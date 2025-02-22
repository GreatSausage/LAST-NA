Imports Guna.UI2.WinForms
Public Class ClassPayrollCalculation
    Shared noofdays As Integer = 0
    Shared NightDiffRate As Decimal = 0
    Shared OtRegularRate As Decimal = 0
    Shared OtSpecialRate As Decimal = 0
    Shared RestDayRate As Decimal = 0
    Shared SpecialHolidayRate As Decimal = 0
    Shared RegularHolidayRate As Decimal = 0
    Shared DoubleHolidayRate As Decimal = 0

    Shared compensationtype As String
    Shared employmentstatus As String
    Shared payrollperiodID As Integer
    Shared isPayout As String

    Shared dateto As String
    Shared datefrom As String

    Public Shared hasschedule As Boolean
#Region "Payroll Period"
    Public Shared Sub NewPayrollPeriod(payrollperiodname As Guna2TextBox, dtpfrom As Guna2DateTimePicker, dtpto As Guna2DateTimePicker, rb As RadioButton)
        Try
            RunCommand("Insert into tblpayrollperiod (payrollperiodname,datefrom,dateto,payout,released) VALUES (@payrollperiodname,@datefrom,@dateto,@payout,'Not Released')")
            With com
                .Parameters.AddWithValue("@payrollperiodname", payrollperiodname.Text.Trim)
                .Parameters.AddWithValue("@datefrom", dtpfrom.Value.Date)
                .Parameters.AddWithValue("@dateto", dtpto.Value.Date)
                .Parameters.AddWithValue("@payout", If(rb.Checked = True, "Yes", "No"))
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
            MsgBox("Saved", MsgBoxStyle.OkOnly)
            payrollperiodname.Clear()
            dtpfrom.Value = Now.Date
            dtpto.Value = Now.Date
            rb.Checked = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Public Shared Sub LoadPayrollPeriod(dg As DataGridView)
        Try
            RunQuery("Select * from tblpayrollperiod")
            If ds.Tables("querytable").Rows.Count > 0 Then
                dg.DataSource = ds.Tables("querytable")

                ' Check if the button column already exists to avoid duplication
                If dg.Columns("btnRelease") Is Nothing Then
                    ' Add a new button column
                    Dim btnColumn As New DataGridViewButtonColumn()
                    btnColumn.Name = "btnRelease"
                    btnColumn.HeaderText = "Action"
                    btnColumn.Text = "Release"
                    btnColumn.UseColumnTextForButtonValue = True ' Makes the button display the text
                    dg.Columns.Add(btnColumn)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadPayrollPeriodCB(cb As Guna2ComboBox)
        Try
            RunQuery("Select * from tblpayrollperiod")
            cb.DataSource = ds.Tables("querytable")
            cb.ValueMember = "payrollperiodID"
            cb.DisplayMember = "payrollperiodname"
            cb.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub RefreshPayrollPeriodCB(cb As Guna2ComboBox)
        Try
            Dim itemcount As Integer = cb.Items.Count
            RunQuery("Select * from tblpayrollperiod")
            Dim rowcount As Integer = ds.Tables("querytable").Rows.Count

            If itemcount <> rowcount Then
                LoadPayrollPeriodCB(cb)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub SelectPayrollPeriod(cb As Guna2ComboBox, txtfrom As Guna2TextBox, txtto As Guna2TextBox, txtpayout As Guna2TextBox)
        Try
            If cb.SelectedIndex = -1 Then
                txtfrom.Clear()
                txtto.Clear()
                txtpayout.Clear()
                Exit Sub
            End If

            Dim payrollperiodID As Integer = cb.SelectedValue
            RunQuery("Select * from tblpayrollperiod where payrollperiodID = '" & payrollperiodID & "'")
            txtfrom.Text = Format(ds.Tables("querytable").Rows(0)(2), "yyyy-MM-dd")
            txtto.Text = Format(ds.Tables("querytable").Rows(0)(3), "yyyy-MM-dd")
            txtpayout.Text = ds.Tables("querytable").Rows(0)(4)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub UsePayrollPeriod(cb As Guna2ComboBox, txtpayrollperiod As Guna2TextBox, txtfrom As Guna2TextBox, txtto As Guna2TextBox, txtpayout As Guna2TextBox)
        Try
            If cb.SelectedIndex = -1 Then
                Exit Sub
            End If
            payrollperiodID = cb.SelectedValue
            txtpayrollperiod.Text = cb.Text
            isPayout = txtpayout.Text
            datefrom = txtfrom.Text
            dateto = txtto.Text

        Catch ex As Exception

        End Try
    End Sub
