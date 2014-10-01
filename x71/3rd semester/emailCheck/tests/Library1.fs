module Tests

open Checker
open NUnit.Framework

let eps = 0.0001

let compare x y = abs(x - y) < eps

[<TestFixture>]
type Tests() =
    [<Test>]
    member x.Test1() =
        Assert.AreEqual(checkEmail "a@b.cc", true, "Valid")
    [<Test>]
    member x.Test2() =
        Assert.AreEqual(checkEmail "victor.polozov@mail.ru", true, "Valid")
    [<Test>]
    member x.Test3() =
        Assert.AreEqual(checkEmail "my@domain.info", true, "Valid")
    [<Test>]
    member x.Test4() =
        Assert.AreEqual(checkEmail "_.1@mail.com", true, "Valid")
    [<Test>]
    member x.Test5() =
        Assert.AreEqual(checkEmail "paints_department@hermitage.museum", true, "Valid")
    [<Test>]
    member x.Test6() =
        Assert.AreEqual(checkEmail "a@b.c", false, "Invalid")
    [<Test>]
    member x.Test7() =
        Assert.AreEqual(checkEmail "a..b@mail.ru", false, "Invalid")
    [<Test>]
    member x.Test8() =
        Assert.AreEqual(checkEmail ".a@mail.ru", false, "Invalid")
    [<Test>]
    member x.Test9() =
        Assert.AreEqual(checkEmail "yo@domain.somedomain", false, "Invalid")
    [<Test>]
    member x.Test10() =
        Assert.AreEqual(checkEmail "1@mail.ru", true, "Invalid")
