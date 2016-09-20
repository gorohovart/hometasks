Imports CSharp

Public Class MedvedVBasic
    Inherits MedvedCSharp
    Public Overrides Sub MeetMedved()
        Console.WriteLine("Preved from VB")
        MyBase.MeetMedved()
    End Sub
End Class
