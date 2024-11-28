Imports MySql.Data.MySqlClient

Module MdlFunctions

    Public letterOnly As String = "^[A-Za-z]+(?: [A-Za-z]+)*$"
    Public numberOnly As String = "^[0-9]+(\.[0-9]{1,2})?$"
    Public noSpace As String = "^\S*$"
    Public antiSpace As String = "^[^ ]+$"
    Public forNames As String = "^[a-zA-ZÑñ](?!.*[-']{2})[a-zA-ZÑñ,'-]*( [a-zA-ZÑñ](?!.*[-']{2})[a-zA-ZÑñ,'-]*)*$"
    Public forPrice As String = "^\d+(\.\d{1,})?$"
    Public singleSpace As String = "^[^\s]+(\s[^\s]+)*$"
    Public timePattern As String = "^([01]\d|2[0-3]):[0-5]\d$"

    Public Sub MsgEmptyField()
        MessageBox.Show("Please fill in the necessary fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Sub MsgLetterOnly()
        MessageBox.Show("This contains letter only.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Sub NamesMessaegbox()
        MessageBox.Show("Invalid names.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Sub MsgNumberOnly()
        MessageBox.Show("This contains number only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Sub DisplayFormPanel(frm As Form, displayPanel As Panel)
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        displayPanel.Controls.Clear()
        displayPanel.Controls.Add(frm)
        frm.Show()
    End Sub

    Public Sub Auditing(action As String)
        Dim command As New MySqlCommand("INSERT INTO tblaudit (action, dateActed) VALUES (@action, NOW())", conn)
        command.Parameters.AddWithValue("@action", action)
        command.ExecuteNonQuery()

        Dim dt As DataTable = DisplayAudit()
        FrmAudit.DgAudit.DataSource = dt
    End Sub

    Public Function DisplayAudit() As DataTable
        Dim command As New MySqlCommand("SELECT * FROM tblaudit", conn)
        Dim dt As New DataTable
        Dim adapter As New MySqlDataAdapter(command)
        adapter.Fill(dt)
        Return dt
    End Function
End Module
