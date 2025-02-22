Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms
Imports System.Text.RegularExpressions

Public Class FrmEmployee
    Private Sub FrmEmployee_Load(sender As Object, e As EventArgs) Handles Me.Load
        OpenServerConnection()
        ClassEmployee.LoadDepartment(CbDepartment)
        ClassEmployee.LoadEmployee(DGEmployee)
    End Sub

    Private Sub CbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbDepartment.SelectedIndexChanged
        ClassEmployee.LoadPosition(CbDepartment, CbPosition)
    End Sub

    Private Sub Guna2DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGEmployee.CellDoubleClick
        ClassEmployee.SelectEmployee(DGEmployee, TxtRFID, TxtFirstName, TxtMiddleName, TxtLastName, CbDepartment, CbPosition, cbStatus, TxtSalary)
    End Sub

    Private Sub BtnSaveEmployee_Click(sender As Object, e As EventArgs) Handles BtnSaveEmployee.Click

        Try
            Dim lastName As String = StrConv(TxtLastName.Text, VbStrConv.ProperCase)
            Dim firstName As String = StrConv(TxtFirstName.Text, VbStrConv.ProperCase)
            Dim middleName As String = StrConv(TxtMiddleName.Text, VbStrConv.ProperCase)

            If String.IsNullOrEmpty(firstName) AndAlso
               String.IsNullOrEmpty(lastName) AndAlso
               String.IsNullOrEmpty(middleName) AndAlso
               String.IsNullOrEmpty(TxtRFID.Text) AndAlso
               String.IsNullOrEmpty(TxtSalary.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf CbDepartment.SelectedIndex = -1 OrElse CbPosition.SelectedIndex = -1 OrElse cbStatus.SelectedIndex = -1 OrElse cbStatus.SelectedIndex = -1 Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtFirstName.Text, forNames) OrElse Not Regex.IsMatch(TxtLastName.Text, forNames) OrElse Not Regex.IsMatch(TxtMiddleName.Text, forNames) Then
                MessageBox.Show("Invalid names.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf TxtRFID.Text.Length <> 10 Then
                MessageBox.Show("Invalid RFID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtRFID.Focus()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtSalary.Text, forPrice) Then
                MessageBox.Show("Invalid salary.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf Val(TxtSalary.text) > 999999 Then
                MessageBox.Show("Invalid salary.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtRFID.Text, numberOnly) Then
                MessageBox.Show("Invalid RFID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtRFID.Focus()
                Exit Sub
            End If
            For Each row As DataGridViewRow In DGVoluntary.Rows
                Try
                    Dim amount As Integer = If(String.IsNullOrEmpty(row.Cells("amount").Value.ToString), 0, row.Cells("amount").Value)

                    If Not IsNumeric(amount) Then
                        MessageBox.Show("Voluntary amount contains only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    ElseIf amount < 0 Then
                        MessageBox.Show("Voluntary amount cannot be less than 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    ElseIf amount.ToString.Length > 20 Then
                        MessageBox.Show("Invalid voluntary amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid Voluntary amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            Next


            ClassEmployee.NewEmployee(TxtRFID, TxtLastName, TxtFirstName, TxtMiddleName, CbDepartment, CbPosition, TxtSalary, cbStatus)
            ClassEmployee.LoadEmployee(DGEmployee)
        Catch ex As MySqlException
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TPEmployeeList_Enter(sender As Object, e As EventArgs) Handles TPEmployeeList.Enter
        ClassEmployee.LoadEmployee(DGEmployee)
    End Sub
    Private Sub TPEmployeeProfile_Enter(sender As Object, e As EventArgs) Handles TPEmployeeProfile.Enter
        ClassEmployee.LoadVoluntary(DGVoluntary)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ClassEmployee.RefreshDepartment(CbDepartment)
        ClassEmployee.RefreshVoluntary(DGVoluntary)
    End Sub

    Private Sub DGVoluntary_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVoluntary.DataError
        MessageBox.Show("Invalid amount.")
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        TxtFirstName.Clear()
        TxtLastName.Clear()
        TxtMiddleName.Clear()
        TxtRFID.Clear()
        TxtSalary.Clear()
        cbStatus.SelectedIndex = -1
        CbDepartment.SelectedIndex = -1
        CbPosition.SelectedIndex = -1
        DGVoluntary.ClearSelection()
        ClassEmployee.employeeID = 0
        ClassEmployee.LoadVoluntary(DGVoluntary)
    End Sub

    Public Shared Sub GetDailyWageOfMonthlyEmployees(id As Integer)
        Try
            Dim selectedemployeeID As Integer = id
            RunQuery("Select salary,type from tblsalary where employeeID = '" & selectedemployeeID & "'")
            Dim salary As Decimal = ds.Tables("querytable").Rows(0)(0)
            Dim type As String = ds.Tables("querytable").Rows(0)(1)



            RunQuery("Select * from tblschedule where employeeID='" & id & "'")
            If ds.Tables("querytable").Rows.Count > 0 Then
                If type = "Monthly" Then
                    RunQuery("WITH RECURSIVE date_range AS (
                      SELECT CAST(CONCAT(YEAR(CURDATE()), '-01-01') AS DATE) AS date
                      UNION ALL
                      SELECT DATE_ADD(date, INTERVAL 1 DAY)
                      FROM date_range
                      WHERE date < CAST(CONCAT(YEAR(CURDATE()), '-12-31') AS DATE)
                      )
                      SELECT COUNT(dr.date) 
                      FROM date_range dr
                      JOIN tblschedule sched ON sched.day = DAYNAME(dr.date)
                      LEFT JOIN tblholiday hol ON hol.date = dr.date
                      WHERE sched.employeeID = '" & selectedemployeeID & "'
                      AND sched.remark = 'With Duty'
                      AND hol.date IS NULL;")
                    Dim numberofdays As Integer = ds.Tables("querytable").Rows(0)(0)
                    Dim dailywage As Decimal = (salary * 12) / numberofdays


                    RunCommand("Update tblsalary SET daily=@daily WHERE employeeID = '" & selectedemployeeID & "'")
                    With com
                        .Parameters.AddWithValue("@daily", dailywage)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                ElseIf type = "Daily" Then
                    RunCommand("Update tblsalary SET daily=@daily WHERE employeeID = '" & selectedemployeeID & "'")
                    With com
                        .Parameters.AddWithValue("@daily", salary)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Dim selectedRow As DataGridViewRow = DGEmployee.SelectedRows(0)

            ' Retrieve the userID of the selected row (assuming userID is at index 0)
            Dim userID As Integer = selectedRow.Cells(0).Value

            If MsgBox("Are you sure you want to reset the password of this user?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                RunCommand("Update tblemployee set password=NULL where employeeID = '" & userID & "'")
                With com
                    .ExecuteNonQuery()
                    .Parameters.Clear()
                    MsgBox("Password reset")
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DGEmployee.MouseDown
        Try
            ' Check if the right mouse button is clicked
            If e.Button = MouseButtons.Right Then
                ' Check if any row is selected
                If DGEmployee.SelectedRows.Count > 0 Then
                    ' Show the ContextMenuStrip at the mouse click location
                    ContextMenuStrip1.Show(DGEmployee, e.Location)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class