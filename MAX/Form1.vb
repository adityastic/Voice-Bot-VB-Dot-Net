Imports System.Speech.Recognition
Imports System.Speech.Recognition.SrgsGrammar
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection
Public Class Form1

    Private recognizer As SpeechRecognizer
    Dim questionevent As String
    Dim max = CreateObject("Sapi.spvoice")


    Public Sub New()


        InitializeComponent()

        recognizer = New SpeechRecognizer()
        AddHandler recognizer.SpeechDetected, AddressOf recognizer_SpeechDetected
        AddHandler recognizer.SpeechRecognitionRejected, AddressOf recognizer_SpeechRecognitionRejected
        AddHandler recognizer.SpeechRecognized, AddressOf recognizer_SpeechRecognized





        Dim grammar As New GrammarBuilder()
        grammar.Append(New Choices(System.IO.File.ReadAllLines("Commands.txt")))

        recognizer.LoadGrammar(New Grammar(grammar))


       
    End Sub


    Private Sub recognizer_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)

        Dim random As New Random

        Dim number As Integer = random.Next(1, 10)





       

        Select Case e.Result.Text.ToUpper





            'GREETINGS


            Case Is = "TELL ME ABOUT YOU MAX", "WHO ARE YOU"
                PictureBox1.Visible = True
                max.SPEAK("I'M MAX. VERSION 1 POINT O POINT O  ........   YOUR VIRTUAL ASSISTANT.. ")
            Case Is = "HELLO MAX", "HELLO", "HAI", "HAI MAX"
                PictureBox1.Visible = True
                max.speak("HELLO! HOW ARE YOU? ")

               
            Case Is = "GOODBYE MAX", "GOODBYE"
                PictureBox1.Visible = True
                max.speak("THANK YOU FOR WATCHING!")
                max.SPEAK("GOODBYE!TILL NEXT TIME!")
                Me.Close()
            Case Is = "SAY HELLO MAX"
                PictureBox1.Visible = True
                max.SPEAK("HELLO GUYS HAVE A NICE DAY")
            Case Is = "IM FINE", "GREAT", "IM GREAT", "FINE"
                PictureBox1.Visible = True
                max.SPEAK("THAT'S NICE TO HEAR!")
            Case Is = "SAY HELLO TO MY GRANDMA"
                PictureBox1.Visible = True
                max.SPEAK("HELLO GRANDMA")
            Case Is = "SAY HELLO TO MY MAMA"
                PictureBox1.Visible = True
                max.SPEAK("HELLO MOTHER")

            Case Is = "DO YOU HAVE QUOTES", "DO YOU HAVE QUOTES MAX"
                PictureBox1.Visible = True
                max.SPEAK("YES I HAVE  ......   TO LOVE IS NOTHING ..  TO BE LOVED IS SOMETHING ..   TO LOVE AND BE LOVED IS EVERYTHING!")
                max.SPEAK("HASHTAG WHOGOT ... HA!HA!HA!HA!")
                'COMMAnDS
            Case Is = "HIDE COMMANDS"
                PictureBox1.Visible = True
                max.speak("HIDING COMMANDS")
                ltbCommands.Visible = False

            Case Is = "SHOW COMMANDS"
                PictureBox1.Visible = True
                max.SPEAK("SHOWING COMMANDS")
                ltbCommands.Visible = True
            Case Is = "WHAT TIME IS IT"
                PictureBox1.Visible = True
                max.SPEAK(Format(Now, "Short Time"))
            Case Is = "WHAT DAY IS IT"
                PictureBox1.Visible = True
                max.SPEAK(Format(Now, "Long Date"))
            Case Is = "VOLUME DOWN"
                PictureBox1.Visible = True
                max.speak("Downing Volume")
                AxWindowsMediaPlayer1.settings.volume -= 10
                Form2.AxWindowsMediaPlayer1.settings.volume -= 10
                If AxWindowsMediaPlayer1.settings.volume = 10 And Form2.AxWindowsMediaPlayer1.settings.volume = 10 Then
                    PictureBox1.Visible = True
                    max.speak("THAT IS THE LOWEST VOLUME")
                    AxWindowsMediaPlayer1.settings.volume += 10
                End If
            Case Is = "VOLUME UP"
                PictureBox1.Visible = True
                AxWindowsMediaPlayer1.settings.volume += 10
                Form2.AxWindowsMediaPlayer1.settings.volume += 10
                If AxWindowsMediaPlayer1.settings.volume = 100 And Form2.AxWindowsMediaPlayer1.settings.volume = 100 Then
                    PictureBox1.Visible = True
                    max.speak("THAT IS THE HIGHEST VOLUME")
                End If
            Case Is = "HIDE MUSICS", "HIDE MUSIC"
                PictureBox1.Visible = True
                max.SPEAK("HIDING MUSICS")
                ltbMusics.Visible = False
            Case Is = "CLOSE", "CLOSE VIDEO"
                PictureBox1.Visible = True
                Form2.Close()
            Case Is = "HIDE VIDEOS", "HIDE VIDEO"
                PictureBox1.Visible = True
                max.SPEAK("HIDING")
                ltbVideos.Visible = False
            Case Is = "STOP"
                PictureBox1.Visible = True
                AxWindowsMediaPlayer1.Ctlcontrols.stop()

            Case Is = "PLAY VIDEOS", "PLAY VIDEO", "VIDEO", "VIDEOS", "SHOW VIDEOS", "SHOW VIDEO"
                max.SPEAK("HERE IS THE VIDEOS PLAYLIST")
                ltbVideos.Visible = True

            Case Is = "PLAY A MUSIC", "MUSICS", "MUSIC", "SHOW MUSICS", "SHOW MUSIC"
                max.speak("HERE IS THE MUSIC PLAYLIST")
                ltbMusics.Visible = True
            Case Is = "FULLSCREEN"
                Form2.WindowState = FormWindowState.Maximized
                Form2.AxWindowsMediaPlayer1.fullScreen = True


                'play video and musics

            Case Is = "PlAY GOING DOWN FOR REAL", "GOING DOWN FOR REAL"
                max.SPEAK("PLAYING")
                AxWindowsMediaPlayer1.URL = "C:\Users\Warren\Music\Flo Rida – GDFR (K Theory Remix) [Official Audio].mp3"
            Case Is = "PLAY ENCORE", "ENCORE"
                max.SPEAK("PLAYING")
                AxWindowsMediaPlayer1.URL = "C:\Users\Warren\Music\Jay-Z & Linkin Park - Numb-Encore dirty version.mp3"
            Case Is = "PlAY TRUMPETS", "TRUMPETS"
                max.SPEAK("PLAYING")
                AxWindowsMediaPlayer1.URL = "C:\Users\Warren\Music\Trumpets Jason Derulo With Lyrics.mp3"
            Case Is = "PlAY WORTH IT", "WORTH IT"
                max.SPEAK("PLAYING")
                AxWindowsMediaPlayer1.URL = "C:\Users\Warren\Music\WORTH IT.mp3"

            Case Is = "PlAY SUGAR", "SUGAR"
                max.SPEAK("PLAYING")
                AxWindowsMediaPlayer1.URL = "C:\Users\Warren\Music\Sugar.mp3"
            Case Is = "PlAY WRAP UP", "WRAP UP"
                max.SPEAK("PLAYING")
                AxWindowsMediaPlayer1.URL = "C:\Users\Warren\Music\Wrap up.mp3"


            Case Is = "PLAY AFTER EARTH", "AFTER EARTH"
                max.SPEAK("PLAYING")
                Form2.Show()
                Form2.AxWindowsMediaPlayer1.URL = "D:\Movie 2015\After Earth.MP4"
            Case Is = "PLAY THE AMAZING SPIDERMAN 2", "THE AMAZING SPIDERMAN 2"
                max.SPEAK("PLAYING")
                Form2.Show()
                Form2.AxWindowsMediaPlayer1.URL = "D:\Movie 2015\The.Amazing.Spider-Man.2.2014.1080p.BluRay.6CH.ShAaNiG.com.MP4"

            Case Else : max.speak("PARDON")
        End Select

    End Sub
    Private Sub recognizer_SpeechDetected(ByVal sender As Object, ByVal e As SpeechDetectedEventArgs)
        Label1.ForeColor = Color.Black
        Label1.Text = "Voice Detected"
        PictureBox1.Visible = False
        Label3.Visible = True
        Label4.Visible = True

    End Sub

    Private Sub recognizer_SpeechRecognitionRejected(ByVal sender As Object, ByVal e As SpeechRecognitionRejectedEventArgs)
        Label1.ForeColor = Color.Red
        Label1.Text = "Voice not Detected"


    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Commands() As String = System.IO.File.ReadAllLines("Commands.txt")
        For i As Integer = 0 To Commands.Count - 1
            ltbCommands.Items.Add(Commands(i))

        Next

    End Sub

    Public WM_SYSCOMMAND As Integer = &H112
    Public SC_MONITORPOWER As Integer = &HF170

    <DllImport("user32.dll")> _
      Private Shared Function SendMessage(ByVal hWnd As Integer, ByVal hMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    End Function
  
 
    Sub ShutdownProcedure()
        If questionevent = "Shutdown" Then
            System.Diagnostics.Process.Start("shutdown", "-s")
        ElseIf questionevent = "Restart" Then
            System.Diagnostics.Process.Start("shutdown", "-r")
        ElseIf questionevent = "Log Off" Then
            System.Diagnostics.Process.Start("shutdown", "-l")
        End If
    End Sub
    




End Class
