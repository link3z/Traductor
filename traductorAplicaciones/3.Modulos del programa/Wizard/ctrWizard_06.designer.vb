<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrWizard_06
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
        Me.lblTitulo = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.epErrores = New Recompila.Controles.rGestorErrores()
        Me.KryptonWrapLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel()
        Me.lnkInformacionUso = New ComponentFactory.Krypton.Toolkit.KryptonLinkLabel()
        Me.lnkAbrirCarpetaPO = New ComponentFactory.Krypton.Toolkit.KryptonLinkLabel()
        Me.lnkDescargarPoedit = New ComponentFactory.Krypton.Toolkit.KryptonLinkLabel()
        Me.lnkGuardarProyecto = New ComponentFactory.Krypton.Toolkit.KryptonLinkLabel()
        Me.lnkReiniciarAsistente = New ComponentFactory.Krypton.Toolkit.KryptonLinkLabel()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(3, 3)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(308, 32)
        Me.lblTitulo.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Values.Text = "¡Traducción completada!"
        '
        'epErrores
        '
        Me.epErrores.Alineacion = System.Windows.Forms.ErrorIconAlignment.TopLeft
        Me.epErrores.ContainerControl = Me
        '
        'KryptonWrapLabel1
        '
        Me.KryptonWrapLabel1.AutoSize = False
        Me.KryptonWrapLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.KryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.KryptonWrapLabel1.Location = New System.Drawing.Point(3, 38)
        Me.KryptonWrapLabel1.Name = "KryptonWrapLabel1"
        Me.KryptonWrapLabel1.Size = New System.Drawing.Size(594, 22)
        Me.KryptonWrapLabel1.Text = "¿Que desea hacer ahora?"
        '
        'lnkInformacionUso
        '
        Me.lnkInformacionUso.Location = New System.Drawing.Point(40, 64)
        Me.lnkInformacionUso.Name = "lnkInformacionUso"
        Me.lnkInformacionUso.OverrideNotVisited.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkInformacionUso.OverrideNotVisited.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkInformacionUso.Size = New System.Drawing.Size(410, 20)
        Me.lnkInformacionUso.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkInformacionUso.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkInformacionUso.TabIndex = 6
        Me.lnkInformacionUso.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.information_16_gris_66
        Me.lnkInformacionUso.Values.Text = "Obtener información de como utilizar las traducciones en mi proyecto."
        '
        'lnkAbrirCarpetaPO
        '
        Me.lnkAbrirCarpetaPO.Location = New System.Drawing.Point(40, 90)
        Me.lnkAbrirCarpetaPO.Name = "lnkAbrirCarpetaPO"
        Me.lnkAbrirCarpetaPO.OverrideNotVisited.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkAbrirCarpetaPO.OverrideNotVisited.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkAbrirCarpetaPO.Size = New System.Drawing.Size(427, 20)
        Me.lnkAbrirCarpetaPO.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkAbrirCarpetaPO.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkAbrirCarpetaPO.TabIndex = 7
        Me.lnkAbrirCarpetaPO.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.folder_open_16_gris_66
        Me.lnkAbrirCarpetaPO.Values.Text = "Abrir la carpeta donde se generaron los archivos PO con las traducciones."
        '
        'lnkDescargarPoedit
        '
        Me.lnkDescargarPoedit.Location = New System.Drawing.Point(40, 116)
        Me.lnkDescargarPoedit.Name = "lnkDescargarPoedit"
        Me.lnkDescargarPoedit.OverrideNotVisited.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkDescargarPoedit.OverrideNotVisited.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkDescargarPoedit.Size = New System.Drawing.Size(419, 20)
        Me.lnkDescargarPoedit.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkDescargarPoedit.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkDescargarPoedit.TabIndex = 8
        Me.lnkDescargarPoedit.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.edit_16_gris_66
        Me.lnkDescargarPoedit.Values.Text = "Descargar la última versión de Poedit para trabajar con las traducciones."
        '
        'lnkGuardarProyecto
        '
        Me.lnkGuardarProyecto.Location = New System.Drawing.Point(40, 142)
        Me.lnkGuardarProyecto.Name = "lnkGuardarProyecto"
        Me.lnkGuardarProyecto.OverrideNotVisited.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkGuardarProyecto.OverrideNotVisited.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkGuardarProyecto.Size = New System.Drawing.Size(463, 20)
        Me.lnkGuardarProyecto.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkGuardarProyecto.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkGuardarProyecto.TabIndex = 9
        Me.lnkGuardarProyecto.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.save_16_gris_66
        Me.lnkGuardarProyecto.Values.Text = "Guardar el proyecto de traducción para volver a traducir la aplicación más tarde." & _
    ""
        '
        'lnkReiniciarAsistente
        '
        Me.lnkReiniciarAsistente.Location = New System.Drawing.Point(40, 168)
        Me.lnkReiniciarAsistente.Name = "lnkReiniciarAsistente"
        Me.lnkReiniciarAsistente.OverrideNotVisited.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkReiniciarAsistente.OverrideNotVisited.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkReiniciarAsistente.Size = New System.Drawing.Size(330, 20)
        Me.lnkReiniciarAsistente.StateCommon.LongText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkReiniciarAsistente.StateCommon.LongText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkReiniciarAsistente.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkReiniciarAsistente.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lnkReiniciarAsistente.TabIndex = 10
        Me.lnkReiniciarAsistente.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.undo_point_16_gris_66
        Me.lnkReiniciarAsistente.Values.Text = "Volver a iniciar el asistente para realizar otra traducción."
        '
        'ctrWizard_05
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lnkReiniciarAsistente)
        Me.Controls.Add(Me.lnkGuardarProyecto)
        Me.Controls.Add(Me.lnkDescargarPoedit)
        Me.Controls.Add(Me.lnkAbrirCarpetaPO)
        Me.Controls.Add(Me.lnkInformacionUso)
        Me.Controls.Add(Me.KryptonWrapLabel1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrWizard_05"
        Me.Size = New System.Drawing.Size(600, 500)
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents epErrores As Recompila.Controles.rGestorErrores
    Friend WithEvents KryptonWrapLabel1 As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents lnkReiniciarAsistente As ComponentFactory.Krypton.Toolkit.KryptonLinkLabel
    Friend WithEvents lnkGuardarProyecto As ComponentFactory.Krypton.Toolkit.KryptonLinkLabel
    Friend WithEvents lnkDescargarPoedit As ComponentFactory.Krypton.Toolkit.KryptonLinkLabel
    Friend WithEvents lnkAbrirCarpetaPO As ComponentFactory.Krypton.Toolkit.KryptonLinkLabel
    Friend WithEvents lnkInformacionUso As ComponentFactory.Krypton.Toolkit.KryptonLinkLabel


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
