namespace FSharp

type MedvedFSharp() =
    inherit VisualBasic.MedvedVBasic()
    override this.MeetMedved() =
        printfn "Preved from F#"
        base.MeetMedved()