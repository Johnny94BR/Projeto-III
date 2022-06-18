Public Class TelaInicial

    Dim lstRecompensas As New List(Of Recompensa)

    Dim lstTransicoes As New List(Of Transicao)

    Dim EstadoAtual As String = "s77"

    Dim DadosTab As DadosPanel

    Structure DadosPanel
        Dim Linha As Integer
        Dim Coluna As Integer
        Dim Estado As Integer
    End Structure



    Public Sub New()

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        Me.Inicializa()


    End Sub

    Private Sub Q(pmEstado As String, tes As String)

    End Sub

    Private Sub Inicializa()

        For Each tbl As Panel In Me.tblPanel.Controls

            For Each ctrl As Control In tbl.Controls
                If ctrl.Name.Contains("TextBox") Then
                    CriaTransicoes(CInt(ctrl.Text), tbl.Name)
                End If
            Next
            Me.lstRecompensas.Add(New Recompensa() With {.Estado = tbl.Name})
        Next


        Me.lstRecompensas.ForEach(Sub(p)
                                      Select Case p.Estado
                                          Case 60
                                              p.Recompensa = 100
                                          Case "s25", "s14", "s27", "s38", "s5", "s31", "s63", "s33", "s45", "s34", "s12", "s24", "s75"
                                              p.Recompensa = -100
                                          Case Else
                                              p.Recompensa = 1
                                      End Select
                                  End Sub)

    End Sub

    Private Sub CriaTransicoes(pmTipoDirecao As Integer, pmestado As String)

        Select Case pmTipoDirecao
            Case 0
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Leste))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Sul))
            Case 1
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Oeste))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Leste))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Sul))
            Case 2
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Oeste))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Sul))
            Case 3
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Norte))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Leste))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Sul))
            Case 4
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Norte))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Oeste))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Leste))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Sul))
            Case 5
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Norte))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Oeste))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Sul))
            Case 6
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Norte))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Leste))
            Case 7
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Norte))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Oeste))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Leste))
            Case 8
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Norte))
                Me.lstTransicoes.Add(New Transicao(pmestado, EnumProj.Direcoes.Oeste))
        End Select

    End Sub



    Private Sub teste()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.s2.Controls.Add(Me.pbCarro)

        For Each objtransicao As Transicao In Me.lstTransicoes.FindAll(Function(x)
                                                                           Return x.Estado = Me.EstadoAtual
                                                                       End Function)
            Me.txtInfo.Text = String.Concat(Me.txtInfo.Text, vbCrLf, objtransicao.Acao)
        Next

    End Sub

End Class
