-- Task 1

-- Look at user tables
select * from user_tables;

-- Days since hiring
select ename, round(sysdate - hiredate) as "Days working" from emp;

-- Task 2
-- Look at user constraints
select * from user_constraints;

-- Number of constraints
select count(*) as "Constraints count" from user_constraints;

-- Add new constraint on salary
alter table emp add constraint emp_sal_cons check (sal between 500 and 5000);

-- Check whether constraint was added
select * from user_constraints where constraint_name='EMP_SAL_CONS';

-- Task 3

-- Look at user indexes
select * from user_indexes;

-- Create index-organized table same as DEPT
create table dept1
(
    deptno number constraint deptno_nn not null, 
    dname varchar2(14),
    loc   varchar2(13),
    constraint deptno_pk primary key (deptno)
)
organization index;

-- Task 4

-- Add view of employees who was hired in winter
create view winter_comers 
as select empno, ename 
from emp 
where extract(month from hiredate) in ('12', '1', '2')
with check option;

-- Add view of managers who looks after 3 or more employees
create view responsible_managers 
as select ename 
from emp mngs 
where 3 <= (select count(*) from emp wkrs where wkrs.mgr=mngs.empno) 
with check option;

-- Look at "winter-comers"-view
select * from winter_comers;

-- Look at "responsible managers" view
select * from responsible_managers;

-- Task 5

-- Create suitable sequence for DEPT1 table's DEPTNO column
create sequence dept1_seq 
start with 10 
increment by 10 
cache 5;

-- Generate several numbers
select dept1_seq.nextval from dual; 
select dept1_seq.nextval from dual; 
select dept1_seq.nextval from dual; 

-- Check whether new sequence has been added
select * from user_sequences where sequence_name='DEPT1_SEQ';

-- Task 6

-- Create factorial function
create or replace function factorial (n in number) 
return number as 
begin 
    if (n <= 1) then 
        return 1; 
    end if; 
    return n * factorial(n-1); 
end; 
-- Test factorial function
select factorial(0), factorial(1), factorial(3), factorial(5) from dual; 

-- Task 7

-- Create employee counting function
create or replace function emp_count 
return number is 
    var_count number;
begin 
    select count(*) into var_count from emp; 
    return var_count; 
end;
-- Test of EMP_COUNT
select emp_count from dual;

-- Task 8

-- Create procedure for statistics
create or replace procedure stats
(   emp_count    out number,
    dep_count    out number,
    pos_count    out number,
    sal_sum      out number
) is
begin
    select count(*) into emp_count from emp;
    select count(*) into dep_count from dept;
    select count(*) into pos_count 
    from (select distinct job from emp);
    select sum(sal) into sal_sum from emp;
end;
-- Use STATS to print the statistics
declare 
    emp_count number;
    dep_count number;
    pos_count number;
    sum_salary number;
begin
    stats(emp_count, dep_count, pos_count, sum_salary);
    dbms_output.put_line('Employee count = '   || emp_count); 
    dbms_output.put_line('Department count = ' || dep_count); 
    dbms_output.put_line('Position count = '   || pos_count); 
    dbms_output.put_line('Sum of salaries = '  || sum_salary); 
end;

/*
drop table debug_log;
drop sequence debug_log_id_seq;
*/
-- Task 9

-- Create table for debugging
create table debug_log
(
    id number constraint debug_log_id_nn not null,
    logtime date,
    message varchar(256),
    insource varchar(256),
    constraint debug_log_id_pk primary key (id)
);

-- Create procedure for getting the most recent and earliest worker
create or replace procedure marginal_workers
    ( shortterm out date
    , longterm  out date
    ) as
begin
    select min(hiredate) into shortterm from emp;
    select max(hiredate) into longterm from emp;
end marginal_workers;

-- Test the procedure and log the result
declare
    sterm date;
    lterm date;
begin
    marginal_workers(sterm, lterm);
    logmsg('marginal_workers'
          , 'shortest = ' || sterm || '; longest = ' || lterm);
end;
-- Show contents of the log
select * from debug_log;

-- Task 10

-- Create sequence for debug message ids
create sequence debug_log_id_seq
start with 1
increment by 1
minvalue 1
maxvalue 500
cycle
cache 5;

-- Create additional procedure for logging
create or replace procedure logmsg
    ( src in varchar
    , msg in varchar
    ) 
as
    pragma AUTONOMOUS_TRANSACTION;
begin
    insert into debug_log(id, logtime, message, insource) 
        values(debug_log_id_seq.nextval, sysdate, msg, src);
    commit;
exception
    when others then
        return;
end logmsg;

-- Create a function which might throw an exception
create or replace function math_function
    ( a in number
    , b in number
    , c in number
    ) 
return number as
begin
    return a / (b + c);
end math_function;

-- Create procedure to call function and log result or error
create or replace procedure calculate
    ( b in number
    , c in number
    , r out number
    ) as
begin
    r := math_function(10, b, c);
    logmsg('calculate', 'res = ' || r);
exception
    when others then
        logmsg('calculate', substr(sqlerrm, 1, 100));
end calculate;
-- Test the procedure
declare 
    res number;
begin
    calculate(10, 10, res);
    calculate(5, -5, res);
end;

-- Look up the log
select * from debug_log;

-- Task 11

