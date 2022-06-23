
Imports System.ComponentModel
Imports System.Reflection
Imports System.Threading
Public Class Start

    Dim lstRecompensas As New List(Of Recompensa)

    Dim lstTransicoes As New List(Of Transicao)

    Dim EstadoAtual As String = "s113"

    Dim Pause As Boolean = False

    Dim Iniciado As Boolean = False

    Dim Reiniciar As Boolean = False

    Dim EstadoAnterior As String = "s113"

    Dim AcaoEscolhida As EnumProj.Direcoes

    Dim rnd() As String = {"max", "max", "rnd", "max", "max", "rnd", "max", "max", "rnd", "max"}

    Dim t1 As Thread

    Dim dt As New DataTable
    Dim Tentativa As Integer = 0

    Public Sub New()

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        Me.MinimumSize = Me.Size
        Me.Inicializa()
        Me.CarregaGrid()
        Me.Experimento()
        Me.ShowDialog()

    End Sub

    Private Sub Experimento()

        Me.dt.Columns.Add("Tentativa", GetType(Integer))
        Me.dt.Columns.Add("Y", GetType(Double))
        Me.dt.Columns.Add("NTransicoes", GetType(Integer))
        Me.dt.Columns.Add("Estado", GetType(String))
        Me.dt.Columns.Add("Acao", GetType(EnumProj.Direcoes))
        Me.dt.Columns.Add("Recompensa", GetType(Double))

    End Sub

    Private Sub Inicializa()

        Me.lstRecompensas = New List(Of Recompensa)

        Me.lstTransicoes = New List(Of Transicao)
        Me.lblAcaoEscolhida.Text = ""
        Me.lblEstadoAnterior.Text = ""

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

    Private Sub CarregaGrid()
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
                                                                          .Width = 150},
                                      New DataGridViewTextBoxColumn With {.DataPropertyName = "Recompensa",
                                                                          .HeaderText = "Recompensa",
                                                                          .Name = "Recompensa",
                                                                          .ValueType = GetType(Double),
                                                                          .Width = 100}})

                End If
            End With

            Me.dgvTransicoes.DataSource = New BindingSource() With {.DataSource = Me.ConvertToDataTable(Me.lstTransicoes.OrderBy(Function(x) CInt(x.Estado.Replace("s", ""))).ToList)}

            Me.dgvTransicoes.Refresh()
            For Each dr As DataGridViewRow In Me.dgvTransicoes.Rows
                If dr.Cells("Estado").Value = Me.EstadoAnterior And dr.Cells("Acao").Value = AcaoEscolhida Then
                    Me.dgvTransicoes.CurrentCell = dr.Cells("Estado")
                    Exit For
                End If
            Next


        Catch ex As Exception

        End Try
    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' fazendo o Gerador static, preservamos a mesma instância
        ' assim não precisamos criar novas instância com a mesma semente 
        ' entre as chamadas
        Static Gerador As System.Random = New System.Random(TimeOfDay.Millisecond)
        Dim Numero As Integer = Gerador.Next(Min, Max)
        Return Numero
    End Function

    Private Sub Reinicia()

        If Reiniciar Then
            Me.Reiniciar = False
            Me.FinalCiclo()
            Me.Invoke(Sub() Me.Inicializa())
            Try
                Me.t1.Abort()
            Catch ex As Exception


            End Try
            Exit Sub
        End If

    End Sub

    Private Sub Pausa()
        While (Me.Pause)
        End While
    End Sub

    'tira isso e colocar msg o final do clico
    'Private Sub FazExperimento()
    '    Me.Invoke(Sub() Me.txtY.Text = "0")
    '    For j As Integer = 0 To 9
    '        Me.Invoke(Sub() Me.txtY.Text = CDbl(Me.txtY.Text) + 0.1)
    '        For i As Integer = 0 To 99
    '            Me.Tentativa += 1
    '            Dim cont As Integer = Me.Inicia()
    '            Me.lstTransicoes.ForEach(Sub(x)
    '                                         dt.Rows.Add(Me.Tentativa, CDbl(Me.txtY.Text), cont, x.Estado, x.Acao, x.Recompensa)
    '                                     End Sub)

    '        Next
    '        Me.Tentativa = 0
    '        Me.Invoke(Sub() Me.Inicializa())
    '    Next
    '    MsgBox("Copia o experimento")


    'End Sub


    Private Function Inicia() As Integer

        Dim cont As Integer = 0
        Me.Iniciado = True
        Invoke(Sub() Me.BtnIniciar.Text = "Reiniciar")

        While (Me.EstadoAtual <> "s60")


            Dim Acao As EnumProj.Direcoes = Me.EscolheAcao()

            Me.AtualizaInfTela()
            Me.Reinicia()
            Me.Pausa()
            Me.AtualizaQ(Acao, Me.RetornaEstado(Me.EstadoAtual, Acao))
            Invoke(Sub() Me.CarregaGrid())
            cont += 1

        End While

        MsgBox(String.Concat("Foram feitas ", cont, " transições até chegar ao destino!"), MsgBoxStyle.Information)

        Me.FinalCiclo()
        Return cont
    End Function

    Private Sub AtualizaInfTela()


        Me.Invoke(Sub() Me.lblEstado.Text = Me.EstadoAtual)
        Me.Invoke(Sub() Me.lblEstado.Refresh())
        Me.Invoke(Sub() Me.lblEstadoAnterior.Text = Me.EstadoAnterior)
        Me.Invoke(Sub() Me.lblEstadoAnterior.Refresh())
        Me.Invoke(Sub() Me.lblAcaoEscolhida.Text = [Enum].GetName(GetType(EnumProj.Direcoes), Me.AcaoEscolhida))
        Me.Invoke(Sub() Me.lblAcaoEscolhida.Refresh())


        If CInt(Me.txtAtraso.Text) > 0 Then
            System.Threading.Thread.Sleep(CInt(Me.txtAtraso.Text))
        End If

    End Sub

    Private Function EscolheAcao() As EnumProj.Direcoes

        Dim Recompensa As Double = 0
        Dim Acao As EnumProj.Direcoes
        Dim lstTransicao As New List(Of Transicao)

        'escolhe qual caminho aqui
        Me.RetornaRecompensas(lstTransicao)

        Dim Aleatorio As Integer

        If Me.rnd(Me.GetRandom(0, 9)) = "rnd" Then
            Aleatorio = Me.GetRandom(0, lstTransicao.Count)
            Recompensa = lstTransicao(Aleatorio).Recompensa
            Acao = lstTransicao(Aleatorio).Acao
        Else
            Dim GeraAleatorio As Boolean = False
            lstTransicao.RemoveAll(Function(p) p.Recompensa < 0)

            lstTransicao.ForEach(Sub(x)
                                     If x.Recompensa > Recompensa Then
                                         Recompensa = x.Recompensa
                                         Acao = x.Acao
                                         GeraAleatorio = False
                                     ElseIf x.Recompensa = Recompensa Then
                                         GeraAleatorio = True
                                     End If
                                 End Sub)

            If GeraAleatorio Then
                Aleatorio = Me.GetRandom(0, lstTransicao.Count)
                Recompensa = lstTransicao(Aleatorio).Recompensa
                Acao = lstTransicao(Aleatorio).Acao
            End If

        End If

        Return Acao
    End Function

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

        Me.lstTransicoes.Find(Function(p) p.Estado = Me.EstadoAtual And p.Acao = pmAcao).Recompensa = Math.Round(Me.r(pmEstadoNovo) + CDbl(Me.txtY.Text) * Me.Max(pmEstadoNovo), 6)

        Me.SalvaAlteraEstados(pmAcao, pmEstadoNovo)

        Me.MudaCarrinho()

    End Sub

    Private Sub SalvaAlteraEstados(pmAcao As EnumProj.Direcoes, pmEstadoNovo As String)
        Me.EstadoAnterior = Me.EstadoAtual
        Me.AcaoEscolhida = pmAcao
        Me.EstadoAtual = pmEstadoNovo
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

            Me.Invoke(Sub() Me.txtInfo.Text = String.Concat(Me.txtInfo.Text, If(Me.txtInfo.Text <> "", vbCrLf, ""), objtransicao.Acao))
            Me.Invoke(Sub() Me.txtInfo.Refresh())
            Me.Invoke(Sub() Me.lblEstado.Refresh())
        Next



    End Sub

    Public Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim table As New DataTable()
        Dim fields() As FieldInfo = GetType(T).GetFields()
        For Each field As FieldInfo In fields
            table.Columns.Add(field.Name, field.FieldType)
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As FieldInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function

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
            Me.btnPause.Enabled = False
        Else
            Me.btnPause.Enabled = True


            Try
                t1.Abort()
            Catch ex As Exception

            End Try
            t1 = New Thread(AddressOf Me.Inicia)
            't1 = New Thread(AddressOf Me.FazExperimento)

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
        pnl.Controls.Add(Me.pbcarro)
        Me.pbcarro.BringToFront()
        Me.tblPanel.Refresh()
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If Me.Iniciado Then
            Me.Pause = Not Me.Pause
            Me.BtnIniciar.Enabled = Not Me.Pause
        End If
    End Sub

    Private Sub Start_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.t1.Abort()
    End Sub

End Class
