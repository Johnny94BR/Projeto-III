

Public Class TelaInicial

    Private Sub lblStart_Click(sender As Object, e As EventArgs) Handles lblStart.Click
        Dim frmtela As New Start
        Me.Close()
    End Sub

    Private Sub TelaInicial_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                e.Handled = True
        End Select
    End Sub
End Class