-- Create procedure for errors logging
create or replace procedure logerr (src in varchar) as
begin
    logmsg(src, substr(sqlerrm, 1, 100));
end logerr;

-- Create specification for packager showing info about employees
create or replace package emp_pack as
-- Function salary calculates final salary for an employee
function salary (emp_id number) return number;
-- Function since_hiring counts days since hiring an employee
function since_hiring (emp_id number) return number;
-- Function manager_name returns the name of employee's manager
function manager_name (emp_id number) return varchar;
-- Procedure job_sal_info finds number of employees 
-- and summes their salaries per job
procedure job_sal_info 
    ( job_name   in varchar
    , emp_count  out number
    , summed_sal out number);
-- Procedure mgr_sal_info finds number of employees 
-- and summes their salaries per manager
procedure mgr_sal_info
    ( mgr_id     in varchar
    , emp_count  out number
    , summed_sal out number);
    
end emp_pack;
-- Implementation of EMP_PACK
create or replace package body emp_pack as

function salary (emp_id number) return number as
    res number;
begin
    select sal+nvl(comm,0) into res from emp where empno=emp_id;
    return res;
exception
    when others then
        logerr('emp_pack.salary');
end salary;

function since_hiring (emp_id number) return number as
    res number;
begin
    select round(sysdate - hiredate) into res from emp where empno=emp_id;
    return res;
exception
    when others then
        logerr('emp_pack.since_hiring');
end since_hiring;

function manager_name (emp_id number) return varchar as
    res varchar(50);
begin
    select (select mgr.ename from emp mgr where mgr.empno=wkr.mgr) 
    into res from emp wkr where wkr.empno=emp_id;
    return res;
exception
    when others then
        logerr('emp_pack.manager_name');
end manager_name;

procedure job_sal_info 
    ( job_name   in varchar
    , emp_count  out number
    , summed_sal out number)
as
begin
    select count(*),
           sum(salary(empno))
    into emp_count, summed_sal from emp where job=job_name;
exception
    when others then
        logerr('emp_pack.job_sal_info');
end job_sal_info;
    
    
procedure mgr_sal_info
    ( mgr_id     in varchar
    , emp_count  out number
    , summed_sal out number)
as
begin
    select count(*),
           sum(salary(empno)) 
    into emp_count, summed_sal from emp where mgr=mgr_id;
exception
    when others then
        logerr('emp_pack.mgr_sal_info');
end mgr_sal_info;

end emp_pack;


-- Testing EMP_PACK
select ename, emp_pack.salary(empno) as salary from emp;
select ename, emp_pack.since_hiring(empno) as days from emp;
select ename, emp_pack.manager_name(empno) as manager from emp;

declare
    job_name varchar(50);
    mgr_id number;
    mgr_name varchar(50);
    emp_count number;
    summed_sal number;
begin
    job_name := 'SALESMAN';
    emp_pack.job_sal_info(job_name, emp_count, summed_sal);
    logmsg('emp_pack test', 'there are ' || emp_count || ' ' || job_name 
                                         || 's with summed salary ' 
                                         || summed_sal);
    mgr_id := 7698;
    emp_pack.mgr_sal_info(mgr_id, emp_count, summed_sal);
    select ename into mgr_name from emp where empno=mgr_id;
    logmsg('emp_pack test', 'there are ' || emp_count 
                                         || ' workers with summed salary ' 
                                         || summed_sal
                                         || ' for manager '
                                         || mgr_name);
end;

create or replace package dept_pack as
function emp_in_dept (dept_id number) return number;
function sal_in_dept (dept_id number) return number;
procedure dept_sal_stats 
    ( dept_id in number
    , minsal out number
    , avgsal out number
    , maxsal out number);
end dept_pack;

create or replace package body dept_pack as
function emp_in_dept (dept_id number) return number as
    res number;
begin
    select count(*) into res from emp where deptno=dept_id;
    return res;
exception
    when others then
        logerr('dept_pack.emp_in_dept');
end emp_in_dept;

function sal_in_dept (dept_id number) return number as
    res number;
begin
    select sum(sal) into res from emp where deptno=dept_id;
    return res;
exception
    when others then
        logerr('dept_pack.sal_in_dept');
end sal_in_dept;

procedure dept_sal_stats 
    ( dept_id in number
    , minsal out number
    , avgsal out number
    , maxsal out number)
as
begin
    select min(emp_pack.salary(empno)),
           round(avg(emp_pack.salary(empno))),
           max(emp_pack.salary(empno))
    into minsal, avgsal, maxsal from emp where deptno=dept_id;
exception
    when others then
        logerr('dept_pack.dept_sal_stats');
end dept_sal_stats;

end dept_pack;

-- Testing DEPT_PACK
select dname, dept_pack.emp_in_dept(deptno) from dept;
select dname, dept_pack.sal_in_dept(deptno) from dept;

declare 
    dept_id number;
    dept_name varchar(30);
    minsal number;
    avgsal number;
    maxsal number;
begin
    dept_id := 30;
    dept_pack.dept_sal_stats(dept_id, minsal, avgsal, maxsal);
    select dname into dept_name from dept where deptno=dept_id;
    logmsg('dept_pack test', 'Salaries in ' || dept_name 
                             || ': min=' || minsal
                             || ', avg=' || avgsal
                             || ', max=' || maxsal);
end;

select * from debug_log;
