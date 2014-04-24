let randomiseTF() =
    let rnd = new System.Random()
    if rnd.Next(2) = 0 then false
    else true

type Named(name:string) = 
    member this.Name = name

[<AbstractClass>]
type Human(name:string, age:int) = 
    inherit Named(name)

type Animal(name:string, isPet:bool) =
    inherit Named(name)

type Cat(name:string, color:string, hasFur:bool) =
    inherit Animal(name, true)
    let mutable mood = 5
    member this.Mood = mood 
    member this.Color = color
    member this.Ownwer = None
    member this.ThornTail() =
        if color = "black"
        then mood <- mood - 5
        else mood <- mood - 2

    member this.Feed() = mood <- mood + 1

    override this.ToString() =
        color + " cat " + name + " has mood: " + 
            if mood > 5 then "good"
            else if mood > 3 then "bad"
            else "terrible"

type Worker(name:string, age:int) = 
    inherit Human(name, age)
    let mutable salary = 0
    let mutable cat = None
    let mutable isDead = false
    let mutable Age = age
    member this.age = Age
    member this.isAlive = not isDead
    member this.setPet p = cat <- p
    member this.getPet =
        cat <- Some(new Cat("Kot", "blue", true))
        printfn ("You have got a cat now!")
    member this.setSalary x = salary <- x
    member this.getSalary = salary
    member this.grow = this.setSalary (salary * 10)
                       printfn ("Grats!You have grown to %A $ salary!") this.getSalary
    member this.tryToGrow = if randomiseTF() then this.grow
    member this.year =
        if randomiseTF() then isDead <- true
                              printfn ("Sorry, you died.")
                         else
                              Age <- (Age + 1)
                              printfn ("Age %A. You are a worker with %A $ salary now.") this.age this.getSalary
                              if randomiseTF() && cat = None then this.getPet

type Student(name:string, age:int) = 
    inherit Human(name, age)
    let mutable courseNum = 1
    let mutable worker = None
    let mutable cat = None
    let mutable Age = age

    member this.age = Age
    member this.getWorker = match worker with |Some(x) -> x
                                              |None -> failwith "Error"

    member this.isWorker = if worker = None then false
                           else true
    member this.setPet p = cat <- p 

    member this.getPet =
        cat <- Some(new Cat("Kot", "blue", true))
        printfn ("You have got a cat now!")

    member this.becomeWorker =
        let w = new Worker(name, Age)
        if courseNum < 4 then w.setSalary(100 * courseNum)
        else w.setSalary(1000)
        w.setPet(cat)
        worker <- Some(w)
        printfn ("Grats!You have become a worker with %A $ salary!") w.getSalary

    member this.exam = 
        let isPassed = randomiseTF()
        if isPassed && courseNum < 4 then courseNum <- (courseNum + 1)
                                          printfn ("Grats!You have passed exam.")
        else this.becomeWorker
    member this.year =
        Age <- (Age + 1)
        printfn ("Age %A. You are on %A course now.") this.age courseNum
        if randomiseTF() && cat = None then this.getPet
        this.exam

type Schoolboy(name:string, age:int) = 
    inherit Human(name, age)
    let mutable classNum = 1
    let mutable student = None
    let mutable worker = None
    let mutable cat = None
    let mutable Age = age
    
    member this.age = Age
    member this.getWorker = match worker with |Some(x) -> x
                                              |None -> failwith "Error"
    member this.getStudent = match student with |Some(x) -> x
                                                |None -> failwith "Error"

    member this.isWorker = if worker = None then false
                           else true
    member this.isStudent = if student = None then false
                            else true
    member this.becomeStudent =
        let s = new Student(name, Age)
        s.setPet(cat)
        student <- Some(s)
        printfn ("Grats!You have become a student with 0 salary! ;)")

    member this.becomeWorker =
        let w = new Worker(name, Age)
        if classNum < 11 then w.setSalary(1)
        else w.setSalary(10)
        w.setPet(cat)
        worker <- Some(w)
        printfn ("Grats!You have become a worker with %A $ salary!") w.getSalary
                
    member this.getPet =
        cat <- Some(new Cat("Kot", "blue", true))
        printfn ("You have got a cat now!")
        
    member this.exam = 
        let isPassed = randomiseTF()
        if isPassed then 
            printfn ("Grats!You have passed exam.")
            if classNum = 9 then classNum <- 10
                            else this.becomeStudent
        else printfn ("You have failed exam.")
             this.becomeWorker

    member this.year =
        Age <- (Age + 1)
        printfn ("Age %A. You are in %A class now.") this.age classNum
        let isWantPet = randomiseTF()
        if isWantPet && cat = None then this.getPet
        if classNum = 9 || classNum = 11 then this.exam
        else classNum <- (classNum + 1)


let life =
    let s = new Schoolboy("Vasya", 6)
    
    while (not s.isWorker) && (not s.isStudent) do
        s.year
    
    if s.isStudent then
        let st = s.getStudent
        while not st.isWorker do
            st.year

        let w = st.getWorker
        while w.isAlive do
            w.year

    else let w = s.getWorker
         while w.isAlive do
             w.year

life
