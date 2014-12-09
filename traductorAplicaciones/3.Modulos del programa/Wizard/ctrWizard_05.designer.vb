<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrWizard_05
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblTitulo = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.gestorErrores = New Recompila.Controles.rGestorErrores()
        Me.txtMensajes = New System.Windows.Forms.TextBox()
        Me.pbPrimaria = New System.Windows.Forms.ProgressBar()
        Me.pbSecundaria = New System.Windows.Forms.ProgressBar()
        Me.tInicio = New System.Windows.Forms.Timer(Me.components)
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(3, 3)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(486, 32)
        Me.lblTitulo.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Values.Text = "Espere mientras se realiza la traducción"
        '
        'gestorErrores
        '
        Me.gestorErrores.Alineacion = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
        Me.gestorErrores.ContainerControl = Me
        '
        'txtMensajes
        '
        Me.txtMensajes.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtMensajes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMensajes.Font = New System.Drawing.Font("Lucida Console", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensajes.ForeColor = System.Drawing.Color.LightGray
        Me.txtMensajes.Location = New System.Drawing.Point(3, 41)
        Me.txtMensajes.MaxLength = 2147483647
        Me.txtMensajes.Multiline = True
        Me.txtMensajes.Name = "txtMensajes"
        Me.txtMensajes.Size = New System.Drawing.Size(594, 418)
        Me.txtMensajes.TabIndex = 9
        '
        'pbPrimaria
        '
        Me.pbPrimaria.Location = New System.Drawing.Point(3, 465)
        Me.pbPrimaria.Name = "pbPrimaria"
        Me.pbPrimaria.Size = New System.Drawing.Size(594, 13)
        Me.pbPrimaria.TabIndex = 10
        '
        'pbSecundaria
        '
        Me.pbSecundaria.Location = New System.Drawing.Point(3, 484)
        Me.pbSecundaria.Name = "pbSecundaria"
        Me.pbSecundaria.Size = New System.Drawing.Size(594, 13)
        Me.pbSecundaria.TabIndex = 11
        '
        'tInicio
        '
        '
        'ctrWizard_04
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pbSecundaria)
        Me.Controls.Add(Me.pbPrimaria)
        Me.Controls.Add(Me.txtMensajes)
        Me.Controls.Add(Me.lblTitulo)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrWizard_04"
        Me.Size = New System.Drawing.Size(600, 500)
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents gestorErrores As Recompila.Controles.rGestorErrores
    Friend WithEvents pbSecundaria As System.Windows.Forms.ProgressBar
    Friend WithEvents pbPrimaria As System.Windows.Forms.ProgressBar
    Friend WithEvents txtMensajes As System.Windows.Forms.TextBox
    Friend WithEvents tInicio As System.Windows.Forms.Timer


Public ReadOnly Property losComponentes As System.ComponentModel.ComponentCollection
    Get
        If Me.components IsNot Nothing Then
            Return Me.components.Components
        else
            Return Nothing
        End If
    End Get
End Property

End Class
