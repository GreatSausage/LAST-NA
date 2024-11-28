<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDepartmentControls
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TCDepartment = New Guna.UI2.WinForms.Guna2TabControl()
        Me.TPDepartmentList = New System.Windows.Forms.TabPage()
        Me.DGDepartment = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.deptID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deptName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deptHead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deptPop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deptStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPDepartmentProfile = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSave = New Guna.UI2.WinForms.Guna2Button()
        Me.CbDepartmentHead = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbDepartment = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCDepartment.SuspendLayout()
        Me.TPDepartmentList.SuspendLayout()
        CType(Me.DGDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPDepartmentProfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'TCDepartment
        '
        Me.TCDepartment.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TCDepartment.Controls.Add(Me.TPDepartmentList)
        Me.TCDepartment.Controls.Add(Me.TPDepartmentProfile)
        Me.TCDepartment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCDepartment.ItemSize = New System.Drawing.Size(180, 40)
        Me.TCDepartment.Location = New System.Drawing.Point(0, 0)
        Me.TCDepartment.Margin = New System.Windows.Forms.Padding(2)
        Me.TCDepartment.Name = "TCDepartment"
        Me.TCDepartment.SelectedIndex = 0
        Me.TCDepartment.Size = New System.Drawing.Size(1173, 658)
        Me.TCDepartment.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty
        Me.TCDepartment.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TCDepartment.TabButtonHoverState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.TCDepartment.TabButtonHoverState.ForeColor = System.Drawing.Color.White
        Me.TCDepartment.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TCDepartment.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty
        Me.TCDepartment.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TCDepartment.TabButtonIdleState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.TCDepartment.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.TCDepartment.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TCDepartment.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty
        Me.TCDepartment.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TCDepartment.TabButtonSelectedState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.TCDepartment.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black
        Me.TCDepartment.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TCDepartment.TabButtonSize = New System.Drawing.Size(180, 40)
        Me.TCDepartment.TabIndex = 2
        Me.TCDepartment.TabMenuBackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        '
        'TPDepartmentList
        '
        Me.TPDepartmentList.Controls.Add(Me.DGDepartment)
        Me.TPDepartmentList.Location = New System.Drawing.Point(184, 4)
        Me.TPDepartmentList.Margin = New System.Windows.Forms.Padding(2)
        Me.TPDepartmentList.Name = "TPDepartmentList"
        Me.TPDepartmentList.Padding = New System.Windows.Forms.Padding(2)
        Me.TPDepartmentList.Size = New System.Drawing.Size(985, 650)
        Me.TPDepartmentList.TabIndex = 0
        Me.TPDepartmentList.Text = "Department List"
        Me.TPDepartmentList.UseVisualStyleBackColor = True
        '
        'DGDepartment
        '
        Me.DGDepartment.AllowUserToAddRows = False
        Me.DGDepartment.AllowUserToDeleteRows = False
        Me.DGDepartment.AllowUserToResizeColumns = False
        Me.DGDepartment.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DGDepartment.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGDepartment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGDepartment.ColumnHeadersHeight = 40
        Me.DGDepartment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.deptID, Me.deptName, Me.deptHead, Me.deptPop, Me.deptStatus})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGDepartment.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGDepartment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGDepartment.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGDepartment.Location = New System.Drawing.Point(2, 2)
        Me.DGDepartment.Margin = New System.Windows.Forms.Padding(2)
        Me.DGDepartment.Name = "DGDepartment"
        Me.DGDepartment.ReadOnly = True
        Me.DGDepartment.RowHeadersVisible = False
        Me.DGDepartment.RowHeadersWidth = 62
        Me.DGDepartment.RowTemplate.Height = 28
        Me.DGDepartment.Size = New System.Drawing.Size(981, 646)
        Me.DGDepartment.TabIndex = 0
        Me.DGDepartment.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DGDepartment.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DGDepartment.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DGDepartment.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DGDepartment.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DGDepartment.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.DGDepartment.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGDepartment.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGDepartment.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGDepartment.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGDepartment.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DGDepartment.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGDepartment.ThemeStyle.HeaderStyle.Height = 40
        Me.DGDepartment.ThemeStyle.ReadOnly = True
        Me.DGDepartment.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.DGDepartment.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DGDepartment.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGDepartment.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DGDepartment.ThemeStyle.RowsStyle.Height = 28
        Me.DGDepartment.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGDepartment.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'deptID
        '
        Me.deptID.DataPropertyName = "departmentID"
        Me.deptID.HeaderText = "Department ID"
        Me.deptID.MinimumWidth = 8
        Me.deptID.Name = "deptID"
        Me.deptID.ReadOnly = True
        Me.deptID.Visible = False
        '
        'deptName
        '
        Me.deptName.DataPropertyName = "departmentName"
        Me.deptName.HeaderText = "Department Name"
        Me.deptName.MinimumWidth = 8
        Me.deptName.Name = "deptName"
        Me.deptName.ReadOnly = True
        '
        'deptHead
        '
        Me.deptHead.DataPropertyName = "departmentHead"
        Me.deptHead.HeaderText = "Department Head"
        Me.deptHead.MinimumWidth = 8
        Me.deptHead.Name = "deptHead"
        Me.deptHead.ReadOnly = True
        '
        'deptPop
        '
        Me.deptPop.DataPropertyName = "departmentPopulation"
        Me.deptPop.HeaderText = "Number of Employees"
        Me.deptPop.MinimumWidth = 8
        Me.deptPop.Name = "deptPop"
        Me.deptPop.ReadOnly = True
        '
        'deptStatus
        '
        Me.deptStatus.DataPropertyName = "status"
        Me.deptStatus.HeaderText = "Status"
        Me.deptStatus.MinimumWidth = 8
        Me.deptStatus.Name = "deptStatus"
        Me.deptStatus.ReadOnly = True
        '
        'TPDepartmentProfile
        '
        Me.TPDepartmentProfile.Controls.Add(Me.Panel2)
        Me.TPDepartmentProfile.Controls.Add(Me.Panel1)
        Me.TPDepartmentProfile.Controls.Add(Me.BtnSave)
        Me.TPDepartmentProfile.Controls.Add(Me.CbDepartmentHead)
        Me.TPDepartmentProfile.Controls.Add(Me.Label2)
        Me.TPDepartmentProfile.Controls.Add(Me.CbDepartment)
        Me.TPDepartmentProfile.Controls.Add(Me.Label4)
        Me.TPDepartmentProfile.Controls.Add(Me.Label1)
        Me.TPDepartmentProfile.Location = New System.Drawing.Point(184, 4)
        Me.TPDepartmentProfile.Margin = New System.Windows.Forms.Padding(2)
        Me.TPDepartmentProfile.Name = "TPDepartmentProfile"
        Me.TPDepartmentProfile.Padding = New System.Windows.Forms.Padding(2)
        Me.TPDepartmentProfile.Size = New System.Drawing.Size(985, 650)
        Me.TPDepartmentProfile.TabIndex = 1
        Me.TPDepartmentProfile.Text = "Department Profile"
        Me.TPDepartmentProfile.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 174)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(981, 5)
        Me.Panel2.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(2, 602)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(981, 5)
        Me.Panel1.TabIndex = 15
        '
        'BtnSave
        '
        Me.BtnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnSave.FillColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BtnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnSave.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Location = New System.Drawing.Point(2, 607)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(981, 41)
        Me.BtnSave.TabIndex = 14
        Me.BtnSave.Text = "SAVE"
        '
        'CbDepartmentHead
        '
        Me.CbDepartmentHead.BackColor = System.Drawing.Color.Transparent
        Me.CbDepartmentHead.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartmentHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.CbDepartmentHead.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbDepartmentHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDepartmentHead.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartmentHead.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartmentHead.FocusedState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartmentHead.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.CbDepartmentHead.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartmentHead.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartmentHead.HoverState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartmentHead.ItemHeight = 30
        Me.CbDepartmentHead.Location = New System.Drawing.Point(2, 138)
        Me.CbDepartmentHead.Margin = New System.Windows.Forms.Padding(2)
        Me.CbDepartmentHead.Name = "CbDepartmentHead"
        Me.CbDepartmentHead.Size = New System.Drawing.Size(981, 36)
        Me.CbDepartmentHead.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 106)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(981, 32)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Department Head Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbDepartment
        '
        Me.CbDepartment.BackColor = System.Drawing.Color.Transparent
        Me.CbDepartment.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartment.Dock = System.Windows.Forms.DockStyle.Top
        Me.CbDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDepartment.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartment.FocusedState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartment.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.CbDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartment.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartment.HoverState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbDepartment.ItemHeight = 30
        Me.CbDepartment.Location = New System.Drawing.Point(2, 70)
        Me.CbDepartment.Margin = New System.Windows.Forms.Padding(2)
        Me.CbDepartment.Name = "CbDepartment"
        Me.CbDepartment.Size = New System.Drawing.Size(981, 36)
        Me.CbDepartment.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 38)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(981, 32)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Department:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(981, 36)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Department Profile"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmDepartmentControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 658)
        Me.ControlBox = False
        Me.Controls.Add(Me.TCDepartment)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmDepartmentControls"
        Me.TCDepartment.ResumeLayout(False)
        Me.TPDepartmentList.ResumeLayout(False)
        CType(Me.DGDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPDepartmentProfile.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TCDepartment As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents TPDepartmentList As TabPage
    Friend WithEvents DGDepartment As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents TPDepartmentProfile As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents CbDepartment As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CbDepartmentHead As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents deptID As DataGridViewTextBoxColumn
    Friend WithEvents deptName As DataGridViewTextBoxColumn
    Friend WithEvents deptHead As DataGridViewTextBoxColumn
    Friend WithEvents deptPop As DataGridViewTextBoxColumn
    Friend WithEvents deptStatus As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
End Class
