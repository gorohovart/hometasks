-- DB, 2016, 471
-- Artem Gorokhov
-- Task 1 -----------------------------------------------------------

-- Look at user tables
select * from user_tables;

-- Days since hiring
select ename, round(sysdate - hiredate) as "Days working" from emp;

-- Task 2 -----------------------------------------------------------

-- Look at user constraints
select * from user_constraints;

-- Number of constraints
select count(*) as "Constraints count" from user_constraints;

-- Add new constraint on salary
alter table emp add constraint emp_sal_cons check (sal between 500 and 5000);

-- Check whether constraint was added
select * from user_constraints where constraint_name='EMP_SAL_CONS';

-- Task 3 -----------------------------------------------------------

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

-- Copy data from DEPT to DEPT1
insert into dept1
	select * from dept;

-- Task 4 -----------------------------------------------------------

-- Add view of employees who was hired in winter
create or replace view winter_comers 
as select empno, ename 
from emp 
where extract(month from hiredate) in ('12', '1', '2')
with check option;

-- Look at "winter-comers"-view
select * from winter_comers;


-- Add view of managers who looks after 3 or more employees
create or replace view responsible_managers 
as select ename 
from emp mngs 
where 3 <= (select count(*) from emp wkrs where wkrs.mgr=mngs.empno) 
with check option;

-- Look at "responsible managers" view
select * from responsible_managers;

-- Task 5 -----------------------------------------------------------

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
