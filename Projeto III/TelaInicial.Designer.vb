<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TelaInicial
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Titulo = New System.Windows.Forms.Label()
        Me.LBLtITULO2 = New System.Windows.Forms.Label()
        Me.lblIntegrantes = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Titulo
        '
        Me.Titulo.AutoSize = True
        Me.Titulo.BackColor = System.Drawing.Color.DimGray
        Me.Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titulo.ForeColor = System.Drawing.SystemColors.Control
        Me.Titulo.Location = New System.Drawing.Point(118, 44)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.Size = New System.Drawing.Size(313, 55)
        Me.Titulo.TabIndex = 0
        Me.Titulo.Text = "PROJETO III"
        '
        'LBLtITULO2
        '
        Me.LBLtITULO2.AutoSize = True
        Me.LBLtITULO2.BackColor = System.Drawing.Color.DimGray
        Me.LBLtITULO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLtITULO2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LBLtITULO2.Location = New System.Drawing.Point(87, 90)
        Me.LBLtITULO2.Name = "LBLtITULO2"
        Me.LBLtITULO2.Size = New System.Drawing.Size(411, 39)
        Me.LBLtITULO2.TabIndex = 1
        Me.LBLtITULO2.Text = "Aprendizado por reforço"
        '
        'lblIntegrantes
        '
        Me.lblIntegrantes.AutoSize = True
        Me.lblIntegrantes.BackColor = System.Drawing.Color.DimGray
        Me.lblIntegrantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntegrantes.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.lblIntegrantes.Location = New System.Drawing.Point(281, 289)
        Me.lblIntegrantes.Name = "lblIntegrantes"
        Me.lblIntegrantes.Size = New System.Drawing.Size(291, 72)
        Me.lblIntegrantes.TabIndex = 2
        Me.lblIntegrantes.Text = "Jonatan Amaral da Silva" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Maurício Zalamena Bavaresco" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rodrigo Perazolli Baldasso" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.BackColor = System.Drawing.Color.DimGray
        Me.lblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart.ForeColor = System.Drawing.Color.Cyan
        Me.lblStart.Location = New System.Drawing.Point(249, 163)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(79, 73)
        Me.lblStart.TabIndex = 3
        Me.lblStart.Text = "▶"
        '
        'TelaInicial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(584, 390)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.lblIntegrantes)
        Me.Controls.Add(Me.LBLtITULO2)
        Me.Controls.Add(Me.Titulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "TelaInicial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TelaInicial"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Titulo As Label
    Friend WithEvents LBLtITULO2 As Label
    Friend WithEvents lblIntegrantes As Label
    Friend WithEvents lblStart As Label
End Class
