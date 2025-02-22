Imports Guna.UI2.WinForms
Public Class ClassDepartmentHeadControls
    Public Shared departmentID As Integer
    Public Shared employeeID As Integer
    Shared compensationtype As String
    Public Shared Sub GetDepartmentID()
        Try
            RunQuery("Select departmentID from tbldepartmenthead where employeeID = '" & employeeID & "'")
            If ds.Tables("querytable").Rows.Count > 0 Then
                departmentID = ds.Tables("querytable").Rows(0)(0)
            Else
                departmentID = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetDepartmentName(lbl As Label)
        Try
            RunQuery("Select departmentName from tbldepartment where departmentID = '" & departmentID & "'")
            lbl.Text = ds.Tables("querytable").Rows(0)(0).ToString
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadEmployees(cb As Guna2ComboBox)
        Try
            RunQuery("Select employeeID,concat(firstname,' ',middlename,' ',lastname) as fullname from tblemployee where status !='Resigned' and departmentID = '" & departmentID & "'")
            cb.DisplayMember = "fullname"
            cb.ValueMember = "employeeID"
            cb.DataSource = ds.Tables("querytable")
            cb.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadAttendance(dg As Guna2DataGridView)
        Try
            RunQuery("Select a.attendanceID, b.employeeNumber,concat(b.firstname,' ',b.middlename,' ',b.lastname) as fullname, a.date, TIME(a.login) as login, TIME(a.logout) as logout, a.report as report from tblattendance a
                      join tblemployee b on b.employeeID = a.employeeID
                      WHERE b.departmentID = '" & departmentID & "'")
            dg.DataSource = ds.Tables("querytable")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub NewSchedule(cbemp As Guna2ComboBox, clb As CheckedListBox, mtbtimein As MaskedTextBox, mtbtimeout As MaskedTextBox, mtbbreakin As MaskedTextBox, mtbbreakout As MaskedTextBox)
        Try
            Dim employeeID As Integer = cbemp.SelectedValue
            Dim timein As String = mtbtimein.Text
            Dim timeout As String = mtbtimeout.Text
            ' Define the correct order of the days
            Dim dayOrder As New List(Of String) From {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            }

            ' Iterate through the days in the correct order
            For Each day As String In dayOrder
                ' Check if the day is selected in CheckedItems or not
                If clb.CheckedItems.Contains(day) Then
                    ' Insert for checked items (With Duty)
                    RunCommand("Insert into tblschedule (employeeID, day, remark) VALUES (@employeeID, @day, @remark)
                                ON DUPLICATE KEY UPDATE remark=@remark")
                    With com
                        .Parameters.AddWithValue("@employeeID", employeeID)
                        .Parameters.AddWithValue("@day", day)
                        .Parameters.AddWithValue("@remark", "With Duty")
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                Else
                    ' Insert for unchecked items (Day Off)
                    RunCommand("Insert into tblschedule (employeeID, day, remark) VALUES (@employeeID, @day, @remark)
                                ON DUPLICATE KEY UPDATE remark=@remark")
                    With com
                        .Parameters.AddWithValue("@employeeID", employeeID)
                        .Parameters.AddWithValue("@day", day)
                        .Parameters.AddWithValue("@remark", "Day Off")
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                End If
            Next

            RunCommand("Insert into tbltimeschedule (employeeID,timein,timeout,breakin,breakout,noofhours) VALUES (@employeeID,@timein,@timeout,@breakin,@breakout,@noofhours)
                        ON DUPLICATE KEY UPDATE timein=@timein, timeout=@timeout, breakin=@breakin, breakout=@breakout, noofhours=@noofhours")

            ' Parse the times from the MaskedTextBoxes (assuming format HH:MM:SS)
            Dim valtimeIn As TimeSpan = TimeSpan.Parse(mtbtimein.Text)
            Dim valtimeOut As TimeSpan = TimeSpan.Parse(mtbtimeout.Text)

            ' Calculate the difference in hours
            Dim hoursDiff As Double

            ' Check if Timeout is earlier than TimeIn (indicating crossing midnight)
            If valtimeOut < valtimeIn Then
                ' Add 24 hours (1 day) to Timeout to handle crossing midnight
                valtimeOut = valtimeOut.Add(TimeSpan.FromHours(24))
            End If

            hoursDiff = (valtimeOut - valtimeIn).TotalHours

            Dim valbreakin As TimeSpan = TimeSpan.Parse(mtbbreakin.Text)
            Dim valbreakout As TimeSpan = TimeSpan.Parse(mtbbreakout.Text)
            Dim breaktotaldiff As Double
            If valbreakout < valbreakin Then
                valbreakout = valbreakout.Add(TimeSpan.FromHours(24))
            End If
            breaktotaldiff = (valbreakout - valbreakin).TotalHours

            Dim workinghours As Double
            workinghours = hoursDiff - breaktotaldiff

            With com
                .Parameters.AddWithValue("@employeeID", employeeID)
                .Parameters.AddWithValue("@timein", mtbtimein.Text.Trim)
                .Parameters.AddWithValue("@timeout", mtbtimeout.Text.Trim)
                .Parameters.AddWithValue("@breakin", mtbbreakin.Text.Trim)
                .Parameters.AddWithValue("@breakout", mtbbreakout.Text.Trim)
                .Parameters.AddWithValue("@noofhours", workinghours)
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With

            GetDailyWageOfMonthlyEmployees(cbemp)
            cbemp.SelectedIndex = -1
            MsgBox("Saved", MsgBoxStyle.OkOnly)
            For i As Integer = 0 To clb.Items.Count - 1
                clb.SetItemChecked(i, False)
            Next
            mtbtimein.Clear()
            mtbtimeout.Clear()
            mtbbreakin.Clear()
            mtbbreakout.Clear()
            Auditing($"{FrmDepartmentHeadControls.LblName.Text} set {FrmDepartmentHeadControls.CbEmployees.Text}'s schedule.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub GetDailyWageOfMonthlyEmployees(cb As Guna2ComboBox)
        Try
            Dim selectedemployeeID As Integer = cb.SelectedValue
            RunQuery("Select salary,type from tblsalary where employeeID = '" & selectedemployeeID & "'")
            Dim salary As Decimal = ds.Tables("querytable").Rows(0)(0)
            Dim type As String = ds.Tables("querytable").Rows(0)(1)

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
            cb.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub LoadSchedule(cbemp As Guna2ComboBox, clb As CheckedListBox, mtbtimein As MaskedTextBox, mtbtimeout As MaskedTextBox, mtbbreakin As MaskedTextBox, mtbbreakout As MaskedTextBox)
        Try
            Dim employeeID As Integer = cbemp.SelectedValue
            If employeeID = 0 Then
                For i As Integer = 0 To clb.Items.Count - 1
                    clb.SetItemChecked(i, False)
                Next
                mtbtimein.Clear()
                mtbtimeout.Clear()
                Exit Sub
            End If

            RunQuery("Select * from tblschedule WHERE employeeID = '" & employeeID & "' order by scheduleID")
            If ds.Tables("querytable").Rows.Count = 0 Then
                For i As Integer = 0 To clb.Items.Count - 1
                    clb.SetItemChecked(i, False)
                Next
                mtbtimein.Clear()
                mtbtimeout.Clear()
                mtbbreakin.Clear()
                mtbbreakout.Clear()
                Exit Sub
            End If

            For Each row As DataRow In ds.Tables("querytable").Rows
                Dim day As String = row("day")
                Dim remark As String = row("remark")
                ' Loop through the CheckedListBox items
                For i As Integer = 0 To clb.Items.Count - 1
                    ' Compare the item in the CheckedListBox with the 'day'
                    If day = clb.Items(i).ToString() Then
                        ' If remark is "With Duty", set the item's checked state to Checked
                        If remark = "With Duty" Then
                            clb.SetItemCheckState(i, CheckState.Checked)
                        Else
                            clb.SetItemCheckState(i, CheckState.Unchecked)
                        End If
                    End If
                Next
            Next

            RunQuery("Select timein,timeout,breakin,breakout from tbltimeschedule WHERE employeeID = '" & employeeID & "'")
            If ds.Tables("querytable").Rows.Count = 0 Then
                Exit Sub
            Else
                mtbtimein.Text = ds.Tables("querytable").Rows(0)(0).ToString
                mtbtimeout.Text = ds.Tables("querytable").Rows(0)(1).ToString
                mtbbreakin.Text = ds.Tables("querytable").Rows(0)(2).ToString
                mtbbreakout.Text = ds.Tables("querytable").Rows(0)(3).ToString
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadFiledLeave(dg As Guna2DataGridView)
        Try
            dg.Rows.Clear()
            RunQuery("select a.filedleaveID 'Filed Leave ID', CONCAT(b.firstname,' ',b.middlename,' ',b.lastname) 'Full Name', a.leavefrom 'From',a.leaveto 'To',c.leaveType 'Type',a.leavereason 'Reason' from tblfiledleave a
                      join tblemployee b on b.employeeID = a.employeeID
                      join tblleave c on c.leaveID = a.leaveID
                      where a.status = 'Pending'")

            If ds.Tables("querytable").Rows.Count > 0 Then
                ' Bind the data to the DataGridView
                dg.DataSource = ds.Tables("querytable")

                ' Add Approve button column
                If dg.Columns("Approve") Is Nothing Then
                    Dim approveButtonColumn As New DataGridViewButtonColumn()
                    approveButtonColumn.Name = "Approve"
                    approveButtonColumn.Text = "Approve"
                    approveButtonColumn.UseColumnTextForButtonValue = True ' Display the text on the button
                    dg.Columns.Add(approveButtonColumn)
                End If


                ' Add Decline button column
                If dg.Columns("Decline") Is Nothing Then
                    Dim declineButtonColumn As New DataGridViewButtonColumn()
                    declineButtonColumn.Name = "Decline"
                    declineButtonColumn.Text = "Decline"
                    declineButtonColumn.UseColumnTextForButtonValue = True ' Display the text on the button
                    dg.Columns.Add(declineButtonColumn)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub RefreshLeave(dg As Guna2DataGridView)
        Try
            RunQuery("select a.filedleaveID 'Filed Leave ID', CONCAT(b.firstname,' ',b.middlename,' ',b.lastname) 'Full Name', a.leavefrom 'From',a.leaveto 'To',c.leaveType 'Type',a.leavereason 'Reason' from tblfiledleave a
                      join tblemployee b on b.employeeID = a.employeeID
                      join tblleave c on c.leaveID = a.leaveID
                      where a.status = 'Pending'")
            Dim count As Integer = ds.Tables("querytable").Rows.Count
            If dg.Rows.Count < count Then
                LoadFiledLeave(dg)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub ApproveLeave(leaveid As Integer)
        Try
            RunQuery("Select employeeID,leavefrom,leaveto from tblfiledleave where filedleaveID = '" & leaveid & "'")
            Dim leaveemployeeID As Integer = ds.Tables("querytable").Rows(0)(0)
            Dim leavefrom As Date = Date.Parse(ds.Tables("querytable").Rows(0)(1))
            Dim leaveto As Date = Date.Parse(ds.Tables("querytable").Rows(0)(2))

            Dim currentdate As Date = leavefrom
            While currentdate <= leaveto

                Dim formattedcurrentdate As String = currentdate.ToString("yyyy-MM-dd")

                RunQuery("Select * from tblattendance where employeeID = '" & leaveemployeeID & "' and date = '" & formattedcurrentdate & "'")
                If ds.Tables("querytable").Rows.Count > 0 Then

                    RunCommand("Update tblfiledleave SET status='Declined' where filedleaveID = '" & leaveid & "'")
                    With com
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With



                    MsgBox("Date: " & currentdate & " already has attendance recorded. Leave request denied")
                    currentdate = currentdate.AddDays(1)
                    Continue While
                End If

                RunCommand("Insert into tblattendance (employeeID,date,report) VALUES (@employeeID,@date,'On Leave')")
                With com
                    .Parameters.AddWithValue("@employeeID", leaveemployeeID)
                    .Parameters.AddWithValue("@date", currentdate)
                    .ExecuteNonQuery()
                    .Parameters.Clear()
                    currentdate = currentdate.AddDays(1)
                End With

                RunCommand("Update tblfiledleave SET status='Approve' where filedleaveID = '" & leaveid & "'")
                With com
                    .ExecuteNonQuery()
                    .Parameters.Clear()
                End With
                MsgBox("Leave Approved", MsgBoxStyle.OkOnly)

            End While

        Catch ex As Exception

        End Try


    End Sub
    Public Shared Sub DeclineLeave(leaveid As Integer)
        Try
            RunCommand("Update tblfiledleave SET status='Decline' where filedleaveID = '" & leaveid & "'")
            With com
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
            MsgBox("Leave declined", MsgBoxStyle.OkOnly)
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub LoadFiledFTIO(dg As Guna2DataGridView)
        Try
            RunQuery("Select a.ftioID 'FTIO ID', concat(b.firstname,' ',b.middlename,' ',b.lastname) 'Full Name',a.date 'Date',a.time 'Time',a.classification 'Classification', a.reason 'Reason',a.status 'Status'
            From tblfiledftio a
                      join tblemployee b on b.employeeID = a.employeeID
                      where a.status='Pending';")
            If ds.Tables("querytable").Rows.Count > 0 Then
                ' Bind the data to the DataGridView
                dg.DataSource = ds.Tables("querytable")

                ' Add Approve button column
                If dg.Columns("Approve") Is Nothing Then
                    Dim approveButtonColumn As New DataGridViewButtonColumn()
                    approveButtonColumn.Name = "Approve"
                    approveButtonColumn.Text = "Approve"
                    approveButtonColumn.UseColumnTextForButtonValue = True ' Display the text on the button
                    dg.Columns.Add(approveButtonColumn)

                End If

                ' Add Decline button column
                If dg.Columns("Decline") Is Nothing Then
                    Dim declineButtonColumn As New DataGridViewButtonColumn()
                    declineButtonColumn.Name = "Decline"
                    declineButtonColumn.Text = "Decline"
                    declineButtonColumn.UseColumnTextForButtonValue = True ' Display the text on the button
                    dg.Columns.Add(declineButtonColumn)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub RefreshFTIO(dg As Guna2DataGridView)
        Try
            RunQuery("Select a.ftioID 'FTIO ID', concat(b.firstname,' ',b.middlename,' ',b.lastname) 'Full Name',a.date 'Date',a.time 'Time',a.classification 'Classification', a.reason 'Reason',a.status 'Status'
            From tblfiledftio a
                      join tblemployee b on b.employeeID = a.employeeID
                      where a.status='Pending';")
            Dim count As Integer = ds.Tables("querytable").Rows.Count
            If dg.Rows.Count < count Then
                LoadFiledFTIO(dg)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub ApproveFTIO(ftioId As Integer)
        Try
            RunCommand("Update tblfiledftio SET status='Approve' where ftioID = '" & ftioId & "'")
            With com
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With

            RunQuery("Select employeeID, date, time, classification from tblfiledftio WHERE ftioID = '" & ftioId & "'")
            If ds.Tables("querytable").Rows.Count > 0 Then
                Dim ftioemployeeID As Integer = ds.Tables("querytable").Rows(0)(0)
                Dim ftiodate As Date = Convert.ToDateTime(ds.Tables("querytable").Rows(0)(1))
                Dim timestring As TimeSpan = TimeSpan.Parse(ds.Tables("querytable").Rows(0)(2).ToString())
                Dim ftiotime As String = timestring.ToString("hh\:mm\:ss")
                Dim ftioFinal As String = ftiodate.ToString("yyyy-MM-dd") & " " & ftiotime
                Dim classification As String = ds.Tables("querytable").Rows(0)(3).ToString()

                If classification = "Login" Then
                    RunCommand("INSERT INTO tblattendance (employeeID, date, login, report) 
                    VALUES (@employeeID, @date, @login, 'Present')
                    ON DUPLICATE KEY UPDATE login = @login")
                    With com
                        .Parameters.AddWithValue("@login", ftioFinal)
                        .Parameters.AddWithValue("@employeeID", ftioemployeeID)
                        .Parameters.AddWithValue("@date", ftiodate)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                ElseIf classification = "Logout" Then
                    RunCommand("INSERT INTO tblattendance (employeeID, date, logout, report) 
                    VALUES (@employeeID, @date, @logout, 'Present')
                    ON DUPLICATE KEY UPDATE logout = @logout")
                    With com
                        .Parameters.AddWithValue("@logout", ftioFinal)
                        .Parameters.AddWithValue("@employeeID", ftioemployeeID)
                        .Parameters.AddWithValue("@date", ftiodate)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                End If
            End If
            MsgBox("FTIO Approved", MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub DeclineFTIO(ftioID As Integer)
        Try
            RunCommand("Update tblfiledftio SET status='Decline' where ftioID = '" & ftioID & "'")
            With com
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
            MsgBox("FTIO declined", MsgBoxStyle.OkOnly)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadOvertime(dg As Guna2DataGridView)
        Try
            RunQuery("SELECT 
                      a.attendanceID AS 'Attendance ID',
                      a.employeeID as 'Employee ID',
                      CONCAT(b.firstname, ' ', b.middlename, ' ', b.lastname) AS 'Full Name',
                      a.date AS 'Attendance Date',
                      a.login AS 'Login',
                      a.logout AS 'Logout',
                      CASE
                      WHEN a.logout > CONCAT(a.date, ' ', c.timeout)
                      THEN FLOOR(TIME_TO_SEC(TIMEDIFF(a.logout, CONCAT(a.date, ' ', c.timeout))) / 3600)  -- Overtime in hours
                      ELSE 0
                      END AS 'Overtime'
                      FROM tblattendance a
                      LEFT JOIN tblemployee b ON b.employeeID = a.employeeID
                      LEFT JOIN tbltimeschedule c ON c.employeeID = a.employeeID
                      WHERE b.departmentID = '" & departmentID & "' AND a.attendanceID NOT IN (SELECT attendanceID FROM tblovertime)
                      GROUP BY a.attendanceID, b.firstname, b.middlename, b.lastname, a.date, a.login, a.logout, c.timeout
                      HAVING FLOOR(TIME_TO_SEC(TIMEDIFF(a.logout, CONCAT(a.date, ' ', c.timeout))) / 3600) > 0
                      ORDER BY a.attendanceID")

            If ds.Tables("querytable").Rows.Count > 0 Then
                ' Bind the data to the DataGridView
                dg.DataSource = ds.Tables("querytable")

                ' Add Approve button column
                If dg.Columns("Approve") Is Nothing Then
                    Dim approveButtonColumn As New DataGridViewButtonColumn()
                    approveButtonColumn.Name = "Approve"
                    approveButtonColumn.Text = "Approve"
                    approveButtonColumn.UseColumnTextForButtonValue = True ' Display the text on the button
                    dg.Columns.Add(approveButtonColumn)
                End If


                ' Add Decline button column
                If dg.Columns("Decline") Is Nothing Then
                    Dim declineButtonColumn As New DataGridViewButtonColumn()
                    declineButtonColumn.Name = "Decline"
                    declineButtonColumn.Text = "Decline"
                    declineButtonColumn.UseColumnTextForButtonValue = True ' Display the text on the button
                    dg.Columns.Add(declineButtonColumn)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub RefreshOvertime(dg As Guna2DataGridView)
        Try
            RunQuery("SELECT 
                      a.attendanceID AS 'Attendance ID',
                      a.employeeID as 'Employee ID',
                      CONCAT(b.firstname, ' ', b.middlename, ' ', b.lastname) AS 'Full Name',
                      a.date AS 'Attendance Date',
                      a.login AS 'Login',
                      a.logout AS 'Logout',
                      CASE
                      WHEN a.logout > CONCAT(a.date, ' ', c.timeout)
                      THEN FLOOR(TIME_TO_SEC(TIMEDIFF(a.logout, CONCAT(a.date, ' ', c.timeout))) / 3600)  -- Overtime in hours
                      ELSE 0
                      END AS 'Overtime'
                      FROM tblattendance a
                      LEFT JOIN tblemployee b ON b.employeeID = a.employeeID
                      LEFT JOIN tbltimeschedule c ON c.employeeID = a.employeeID
                      WHERE b.departmentID = '" & departmentID & "' AND a.attendanceID NOT IN (SELECT attendanceID FROM tblovertime)
                      GROUP BY a.attendanceID, b.firstname, b.middlename, b.lastname, a.date, a.login, a.logout, c.timeout
                      HAVING FLOOR(TIME_TO_SEC(TIMEDIFF(a.logout, CONCAT(a.date, ' ', c.timeout))) / 3600) > 0
                      ORDER BY a.attendanceID")
            Dim count As Integer = ds.Tables("querytable").Rows.Count
            If dg.Rows.Count < count Then
                LoadOvertime(dg)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub ApproveOvertime(employeeID As Integer, attendanceID As Integer, dg As Guna2DataGridView)
        Try
            RunCommand("Insert into tblovertime (employeeID,attendanceID,remarks) VALUES (@employeeID,@attendanceID,@remarks)")
            With com
                .Parameters.AddWithValue("@employeeID", employeeID)
                .Parameters.AddWithValue("@attendanceID", attendanceID)
                .Parameters.AddWithValue("@remarks", "Approved")
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With

            MsgBox("Overtime Approved", MsgBoxStyle.OkOnly)
            LoadOvertime(dg)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub DeclineOvertime(employeeID As Integer, attendanceID As Integer, dg As Guna2DataGridView)
        Try
            RunCommand("Insert into tblovertime (employeeID,attendanceID,remarks) VALUES (@employeeID,@attendanceID,@remarks)")
            With com
                .Parameters.AddWithValue("@employeeID", employeeID)
                .Parameters.AddWithValue("@attendanceID", attendanceID)
                .Parameters.AddWithValue("@remarks", "Declined")
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
            MsgBox("Overtime Declined", MsgBoxStyle.OkOnly)
            LoadOvertime(dg)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub FileFTIO(dtp As Guna2DateTimePicker, cb As Guna2ComboBox, txtreason As Guna2TextBox, mtbtime As MaskedTextBox)
        Try
            RunCommand("Insert into tblfiledftio (employeeID,date,time,classification,reason,status) VALUES (@employeeID,@date,@time,@classification,@reason,@status)")
            With com
                .Parameters.AddWithValue("@employeeID", employeeID)
                .Parameters.AddWithValue("@date", dtp.Value)
                .Parameters.AddWithValue("@time", mtbtime.Text.Trim)
                .Parameters.AddWithValue("@classification", cb.Text)
                .Parameters.AddWithValue("@reason", txtreason.Text.Trim)
                .Parameters.AddWithValue("@status", "Pending")
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
            MsgBox("Saved")
            dtp.Value = Now
            cb.SelectedIndex = -1
            txtreason.Clear()
            Auditing($"{FrmDepartmentHeadControls.LblName.Text} filed FTIO {cb.Text} for date {dtp.Value}")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub FileLeave(dtpfrom As Guna2DateTimePicker, dtpto As Guna2DateTimePicker, cb As Guna2ComboBox, txtreason As Guna2TextBox)
        Try
            Dim count As Integer
            If dtpfrom.Value = dtpto.Value Then
                count = 0 + 1
            ElseIf dtpfrom.Value < dtpto.Value Then
                Dim dtfrom As DateTime = dtpfrom.Value
                Dim dtto As DateTime = dtpto.Value
                Dim differenceInDays As TimeSpan = dtto - dtfrom
                count = differenceInDays.Days + 1
            End If
            RunCommand("Insert into tblfiledleave (employeeID,leavefrom,leaveto,leaveID,leavereason,noofdays,status) VALUES (@employeeID,@leavefrom,@leaveto,@leaveID,@leavereason,@noofdays,@status)")
            With com
                .Parameters.AddWithValue("@employeeID", employeeID)
                .Parameters.AddWithValue("@leavefrom", dtpfrom.Value)
                .Parameters.AddWithValue("@leaveto", dtpto.Value)
                .Parameters.AddWithValue("@leaveID", cb.SelectedValue)
                .Parameters.AddWithValue("@leavereason", txtreason.Text.Trim)
                .Parameters.AddWithValue("@noofdays", count)
                .Parameters.AddWithValue("@status", "Pending")
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
            MsgBox("Leave filed")
            dtpfrom.Value = Now
            dtpto.Value = Now
            cb.SelectedIndex = -1
            txtreason.Clear()
            Auditing($"{FrmDepartmentHeadControls.LblName.Text} filed {cb.Text} from {dtpfrom.Value} to {dtpto.Value}")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub LoadSalaryAndPaySlip(dg As Guna2DataGridView)
        Try
            RunQuery("Select p.payrollID,pp.payrollperiodname,pp.datefrom,pp.dateto,p.netpay from tblpayrollperiod pp
                      LEFT JOIN tblpayroll p on p.payrollperiodID = pp.payrollperiodID
                      WHERE p.employeeID = '" & employeeID & "'")
            dg.DataSource = ds.Tables("querytable")
            If ds.Tables("querytable").Rows.Count > 0 Then
                If dg.Columns("btnViewAndPrint") Is Nothing Then
                    ' Add a new button column
                    Dim btnColumn As New DataGridViewButtonColumn()
                    btnColumn.Name = "btnViewAndPrint"
                    btnColumn.HeaderText = "Action"
                    btnColumn.Text = "View Pay Slip"
                    btnColumn.UseColumnTextForButtonValue = True ' Makes the button display the text
                    dg.Columns.Add(btnColumn)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub RefreshSalaryAndPayslip(dg As Guna2DataGridView)
        Try
            Dim count As Integer = dg.Rows.Count
            RunQuery("Select p.payrollID,pp.payrollperiodname,pp.datefrom,pp.dateto,p.netpay from tblpayrollperiod pp
                      LEFT JOIN tblpayroll p on p.payrollperiodID = pp.payrollperiodID
                      WHERE p.employeeID = '" & employeeID & "'")
            If count < ds.Tables("querytable").Rows.Count Then
                LoadSalaryAndPaySlip(dg)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadMyFiledFTIO(dg As Guna2DataGridView)
        Try
            RunQuery("Select * from tblfiledftio where employeeID = '" & employeeID & "'")
            dg.AutoGenerateColumns = False
            dg.DataSource = ds.Tables("querytable")
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadLeaveType(cb As Guna2ComboBox)
        Try
            RunQuery("Select positionID from tblemployee where employeeID = '" & employeeID & "'")
            Dim posID As Integer = ds.Tables("querytable").Rows(0)(0)
            RunQuery("Select a.leaveID, a.leaveType from tblleave a
                      JOIN tbljobleave b on b.leaveID = a.leaveID
                      WHERE b.positionID = '" & posID & "' and
                      a.status = 'Active'")
            cb.ValueMember = "leaveID"
            cb.DisplayMember = "leaveType"
            cb.DataSource = ds.Tables("querytable")
            cb.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub LeaveCount(dg As Guna2DataGridView)
        Try
            RunQuery("Select positionID from tblemployee where employeeID = '" & employeeID & "'")
            Dim positionID As Integer = ds.Tables("querytable").Rows(0)(0)
            RunQuery("SELECT 
                      a.leaveID, 
                      a.leaveType, 
                      b.days, 
                      b.days - IFNULL(SUM(CASE WHEN c.noofdays IS NOT NULL THEN c.noofdays ELSE 0 END), 0) AS remainingleave 
                      FROM tblleave a
                      LEFT JOIN tbljobleave b ON b.leaveID = a.leaveID
                      LEFT JOIN tblfiledleave c ON c.leaveID = a.leaveID 
                      AND c.employeeID = '" & employeeID & "'  -- Example employeeID
                      AND c.status = 'Approve'
                      WHERE b.positionID = '" & positionID & "'  -- Example positionID AND a.status = 'Active'
                      GROUP BY a.leaveID, a.leaveType, b.days;")
            dg.DataSource = ds.Tables("querytable")
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadMyFiledLeave(dg As Guna2DataGridView)
        Try
            RunQuery("Select a.filedleaveID,b.leaveType,a.leavefrom,a.leaveto,a.status from tblfiledleave a
                      JOIN tblleave b on b.leaveID = a.leaveID
                      WHERE a.employeeID = '" & employeeID & "'")
            dg.DataSource = ds.Tables("querytable")
        Catch ex As Exception

        End Try
    End Sub
End Class
