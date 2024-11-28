<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReport
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbReport = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.PanelEmployeeList = New Guna.UI2.WinForms.Guna2Panel()
        Me.BtnEmployeeGenerate = New Guna.UI2.WinForms.Guna2Button()
        Me.CbStatus = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelDepartment = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2TextBox1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.BtnDepartment = New Guna.UI2.WinForms.Guna2Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Guna2CustomGradientPanel3 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        Me.Guna2CustomGradientPanel4 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        Me.PanelAttendance = New Guna.UI2.WinForms.Guna2Panel()
        Me.DtpTo = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpFrom = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.BtnAttendanceGenerate = New Guna.UI2.WinForms.Guna2Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2CustomGradientPanel1 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        Me.Guna2CustomGradientPanel2 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        Me.PanelEmployeeList.SuspendLayout()
        Me.PanelDepartment.SuspendLayout()
        Me.Guna2CustomGradientPanel4.SuspendLayout()
        Me.PanelAttendance.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1294, 39)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "PRINT REPORT"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CbReport
        '
        Me.CbReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbReport.BackColor = System.Drawing.Color.Transparent
        Me.CbReport.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbReport.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CbReport.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CbReport.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CbReport.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbReport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.CbReport.ItemHeight = 30
        Me.CbReport.Items.AddRange(New Object() {"Employee List", "Attendance List", "Department List"})
        Me.CbReport.Location = New System.Drawing.Point(401, 21)
        Me.CbReport.Name = "CbReport"
        Me.CbReport.Size = New System.Drawing.Size(492, 36)
        Me.CbReport.TabIndex = 10
        Me.CbReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PanelEmployeeList
        '
        Me.PanelEmployeeList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelEmployeeList.Controls.Add(Me.BtnEmployeeGenerate)
        Me.PanelEmployeeList.Controls.Add(Me.CbStatus)
        Me.PanelEmployeeList.Controls.Add(Me.Label1)
        Me.PanelEmployeeList.Location = New System.Drawing.Point(230, 126)
        Me.PanelEmployeeList.Name = "PanelEmployeeList"
        Me.PanelEmployeeList.Size = New System.Drawing.Size(834, 368)
        Me.PanelEmployeeList.TabIndex = 11
        Me.PanelEmployeeList.Visible = False
        '
        'BtnEmployeeGenerate
        '
        Me.BtnEmployeeGenerate.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnEmployeeGenerate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnEmployeeGenerate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnEmployeeGenerate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnEmployeeGenerate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnEmployeeGenerate.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BtnEmployeeGenerate.ForeColor = System.Drawing.Color.Black
        Me.BtnEmployeeGenerate.Location = New System.Drawing.Point(0, 320)
        Me.BtnEmployeeGenerate.Name = "BtnEmployeeGenerate"
        Me.BtnEmployeeGenerate.Size = New System.Drawing.Size(834, 48)
        Me.BtnEmployeeGenerate.TabIndex = 12
        Me.BtnEmployeeGenerate.Text = "Generate Report"
        '
        'CbStatus
        '
        Me.CbStatus.BackColor = System.Drawing.Color.Transparent
        Me.CbStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.CbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbStatus.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CbStatus.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.CbStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.CbStatus.ItemHeight = 30
        Me.CbStatus.Items.AddRange(New Object() {"Print all", "Regular", "Probationary", "Resigned / Terminated"})
        Me.CbStatus.Location = New System.Drawing.Point(0, 39)
        Me.CbStatus.Name = "CbStatus"
        Me.CbStatus.Size = New System.Drawing.Size(834, 36)
        Me.CbStatus.TabIndex = 11
        Me.CbStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(834, 39)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelDepartment
        '
        Me.PanelDepartment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDepartment.Controls.Add(Me.Guna2TextBox1)
        Me.PanelDepartment.Controls.Add(Me.BtnDepartment)
        Me.PanelDepartment.Controls.Add(Me.Label6)
        Me.PanelDepartment.Location = New System.Drawing.Point(230, 126)
        Me.PanelDepartment.Name = "PanelDepartment"
        Me.PanelDepartment.Size = New System.Drawing.Size(834, 368)
        Me.PanelDepartment.TabIndex = 13
        Me.PanelDepartment.Visible = False
        '
        'Guna2TextBox1
        '
        Me.Guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Guna2TextBox1.DefaultText = "All Department"
        Me.Guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2TextBox1.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2TextBox1.ForeColor = System.Drawing.Color.Black
        Me.Guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.Location = New System.Drawing.Point(0, 39)
        Me.Guna2TextBox1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Guna2TextBox1.Name = "Guna2TextBox1"
        Me.Guna2TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Guna2TextBox1.PlaceholderText = ""
        Me.Guna2TextBox1.SelectedText = ""
        Me.Guna2TextBox1.Size = New System.Drawing.Size(834, 86)
        Me.Guna2TextBox1.TabIndex = 13
        Me.Guna2TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnDepartment
        '
        Me.BtnDepartment.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnDepartment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnDepartment.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnDepartment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnDepartment.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnDepartment.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BtnDepartment.ForeColor = System.Drawing.Color.Black
        Me.BtnDepartment.Location = New System.Drawing.Point(0, 280)
        Me.BtnDepartment.Name = "BtnDepartment"
        Me.BtnDepartment.Size = New System.Drawing.Size(834, 88)
        Me.BtnDepartment.TabIndex = 12
        Me.BtnDepartment.Text = "Generate Report"
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(834, 39)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Department List"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2CustomGradientPanel3
        '
        Me.Guna2CustomGradientPanel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2CustomGradientPanel3.FillColor = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel3.FillColor2 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel3.FillColor3 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel3.FillColor4 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel3.Location = New System.Drawing.Point(0, 500)
        Me.Guna2CustomGradientPanel3.Name = "Guna2CustomGradientPanel3"
        Me.Guna2CustomGradientPanel3.Size = New System.Drawing.Size(1294, 165)
        Me.Guna2CustomGradientPanel3.TabIndex = 16
        '
        'Guna2CustomGradientPanel4
        '
        Me.Guna2CustomGradientPanel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel4.Controls.Add(Me.CbReport)
        Me.Guna2CustomGradientPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2CustomGradientPanel4.FillColor = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel4.FillColor2 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel4.FillColor3 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel4.FillColor4 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel4.Location = New System.Drawing.Point(0, 39)
        Me.Guna2CustomGradientPanel4.Name = "Guna2CustomGradientPanel4"
        Me.Guna2CustomGradientPanel4.Size = New System.Drawing.Size(1294, 81)
        Me.Guna2CustomGradientPanel4.TabIndex = 17
        '
        'PanelAttendance
        '
        Me.PanelAttendance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelAttendance.Controls.Add(Me.DtpTo)
        Me.PanelAttendance.Controls.Add(Me.Label4)
        Me.PanelAttendance.Controls.Add(Me.DtpFrom)
        Me.PanelAttendance.Controls.Add(Me.BtnAttendanceGenerate)
        Me.PanelAttendance.Controls.Add(Me.Label3)
        Me.PanelAttendance.Location = New System.Drawing.Point(230, 126)
        Me.PanelAttendance.Name = "PanelAttendance"
        Me.PanelAttendance.Size = New System.Drawing.Size(834, 368)
        Me.PanelAttendance.TabIndex = 12
        Me.PanelAttendance.Visible = False
        '
        'DtpTo
        '
        Me.DtpTo.Checked = True
        Me.DtpTo.Dock = System.Windows.Forms.DockStyle.Top
        Me.DtpTo.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.DtpTo.Location = New System.Drawing.Point(0, 154)
        Me.DtpTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DtpTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DtpTo.Name = "DtpTo"
        Me.DtpTo.Size = New System.Drawing.Size(834, 76)
        Me.DtpTo.TabIndex = 15
        Me.DtpTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DtpTo.Value = New Date(2024, 11, 24, 18, 53, 22, 989)
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 115)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(834, 39)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "To"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFrom
        '
        Me.DtpFrom.Checked = True
        Me.DtpFrom.Dock = System.Windows.Forms.DockStyle.Top
        Me.DtpFrom.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.DtpFrom.Location = New System.Drawing.Point(0, 39)
        Me.DtpFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DtpFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DtpFrom.Name = "DtpFrom"
        Me.DtpFrom.Size = New System.Drawing.Size(834, 76)
        Me.DtpFrom.TabIndex = 13
        Me.DtpFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DtpFrom.Value = New Date(2024, 11, 24, 18, 53, 22, 989)
        '
        'BtnAttendanceGenerate
        '
        Me.BtnAttendanceGenerate.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnAttendanceGenerate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnAttendanceGenerate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnAttendanceGenerate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnAttendanceGenerate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnAttendanceGenerate.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BtnAttendanceGenerate.ForeColor = System.Drawing.Color.Black
        Me.BtnAttendanceGenerate.Location = New System.Drawing.Point(0, 320)
        Me.BtnAttendanceGenerate.Name = "BtnAttendanceGenerate"
        Me.BtnAttendanceGenerate.Size = New System.Drawing.Size(834, 48)
        Me.BtnAttendanceGenerate.TabIndex = 12
        Me.BtnAttendanceGenerate.Text = "Generate Report"
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(834, 39)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "From"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2CustomGradientPanel1
        '
        Me.Guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Guna2CustomGradientPanel1.FillColor = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel1.Location = New System.Drawing.Point(1069, 120)
        Me.Guna2CustomGradientPanel1.Name = "Guna2CustomGradientPanel1"
        Me.Guna2CustomGradientPanel1.Size = New System.Drawing.Size(225, 380)
        Me.Guna2CustomGradientPanel1.TabIndex = 19
        '
        'Guna2CustomGradientPanel2
        '
        Me.Guna2CustomGradientPanel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Guna2CustomGradientPanel2.FillColor = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.Transparent
        Me.Guna2CustomGradientPanel2.Location = New System.Drawing.Point(0, 120)
        Me.Guna2CustomGradientPanel2.Name = "Guna2CustomGradientPanel2"
        Me.Guna2CustomGradientPanel2.Size = New System.Drawing.Size(225, 380)
        Me.Guna2CustomGradientPanel2.TabIndex = 20
        '
        'FrmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1294, 665)
        Me.ControlBox = False
        Me.Controls.Add(Me.Guna2CustomGradientPanel2)
        Me.Controls.Add(Me.Guna2CustomGradientPanel1)
        Me.Controls.Add(Me.Guna2CustomGradientPanel4)
        Me.Controls.Add(Me.Guna2CustomGradientPanel3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PanelEmployeeList)
        Me.Controls.Add(Me.PanelAttendance)
        Me.Controls.Add(Me.PanelDepartment)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.PanelEmployeeList.ResumeLayout(False)
        Me.PanelDepartment.ResumeLayout(False)
        Me.Guna2CustomGradientPanel4.ResumeLayout(False)
        Me.PanelAttendance.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents CbReport As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents PanelEmployeeList As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents CbStatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents BtnEmployeeGenerate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PanelDepartment As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2TextBox1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents BtnDepartment As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Guna2CustomGradientPanel3 As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents Guna2CustomGradientPanel4 As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents PanelAttendance As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents DtpTo As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents DtpFrom As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents BtnAttendanceGenerate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Guna2CustomGradientPanel1 As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents Guna2CustomGradientPanel2 As Guna.UI2.WinForms.Guna2CustomGradientPanel
End Class
