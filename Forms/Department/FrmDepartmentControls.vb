Public Class FrmDepartmentControls
    Private Sub TPDepartmentList_Enter(sender As Object, e As EventArgs) Handles TPDepartmentList.Enter
        ClassDepartment.LoadDepartmentDG(DGDepartment)
    End Sub
    Private Sub FrmDepartmentControls_Load(sender As Object, e As EventArgs) Handles Me.Load
        OpenServerConnection()
        ClassDepartment.LoadDepartmentDG(DGDepartment)
    End Sub
    Private Sub TPDepartmentProfile_Enter(sender As Object, e As EventArgs) Handles TPDepartmentProfile.Enter
        ClassDepartment.LoadDepartment(CbDepartment)
        ClassDepartment.LoadDepartmentHead(CbDepartmentHead, CbDepartment)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If CbDepartment.SelectedIndex = -1 Then
            MsgEmptyField()
            Exit Sub
        ElseIf CbDepartmentHead.SelectedIndex = -1 Then
            MsgEmptyField()
            Exit Sub
        End If
        ClassDepartment.SaveDepartmentHead(DGDepartment)
    End Sub

    Private Sub CbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbDepartment.SelectedIndexChanged
        Try
            If CbDepartment.SelectedIndex = -1 Then
                Exit Sub
            End If
            ClassDepartment.LoadDepartmentHead(CbDepartmentHead, CbDepartment)

        Catch ex As Exception
        End Try
    End Sub
End Class