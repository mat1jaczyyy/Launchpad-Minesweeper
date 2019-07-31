Imports Midi

Public Class MainForm
    Public inputDevice As Midi.InputDevice
    Public outputDevice As Midi.OutputDevice
    Public nBombs As Integer = 1
    Public nRows As Integer = 1
    Public nColumns As Integer = 1
    Dim m(nRows, nColumns) As Char
    Dim b(nRows, nColumns) As Char
    Dim f As Boolean = False
    Dim w As Boolean = False
    Dim _x As Integer = 0
    Dim _y As Integer = 0
    Dim s As Integer = 15

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Sub Form1_Load() Handles MyBase.Load
        Try
            With inputDevice
                .Open()
                .StartReceiving(Nothing)
                AddHandler .NoteOn, AddressOf NoteOn
                AddHandler .ControlChange, AddressOf ControlChange
            End With
        Catch ex As Exception
            MsgBox("Could not initialize Input Device.", MsgBoxStyle.Critical, "Error")
            Application.Exit()
        End Try

        Try
            outputDevice.Open()
        Catch ex As Exception
            MsgBox("Could not initialize Output Device.", MsgBoxStyle.Critical, "Error")
            Application.Exit()
        End Try

        If nRows * nColumns < nBombs Then
            MsgBox("nice nuclear bomb field")
            Application.Exit()
        End If

        ReDim m(nRows, nColumns)
        ReDim b(nRows, nColumns)

        For k As Integer = 0 To nRows
            For i As Integer = 0 To nColumns
                m(k, i) = "."
                b(k, i) = "?"
            Next
        Next

        Dim p(2) As Integer
        For i As Integer = 1 To nBombs
            p(0) = GetRandom(0, nRows)
            p(1) = GetRandom(0, nColumns)
            While m(p(0), p(1)) <> "."
                p(0) = GetRandom(0, nRows)
                p(1) = GetRandom(0, nColumns)
            End While
            m(p(0), p(1)) = "X"
        Next

        drawBoard()
    End Sub

    ' MINESWEEPER LETS GO
    Function getColor(field As Char) As Integer
        Select Case field
            Case "?"
                Return 3
            Case "F"
                Return 1
            Case "0"
                Return 0
            Case "1"
                Return 45
            Case "2"
                Return 21
            Case "3"
                Return 5
            Case "4"
                Return 49
            Case "5"
                Return 9
            Case "6"
                Return 37
            Case "7"
                Return 53
            Case "8"
                Return 13
        End Select
    End Function

    Function getBrush(field As Char) As SolidBrush
        Dim argb As Integer
        Select Case field
            Case "?"
                argb = 16777215
            Case "F"
                argb = 1973790
            Case "0"
                argb = 0
            Case "1"
                argb = 5000447
            Case "2"
                argb = 65280
            Case "3"
                argb = 16711680
            Case "4"
                argb = 5505279
            Case "5"
                argb = 16733184
            Case "6"
                argb = 43519
            Case "7"
                argb = 16711935
            Case "8"
                argb = 16776960
        End Select

        Return New SolidBrush(Color.FromArgb(255, Color.FromArgb(argb)))
    End Function

    Sub drawBoard()
        For k As Integer = _y To 7 + _y
            For i As Integer = _x To 7 + _x
                outputDevice.SendNoteOn(Channel.Channel4, (8 - (k - _y)) * 10 + (i - _x) + 1, getColor(b(k, i)))
            Next i
        Next k

        If Not f Then
            outputDevice.SendControlChange(Channel.Channel4, 80, 1)
        Else
            outputDevice.SendControlChange(Channel.Channel4, 80, 7)
        End If

        Dim e As Graphics = PictureBox1.CreateGraphics()

        For k As Integer = 0 To nRows - 1
            For i As Integer = 0 To nColumns - 1
                e.FillRectangle(getBrush(b(k, i)), i * s, k * s, s, s)
            Next i
        Next k

        e.DrawRectangle(New Pen(Color.FromArgb(255, 255, 0)), _x * s, _y * s, 8 * s, 8 * s)

        e.Flush()
    End Sub

    Function bCount(y, x) As Integer
        Dim c As Integer = 0
        If x > 0 Then
            c += CInt(m(y, x - 1) = "X")
            If y > 0 Then
                c += CInt(m(y - 1, x - 1) = "X")
            End If
            If y < nRows Then
                c += CInt(m(y + 1, x - 1) = "X")
            End If
        End If
        If x < nColumns Then
            c += CInt(m(y, x + 1) = "X")
            If y > 0 Then
                c += CInt(m(y - 1, x + 1) = "X")
            End If
            If y < nRows Then
                c += CInt(m(y + 1, x + 1) = "X")
            End If
        End If
        If y > 0 Then
            c += CInt(m(y - 1, x) = "X")
        End If
        If y < nRows Then
            c += CInt(m(y + 1, x) = "X")
        End If
        Return -c
    End Function

    Function fCount(y, x) As Integer
        Dim c As Integer = 0
        If x > 0 Then
            c += CInt(b(y, x - 1) = "F")
            If y > 0 Then
                c += CInt(b(y - 1, x - 1) = "F")
            End If
            If y < nRows Then
                c += CInt(b(y + 1, x - 1) = "F")
            End If
        End If
        If x < nColumns Then
            c += CInt(b(y, x + 1) = "F")
            If y > 0 Then
                c += CInt(b(y - 1, x + 1) = "F")
            End If
            If y < nRows Then
                c += CInt(b(y + 1, x + 1) = "F")
            End If
        End If
        If y > 0 Then
            c += CInt(b(y - 1, x) = "F")
        End If
        If y < nRows Then
            c += CInt(b(y + 1, x) = "F")
        End If
        Return -c
    End Function

    Sub solve(y, x)
        If Strings.Asc("1") <= Strings.Asc(b(y, x)) And Strings.Asc(b(y, x)) <= Strings.Asc("8") Then
            open(y, x)
            Return
        End If
        If b(y, x) = "0" Then
            Return
        End If
        If m(y, x) = "X" Then
            MsgBox("bomb")
            Return
        End If
        Dim bc As Integer = bCount(y, x)
        b(y, x) = bc.ToString()
        If bc = 0 Then
            If x > 0 Then
                solve(y, x - 1)
                If y > 0 Then
                    solve(y - 1, x - 1)
                End If
                If y < nRows Then
                    solve(y + 1, x - 1)
                End If
            End If
            If x < nColumns Then
                solve(y, x + 1)
                If y > 0 Then
                    solve(y - 1, x + 1)
                End If
                If y < nRows Then
                    solve(y + 1, x + 1)
                End If
            End If
            If y > 0 Then
                solve(y - 1, x)
            End If
            If y < nRows Then
                solve(y + 1, x)
            End If
        End If
        Return
    End Sub

    Sub open(y, x)
        Dim fc As Integer = fCount(y, x)
        If fc.ToString = b(y, x) Then
            If x > 0 Then
                If b(y, x - 1) = "?" Then
                    solve(y, x - 1)
                End If
                If y > 0 Then
                    If b(y - 1, x - 1) = "?" Then
                        solve(y - 1, x - 1)
                    End If
                End If
                If y < nRows Then
                    If b(y + 1, x - 1) = "?" Then
                        solve(y + 1, x - 1)
                    End If
                End If
            End If
            If x < nColumns Then
                If b(y, x + 1) = "?" Then
                    solve(y, x + 1)
                End If
                If y > 0 Then
                    If b(y - 1, x + 1) = "?" Then
                        solve(y - 1, x + 1)
                    End If
                End If
                If y < nRows Then
                    If b(y + 1, x + 1) = "?" Then
                        solve(y + 1, x + 1)
                    End If
                End If
            End If
            If y > 0 Then
                If b(y - 1, x) = "?" Then
                    solve(y - 1, x)
                End If
            End If
            If y < nRows Then
                If b(y + 1, x) = "?" Then
                    solve(y + 1, x)
                End If
            End If
        End If
        Return
    End Sub

    Sub Form1_FormClosing() Handles Me.FormClosing
        If inputDevice.IsReceiving Then
            inputDevice.StopReceiving()
        End If

        If inputDevice.IsOpen Then
            inputDevice.Close()
            RemoveHandler inputDevice.NoteOn, AddressOf NoteOn
            RemoveHandler inputDevice.ControlChange, AddressOf ControlChange
        End If

        If outputDevice.IsOpen Then
            outputDevice.Close()
        End If

        Application.Exit()
    End Sub

    Sub NoteOn(ByVal msg As Midi.NoteOnMessage)
        Dim channel As Byte = CByte(msg.Channel)
        Dim pitch As Byte = CByte(msg.Pitch)
        Dim velocity As Byte = CByte(msg.Velocity)

        If velocity = 127 Then
            Dim y, x As Integer
            y = (pitch \ 10) - 1
            y = 7 - y
            x = (pitch Mod 10) - 1

            y += _y
            x += _x

            If Not f Then
                solve(y, x)
            Else
                If b(y, x) = "?" Then
                    b(y, x) = "F"
                ElseIf b(y, x) = "F" Then
                    b(y, x) = "?"
                End If
            End If

            drawBoard()

            w = True
            For k As Integer = 0 To nRows - 1
                For i As Integer = 0 To nColumns - 1
                    If b(k, i) = "?" Then
                        w = False
                    End If
                Next
            Next

            If w Then
                MsgBox("you won")
                End
            End If

        End If
    End Sub

    Sub ControlChange(ByVal msg As Midi.ControlChangeMessage)
        Dim channel As Byte = CByte(msg.Channel)
        Dim control As Byte = CByte(msg.Control)
        Dim value As Byte = CByte(msg.Value)

        If value = 127 And control = 80 Then
            f = Not f
        End If

        If value = 127 Then
            Select Case control
                Case 91
                    _y = Math.Max(0, _y - 1)
                Case 92
                    _y = Math.Min(nRows - 8, _y + 1)
                Case 93
                    _x = Math.Max(0, _x - 1)
                Case 94
                    _x = Math.Min(nColumns - 8, _x + 1)
            End Select
        End If

        drawBoard()

    End Sub

    Function VelocityToColor(ByVal v As Byte) As Color
        Dim x As String = Convert.ToString(v, 2)
        While x.Length < 7
            x = "0" + x
        End While
        Dim r, g As Integer
        r = Convert.ToInt32(x.Substring(5, 2), 2)
        g = Convert.ToInt32(x.Substring(1, 2), 2)
        Return Color.FromArgb(r * 85, g * 85, 0)
    End Function
End Class