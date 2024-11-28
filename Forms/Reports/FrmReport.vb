Imports MySql.Data.MySqlClient
Public Class FrmReport
    Private Sub BtnEmployeeGenerate_Click(sender As Object, e As EventArgs) Handles BtnEmployeeGenerate.Click
        Try
            If CbStatus.SelectedIndex = -1 Then
                MsgBox("Please select category")
                Exit Sub
            End If

            dt = New DataTable("DT_EmployeeList")
            dt.Clear()
            Dim status As String
            If CbStatus.SelectedIndex = 0 Then
                adp = New MySqlDataAdapter("Select e.employeeNumber, e.rfidnumber, CONCAT(e.firstname,' ',e.middlename,' ',e.lastname) as fullname, d.departmentName, p.positionName, e.status from tblemployee e
                                        LEFT JOIN tbldepartment d on d.departmentID = e.departmentID
                                        LEFT JOIN tblposition p on p.positionID = e.positionID
                                        ORDER by e.employeeNumber", conn)
            ElseIf CbStatus.SelectedIndex = 1 Then
                status = "Regular"
                adp = New MySqlDataAdapter("Select e.employeeNumber, e.rfidnumber, CONCAT(e.firstname,' ',e.middlename,' ',e.lastname) as fullname, d.departmentName, p.positionName, e.status from tblemployee e
                                    LEFT JOIN tbldepartment d on d.departmentID = e.departmentID
                                    LEFT JOIN tblposition p on p.positionID = e.positionID
                                    where e.status = '" & status & "' ORDER by e.employeeNumber", conn)
            ElseIf CbStatus.SelectedIndex = 2 Then
                status = "Probationary"
                adp = New MySqlDataAdapter("Select e.employeeNumber, e.rfidnumber, CONCAT(e.firstname,' ',e.middlename,' ',e.lastname) as fullname, d.departmentName, p.positionName, e.status from tblemployee e
                                    LEFT JOIN tbldepartment d on d.departmentID = e.departmentID
                                    LEFT JOIN tblposition p on p.positionID = e.positionID
                                    where e.status = '" & status & "' ORDER by e.employeeNumber", conn)
            Else
                status = "Resigned"
                adp = New MySqlDataAdapter("Select e.employeeNumber, e.rfidnumber, CONCAT(e.firstname,' ',e.middlename,' ',e.lastname) as fullname, d.departmentName, p.positionName, e.status from tblemployee e
                                    LEFT JOIN tbldepartment d on d.departmentID = e.departmentID
                                    LEFT JOIN tblposition p on p.positionID = e.positionID
                                    where e.status = '" & status & "' ORDER by e.employeeNumber", conn)

            End If

            adp.Fill(dt)

            Dim crystal As New CREmployeeList
            crystal.SetDataSource(dt)
            FrmPrinting.CRVPrinting.ReportSource = crystal
            FrmPrinting.Show()
            FrmMain.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnAttendanceGenerate_Click(sender As Object, e As EventArgs) Handles BtnAttendanceGenerate.Click
        Try
            If DtpFrom.Value > DtpTo.Value Then
                MsgBox("Invalid date range")
                Exit Sub
            End If

            dt = New DataTable("DT_Attendance")
            dt.Clear()

            Dim rangefrom As String = Format(DtpFrom.Value, "MMM-dd-yyyy")
            Dim rangeto As String = Format(DtpTo.Value, "MMM-dd-yyyy")
            Dim datefrom As String = Format(DtpFrom.Value, "yyyy-MM-dd")
            Dim dateto As String = Format(DtpTo.Value, "yyyy-MM-dd")
            adp = New MySqlDataAdapter("WITH RECURSIVE date_range AS (
                SELECT '" & datefrom & "' AS date
                UNION
                SELECT DATE_ADD(date, INTERVAL 1 DAY)
                FROM date_range
                WHERE date < '" & dateto & "'
                )
                SELECT DISTINCT
                e.employeeNumber,
                CONCAT(e.firstname,' ',e.middlename,' ',e.lastname) as fullname,
                dep.departmentName,
                dr.date,
                IF(att.login is null,'No Record',TIME(att.login)) as login,
                IF(att.logout is null,'No Record',TIME(att.logout)) as logout,
                '" & rangefrom & "' as datefrom,
                '" & rangeto & "' as dateto,
                att.report as report
                
                FROM date_range dr
                JOIN tblattendance att ON att.date = dr.date
                JOIN tblemployee e on e.employeeID = att.employeeID
                JOIN tbldepartment dep on dep.departmentID = e.departmentID
                ORDER BY dr.date DESC;
               ", conn)


            adp.Fill(dt)

            Dim crystal As New CRAttendance
            crystal.SetDataSource(dt)
            FrmPrinting.CRVPrinting.ReportSource = crystal
            FrmPrinting.Show()
            FrmMain.Enabled = False
        Catch ex As Exception

        End Try


    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles BtnDepartment.Click
        Try
            dt = New DataTable("DT_Department")
            dt.Clear()

            adp = New MySqlDataAdapter("SELECT 
                CONCAT(eh.firstname, ' ', eh.middlename, ' ', eh.lastname) AS fullname,
                d.departmentName,
                COUNT(e.employeeID) AS noofemployees
                FROM 
                tbldepartmenthead dh
                JOIN 
                tbldepartment d ON dh.departmentID = d.departmentID
                JOIN 
                tblemployee eh ON dh.employeeID = eh.employeeID
                LEFT JOIN 
                tblemployee e ON d.departmentID = e.departmentID
                GROUP BY 
                fullname, d.departmentName;
                ", conn)
            adp.Fill(dt)


            Dim crystal As New CRDepartmentList
            crystal.SetDataSource(dt)
            FrmPrinting.CRVPrinting.ReportSource = crystal
            FrmPrinting.Show()
            FrmMain.Enabled = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CbReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbReport.SelectedIndexChanged
        If CbReport.SelectedIndex = -1 Then
            PanelAttendance.Visible = False
            PanelDepartment.Visible = False
            PanelEmployeeList.Visible = False
        ElseIf CbReport.SelectedIndex = 0 Then
            PanelEmployeeList.Visible = True
            PanelAttendance.Visible = False
            PanelDepartment.Visible = False
        ElseIf CbReport.SelectedIndex = 1 Then
            PanelEmployeeList.Visible = False
            PanelAttendance.Visible = True
            PanelDepartment.Visible = False
        Else
            PanelEmployeeList.Visible = False
            PanelAttendance.Visible = False
            PanelDepartment.Visible = True
        End If
    End Sub

    Private Sub FrmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenServerConnection()
        CbReport.SelectedIndex = -1

    End Sub
End Class