Imports System.ComponentModel

Public Class FrmPrinting
    Private Sub FrmPrinting_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FrmMain.Enabled = True
    End Sub

    Private Sub FrmPrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenServerConnection()
    End Sub
End Class