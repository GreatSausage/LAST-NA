Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class FrmMainte

    Private Sub FrmMainte_Load(sender As Object, e As EventArgs) Handles Me.Load
        DisplayDepartmentInForm()
        DisplayLeaveInForm()
        DisplayPositionInForm()
        DisplayAllowanceInForm()
        Load_department(cbDept)
        DisplayIncentivesInForm()
        DisplayRatesInForm()
        DisplayHolidayInForm()
        DisplayTaxInForm()
        DisplaySSSInForm()
        DisplayPagibigInForm()
        DisplayPhilhealthInForm()
        DisplayVoluntaryInForm()
        DisplayUserInForm()

        Dim dtDepartment As DataTable = DisplayDepartment()
        CbDepartment.DataSource = dtDepartment
        CbDepartment.ValueMember = "departmentID"
        CbDepartment.DisplayMember = "departmentName"

        Dim dtPosition As DataTable = DisplayPosition()
        CbDepartment.SelectedIndex = -1
        CbClassification.SelectedIndex = 0

        Dim maxSalary As Decimal = TaxGetMaxSalary()
        TxtTaxMinSalary.Text = maxSalary

        Dim maxSalaryOne As Decimal = SSSGetMaxSalary()
        TxtSSSMinSalary.Text = maxSalaryOne

        cbRoles.SelectedIndex = 0
    End Sub

