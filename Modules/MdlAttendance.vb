Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms

Module MdlAttendance

    ReadOnly connection As MySqlConnection = conn
    Public Sub NewAttendance(rfid As String)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            RunQuery("Select employeeID from tblemployee where rfidnumber='" & rfid & "'")
            Dim employeeID As Integer = ds.Tables("querytable").Rows(0)(0)

            Using command As New MySqlCommand("INSERT INTO tblAttendance(employeeID, date, login,report) VALUES (@employeeID, Curdate(), NOW(),'Present')", connection)
                command.Parameters.AddWithValue("@employeeID", employeeID)
                command.ExecuteNonQuery()
            End Using

        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub
    Public Sub Login(txtrfid As Guna2TextBox)
        Try
            OpenServerConnection()
            Dim rfid As String = txtrfid.Text.Trim
            Dim employeeID As Integer
            RunQuery("Select employeeID from tblemployee WHERE rfidnumber = '" & rfid & "' and status != 'Resigned'")
            If ds.Tables("querytable").Rows.Count = 0 Then
                FrmAttendance.loginTimer.Start()
                FrmAttendance.TxtIndicator.Text = "RFID Number does not exist"
                Exit Sub
            Else
                employeeID = ds.Tables("querytable").Rows(0)(0)
            End If

            ' Check if the employee has already logged out today
            RunQuery("Select * from tblattendance where employeeID = '" & employeeID & "' and date=current_date() and login is not null and logout is not NULL")
            If ds.Tables("querytable").Rows.Count > 0 Then
                FrmAttendance.loginTimer.Start()
                FrmAttendance.TxtIndicator.Text = "Login and Logout already recorded"
                Exit Sub
            End If

            ' Check if the employee is still logged in from yesterday (no logout recorded)
            RunQuery("Select * from tblattendance where employeeID = '" & employeeID & "' and date=current_date() - INTERVAL 1 DAY and logout is NULL")

            If ds.Tables("querytable").Rows.Count > 0 Then
                Dim attendanceID As Integer = ds.Tables("querytable").Rows(0)(0)
                ' Update the previous day's logout with the current time
                RunCommand("Update tblattendance SET logout=NOW() WHERE attendanceID='" & attendanceID & "'")
                With com
                    .ExecuteNonQuery()
                    .Parameters.Clear()
                End With
                FrmAttendance.loginTimer.Start()
                FrmAttendance.TxtIndicator.Text = "Logout Success"
                Exit Sub
            End If

            ' Check if the employee has already logged in today but not logged out
            RunQuery("Select * from tblattendance where employeeID = '" & employeeID & "' and date=current_date() and logout is NULL")

            If ds.Tables("querytable").Rows.Count > 0 Then
                Dim attendanceID As Integer = ds.Tables("querytable").Rows(0)(0)
                ' Update today's logout with the current time
                RunCommand("Update tblattendance SET logout=NOW() WHERE attendanceID='" & attendanceID & "'")
                With com
                    .ExecuteNonQuery()
                    .Parameters.Clear()
                End With
                FrmAttendance.loginTimer.Start()
                FrmAttendance.TxtIndicator.Text = "Logout Success"
                Exit Sub
            End If

            ' If none of the above, it means the employee is logging in for the first time today
            RunQuery("Select * from tblattendance where employeeID = '" & employeeID & "' and date=current_date()")

            If ds.Tables("querytable").Rows.Count = 0 Then
                NewAttendance(rfid)
                FrmAttendance.loginTimer.Start()
                FrmAttendance.TxtIndicator.Text = "Login Success"
                Exit Sub
            End If

        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub CheckAdmin()
        Try
            RunQuery("Select * from tblusers where role='Admin'")
            If ds.Tables("querytable").Rows.Count = 0 Then
                FrmSignUpAdmin.Show()
                FrmLogin.Close()
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SaveSignUp(firstname As String, lastname As String, username As String, password As String)
        Try
            OpenServerConnection()
            Using command As New MySqlCommand("INSERT INTO tblusers (firstName, lastName, role, username, password) 
                                           VALUES (@firstname, @lastname, @role, @username, @password)", connection)
                command.Parameters.AddWithValue("@firstname", firstname)
                command.Parameters.AddWithValue("@lastname", lastname)
                command.Parameters.AddWithValue("@role", "Admin")
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)
                command.ExecuteNonQuery()
                FrmLogin.Show()
                FrmSignUpAdmin.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub
End Module
