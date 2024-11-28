Imports System.ComponentModel

Public Class FrmMain
    Private Sub BtnMaintenance_Click(sender As Object, e As EventArgs) Handles BtnMaintenance.Click
        DisplayFormPanel(FrmMainte, displaypanel)
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Enabled = True
    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        With Screen.PrimaryScreen
            Me.Size = .WorkingArea.Size
            Me.Location = Point.Empty
        End With

    End Sub

    Private Sub BtnEmployee_Click(sender As Object, e As EventArgs) Handles BtnEmployee.Click
        DisplayFormPanel(FrmEmployee, displaypanel)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        DisplayFormPanel(FrmDepartmentControls, displaypanel)
    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        DisplayFormPanel(FrmPayrollCalculation, displaypanel)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim currentDate As String = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        Dim currentTime As String = DateTime.Now.ToString("h:mm:ss tt")
        Dim currentDateTime As String = currentTime
        DisplayDate.Text = currentDate
        DisplayTime.Text = currentDateTime
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)
        FrmLogin.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button14_Click(sender As Object, e As EventArgs) Handles Guna2Button14.Click
        DisplayFormPanel(FrmReport, displaypanel)
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        If MsgBox("Are you sure you want to logout?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MsgBox("Logout Success")
            FrmLogin.Show()
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub FrmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ClassLogin.SetToLoggedOutUsers()
    End Sub

    Private Sub BtnAudit_Click(sender As Object, e As EventArgs) Handles BtnAudit.Click
        DisplayFormPanel(FrmAudit, displaypanel)
    End Sub

End Class