#Region "User Maintenance"
    Public Sub DisplayUserInForm()
        Dim dt As DataTable = DisplayUsers()
        DgUser.DataSource = dt
    End Sub

    Private Sub BtnSaveUser_Click(sender As Object, e As EventArgs) Handles BtnSaveUser.Click
        Try
            If String.IsNullOrEmpty(TxtFirstname.Text) OrElse
          String.IsNullOrEmpty(TxtLastname.Text) OrElse
          String.IsNullOrEmpty(TxtUsername.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtFirstname.Text, forNames) OrElse
                   Not Regex.IsMatch(TxtLastname.Text, forNames) Then
                MsgLetterOnly()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtUsername.Text, antiSpace) Then
                MessageBox.Show("Username cannot contain spaces.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            Else
                NewUser(TxtFirstname.Text, TxtLastname.Text, cbRoles.SelectedItem.ToString, TxtUsername.Text)
                DisplayUserInForm()
                TxtFirstname.Clear()
                TxtLastname.Clear()

                TxtUsername.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If String.IsNullOrEmpty(TxtFirstname.Text) OrElse
           String.IsNullOrEmpty(TxtLastname.Text) OrElse
           String.IsNullOrEmpty(TxtUsername.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf MdlMaintenance.firstname <> TxtFirstname.Text OrElse MdlMaintenance.lastname <> TxtLastname.Text OrElse MdlMaintenance.username <> TxtUsername.Text Then
            MessageBox.Show("Selected user doesn't match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MdlMaintenance.firstname = ""
            MdlMaintenance.lastname = ""
            MdlMaintenance.username = ""
            MdlMaintenance.userID = 0
            TxtFirstname.Clear()
            TxtLastname.Clear()
            TxtUsername.Clear()
            DgUser.ClearSelection()
            Exit Sub
        ElseIf MdlMaintenance.userID = 0 AndAlso (Not String.IsNullOrEmpty(TxtFirstname.Text) OrElse Not String.IsNullOrEmpty(TxtLastname.Text) OrElse Not String.IsNullOrEmpty(TxtUsername.Text)) Then
            MessageBox.Show("Invalid deletion.")
            Exit Sub
        ElseIf MdlMaintenance.userID <> 0 Then
            If MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DeleteUser(MdlMaintenance.userID)
                DisplayUserInForm()
                MdlMaintenance.userID = 0
                MdlMaintenance.firstname = ""
                MdlMaintenance.lastname = ""
                MdlMaintenance.username = ""
                MdlMaintenance.userID = 0
                TxtFirstname.Clear()
                TxtLastname.Clear()
                TxtUsername.Clear()

                DgUser.ClearSelection()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Panel39_Click(sender As Object, e As EventArgs) Handles Panel39.Click
        MdlMaintenance.userID = 0
        MdlMaintenance.firstname = ""
        MdlMaintenance.lastname = ""
        MdlMaintenance.username = ""
        MdlMaintenance.userID = 0
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        DgUser.ClearSelection()
    End Sub

    Private Sub DgUser_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgUser.CellClick
        Try
            SelectUser(DgUser)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Department"
    Public Sub DisplayDepartmentInForm()
        Dim dtDepartment As DataTable = DisplayDepartment()
        DgDepartment.DataSource = dtDepartment
    End Sub

    Private Sub BtnSaveDepartment_Click(sender As Object, e As EventArgs) Handles BtnSaveDepartment.Click
        Try
            If String.IsNullOrEmpty(TxtDepartment.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtDepartment.Text, letterOnly) Then
                MsgLetterOnly()
                TxtDepartment.Clear()
                Exit Sub
            Else
                NewDepartment(TxtDepartment.Text)
                TxtDepartment.Clear()
                DisplayDepartmentInForm()
                Dim dtDepartment As DataTable = DisplayDepartment()
                CbDepartment.DataSource = dtDepartment
                CbDepartment.ValueMember = "departmentID"
                CbDepartment.DisplayMember = "departmentName"
                cbDept.DataSource = dtDepartment
                cbDept.ValueMember = "departmentID"
                cbDept.DisplayMember = "departmentName"
                MdlMaintenance.departmentName = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub DgDepartment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgDepartment.CellClick
        Try
            SelectDepartment(DgDepartment)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub BtnDeleteDepartment_Click(sender As Object, e As EventArgs) Handles BtnDeleteDepartment.Click
        Try
            'pag empty ang textbox
            If String.IsNullOrEmpty(TxtDepartment.Text) Then
                MsgEmptyField()
                Exit Sub
                'pag di parehas ang textbox sa selectedrow
            ElseIf MdlMaintenance.departmentName <> TxtDepartment.Text Then
                MessageBox.Show("Selected department doesn't match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MdlMaintenance.departmentID = 0
                TxtDepartment.Clear()
                DgDepartment.ClearSelection()
                MdlMaintenance.departmentName = ""
                Exit Sub
                'pag nagdedelete nang di nagselect sa datagrid
            ElseIf MdlMaintenance.departmentID = 0 AndAlso Not String.IsNullOrEmpty(TxtDepartment.Text) Then
                MessageBox.Show("This department doesn't exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtDepartment.Clear()
                MdlMaintenance.departmentName = ""
                Exit Sub
                'multidelete 
            ElseIf DgDepartment.SelectedRows.Count > 0 AndAlso String.IsNullOrEmpty(TxtDepartment.Text) Then
                If MessageBox.Show("Are you sure you want to delete this department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    UpdateDepartmentStatus(DgDepartment)
                    DisplayDepartmentInForm()
                    Dim dt As DataTable = DisplayDepartment()
                    Dim dtDepartment As DataTable = DisplayDepartment()
                    CbDepartment.DataSource = dtDepartment
                    CbDepartment.ValueMember = "departmentID"
                    CbDepartment.DisplayMember = "departmentName"
                    TxtDepartment.Clear()
                    MdlMaintenance.departmentName = ""
                    Exit Sub
                End If
                Exit Sub
                'single delete
            ElseIf MdlMaintenance.departmentID <> 0 Then
                If MessageBox.Show("Are you sure you want to delete this department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    UpdateDepartmentStatus(DgDepartment)
                    DisplayDepartmentInForm()
                    Dim dtDepartment As DataTable = DisplayDepartment()
                    CbDepartment.DataSource = dtDepartment
                    CbDepartment.ValueMember = "departmentID"
                    CbDepartment.DisplayMember = "departmentName"
                    MdlMaintenance.departmentName = ""
                    TxtDepartment.Clear()
                    Exit Sub
                End If
                Exit Sub

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtDepartment_TextChanged(sender As Object, e As EventArgs) Handles TxtDepartment.TextChanged
        If String.IsNullOrEmpty(TxtDepartment.Text) Then
            MdlMaintenance.departmentID = 0
        End If

    End Sub


    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        DgDepartment.ClearSelection()
        TxtDepartment.Clear()
        MdlMaintenance.departmentID = 0
        MdlMaintenance.departmentName = ""
    End Sub
#End Region

#Region "Leave"
    Public Sub DisplayLeaveInForm()
        Dim dtLeave As DataTable = DisplayLeave()
        dgLeave.DataSource = dtLeave
    End Sub

    Private Sub BtnSaveLeave_Click(sender As Object, e As EventArgs) Handles BtnSaveLeave.Click
        Try
            If String.IsNullOrEmpty(TxtLeave.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtLeave.Text, letterOnly) Then
                MsgLetterOnly()
                TxtLeave.Clear()
                Exit Sub
            Else
                NewLeave(TxtLeave.Text)
                TxtLeave.Clear()
                DisplayLeaveInForm()
                MdlMaintenance.leaveName = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DgLeave_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLeave.CellClick
        Try
            SelectLeaveID(dgLeave)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnDeleteLeave_Click(sender As Object, e As EventArgs) Handles BtnDeleteLeave.Click
        Try
            If String.IsNullOrEmpty(TxtLeave.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf MdlMaintenance.leaveName <> TxtLeave.Text Then
                MessageBox.Show("Selected leave doesn't match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MdlMaintenance.leaveID = 0
                TxtLeave.Clear()
                dgLeave.ClearSelection()
                MdlMaintenance.leaveName = ""
                Exit Sub
            ElseIf MdlMaintenance.leaveID = 0 AndAlso Not String.IsNullOrEmpty(TxtDepartment.Text) Then
                MessageBox.Show("This leave type doesn't exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtLeave.Clear()
                MdlMaintenance.leaveName = ""
                Exit Sub
            ElseIf dgLeave.SelectedRows.Count > 0 AndAlso String.IsNullOrEmpty(TxtLeave.Text) Then
                If MessageBox.Show("Are you sure you want to delete this leave?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    UpdateLeaveStatus(dgLeave)
                    DisplayLeaveInForm()
                    TxtLeave.Clear()
                    MdlMaintenance.leaveName = ""
                    Exit Sub
                End If
                Exit Sub
            ElseIf MdlMaintenance.leaveID <> 0 Then
                If MessageBox.Show("Are you sure you want to delete this leave?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    UpdateLeaveStatus(dgLeave)
                    DisplayLeaveInForm()
                    TxtLeave.Clear()
                    MdlMaintenance.leaveName = ""
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtLeave_TextChanged(sender As Object, e As EventArgs) Handles TxtLeave.TextChanged
        If String.IsNullOrEmpty(TxtLeave.Text) Then
            MdlMaintenance.leaveID = 0
        End If
    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        dgLeave.ClearSelection()
        TxtLeave.Clear()
        MdlMaintenance.leaveID = 0
        MdlMaintenance.leaveName = ""
    End Sub

#End Region

#Region "Position"
    Public Sub DisplayPositionInForm()
        Dim dtPosition As DataTable = DisplayPosition()
        DgPosition.DataSource = dtPosition
    End Sub

    Private Sub BtnSavePosition_Click(sender As Object, e As EventArgs) Handles BtnSavePosition.Click
        Try
            If String.IsNullOrEmpty(TxtPosition.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf CbDepartment.SelectedIndex = -1 Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtPosition.Text, letterOnly) Then
                MsgLetterOnly()
                TxtPosition.Clear()
                Exit Sub
            Else
                Dim id As Integer = Convert.ToInt32(CbDepartment.SelectedValue)
                NewPosition(TxtPosition.Text, id)
                DisplayPositionInForm()
                CbDepartment.SelectedIndex = -1
                TxtPosition.Clear()
                MdlMaintenance.positionName = ""
                MdlMaintenance.positionID = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DgPosition_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgPosition.CellClick
        Try
            SelectPositionID(DgPosition)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnDeletePosition_Click(sender As Object, e As EventArgs) Handles BtnDeletePosition.Click
        If String.IsNullOrEmpty(TxtPosition.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf MdlMaintenance.positionName <> TxtPosition.Text Then
            MessageBox.Show("Selected position doesn't match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MdlMaintenance.positionID = 0
            TxtPosition.Clear()
            DgPosition.ClearSelection()
            MdlMaintenance.positionName = ""
            Exit Sub
        ElseIf MdlMaintenance.positionID = 0 AndAlso Not String.IsNullOrEmpty(TxtPosition.text) Then
            MessageBox.Show("This position doesn't exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtPosition.Clear()
            MdlMaintenance.positionName = ""
            Exit Sub
        ElseIf DgPosition.SelectedRows.Count > 0 AndAlso String.IsNullOrEmpty(TxtPosition.text) Then
            If MessageBox.Show("Are you sure you want to delete this position?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                UpdatePositionStatus(DgPosition)
                DisplayPositionInForm()
                TxtPosition.Clear()
                MdlMaintenance.positionName = ""
                Exit Sub
            End If
        ElseIf MdlMaintenance.positionID <> 0 Then
            If MessageBox.Show("Are you sure you want to delete this position?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                UpdatePositionStatus(DgPosition)
                DisplayPositionInForm()
                TxtPosition.Clear()
                MdlMaintenance.positionName = ""
                Exit Sub
            End If
            Exit Sub
        End If
    End Sub

    Private Sub TxtPosition_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(TxtPosition.Text) Then
            MdlMaintenance.positionID = 0
        End If

    End Sub

    Private Sub CbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbDepartment.SelectedIndexChanged
        If MdlMaintenance.positionID = 0 AndAlso DgPosition.SelectedRows.Count <> 0 Then
            TxtPosition.Clear()
            MdlMaintenance.positionName = ""
            Exit Sub
        End If
    End Sub

    Private Sub Panel10_Click(sender As Object, e As EventArgs) Handles Panel10.Click
        TxtPosition.Clear()
        CbDepartment.SelectedIndex = -1
        DgPosition.ClearSelection()
        MdlMaintenance.positionID = 0
        MdlMaintenance.positionName = ""
    End Sub
#End Region

#Region "Allowance"
    Public Sub DisplayAllowanceInForm()
        Dim dtAllowance As DataTable = DisplayAllowance()
        DgAllowance.DataSource = dtAllowance
    End Sub
    Private Sub BtnSaveAllowance_Click(sender As Object, e As EventArgs) Handles BtnSaveAllowance.Click
        Try
            If String.IsNullOrEmpty(TxtAllowance.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtAllowance.Text, letterOnly) Then
                MsgLetterOnly()
                TxtAllowance.Clear()
                Exit Sub
            Else
                NewAllowance(TxtAllowance.Text)
                TxtAllowance.Clear()
                DisplayAllowanceInForm()
                MdlMaintenance.allowanceName = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DgAllowance_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgAllowance.CellClick
        Try
            SelectAllowance(DgAllowance)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub BtnDeleteAllowance_Click(sender As Object, e As EventArgs) Handles BtnDeleteAllowance.Click
        If String.IsNullOrEmpty(TxtAllowance.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf MdlMaintenance.allowanceName <> TxtDepartment.Text Then
            MessageBox.Show("Selected allowance doesn't match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MdlMaintenance.allowanceID = 0
            TxtAllowance.Clear()
            DgAllowance.ClearSelection()
            MdlMaintenance.allowanceName = ""
            Exit Sub
        ElseIf MdlMaintenance.allowanceID = 0 AndAlso Not String.IsNullOrEmpty(TxtAllowance.text) Then
            MessageBox.Show("This allowance doesn't exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtAllowance.Clear()
            MdlMaintenance.allowanceName = ""
            Exit Sub
        ElseIf DgAllowance.SelectedRows.Count > 0 AndAlso String.IsNullOrEmpty(TxtAllowance.text) Then
            If MessageBox.Show("Are you sure you want to delete this allowance?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                UpdateAllowanceStatus(DgAllowance)
                DisplayAllowanceInForm()
                TxtAllowance.Clear()
                Exit Sub
            End If
        ElseIf MdlMaintenance.allowanceID <> 0 Then
            If MessageBox.Show("Are you sure you want to delete this allowance?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                UpdateAllowanceStatus(DgAllowance)
                DisplayAllowanceInForm()
                TxtAllowance.Clear()
                Exit Sub
            End If
            Exit Sub
        End If
    End Sub

    Private Sub TxtAllowance_TextChanged(sender As Object, e As EventArgs) Handles TxtAllowance.TextChanged
        If String.IsNullOrEmpty(TxtAllowance.Text) Then
            MdlMaintenance.allowanceID = 0
        End If
    End Sub

    Private Sub Panel14_Click(sender As Object, e As EventArgs) Handles Panel14.Click
        TxtAllowance.Clear()
        DgAllowance.ClearSelection()
        MdlMaintenance.allowanceID = 0
        MdlMaintenance.allowanceName = ""
    End Sub

#End Region

#Region "Manage Position"
    Private Sub btnManagePos_Click(sender As Object, e As EventArgs) Handles btnManagePos.Click
        Try
            If cbDept.SelectedIndex = -1 OrElse cbPos.SelectedIndex = -1 Then
                MsgEmptyField()
                Exit Sub
            End If

            For Each row As DataGridViewRow In dgManageLeave.Rows
            'maximum leave
            Dim maximum As Integer = If(String.IsNullOrEmpty(row.Cells("days").Value.ToString), 0, row.Cells("days").Value)
            If Not IsNumeric(maximum) Then
                MessageBox.Show("This contains number only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf maximum < 0 Then
                MessageBox.Show("Maximum number of leave cannot be less than 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf maximum.ToString.Length > 2 Then
                MessageBox.Show("Invalid number of leave.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf Not Regex.IsMatch(maximum.ToString, numberOnly) Then
                MessageBox.Show("This contains number only")
                Exit Sub
            End If
        Next

        For Each row As DataGridViewRow In dgManageAllowance.Rows
            Dim amount As Integer = If(String.IsNullOrEmpty(row.Cells("amount").Value.ToString), 0, row.Cells("amount").Value)

            If Not IsNumeric(amount) Then
                MessageBox.Show("This contains number only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf amount < 0 Then
                MessageBox.Show("Allowance amount cannont be less than 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf amount.ToString.Length > 20 Then
                MessageBox.Show("Invalid allowance ammount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next

        Update_Leave(dgManageLeave, cbPos, dgManageAllowance)
        Catch ex As Exception
        MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cbDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDept.SelectedIndexChanged
        Try
            Load_position(cbDept, cbPos)
            cbPos.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cbPos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPos.SelectedIndexChanged
        Try
            Load_LeaveAndAllowance(cbPos, dgManageLeave, dgManageAllowance)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



#End Region

#Region "Incentives"
    Public Sub DisplayIncentivesInForm()
        Dim dtIncentive As DataTable = DisplayIncentives()
        DgIncentives.DataSource = dtIncentive
    End Sub

    Private Sub BtnSaveIncentives_Click(sender As Object, e As EventArgs) Handles BtnSaveIncentives.Click
        Try
            If String.IsNullOrEmpty(TxtIncentives.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtIncentives.Text, singleSpace) Then
                MessageBox.Show("Invalid incentive name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                NewIncentives(TxtIncentives.Text)
                TxtIncentives.Clear()
                DisplayIncentivesInForm()
                MdlMaintenance.incentiveName = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DgIncentives_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgIncentives.CellClick
        Try
            SelectIncentives(DgIncentives)

        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnDeleteIncentive_Click(sender As Object, e As EventArgs) Handles BtnDeleteIncentive.Click
        If String.IsNullOrEmpty(TxtIncentives.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf MdlMaintenance.incentiveName <> TxtIncentives.Text Then
            MessageBox.Show("Selected incentive doesn't match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MdlMaintenance.incentiveID = 0
            TxtIncentives.Clear()
            DgIncentives.ClearSelection()
            MdlMaintenance.incentiveName = ""
            Exit Sub
        ElseIf MdlMaintenance.incentiveID = 0 AndAlso Not String.IsNullOrEmpty(TxtIncentives.text) Then
            MessageBox.Show("This incentive doesn't exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtIncentives.Clear()
            MdlMaintenance.incentiveName = ""
            Exit Sub
        ElseIf DgDepartment.SelectedRows.Count > 0 AndAlso String.IsNullOrEmpty(TxtIncentives.text) Then
            If MessageBox.Show("Are you sure you want to delete this incentive?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                UpdateIncentiveStatus()
                DisplayIncentivesInForm()
                TxtIncentives.Clear()
                Exit Sub
            End If
            Exit Sub
        ElseIf MdlMaintenance.incentiveID <> 0 Then
            If MessageBox.Show("Are you sure you want to delete this incentive?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                UpdateIncentiveStatus()
                DisplayIncentivesInForm()
                TxtIncentives.Clear()
                Exit Sub
            End If
            Exit Sub
        End If
    End Sub

    Private Sub TxtIncentives_TextChanged(sender As Object, e As EventArgs) Handles TxtIncentives.TextChanged
        If String.IsNullOrEmpty(TxtIncentives.Text) Then
            MdlMaintenance.incentiveID = 0
        End If

    End Sub

    Private Sub Panel20_Click(sender As Object, e As EventArgs) Handles Panel20.Click
        DgIncentives.ClearSelection()
        TxtIncentives.Clear()
        MdlMaintenance.incentiveID = 0
        MdlMaintenance.incentiveName = ""
    End Sub
#End Region

#Region "Holiday"

    Public Sub DisplayHolidayInForm()
        Dim dt As DataTable = DisplayHoliday()
        dgHoliday.DataSource = dt
    End Sub
    Private Sub BtnSaveHoliday_Click(sender As Object, e As EventArgs) Handles BtnSaveHoliday.Click
        Try
            If String.IsNullOrEmpty(TxtHoliday.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtHoliday.Text, letterOnly) Then
                MsgLetterOnly()
                Exit Sub
            Else
                NewHoliday(TxtHoliday.Text, DtHoliday.Value, CbClassification.Text)
                TxtHoliday.Clear()
                CbClassification.SelectedIndex = 0
                DtHoliday.Value = Date.Now
                DisplayHolidayInForm()
                MdlMaintenance.holidayName = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DgHoliday_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgHoliday.CellClick
        Try
            SelectHoliday(dgHoliday)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDeleteHoliday_Click(sender As Object, e As EventArgs) Handles BtnDeleteHoliday.Click
        If String.IsNullOrEmpty(TxtHoliday.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf MdlMaintenance.holidayName <> TxtHoliday.Text Then
            MessageBox.Show("Selected holiday doesn't match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MdlMaintenance.holidayID = 0
            TxtHoliday.Clear()
            dgHoliday.ClearSelection()
            MdlMaintenance.holidayName = ""
            Exit Sub
        ElseIf MdlMaintenance.holidayID = 0 AndAlso Not String.IsNullOrEmpty(TxtHoliday.Text) Then
            MessageBox.Show("This holiday doesn't exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtHoliday.Clear()
            MdlMaintenance.holidayName = ""
            Exit Sub
        ElseIf dgHoliday.SelectedRows.Count > 0 AndAlso String.IsNullOrEmpty(TxtHoliday.Text) Then
            If MessageBox.Show("Are you sure you want to delete this holiday?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DeleteHoliday()
                DisplayHolidayInForm()
                TxtHoliday.Clear()
                CbClassification.SelectedIndex = 0
                DtHoliday.Value = Date.Now
                Exit Sub
            End If
            Exit Sub
        ElseIf MdlMaintenance.holidayID <> 0 Then
            If MessageBox.Show("Are you sure you want to delete this holiday?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DeleteHoliday()
                DisplayHolidayInForm()
                TxtHoliday.Clear()
                CbClassification.SelectedIndex = 0
                DtHoliday.Value = Date.Now
                Exit Sub
            End If
            Exit Sub
        End If
    End Sub

    Private Sub TxtHoliday_TextChanged(sender As Object, e As EventArgs) Handles TxtHoliday.TextChanged
        If String.IsNullOrEmpty(TxtHoliday.Text) Then
            MdlMaintenance.holidayID = 0
        End If
    End Sub
    Private Sub Panel23_Click(sender As Object, e As EventArgs) Handles Panel23.Click
        dgHoliday.ClearSelection()
        TxtHoliday.Clear()
        MdlMaintenance.holidayID = 0
        MdlMaintenance.holidayName = ""
    End Sub
#End Region

#Region "Rates"
    Public Sub DisplayRatesInForm()
        Dim dtRates As DataTable = DisplayRates()
        dgRates.DataSource = dtRates
    End Sub

    Private Sub BtnSaveRate_Click(sender As Object, e As EventArgs) Handles BtnSaveRate.Click
        Try
            If String.IsNullOrEmpty(TxtRates.Text) OrElse String.IsNullOrEmpty(TxtRateClassification.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtRates.Text, numberOnly) Then
                MsgNumberOnly()
                TxtRates.Clear()
                Exit Sub
            Else
                NewRates(TxtRates.Text, TxtRateClassification.Text)
                DisplayRatesInForm()
                TxtRates.Clear()
                TxtRateClassification.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DgRates_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRates.CellClick
        Try
            SelectRates(dgRates)
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Contributions"

#Region "Tax"
    Public Sub DisplayTaxInForm()
        Dim dtTax As DataTable = DisplayTax()
        dgTax.DataSource = dtTax
    End Sub
    Private Sub BtnSaveTax_Click(sender As Object, e As EventArgs) Handles BtnSaveTax.Click
        Dim taxMinSalary As Decimal = Val(TxtTaxMinSalary.Text)
        Dim taxMaxSalary As Decimal = Val(TxtTaxMaxSalary.Text)
        Try
            If String.IsNullOrEmpty(TxtTaxMaxSalary.Text) OrElse
           String.IsNullOrEmpty(TxtTaxFixedAmount.Text) OrElse
           String.IsNullOrEmpty(TxtTaxPercentage.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtTaxMaxSalary.Text, numberOnly) OrElse
               Not Regex.IsMatch(TxtTaxFixedAmount.Text, numberOnly) OrElse
               Not Regex.IsMatch(TxtTaxPercentage.Text, numberOnly) Then
                MsgNumberOnly()
                Exit Sub
            ElseIf taxMinSalary > taxMaxSalary Then
                MessageBox.Show("Minimum Salary should be lower than max salary.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtTaxMaxSalary.Clear()
                Exit Sub
            ElseIf Val(TxtTaxFixedAmount.Text) > 300000 Then
                MessageBox.Show("invalid fixed amount")
                Exit Sub
            Else
                Dim minSalary As Decimal
                If String.IsNullOrEmpty(TxtTaxMinSalary.Text) Then
                    minSalary = 0
                Else
                    minSalary = Val(TxtTaxMinSalary.Text)
                End If
                Dim maxSalary As Decimal = Val(TxtTaxMaxSalary.Text)
                Dim fixedAmount As Decimal = Val(TxtTaxFixedAmount.Text)
                Dim percentage As Decimal = Val(TxtTaxPercentage.Text)
                NewTax(minSalary, maxSalary, fixedAmount, percentage)
                DisplayTaxInForm()
                Dim maxSalaryOne As Decimal = TaxGetMaxSalary()
                TxtTaxMinSalary.Text = maxSalaryOne
                TxtTaxMaxSalary.Clear()
                TxtTaxFixedAmount.Clear()
                TxtTaxPercentage.Clear()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnDeleteTax_Click(sender As Object, e As EventArgs) Handles BtnDeleteTax.Click
        If dgTax.Rows.Count = 0 Then
            MessageBox.Show("Invalid deletion.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to delete this tax?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DeleteTax()
                DisplayTaxInForm()
                TxtTaxMinSalary.Text = TaxGetMaxSalary()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Panel28_Click(sender As Object, e As EventArgs) Handles Panel28.Click
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        dgTax.ClearSelection()
    End Sub

#End Region

#Region "SSS"

    Public Sub DisplaySSSInForm()
        Dim dtSSS As DataTable = DisplaySSS()
        dgSSS.DataSource = dtSSS
    End Sub

    Private Sub BtnSaveSSS_Click(sender As Object, e As EventArgs) Handles BtnSaveSSS.Click
        Try
            If String.IsNullOrEmpty(TxtSSSMaxSalary.Text) OrElse
                    String.IsNullOrEmpty(TxtSSSEE.Text) OrElse
                    String.IsNullOrEmpty(TxtSSSWISP.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtSSSEE.Text, forPrice) Then
                MessageBox.Show("Invalid EE")
                Exit Sub
            ElseIf Val(TxtSSSEE.Text > 10000) Then
                MessageBox.Show("Invalid amount of EE")
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtSSSMaxSalary.Text, numberOnly) OrElse
                   Not Regex.IsMatch(TxtSSSEE.Text, numberOnly) OrElse
                   Not Regex.IsMatch(TxtSSSWISP.Text, numberOnly) Then
                MsgNumberOnly()
                Exit Sub
            ElseIf Val(TxtSSSWISP.text) > 9999 Then
                MessageBox.Show("Invalid WISP")
                Exit Sub
            Else
                Dim minSalary As Decimal
                If String.IsNullOrEmpty(TxtSSSMinSalary.Text) Then
                    minSalary = 0
                Else
                    minSalary = Val(TxtSSSMinSalary.Text)
                End If
                NewSSS(minSalary, Val(TxtSSSMaxSalary.Text), Val(TxtSSSEE.Text), Val(TxtSSSWISP.Text))
                DisplaySSSInForm()
                Dim sssMaxSalary As Decimal = SSSGetMaxSalary()
                TxtSSSMinSalary.Text = sssMaxSalary
                TxtSSSMaxSalary.Clear()
                TxtSSSEE.Clear()
                TxtSSSWISP.Clear()
                TxtSSSTotal.Clear()
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub TxtSSSMaxSalary_TextChanged(sender As Object, e As EventArgs) Handles TxtSSSMaxSalary.TextChanged
        Try
            If String.IsNullOrEmpty(TxtSSSMaxSalary.Text) Then
                TxtSSSWISP.Enabled = False
                Exit Sub
            Else
                Dim max As Integer = Val(TxtSSSMaxSalary.Text)
                If max < 20000 Then
                    TxtSSSWISP.Enabled = False
                    TxtSSSWISP.Text = "0.00"
                Else
                    TxtSSSWISP.Enabled = True
                    TxtSSSWISP.Clear()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSSSWisp_TextChanged(sender As Object, e As EventArgs) Handles TxtSSSWISP.TextChanged
        Dim wisp As Decimal
        Try
            If Not String.IsNullOrEmpty(TxtSSSEE.Text) Then
                TxtSSSTotal.Text = Val(TxtSSSEE.Text) + Val(TxtSSSWISP.Text)
            ElseIf String.IsNullOrEmpty(TxtSSSWISP.Text) Then
                wisp = 0
                TxtSSSTotal.Text = Val(TxtSSSEE.Text) + wisp
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDeleteSSS_Click(sender As Object, e As EventArgs) Handles BtnDeleteSSS.Click
        If dgSSS.Rows.Count = 0 Then
            MessageBox.Show("Invalid deletion")
            Exit Sub
        End If
        If MessageBox.Show("Are you sure you want to delete this SSS?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeleteSSS()
            DisplaySSSInForm()
            TxtSSSMinSalary.Text = SSSGetMaxSalary()
            Exit Sub
        End If
    End Sub

    Private Sub Panel32_Click(sender As Object, e As EventArgs) Handles Panel32.Click
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtSSSWISP.Clear()
        dgSSS.ClearSelection()
    End Sub

#End Region

#Region "PAG-IBIG"
    Public Sub DisplayPagibigInForm()
        Dim dt As DataTable = DisplayPagIbig()
        dgPagibig.DataSource = dt
    End Sub

    Private Sub BtnSavePagibig_Click(sender As Object, e As EventArgs) Handles BtnSavePagibig.Click
        Try
            If String.IsNullOrEmpty(TxtPagibigRate.Text) Then
                MessageBox.Show("Please fill in the necessary fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtPagibigRate.Text, numberOnly) Then
                MessageBox.Show("This contains number only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                NewPagibig(TxtPagibigRate.Text)
                DisplayPagibigInForm()
                TxtPagibigRate.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "PhilHealth"
    Public Sub DisplayPhilhealthInForm()
        Dim dt As DataTable = DisplayPhilhealth()
        dgPhilhealth.DataSource = dt
    End Sub

    Private Sub BtnSavePhilhealth_Click(sender As Object, e As EventArgs) Handles BtnSavePhilhealth.Click
        Try
            If String.IsNullOrEmpty(txtPhilhealthRate.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(txtPhilhealthRate.Text, numberOnly) Then
                MessageBox.Show("This contains number only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                NewPhilhealth(Convert.ToInt32(txtPhilhealthRate.Text))
                DisplayPhilhealthInForm()
                txtPhilhealthRate.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Voluntary"

    Public Sub DisplayVoluntaryInForm()
        Dim dt As DataTable = DisplayVoluntary()
        DgVoluntary.DataSource = dt
    End Sub
    Private Sub BtnSaveVoluntary_Click(sender As Object, e As EventArgs) Handles BtnSaveVoluntary.Click
        Try
            If String.IsNullOrEmpty(TxtVoluntary.Text) Then
                MsgEmptyField()
                Exit Sub
            ElseIf Not Regex.IsMatch(TxtVoluntary.Text, letterOnly) Then
                MsgLetterOnly()
                Exit Sub
            Else
                NewVoluntary(TxtVoluntary.Text)
                TxtVoluntary.Clear()
                DisplayVoluntaryInForm()
                MdlMaintenance.voluntaryName = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub BtnDeleteVoluntary_Click(sender As Object, e As EventArgs) Handles BtnDeleteVoluntary.Click
        If String.IsNullOrEmpty(TxtVoluntary.Text) Then
            MsgEmptyField()
            Exit Sub
        ElseIf MdlMaintenance.voluntaryName <> TxtVoluntary.Text Then
            MessageBox.Show("Selected voluntary name doesn't match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MdlMaintenance.voluntaryID = 0
            TxtVoluntary.Clear()
            DgVoluntary.ClearSelection()
            MdlMaintenance.voluntaryName = ""
            Exit Sub
        ElseIf MdlMaintenance.voluntaryID = 0 AndAlso Not String.IsNullOrEmpty(TxtVoluntary.text) Then
            MessageBox.Show("This voluntary doesn't exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtVoluntary.Clear()
            MdlMaintenance.voluntaryName = ""
            Exit Sub
        ElseIf DgVoluntary.SelectedRows.Count > 0 AndAlso String.IsNullOrEmpty(TxtVoluntary.text) Then
            If MessageBox.Show("Are you sure you want to delete this voluntary?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                UpdateVoluntaryStatus()
                DisplayVoluntaryInForm()
                TxtVoluntary.Clear()
                Exit Sub
            End If
            Exit Sub
        ElseIf MdlMaintenance.voluntaryID <> 0 Then
            If MessageBox.Show("Are you sure you want to delete this voluntary?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                UpdateVoluntaryStatus()
                DisplayVoluntaryInForm()
                TxtVoluntary.Clear()
                Exit Sub
            End If
            Exit Sub
        End If
    End Sub

    Private Sub DgVoluntary_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgVoluntary.CellClick
        Try
            SelectVoluntaryID(DgVoluntary)
            If MdlMaintenance.voluntaryName <> TxtVoluntary.Text Then
                BtnSaveVoluntary.Enabled = True
                Exit Sub
            ElseIf MdlMaintenance.voluntaryName = "" Then
                BtnSaveVoluntary.Enabled = True
                Exit Sub
            Else
                BtnSaveVoluntary.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtVoluntary_TextChanged(sender As Object, e As EventArgs) Handles TxtVoluntary.TextChanged
        If String.IsNullOrEmpty(TxtVoluntary.Text) Then
            MdlMaintenance.voluntaryID = 0
        End If

        If MdlMaintenance.voluntaryName <> TxtVoluntary.Text Then
            BtnSaveVoluntary.Enabled = True
            Exit Sub
        ElseIf MdlMaintenance.voluntaryName = "" Then
            BtnSaveVoluntary.Enabled = True
            Exit Sub
        Else
            BtnSaveVoluntary.Enabled = False
        End If
    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        DgVoluntary.ClearSelection()
        TxtVoluntary.Clear()
        MdlMaintenance.voluntaryID = 0
        MdlMaintenance.voluntaryName = ""
    End Sub

#End Region
#End Region

#Region "taga clear"
    Private Sub tabUser_Enter(sender As Object, e As EventArgs) Handles tabUser.Enter
        TxtDepartment.Clear()
        TxtLeave.Clear()
        TxtPosition.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtHoliday.Clear()
        TxtRates.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
    End Sub

    Private Sub tabDepartment_Enter(sender As Object, e As EventArgs) Handles tabDepartment.Enter
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtPosition.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtHoliday.Clear()
        TxtRates.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
    End Sub

    Private Sub tabLeave_Enter(sender As Object, e As EventArgs) Handles tabLeave.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtPosition.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtHoliday.Clear()
        TxtRates.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
    End Sub

    Private Sub tabPosition_Enter(sender As Object, e As EventArgs) Handles tabPosition.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtHoliday.Clear()
        TxtRates.Clear()
        TxtTaxFixedAmount.Clear()
        TxtPosition.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
    End Sub

    Private Sub tabAllowance_Enter(sender As Object, e As EventArgs) Handles tabAllowance.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtLeave.Clear()
        TxtIncentives.Clear()
        TxtHoliday.Clear()
        TxtRates.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtPosition.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
    End Sub

    Private Sub tabIncentives_Enter(sender As Object, e As EventArgs) Handles tabIncentives.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtAllowance.Clear()
        TxtHoliday.Clear()
        TxtRates.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtTaxFixedAmount.Clear()
        TxtPosition.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
    End Sub

    Private Sub tabHoliday_Enter(sender As Object, e As EventArgs) Handles tabHoliday.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtRates.Clear()
        TxtPosition.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
    End Sub

    Private Sub tabRate_Enter(sender As Object, e As EventArgs) Handles tabRate.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtRates.Clear()
        TxtPosition.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtSSSWISP.Clear()
        TxtHoliday.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
    End Sub

    Private Sub tabTax_Enter(sender As Object, e As EventArgs) Handles tabTax.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtRates.Clear()
        TxtPosition.Clear()
        TxtSSSMaxSalary.Clear()
        TxtHoliday.Clear()
        TxtSSSTotal.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
    End Sub

    Private Sub tabSSS_Enter(sender As Object, e As EventArgs) Handles tabSSS.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtRates.Clear()
        TxtPosition.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtHoliday.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
    End Sub

    Private Sub tabPagibig_Enter(sender As Object, e As EventArgs) Handles tabPagibig.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtRates.Clear()
        TxtPosition.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtVoluntary.Clear()
        TxtHoliday.Clear()
    End Sub

    Private Sub tabPhilHealth_Enter(sender As Object, e As EventArgs) Handles tabPhilHealth.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtRates.Clear()
        TxtPosition.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtSSSWISP.Clear()
        TxtPagibigRate.Clear()
        TxtVoluntary.Clear()
        TxtHoliday.Clear()
    End Sub

    Private Sub tabVoluntary_Enter(sender As Object, e As EventArgs) Handles tabVoluntary.Enter
        TxtDepartment.Clear()
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        TxtLeave.Clear()
        TxtAllowance.Clear()
        TxtIncentives.Clear()
        TxtRates.Clear()
        TxtPosition.Clear()
        TxtTaxFixedAmount.Clear()
        TxtTaxMaxSalary.Clear()
        TxtTaxPercentage.Clear()
        TxtSSSEE.Clear()
        TxtSSSMaxSalary.Clear()
        TxtSSSTotal.Clear()
        TxtRates.Clear()
        TxtRateClassification.Clear()
        TxtSSSWISP.Clear()
        txtPhilhealthRate.Clear()
        TxtPagibigRate.Clear()
        TxtHoliday.Clear()
    End Sub

    Private Sub dgManageAllowance_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgManageAllowance.DataError
        MessageBox.Show("Invalid amount of allowance.")
    End Sub

    Private Sub dgManageLeave_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgManageLeave.DataError
        MessageBox.Show("Invalid no. of leave.")
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        TxtFirstname.Clear()
        TxtLastname.Clear()
        TxtUsername.Clear()
        MdlMaintenance.userID = 0
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Dim selectedRow As DataGridViewRow = DgUser.SelectedRows(0)

            ' Retrieve the userID of the selected row (assuming userID is at index 0)
            Dim userID As Integer = selectedRow.Cells(0).Value

            If MsgBox("Are you sure you want to reset the password of this user?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                RunCommand("Update tblusers set password=NULL where userID = '" & userID & "'")
                With com
                    .ExecuteNonQuery()
                    .Parameters.Clear()
                    MsgBox("Password reset")
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DgUser.MouseDown
        ' Check if the right mouse button is clicked
        If e.Button = MouseButtons.Right Then
            ' Check if any row is selected
            If DgUser.SelectedRows.Count > 0 Then
                ' Show the ContextMenuStrip at the mouse click location
                ContextMenuStrip1.Show(DgUser, e.Location)
            End If
        End If
    End Sub
#End Region
End Class