Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms
Public Class ClassEmployee
    Public Shared employeeID As Integer

    Public Shared Sub LoadEmployee(dg As DataGridView)
        Try
            RunQuery("Select a.employeeID,a.employeeNumber,a.rfidnumber,a.lastname,a.firstname,a.middlename,b.departmentName,c.positionName,a.status from tblemployee a
                      LEFT JOIN tbldepartment b on b.departmentID = a.departmentID
                      LEFT JOIN tblposition c on c.positionID = a.positionID")
            dg.DataSource = ds.Tables("querytable")
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadDepartment(cb As Guna2ComboBox)
        Try
            RunQuery("Select * from tbldepartment")
            cb.ValueMember = "departmentID"
            cb.DisplayMember = "departmentName"
            cb.DataSource = ds.Tables("querytable")
            cb.SelectedIndex = -1
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

        End Try
    End Sub

    Public Shared Sub SelectEmployee(dg As Guna2DataGridView, txtrfid As Guna2TextBox, txtfirstname As Guna2TextBox, txtmiddlename As Guna2TextBox, txtlastname As Guna2TextBox, cbdept As Guna2ComboBox, cbpos As Guna2ComboBox)
        Try
            If dg.SelectedRows.Count > 0 Then
                employeeID = dg.SelectedRows(0).Cells(0).Value
                txtrfid.Text = dg.SelectedRows(0).Cells(2).Value
                txtfirstname.Text = dg.SelectedRows(0).Cells(3).Value
                txtmiddlename.Text = dg.SelectedRows(0).Cells(4).Value
                txtlastname.Text = dg.SelectedRows(0).Cells(5).Value
                cbdept.Text = dg.SelectedRows(0).Cells(6).Value
                cbpos.Text = dg.SelectedRows(0).Cells(7).Value
                MsgBox(employeeID)
                FrmEmployee.TCEmployee.SelectedTab = FrmEmployee.TPEmployeeProfile

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub NewEmployee(rfidnumber As Guna2TextBox, txtlastname As Guna2TextBox, txtfirstname As Guna2TextBox, txtmiddlename As Guna2TextBox, cbdept As Guna2ComboBox, cbpos As Guna2ComboBox)
        Try
            Dim employeenumber As Integer
            If employeeID = 0 Then

                RunQuery("Select * from tblemployee")
                If ds.Tables("querytable").Rows.Count > 0 Then
                    employeenumber = ds.Tables("querytable").Rows(0)(1) + 1

                Else
                    Dim year = Now.Year
                    employeenumber = year & "00001"
                End If
                MsgBox(employeenumber)
                RunCommand("Insert into tblemployee (employeeNumber,rfidnumber,lastname,firstname,middlename,departmentID,positionID,status) VALUES
                        (@employeeNumber,@rfidnumber,@lastname,@firstname,@middlename,@departmentID,@positionID,'Active')")


            Else
                RunCommand("Update tblemployee SET rfidnumber=@rfidnumber,lastname=@lastname,firstname=@firstname,middlename=@middlename,
                        departmentID=@departmentID,positionID=@positionID WHERE employeeID=@employeeID")

            End If

            With com
                .Parameters.AddWithValue("@employeeID", employeeID)
                .Parameters.AddWithValue("@employeeNumber", employeenumber)
                .Parameters.AddWithValue("@rfidnumber", rfidnumber.Text)
                .Parameters.AddWithValue("@lastname", txtlastname.Text)
                .Parameters.AddWithValue("@firstname", txtfirstname.Text)
                .Parameters.AddWithValue("@middlename", txtmiddlename.Text)
                .Parameters.AddWithValue("@departmentID", cbdept.SelectedValue)
                .Parameters.AddWithValue("@positionID", cbpos.SelectedValue)
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With

            MsgBox("Employee Saved")
            FrmEmployee.TCEmployee.SelectedTab = FrmEmployee.TPEmployeeList

            rfidnumber.Clear()
            txtlastname.Clear()
            txtfirstname.Clear()
            txtmiddlename.Clear()
            cbdept.SelectedIndex = -1
            cbpos.SelectedIndex = -1

        Catch ex As Exception

        End Try

    End Sub
End Class
