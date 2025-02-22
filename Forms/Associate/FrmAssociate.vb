Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Public Class FrmAssociate
    Private Sub FrmAssociate_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        With Screen.PrimaryScreen
            Me.Size = .WorkingArea.Size
            Me.Location = Point.Empty
        End With
    End Sub
    Private Sub FrmAssociate_Load(sender As Object, e As EventArgs) Handles Me.Load
        OpenServerConnection()
        ClassAssociates.LoadSchedule(DGSchedule)
        ClassAssociates.LoadAttendance(DGAttendance)
        ClassAssociates.LoadFiledLeave(DGLeaveFiled)
        ClassAssociates.LoadFiledFTIO(DGFTIOFiled)
        ClassAssociates.LoadOvertime(DGOvertime)
        ClassAssociates.LoadLeaveType(CBLeaveType)
        ClassAssociates.LeaveCount(DGLeaveCount)
        Timer1.Start()
    End Sub
    Private Sub TPLeave_Enter(sender As Object, e As EventArgs) Handles TPLeave.Enter
        ClassAssociates.LoadLeaveType(CBLeaveType)
        ClassAssociates.LeaveCount(DGLeaveCount)
        ClassAssociates.LoadFiledLeave(DGLeaveFiled)
    End Sub
    Private Sub TPSalaryAndPaySlip_Enter(sender As Object, e As EventArgs) Handles TPPaySlip.Enter
        ClassAssociates.LoadSalaryAndPaySlip(DGSalaryAndPaySlip)
    End Sub

    dim remainingLeavee As Integer = 0
    Dim difference As Integer = 0

    Private Sub CBLeaveType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBLeaveType.SelectedIndexChanged
        Try
            If DGLeaveCount.SelectedRows.Count > 0 Then
                For Each row As DataGridViewRow In DGLeaveCount.Rows
                    If CBLeaveType.Text = row.Cells("manageTypeOfLeave").Value Then
                        MsgBox(row.Cells("manageTypeOfLeave").Value)
                        remainingLeavee = row.Cells("remainingLeave").Value
                        MsgBox(remainingLeavee)
                        Dim dtDiff As TimeSpan = DTPLeaveTo.Value.AddDays(1) - DTPLeaveFrom.Value
                        difference = dtDiff.Days
                        MsgBox(dtDiff.Days)
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnLeaveSave.Click
        If String.IsNullOrEmpty(CBLeaveType.SelectedIndex = -1) Then
            MsgEmptyField()
            Exit Sub
        ElseIf String.IsNullOrEmpty(TxtLeaveReason.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf Not Regex.IsMatch(TxtLeaveReason.Text, singleSpace) Then
            MessageBox.Show("Invalid Reason for leave.")
            Exit Sub
        ElseIf difference > remainingLeavee Then
            MessageBox.Show("Insufficient leave credits.")
            Exit Sub
        End If

        ClassAssociates.FileLeave(DTPLeaveFrom, DTPLeaveTo, CBLeaveType, TxtLeaveReason)
        ClassAssociates.LeaveCount(DGLeaveCount)
        ClassAssociates.LoadFiledLeave(DGLeaveFiled)
    End Sub
    Private Sub TPFTIO_Enter(sender As Object, e As EventArgs) Handles TPFTIO.Enter
        ClassAssociates.LoadFiledFTIO(DGFTIOFiled)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ClassDepartmentHeadControls.RefreshSalaryAndPayslip(DGSalaryAndPaySlip)
        Dim currentDate As String = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        Dim currentTime As String = DateTime.Now.ToString("h:mm:ss tt")
        Dim currentDateTime As String = currentTime
        DisplayDate.Text = currentDate
        DisplayTime.Text = currentDateTime
    End Sub

    Private Sub BtnFTIOSave_Click_1(sender As Object, e As EventArgs) Handles BtnFTIOSave.Click
        If CBFTIOType.SelectedIndex = -1 Then
            MsgEmptyField()
            Exit Sub
        ElseIf String.IsNullOrEmpty(mtbTime.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf String.IsNullOrEmpty(TxtFTIOReason.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf Not Regex.IsMatch(TxtFTIOReason.text, singleSpace) Then
            MessageBox.Show("FTIO Reason contains single space only.")
            Exit Sub
        ElseIf Not Regex.IsMatch(mtbTime.Text, timePattern) Then
            MessageBox.Show("Invalid time format.")
            Exit Sub
        ElseIf String.IsNullOrEmpty(TxtFTIOReason.Text) Then
            MsgEmptyField()
            Exit Sub
        End If
        ClassAssociates.FileFTIO(DTPFTIODate, CBFTIOType, TxtFTIOReason, mtbTime)
        ClassAssociates.LoadFiledFTIO(DGFTIOFiled)
    End Sub

    Private Sub DGSalaryAndPaySlip_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGSalaryAndPaySlip.CellContentClick
        Try
            ' Check if the clicked cell is in the button column
            If e.ColumnIndex = DGSalaryAndPaySlip.Columns("btnViewAndPrint").Index AndAlso e.RowIndex >= 0 Then
                Dim payrollID As String = DGSalaryAndPaySlip.Rows(e.RowIndex).Cells("colPayrollPeriodID").Value.ToString()
                dt = New DataTable("DT_Department")
                dt.Clear()

                adp = New MySqlDataAdapter("Select CONCAT(pp.datefrom,' to ',pp.dateto) as payrollperiod, e.employeeNumber, CONCAT(e.firstname,' ',e.middlename,' ',e.lastname) as name,
                                        p.overtime,p.allowance,p.incentives,p.nightdifferential,p.late,p.undertime,p.voluntary,p.sss,p.philhealth,p.pagibig,p.tax,p.totalincrease,
                                        p.totaldeduc,p.grosspay, (p.totalincrease + p.grosspay) as totalearning, p.netpay from tblpayrollperiod pp
                                        LEFT JOIN tblpayroll p on p.payrollperiodID = pp.payrollperiodID
                                        LEFT JOIn tblemployee e on e.employeeID = p.employeeID
                                        WHERE p.payrollID = '" & payrollID & "'", conn)
                adp.Fill(dt)


                Dim crystal As New CRPaySlip
                crystal.SetDataSource(dt)
                FrmPrinting.CRVPrinting.ReportSource = crystal
                FrmPrinting.Show()
                FrmMain.Enabled = False
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        If MsgBox("Are you sure you want to logout?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MsgBox("Logout Success")
            FrmLogin.Show()
            Me.Close()
            Exit Sub
        End If

    End Sub


    Private Sub FrmAssociate_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ClassLogin.SetToLoggedOutEmployees(ClassAssociates.employeeID)
    End Sub


End Class