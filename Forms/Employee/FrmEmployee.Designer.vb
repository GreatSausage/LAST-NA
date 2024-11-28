<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEmployee
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TCEmployee = New Guna.UI2.WinForms.Guna2TabControl()
        Me.TPEmployeeList = New System.Windows.Forms.TabPage()
        Me.DGEmployee = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.empID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rfid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MiddleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.positionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPEmployeeProfile = New System.Windows.Forms.TabPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.DGVoluntary = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.voluntaryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.voluntaryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.cbStatus = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RBMonthly = New System.Windows.Forms.RadioButton()
        Me.RBDaily = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtSalary = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnSaveEmployee = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CbPosition = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CbDepartment = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtRFID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtLastName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtMiddleName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtFirstName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCEmployee.SuspendLayout()
        Me.TPEmployeeList.SuspendLayout()
        CType(Me.DGEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPEmployeeProfile.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.DGVoluntary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TCEmployee
        '
        Me.TCEmployee.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TCEmployee.Controls.Add(Me.TPEmployeeList)
        Me.TCEmployee.Controls.Add(Me.TPEmployeeProfile)
        Me.TCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCEmployee.ItemSize = New System.Drawing.Size(180, 40)
        Me.TCEmployee.Location = New System.Drawing.Point(0, 0)
        Me.TCEmployee.Margin = New System.Windows.Forms.Padding(2)
        Me.TCEmployee.Name = "TCEmployee"
        Me.TCEmployee.SelectedIndex = 0
        Me.TCEmployee.Size = New System.Drawing.Size(1386, 974)
        Me.TCEmployee.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty
        Me.TCEmployee.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TCEmployee.TabButtonHoverState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.TCEmployee.TabButtonHoverState.ForeColor = System.Drawing.Color.White
        Me.TCEmployee.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TCEmployee.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty
        Me.TCEmployee.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TCEmployee.TabButtonIdleState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.TCEmployee.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TCEmployee.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TCEmployee.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty
        Me.TCEmployee.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TCEmployee.TabButtonSelectedState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.TCEmployee.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black
        Me.TCEmployee.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TCEmployee.TabButtonSize = New System.Drawing.Size(180, 40)
        Me.TCEmployee.TabIndex = 1
        Me.TCEmployee.TabMenuBackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        '
        'TPEmployeeList
        '
        Me.TPEmployeeList.Controls.Add(Me.DGEmployee)
        Me.TPEmployeeList.Location = New System.Drawing.Point(184, 4)
        Me.TPEmployeeList.Margin = New System.Windows.Forms.Padding(2)
        Me.TPEmployeeList.Name = "TPEmployeeList"
        Me.TPEmployeeList.Padding = New System.Windows.Forms.Padding(2)
        Me.TPEmployeeList.Size = New System.Drawing.Size(1198, 966)
        Me.TPEmployeeList.TabIndex = 0
        Me.TPEmployeeList.Text = "Associates List"
        Me.TPEmployeeList.UseVisualStyleBackColor = True
        '
        'DGEmployee
        '
        Me.DGEmployee.AllowUserToAddRows = False
        Me.DGEmployee.AllowUserToDeleteRows = False
        Me.DGEmployee.AllowUserToResizeColumns = False
        Me.DGEmployee.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DGEmployee.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEmployee.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGEmployee.ColumnHeadersHeight = 40
        Me.DGEmployee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.empID, Me.empNumber, Me.rfid, Me.FirstName, Me.MiddleName, Me.LastName, Me.departmentName, Me.positionName, Me.salary, Me.type, Me.STATUS})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGEmployee.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGEmployee.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGEmployee.Location = New System.Drawing.Point(2, 2)
        Me.DGEmployee.Margin = New System.Windows.Forms.Padding(2)
        Me.DGEmployee.Name = "DGEmployee"
        Me.DGEmployee.ReadOnly = True
        Me.DGEmployee.RowHeadersVisible = False
        Me.DGEmployee.RowHeadersWidth = 62
        Me.DGEmployee.RowTemplate.Height = 28
        Me.DGEmployee.Size = New System.Drawing.Size(1194, 962)
        Me.DGEmployee.TabIndex = 0
        Me.DGEmployee.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DGEmployee.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DGEmployee.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DGEmployee.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DGEmployee.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DGEmployee.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.DGEmployee.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGEmployee.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGEmployee.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGEmployee.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGEmployee.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DGEmployee.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGEmployee.ThemeStyle.HeaderStyle.Height = 40
        Me.DGEmployee.ThemeStyle.ReadOnly = True
        Me.DGEmployee.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.DGEmployee.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DGEmployee.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGEmployee.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DGEmployee.ThemeStyle.RowsStyle.Height = 28
        Me.DGEmployee.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGEmployee.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'empID
        '
        Me.empID.DataPropertyName = "employeeID"
        Me.empID.HeaderText = "ID"
        Me.empID.MinimumWidth = 8
        Me.empID.Name = "empID"
        Me.empID.ReadOnly = True
        Me.empID.Visible = False
        '
        'empNumber
        '
        Me.empNumber.DataPropertyName = "employeeNumber"
        Me.empNumber.HeaderText = "Associate Number"
        Me.empNumber.MinimumWidth = 8
        Me.empNumber.Name = "empNumber"
        Me.empNumber.ReadOnly = True
        '
        'rfid
        '
        Me.rfid.DataPropertyName = "rfidnumber"
        Me.rfid.HeaderText = "RFID Number"
        Me.rfid.MinimumWidth = 8
        Me.rfid.Name = "rfid"
        Me.rfid.ReadOnly = True
        '
        'FirstName
        '
        Me.FirstName.DataPropertyName = "firstname"
        Me.FirstName.HeaderText = "First Name"
        Me.FirstName.MinimumWidth = 8
        Me.FirstName.Name = "FirstName"
        Me.FirstName.ReadOnly = True
        '
        'MiddleName
        '
        Me.MiddleName.DataPropertyName = "middlename"
        Me.MiddleName.HeaderText = "Middle Name"
        Me.MiddleName.MinimumWidth = 8
        Me.MiddleName.Name = "MiddleName"
        Me.MiddleName.ReadOnly = True
        '
        'LastName
        '
        Me.LastName.DataPropertyName = "lastname"
        Me.LastName.HeaderText = "Last Name"
        Me.LastName.MinimumWidth = 8
        Me.LastName.Name = "LastName"
        Me.LastName.ReadOnly = True
        '
        'departmentName
        '
        Me.departmentName.DataPropertyName = "departmentName"
        Me.departmentName.HeaderText = "Department"
        Me.departmentName.MinimumWidth = 8
        Me.departmentName.Name = "departmentName"
        Me.departmentName.ReadOnly = True
        '
        'positionName
        '
        Me.positionName.DataPropertyName = "positionName"
        Me.positionName.HeaderText = "Position"
        Me.positionName.MinimumWidth = 8
        Me.positionName.Name = "positionName"
        Me.positionName.ReadOnly = True
        '
        'salary
        '
        Me.salary.DataPropertyName = "salary"
        Me.salary.HeaderText = "Salary"
        Me.salary.Name = "salary"
        Me.salary.ReadOnly = True
        '
        'type
        '
        Me.type.DataPropertyName = "type"
        Me.type.HeaderText = "Compensation Type"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        '
        'STATUS
        '
        Me.STATUS.DataPropertyName = "status"
        Me.STATUS.HeaderText = "Status"
        Me.STATUS.MinimumWidth = 8
        Me.STATUS.Name = "STATUS"
        Me.STATUS.ReadOnly = True
        '
        'TPEmployeeProfile
        '
        Me.TPEmployeeProfile.Controls.Add(Me.Panel6)
        Me.TPEmployeeProfile.Controls.Add(Me.Label8)
        Me.TPEmployeeProfile.Controls.Add(Me.Panel5)
        Me.TPEmployeeProfile.Controls.Add(Me.BtnSaveEmployee)
        Me.TPEmployeeProfile.Controls.Add(Me.Panel1)
        Me.TPEmployeeProfile.Controls.Add(Me.Label1)
        Me.TPEmployeeProfile.Location = New System.Drawing.Point(184, 4)
        Me.TPEmployeeProfile.Margin = New System.Windows.Forms.Padding(2)
        Me.TPEmployeeProfile.Name = "TPEmployeeProfile"
        Me.TPEmployeeProfile.Padding = New System.Windows.Forms.Padding(2)
        Me.TPEmployeeProfile.Size = New System.Drawing.Size(1198, 966)
        Me.TPEmployeeProfile.TabIndex = 1
        Me.TPEmployeeProfile.Text = "Associate Profile"
        Me.TPEmployeeProfile.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.DGVoluntary)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(2, 327)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1194, 587)
        Me.Panel6.TabIndex = 12
        '
        'DGVoluntary
        '
        Me.DGVoluntary.AllowUserToAddRows = False
        Me.DGVoluntary.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.DGVoluntary.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVoluntary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(231, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(231, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVoluntary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGVoluntary.ColumnHeadersHeight = 40
        Me.DGVoluntary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.voluntaryID, Me.voluntaryName, Me.amount})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVoluntary.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGVoluntary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVoluntary.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVoluntary.Location = New System.Drawing.Point(573, 36)
        Me.DGVoluntary.Margin = New System.Windows.Forms.Padding(2)
        Me.DGVoluntary.Name = "DGVoluntary"
        Me.DGVoluntary.RowHeadersVisible = False
        Me.DGVoluntary.RowHeadersWidth = 51
        Me.DGVoluntary.RowTemplate.Height = 24
        Me.DGVoluntary.Size = New System.Drawing.Size(621, 543)
        Me.DGVoluntary.TabIndex = 5
        Me.DGVoluntary.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DGVoluntary.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DGVoluntary.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DGVoluntary.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DGVoluntary.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DGVoluntary.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.DGVoluntary.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVoluntary.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVoluntary.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGVoluntary.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVoluntary.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DGVoluntary.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGVoluntary.ThemeStyle.HeaderStyle.Height = 40
        Me.DGVoluntary.ThemeStyle.ReadOnly = False
        Me.DGVoluntary.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.DGVoluntary.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DGVoluntary.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVoluntary.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DGVoluntary.ThemeStyle.RowsStyle.Height = 24
        Me.DGVoluntary.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVoluntary.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'voluntaryID
        '
        Me.voluntaryID.DataPropertyName = "voluntaryID"
        Me.voluntaryID.HeaderText = "Voluntary ID"
        Me.voluntaryID.MinimumWidth = 6
        Me.voluntaryID.Name = "voluntaryID"
        Me.voluntaryID.Visible = False
        '
        'voluntaryName
        '
        Me.voluntaryName.DataPropertyName = "name"
        Me.voluntaryName.HeaderText = "Name"
        Me.voluntaryName.MinimumWidth = 8
        Me.voluntaryName.Name = "voluntaryName"
        Me.voluntaryName.ReadOnly = True
        '
        'amount
        '
        Me.amount.DataPropertyName = "amount"
        Me.amount.HeaderText = "Amount"
        Me.amount.MinimumWidth = 8
        Me.amount.Name = "amount"
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(573, 0)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(621, 36)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Voluntary Contributions"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(573, 579)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(621, 8)
        Me.Panel7.TabIndex = 1
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Guna2Button1)
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Controls.Add(Me.cbStatus)
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Controls.Add(Me.RBMonthly)
        Me.Panel8.Controls.Add(Me.RBDaily)
        Me.Panel8.Controls.Add(Me.Label9)
        Me.Panel8.Controls.Add(Me.TxtSalary)
        Me.Panel8.Controls.Add(Me.Label14)
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(573, 587)
        Me.Panel8.TabIndex = 0
        '
        'Guna2Button1
        '
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Button1.FillColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.Location = New System.Drawing.Point(0, 532)
        Me.Guna2Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(533, 50)
        Me.Guna2Button1.TabIndex = 22
        Me.Guna2Button1.Text = "CLEAR"
        '
        'Panel10
        '
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 582)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(533, 5)
        Me.Panel10.TabIndex = 21
        '
        'cbStatus
        '
        Me.cbStatus.BackColor = System.Drawing.Color.Transparent
        Me.cbStatus.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cbStatus.BorderRadius = 5
        Me.cbStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cbStatus.ItemHeight = 30
        Me.cbStatus.Items.AddRange(New Object() {"Probationary", "Regular", "Resigned"})
        Me.cbStatus.Location = New System.Drawing.Point(0, 207)
        Me.cbStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(533, 36)
        Me.cbStatus.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 168)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(533, 39)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Associate Status:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RBMonthly
        '
        Me.RBMonthly.Dock = System.Windows.Forms.DockStyle.Top
        Me.RBMonthly.Location = New System.Drawing.Point(0, 141)
        Me.RBMonthly.Margin = New System.Windows.Forms.Padding(2)
        Me.RBMonthly.Name = "RBMonthly"
        Me.RBMonthly.Size = New System.Drawing.Size(533, 27)
        Me.RBMonthly.TabIndex = 14
        Me.RBMonthly.TabStop = True
        Me.RBMonthly.Text = "Monthly"
        Me.RBMonthly.UseVisualStyleBackColor = True
        '
        'RBDaily
        '
        Me.RBDaily.Dock = System.Windows.Forms.DockStyle.Top
        Me.RBDaily.Location = New System.Drawing.Point(0, 114)
        Me.RBDaily.Margin = New System.Windows.Forms.Padding(2)
        Me.RBDaily.Name = "RBDaily"
        Me.RBDaily.Size = New System.Drawing.Size(533, 27)
        Me.RBDaily.TabIndex = 13
        Me.RBDaily.TabStop = True
        Me.RBDaily.Text = "Daily"
        Me.RBDaily.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 75)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(533, 39)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Compensation Type:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TxtSalary
        '
        Me.TxtSalary.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtSalary.BorderRadius = 5
        Me.TxtSalary.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSalary.DefaultText = ""
        Me.TxtSalary.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TxtSalary.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TxtSalary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtSalary.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtSalary.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtSalary.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtSalary.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtSalary.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtSalary.Location = New System.Drawing.Point(0, 39)
        Me.TxtSalary.MaxLength = 20
        Me.TxtSalary.Name = "TxtSalary"
        Me.TxtSalary.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtSalary.PlaceholderText = ""
        Me.TxtSalary.SelectedText = ""
        Me.TxtSalary.Size = New System.Drawing.Size(533, 36)
        Me.TxtSalary.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(533, 39)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Salary:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel9
        '
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel9.Location = New System.Drawing.Point(533, 0)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(40, 587)
        Me.Panel9.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 291)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(1194, 36)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Salary"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(2, 288)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1194, 3)
        Me.Panel5.TabIndex = 9
        '
        'BtnSaveEmployee
        '
        Me.BtnSaveEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnSaveEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnSaveEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnSaveEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnSaveEmployee.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnSaveEmployee.FillColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BtnSaveEmployee.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnSaveEmployee.ForeColor = System.Drawing.Color.White
        Me.BtnSaveEmployee.Location = New System.Drawing.Point(2, 914)
        Me.BtnSaveEmployee.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSaveEmployee.Name = "BtnSaveEmployee"
        Me.BtnSaveEmployee.Size = New System.Drawing.Size(1194, 50)
        Me.BtnSaveEmployee.TabIndex = 6
        Me.BtnSaveEmployee.Text = "SAVE"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CbPosition)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.CbDepartment)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TxtRFID)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 38)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1194, 250)
        Me.Panel1.TabIndex = 8
        '
        'CbPosition
        '
        Me.CbPosition.BackColor = System.Drawing.Color.Transparent
        Me.CbPosition.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.CbPosition.BorderRadius = 5
        Me.CbPosition.Dock = System.Windows.Forms.DockStyle.Top
        Me.CbPosition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPosition.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CbPosition.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CbPosition.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CbPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.CbPosition.ItemHeight = 30
        Me.CbPosition.Location = New System.Drawing.Point(613, 189)
        Me.CbPosition.Margin = New System.Windows.Forms.Padding(2)
        Me.CbPosition.Name = "CbPosition"
        Me.CbPosition.Size = New System.Drawing.Size(581, 36)
        Me.CbPosition.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(613, 150)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(581, 39)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Position:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'CbDepartment
        '
        Me.CbDepartment.BackColor = System.Drawing.Color.Transparent
        Me.CbDepartment.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.CbDepartment.BorderRadius = 5
        Me.CbDepartment.Dock = System.Windows.Forms.DockStyle.Top
        Me.CbDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDepartment.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CbDepartment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CbDepartment.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CbDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.CbDepartment.ItemHeight = 30
        Me.CbDepartment.Location = New System.Drawing.Point(613, 114)
        Me.CbDepartment.Margin = New System.Windows.Forms.Padding(2)
        Me.CbDepartment.Name = "CbDepartment"
        Me.CbDepartment.Size = New System.Drawing.Size(581, 36)
        Me.CbDepartment.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(613, 75)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(581, 39)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Department:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TxtRFID
        '
        Me.TxtRFID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtRFID.BorderRadius = 5
        Me.TxtRFID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtRFID.DefaultText = ""
        Me.TxtRFID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TxtRFID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TxtRFID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtRFID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtRFID.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtRFID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtRFID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtRFID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtRFID.Location = New System.Drawing.Point(613, 39)
        Me.TxtRFID.MaxLength = 10
        Me.TxtRFID.Name = "TxtRFID"
        Me.TxtRFID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtRFID.PlaceholderText = ""
        Me.TxtRFID.SelectedText = ""
        Me.TxtRFID.Size = New System.Drawing.Size(581, 36)
        Me.TxtRFID.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(613, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(581, 39)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "RFID Number:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(573, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(40, 250)
        Me.Panel4.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtLastName)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TxtMiddleName)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TxtFirstName)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(573, 250)
        Me.Panel2.TabIndex = 0
        '
        'TxtLastName
        '
        Me.TxtLastName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtLastName.BorderRadius = 5
        Me.TxtLastName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtLastName.DefaultText = ""
        Me.TxtLastName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TxtLastName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TxtLastName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtLastName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtLastName.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtLastName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtLastName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtLastName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtLastName.Location = New System.Drawing.Point(0, 189)
        Me.TxtLastName.MaxLength = 45
        Me.TxtLastName.Name = "TxtLastName"
        Me.TxtLastName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtLastName.PlaceholderText = ""
        Me.TxtLastName.SelectedText = ""
        Me.TxtLastName.Size = New System.Drawing.Size(533, 36)
        Me.TxtLastName.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 150)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(533, 39)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Last Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TxtMiddleName
        '
        Me.TxtMiddleName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtMiddleName.BorderRadius = 5
        Me.TxtMiddleName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtMiddleName.DefaultText = ""
        Me.TxtMiddleName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TxtMiddleName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TxtMiddleName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtMiddleName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtMiddleName.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMiddleName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtMiddleName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtMiddleName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtMiddleName.Location = New System.Drawing.Point(0, 114)
        Me.TxtMiddleName.MaxLength = 45
        Me.TxtMiddleName.Name = "TxtMiddleName"
        Me.TxtMiddleName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtMiddleName.PlaceholderText = ""
        Me.TxtMiddleName.SelectedText = ""
        Me.TxtMiddleName.Size = New System.Drawing.Size(533, 36)
        Me.TxtMiddleName.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(533, 39)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Middle Name:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TxtFirstName
        '
        Me.TxtFirstName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtFirstName.BorderRadius = 5
        Me.TxtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtFirstName.DefaultText = ""
        Me.TxtFirstName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TxtFirstName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TxtFirstName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtFirstName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TxtFirstName.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtFirstName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtFirstName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFirstName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TxtFirstName.Location = New System.Drawing.Point(0, 39)
        Me.TxtFirstName.MaxLength = 45
        Me.TxtFirstName.Name = "TxtFirstName"
        Me.TxtFirstName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtFirstName.PlaceholderText = ""
        Me.TxtFirstName.SelectedText = ""
        Me.TxtFirstName.Size = New System.Drawing.Size(533, 36)
        Me.TxtFirstName.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(533, 39)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "First Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(533, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(40, 250)
        Me.Panel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1194, 36)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Personal Information"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(156, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.ToolStripMenuItem1.Text = "Reset Password"
        '
        'FrmEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1386, 974)
        Me.ControlBox = False
        Me.Controls.Add(Me.TCEmployee)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmEmployee"
        Me.TCEmployee.ResumeLayout(False)
        Me.TPEmployeeList.ResumeLayout(False)
        CType(Me.DGEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPEmployeeProfile.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.DGVoluntary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TCEmployee As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents TPEmployeeList As TabPage
    Friend WithEvents TPEmployeeProfile As TabPage
    Friend WithEvents BtnSaveEmployee As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents DGEmployee As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TxtFirstName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents CbDepartment As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtRFID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtLastName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtMiddleName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CbPosition As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents DGVoluntary As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents RBMonthly As RadioButton
    Friend WithEvents RBDaily As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtSalary As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents cbStatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents voluntaryID As DataGridViewTextBoxColumn
    Friend WithEvents voluntaryName As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Panel10 As Panel
    Friend WithEvents empID As DataGridViewTextBoxColumn
    Friend WithEvents empNumber As DataGridViewTextBoxColumn
    Friend WithEvents rfid As DataGridViewTextBoxColumn
    Friend WithEvents FirstName As DataGridViewTextBoxColumn
    Friend WithEvents MiddleName As DataGridViewTextBoxColumn
    Friend WithEvents LastName As DataGridViewTextBoxColumn
    Friend WithEvents departmentName As DataGridViewTextBoxColumn
    Friend WithEvents positionName As DataGridViewTextBoxColumn
    Friend WithEvents salary As DataGridViewTextBoxColumn
    Friend WithEvents type As DataGridViewTextBoxColumn
    Friend WithEvents STATUS As DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
End Class
