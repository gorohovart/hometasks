module EmailCheck

open System
open System.Windows.Forms
open System.Threading
open System.Drawing
open Checker

let mainForm = new Form(Text = "email validator 1.0", Height = 150, Width = 360)

let emailBox = new TextBox(Top = 55, Left = 10, Width = 250)

let checkButton = new Button(Text = "Check!", Top = 55, Left = 270, Width = 60)
let exitButton = new Button(Text = "Exit", Top = 80, Left = 270, Width = 60)

let textSpace = new Label(Top = 35, Left = 10, Height = 20, Width = 200)
let resultSpace = new Label(Top = 85, Left = 115, Height = 20, Width = 40)

mainForm.AcceptButton <- checkButton
mainForm.CancelButton <- exitButton

emailBox.TabIndex <- 0


textSpace.Text <- "Type an email:"

mainForm.Controls.AddRange [|textSpace; emailBox; checkButton; exitButton; resultSpace|]

checkButton.Click.Add (fun _ -> if checkEmail emailBox.Text then resultSpace.Text <- "Valid"
                                                                 resultSpace.BackColor <- Color.Green
                                                            else resultSpace.Text <- "Invalid"
                                                                 resultSpace.BackColor <- Color.Red
                                resultSpace.Refresh()
                       )

exitButton.Click.Add (fun _ -> Application.Exit())

Application.Run(mainForm)