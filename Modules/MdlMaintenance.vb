Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms

'hehez
Module MdlMaintenance

    ReadOnly connection As MySqlConnection = conn

#Region "User Maintenance"

    Public userID As Integer = 0
    Public Function DisplayUsers() As DataTable
        Dim dt As New DataTable
        Dim command As MySqlCommand = Nothing
        Dim adapter As MySqlDataAdapter = Nothing
        Try
            command = New MySqlCommand("SELECT userID, CONCAT(firstName, ' ', lastName) AS fullName, firstname, lastname, username, password, role FROM tblUsers WHERE status = 'Active' AND role = 'Payroll Staff'", connection)
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Error displaying users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If command IsNot Nothing Then command.Dispose()
            If adapter IsNot Nothing Then adapter.Dispose()
        End Try
        Return dt
    End Function



    Public Sub NewUser(firstname As String, lastname As String, role As String, username As String)
        Try
            Dim first As String = StrConv(firstname, VbStrConv.ProperCase)
            Dim last As String = StrConv(lastname, VbStrConv.ProperCase)

            If userID = 0 Then
                Dim selectCommand As New MySqlCommand("SELECT userID FROM tblUsers WHERE username = @username AND status = 'Inactive'", connection)
                selectCommand.Parameters.AddWithValue("@username", username)
                Dim reader As MySqlDataReader = selectCommand.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    Dim existingUserID As Integer = reader("userID")
                    reader.Close()

                    Dim command As New MySqlCommand("UPDATE tblUsers SET status = 'Active' WHERE userID = @userID", connection)
                    command.Parameters.AddWithValue("@userID", userID)
                    command.ExecuteNonQuery()
                    MessageBox.Show("User has been reactivated successfully.")
                    Auditing($"{FrmMain.LblName.Text} reactivated an account: {firstname} {lastname}")
                    userID = 0
                Else
                    reader.Close()

                    Dim command As New MySqlCommand("INSERT INTO tblUsers (firstName, lastName, role, username, status) 
                                                     VALUES (@firstname, @lastname, 'Payroll Staff', @username, 'Active')", connection)
                    With command.Parameters
                        .AddWithValue("@firstname", first)
                        .AddWithValue("@lastname", last)
                        .AddWithValue("@username", username)
                    End With
                    command.ExecuteNonQuery()
                    MessageBox.Show("User has been added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Auditing($"{FrmMain.LblName.Text} added a Payroll Staff account: {firstname} {lastname}")
                    userID = 0
                End If
            Else
                Dim command As New MySqlCommand("UPDATE tblUsers SET firstname = @firstname, lastname = @lastname, username = @username WHERE userID = @userID", connection)
                With command.Parameters
                    .AddWithValue("@firstname", first)
                    .AddWithValue("@lastname", last)
                    .AddWithValue("@username", username)
                    .AddWithValue("@userID", userID)
                End With
                command.ExecuteNonQuery()
                MessageBox.Show("User updated successfully.")
                Auditing($"{FrmMain.LblName.Text} updated a Payroll Staff Account: {firstname} {lastname}")
                userID = 0
            End If
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public firstname As String = ""
    Public lastname As String = ""
    Public username As String = ""

    Public Sub SelectUser(dg As DataGridView)
        Try
            If dg.SelectedRows.Count > 0 Then
                userID = dg.SelectedRows(0).Cells(0).Value
                FrmMainte.TxtFirstname.Text = dg.SelectedRows(0).Cells(2).Value
                firstname = dg.SelectedRows(0).Cells(2).Value
                FrmMainte.TxtLastname.Text = dg.SelectedRows(0).Cells(3).Value
                lastname = dg.SelectedRows(0).Cells(3).Value
                FrmMainte.TxtUsername.Text = dg.SelectedRows(0).Cells(4).Value
                username = dg.SelectedRows(0).Cells(4).Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DeleteUser(userIDD As Integer)
        Try
            Dim command As New MySqlCommand("UPDATE tblUsers SET status = 'Inactive' WHERE userID = @userID", connection)
            command.Parameters.AddWithValue("@userID", userIDD)
            command.ExecuteNonQuery()
            MessageBox.Show("Payroll Staff has been deleted.")
            userID = 0
            Auditing($"{FrmMain.LblName.Text} deleted a Payroll Staff account: {firstname} {lastname}")

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Department"
    Public departmentID As Integer = 0
    Public Function DisplayDepartment() As DataTable
        Try
            Using command As New MySqlCommand("SELECT * FROM tblDepartment WHERE status = 'Active'", connection)
                Using adapter As New MySqlDataAdapter(command)
                    Dim datatable As New DataTable
                    adapter.Fill(datatable)
                    Return datatable
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New DataTable
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New DataTable
        End Try
    End Function
    Public Sub NewDepartment(departmentName As String)
        Dim deptName As String = StrConv(departmentName, VbStrConv.ProperCase)

        Try
            If departmentID = 0 Then
                Dim selectCommand As New MySqlCommand("SELECT departmentID FROM tblDepartment WHERE departmentName = @departmentName AND status = 'Inactive'", connection)
                selectCommand.Parameters.AddWithValue("@departmentName", deptName)
                Dim reader As MySqlDataReader = selectCommand.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    Dim existingDepartmentID As Integer = reader("departmentID")
                    reader.Close()

                    Dim command As New MySqlCommand("UPDATE tblDepartment SET status = 'Active' WHERE departmentID = @id", connection)
                    command.Parameters.AddWithValue("@id", existingDepartmentID)
                    command.ExecuteNonQuery()
                    MessageBox.Show("Department has been reactivated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Auditing($"{FrmMain.LblName.Text} reactivated a department: {departmentName}")
                Else
                    reader.Close()

                    Dim command As New MySqlCommand("INSERT INTO tblDepartment (departmentName, status) VALUES (@name, 'Active')", connection)
                    command.Parameters.AddWithValue("@name", deptName)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Department has been added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    departmentID = 0

                    RunQuery("Select departmentID from tbldepartment ORDER by departmentID DESC LIMIT 1")
                    Dim deptID As Integer = ds.Tables("querytable").Rows(0)(0)

                    RunCommand("Insert into tblposition (positionName,status,departmentID) VALUES ('Department Head','Active',@deptID)")
                    With com
                        .Parameters.AddWithValue("@deptID", deptID)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                    Auditing($"{FrmMain.LblName.Text} added department: {deptName}")
                End If
            Else
                Dim command As New MySqlCommand("UPDATE tblDepartment SET departmentName = @departmentName WHERE departmentID = @id", connection)
                command.Parameters.AddWithValue("@id", departmentID)
                command.Parameters.AddWithValue("@departmentName", deptName)
                command.ExecuteNonQuery()

                MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Auditing($"{FrmMain.LblName.Text} updated a department: {deptName}")
                departmentID = 0
            End If

        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public departmentName As String = ""
    Public Sub SelectDepartment(dg As DataGridView)
        Try
            If dg.SelectedRows.Count > 0 Then
                departmentID = dg.SelectedRows(0).Cells(0).Value
                FrmMainte.TxtDepartment.Text = dg.SelectedRows(0).Cells(1).Value
                departmentName = dg.SelectedRows(0).Cells(1).Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UpdateDepartmentStatus(dg As DataGridView)
        Try

            For Each row As DataGridViewRow In dg.SelectedRows
                Dim deptID As Integer = row.Cells("departmentID").Value

                RunQuery("Select * from tblemployee WHERE departmentID = '" & deptID & "' and status != 'Resigned'")
                If ds.Tables("querytable").Rows.Count > 0 Then
                    MsgBox("id exist")
                    Continue For
                End If

                Dim command As New MySqlCommand("UPDATE tblDepartment SET status = 'Inactive' WHERE departmentID = @id", connection)
                command.Parameters.AddWithValue("@id", deptID)
                command.ExecuteNonQuery()
                Auditing($"{FrmMain.LblName.Text} deleted a department.")
            Next

            departmentID = 0
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


#End Region

#Region "Leave"

    Public leaveID As Integer = 0
    Public Function DisplayLeave() As DataTable
        Dim datatable As New DataTable
        Try
            Using command As New MySqlCommand("SELECT * FROM tblLeave WHERE status = 'Active'", connection)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(datatable)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function


    Public Sub NewLeave(leaveName As String)
        Dim leave As String = StrConv(leaveName, VbStrConv.ProperCase)

        Try
            If leaveID = 0 Then
                Dim selectCommand As New MySqlCommand("SELECT leaveID FROM tblLeave WHERE leaveType = @leaveType AND status = 'Inactive'", connection)
                selectCommand.Parameters.AddWithValue("@leaveType", leave)
                Dim reader As MySqlDataReader = selectCommand.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    Dim existingLeaveID As Integer = reader("leaveID")
                    reader.Close()

                    Dim command As New MySqlCommand("UPDATE tblLeave SET status = 'Active' WHERE leaveID = @id", connection)
                    command.Parameters.AddWithValue("@id", existingLeaveID)
                    command.ExecuteNonQuery()
                    Auditing($"{FrmMain.LblName.Text} updated a type of leave: {leave}")
                    MessageBox.Show("Leave has been reactivated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    reader.Close()

                    Dim command As New MySqlCommand("INSERT INTO tblLeave (leaveType, status) VALUES (@name, 'Active')", connection)
                    command.Parameters.AddWithValue("@name", leave)
                    command.ExecuteNonQuery()
                    Auditing($"{FrmMain.LblName.Text} added a type of leave: {leave}")
                    MessageBox.Show("Leave has been added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    leaveID = 0
                End If
            Else
                Dim command As New MySqlCommand("UPDATE tblLeave SET leaveType = @leaveType WHERE leaveID = @id", connection)
                command.Parameters.AddWithValue("@id", leaveID)
                command.Parameters.AddWithValue("@leaveType", leave)
                command.ExecuteNonQuery()

                MessageBox.Show("Leave updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Auditing($"{FrmMain.LblName.Text} updated a type of leave: {leave}")
                leaveID = 0
            End If

        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public leaveName As String = ""
    Public Sub SelectLeaveID(dg As Guna2DataGridView)
        Try
            If dg.SelectedRows.Count > 0 Then
                leaveID = dg.SelectedRows(0).Cells(0).Value
                FrmMainte.TxtLeave.Text = dg.SelectedRows(0).Cells(1).Value
                leaveName = dg.SelectedRows(0).Cells(1).Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UpdateLeaveStatus(dg As DataGridView)
        Try

            For Each row As DataGridViewRow In dg.SelectedRows
                Dim command As New MySqlCommand("UPDATE tblLeave SET status = 'Inactive' WHERE leaveID = @id", connection)
                command.Parameters.AddWithValue("@id", leaveID)
                command.ExecuteNonQuery()
            Next
            MessageBox.Show("Leave deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} deleted a type of leave.")
            leaveID = 0
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region "Position"
    Public positionID As Integer = 0
    Public Function DisplayPosition() As DataTable
        Dim datatable As New DataTable
        Try
            Using command As New MySqlCommand("SELECT p.positionID, p.positionName, p.status, 
                                                   d.departmentName 
                                           FROM tblPosition p 
                                           JOIN tblDepartment d 
                                           ON d.departmentID = p.departmentID
                                           WHERE p.status = 'Active' AND d.status = 'Active' and p.positionName != 'Department Head'", connection)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(datatable)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function


    Public Sub NewPosition(positionName As String, departmentID As Integer)
        Dim position As String = StrConv(positionName, VbStrConv.ProperCase)

        Try
            If positionID = 0 Then
                Dim selectCommand As New MySqlCommand("SELECT positionID FROM tblPosition WHERE positionName = @positionName AND departmentID = @departmentID AND status = 'Inactive'", connection)
                selectCommand.Parameters.AddWithValue("@positionName", position)
                selectCommand.Parameters.AddWithValue("@departmentID", departmentID)
                Dim reader As MySqlDataReader = selectCommand.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    Dim existingPositionID As Integer = reader("positionID")
                    reader.Close()

                    Dim command As New MySqlCommand("UPDATE tblPosition SET status = 'Active' WHERE positionID = @id", connection)
                    command.Parameters.AddWithValue("@id", existingPositionID)
                    command.ExecuteNonQuery()
                    MessageBox.Show("Position has been reactivated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Auditing($"{FrmMain.LblName.Text} reactivated a position: {position}")
                Else
                    reader.Close()

                    Dim command As New MySqlCommand("INSERT INTO tblPosition (positionName, departmentID, status) VALUES (@name, @id, 'Active')", connection)
                    command.Parameters.AddWithValue("@name", position)
                    command.Parameters.AddWithValue("@id", departmentID)
                    command.ExecuteNonQuery()
                    MessageBox.Show("Position has been added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Auditing($"{FrmMain.LblName.Text} added position: {position}")
                    positionID = 0
                End If
            Else
                Dim command As New MySqlCommand("UPDATE tblPosition SET positionName = @name, departmentID = @id WHERE positionID = @positionID", connection)
                command.Parameters.AddWithValue("@name", position)
                command.Parameters.AddWithValue("@id", departmentID)
                command.Parameters.AddWithValue("@positionID", positionID)
                command.ExecuteNonQuery()

                MessageBox.Show("Position updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Auditing($"{FrmMain.LblName.Text} updated a position name: {position}")
                positionID = 0
            End If

        Catch ex As MySqlException
            MessageBox.Show("Cannot enter a same position in a same department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public positionName As String = ""
    Public positionDept As String = ""

    Public Sub SelectPositionID(dg As Guna2DataGridView)
        If dg.SelectedRows.Count > 0 Then
            FrmMainte.CbDepartment.Text = dg.SelectedRows(0).Cells("departmentPosition").Value.ToString
            positionDept = dg.SelectedRows(0).Cells("departmentPosition").Value.ToString
            positionID = dg.SelectedRows(0).Cells(0).Value
            FrmMainte.TxtPosition.Text = dg.SelectedRows(0).Cells(1).Value
            positionName = dg.SelectedRows(0).Cells(1).Value
        End If
    End Sub

    Public Sub UpdatePositionStatus(dg As DataGridView)
        Try
            For Each row As DataGridViewRow In dg.SelectedRows
                Dim posID As Integer = row.Cells("positionID").Value
                RunQuery("Select * from tblemployee where positionID = '" & posID & "' and status != 'Resigned'")
                If ds.Tables("querytable").Rows.Count > 0 Then
                    MsgBox("Cannot delete position.")
                    Continue For
                End If

                Dim command As New MySqlCommand("UPDATE tblPosition SET status = 'Inactive' WHERE positionID = @id", connection)
                command.Parameters.AddWithValue("@id", posID)
                Auditing($"{FrmMain.LblName.Text} deleted a position.")
                command.ExecuteNonQuery()
            Next

            positionID = 0
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Allowance"
    Public allowanceID As Integer = 0

    Public Function DisplayAllowance() As DataTable
        Dim datatable As New DataTable
        Try
            Using command As New MySqlCommand("SELECT * FROM tblAllowance WHERE status = 'Active'", connection)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(datatable)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function


    Public Sub NewAllowance(allowanceName As String)
        Dim allowance As String = StrConv(allowanceName, VbStrConv.ProperCase)

        Try
            If allowanceID = 0 Then
                Dim selectCommand As New MySqlCommand("SELECT allowanceID FROM tblAllowance WHERE allowanceName = @allowanceName AND status = 'Inactive'", connection)
                selectCommand.Parameters.AddWithValue("@allowanceName", allowance)
                Dim reader As MySqlDataReader = selectCommand.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    Dim existingAllowanceID As Integer = reader("allowanceID")
                    reader.Close()

                    Dim command As New MySqlCommand("UPDATE tblAllowance SET status = 'Active' WHERE allowanceID = @id", connection)
                    command.Parameters.AddWithValue("@id", existingAllowanceID)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Allowance has been reactivated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    allowanceID = 0
                    Auditing($"{FrmMain.LblName.Text} reactivated an allowance: {allowance}")
                Else
                    reader.Close()

                    Dim command As New MySqlCommand("INSERT INTO tblAllowance (allowanceName, status) VALUES (@name, 'Active')", connection)
                    command.Parameters.AddWithValue("@name", allowance)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Allowance has been added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Auditing($"{FrmMain.LblName.Text} added an allowance: {allowance}")
                    allowanceID = 0
                End If
            Else
                Dim command As New MySqlCommand("UPDATE tblAllowance SET allowanceName = @allowanceName WHERE allowanceID = @id", connection)
                command.Parameters.AddWithValue("@id", allowanceID)
                command.Parameters.AddWithValue("@allowanceName", allowance)
                command.ExecuteNonQuery()

                MessageBox.Show("Allowance updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Auditing($"{FrmMain.LblName.Text} updated an allowance: {allowance}")
                allowanceID = 0
            End If

        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public allowanceName As String = ""

    Public Sub SelectAllowance(dg As DataGridView)
        Try
            If dg.SelectedRows.Count > 0 Then
                allowanceID = dg.SelectedRows(0).Cells(0).Value
                allowanceName = dg.SelectedRows(0).Cells(1).Value
                FrmMainte.TxtAllowance.Text = dg.SelectedRows(0).Cells(1).Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UpdateAllowanceStatus(dg As DataGridView)
        Try
            For Each row As DataGridViewRow In dg.SelectedRows
                Dim command As New MySqlCommand("UPDATE tblAllowance SET status = 'Inactive' WHERE allowanceID = @id", connection)
                command.Parameters.AddWithValue("@id", allowanceID)
                command.ExecuteNonQuery()
            Next
            MessageBox.Show("Allowance deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} deleted an allowance.")
            allowanceID = 0
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Manage Position"
    Public Sub Load_department(cb As ComboBox)
        Try
            RunQuery("Select * from tbldepartment where status = 'Active'")
            If ds.Tables("querytable").Rows.Count > 0 Then
                cb.ValueMember = "departmentID"
                cb.DisplayMember = "departmentName"
                cb.DataSource = ds.Tables("querytable")
                cb.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub Load_position(deptcb As ComboBox, cbposition As ComboBox)
        Try
            If deptcb.SelectedIndex >= 0 Then
                Dim dept As String = deptcb.SelectedValue.ToString
                RunQuery("Select * from tblposition WHERE departmentID='" & dept & "' and status='Active'")
                If ds.Tables("querytable").Rows.Count > 0 Then
                    cbposition.ValueMember = "positionID"
                    cbposition.DisplayMember = "positionName"
                    cbposition.DataSource = ds.Tables("querytable")
                    cbposition.SelectedIndex = -1
                Else
                    cbposition.DataSource = Nothing
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub Update_Leave(dg As DataGridView, cb As ComboBox, dg1 As DataGridView)
        Try
            For Each row As DataGridViewRow In dg.Rows
                Dim positionID As Integer = cb.SelectedValue
                Dim manageleaveID As Integer = row.Cells(0).Value
                Dim days As Integer = If(String.IsNullOrEmpty(row.Cells(2).Value.ToString), 0, Convert.ToInt32(row.Cells(2).Value))
                RunCommand("Insert into tbljobleave (positionID,leaveID,days) VALUES (@positionID,@leaveID,@days) 
                            ON DUPLICATE KEY UPDATE
                            days = @days")
                With com.Parameters
                    .AddWithValue("@positionID", positionID)
                    .AddWithValue("@leaveID", manageleaveID)
                    .AddWithValue("@days", days)
                End With
                com.ExecuteNonQuery()
                com.Parameters.Clear()
            Next

            For Each row As DataGridViewRow In dg1.Rows

                Dim positionID As Integer = cb.SelectedValue
                Dim manageAllowanceID As Integer = row.Cells(0).Value
                Dim amount As Integer = If(String.IsNullOrEmpty(row.Cells(2).Value.ToString), 0, Convert.ToInt32(row.Cells(2).Value)) 'may error
                RunCommand("Insert into tbljoballowance (positionID,allowanceID,amount) VALUES (@positionID,@allowanceID,@amount) 
                            ON DUPLICATE KEY UPDATE
                            amount = @amount")
                With com.Parameters
                    .AddWithValue("@positionID", positionID)
                    .AddWithValue("@allowanceID", manageAllowanceID)
                    .AddWithValue("@amount", amount)
                End With
                com.ExecuteNonQuery()
                com.Parameters.Clear()
            Next
            MsgBox("Updated successfully", MsgBoxStyle.OkOnly, "MC-PMS")
            Auditing($"{FrmMain.LblName.Text} not sure kung anong message ng audit nito.")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Load_LeaveAndAllowance(cb As ComboBox, dg As DataGridView, dg1 As DataGridView)
        Try
            If cb.SelectedIndex = -1 Then
                dg.DataSource = Nothing
                dg1.DataSource = Nothing
            Else
                RunQuery("Select j.leaveID, j.leaveType, jl.days, j.status from tblleave j
                      left join tbljobleave jl on j.leaveID = jl.leaveID and jl.positionID = '" & cb.SelectedValue & "'
                      WHERE j.status = 'Active'")
                dg.DataSource = ds.Tables("querytable")

                RunQuery("Select a.allowanceID, a.allowanceName, ja.amount, a.status from tbljoballowance ja
                      right join tblallowance a on a.allowanceID = ja.allowanceID and ja.positionID = '" & cb.SelectedValue & "'
                      WHERE a.status = 'Active'")
                dg1.DataSource = ds.Tables("querytable")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Incentives"
    Public incentiveID As Integer = 0
    Public Function DisplayIncentives() As DataTable
        Dim datatable As New DataTable
        Try
            Using command As New MySqlCommand("SELECT * FROM tblIncentives WHERE status = 'Active'", connection)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(datatable)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function


    Public Sub NewIncentives(incentive As String)
        Dim incentiveName As String = StrConv(incentive, VbStrConv.ProperCase)

        Try
            If incentiveID = 0 Then
                Dim selectCommand As New MySqlCommand("SELECT incentiveID FROM tblIncentives WHERE incentiveName = @incentiveName AND status = 'Inactive'", connection)
                selectCommand.Parameters.AddWithValue("@incentiveName", incentiveName)
                Dim reader As MySqlDataReader = selectCommand.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    Dim existingIncentiveID As Integer = reader("incentiveID")
                    reader.Close()

                    Dim command As New MySqlCommand("UPDATE tblIncentives SET status = 'Active' WHERE incentiveID = @id", connection)
                    command.Parameters.AddWithValue("@id", existingIncentiveID)
                    command.ExecuteNonQuery()
                    incentiveID = 0
                    MessageBox.Show("Incentive has been reactivated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Auditing($"{FrmMain.LblName.Text} reactivated an incentive: {incentiveName}")
                Else
                    reader.Close()

                    Dim command As New MySqlCommand("INSERT INTO tblIncentives (incentiveName, status) VALUES (@name, 'Active')", connection)
                    command.Parameters.AddWithValue("@name", incentiveName)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Incentive has been added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    incentiveID = 0
                    Auditing($"{FrmMain.LblName.Text} added an incentive: {incentiveName}")
                End If
            Else
                Dim command As New MySqlCommand("UPDATE tblIncentives SET incentiveName = @incentiveName WHERE incentiveID = @id", connection)
                command.Parameters.AddWithValue("@id", incentiveID)
                command.Parameters.AddWithValue("@incentiveName", incentiveName)
                command.ExecuteNonQuery()

                MessageBox.Show("Incentive updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Auditing($"{FrmMain.LblName.Text} updated an incentive: {incentiveName}")
                incentiveID = 0
            End If

        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public incentiveName As String = ""
    Public Sub SelectIncentives(dg As DataGridView)
        Try
            If dg.SelectedRows.Count > 0 Then
                incentiveID = dg.SelectedRows(0).Cells(0).Value
                FrmMainte.TxtIncentives.Text = dg.SelectedRows(0).Cells(1).Value
                incentiveName = dg.SelectedRows(0).Cells(1).Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UpdateIncentiveStatus()
        Try
            Dim command As New MySqlCommand("UPDATE tblIncentives SET status = 'Inactive' WHERE incentiveID = @id", connection)
            command.Parameters.AddWithValue("@id", incentiveID)

            command.ExecuteNonQuery()

            MessageBox.Show("Incentive deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} deleted an incentive.")
            incentiveID = 0
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Holidays"

    Public holidayID As Integer = 0
    Public Function DisplayHoliday() As DataTable
        Dim datatable As New DataTable
        Try
            Using command As New MySqlCommand("SELECT * FROM tblHoliday", connection)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(datatable)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function


    Public Sub NewHoliday(holidayName As String, holidayDate As Date, classification As String)
        Dim holiday As String = StrConv(holidayName, VbStrConv.ProperCase)

        Try
            If holidayID = 0 Then
                Dim command As New MySqlCommand("INSERT INTO tblHoliday (holidayName, date, classification) VALUES (@name, @date, @classification)", connection)
                command.Parameters.AddWithValue("@name", holiday)
                command.Parameters.AddWithValue("@date", holidayDate)
                command.Parameters.AddWithValue("@classification", classification)
                command.ExecuteNonQuery()
                MessageBox.Show("Holiday added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Auditing($"{FrmMain.LblName.Text} added a holiday: {holiday}")
                holidayID = 0
            Else
                Dim command As New MySqlCommand("UPDATE tblHoliday SET holidayName = @name, date = @date, classification = @classification WHERE holidayID = @holidayID", connection)
                command.Parameters.AddWithValue("@name", holiday)
                command.Parameters.AddWithValue("@date", holidayDate)
                command.Parameters.AddWithValue("@classification", classification)
                command.Parameters.AddWithValue("@holidayID", holidayID)
                command.ExecuteNonQuery()
                MessageBox.Show("Holiday updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Auditing($"{FrmMain.LblName.Text} updated a holiday: {holiday}")
                holidayID = 0
            End If
        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public holidayName As String = ""
    Public Sub SelectHoliday(dg As DataGridView)
        Try
            If dg.SelectedRows.Count > 0 Then
                holidayID = dg.SelectedRows(0).Cells("holidayID").Value
                FrmMainte.TxtHoliday.Text = dg.SelectedRows(0).Cells("holidayName").Value
                holidayName = dg.SelectedRows(0).Cells("holidayName").Value
                FrmMainte.DtHoliday.Value = dg.SelectedRows(0).Cells("holidayDate").Value
                FrmMainte.CbClassification.Text = dg.SelectedRows(0).Cells("classification").Value.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DeleteHoliday()
        Try
            Dim command As New MySqlCommand("DELETE FROM tblHoliday WHERE holidayID = @holidayID", connection)
            command.Parameters.AddWithValue("@holidayID", holidayID)
            command.ExecuteNonQuery()
            MessageBox.Show("Holiday deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} deleted a holiday.")
            holidayID = 0
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Rates"
    Dim rateID As Integer = 0

    Public Function DisplayRates() As DataTable
        Dim datatable As New DataTable
        Try
            Using command As New MySqlCommand("SELECT * FROM tblrates", connection)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(datatable)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function


    Public Sub NewRates(rate As Integer, classification As String)
        Try
            If rateID = 0 Then
                Dim command As New MySqlCommand("INSERT INTO tblRates (rateClassification, rate) VALUES (@rateClassification, @rate)", connection)
                command.Parameters.AddWithValue("@rateClassification", classification)
                command.Parameters.AddWithValue("@rate", rate)
                command.ExecuteNonQuery()
                MessageBox.Show("Rate saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                rateID = 0
            Else
                Dim command As New MySqlCommand("UPDATE tblRates SET rate = @rate WHERE ratesID = @rateID", connection)
                command.Parameters.AddWithValue("@rate", rate)
                command.Parameters.AddWithValue("@rateID", rateID)
                command.ExecuteNonQuery()
                MessageBox.Show("Rates saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                rateID = 0
            End If
            Auditing($"{FrmMain.LblName.Text} updated {classification}'s rate")
        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SelectRates(dg As DataGridView)
        Try
            If dg.SelectedRows.Count > 0 Then
                rateID = dg.SelectedRows(0).Cells("rateID").Value
                FrmMainte.TxtRates.Text = dg.SelectedRows(0).Cells("rate").Value
                FrmMainte.TxtRateClassification.Text = dg.SelectedRows(0).Cells("rateClassification").Value
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Contributions"
#Region "Tax"
    Public Function DisplayTax() As DataTable
        Dim datatable As New DataTable
        Try
            Dim command As New MySqlCommand("SELECT * FROM tblTax", connection)
            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(datatable)
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function


    Public Function TaxGetMaxSalary() As Decimal
        Try
            Dim max As Decimal = 0
            RunQuery("Select maxSalary from tbltax order by taxID DESC LIMIT 1")
            If ds.Tables("querytable").Rows.Count > 0 Then
                Dim result = ds.Tables("querytable").Rows(0)(0)
                If Not IsDBNull(result) Then
                    max = Convert.ToDecimal(result) + 0.01
                End If
            Else
                max = 0
            End If
            Return max
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return 0
        End Try
    End Function

    Public Sub NewTax(minimumSalary As Decimal, maximumSalary As Decimal, fixedAmount As Decimal, percentage As Integer)
        Try
            Dim command As New MySqlCommand("INSERT INTO tblTax (minSalary, maxSalary, fixedAmount, percentage) 
                                         VALUES (@minSalary, @maxSalary, @fixedAmount, @percentage)", connection)
            With command.Parameters
                .AddWithValue("@minSalary", minimumSalary)
                .AddWithValue("@maxSalary", maximumSalary)
                .AddWithValue("@fixedAmount", fixedAmount)
                .AddWithValue("@percentage", percentage)
            End With

            command.ExecuteNonQuery()

            MessageBox.Show("Tax added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} added new tax.")
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DeleteTax()
        Try
            Dim checkCommand As New MySqlCommand("SELECT COUNT(*) FROM tblTax", connection)
            Dim count As Integer = checkCommand.ExecuteScalar()
            If count = 0 Then
                MessageBox.Show("This tax cannot deleted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                FrmMainte.TxtTaxFixedAmount.Clear()
                FrmMainte.TxtTaxMaxSalary.Clear()
                FrmMainte.TxtTaxMinSalary.Clear()
                FrmMainte.TxtTaxPercentage.Clear()
                Exit Sub
            End If
            Dim command As New MySqlCommand("DELETE FROM tblTax ORDER BY taxID DESC LIMIT 1", connection)
            command.ExecuteNonQuery()
            MessageBox.Show("Tax deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} deleted tax.")

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "SSS"
    Public Function DisplaySSS() As DataTable
        Dim datatable As New DataTable
        Try
            Dim command As New MySqlCommand("SELECT * FROM tblSSS", connection)
            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(datatable)
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function


    Public Function SSSGetMaxSalary() As Decimal
        Try
            Dim max As Decimal = 0
            RunQuery("Select max(maxSalary) from tblsss")
            If ds.Tables("querytable").Rows.Count > 0 Then
                Dim result = ds.Tables("querytable").Rows(0)(0)
                If Not IsDBNull(result) Then
                    max = Convert.ToDecimal(result) + 0.01
                End If
            Else
                max = 0
            End If
            Return max
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return 0
        End Try
    End Function
    Public Sub NewSSS(minSalary As Decimal, maxSalary As Decimal, EE As Decimal, wisp As Decimal)
        Try
            Dim command As New MySqlCommand("INSERT INTO tblSSS (minSalary, maxSalary, EE, wisp, total) 
                                         VALUES (@minSalary, @maxSalary, @EE, @wisp, @total)", connection)
            With command.Parameters
                .AddWithValue("@minSalary", minSalary)
                .AddWithValue("@maxSalary", maxSalary)
                .AddWithValue("@EE", EE)
                .AddWithValue("@wisp", wisp)
                .AddWithValue("@total", EE + wisp)
            End With

            command.ExecuteNonQuery()
            Auditing($"{FrmMain.LblName.Text} added SSS.")
            MessageBox.Show("SSS added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DeleteSSS()
        Try
            Dim command As New MySqlCommand("DELETE FROM tblSSS ORDER BY sssID DESC LIMIT 1", connection)
            command.ExecuteNonQuery()
            MessageBox.Show("SSS deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} deleted an SSS.")
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "PAGIBIG"
    Public Function DisplayPagIbig() As DataTable
        Dim datatable As New DataTable
        Try
            Dim command As New MySqlCommand("SELECT * FROM tblpagibig ORDER BY date DESC", connection)
            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(datatable)
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function

    Public Sub NewPagibig(rate As Integer)
        Try
            Dim command As New MySqlCommand("INSERT INTO tblpagibig (rate, date) VALUES (@rate, current_timestamp)", connection)
            With command.Parameters
                .AddWithValue("@rate", rate)
            End With

            command.ExecuteNonQuery()

            MessageBox.Show("New Pag-Ibig rate updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} updated PAGIBIG rates.")
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Philhealth"
    Public Function DisplayPhilhealth() As DataTable
        Dim datatable As New DataTable
        Try
            Dim command As New MySqlCommand("SELECT * FROM tblPhilhealth ORDER BY date DESC", connection)
            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(datatable)
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return datatable
    End Function


    Public Sub NewPhilhealth(rate As Integer)
        Try
            Dim command As New MySqlCommand("INSERT INTO tblPhilHealth (rate, date) VALUES (@rate, NOW())", connection)
            command.Parameters.AddWithValue("@rate", rate)

            command.ExecuteNonQuery()

            MessageBox.Show("PhilHealth rate added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} updated PhilHealth's rate.")
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region
#End Region

#Region "Voluntary"

    Public voluntaryID As Integer = 0

    Public Function DisplayVoluntary() As DataTable
        Dim dt As New DataTable
        Try
            Using command As New MySqlCommand("SELECT * FROM tblVoluntary WHERE status = 'Active'", connection)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function


    Public Sub NewVoluntary(voluntaryName As String)
        Dim voluntary As String = StrConv(voluntaryName, VbStrConv.ProperCase)

        Try
            If voluntaryID = 0 Then
                Dim selectCommand As New MySqlCommand("SELECT voluntaryID FROM tblVoluntary WHERE name = @voluntaryName AND status = 'Inactive'", connection)
                selectCommand.Parameters.AddWithValue("@voluntaryName", voluntary)
                Dim reader As MySqlDataReader = selectCommand.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    Dim existingVoluntaryID As Integer = reader("voluntaryID")
                    reader.Close()

                    Dim command As New MySqlCommand("UPDATE tblVoluntary SET status = 'Active' WHERE voluntaryID = @id", connection)
                    command.Parameters.AddWithValue("@id", existingVoluntaryID)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Voluntary has been reactivated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Auditing($"{FrmMain.LblName.Text} reactivated a voluntary contribution: {voluntary}")
                    voluntaryID = 0
                Else
                    reader.Close()

                    Dim command As New MySqlCommand("INSERT INTO tblVoluntary (name, status) VALUES (@name, 'Active')", connection)
                    command.Parameters.AddWithValue("@name", voluntary)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Voluntary has been added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Auditing($"{FrmMain.LblName.Text} added a voluntary contribution: {voluntary}")
                    voluntaryID = 0

                End If
            Else
                Dim command As New MySqlCommand("UPDATE tblVoluntary SET name = @voluntaryName WHERE voluntaryID = @id", connection)
                command.Parameters.AddWithValue("@id", voluntaryID)
                command.Parameters.AddWithValue("@voluntaryName", voluntary)
                command.ExecuteNonQuery()

                MessageBox.Show("Voluntary updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Auditing($"{FrmMain.LblName.Text} updated a voluntary contributions: {voluntary}")
                voluntaryID = 0
            End If

        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub UpdateVoluntaryStatus()
        Try
            Dim command As New MySqlCommand("UPDATE tblVoluntary SET status = 'Inactive' WHERE voluntaryID = @id", connection)
            command.Parameters.AddWithValue("@id", voluntaryID)

            command.ExecuteNonQuery()

            MessageBox.Show("Voluntary deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Auditing($"{FrmMain.LblName.Text} deleted a voluntary contribution.")
            voluntaryID = 0
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'hehez
    Public voluntaryName As String = ""
    Public Sub SelectVoluntaryID(dg As Guna2DataGridView)
        Try
            If dg.SelectedRows.Count > 0 Then
                voluntaryID = dg.SelectedRows(0).Cells(0).Value
                FrmMainte.TxtVoluntary.Text = dg.SelectedRows(0).Cells(1).Value
                voluntaryName = dg.SelectedRows(0).Cells(1).Value
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Module