#End Region
    Public Shared Sub EmployeeStatus(cb As Guna2ComboBox)
        Try
            Dim employeeID As Integer = cb.SelectedValue
            RunQuery("Select status from tblemployee where employeeID = '" & employeeID & "'")
            If ds.Tables("querytable").Rows.Count > 0 Then
                employmentstatus = ds.Tables("querytable").Rows(0)(0)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub EmployeeCompensationType(cb As Guna2ComboBox)
        Try
            Dim employeeID As Integer = cb.SelectedValue
            RunQuery("Select type from tblsalary where employeeID = '" & employeeID & "'")
            If ds.Tables("querytable").Rows.Count > 0 Then
                compensationtype = ds.Tables("querytable").Rows(0)(0)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub GetRates()
        Try
            RunQuery("Select rate from tblrates")
            If ds.Tables("querytable").Rows.Count > 0 Then
                NightDiffRate = If(IsDBNull(ds.Tables("querytable").Rows(0)(0)), 0, ds.Tables("querytable").Rows(0)(0) / 100)
                OtRegularRate = If(IsDBNull(ds.Tables("querytable").Rows(1)(0)), 0, ds.Tables("querytable").Rows(1)(0) / 100)
                OtSpecialRate = If(IsDBNull(ds.Tables("querytable").Rows(2)(0)), 0, ds.Tables("querytable").Rows(2)(0) / 100)
                RestDayRate = If(IsDBNull(ds.Tables("querytable").Rows(3)(0)), 0, ds.Tables("querytable").Rows(3)(0) / 100)
                SpecialHolidayRate = If(IsDBNull(ds.Tables("querytable").Rows(4)(0)), 0, ds.Tables("querytable").Rows(4)(0) / 100)
                RegularHolidayRate = If(IsDBNull(ds.Tables("querytable").Rows(5)(0)), 0, ds.Tables("querytable").Rows(5)(0) / 100)
                DoubleHolidayRate = If(IsDBNull(ds.Tables("querytable").Rows(6)(0)), 0, ds.Tables("querytable").Rows(6)(0) / 100)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadEmployees(cbemployee As Guna2ComboBox)
        Try
            RunQuery("SELECT e.employeeID, CONCAT(e.firstname, ' ', e.middlename, ' ', e.lastname) AS fullname
                      FROM tblemployee e
                      WHERE e.employeeID NOT IN (
                      SELECT p.employeeID
                      FROM tblpayroll p
                      WHERE p.payrollperiodID = '" & payrollperiodID & "')")
            If ds.Tables.Contains("querytable") AndAlso ds.Tables("querytable").Rows.Count > 0 Then
                cbemployee.ValueMember = "employeeID"
                cbemployee.DisplayMember = "fullname"
                cbemployee.DataSource = ds.Tables("querytable")
                cbemployee.SelectedIndex = -1
            Else
                ' Handle empty data source
                cbemployee.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub LoadIncentive(dg As Guna2DataGridView)
        Try
            RunQuery("Select incentiveID, incentiveName from tblincentives where status='Active'")
            If isPayout = "Yes" Then
                dg.DataSource = ds.Tables("querytable")
            Else
                ds.Tables("querytable").Rows.Clear()
                dg.DataSource = ds.Tables("querytable")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadAllowance(dg As Guna2DataGridView, cbEmp As Guna2ComboBox)
        Try
            Dim employeeID As Integer = cbEmp.SelectedValue
            If employeeID = 0 Then
                Exit Sub
            End If
            RunQuery("Select positionID from tblemployee WHERE employeeID = '" & employeeID & "'")
            Dim positionID As Integer = ds.Tables("querytable").Rows(0)(0)

            RunQuery("Select a.allowanceID, b.allowanceName, a.amount from tbljoballowance a
                  LEFT JOIN tblallowance b on b.allowanceID = a.allowanceID
                  WHERE positionID = '" & positionID & "'")
            If isPayout = "Yes" Then
                dg.DataSource = ds.Tables("querytable")
            Else
                ds.Tables("querytable").Rows.Clear()
                dg.DataSource = ds.Tables("querytable")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadVoluntary(dg As Guna2DataGridView, cbemp As Guna2ComboBox)
        Try
            Dim employeeID As Integer = cbemp.SelectedValue
            RunQuery("Select a.voluntaryID, b.name, a.amount from tblempvoluntary a
                      LEFT JOIN tblvoluntary b on b.voluntaryID = a.voluntaryID
                      WHERE a.employeeID='" & employeeID & "'")
            If isPayout = "Yes" Then
                dg.DataSource = ds.Tables("querytable")
            Else
                ds.Tables("querytable").Rows.Clear()
                dg.DataSource = ds.Tables("querytable")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadAttendance(dg As Guna2DataGridView, cbemp As Guna2ComboBox)
        Try
            If cbemp.SelectedIndex = -1 Then
                dg.DataSource = Nothing
                Exit Sub
            End If

            Dim employeeID As Integer = cbemp.SelectedValue

            RunQuery("WITH RECURSIVE date_range AS (
                SELECT '" & datefrom & "' AS date
                UNION
                SELECT DATE_ADD(date, INTERVAL 1 DAY)
                FROM date_range
                WHERE date < '" & dateto & "'
                )
                SELECT DISTINCT
                dr.date,
                att.login,
                att.logout,

                CASE
                    WHEN att.logout > CONCAT(dr.date, ' ', ts.timeout)
                    THEN FLOOR(TIME_TO_SEC(TIMEDIFF(att.logout, CONCAT(dr.date, ' ', ts.timeout))) / 3600)
                    ELSE 0
                END AS overtime,

                ot.remarks as otremark,

                CASE
                    WHEN att.login > CONCAT(dr.date, ' ', ts.timein)
                    THEN FLOOR(TIME_TO_SEC(TIMEDIFF(att.login, CONCAT(dr.date, ' ', ts.timein))) / 60)
                    ELSE 0
                END AS late,

                CASE
                    WHEN att.logout < CONCAT(dr.date, ' ', ts.timeout)
                    THEN FLOOR(TIME_TO_SEC(TIMEDIFF(CONCAT(dr.date, ' ', ts.timeout), att.logout)) / 60)
                    ELSE 0
                END AS undertime,

                CASE
                    WHEN att.logout >= CONCAT(dr.date, ' ', '23:00:00') 
                    THEN FLOOR(TIME_TO_SEC(TIMEDIFF(att.logout, CONCAT(dr.date, ' ', '22:00:00'))) / 3600)
                    ELSE 0
                END AS nightdifferential,

                IF(att.report IS NULL, 'Absent', att.report) AS report,

                IF(h.classification IS NULL, 'No Holiday', h.classification) AS classification,

                sc.remark AS dayremark

                FROM date_range dr
                LEFT JOIN tblattendance att ON att.date = dr.date AND att.employeeID = '" & employeeID & "'
                LEFT JOIN tbltimeschedule ts ON ts.employeeID = att.employeeID
                LEFT JOIN tblschedule sc ON sc.employeeID = '" & employeeID & "' AND sc.day = DAYNAME(dr.date)
                LEFT JOIN tblholiday h ON h.date = dr.date
                LEFT JOIN tblovertime ot on ot.attendanceID = att.attendanceID
                ORDER BY dr.date ASC;
                ")
            If ds.Tables("querytable").Rows.Count > 0 Then
                dg.DataSource = ds.Tables("querytable")
            Else

            End If

            hasschedule = True
            RunQuery("Select * from tbltimeschedule WHERE employeeID = '" & employeeID & "'")
            If ds.Tables("querytable").Rows.Count = 0 Then
                MsgBox("No schedule set to the employee yet")
                hasschedule = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub GetGrossPay(cbemp As Guna2ComboBox, dg As Guna2DataGridView, txtgrosspay As Guna2TextBox)
        Try
            Dim employeeID As Integer = cbemp.SelectedValue
            If employeeID = 0 Then
                Exit Sub
            End If

            RunQuery("Select salary,daily from tblsalary WHERE employeeID='" & employeeID & "'")
            Dim salary As Decimal = ds.Tables("querytable").Rows(0)(0)
            Dim daily As Decimal = ds.Tables("querytable").Rows(0)(1)


            If compensationtype = "Daily" Then
                Dim totalpay As Decimal = 0
                For Each row As DataGridViewRow In dg.Rows
                    Dim dayclass As String = row.Cells("colClassification").Value
                    Dim holiday As String = row.Cells("colHoliday").Value
                    Dim recordentry As String = row.Cells("colReport").Value
                    'Regular Working Day
                    If dayclass = "With Duty" And holiday = "No Holiday" And recordentry = "Present" Then
                        totalpay += salary
                    End If

                    'Regular Working Day Pero naka Leave
                    If employmentstatus = "Regular" And dayclass = "With Duty" And holiday = "No Holiday" And recordentry = "On Leave" Then
                        totalpay += salary
                    End If

                    'Special Holiday Pumasok
                    If dayclass = "With Duty" And holiday = "Special Holiday" And recordentry = "Present" Then
                        totalpay += (salary * SpecialHolidayRate)
                    End If

                    'Special Holiday Hindi Pumasok
                    If employmentstatus = "Regular" And dayclass = "With Duty" And holiday = "Special Holiday" And recordentry = "Absent" Then
                        totalpay += salary
                    End If

                    'Regular Holiday Pumasok
                    If dayclass = "With Duty" And holiday = "Regular Holiday" And recordentry = "Present" Then
                        totalpay += (salary * RegularHolidayRate)
                    End If

                    'Regular Holiday Hindi Pumasok
                    If employmentstatus = "Regular" And dayclass = "With Duty" And holiday = "Regular Holiday" And recordentry = "Absent" Then
                        totalpay += salary
                    End If

                    'Double Holiday Pumasok
                    If dayclass = "With Duty" And holiday = "Double Holiday" And recordentry = "Present" Then
                        totalpay += (salary * DoubleHolidayRate)
                    End If

                    'Double Holiday Hindi Pumasok
                    If dayclass = "With Duty" And holiday = "Double Holiday" And recordentry = "Absent" Then
                        totalpay += salary
                    End If

                    'Day Off Pumasok
                    If dayclass = "Day Off" And holiday = "No Holiday" And recordentry = "Present" Then
                        totalpay += (salary * RestDayRate)
                    End If

                    'Day Off and Special Holiday
                    If dayclass = "Day Off" And holiday = "Special Holiday" And recordentry = "Present" Then
                        totalpay += (salary * (RestDayRate * SpecialHolidayRate))
                    End If

                    'Day Off and Regular Holiday
                    If dayclass = "Day Off" And holiday = "Regular Holiday" And recordentry = "Present" Then
                        totalpay += (salary * (RestDayRate * RegularHolidayRate))
                    End If

                    'Day Off and Double Holiday
                    If dayclass = "Day Off" And holiday = "Double Holiday" And recordentry = "Present" Then
                        totalpay += (salary * (RestDayRate * DoubleHolidayRate))
                    End If
                Next
                txtgrosspay.Clear()
                txtgrosspay.Text = totalpay
            End If

            If compensationtype = "Monthly" Then
                Dim totalpay As Decimal = salary / 2
                For Each row As DataGridViewRow In dg.Rows
                    Dim dayclass As String = row.Cells("colClassification").Value
                    Dim holiday As String = row.Cells("colHoliday").Value
                    Dim recordentry As String = row.Cells("colReport").Value

                    'Regular Working Day
                    If dayclass = "With Duty" And holiday = "No Holiday" And recordentry = "Absent" Then
                        totalpay -= daily
                    End If

                    'Regular Working Day Pero naka Leave
                    If employmentstatus = "Probationary" And dayclass = "With Duty" And holiday = "No Holiday" And recordentry = "On Leave" Then
                        totalpay -= daily
                    End If

                    'Special Holiday Pumasok
                    If dayclass = "With Duty" And holiday = "Special Holiday" And recordentry = "Present" Then
                        totalpay += (daily * SpecialHolidayRate)
                    End If

                    'Special Holiday Hindi Pumasok
                    If employmentstatus = "Probationary" And dayclass = "With Duty" And holiday = "Special Holiday" And recordentry = "Absent" Then
                        totalpay -= daily
                    End If

                    'Regular Holiday Pumasok
                    If dayclass = "With Duty" And holiday = "Regular Holiday" And recordentry = "Present" Then
                        totalpay += (daily * RegularHolidayRate)
                    End If

                    'Regular Holiday Hindi Pumasok
                    If employmentstatus = "Regular" And dayclass = "With Duty" And holiday = "Regular Holiday" And recordentry = "Absent" Then
                        totalpay += daily
                    End If

                    'Double Holiday Pumasok
                    If dayclass = "With Duty" And holiday = "Double Holiday" And recordentry = "Present" Then
                        totalpay += (daily * DoubleHolidayRate)
                    End If

                    'Double Holiday Hindi Pumasok
                    If employmentstatus = "Regular" And dayclass = "With Duty" And holiday = "Double Holiday" And recordentry = "Absent" Then
                        totalpay += daily
                    End If

                    'Day Off Pumasok
                    If dayclass = "Day Off" And holiday = "No Holiday" And recordentry = "Present" Then
                        totalpay += (daily * RestDayRate)
                    End If

                    'Day Off and Special Holiday
                    If dayclass = "Day Off" And holiday = "Special Holiday" And recordentry = "Present" Then
                        totalpay += (daily * (RestDayRate * SpecialHolidayRate))
                    End If

                    'Day Off and Regular Holiday
                    If dayclass = "Day Off" And holiday = "Regular Holiday" And recordentry = "Present" Then
                        totalpay += (daily * (RestDayRate * RegularHolidayRate))
                    End If

                    'Day Off and Double Holiday
                    If dayclass = "Day Off" And holiday = "Double Holiday" And recordentry = "Present" Then
                        totalpay += (daily * (RestDayRate * DoubleHolidayRate))
                    End If

                Next
                txtgrosspay.Clear()
                txtgrosspay.Text = totalpay
            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Shared Sub GetOvertime(cbemp As Guna2ComboBox, dg As Guna2DataGridView, txtovertime As Guna2TextBox)
        Try
            Dim employeeID As Integer = cbemp.SelectedValue
            If employeeID = 0 Then
                Exit Sub
            End If
            RunQuery("Select daily from tblsalary WHERE employeeID='" & employeeID & "'")
            Dim daily As Decimal = ds.Tables("querytable").Rows(0)(0)



            RunQuery("Select noofhours from tbltimeschedule where employeeID= '" & employeeID & "'")
            Dim noofhours As Decimal = ds.Tables("querytable").Rows(0)(0)

            Dim hourlyrate As Decimal = daily / noofhours
            Dim totalot As Decimal = 0
            For Each row As DataGridViewRow In dg.Rows
                Dim otremarks As String = If(String.IsNullOrEmpty(row.Cells("colOtRemarks").Value.ToString), "For Approval", row.Cells("colOtRemarks").Value)
                Dim noofot As Integer = If(String.IsNullOrEmpty(row.Cells("colOvertime").Value.ToString), 0, row.Cells("colOvertime").Value)
                Dim dayclass As String = row.Cells("colClassification").Value
                Dim holiday As String = row.Cells("colHoliday").Value

                If otremarks = "Declined" Then
                    Continue For
                End If
                If noofot = 0 Then
                    Continue For
                End If


                If dayclass = "With Duty" And holiday = "No Holiday" Then
                    totalot += ((hourlyrate * OtRegularRate) * noofot)
                ElseIf dayclass = "With Duty" And holiday = "Special Holiday" Then
                    totalot += ((hourlyrate * SpecialHolidayRate) * OtSpecialRate) * noofot
                ElseIf dayclass = "With Duty" And holiday = "Regular Holiday" Then
                    totalot += ((hourlyrate * RegularHolidayRate) * OtSpecialRate) * noofot
                ElseIf dayclass = "With Duty" And holiday = "Double Holiday" Then
                    totalot += ((hourlyrate * DoubleHolidayRate) * OtSpecialRate) * noofot
                ElseIf dayclass = "Day Off" And holiday = "No Holiday" Then
                    totalot += ((hourlyrate * RestDayRate) * OtSpecialRate) * noofot
                ElseIf dayclass = "Day Off" And holiday = "Special Holiday" Then
                    totalot += (((hourlyrate * RestDayRate) * SpecialHolidayRate) * OtSpecialRate) * noofot
                ElseIf dayclass = "Day Off" And holiday = "Regular Holiday" Then
                    totalot += (((hourlyrate * RestDayRate) * RegularHolidayRate) * OtSpecialRate) * noofot
                ElseIf dayclass = "Day Off" And holiday = "Double Holiday" Then
                    totalot += (((hourlyrate * RestDayRate) * DoubleHolidayRate) * OtSpecialRate) * noofot
                End If
            Next
            txtovertime.Clear()
            txtovertime.Text = totalot
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub GetAllowance(dg As Guna2DataGridView, txtallowance As Guna2TextBox)
        Try
            If isPayout = "Yes" Then
                Dim totalallowance As Decimal
                For Each row As DataGridViewRow In dg.Rows
                    Dim allowanceamount As Decimal = row.Cells("allowanceAmount").Value
                    totalallowance += allowanceamount
                Next
                txtallowance.Clear()
                txtallowance.Text = totalallowance
            Else
                txtallowance.Text = "0"
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetIncentives(dg As Guna2DataGridView, txtincentives As Guna2TextBox)
        Try
            Dim totalincentive As Decimal
            For Each row As DataGridViewRow In dg.Rows
                Dim incentiveamount As Decimal = row.Cells("incentiveAmount").Value
                totalincentive += incentiveamount
            Next
            txtincentives.Clear()
            txtincentives.Text = totalincentive
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetVoluntaryContrib(dg As Guna2DataGridView, txtvoluntary As Guna2TextBox)
        Try
            Dim totalvoluntary As Decimal
            For Each row As DataGridViewRow In dg.Rows
                Dim voluntaryamount As Decimal = row.Cells("voluntaryAmount").Value
                totalvoluntary += voluntaryamount
            Next
            txtvoluntary.Clear()
            txtvoluntary.Text = totalvoluntary

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetLate(dg As Guna2DataGridView, txtlate As Guna2TextBox, cbemp As Guna2ComboBox)
        Try
            Dim employeeID As Integer = cbemp.SelectedValue
            If employeeID = 0 Then
                Exit Sub
            End If
            RunQuery("Select daily from tblsalary WHERE employeeID='" & employeeID & "'")
            Dim daily As Decimal = ds.Tables("querytable").Rows(0)(0)

            RunQuery("Select noofhours from tbltimeschedule where employeeID= '" & employeeID & "'")
            Dim noofhours As Decimal = ds.Tables("querytable").Rows(0)(0)

            Dim minuterate As Decimal = (daily / noofhours) / 60

            Dim totallate As Decimal
            For Each row As DataGridViewRow In dg.Rows
                Dim late As Decimal = row.Cells("colLate").Value
                totallate += late
            Next
            txtlate.Clear()
            txtlate.Text = totallate * minuterate
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetUndertime(dg As Guna2DataGridView, txtundertime As Guna2TextBox, cbemp As Guna2ComboBox)
        Try
            Dim employeeID As Integer = cbemp.SelectedValue
            If employeeID = 0 Then
                Exit Sub
            End If
            RunQuery("Select daily from tblsalary WHERE employeeID='" & employeeID & "'")
            Dim daily As Decimal = ds.Tables("querytable").Rows(0)(0)

            RunQuery("Select noofhours from tbltimeschedule where employeeID= '" & employeeID & "'")
            Dim noofhours As Decimal = ds.Tables("querytable").Rows(0)(0)

            Dim minuterate As Decimal = (daily / noofhours) / 60

            Dim totalundertime As Decimal
            For Each row As DataGridViewRow In dg.Rows
                Dim undertime As Decimal = row.Cells("colUndertime").Value
                totalundertime += undertime
            Next
            txtundertime.Clear()
            txtundertime.Text = totalundertime * minuterate

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetNightDifferential(dg As Guna2DataGridView, txtnightdifferential As Guna2TextBox, cbemp As Guna2ComboBox)
        Try
            Dim employeeID As Integer = cbemp.SelectedValue
            If employeeID = 0 Then
                Exit Sub
            End If
            RunQuery("Select daily from tblsalary WHERE employeeID='" & employeeID & "'")
            Dim daily As Decimal = ds.Tables("querytable").Rows(0)(0)

            RunQuery("Select noofhours from tbltimeschedule where employeeID= '" & employeeID & "'")
            Dim noofhours As Decimal = ds.Tables("querytable").Rows(0)(0)

            Dim hourlyrate As Decimal = daily / noofhours

            Dim nightdiffcount As Decimal
            For Each row As DataGridViewRow In dg.Rows
                Dim nightdiff As Decimal = row.Cells("colNightDifferential").Value
                nightdiffcount += nightdiff
            Next

            txtnightdifferential.Clear()
            txtnightdifferential.Text = (hourlyrate * NightDiffRate) * nightdiffcount

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetSSS(netpay As Guna2TextBox, sss As Guna2TextBox)
        Try
            If isPayout = "Yes" Then
                RunQuery("Select total from tblsss WHERE minSalary <= '" & netpay.Text & "' and maxsalary >= '" & netpay.Text & "'")
                sss.Clear()
                If ds.Tables("querytable").Rows.Count > 0 Then
                    Dim total As Decimal = ds.Tables("querytable").Rows(0)(0)
                    sss.Text = total

                Else
                    sss.Text = 0
                End If
            Else
                sss.Text = 0
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetPhilhealth(netpay As Guna2TextBox, philhealth As Guna2TextBox)
        Try
            If isPayout = "Yes" Then
                RunQuery("Select rate from tblphilhealth order by philhealthID DESC LIMIT 1")
                philhealth.Clear()
                If ds.Tables("querytable").Rows.Count > 0 Then
                    Dim rate As Decimal = ds.Tables("querytable").Rows(0)(0) / 100
                    philhealth.Text = Val(netpay.Text) * rate
                Else
                    philhealth.Text = 0
                End If
            Else
                philhealth.Text = 0
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetPagIbig(pagibig As Guna2TextBox)
        Try
            If isPayout = "Yes" Then
                RunQuery("Select rate from tblpagibig order by pagibigID DESC LIMIT 1")
                pagibig.Clear()
                If ds.Tables("querytable").Rows.Count > 0 Then
                    Dim rate As Decimal = ds.Tables("querytable").Rows(0)(0)
                    pagibig.Text = rate
                Else
                    pagibig.Text = 0
                End If
            Else
                pagibig.Text = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetTax(grosspay As Guna2TextBox, txttax As Guna2TextBox, txtsss As Guna2TextBox, txtphilhealth As Guna2TextBox, txtpagibig As Guna2TextBox)
        Try
            Dim taxableamount As Decimal = Val(grosspay.Text) - (Val(txtsss.Text) + Val(txtphilhealth.Text) + Val(txtpagibig.Text))
            RunQuery("Select * from tbltax WHERE minSalary <= '" & taxableamount & "' and maxSalary >= '" & taxableamount & "'")
            If ds.Tables("querytable").Rows.Count > 0 Then
                Dim minSalary As Decimal = ds.Tables("querytable").Rows(0)(1)
                Dim fixedamount As Decimal = ds.Tables("querytable").Rows(0)(3)
                Dim percent As Integer = ds.Tables("querytable").Rows(0)(4) / 100

                Dim taxpercent As Decimal = (taxableamount - minSalary) * percent
                Dim total = fixedamount + taxpercent

                txttax.Clear()
                txttax.Text = Val(total)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub TotalIncrease(txtot As Guna2TextBox, txtallowance As Guna2TextBox, txtincentives As Guna2TextBox, txtnightdiff As Guna2TextBox, txttotalincrease As Guna2TextBox)
        Try
            txttotalincrease.Text = Val(txtot.Text) + Val(txtallowance.Text) + Val(txtincentives.Text) + Val(txtnightdiff.Text)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub TotalMandatoryContri(txtsss As Guna2TextBox, txtphilhealth As Guna2TextBox, txtpagibig As Guna2TextBox, txttax As Guna2TextBox, txttotalmandatory As Guna2TextBox)
        Try
            txttotalmandatory.Text = Val(txtsss.Text) + Val(txtphilhealth.Text) + Val(txtpagibig.Text) + Val(txttax.Text)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub TotalDeductions(txtlate As Guna2TextBox, txtundertime As Guna2TextBox, txtvoluntary As Guna2TextBox, txttotalmandatory As Guna2TextBox, txttotaldeductions As Guna2TextBox)
        Try
            txttotaldeductions.Text = Val(txtlate.Text) + Val(txtundertime.Text) + Val(txtvoluntary.Text) + Val(txttotalmandatory.Text)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub GetNetPay(txtgrosspay As Guna2TextBox, txttotalincrease As Guna2TextBox, txttotaldeductions As Guna2TextBox, txtnetpay As Guna2TextBox)
        Try
            txtnetpay.Text = Val(txtgrosspay.Text) + Val(txttotalincrease.Text) - Val(txttotaldeductions.Text)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub SaveSalary(cb As Guna2ComboBox, txtot As Guna2TextBox, txtallowance As Guna2TextBox, txtincentives As Guna2TextBox, txtnightdiff As Guna2TextBox, txtlate As Guna2TextBox, txtundertime As Guna2TextBox, txtvoluntary As Guna2TextBox, txtsss As Guna2TextBox, txtphilhealth As Guna2TextBox, txtpagibig As Guna2TextBox, txttax As Guna2TextBox, txtmandatory As Guna2TextBox, txttotalincrease As Guna2TextBox, txttotaldeduc As Guna2TextBox, txtgrosspay As Guna2TextBox, txtnetpay As Guna2TextBox)
        Try
            Dim employeeID As Integer = cb.SelectedValue
            RunCommand("Insert into tblpayroll (employeeID,payrollperiodID,overtime,allowance,incentives,nightdifferential,late,undertime,voluntary,sss,philhealth,pagibig,tax,mandatory,totalincrease,totaldeduc,grosspay,netpay) VALUES
                        (@employeeID,@payrollperiodID,@overtime,@allowance,@incentives,@nightdifferential,@late,@undertime,@voluntary,@sss,@philhealth,@pagibig,@tax,@mandatory,@totalincrease,@totaldeduc,@grosspay,@netpay)")
            With com
                .Parameters.AddWithValue("@employeeID", employeeID)
                .Parameters.AddWithValue("@payrollperiodID", payrollperiodID)
                .Parameters.AddWithValue("@overtime", txtot.Text)
                .Parameters.AddWithValue("@allowance", txtallowance.Text)
                .Parameters.AddWithValue("@incentives", txtincentives.Text)
                .Parameters.AddWithValue("@nightdifferential", txtnightdiff.Text)
                .Parameters.AddWithValue("@late", txtlate.Text)
                .Parameters.AddWithValue("@undertime", txtundertime.Text)
                .Parameters.AddWithValue("@voluntary", txtvoluntary.Text)
                .Parameters.AddWithValue("@sss", txtsss.Text)
                .Parameters.AddWithValue("@philhealth", txtphilhealth.Text)
                .Parameters.AddWithValue("@pagibig", txtpagibig.Text)
                .Parameters.AddWithValue("@tax", txttax.Text)
                .Parameters.AddWithValue("@mandatory", txtmandatory.Text)
                .Parameters.AddWithValue("@totalincrease", txttotalincrease.Text)
                .Parameters.AddWithValue("@totaldeduc", txttotaldeduc.Text)
                .Parameters.AddWithValue("@grosspay", txtgrosspay.Text)
                .Parameters.AddWithValue("@netpay", txtnetpay.Text)
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
            MsgBox("Payroll saved!")
            LoadEmployees(cb)
            cb.SelectedIndex = -1
            txtot.Clear()
            txtallowance.Clear()
            txtincentives.Clear()
            txtnightdiff.Clear()
            txtlate.Clear()
            txtundertime.Clear()
            txtvoluntary.Clear()
            txtsss.Clear()
            txtphilhealth.Clear()
            txtpagibig.Clear()
            txttax.Clear()
            txtmandatory.Clear()
            txttotalincrease.Clear()
            txttotaldeduc.Clear()
            txtgrosspay.Clear()
            txtnetpay.Clear()
        Catch ex As Exception

        End Try
    End Sub
End Class
