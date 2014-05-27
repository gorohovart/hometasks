// Gorokhov Artem (c) 2014
// 2nd semester HW 4
// Chat with bot
// Using this library: http://aimlbot.sourceforge.net/

open System
open System.Windows.Forms
open System.Threading
open System.Drawing
open AIMLbot

let myBot = new Bot()
myBot.loadSettings()
let myUser = new AIMLbot.User("senderUser", myBot);
myBot.loadAIMLFromFiles();

let chatForm = new Form(Text = "ChatBot v0.1", Height = 350, Width = 430)

let dialogBox = new TextBox(Top = 10, Left = 10, Width = 400, Height = 220)
let messageBox = new TextBox(Top = 250, Left = 10, Width = 340)

let sendMessageButton = new Button(Text = "Enter", Top = 250, Left = 350, Width = 60)
let exitButton = new Button(Text = "Exit", Top = 275, Left = 175)

let thinkSpace = new Label(Top = 230, Left = 10, Height = 20, Width = 200)

chatForm.Icon <- new Icon("Icon.ico")
chatForm.AcceptButton <- sendMessageButton
chatForm.CancelButton <- exitButton

dialogBox.Multiline <- true
dialogBox.WordWrap <- true
dialogBox.ReadOnly <- true
dialogBox.ScrollBars <- ScrollBars.Vertical
messageBox.TabIndex <- 0
dialogBox.TabIndex <- 2

thinkSpace.Text <- "Type your message:"

chatForm.Controls.AddRange [|thinkSpace; dialogBox; messageBox; sendMessageButton; exitButton|]

sendMessageButton.Click.Add (fun _ -> let s = messageBox.Text
                                      let r = new Request(s, myUser, myBot)
                                      let res = myBot.Chat(r)
                                      dialogBox.AppendText("You: " + s + "\n")
                                      messageBox.Text <- ""
                                      messageBox.Refresh()

                                      for i in 1..3 do
                                          thinkSpace.Text <- "Thinking"
                                          thinkSpace.Refresh()
                                          Thread.Sleep(300)
                                          for i in 1..3 do
                                              thinkSpace.Text <- thinkSpace.Text + "."
                                              thinkSpace.Refresh()
                                              Thread.Sleep(300)

                                      thinkSpace.Text <- "Type your message:"
                                      thinkSpace.Refresh()

                                      dialogBox.AppendText("Bot: " + res.Output.ToString() + "\n")
                                      )

exitButton.Click.Add (fun _ -> Application.Exit())

Application.Run(chatForm)