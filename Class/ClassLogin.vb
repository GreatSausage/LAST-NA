Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms
Public Class ClassLogin
    Public Shared usersid As Integer
    Public Shared Sub LoginNa(login As Form, txtusername As Guna2TextBox, txtpassword As Guna2TextBox)
        Try
            Dim username As String = txtusername.Text.Trim
            Dim password As String = txtpassword.Text.Trim

            RunQuery("Select * from tblusers where username='" & username & "' and password is null")
            If ds.Tables("querytable").Rows.Count > 0 Then
                MsgBox("Please update your password first")
                FrmSignUpPayroll.Show()
                FrmSignUpPayroll.TxtUsername.Text = txtusername.Text.Trim
                Exit Sub
            End If


            RunQuery("Select * from tblusers where username= '" & username & "' and password='" & password & "' and status = 'Active'")
            If ds.Tables("querytable").Rows.Count > 0 Then
                usersid = ds.Tables("querytable").Rows(0)(0)
                Dim adminname As String = ds.Tables("querytable").Rows(0)(1) & " " & ds.Tables("querytable").Rows(0)(2)
                Dim role As String = ds.Tables("querytable").Rows(0)("role")

                RunQuery("Select logged from tblusers where username = '" & username & "' and password ='" & password & "'")
                Dim logged As String = ds.Tables("querytable").Rows(0)(0)
                If logged = "Yes" Then
                    MsgBox("Already logged in")
                    Exit Sub
                Else
                    RunCommand("Update tblusers set logged='Yes' where username = '" & username & "' and password = '" & password & "'")
                    com.ExecuteNonQuery()
                End If

                If role = "Admin" Then
                    FrmMain.Show()
                    FrmMain.LblName.Text = adminname
                    DisplayFormPanel(FrmMainte, FrmMain.displaypanel)
                    login.Close()
                    Exit Sub
                ElseIf role = "Attendance" Then
                    FrmAttendance.Show()
                    login.Close()
                    Exit Sub
                Else
                    FrmMain.Show()
                    FrmMain.LblName.Text = adminname
                    FrmMain.LblPos.Text = role
                    FrmMain.BtnMaintenance.Visible = False
                    FrmMain.Guna2Button3.Visible = False
                    FrmMain.Guna2Button14.Visible = False
                    FrmMain.BtnAudit.Visible = False
                    DisplayFormPanel(FrmEmployee, FrmMain.displaypanel)
                    login.Close()
                    Exit Sub
                End If
            End If


            RunQuery("Select * from tblemployee WHERE employeeNumber = '" & username & "' and password is null and status != 'Resigned'")
            If ds.Tables("querytable").Rows.Count > 0 Then
                MsgBox("Please set password first")
                FrmSignUpEmployee.Show()
                FrmSignUpEmployee.TxtUsername.Text = username
                login.Close()
                Exit Sub
            End If

            RunQuery("Select * from tblemployee WHERE employeeNumber = '" & username & "' and password = '" & password & "' and status != 'Resigned'")
            If ds.Tables("querytable").Rows.Count > 0 Then

                Dim employeeID As Integer = ds.Tables("querytable").Rows(0)(0)
                Dim empname As String = ds.Tables("querytable").Rows(0)(3) & " " & ds.Tables("querytable").Rows(0)(4) & " " & ds.Tables("querytable").Rows(0)(5)

                RunQuery("Select logged from tblemployee where employeeNumber = '" & username & "' and password ='" & password & "'")
                Dim logged As String = ds.Tables("querytable").Rows(0)(0)
                If logged = "Yes" Then
                    MsgBox("Already logged in")
                    Exit Sub
                Else
                    RunCommand("Update tblemployee set logged='Yes' where employeeNumber = '" & username & "' and password = '" & password & "'")
                    com.ExecuteNonQuery()
                End If

                RunQuery("Select IF(b.positionID = 0,'Department Head',a.positionName) as posname from tblposition a right JOIN tblemployee b on b.positionID = a.positionID where b.employeeID = '" & employeeID & "'")
                If ds.Tables("querytable").Rows.Count > 0 Then
                    Dim posname As String = ds.Tables("querytable").Rows(0)(0)

                    'Check if Department head
                    RunQuery("Select * from tbldepartmenthead where employeeID = '" & employeeID & "'")
                    If ds.Tables("querytable").Rows.Count > 0 Then
                        ClassDepartmentHeadControls.employeeID = employeeID
                        FrmDepartmentHeadControls.Show()
                        FrmDepartmentHeadControls.LblName.Text = empname
                        FrmDepartmentHeadControls.LblPosition.Text = posname
                        login.Close()
                        Exit Sub

                    Else
                        ClassAssociates.employeeID = employeeID
                        FrmAssociate.Show()
                        FrmAssociate.LblName.Text = empname
                        FrmAssociate.LblPosition.Text = posname
                        login.Close()
                        Exit Sub
                    End If
                End If

            Else
                MsgBox("Please check username or password", MsgBoxStyle.Critical)
                txtpassword.Clear()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub SetToLoggedOutUsers()
        Try
            RunCommand("Update tblusers SET logged='No' where userID = '" & usersid & "'")
            com.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub SetToLoggedOutEmployees(id As Integer)
        Try
            RunCommand("Update tblemployee SET logged='No' where employeeID = '" & id & "'")
            com.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

End Class
