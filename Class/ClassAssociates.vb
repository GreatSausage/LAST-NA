Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class ClassAssociates
    Public Shared employeeID As Integer
    Public Shared Sub LoadSchedule(dg As Guna2DataGridView)
        Try
            RunQuery("Select a.*,IF(a.remark='Day Off','Day Off',b.timein) as timein,IF(a.remark='Day Off','Day Off',b.timeout) as timeout from tblschedule a
                      LEFT JOIN tbltimeschedule b on b.employeeID = a.employeeID 
                      WHERE a.employeeID = '" & employeeID & "' order by a.scheduleID")
            If ds.Tables("querytable").Rows.Count > 0 Then
                dg.AutoGenerateColumns = False
                dg.DataSource = ds.Tables("querytable")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadAttendance(dg As Guna2DataGridView)
        Try
            RunQuery("Select * from tblattendance where employeeID = '" & employeeID & "' order by attendanceID")
            If ds.Tables("querytable").Rows.Count > 0 Then
                dg.AutoGenerateColumns = False
                dg.DataSource = ds.Tables("querytable")
            End If
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
            Auditing($"{FrmAssociate.LblName.Text} filed {cb.Text} from {dtpfrom.Value} to {dtpto.Value}")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub LoadFiledLeave(dg As Guna2DataGridView)
        Try
            RunQuery("Select a.filedleaveID,b.leaveType,a.leavefrom,a.leaveto,a.status from tblfiledleave a
                      JOIN tblleave b on b.leaveID = a.leaveID
                      WHERE a.employeeID = '" & employeeID & "'")
            dg.DataSource = ds.Tables("querytable")
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
            Auditing($"{FrmAssociate.LblName.Text} filed FTIO {cb.Text} for date {dtp.Value}")
        Catch ex As Exception
            MessageBox.Show("FTIO is already filed.")
        End Try
    End Sub
    Public Shared Sub LoadFiledFTIO(dg As Guna2DataGridView)
        Try
            RunQuery("Select * from tblfiledftio where employeeID = '" & employeeID & "'")
            dg.AutoGenerateColumns = False
            dg.DataSource = ds.Tables("querytable")
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub LoadOvertime(dg As Guna2DataGridView)
        Try
            RunQuery("SELECT 
                      a.date, 
                      a.login, 
                      a.logout, 
                      CASE
                      WHEN a.logout > CONCAT(a.date, ' ', b.timeout)
                      THEN FLOOR(TIME_TO_SEC(TIMEDIFF(a.logout, CONCAT(a.date, ' ', b.timeout))) / 3600)  -- Overtime in hours
                      ELSE 0
                      END AS 'Overtime',
                      c.remarks
                      FROM tblattendance a
                      LEFT JOIN tbltimeschedule b ON b.employeeID = a.employeeID
                      LEFT JOIN tblovertime c on c.attendanceID = a.attendanceID
                      WHERE a.employeeID = 1 and FLOOR(TIME_TO_SEC(TIMEDIFF(a.logout, CONCAT(a.date, ' ', b.timeout))) / 3600) > 0")
            dg.DataSource = ds.Tables("querytable")
        Catch ex As Exception

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
End Class
