
Public Class Form1
    Dim WithEvents reg As New Speech.Recognition.SpeechRecognitionEngine

    Dim Grammar As New Speech.Recognition.DictationGrammar()

    Private Sub speak(ByVal str As String)
        Dim synth As New Speech.Synthesis.SpeechSynthesizer
        synth.SpeakAsync(str)
    End Sub

    Private Function basicoptions() As Speech.Recognition.GrammarBuilder
        Dim options As New Speech.Recognition.GrammarBuilder("Start")
        options.Append(New Speech.Recognition.Choices("Notepad", "Browser"))
        Return options
    End Function
    Private Function colors() As Speech.Recognition.GrammarBuilder
        Dim options As New Speech.Recognition.GrammarBuilder()
        options.Append(New Speech.Recognition.Choices("Yellow", "Blue", "Green", "Red"))
        Return options
    End Function
    Private Function google() As Speech.Recognition.GrammarBuilder
        Dim options As New Speech.Recognition.GrammarBuilder()
        options.Append(New Speech.Recognition.Choices("Google", "Search"))
        options.AppendDictation()
        Return options
    End Function
    Private Function OGCommands() As Speech.Recognition.GrammarBuilder
        Dim options As New Speech.Recognition.GrammarBuilder
        options.Append(New Speech.Recognition.Choices(IO.File.ReadAllLines("Commands.txt")))
        options.AppendDictation()
        Return options
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ""
        reg.SetInputToDefaultAudioDevice()
        reg.LoadGrammar(New Speech.Recognition.Grammar(google))
        reg.LoadGrammar(New Speech.Recognition.Grammar(basicoptions))
        reg.LoadGrammar(New Speech.Recognition.Grammar(OGCommands))
        reg.LoadGrammar(New Speech.Recognition.Grammar(New Speech.Recognition.GrammarBuilder("exit")))
        reg.LoadGrammar(New Speech.Recognition.DictationGrammar())
        reg.RecognizeAsync(Speech.Recognition.RecognizeMode.Multiple)
    End Sub
    Private Sub reg_RecognizeCompleted(ByVal sender As Object, ByVal e As Speech.Recognition.RecognizeCompletedEventArgs) Handles reg.RecognizeCompleted
        reg.RecognizeAsync(Speech.Recognition.RecognizeMode.Multiple)
    End Sub
    Private Sub reg_SpeechRecognized(ByVal sender As Object, ByVal e As Speech.Recognition.SpeechRecognizedEventArgs) Handles reg.SpeechRecognized
        Label1.Text = Label1.Text + e.Result.Text
        Dim cmd As String = e.Result.Text.ToLower
        If InStr(cmd, "search") Or InStr(cmd, "google") Then
            Process.Start("chrome.exe", "https://www.google.co.in/search?site=&source=hp&q=" + cmd.Split(" ")(1))
        End If
        Select Case cmd
            Case "exit"
                Application.Exit()
            Case Is = "hello", "hey", "hai"
                speak("HELLO! HOW ARE YOU?")
            Case "volume up"
                speak("No! Shut up")
            Case "start notepad"
                Process.Start("notepad.exe")
            Case "start browser"
                Process.Start("chrome.exe")
            Case Is = "goodbye"
                speak("THANK YOU FOR WATCHING!")
                speak("GOODBYE!TILL NEXT TIME!")
                Me.Close()
            Case Is = "say hello "
                speak("HELLO GUYS HAVE A NICE DAY")
            Case Is = "im fine", "great", "im great", "fine"
                speak("THAT'S NICE TO HEAR!")
            Case Is = "say hello to my grandma"
                speak("HELLO GRANDMA")
            Case Is = "say hello to my mama"
                speak("HELLO MOTHER")
            Case Is = "do you have quotes"
                speak("YES I HAVE  ......   TO LOVE IS NOTHING ..  TO BE LOVED IS SOMETHING ..   TO LOVE AND BE LOVED IS EVERYTHING!")
                speak("HASHTAG WHOGOT ... HA!HA!HA!HA!")
        End Select

    End Sub

    Private Sub reg_SpeechDetected(sender As Object, e As Speech.Recognition.SpeechDetectedEventArgs) Handles reg.SpeechDetected
        Label2.Text = "Detected"
        Label2.ForeColor = Color.Green
    End Sub

    Private Sub reg_SpeechRecognitionRejected(sender As Object, e As Speech.Recognition.SpeechRecognitionRejectedEventArgs) Handles reg.SpeechRecognitionRejected
        Label2.Text = "Not Detected"
        Label2.ForeColor = Color.Red
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        speak(RichTextBox1.Text.ToString)
    End Sub
End Class
