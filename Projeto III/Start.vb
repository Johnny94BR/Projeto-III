
Imports System.Threading
Public Class Start

    Dim lstRecompensas As New List(Of Recompensa)

    Dim lstTransicoes As New List(Of Transicao)

    Dim EstadoAtual As String = "s113"

    Dim Pause As Boolean = False

    Dim Iniciado As Boolean = False

    Dim Reiniciar As Boolean = False

    Dim rnd() As String = {"max", "max", "rnd", "max", "max", "rnd", "max", "max", "rnd", "max"}


    Public Sub New()

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        Me.MinimumSize = Me.Size
        Me.Inicializa()
        Me.CriaGrid()
        Me.ShowDialog()
        Me.CriaGrid()


    End Sub


    Private Sub Inicializa()

        Me.lstRecompensas = New List(Of Recompensa)

        Me.lstTransicoes = New List(Of Transicao)

        Me.EstadoAtual = "s113"

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
                                          Case "s60"
                                              p.Recompensa = 100
                                          Case "s5", "s12", "s14", "s24", "s25", "s27", "s31", "s33", "s34", "s38", "s45", "s67", "s103"
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



    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' fazendo o Gerador static, preservamos a mesma instância
        ' assim não precisamos criar novas instância com a mesma semente 
        ' entre as chamadas
        Static Gerador As System.Random = New System.Random(TimeOfDay.Millisecond)
        Dim Numero As Integer = Gerador.Next(Min, Max)
        Return Numero
    End Function

    Private Sub Inicia()

        Dim cont As Integer = 0

        Me.Iniciado = True
        Invoke(Sub() Me.BtnIniciar.Text = "Reiniciar")

        While (Me.EstadoAtual <> "s60")

            Dim i As Integer = 0

            If Reiniciar Then
                Me.Reiniciar = False
                Me.FinalCiclo()
                Me.Inicializa()
                Exit Sub
            End If


            While (Me.Pause)

            End While

            Dim lstTransicao As New List(Of Transicao)

            'escolhe qual caminho aqui
            Me.RetornaRecompensas(lstTransicao)

            Dim Recompensa As Double = 0
            Dim Acao As EnumProj.Direcoes

            lstTransicao.ForEach(Sub(x)
                                     If x.Recompensa >= Recompensa Then
                                         Recompensa = x.Recompensa
                                         Acao = x.Acao
                                     End If
                                 End Sub)

            Dim Aleatorio As Integer
            If Me.rnd(Me.GetRandom(0, 9)) = "rnd" Then
                'If Me.rnd(Me.GetRandom(0, 9)) = "rnd" Then
                Aleatorio = Me.GetRandom(0, lstTransicao.Count)
                Recompensa = lstTransicao(Aleatorio).Recompensa
                Acao = lstTransicao(Aleatorio).Acao
            Else
                If Recompensa = 0 Then
                    Aleatorio = Me.GetRandom(0, lstTransicao.Count)
                    Recompensa = lstTransicao(Aleatorio).Recompensa
                    Acao = lstTransicao(Aleatorio).Acao
                End If
            End If
            If i = 9 Then
                i = 0
            Else
                i += 1
            End If
            Dim NovoEstado As String = Me.RetornaEstado(Me.EstadoAtual, Acao)

            Me.AtualizaQ(Acao, NovoEstado)
            cont += 1
            Me.Invoke(Sub() Me.lblEstado.Text = Me.EstadoAtual)
            Me.Invoke(Sub() Me.lblEstado.Refresh())
            Dim t As List(Of Transicao) = Me.lstTransicoes.FindAll(Function(p) p.Recompensa > 0)
        End While

        MsgBox(String.Concat("Foram feitas ", cont, " transições até chegar ao destino!"), MsgBoxStyle.Information)

        Me.FinalCiclo()

    End Sub

    Private Sub FinalCiclo()
        Invoke(Sub() Me.BtnIniciar.Text = "Iniciar")
        Me.EstadoAtual = "s113"
        Invoke(Sub() Me.s113.Controls.Add(Me.pbcarro))
        Me.Iniciado = False
    End Sub


    Private Sub AtualizaQ(pmAcao As EnumProj.Direcoes, pmEstadoNovo As String)
        'Q(s1, a12):
        'Q(s1, a12) = r + 0.5 * max(Q(s2, a21),
        'Q(s2, a25), Q(s2, a23))
        Me.lstTransicoes.Find(Function(p) p.Estado = Me.EstadoAtual And p.Acao = pmAcao).Recompensa = Me.r(Me.EstadoAtual) + Me.txtY.Text * Me.Max(pmEstadoNovo)
        If pmEstadoNovo = "s60" Then Me.lstTransicoes.Find(Function(p) p.Estado = Me.EstadoAtual And p.Acao = pmAcao).Recompensa = 100
        Me.EstadoAtual = pmEstadoNovo
        Me.MudaCarrinho()
    End Sub

    Private Function Max(pmEstado As String) As Double
        Dim Recompensa As Double = 0

        Me.lstTransicoes.FindAll(Function(p) p.Estado = pmEstado).ForEach(Sub(x)
                                                                              If x.Recompensa > Recompensa Then
                                                                                  Recompensa = x.Recompensa
                                                                              End If
                                                                          End Sub)

        Return Recompensa
    End Function

    Private Function r(pmEstado As String) As Double
        Return Me.lstRecompensas.Find(Function(x) x.Estado = pmEstado).Recompensa
    End Function

    Private Sub RetornaRecompensas(lstTransicao As List(Of Transicao))

        Dim Recompensa As Integer = 0

        Me.Invoke(Sub() Me.txtInfo.Text = "")
        For Each objtransicao As Transicao In Me.lstTransicoes.FindAll(Function(x) x.Estado = Me.EstadoAtual)

            lstTransicao.Add(Me.RetornaRecompensa(Me.EstadoAtual, objtransicao.Acao))

            Me.Invoke(Sub() Me.txtInfo.Text = String.Concat(Me.txtInfo.Text, vbCrLf, objtransicao.Acao))
            Me.Invoke(Sub() Me.txtInfo.Refresh())
            Me.Invoke(Sub() Me.lblEstado.Refresh())
        Next



    End Sub

    Private Sub CriaGrid()
        Try
            With Me.dgvTransicoes
                If .Columns.Count = 0 Then
                    .Columns.AddRange(New DataGridViewColumn() {
                                      New DataGridViewTextBoxColumn With {.DataPropertyName = "Estado",
                                                                          .HeaderText = "Estado",
                                                                          .Name = "Estado",
                                                                          .Width = 100,
                                                                          .DefaultCellStyle = New DataGridViewCellStyle With {.ForeColor = Color.Black}},
                                      New DataGridViewTextBoxColumn With {.DataPropertyName = "Acao",
                                                                          .HeaderText = "Acao",
                                                                          .Name = "Acao",
                                                                          .Width = 100},
                                      New DataGridViewTextBoxColumn With {.DataPropertyName = "Transicao.Recompensa",
                                                                          .HeaderText = "Recompensa",
                                                                          .Name = "Transicao.Recompensa",
                                                                          .Width = 100}})
                End If
            End With

            Me.dgvTransicoes.DataSource = New BindingSource() With {.DataSource = Me.lstTransicoes}
            Me.dgvTransicoes.Refresh()

        Catch ex As Exception

        End Try
    End Sub

    Private Function RetornaRecompensa(pmEstado As String, pmAcao As EnumProj.Direcoes) As Transicao

        Return Me.lstTransicoes.Find(Function(p) p.Estado = pmEstado And p.Acao = pmAcao)

    End Function

    Private Function RetornaEstado(pmEstado As String, pmAcao As EnumProj.Direcoes) As String

        Select Case pmAcao
            Case EnumProj.Direcoes.Norte
                Return String.Concat("s", CInt(pmEstado.Replace("s", "")) - 12)
            Case EnumProj.Direcoes.Sul
                Return String.Concat("s", CInt(pmEstado.Replace("s", "")) + 12)
            Case EnumProj.Direcoes.Leste
                Return String.Concat("s", CInt(pmEstado.Replace("s", "")) + 1)
            Case EnumProj.Direcoes.Oeste
                Return String.Concat("s", CInt(pmEstado.Replace("s", "")) - 1)
        End Select

    End Function


    Private Sub BtnIniciar_Click(sender As Object, e As EventArgs) Handles BtnIniciar.Click

        If Me.Iniciado Then
            Me.Reiniciar = True
        Else
            Dim t1 As Thread

            t1 = New Thread(AddressOf Me.Inicia)
            t1.Start()

        End If


    End Sub

    Private Sub MudaCarrinho()
        For Each pnl As Panel In Me.tblPanel.Controls
            If pnl.Name = Me.EstadoAtual Then
                Me.Invoke(Sub() Me.AtualizaPosCarro(pnl))
                Exit For
            End If
        Next
    End Sub

    Private Sub AtualizaPosCarro(ByRef pnl As Panel)
        System.Threading.Thread.Sleep(CInt(Me.txtAtraso.Text))
        pnl.Controls.Add(Me.pbcarro)
        Me.pbcarro.BringToFront()
        Me.tblPanel.Refresh()
        Me.pbcarro.Location = New Point(29, 0)
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If Me.Iniciado Then
            Me.Pause = Not Me.Pause
        End If
    End Sub
End Class
