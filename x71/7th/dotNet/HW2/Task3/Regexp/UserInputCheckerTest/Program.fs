// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Regexp


[<EntryPoint>]
let main argv = 
    let testStrings = System.IO.File.ReadAllLines("..\\..\\test.txt")

    for line in testStrings do

        if UserInputChecker.IsZip line
        then
            Program.PrintCheckSucceed(line,"a ZIP") 
        elif UserInputChecker.IsPhoneNumber line
        then
            Program.PrintCheckSucceed(line,"a phone number")
        elif UserInputChecker.IsEmergencyPhoneNumber line
        then
            Program.PrintCheckSucceed(line,"an emergency phone number")
        elif UserInputChecker.IsEmail line
        then
            Program.PrintCheckSucceed(line,"an email")
        else
            Program.PrintCheckFailed(line)
    0 // return an integer exit code
