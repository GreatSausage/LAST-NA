Public Class FrmPayrollPeriod
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Close()
    End Sub

    Private Sub FrmPayrollPeriod_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            OpenServerConnection()
            FrmMain.Enabled = False
            ClassPayrollCalculation.LoadPayrollPeriodCB(CbPayrollPeriod)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmPayrollPeriod_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmMain.Enabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ClassPayrollCalculation.RefreshPayrollPeriodCB(CbPayrollPeriod)
    End Sub

    Private Sub CbPayrollPeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbPayrollPeriod.SelectedIndexChanged
        ClassPayrollCalculation.SelectPayrollPeriod(CbPayrollPeriod, TxtFrom, TxtTo, TxtPayout)
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If CbPayrollPeriod.SelectedIndex = -1 Then
            MsgBox("Please select a payroll period", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ClassPayrollCalculation.UsePayrollPeriod(CbPayrollPeriod, FrmPayrollCalculation.TxtPayrollPeriod, TxtFrom, TxtTo, TxtPayout)
        ClassPayrollCalculation.LoadEmployees(FrmPayrollCalculation.CbEmployees)
        Me.Close()
    End Sub
End Class