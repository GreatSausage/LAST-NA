Imports MySql.Data.MySqlClient

Module MdlConnections

    Public conn As New MySqlConnection
    Public ServerConn As New MySqlConnection
    Public com As New MySqlCommand
    Public adp As New MySqlDataAdapter
    Public dt As New DataTable
    Public ds As New DataSet
    Public Sub OpenServerConnection()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub RunQuery(ByVal querystatement As String)
        Try
            adp = New MySqlDataAdapter(querystatement, conn)
            ds = New DataSet
            adp.Fill(ds, "querytable")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub RunCommand(ByVal commandstatement As String)
        Try
            com = New MySqlCommand(commandstatement, conn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function RunScalar(ByVal scalarstatement As String)
        Try
            OpenServerConnection()
            com = New MySqlCommand(scalarstatement, conn)
            Dim scalar As Object = com.ExecuteScalar
            If scalar IsNot Nothing AndAlso Not DBNull.Value.Equals(scalar) Then
                Return scalar.ToString
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
End Module
