Public Class Player
    Public id As Integer
    Friend name As String
    Public score As Integer
    Public scoreLadder As Integer
    Public scoreSnake As Integer
    Public position As Integer
    Public plimage As Bitmap


    Sub New(i As Integer, s As Integer, sl As Integer, ss As Integer, p As Integer, b As Bitmap)

        id = i
        score = s
        scoreLadder = sl
        scoreSnake = ss
        position = p
        plimage = b
        Console.WriteLine("Object " + id.ToString() + " created, position " + position.ToString())
    End Sub



    Public Sub setName(s As String)
        name = s
    End Sub

End Class
