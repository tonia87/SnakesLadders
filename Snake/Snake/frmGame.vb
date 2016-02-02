Imports System.ComponentModel

Public Class frmGame
    Dim p1 As Player
    Dim p2 As Player
    Dim turn As Player



    Private Sub frmGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DesignFormGame()
        InitGame()
        ShowScore()


    End Sub
    Private Sub DesignFormGame()
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.BackgroundImage = My.Resources.back2

        lblP1.BackColor = Color.Transparent
        lblP2.BackColor = Color.Transparent

        lblPlayNext.ForeColor = Color.Gold
        lblP1.ForeColor = Color.Gold
        lblP2.ForeColor = Color.Gold
        rbnPlayer1.ForeColor = Color.Gold
        rbnPlayer2.ForeColor = Color.Gold
        

        lblLadders1.BackColor = Color.Transparent
        lblLadders2.BackColor = Color.Transparent
        lblSnakes1.BackColor = Color.Transparent
        lblSnakes2.BackColor = Color.Transparent
        lblMessage.BackColor = Color.Transparent

        lblLadders1.ForeColor = Color.Gold
        lblLadders2.ForeColor = Color.Gold
        lblSnakes1.ForeColor = Color.Gold
        lblSnakes2.ForeColor = Color.Gold
        lblMessage.ForeColor = Color.Gold


        pbxDice.Image = My.Resources.dice1
        pbxDice.Visible = False
        pbxSnake.Visible = False
        pbxSnake.Image = My.Resources.snake


    End Sub
    Private Sub InitGame()

        p1 = New Player(1, 0, 0, 0, 1, My.Resources.circle1)
        p2 = New Player(2, 0, 0, 0, 1, My.Resources.circle2)
        valueDice = 0
        lblMessage.Text = "Please enter your name: player " + p1.id.ToString() + " and player " + p2.id.ToString()
        lblLadders1.Text = ""
        lblLadders2.Text = ""
        lblSnakes1.Text = ""
        lblSnakes2.Text = ""
        rbnPlayer1.Checked = True
        turn = p1
        flag = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btn37.Click

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click


        For i As Integer = 0 To 80 Step 1
            tablePosition(i).BackgroundImageLayout = ImageLayout.Stretch
            tablePosition(i).ImageAlign = ContentAlignment.MiddleCenter
        Next i
        For i As Integer = 0 To 80 Step 1
            If tablePosition(i).Text = "SNAKE" Then
                tablePosition(i).Text = ""
                tablePosition(i).Image = My.Resources.facesn
            End If
        Next i

        If txtInput1.Text <> "Player1" And txtInput2.Text <> "Player2" Then
            p1.setName(txtInput1.Text)
            rbnPlayer1.Text = p1.name
            lblP1.Text = p1.name
            p2.setName(txtInput2.Text)
            rbnPlayer2.Text = p2.name
            lblP2.Text = p2.name
            lblMessage.Text = "Names registered ! Click on the dice, " + turn.name + " !"


            pbxDice.Visible = True
            pbxLadder1.Image = My.Resources.ladder1
            pbxLadder2.Image = My.Resources.ladder1
            pbxLadder3.Image = My.Resources.ladder1
            pbxLadder4.Image = My.Resources.ladder1
            pbxLadder5.Image = My.Resources.ladder1
            pbxLadder6.Image = My.Resources.ladder1
            pbxLadder7.Image = My.Resources.ladder1
            pbxLadder8.Image = My.Resources.ladder1





            btnOk.Enabled = False
            btnOk.Visible = False
            txtInput1.Enabled = False
            txtInput1.Visible = False
            txtInput2.Enabled = False
            txtInput2.Visible = False
        Else
            lblMessage.Text = "Please enter valid names..."
        End If

    End Sub
    Private Sub ShowScore()
        lblLadders1.Text = "Ladders " + p1.scoreLadder.ToString()
        lblSnakes1.Text = "Snakes " + p1.scoreSnake.ToString()
        lblLadders2.Text = "Ladders " + p2.scoreLadder.ToString()
        lblSnakes2.Text = "Snakes " + p2.scoreSnake.ToString()
    End Sub
    Private Function CheckLadder()
        'check out in pbxClick!!!
        'If CheckPosition() = 0 Then
        Dim previous As Integer = turn.position

        If turn.position = 3 Then
            turn.position = 21
            turn.scoreLadder += 1
        ElseIf turn.position = 7 Then
            turn.position = 12
            turn.scoreLadder += 1
        ElseIf turn.position = 30 Then
            turn.position = 43
            turn.scoreLadder += 1
        ElseIf turn.position = 39 Then
            turn.position = 70
            turn.scoreLadder += 1
        ElseIf turn.position = 48 Then
            turn.position = 61
            turn.scoreLadder += 1
        ElseIf turn.position = 46 Then
            turn.position = 64
            turn.scoreLadder += 1
        ElseIf turn.position = 69 Then
            turn.position = 76
            turn.scoreLadder += 1
        ElseIf turn.position = 72 Then
            turn.position = 73
            turn.scoreLadder += 1
        End If
        ' End If
        If CheckPosition() = 0 Then
            tablePosition(previous - 1).BackgroundImage = Nothing

            tablePosition(turn.position - 1).BackgroundImage = turn.plimage

        Else
            'if unable to move through snake---stay put
            tablePosition(previous - 1).BackgroundImage = turn.plimage

        End If

        Return turn.scoreLadder

    End Function
    Private Function CheckSnake()
        'check again before change!!!
        'If CheckPosition() = 0 Then
        Dim previous As Integer = turn.position

        If turn.position = 14 Then
            turn.position = 5
            turn.scoreSnake += 1
            pbxSnake.Visible = True
        ElseIf turn.position = 45 Then
            turn.position = 11
            turn.scoreSnake += 1
            pbxSnake.Visible = True
        ElseIf turn.position = 54 Then
            turn.position = 36
            turn.scoreSnake += 1
            pbxSnake.Visible = True
        ElseIf turn.position = 65 Then
            turn.position = 62
            turn.scoreSnake += 1
            pbxSnake.Visible = True
        ElseIf turn.position = 74 Then
            turn.position = 38
            turn.scoreSnake += 1
            pbxSnake.Visible = True
        ElseIf turn.position = 79 Then
            turn.position = 32
            turn.scoreSnake += 1
            pbxSnake.Visible = True
        End If
        'End If

        lblMessage.Text += "Snake up! "
        If CheckPosition() = 0 Then

            tablePosition(previous - 1).BackgroundImage = Nothing

            tablePosition(turn.position - 1).BackgroundImage = turn.plimage

        Else
            'if unable to move through snake---stay put
            tablePosition(previous - 1).BackgroundImage = turn.plimage

        End If
        Return turn.scoreSnake


    End Function

    Private Sub lblLadders1_Click(sender As Object, e As EventArgs) Handles lblLadders1.Click

    End Sub

    Private Sub rbnPlayer2_CheckedChanged(sender As Object, e As EventArgs) Handles rbnPlayer2.CheckedChanged

    End Sub

    Private Sub lblLadders2_Click(sender As Object, e As EventArgs) Handles lblLadders2.Click

    End Sub

    Private Sub pbxDice_Click(sender As Object, e As EventArgs) Handles pbxDice.Click

        pbxSnake.Visible = False

        Dim previous As Integer = turn.position
        'empty icon
        tablePosition(previous - 1).BackgroundImage = Nothing

        'roll dice
        valueDice = generator.Next(1, 6)
        lblDice.Text = valueDice.ToString()
        turn.position = previous + valueDice
        'check new position if available
        If CheckPosition() = 0 Then
            'six or less available places from previous
            If 81 - previous < 7 Then
                'if close to finish---keep previous position
                'to check available positions
                lblMessage.Text = ""
                turn.position = previous
                FinishMove()
                CheckPosition()



                pbxDice.Visible = True


                'exit click
            Else
                'raise position
                CheckLadder()
                CheckSnake()
                'if not an exchange, print folowing message
                If CheckPositionExchange() = 0 Then
                    lblMessage.Text = turn.name + " ,new position: " + turn.position.ToString() + " !"

                Else
                    CheckPosition()
                End If

                tablePosition(turn.position - 1).BackgroundImage = turn.plimage
                tablePosition(turn.position - 1).Enabled = False
                pbxDice.Visible = False

            End If
        Else
            'before dice---return to default
            tablePosition(previous - 1).BackgroundImage = turn.plimage
            tablePosition(previous - 1).Enabled = False

        End If

            'after check , show on labels
            ShowScore()
        
        'check winner 
        If flag = False Then
            'then exchange turn 
            ExchangeTurn()
            lblMessage.Text += turn.name + ", it's your turn...Roll the dice!"
            pbxDice.Visible = True
        End If



    End Sub
    Private Function CheckPosition()
        If p1.position = p2.position Then
            lblMessage.Text = turn.name + ", you may not move!! Position reserved !"
            'position before dice
            turn.position -= valueDice
            'keep icons in previous position
            
            Return 1
        Else
            Return 0

        End If
    End Function
    Private Sub ExchangeTurn()
        'choose all but positions on Play Again buttons
        If turn.position <> 2 And turn.position <> 23 And turn.position <> 34 And turn.position <> 58 And turn.position <> 67 Then

            If turn Is p1 Then
                turn = p2
                rbnPlayer1.Checked = False
                rbnPlayer2.Checked = True

            Else
                turn = p1
                rbnPlayer1.Checked = True
                rbnPlayer2.Checked = False
            End If
        Else
            lblMessage.Text = "Oops! " + turn.name + " plays again !!"
        End If

        ' lblMessage.Text = "Click on the dice, " + turn.name + " !"
    End Sub
    Private Function CheckPositionExchange()
        If turn.position = 41 Or turn.position = 51 Then

            Dim positionTemp As Integer
            'exchange positions
            If turn Is p1 Then
                positionTemp = p1.position
                p1.position = p2.position
                p2.position = positionTemp
            ElseIf turn Is p2 Then
                positionTemp = p2.position
                p2.position = p1.position
                p1.position = positionTemp
            End If

            'exchange---update icons position
            tablePosition(p1.position - 1).BackgroundImage = p1.plimage
            tablePosition(p2.position - 1).BackgroundImage = p2.plimage

            'if an exchange,print own message
            lblMessage.Text = "You've just switched places!!!"
            Return 1
        Else
            Return 0
        End If

    End Function
    Private Sub FinishMove()
        'value of dice---place of player
        Dim previous As Integer = turn.position  'current position
        Dim a As Integer = previous + valueDice  'maximum



        'reset icon
        tablePosition(previous - 1).BackgroundImage = Nothing


        If a > 81 Then
            ' '' ''use to count available places 
            Dim counterRest As Integer = 81 - previous
            Dim restOfDice As Integer = valueDice - counterRest
            ' '' ''only change copy of turn.position
            '' ''While previous < 81
            '' ''    previous += 1
            '' ''    counter += 1
            '' ''End While
            'after count of available positions,sub

            ''final position::: 
            turn.position = 81 - restOfDice
            If turn.position = 79 Then
                CheckSnake()
                lblMessage.Text = "Well, " + turn.name + " ,that was far from lucky..."
                'escape if snake
                Return
            End If
            'else move on to changing icon
            tablePosition(turn.position - 1).BackgroundImage = turn.plimage


            lblMessage.Text = "Value of dice " + valueDice.ToString() + " ! " + turn.name + " ,wait up! ;) ;)"


        ElseIf a = 81 Then

            turn.position += valueDice

            'update icons

            tablePosition(turn.position - 1).BackgroundImage = turn.plimage

            lblMessage.Text = "We have a winner! Congrats, " + turn.name + " !!!"
            flag = True
            'disable table
            For i As Integer = 0 To 80 Step 1
                tablePosition(i).Enabled = False
            Next i
            pbxDice.Image = turn.plimage
            pbxDice.Enabled = False

        Else
            turn.position += valueDice
            'set icon to new position
            tablePosition(turn.position - 1).BackgroundImage = turn.plimage

        End If


    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click

    End Sub

    Private Sub frmGame_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    End Sub

End Class
