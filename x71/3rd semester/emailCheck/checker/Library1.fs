module Checker

open System.Text.RegularExpressions



let checkEmail email =
    let login = "[\w]([\.]|([.]?[\w]){0,30})[a-zA-Z\d]"
    let afterAt = "([\w\d]{2,}[\.]){1,}(aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|xxx|[a-z][a-z])"
    let emailRegex = new Regex("^" + login + "@" + afterAt + "$");
    emailRegex.IsMatch(email)
