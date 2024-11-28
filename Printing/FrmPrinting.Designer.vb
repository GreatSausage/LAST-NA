<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrinting
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
        Me.CRVPrinting = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CRVPrinting
        '
        Me.CRVPrinting.ActiveViewIndex = -1
        Me.CRVPrinting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVPrinting.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRVPrinting.DisplayStatusBar = False
        Me.CRVPrinting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVPrinting.Location = New System.Drawing.Point(0, 0)
        Me.CRVPrinting.Name = "CRVPrinting"
        Me.CRVPrinting.Size = New System.Drawing.Size(800, 450)
        Me.CRVPrinting.TabIndex = 0
        Me.CRVPrinting.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmPrinting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CRVPrinting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPrinting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Printing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CRVPrinting As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
