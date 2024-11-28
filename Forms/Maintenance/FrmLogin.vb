Imports MySql.Data.MySqlClient

Public Class FrmLogin
    Dim server As String
    Dim db As String
    Dim serverusername As String
    Dim serverpassword As String
    Dim constring As String
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            server = My.Settings.server
            db = My.Settings.database
            serverusername = My.Settings.userid
            serverpassword = My.Settings.password
            constring = My.Settings.constr

            If String.IsNullOrEmpty(constring) Then
                Exit Sub
            Else
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    conn.ConnectionString = constring
                    conn.Open()
                    CheckAdmin()
                Else
                    conn.ConnectionString = constring
                    conn.Open()
                    CheckAdmin()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            '    If String.IsNullOrEmpty(TxtServer.Text.Trim) Or String.IsNullOrEmpty(TxtDatabase.Text.Trim) Or String.IsNullOrEmpty(TxtServerUsername.Text.Trim) Or String.IsNullOrEmpty(TxtServerPassword.Text.Trim) Then
            '        MsgBox("Fields are required")
            '        Exit Sub
            '    End If
            server = TxtServer.Text.Trim
            db = TxtDatabase.Text.Trim
            serverusername = TxtServerUsername.Text.Trim
            serverpassword = TxtServerPassword.Text.Trim
            constring = "server=" & server & ";user id=" & serverusername & ";password=" & serverpassword & ";database=" & db & ";port=3306"

            My.Settings.server = server
            My.Settings.database = db
            My.Settings.userid = serverusername
            My.Settings.password = serverpassword
            My.Settings.constr = constring
            My.Settings.Save()



            If conn.State = ConnectionState.Open Then
                conn.Close()
                conn.ConnectionString = constring
            Else
                conn.ConnectionString = constring
            End If

            If conn.State = ConnectionState.Closed Then
                conn.Open()
                MsgBox("Successfully Connected to Server")
                CheckAdmin()
                Exit Sub
            Else
                MsgBox("Failed to connect to server")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        If String.IsNullOrEmpty(TxtPassword.Text) OrElse String.IsNullOrEmpty(TxtUsername.Text) Then
            MsgEmptyField()
            Exit Sub
        Else
            If conn.State = ConnectionState.Open Then
                ClassLogin.LoginNa(Me, TxtUsername, TxtPassword)
            Else
                MessageBox.Show("Not connected to server", "Not connected to server", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtUsername.Clear()
                TxtPassword.Clear()
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Close()
    End Sub
End Class