<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAudit
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
        Me.DgAudit = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.auditID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateActed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgAudit
        '
        Me.DgAudit.AllowUserToAddRows = False
        Me.DgAudit.AllowUserToDeleteRows = False
        Me.DgAudit.AllowUserToResizeColumns = False
        Me.DgAudit.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DgAudit.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgAudit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(231, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(231, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgAudit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgAudit.ColumnHeadersHeight = 40
        Me.DgAudit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.auditID, Me.action, Me.dateActed})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgAudit.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgAudit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgAudit.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DgAudit.Location = New System.Drawing.Point(0, 0)
        Me.DgAudit.Margin = New System.Windows.Forms.Padding(2)
        Me.DgAudit.Name = "DgAudit"
        Me.DgAudit.ReadOnly = True
        Me.DgAudit.RowHeadersVisible = False
        Me.DgAudit.RowHeadersWidth = 51
        Me.DgAudit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgAudit.RowTemplate.Height = 24
        Me.DgAudit.Size = New System.Drawing.Size(1745, 667)
        Me.DgAudit.TabIndex = 4
        Me.DgAudit.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DgAudit.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.DgAudit.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.DgAudit.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.DgAudit.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.DgAudit.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.DgAudit.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DgAudit.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DgAudit.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DgAudit.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgAudit.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DgAudit.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgAudit.ThemeStyle.HeaderStyle.Height = 40
        Me.DgAudit.ThemeStyle.ReadOnly = True
        Me.DgAudit.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.DgAudit.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgAudit.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgAudit.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DgAudit.ThemeStyle.RowsStyle.Height = 24
        Me.DgAudit.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DgAudit.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'auditID
        '
        Me.auditID.DataPropertyName = "auditID"
        Me.auditID.HeaderText = "Audit ID"
        Me.auditID.Name = "auditID"
        Me.auditID.ReadOnly = True
        Me.auditID.Visible = False
        '
        'action
        '
        Me.action.DataPropertyName = "action"
        Me.action.HeaderText = ""
        Me.action.Name = "action"
        Me.action.ReadOnly = True
        '
        'dateActed
        '
        Me.dateActed.DataPropertyName = "dateActed"
        Me.dateActed.HeaderText = "Date"
        Me.dateActed.Name = "dateActed"
        Me.dateActed.ReadOnly = True
        '
        'FrmAudit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1745, 667)
        Me.ControlBox = False
        Me.Controls.Add(Me.DgAudit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmAudit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DgAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgAudit As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents auditID As DataGridViewTextBoxColumn
    Friend WithEvents action As DataGridViewTextBoxColumn
    Friend WithEvents dateActed As DataGridViewTextBoxColumn
End Class
