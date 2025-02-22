Public Class FrmPayrollCalculation
    Private Sub TPPayrollCalculation_Enter(sender As Object, e As EventArgs) Handles TPPayrollCalculation.Enter
        FrmPayrollPeriod.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        FrmPayrollPeriod.Show()
    End Sub

    Private Sub CbEmployees_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbEmployees.SelectedIndexChanged
        If CbEmployees.SelectedIndex = -1 Then
            Exit Sub
        End If
        ClassPayrollCalculation.LoadAttendance(DGAttendance, CbEmployees)
        ClassPayrollCalculation.EmployeeCompensationType(CbEmployees)
        ClassPayrollCalculation.EmployeeStatus(CbEmployees)
        ClassPayrollCalculation.LoadIncentive(DGIncentive)
        ClassPayrollCalculation.LoadAllowance(DGAllowance, CbEmployees)
        ClassPayrollCalculation.LoadVoluntary(DGVoluntary, CbEmployees)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click

        'Select Employee
        If CbEmployees.SelectedIndex = -1 Then
            MsgBox("Please select an employee first", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'If employee has schedule
        If ClassPayrollCalculation.hasschedule = False Then
            MsgBox("Employee doesn't have assigned schedule yet")
            Exit Sub
        End If

        'Check if all logins have logouts and vice versa
        For Each row As DataGridViewRow In DGAttendance.Rows
            Dim otcount As Integer = If(String.IsNullOrEmpty(row.Cells("colOvertime").Value.ToString), 0, row.Cells("colOvertime").Value)
            Dim otremarks As String = If(String.IsNullOrEmpty(row.Cells("colOtRemarks").Value.ToString), "No record", row.Cells("colOtRemarks").Value)
            Dim login As String = If(String.IsNullOrEmpty(row.Cells("colTimeIn").Value.ToString), "No record", row.Cells("colTimeIn").Value)
            Dim logout As String = If(String.IsNullOrEmpty(row.Cells("colTimeOut").Value.ToString), "No record", row.Cells("colTimeOut").Value)
            If (login = "No record" And logout <> "No record") Or (login <> "No record" And logout = "No record") Then
                MsgBox("A record doesn't have a login or logout. Please inform the employee or the Department Head")
                Exit Sub
            End If

            If otcount = 0 Then
                Continue For
            End If

            If otremarks = "No record" Then
                MsgBox("An overtime is still pending. Please inform the Department Head")
                Exit Sub
            End If
        Next

        ClassPayrollCalculation.GetGrossPay(CbEmployees, DGAttendance, TxtGrossPay)
        ClassPayrollCalculation.GetOvertime(CbEmployees, DGAttendance, TxtOvertime)
        ClassPayrollCalculation.GetAllowance(DGAllowance, TxtAllowance)
        ClassPayrollCalculation.GetIncentives(DGIncentive, TxtIncentives)
        ClassPayrollCalculation.GetLate(DGAttendance, TxtLate, CbEmployees)
        ClassPayrollCalculation.GetUndertime(DGAttendance, TxtUndertime, CbEmployees)
        ClassPayrollCalculation.GetNightDifferential(DGAttendance, TxtNightDifferential, CbEmployees)
        ClassPayrollCalculation.GetVoluntaryContrib(DGVoluntary, TxtVoluntaryContributions)
        ClassPayrollCalculation.GetSSS(TxtGrossPay, TxtSSS)
        ClassPayrollCalculation.GetPhilhealth(TxtGrossPay, TxtPhilHealth)
        ClassPayrollCalculation.GetPagIbig(TxtPagIbig)
        ClassPayrollCalculation.GetTax(TxtGrossPay, TxtTax, TxtSSS, TxtPhilHealth, TxtPagIbig)
        ClassPayrollCalculation.TotalIncrease(TxtOvertime, TxtAllowance, TxtIncentives, TxtNightDifferential, TxtTotalIncrease)
        ClassPayrollCalculation.TotalMandatoryContri(TxtSSS, TxtPhilHealth, TxtPagIbig, TxtTax, TxtMandatory)
        ClassPayrollCalculation.TotalDeductions(TxtLate, TxtUndertime, TxtVoluntaryContributions, TxtMandatory, TxtTotalDeduc)
        ClassPayrollCalculation.GetNetPay(TxtGrossPay, TxtTotalIncrease, TxtTotalDeduc, TxtNetPay)
    End Sub

    Private Sub FrmPayrollCalculation_Load(sender As Object, e As EventArgs) Handles Me.Load
        OpenServerConnection()
        ClassPayrollCalculation.GetRates()
        ClassPayrollCalculation.LoadPayrollPeriod(DGPayrollPeriod)
        RBYes.Checked = True
    End Sub
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            If MsgBox("Verify salary calculation", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ClassPayrollCalculation.SaveSalary(CbEmployees, TxtOvertime, TxtAllowance, TxtIncentives, TxtNightDifferential, TxtLate, TxtUndertime, TxtVoluntaryContributions, TxtSSS, TxtPhilHealth, TxtPagIbig, TxtTax, TxtMandatory, TxtTotalIncrease, TxtTotalDeduc, TxtGrossPay, TxtNetPay)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Try
            'max 17 days and min 14 days
            If String.IsNullOrEmpty(TxtPayrollPeriodName.Text) Then
                MsgEmptyField()
                Exit Sub
            End If

            Dim startDate As Date = DTPFrom.Value.Date
            Dim endDate As Date = DTPTo.Value.Date

            If endDate < startDate Then
                MessageBox.Show("The end date cannot be earlier than start date.")
                Exit Sub
            End If

            Dim difference As Integer = (endDate - startDate).Days + 1

            If difference < 14 OrElse difference > 17 Then
                MessageBox.Show("Invalid payroll period.")
                Exit Sub
            End If
            '
            ClassPayrollCalculation.NewPayrollPeriod(TxtPayrollPeriodName, DTPFrom, DTPTo, RBYes)
            ClassPayrollCalculation.LoadPayrollPeriod(DGPayrollPeriod)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgPayrollPeriod_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGPayrollPeriod.CellContentClick
        Try
            ' Check if the clicked cell is in the button column
            If e.ColumnIndex = DGPayrollPeriod.Columns("btnRelease").Index AndAlso e.RowIndex >= 0 Then
                Dim payrollperiodID As String = DGPayrollPeriod.Rows(e.RowIndex).Cells("colPayrollPeriodID").Value.ToString()
                Dim isreleased As String = DGPayrollPeriod.Rows(e.RowIndex).Cells("colReleased").Value.ToString

                If isreleased = "Released" Then
                    MsgBox("Pay Slip already released")
                    Exit Sub
                End If

                If MsgBox("Are you sure you want to release the Pay Slip?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    RunCommand("Update tblpayrollperiod SET released='Released' WHERE payrollperiodID = '" & payrollperiodID & "'")
                    With com
                        .ExecuteNonQuery()
                    End With
                    MsgBox("Pay Slip for the selected period is now released")
                    ClassPayrollCalculation.LoadPayrollPeriod(DGPayrollPeriod)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class