Imports System.ComponentModel

Public Class FrmAttendance
    Private Sub FrmAttendance_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        With Screen.PrimaryScreen
            Me.Size = .WorkingArea.Size
            Me.Location = Point.Empty
        End With
    End Sub

    Private Sub TxtAttendance_TextChanged(sender As Object, e As EventArgs) Handles TxtAttendance.TextChanged
        If TxtAttendance.Text.Length <> 10 Then
            TxtIndicator.Text = ""
        Else
            Login(TxtAttendance)
        End If
    End Sub
    Private Sub LoginTimer_Tick(sender As Object, e As EventArgs) Handles loginTimer.Tick
        TxtIndicator.Text = ""
        TxtAttendance.Clear()
        loginTimer.Stop()
    End Sub

    Private Sub FrmAttendance_Load(sender As Object, e As EventArgs) Handles Me.Load
        OpenServerConnection()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FrmLogin.Show()
        Me.Close()
    End Sub

    Private Sub FrmAttendance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            RunCommand("Update tblusers SET logged='No' where role='Attendance'")
            With com
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class