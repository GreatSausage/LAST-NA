Imports MySql.Data.MySqlClient

Module MdlEmployee

    ReadOnly connection As New MySqlConnection("server=localhost;port=3306;user id=root;password=052903;database=dbmcpms")

    Public Sub NewEmployee(rfid As String, firstname As String, middlename As String, lastname As String, departmentId As Integer, positionID As Integer, salary As Decimal, hours As Decimal, type As String)
        connection.Open()
        Dim command As New MySqlCommand("INSERT INTO (rfid, firstName, middleName, lastName, departmentID, positionID)          
                                         VALUES (@rfid, @firstName, @middleName, @lastName, @departmentID, @positionID);
                                         SELECT last_insert_id();", connection)
        With command.Parameters
            .AddWithValue("@rfid", rfid)
            .AddWithValue("@firstName", firstname)
            .AddWithValue("@middleName", middlename)
            .AddWithValue("@lastName", lastname)
            .AddWithValue("@departmentID", departmentId)
            .AddWithValue("@positionID", positionID)
        End With
        Dim id As Integer = command.ExecuteScalar()

        Dim commandOne As New MySqlCommand("INSERT INTO tblSalary(employeeID, salary, hours, type) VALUES (@employeeID, @salary, @hours, @type)", connection)
        With commandOne.Parameters
            .AddWithValue("@employeeID", id)
            .AddWithValue("@salary", salary)
            .AddWithValue("@hours", hours)
            .AddWithValue("@type", type)
        End With
        commandOne.ExecuteNonQuery()
        MessageBox.Show("Employee has been added successfuly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Module
