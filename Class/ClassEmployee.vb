Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class ClassEmployee
    Public Shared employeeID As Integer

    Public Shared Sub LoadEmployee(dg As DataGridView)
        Try
            RunQuery("Select a.employeeID,a.employeeNumber,a.rfidnumber,a.firstname,a.middlename,a.lastname,b.departmentName,if(a.positionID=0,NULL,c.positionName) as positionName,d.salary,d.type,a.status from tblemployee a
                      LEFT JOIN tbldepartment b on b.departmentID = a.departmentID
                      LEFT JOIN tblposition c on c.positionID = a.positionID
                      LEFT JOIN tblsalary d on d.employeeID = a.employeeID
                      ORDER by a.employeeID")
            dg.DataSource = ds.Tables("querytable")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub LoadVoluntary(dg As DataGridView)
        Try
            If employeeID = 0 Then
                RunQuery("select voluntaryID, name, '0' as amount from tblvoluntary WHERE status='Active'")
                dg.DataSource = ds.Tables("querytable")
                FrmEmployee.RBDaily.Checked = True
            Else
                RunQuery("select b.voluntaryID, b.name, a.amount from tblempvoluntary a
                          right join tblvoluntary b on b.voluntaryID = a.voluntaryID and a.employeeID = '" & employeeID & "'
                          where b.status='Active'")
                dg.AutoGenerateColumns = False
                dg.DataSource = ds.Tables("querytable")
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub LoadDepartment(cb As Guna2ComboBox)
        Try
            RunQuery("Select * from tbldepartment where status = 'Active'")
            cb.ValueMember = "departmentID"
            cb.DisplayMember = "departmentName"
            cb.DataSource = ds.Tables("querytable")
            cb.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub RefreshDepartment(cb As Guna2ComboBox)
        Try
            RunQuery("Select * from tbldepartment where status='Active'")
            Dim count As Integer = ds.Tables("querytable").Rows.Count
            If cb.Items.Count < count Then
                LoadDepartment(cb)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub RefreshVoluntary(dg As DataGridView)
        Try
            RunQuery("select * from tblvoluntary where status = 'Active'")
            Dim count As Integer = ds.Tables("querytable").Rows.Count
            If dg.Rows.Count < count Then
                LoadVoluntary(dg)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Shared Sub LoadPosition(cbDept As Guna2ComboBox, cbPos As Guna2ComboBox)
        Try
            RunQuery("Select * from tblposition where departmentID = '" & cbDept.SelectedValue & "'")
            cbPos.ValueMember = "positionID"
            cbPos.DisplayMember = "positionName"
            cbPos.DataSource = ds.Tables("querytable")
            cbPos.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub SelectEmployee(dg As Guna2DataGridView, txtrfid As Guna2TextBox, txtfirstname As Guna2TextBox, txtmiddlename As Guna2TextBox, txtlastname As Guna2TextBox, cbdept As Guna2ComboBox, cbpos As Guna2ComboBox, cbstatus As Guna2ComboBox, txtsalary As Guna2TextBox)
        Try
            If dg.SelectedRows.Count > 0 Then
                employeeID = dg.SelectedRows(0).Cells(0).Value
                txtrfid.Text = dg.SelectedRows(0).Cells(2).Value
                txtfirstname.Text = dg.SelectedRows(0).Cells(3).Value
                txtmiddlename.Text = dg.SelectedRows(0).Cells(4).Value
                txtlastname.Text = dg.SelectedRows(0).Cells(5).Value
                cbdept.Text = If(String.IsNullOrEmpty(dg.SelectedRows(0).Cells(6).Value.ToString), "", dg.SelectedRows(0).Cells(6).Value)
                cbpos.Text = If(String.IsNullOrEmpty(dg.SelectedRows(0).Cells(7).Value.ToString), "", dg.SelectedRows(0).Cells(7).Value)
                txtsalary.Text = If(String.IsNullOrEmpty(dg.SelectedRows(0).Cells(8).Value.ToString), "0.00", dg.SelectedRows(0).Cells(8).Value)
                If dg.SelectedRows(0).Cells(9).Value.ToString = "Daily" Then
                    FrmEmployee.RBDaily.Checked = True
                ElseIf dg.SelectedRows(0).Cells(9).Value.ToString = "Monthly" Then
                    FrmEmployee.RBMonthly.Checked = True
                Else
                    FrmEmployee.RBDaily.Checked = False
                    FrmEmployee.RBMonthly.Checked = False
                End If
                cbstatus.Text = If(IsDBNull(dg.SelectedRows(0).Cells(10).Value), "", dg.SelectedRows(0).Cells(10).Value)
                FrmEmployee.TCEmployee.SelectedTab = FrmEmployee.TPEmployeeProfile
                FrmEmployee.TxtFirstName.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Public Shared Sub NewEmployee(rfidnumber As Guna2TextBox, txtlastname As Guna2TextBox, txtfirstname As Guna2TextBox, txtmiddlename As Guna2TextBox, cbdept As Guna2ComboBox, cbpos As Guna2ComboBox, txtsalary As Guna2TextBox, cbstatus As Guna2ComboBox)
        'Try
        Dim employeenumber As Integer
        If employeeID = 0 Then

            If cbstatus.Text = "Resigned" Then
                MsgBox("Can't set the status to resigned for new employees", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim deptID As Integer = cbdept.SelectedValue

            'Get Last Inserted Employee Number
            RunQuery("Select * from tblemployee order by employeeID DESC LIMIT 1")
            If ds.Tables("querytable").Rows.Count > 0 Then
                employeenumber = ds.Tables("querytable").Rows(0)(1) + 1
            Else
                Dim year = Now.Year
                employeenumber = year & "0001"
            End If

            'If Position is Department Head and there is an existing Department Head
            If cbpos.Text = "Department Head" Then
                RunQuery("Select * from tbldepartmenthead where departmentID = '" & deptID & "' and employeeID != 0")
                If ds.Tables("querytable").Rows.Count > 0 Then
                    MsgBox("There's an assigned Department Head already. Demote the current Department Head to assign a new one.")
                    Exit Sub


                Else

                    'Insert employee
                    RunCommand("Insert into tblemployee (employeeNumber,rfidnumber,lastname,firstname,middlename,departmentID,positionID,status) VALUES
                        (@employeeNumber,@rfidnumber,@lastname,@firstname,@middlename,@departmentID,@positionID,@status)")
                    With com
                        .Parameters.AddWithValue("@employeeID", employeeID)
                        .Parameters.AddWithValue("@employeeNumber", employeenumber)
                        .Parameters.AddWithValue("@rfidnumber", rfidnumber.Text)
                        .Parameters.AddWithValue("@lastname", txtlastname.Text)
                        .Parameters.AddWithValue("@firstname", txtfirstname.Text)
                        .Parameters.AddWithValue("@middlename", txtmiddlename.Text)
                        .Parameters.AddWithValue("@departmentID", cbdept.SelectedValue)
                        .Parameters.AddWithValue("@positionID", cbpos.SelectedValue)
                        .Parameters.AddWithValue("@status", cbstatus.Text)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With


                    'Get last inserted Employee ID
                    RunQuery("Select employeeID from tblemployee order by employeeID DESC limit 1")
                    Dim newemployeeID As Integer = ds.Tables("querytable").Rows(0)(0)

                    'If Position is Department Head and no Department Assigned yet
                    If cbpos.Text = "Department Head" Then
                        RunCommand("Insert into tbldepartmenthead (departmentID,employeeID) VALUES (@departmentID,@employeeID) 
                                    ON DUPLICATE KEY UPDATE employeeID=@employeeID")
                        With com
                            .Parameters.AddWithValue("@departmentID", deptID)
                            .Parameters.AddWithValue("@employeeID", newemployeeID)
                            .ExecuteNonQuery()
                            .Parameters.Clear()
                        End With
                    End If

                    'Get last inserted
                    RunQuery("Select * from tblemployee ORDER by employeeID DESC LIMIT 1")
                    If ds.Tables("querytable").Rows.Count > 0 Then
                        Dim empID As Integer = ds.Tables("querytable").Rows(0)(0)

                        RunCommand("Insert into tblsalary (employeeID,salary,type) VALUES (@employeeID,@salary,@type)")
                        With com
                            .Parameters.AddWithValue("@employeeID", empID)
                            .Parameters.AddWithValue("@salary", txtsalary.Text.Trim)
                            .Parameters.AddWithValue("@type", If(FrmEmployee.RBDaily.Checked = True, "Daily", "Monthly"))
                            .ExecuteNonQuery()
                            .Parameters.Clear()

                        End With

                        'Voluntary
                        For Each row As DataGridViewRow In FrmEmployee.DGVoluntary.Rows
                            Dim volID As Integer = row.Cells("voluntaryID").Value
                            Dim amount As Decimal = If(String.IsNullOrEmpty(row.Cells("amount").Value), 0, row.Cells("amount").Value)

                            RunCommand("Insert into tblempvoluntary (employeeID,voluntaryID,amount) VALUES (@employeeID,@voluntaryID,@amount)
                                    ON DUPLICATE KEY UPDATE amount=@amount")
                            With com
                                .Parameters.AddWithValue("@employeeID", empID)
                                .Parameters.AddWithValue("@voluntaryID", volID)
                                .Parameters.AddWithValue("@amount", amount)
                                .ExecuteNonQuery()
                                .Parameters.Clear()
                            End With
                        Next
                    End If
                    MsgBox("Saved")
                End If

            Else
                'Insert employee
                RunCommand("Insert into tblemployee (employeeNumber,rfidnumber,lastname,firstname,middlename,departmentID,positionID,status) VALUES
                        (@employeeNumber,@rfidnumber,@lastname,@firstname,@middlename,@departmentID,@positionID,@status)")
                With com
                    .Parameters.AddWithValue("@employeeID", employeeID)
                    .Parameters.AddWithValue("@employeeNumber", employeenumber)
                    .Parameters.AddWithValue("@rfidnumber", rfidnumber.Text)
                    .Parameters.AddWithValue("@lastname", txtlastname.Text)
                    .Parameters.AddWithValue("@firstname", txtfirstname.Text)
                    .Parameters.AddWithValue("@middlename", txtmiddlename.Text)
                    .Parameters.AddWithValue("@departmentID", cbdept.SelectedValue)
                    .Parameters.AddWithValue("@positionID", cbpos.SelectedValue)
                    .Parameters.AddWithValue("@status", cbstatus.Text)
                    .ExecuteNonQuery()
                    .Parameters.Clear()
                End With

                'Get last inserted Employee ID
                RunQuery("Select employeeID from tblemployee order by employeeID DESC limit 1")
                Dim newemployeeID As Integer = ds.Tables("querytable").Rows(0)(0)


                'Get last inserted
                RunQuery("Select * from tblemployee ORDER by employeeID DESC LIMIT 1")
                If ds.Tables("querytable").Rows.Count > 0 Then
                    Dim empID As Integer = ds.Tables("querytable").Rows(0)(0)

                    RunCommand("Insert into tblsalary (employeeID,salary,type) VALUES (@employeeID,@salary,@type)")
                    With com
                        .Parameters.AddWithValue("@employeeID", empID)
                        .Parameters.AddWithValue("@salary", txtsalary.Text.Trim)
                        .Parameters.AddWithValue("@type", If(FrmEmployee.RBDaily.Checked = True, "Daily", "Monthly"))
                        .ExecuteNonQuery()
                        .Parameters.Clear()

                    End With

                    'Voluntary
                    For Each row As DataGridViewRow In FrmEmployee.DGVoluntary.Rows
                        Dim volID As Integer = row.Cells("voluntaryID").Value
                        Dim amount As Decimal = If(String.IsNullOrEmpty(row.Cells("amount").Value), 0, row.Cells("amount").Value)

                        RunCommand("Insert into tblempvoluntary (employeeID,voluntaryID,amount) VALUES (@employeeID,@voluntaryID,@amount)
                                    ON DUPLICATE KEY UPDATE amount=@amount")
                        With com
                            .Parameters.AddWithValue("@employeeID", empID)
                            .Parameters.AddWithValue("@voluntaryID", volID)
                            .Parameters.AddWithValue("@amount", amount)
                            .ExecuteNonQuery()
                            .Parameters.Clear()
                        End With
                    Next
                End If
            End If
            MsgBox("Saved")
        Else
            Dim depID As Integer = cbdept.SelectedValue
            Dim selectedposID As Integer = cbpos.SelectedValue
            RunQuery("Select * from tblemployee where employeeID = '" & employeeID & "'")
            Dim posID As Integer
            If ds.Tables("querytable").Rows.Count > 0 Then
                posID = ds.Tables("querytable").Rows(0)(0)
            End If

            'If no current position
            If posID = 0 Then


                'If aassign na department head
                If cbpos.Text = "Department Head" Then

                    'If may assigned Department Head
                    RunQuery("Select * from tbldepartmenthead where departmentID = '" & depID & "' and employeeID !='" & employeeID & "'")
                    If ds.Tables("querytable").Rows.Count > 0 Then
                        MsgBox("There's an assigned Department Head already. Demote the Department head first.")
                        Exit Sub

                    Else
                        'If walang department head
                        RunCommand("Update tblemployee SET rfidnumber=@rfidnumber, firstname=@firstname,middlename=@middlename,lastname=@lastname,
                                            departmentID=@departmentID,positionID=@positionID,status=@status WHERE employeeID=@employeeID")
                        With com
                            .Parameters.AddWithValue("@rfidnumber", rfidnumber.Text.Trim)
                            .Parameters.AddWithValue("@firstname", txtfirstname.Text.Trim)
                            .Parameters.AddWithValue("@middlename", txtmiddlename.Text.Trim)
                            .Parameters.AddWithValue("@lastname", txtlastname.Text.Trim)
                            .Parameters.AddWithValue("@departmentID", depID)
                            .Parameters.AddWithValue("@positionID", selectedposID)
                            .Parameters.AddWithValue("@status", cbstatus.Text)
                            .Parameters.AddWithValue("@employeeID", employeeID)
                            .ExecuteNonQuery()
                            .Parameters.Clear()

                        End With

                        'Create new department head
                        RunCommand("Insert into tbldepartmenthead (departmentID,employeeID) VALUES (@departmentID,@employeeID) 
                                    ON DUPLICATE KEY UPDATE employeeID=@employeeID")
                        With com
                            .Parameters.AddWithValue("@departmentID", depID)
                            .Parameters.AddWithValue("@employeeID", employeeID)

                        End With

                        'Update Salary
                        RunCommand("Update tblsalary set salary=@salary, type=@type WHERE employeeID=@employeeID")
                        With com
                            .Parameters.AddWithValue("@employeeID", employeeID)
                            .Parameters.AddWithValue("@salary", txtsalary.Text.Trim)
                            .Parameters.AddWithValue("@type", If(FrmEmployee.RBDaily.Checked = True, "Daily", "Monthly"))
                            .ExecuteNonQuery()
                            .Parameters.Clear()

                        End With

                        'Insert Voluntary Contribution
                        For Each row As DataGridViewRow In FrmEmployee.DGVoluntary.Rows
                            Dim volID As Integer = row.Cells("voluntaryID").Value
                            Dim amount As Decimal = If(String.IsNullOrEmpty(row.Cells("amount").Value.ToString), 0, row.Cells("amount").Value)

                            RunCommand("Insert into tblempvoluntary (employeeID,voluntaryID,amount) VALUES (@employeeID,@voluntaryID,@amount)
                                        ON DUPLICATE KEY UPDATE amount=@amount")
                            With com
                                .Parameters.AddWithValue("@employeeID", employeeID)
                                .Parameters.AddWithValue("@voluntaryID", volID)
                                .Parameters.AddWithValue("@amount", amount)
                                .ExecuteNonQuery()
                                .Parameters.Clear()
                            End With
                        Next


                        'Check if may schedule
                        RunQuery("Select * from tblschedule where employeeID = '" & employeeID & "'")
                        If ds.Tables("querytable").Rows.Count > 0 Then
                            GetDailyWageOfMonthlyEmployees(employeeID)

                        End If

                    End If
                    MsgBox("Saved")

                Else
                    'If hindi department head
                    RunCommand("Update tblemployee SET rfidnumber=@rfidnumber, firstname=@firstname,middlename=@middlename,lastname=@lastname,
                                            departmentID=@departmentID,positionID=@positionID,status=@status WHERE employeeID=@employeeID")
                    With com
                        .Parameters.AddWithValue("@rfidnumber", rfidnumber.Text.Trim)
                        .Parameters.AddWithValue("@firstname", txtfirstname.Text.Trim)
                        .Parameters.AddWithValue("@middlename", txtmiddlename.Text.Trim)
                        .Parameters.AddWithValue("@lastname", txtlastname.Text.Trim)
                        .Parameters.AddWithValue("@departmentID", depID)
                        .Parameters.AddWithValue("@positionID", selectedposID)
                        .Parameters.AddWithValue("@status", cbstatus.Text)
                        .Parameters.AddWithValue("@employeeID", employeeID)
                        .ExecuteNonQuery()
                        .Parameters.Clear()

                    End With

                    'Update Salary
                    RunCommand("Update tblsalary set salary=@salary, type=@type WHERE employeeID=@employeeID")
                    With com
                        .Parameters.AddWithValue("@employeeID", employeeID)
                        .Parameters.AddWithValue("@salary", txtsalary.Text.Trim)
                        .Parameters.AddWithValue("@type", If(FrmEmployee.RBDaily.Checked = True, "Daily", "Monthly"))
                        .ExecuteNonQuery()
                        .Parameters.Clear()

                    End With

                    'Insert Voluntary Contribution
                    For Each row As DataGridViewRow In FrmEmployee.DGVoluntary.Rows
                        Dim volID As Integer = row.Cells("voluntaryID").Value
                        Dim amount As Decimal = If(String.IsNullOrEmpty(row.Cells("amount").Value.ToString), 0, row.Cells("amount").Value)

                        RunCommand("Insert into tblempvoluntary (employeeID,voluntaryID,amount) VALUES (@employeeID,@voluntaryID,@amount)
                                        ON DUPLICATE KEY UPDATE amount=@amount")
                        With com
                            .Parameters.AddWithValue("@employeeID", employeeID)
                            .Parameters.AddWithValue("@voluntaryID", volID)
                            .Parameters.AddWithValue("@amount", amount)
                            .ExecuteNonQuery()
                            .Parameters.Clear()
                        End With
                    Next


                    'Check if may schedule
                    RunQuery("Select * from tblschedule where employeeID = '" & employeeID & "'")
                    If ds.Tables("querytable").Rows.Count > 0 Then
                        GetDailyWageOfMonthlyEmployees(employeeID)
                    End If
                    MsgBox("Saved")
                End If

            Else
                'May position na magpapalit lang

                'Magpapalit into department head
                If cbpos.Text = "Department Head" Then
                    RunQuery("Select * from tbldepartmenthead where departmentID = '" & depID & "'")
                    'If merong department
                    If ds.Tables("querytable").Rows.Count > 0 Then
                        Dim sempid As Integer = ds.Tables("querytable").Rows(0)(2)
                        If sempid = 0 Then
                            'IF WALANG DEPARTMENT HEAD

                            'Update profile
                            RunCommand("Update tblemployee SET rfidnumber=@rfidnumber, firstname=@firstname,middlename=@middlename,lastname=@lastname,
                                            departmentID=@departmentID,positionID=@positionID,status=@status WHERE employeeID=@employeeID")
                            With com
                                .Parameters.AddWithValue("@rfidnumber", rfidnumber.Text.Trim)
                                .Parameters.AddWithValue("@firstname", txtfirstname.Text.Trim)
                                .Parameters.AddWithValue("@middlename", txtmiddlename.Text.Trim)
                                .Parameters.AddWithValue("@lastname", txtlastname.Text.Trim)
                                .Parameters.AddWithValue("@departmentID", depID)
                                .Parameters.AddWithValue("@positionID", selectedposID)
                                .Parameters.AddWithValue("@status", cbstatus.Text)
                                .Parameters.AddWithValue("@employeeID", employeeID)
                                .ExecuteNonQuery()
                                .Parameters.Clear()

                            End With

                            'Update Salary
                            RunCommand("Update tblsalary set salary=@salary, type=@type WHERE employeeID=@employeeID")
                            With com
                                .Parameters.AddWithValue("@employeeID", employeeID)
                                .Parameters.AddWithValue("@salary", txtsalary.Text.Trim)
                                .Parameters.AddWithValue("@type", If(FrmEmployee.RBDaily.Checked = True, "Daily", "Monthly"))
                                .ExecuteNonQuery()
                                .Parameters.Clear()

                            End With
                            'Insert Voluntary Contribution
                            For Each row As DataGridViewRow In FrmEmployee.DGVoluntary.Rows
                                Dim volID As Integer = row.Cells("voluntaryID").Value
                                Dim amount As Decimal = If(String.IsNullOrEmpty(row.Cells("amount").Value.ToString), 0, row.Cells("amount").Value)

                                RunCommand("Insert into tblempvoluntary (employeeID,voluntaryID,amount) VALUES (@employeeID,@voluntaryID,@amount)
                                        ON DUPLICATE KEY UPDATE amount=@amount")
                                With com
                                    .Parameters.AddWithValue("@employeeID", employeeID)
                                    .Parameters.AddWithValue("@voluntaryID", volID)
                                    .Parameters.AddWithValue("@amount", amount)
                                    .ExecuteNonQuery()
                                    .Parameters.Clear()
                                End With
                            Next

                            'Assign Department HEad
                            RunCommand("Update tbldepartmenthead set employeeID = '" & employeeID & "' where employeeID = 0 and departmentID = '" & depID & "'")
                            With com
                                .ExecuteNonQuery()
                                .Parameters.Clear()
                            End With


                            'Check if may schedule
                            RunQuery("Select * from tblschedule where employeeID = '" & employeeID & "'")
                            If ds.Tables("querytable").Rows.Count > 0 Then
                                GetDailyWageOfMonthlyEmployees(employeeID)
                            End If
                            MsgBox("Saved")


                        Else
                            ''IF MERONG DEPARTMENT HEAD
                            If sempid = employeeID Then
                                'IF SAME ACCOUNT 

                                'Update profile
                                RunCommand("Update tblemployee SET rfidnumber=@rfidnumber, firstname=@firstname,middlename=@middlename,lastname=@lastname,
                                            departmentID=@departmentID,positionID=@positionID,status=@status WHERE employeeID=@employeeID")
                                With com
                                    .Parameters.AddWithValue("@rfidnumber", rfidnumber.Text.Trim)
                                    .Parameters.AddWithValue("@firstname", txtfirstname.Text.Trim)
                                    .Parameters.AddWithValue("@middlename", txtmiddlename.Text.Trim)
                                    .Parameters.AddWithValue("@lastname", txtlastname.Text.Trim)
                                    .Parameters.AddWithValue("@departmentID", depID)
                                    .Parameters.AddWithValue("@positionID", selectedposID)
                                    .Parameters.AddWithValue("@status", cbstatus.Text)
                                    .Parameters.AddWithValue("@employeeID", employeeID)
                                    .ExecuteNonQuery()
                                    .Parameters.Clear()

                                End With

                                'Update Salary
                                RunCommand("Update tblsalary set salary=@salary, type=@type WHERE employeeID=@employeeID")
                                With com
                                    .Parameters.AddWithValue("@employeeID", employeeID)
                                    .Parameters.AddWithValue("@salary", txtsalary.Text.Trim)
                                    .Parameters.AddWithValue("@type", If(FrmEmployee.RBDaily.Checked = True, "Daily", "Monthly"))
                                    .ExecuteNonQuery()
                                    .Parameters.Clear()
                                End With

                                'Insert Voluntary Contribution
                                For Each row As DataGridViewRow In FrmEmployee.DGVoluntary.Rows
                                    Dim volID As Integer = row.Cells("voluntaryID").Value
                                    Dim amount As Decimal = If(String.IsNullOrEmpty(row.Cells("amount").Value.ToString), 0, row.Cells("amount").Value)

                                    RunCommand("Insert into tblempvoluntary (employeeID,voluntaryID,amount) VALUES (@employeeID,@voluntaryID,@amount)
                                        ON DUPLICATE KEY UPDATE amount=@amount")
                                    With com
                                        .Parameters.AddWithValue("@employeeID", employeeID)
                                        .Parameters.AddWithValue("@voluntaryID", volID)
                                        .Parameters.AddWithValue("@amount", amount)
                                        .ExecuteNonQuery()
                                        .Parameters.Clear()
                                    End With
                                Next

                                'Create new department head
                                RunCommand("Insert into tbldepartmenthead (departmentID,employeeID) VALUES (@departmentID,@employeeID) 
                                    ON DUPLICATE KEY UPDATE employeeID=@employeeID")
                                With com
                                    .Parameters.AddWithValue("@departmentID", depID)
                                    .Parameters.AddWithValue("@employeeID", employeeID)
                                End With

                                'Check if may schedule
                                RunQuery("Select * from tblschedule where employeeID = '" & employeeID & "'")
                                If ds.Tables("querytable").Rows.Count > 0 Then
                                    GetDailyWageOfMonthlyEmployees(employeeID)
                                End If
                                MsgBox("Saved")
                            Else
                                MsgBox("There's an assigned Department Head already. Demote the current Department Head to assign a new one.")
                                Exit Sub
                            End If
                        End If
                    Else
                        'If wala pang department
                        'Update profile
                        RunCommand("Update tblemployee SET rfidnumber=@rfidnumber, firstname=@firstname,middlename=@middlename,lastname=@lastname,
                                            departmentID=@departmentID,positionID=@positionID,status=@status WHERE employeeID=@employeeID")
                        With com
                            .Parameters.AddWithValue("@rfidnumber", rfidnumber.Text.Trim)
                            .Parameters.AddWithValue("@firstname", txtfirstname.Text.Trim)
                            .Parameters.AddWithValue("@middlename", txtmiddlename.Text.Trim)
                            .Parameters.AddWithValue("@lastname", txtlastname.Text.Trim)
                            .Parameters.AddWithValue("@departmentID", depID)
                            .Parameters.AddWithValue("@positionID", selectedposID)
                            .Parameters.AddWithValue("@status", cbstatus.Text)
                            .Parameters.AddWithValue("@employeeID", employeeID)
                            .ExecuteNonQuery()
                            .Parameters.Clear()

                        End With

                        'Update Salary
                        RunCommand("Update tblsalary set salary=@salary, type=@type WHERE employeeID=@employeeID")
                        With com
                            .Parameters.AddWithValue("@employeeID", employeeID)
                            .Parameters.AddWithValue("@salary", txtsalary.Text.Trim)
                            .Parameters.AddWithValue("@type", If(FrmEmployee.RBDaily.Checked = True, "Daily", "Monthly"))
                            .ExecuteNonQuery()
                            .Parameters.Clear()

                        End With
                        'Insert Voluntary Contribution
                        For Each row As DataGridViewRow In FrmEmployee.DGVoluntary.Rows
                            Dim volID As Integer = row.Cells("voluntaryID").Value
                            Dim amount As Decimal = If(String.IsNullOrEmpty(row.Cells("amount").Value.ToString), 0, row.Cells("amount").Value)

                            RunCommand("Insert into tblempvoluntary (employeeID,voluntaryID,amount) VALUES (@employeeID,@voluntaryID,@amount)
                                        ON DUPLICATE KEY UPDATE amount=@amount")
                            With com
                                .Parameters.AddWithValue("@employeeID", employeeID)
                                .Parameters.AddWithValue("@voluntaryID", volID)
                                .Parameters.AddWithValue("@amount", amount)
                                .ExecuteNonQuery()
                                .Parameters.Clear()
                            End With
                        Next


                        'Check if may schedule
                        RunQuery("Select * from tblschedule where employeeID = '" & employeeID & "'")
                        If ds.Tables("querytable").Rows.Count > 0 Then
                            GetDailyWageOfMonthlyEmployees(employeeID)
                        End If

                        'Create new department head
                        RunCommand("Insert into tbldepartmenthead (departmentID,employeeID) VALUES (@departmentID,@employeeID) 
                                    ON DUPLICATE KEY UPDATE employeeID=@employeeID")
                        With com
                            .Parameters.AddWithValue("@departmentID", depID)
                            .Parameters.AddWithValue("@employeeID", employeeID)

                        End With

                        MsgBox("Saved")
                    End If
                Else
                    'Magpapalit pero hindi department head
                    RunCommand("Update tblemployee SET rfidnumber=@rfidnumber, firstname=@firstname,middlename=@middlename,lastname=@lastname,
                                            departmentID=@departmentID,positionID=@positionID,status=@status WHERE employeeID=@employeeID")
                    With com
                        .Parameters.AddWithValue("@rfidnumber", rfidnumber.Text.Trim)
                        .Parameters.AddWithValue("@firstname", txtfirstname.Text.Trim)
                        .Parameters.AddWithValue("@middlename", txtmiddlename.Text.Trim)
                        .Parameters.AddWithValue("@lastname", txtlastname.Text.Trim)
                        .Parameters.AddWithValue("@departmentID", depID)
                        .Parameters.AddWithValue("@positionID", selectedposID)
                        .Parameters.AddWithValue("@status", cbstatus.Text)
                        .Parameters.AddWithValue("@employeeID", employeeID)
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With

                    'Update Salary
                    RunCommand("Update tblsalary set salary=@salary, type=@type WHERE employeeID=@employeeID")
                    With com
                        .Parameters.AddWithValue("@employeeID", employeeID)
                        .Parameters.AddWithValue("@salary", txtsalary.Text.Trim)
                        .Parameters.AddWithValue("@type", If(FrmEmployee.RBDaily.Checked = True, "Daily", "Monthly"))
                        .ExecuteNonQuery()
                        .Parameters.Clear()

                    End With
                    'Insert Voluntary Contribution
                    For Each row As DataGridViewRow In FrmEmployee.DGVoluntary.Rows
                        Dim volID As Integer = row.Cells("voluntaryID").Value
                        Dim amount As Decimal = If(String.IsNullOrEmpty(row.Cells("amount").Value.ToString), 0, row.Cells("amount").Value)

                        RunCommand("Insert into tblempvoluntary (employeeID,voluntaryID,amount) VALUES (@employeeID,@voluntaryID,@amount)
                                        ON DUPLICATE KEY UPDATE amount=@amount")
                        With com
                            .Parameters.AddWithValue("@employeeID", employeeID)
                            .Parameters.AddWithValue("@voluntaryID", volID)
                            .Parameters.AddWithValue("@amount", amount)
                            .ExecuteNonQuery()
                            .Parameters.Clear()
                        End With
                    Next


                    'Check if may schedule
                    RunQuery("Select * from tblschedule where employeeID = '" & employeeID & "'")
                    If ds.Tables("querytable").Rows.Count > 0 Then
                        GetDailyWageOfMonthlyEmployees(employeeID)
                    End If

                    'Remove from department head list
                    RunCommand("Update tbldepartmenthead SET employeeID = 0 WHERE employeeID = '" & employeeID & "'")
                    With com
                        .ExecuteNonQuery()
                        .Parameters.Clear()
                    End With
                    MsgBox("Saved")
                End If
            End If
        End If

        FrmEmployee.TCEmployee.SelectedTab = FrmEmployee.TPEmployeeList
        employeeID = 0
        rfidnumber.Clear()
        txtlastname.Clear()
        txtfirstname.Clear()
        txtmiddlename.Clear()
        cbdept.SelectedIndex = -1
        cbpos.SelectedIndex = -1
        FrmEmployee.TxtSalary.Clear()
        FrmEmployee.RBDaily.Checked = True
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Exit Sub
        'End Try
    End Sub

    Public Shared Sub GetDailyWageOfMonthlyEmployees(id As Integer)
        Try
            Dim selectedemployeeID As Integer = id
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class
