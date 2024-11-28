Imports Guna.UI2.WinForms
Public Class ClassDepartment

    Public Shared Sub LoadDepartmentDG(dg As Guna2DataGridView)
        Try
            RunQuery("SELECT 
                     a.departmentID, 
                     a.departmentName, 
                     CONCAT(c.firstname, ' ', c.middlename, ' ', c.lastname) AS departmentHead,
                     (SELECT COUNT(*) 
                     FROM tblemployee e 
                     WHERE e.departmentID = a.departmentID and e.status != 'Resigned') AS departmentPopulation,
                     a.status 
                     FROM 
                     tbldepartment a
                     LEFT JOIN 
                     tbldepartmenthead b ON b.departmentID = a.departmentID
                     LEFT JOIN 
                     tblemployee c ON c.employeeID = b.employeeID
                     WHERE a.status != 'Resigned'
                     GROUP BY 
                     a.departmentID, a.departmentName, departmentHead, a.status")
            dg.DataSource = ds.Tables("querytable")
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadDepartmentHead(cb As Guna2ComboBox, cbdep As Guna2ComboBox)
        Try
            Dim deptid As Integer = cbdep.SelectedValue
            RunQuery("Select a.employeeID, CONCAT(a.firstname,' ',a.middlename,' ',a.lastname) as fullname from tblemployee a 
                      where status ='Regular' and departmentID = '" & deptid & "'")
            cb.DisplayMember = "fullname"
            cb.ValueMember = "employeeID"
            cb.DataSource = ds.Tables("querytable")
            cb.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadDepartment(cb As Guna2ComboBox)
        Try
            RunQuery("Select * from tbldepartment where status='Active'")
            cb.ValueMember = "departmentID"
            cb.DisplayMember = "departmentName"
            cb.DataSource = ds.Tables("querytable")
            cb.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub SaveDepartmentHead(dg As Guna2DataGridView)
        Try
            Dim deptID As Integer = FrmDepartmentControls.CbDepartment.SelectedValue
            Dim empID As Integer = FrmDepartmentControls.CbDepartmentHead.SelectedValue

            RunQuery("Select * from tblposition WHERE departmentID = '" & deptID & "' and positionName = 'Department Head'")
            Dim posID As Integer = ds.Tables("querytable").Rows(0)(0)


            RunCommand("Update tblemployee SET positionID = '0' WHERE positionID = '" & posID & "'")
            With com
                .ExecuteNonQuery()
            End With

            RunCommand("Insert into tbldepartmenthead (departmentID,employeeID) VALUES (@departmentID,@employeeID)
                        ON DUPLICATE KEY UPDATE employeeID=@employeeID")
            With com
                .Parameters.AddWithValue("@departmentID", deptID)
                .Parameters.AddWithValue("@employeeID", empID)
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With

            RunCommand("Update tblemployee SET departmentID=@departmentID,positionID=@posID WHERE employeeID=@empID")
            With com
                .Parameters.AddWithValue("@departmentID", deptID)
                .Parameters.AddWithValue("@posID", posID)
                .Parameters.AddWithValue("@empID", empID)
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With

            MsgBox("Saved", MsgBoxStyle.OkOnly)
            FrmDepartmentControls.TCDepartment.SelectedTab = FrmDepartmentControls.TPDepartmentList
            LoadDepartmentDG(dg)
            Auditing($"{FrmMain.LblName.Text} set {FrmDepartmentControls.CbDepartmentHead.Text} as Department Head in {FrmDepartmentControls.CbDepartment.Text}")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
