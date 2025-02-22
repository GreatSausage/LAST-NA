Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class FrmDepartmentHeadControls
    Private Sub FrmDepartmentHeadControls_Load(sender As Object, e As EventArgs) Handles Me.Load
        OpenServerConnection()
        ClassDepartmentHeadControls.GetDepartmentID()
        ClassDepartmentHeadControls.GetDepartmentName(LblDeptName)
        ClassDepartmentHeadControls.LoadFiledLeave(DGFiledLeave)
        ClassDepartmentHeadControls.LoadFiledFTIO(DGFiledFTIO)
        ClassDepartmentHeadControls.LoadAttendance(DGAttendance)
        ClassDepartmentHeadControls.LoadOvertime(DGOvertime)
        ClassDepartmentHeadControls.LoadMyFiledFTIO(DGFTIOFiled)
        ClassDepartmentHeadControls.LoadLeaveType(CBLeaveType)
        ClassDepartmentHeadControls.LeaveCount(DGLeaveCount)
        ClassDepartmentHeadControls.LoadMyFiledLeave(DGLeaveFiled)
        Timer1.Start()
        Timer2.Start()
    End Sub
    Private Sub TPSchedule_Enter(sender As Object, e As EventArgs) Handles TPSchedule.Enter

        ClassDepartmentHeadControls.LoadEmployees(CbEmployees)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        If CLBSchedule.CheckedItems.Count = 0 Then
            MsgBox("Please set schedule atleast 1 day")
            Exit Sub
        End If


        If CbEmployees.SelectedIndex = -1 Then
            MsgEmptyField()
            Exit Sub
        ElseIf Not Regex.IsMatch(MtbTimeIn.Text, timePattern) Then
            MessageBox.Show("Invalid time format.")
            Exit Sub
        ElseIf Not Regex.IsMatch(MtbTimeOut.Text, timePattern) Then
            MessageBox.Show("Invalid time format.")
            Exit Sub
        ElseIf Not Regex.IsMatch(mtbBreakin.Text, timePattern) Then
            MessageBox.Show("Invalid time format.")
            Exit Sub
        ElseIf Not Regex.IsMatch(mtbBreakOut.Text, timePattern) Then
            MessageBox.Show("Invalid time format.")
            Exit Sub
        End If
        Try
            ' Parse times into DateTime objects
            Dim timeIn As DateTime
            Dim timeOut As DateTime
            Dim breakIn As DateTime
            Dim breakOut As DateTime

            If DateTime.TryParse(MtbTimeIn.Text, timeIn) AndAlso
        DateTime.TryParse(MtbTimeOut.Text, timeOut) AndAlso
        DateTime.TryParse(mtbBreakin.Text, breakIn) AndAlso
        DateTime.TryParse(mtbBreakOut.Text, breakOut) Then

                ' Validate that break times are within the range of time in and time out
                If breakIn < timeIn OrElse breakIn > timeOut Then
                    MessageBox.Show("Break In time must be within Time In and Time Out range.")
                    Exit Sub
                End If

                If breakOut < timeIn OrElse breakOut > timeOut Then
                    MessageBox.Show("Break Out time must be within Time In and Time Out range.")
                    Exit Sub
                End If

                ' Ensure Break In is before Break Out
                If breakIn >= breakOut Then
                    MessageBox.Show("Break In time must be earlier than Break Out time.")
                    Exit Sub
                End If
            Else
                MessageBox.Show("One or more time values could not be parsed.")
                Exit Sub
            End If

            ClassDepartmentHeadControls.NewSchedule(CbEmployees, CLBSchedule, MtbTimeIn, MtbTimeOut, mtbBreakin, mtbBreakOut)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmDepartmentHeadControls_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        With Screen.PrimaryScreen
            Me.Size = .WorkingArea.Size
            Me.Location = Point.Empty
        End With
    End Sub
    Private Sub CbEmployees_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbEmployees.SelectedIndexChanged
        Try
            ClassDepartmentHeadControls.LoadSchedule(CbEmployees, CLBSchedule, MtbTimeIn, MtbTimeOut, mtbBreakin, mtbBreakOut)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGFiledLeave_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGFiledLeave.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = DGFiledLeave.Columns("Approve").Index Then
                    ' Get the Filed Leave ID of the selected row
                    Dim filedLeaveID As Integer = Convert.ToInt32(DGFiledLeave.Rows(e.RowIndex).Cells("Filed Leave ID").Value)

                    If MsgBox("Are you sure you want to approve the leave filed?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ClassDepartmentHeadControls.ApproveLeave(filedLeaveID)
                        Dim name As String = DGFiledLeave.Rows(e.RowIndex).Cells("Full Name").Value.ToString
                        Auditing($"{LblName.Text} approved {name}'s leave.")
                        DGFiledLeave.Rows.RemoveAt(e.RowIndex)
                    End If

                ElseIf e.ColumnIndex = DGFiledLeave.Columns("Decline").Index Then
                    ' Get the Filed Leave ID of the selected row
                    Dim filedLeaveID As Integer = Convert.ToInt32(DGFiledLeave.Rows(e.RowIndex).Cells("Filed Leave ID").Value)
                    If MsgBox("Are you sure you want to decline the leave filed?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ClassDepartmentHeadControls.DeclineLeave(filedLeaveID)
                        Dim name As String = DGFiledLeave.Rows(e.RowIndex).Cells("Full Name").Value.ToString
                        Auditing($"{LblName.Text} approved {name}'s leave.")
                        DGFiledLeave.Rows.RemoveAt(e.RowIndex)
                    End If

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGFiledFTIO_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGFiledFTIO.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = DGFiledFTIO.Columns("Approve").Index Then
                    ' Get the Filed FTIO ID of the selected row
                    Dim FTIOID As Integer = Convert.ToInt32(DGFiledFTIO.Rows(e.RowIndex).Cells("FTIO ID").Value)

                    If MsgBox("Are you sure you want to approve the FTIO filed?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ClassDepartmentHeadControls.ApproveFTIO(FTIOID)
                        Dim name As String = DGFiledFTIO.Rows(e.RowIndex).Cells("Full Name").Value.ToString
                        Auditing($"{LblName.Text} approved {name}'s FTIO.")
                        DGFiledFTIO.Rows.RemoveAt(e.RowIndex)
                    End If

                ElseIf e.ColumnIndex = DGFiledFTIO.Columns("Decline").Index Then
                    ' Get the Filed FTIO ID of the selected row
                    Dim FTIOID As Integer = Convert.ToInt32(DGFiledFTIO.Rows(e.RowIndex).Cells("FTIO ID").Value)
                    If MsgBox("Are you sure you want to decline the FTIO filed?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ClassDepartmentHeadControls.DeclineFTIO(FTIOID)
                        Dim name As String = DGFiledFTIO.Rows(e.RowIndex).Cells("Full Name").Value.ToString
                        Auditing($"{LblName.Text} declined {name}'s FTIO.")
                        DGFiledFTIO.Rows.RemoveAt(e.RowIndex)
                    End If

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGOvertime_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGOvertime.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = DGOvertime.Columns("Approve").Index Then
                    ' Get the Filed FTIO ID of the selected row
                    Dim employeeID As Integer = Convert.ToInt32(DGOvertime.Rows(e.RowIndex).Cells("EmployeeID").Value)
                    Dim attendanceID As Integer = Convert.ToInt32(DGOvertime.Rows(e.RowIndex).Cells("AttendanceID").Value)


                    If MsgBox("Are you sure you want to approve the Overtime filed?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ClassDepartmentHeadControls.ApproveOvertime(employeeID, attendanceID, DGOvertime)
                        ClassDepartmentHeadControls.LoadOvertime(DGOvertime)
                        Dim name As String = DGOvertime.Rows(e.RowIndex).Cells("FullName").Value.ToString
                        Auditing($"{LblName.Text} approved {name}'s overtime.")
                        DGOvertime.Rows.RemoveAt(e.RowIndex)
                    End If

                ElseIf e.ColumnIndex = DGOvertime.Columns("Decline").Index Then
                    ' Get the Filed FTIO ID of the selected row
                    Dim employeeID As Integer = Convert.ToInt32(DGOvertime.Rows(e.RowIndex).Cells("EmployeeID").Value)
                    Dim attendanceID As Integer = Convert.ToInt32(DGOvertime.Rows(e.RowIndex).Cells("AttendanceID").Value)
                    If MsgBox("Are you sure you want to decline the Overtime filed?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ClassDepartmentHeadControls.DeclineOvertime(employeeID, attendanceID, DGOvertime)
                        ClassDepartmentHeadControls.LoadOvertime(DGOvertime)
                        Dim name As String = DGOvertime.Rows(e.RowIndex).Cells("FullName").Value.ToString
                        Auditing($"{LblName.Text} declined {name}'s overtime.")
                        DGOvertime.Rows.RemoveAt(e.RowIndex)
                    End If

                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ClassDepartmentHeadControls.LoadAttendance(DGAttendance)
        ClassDepartmentHeadControls.RefreshOvertime(DGOvertime)
        ClassDepartmentHeadControls.RefreshFTIO(DGFiledFTIO)
        ClassDepartmentHeadControls.RefreshLeave(DGFiledLeave)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim currentDate As String = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        Dim currentTime As String = DateTime.Now.ToString("h:mm:ss tt")
        Dim currentDateTime As String = currentTime
        DisplayDate.Text = currentDate
        DisplayTime.Text = currentDateTime
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        If MsgBox("Are you sure you want to logout?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MsgBox("Logout Success")
            FrmLogin.Show()
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub FrmDepartmentHeadControls_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ClassLogin.SetToLoggedOutEmployees(ClassDepartmentHeadControls.departmentID)
    End Sub

    Private Sub BtnFTIOSave_Click(sender As Object, e As EventArgs) Handles BtnFTIOSave.Click
        Dim today As Date = Date.Now()

        If CBFTIOType.SelectedIndex = -1 Then
            MsgEmptyField()
            Exit Sub
        ElseIf Not Regex.IsMatch(mtbTime.Text, timePattern) Then
            MessageBox.Show("Invalid time format.")
            Exit Sub
        ElseIf String.IsNullOrEmpty(TxtFTIOReason.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf Not Regex.IsMatch(TxtFTIOReason.Text, singleSpace) Then
            MessageBox.Show("Invalid FTIO reason.")
            Exit Sub
        ElseIf DTPFTIODate.Value.Day >= today.Day Then
            MessageBox.Show("Date must start yesterday.")
            Exit Sub
        End If
        ClassDepartmentHeadControls.FileFTIO(DTPFTIODate, CBFTIOType, TxtFTIOReason, mtbTime)
        ClassDepartmentHeadControls.LoadMyFiledFTIO(DGFTIOFiled)
    End Sub

    Private Sub BtnLeaveSave_Click(sender As Object, e As EventArgs) Handles BtnLeaveSave.Click
        If CBLeaveType.SelectedIndex = -1 Then
            MsgEmptyField()
            Exit Sub
        ElseIf String.IsNullOrEmpty(TxtLeaveReason.text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf Not Regex.IsMatch(TxtLeaveReason.Text, singleSpace) Then
            MessageBox.Show("Invalid Leave Reason.")
            Exit Sub
        End If

        If CBLeaveType.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a type of leave.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedTypeOfLeave As String = CBLeaveType.Text.ToString()
        Dim remaining As Integer

        For Each row As DataGridViewRow In DGLeaveCount.Rows
            If row.Cells("manageTypeofLeave").Value IsNot Nothing AndAlso row.Cells("manageTypeofLeave").Value.ToString() = selectedTypeOfLeave Then
                If Integer.TryParse(row.Cells("manageRemainingLeave").Value.ToString(), remaining) Then
                Else
                    MessageBox.Show("Invalid remaining leave value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim startDate As Date = DTPLeaveFrom.Value.Date
                Dim endDate As Date = DTPLeaveTo.Value.Date

                If endDate < startDate Then
                    MessageBox.Show("End date cannot be earlier than start date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim difference As Integer = (endDate - startDate).Days + 1
                If difference > remaining Then
                    MessageBox.Show("Insufficient leave credits.")
                    Exit Sub
                End If

                Exit For
            End If
        Next

        If remaining = -1 Then
            MessageBox.Show("Leave type not found in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ClassDepartmentHeadControls.FileLeave(DTPLeaveFrom, DTPLeaveTo, CBLeaveType, TxtLeaveReason)
        ClassDepartmentHeadControls.LeaveCount(DGLeaveCount)
        ClassDepartmentHeadControls.LoadFiledLeave(DGLeaveFiled)
        ClassDepartmentHeadControls.LoadMyFiledLeave(DGLeaveFiled)
    End Sub

End Class