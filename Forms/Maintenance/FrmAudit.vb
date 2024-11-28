Public Class FrmAudit
    Private Sub FrmAudit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As DataTable = DisplayAudit()
        DgAudit.DataSource = dt
    End Sub
End Class