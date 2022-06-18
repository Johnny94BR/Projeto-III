
Public Class Transicao

    Public Estado As String
    Public Acao As EnumProj.Direcoes
    Public Recompensa As Double = 0

    Public Sub New()

    End Sub

    Public Sub New(pmEstado As String, pmAcao As EnumProj.Direcoes)
        Me.Estado = pmEstado
        Me.Acao = pmAcao
    End Sub

End Class
