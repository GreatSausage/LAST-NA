<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2Button4 = New Guna.UI2.WinForms.Guna2Button()
        Me.LblPos = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.DisplayDate = New System.Windows.Forms.Label()
        Me.DisplayTime = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnAudit = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button14 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button11 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button3 = New Guna.UI2.WinForms.Guna2Button()
        Me.BtnEmployee = New Guna.UI2.WinForms.Guna2Button()
        Me.BtnMaintenance = New Guna.UI2.WinForms.Guna2Button()
        Me.displaypanel = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Guna2Button4)
        Me.Panel1.Controls.Add(Me.LblPos)
        Me.Panel1.Controls.Add(Me.LblName)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1454, 167)
        Me.Panel1.TabIndex = 1
        '
        'Guna2Button4
        '
        Me.Guna2Button4.AutoRoundedCorners = True
        Me.Guna2Button4.BorderRadius = 13
        Me.Guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button4.ForeColor = System.Drawing.Color.White
        Me.Guna2Button4.Location = New System.Drawing.Point(180, 115)
        Me.Guna2Button4.Name = "Guna2Button4"
        Me.Guna2Button4.Size = New System.Drawing.Size(180, 28)
        Me.Guna2Button4.TabIndex = 4
        Me.Guna2Button4.Text = "Logout"
        '
        'LblPos
        '
        Me.LblPos.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblPos.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPos.ForeColor = System.Drawing.Color.White
        Me.LblPos.Location = New System.Drawing.Point(170, 85)
        Me.LblPos.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblPos.Name = "LblPos"
        Me.LblPos.Size = New System.Drawing.Size(1061, 27)
        Me.LblPos.TabIndex = 3
        Me.LblPos.Text = " Admin"
        '
        'LblName
        '
        Me.LblName.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblName.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.ForeColor = System.Drawing.Color.White
        Me.LblName.Location = New System.Drawing.Point(170, 0)
        Me.LblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(1061, 85)
        Me.LblName.TabIndex = 2
        Me.LblName.Text = "Villena, Clifford T."
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.DisplayDate)
        Me.Panel8.Controls.Add(Me.DisplayTime)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(1231, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(223, 167)
        Me.Panel8.TabIndex = 1
        '
        'DisplayDate
        '
        Me.DisplayDate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DisplayDate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplayDate.ForeColor = System.Drawing.Color.White
        Me.DisplayDate.Location = New System.Drawing.Point(0, 20)
        Me.DisplayDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.DisplayDate.Name = "DisplayDate"
        Me.DisplayDate.Size = New System.Drawing.Size(223, 65)
        Me.DisplayDate.TabIndex = 1
        Me.DisplayDate.Text = "Label4"
        Me.DisplayDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'DisplayTime
        '
        Me.DisplayTime.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DisplayTime.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplayTime.ForeColor = System.Drawing.Color.White
        Me.DisplayTime.Location = New System.Drawing.Point(0, 85)
        Me.DisplayTime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.DisplayTime.Name = "DisplayTime"
        Me.DisplayTime.Size = New System.Drawing.Size(223, 82)
        Me.DisplayTime.TabIndex = 0
        Me.DisplayTime.Text = "Label3"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(170, 167)
        Me.Panel2.TabIndex = 0
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2CirclePictureBox1.Image = CType(resources.GetObject("Guna2CirclePictureBox1.Image"), System.Drawing.Image)
        Me.Guna2CirclePictureBox1.ImageRotate = 0!
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(22, 24)
        Me.Guna2CirclePictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(126, 119)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Guna2CirclePictureBox1.TabIndex = 1
        Me.Guna2CirclePictureBox1.TabStop = False
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 24)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(22, 119)
        Me.Panel7.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(148, 24)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(22, 119)
        Me.Panel6.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 143)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(170, 24)
        Me.Panel5.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(170, 24)
        Me.Panel4.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnAudit)
        Me.Panel3.Controls.Add(Me.Guna2Button14)
        Me.Panel3.Controls.Add(Me.Guna2Button11)
        Me.Panel3.Controls.Add(Me.Guna2Button3)
        Me.Panel3.Controls.Add(Me.BtnEmployee)
        Me.Panel3.Controls.Add(Me.BtnMaintenance)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 167)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1454, 41)
        Me.Panel3.TabIndex = 2
        '
        'BtnAudit
        '
        Me.BtnAudit.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.BtnAudit.BorderThickness = 1
        Me.BtnAudit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnAudit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnAudit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnAudit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnAudit.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnAudit.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.BtnAudit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnAudit.ForeColor = System.Drawing.Color.Black
        Me.BtnAudit.Location = New System.Drawing.Point(900, 0)
        Me.BtnAudit.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnAudit.Name = "BtnAudit"
        Me.BtnAudit.Size = New System.Drawing.Size(180, 41)
        Me.BtnAudit.TabIndex = 6
        Me.BtnAudit.Text = "Audit Trail"
        '
        'Guna2Button14
        '
        Me.Guna2Button14.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Guna2Button14.BorderThickness = 1
        Me.Guna2Button14.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button14.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button14.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button14.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Guna2Button14.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Guna2Button14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button14.ForeColor = System.Drawing.Color.Black
        Me.Guna2Button14.Location = New System.Drawing.Point(720, 0)
        Me.Guna2Button14.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2Button14.Name = "Guna2Button14"
        Me.Guna2Button14.Size = New System.Drawing.Size(180, 41)
        Me.Guna2Button14.TabIndex = 5
        Me.Guna2Button14.Text = "Reports"
        '
        'Guna2Button11
        '
        Me.Guna2Button11.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Guna2Button11.BorderThickness = 1
        Me.Guna2Button11.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button11.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button11.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button11.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Guna2Button11.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Guna2Button11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button11.ForeColor = System.Drawing.Color.Black
        Me.Guna2Button11.Location = New System.Drawing.Point(540, 0)
        Me.Guna2Button11.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2Button11.Name = "Guna2Button11"
        Me.Guna2Button11.Size = New System.Drawing.Size(180, 41)
        Me.Guna2Button11.TabIndex = 4
        Me.Guna2Button11.Text = "Payroll Calculations"
        '
        'Guna2Button3
        '
        Me.Guna2Button3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Guna2Button3.BorderThickness = 1
        Me.Guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Guna2Button3.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Guna2Button3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button3.ForeColor = System.Drawing.Color.Black
        Me.Guna2Button3.Location = New System.Drawing.Point(360, 0)
        Me.Guna2Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2Button3.Name = "Guna2Button3"
        Me.Guna2Button3.Size = New System.Drawing.Size(180, 41)
        Me.Guna2Button3.TabIndex = 2
        Me.Guna2Button3.Text = "Department Controls"
        '
        'BtnEmployee
        '
        Me.BtnEmployee.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.BtnEmployee.BorderThickness = 1
        Me.BtnEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnEmployee.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnEmployee.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.BtnEmployee.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnEmployee.ForeColor = System.Drawing.Color.Black
        Me.BtnEmployee.Location = New System.Drawing.Point(180, 0)
        Me.BtnEmployee.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnEmployee.Name = "BtnEmployee"
        Me.BtnEmployee.Size = New System.Drawing.Size(180, 41)
        Me.BtnEmployee.TabIndex = 1
        Me.BtnEmployee.Text = "Associate Controls"
        '
        'BtnMaintenance
        '
        Me.BtnMaintenance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.BtnMaintenance.BorderThickness = 1
        Me.BtnMaintenance.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnMaintenance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnMaintenance.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnMaintenance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnMaintenance.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnMaintenance.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.BtnMaintenance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnMaintenance.ForeColor = System.Drawing.Color.Black
        Me.BtnMaintenance.Location = New System.Drawing.Point(0, 0)
        Me.BtnMaintenance.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnMaintenance.Name = "BtnMaintenance"
        Me.BtnMaintenance.Size = New System.Drawing.Size(180, 41)
        Me.BtnMaintenance.TabIndex = 0
        Me.BtnMaintenance.Text = "Maintenance"
        '
        'displaypanel
        '
        Me.displaypanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.displaypanel.Location = New System.Drawing.Point(0, 208)
        Me.displaypanel.Margin = New System.Windows.Forms.Padding(2)
        Me.displaypanel.Name = "displaypanel"
        Me.displaypanel.Size = New System.Drawing.Size(1454, 507)
        Me.displaypanel.TabIndex = 3
        '
        'Timer1
        '
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1454, 715)
        Me.ControlBox = False
        Me.Controls.Add(Me.displaypanel)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Guna2Button14 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button11 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BtnEmployee As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BtnMaintenance As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents displaypanel As Panel
    Friend WithEvents BtnAudit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LblPos As Label
    Friend WithEvents LblName As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents DisplayDate As Label
    Friend WithEvents DisplayTime As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Guna2Button4 As Guna.UI2.WinForms.Guna2Button
End Class
