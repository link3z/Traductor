<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrWizard_02
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
        Me.gestorErrores = New Recompila.Controles.rGestorErrores()
        Me.txtRutaProyecto = New Recompila.Controles.rTextOpenFile()
        Me.cmbSeleccionar = New System.Windows.Forms.TableLayoutPanel()
        Me.chklObjetos = New ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox()
        Me.cmbOpcionesSeleccion = New Recompila.Controles.rComboBox()
        Me.lblRutaProyecto = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblEnsamblado = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtNombreEnsamblado = New Recompila.Controles.rTextBox()
        Me.txtVersion = New Recompila.Controles.rTextBox()
        Me.lblVersion = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblSeleccionar = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbSeleccionar.SuspendLayout()
        CType(Me.cmbOpcionesSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(3, 3)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(488, 32)
        Me.lblTitulo.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Values.Text = "Seleccione el proyecto y los formularios"
        '
        'gestorErrores
        '
        Me.gestorErrores.Alineacion = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
        Me.gestorErrores.ContainerControl = Me
        '
        'txtRutaProyecto
        '
        Me.txtRutaProyecto.Apertura = Recompila.Controles.rTextOpenFile.AperturaTipo.OpenFile
        Me.txtRutaProyecto.BackColor = System.Drawing.Color.Transparent
        Me.txtRutaProyecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRutaProyecto.ExtensionesArchivo = "VB (*.vbproj)|*.vbproj"
        Me.txtRutaProyecto.IconoApertura = Global.traductorAplicaciones.My.Resources.Resources.folder_open_16_gris_66
        Me.txtRutaProyecto.Location = New System.Drawing.Point(131, 1)
        Me.txtRutaProyecto.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRutaProyecto.Name = "txtRutaProyecto"
        Me.txtRutaProyecto.NombreArchivo = ""
        Me.txtRutaProyecto.RutaInicial = "C:\rTrabajo\_PROYECTOS\Traductor\pruebasTraductor"
        Me.txtRutaProyecto.Size = New System.Drawing.Size(462, 24)
        Me.txtRutaProyecto.TabIndex = 0
        '
        'cmbSeleccionar
        '
        Me.cmbSeleccionar.ColumnCount = 3
        Me.cmbSeleccionar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.cmbSeleccionar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.cmbSeleccionar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.cmbSeleccionar.Controls.Add(Me.chklObjetos, 0, 5)
        Me.cmbSeleccionar.Controls.Add(Me.cmbOpcionesSeleccion, 2, 4)
        Me.cmbSeleccionar.Controls.Add(Me.txtRutaProyecto, 2, 0)
        Me.cmbSeleccionar.Controls.Add(Me.lblRutaProyecto, 0, 0)
        Me.cmbSeleccionar.Controls.Add(Me.lblEnsamblado, 0, 1)
        Me.cmbSeleccionar.Controls.Add(Me.txtNombreEnsamblado, 2, 1)
        Me.cmbSeleccionar.Controls.Add(Me.txtVersion, 2, 2)
        Me.cmbSeleccionar.Controls.Add(Me.lblVersion, 0, 2)
        Me.cmbSeleccionar.Controls.Add(Me.lblSeleccionar, 0, 4)
        Me.cmbSeleccionar.Location = New System.Drawing.Point(3, 41)
        Me.cmbSeleccionar.Name = "cmbSeleccionar"
        Me.cmbSeleccionar.RowCount = 6
        Me.cmbSeleccionar.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.cmbSeleccionar.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.cmbSeleccionar.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.cmbSeleccionar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.cmbSeleccionar.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.cmbSeleccionar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.cmbSeleccionar.Size = New System.Drawing.Size(594, 456)
        Me.cmbSeleccionar.TabIndex = 1043
        '
        'chklObjetos
        '
        Me.chklObjetos.CheckOnClick = True
        Me.cmbSeleccionar.SetColumnSpan(Me.chklObjetos, 3)
        Me.chklObjetos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chklObjetos.Location = New System.Drawing.Point(1, 114)
        Me.chklObjetos.Margin = New System.Windows.Forms.Padding(1)
        Me.chklObjetos.Name = "chklObjetos"
        Me.chklObjetos.Size = New System.Drawing.Size(592, 341)
        Me.chklObjetos.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.chklObjetos.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.chklObjetos.TabIndex = 4
        '
        'cmbOpcionesSeleccion
        '
        Me.cmbOpcionesSeleccion.controlarBotonBorrar = False
        Me.cmbOpcionesSeleccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbOpcionesSeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOpcionesSeleccion.DropDownWidth = 462
        Me.cmbOpcionesSeleccion.limpiarAlPulsarBoton = True
        Me.cmbOpcionesSeleccion.Location = New System.Drawing.Point(131, 91)
        Me.cmbOpcionesSeleccion.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbOpcionesSeleccion.mostrarSiempreBotonBorrar = False
        Me.cmbOpcionesSeleccion.Name = "cmbOpcionesSeleccion"
        Me.cmbOpcionesSeleccion.Size = New System.Drawing.Size(462, 21)
        Me.cmbOpcionesSeleccion.TabIndex = 3
        '
        'lblRutaProyecto
        '
        Me.lblRutaProyecto.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblRutaProyecto.Location = New System.Drawing.Point(6, 1)
        Me.lblRutaProyecto.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRutaProyecto.Name = "lblRutaProyecto"
        Me.lblRutaProyecto.Size = New System.Drawing.Size(103, 24)
        Me.lblRutaProyecto.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaProyecto.TabIndex = 1043
        Me.lblRutaProyecto.Values.Text = "Ruta del proyecto"
        '
        'lblEnsamblado
        '
        Me.lblEnsamblado.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEnsamblado.Location = New System.Drawing.Point(34, 27)
        Me.lblEnsamblado.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEnsamblado.Name = "lblEnsamblado"
        Me.lblEnsamblado.Size = New System.Drawing.Size(75, 20)
        Me.lblEnsamblado.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnsamblado.TabIndex = 1043
        Me.lblEnsamblado.Values.Text = "Ensamblado"
        '
        'txtNombreEnsamblado
        '
        Me.txtNombreEnsamblado.controlarBotonBorrar = False
        Me.txtNombreEnsamblado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNombreEnsamblado.limpiarAlPulsarBoton = True
        Me.txtNombreEnsamblado.Location = New System.Drawing.Point(131, 27)
        Me.txtNombreEnsamblado.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNombreEnsamblado.mostrarSiempreBotonBorrar = False
        Me.txtNombreEnsamblado.Name = "txtNombreEnsamblado"
        Me.txtNombreEnsamblado.ReadOnly = True
        Me.txtNombreEnsamblado.seleccionarTodo = True
        Me.txtNombreEnsamblado.Size = New System.Drawing.Size(462, 20)
        Me.txtNombreEnsamblado.TabIndex = 1
        Me.txtNombreEnsamblado.TabStop = False
        '
        'txtVersion
        '
        Me.txtVersion.controlarBotonBorrar = False
        Me.txtVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVersion.limpiarAlPulsarBoton = True
        Me.txtVersion.Location = New System.Drawing.Point(131, 49)
        Me.txtVersion.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVersion.mostrarSiempreBotonBorrar = False
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.ReadOnly = True
        Me.txtVersion.seleccionarTodo = True
        Me.txtVersion.Size = New System.Drawing.Size(462, 20)
        Me.txtVersion.TabIndex = 2
        Me.txtVersion.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblVersion.Location = New System.Drawing.Point(1, 49)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(108, 20)
        Me.lblVersion.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.TabIndex = 1043
        Me.lblVersion.Values.Text = "Versión traducción"
        '
        'lblSeleccionar
        '
        Me.lblSeleccionar.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblSeleccionar.Location = New System.Drawing.Point(36, 91)
        Me.lblSeleccionar.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSeleccionar.Name = "lblSeleccionar"
        Me.lblSeleccionar.Size = New System.Drawing.Size(73, 21)
        Me.lblSeleccionar.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionar.TabIndex = 1051
        Me.lblSeleccionar.Values.Text = "Formularios"
        '
        'ctrWizard_02
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.cmbSeleccionar)
        Me.Controls.Add(Me.lblTitulo)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrWizard_02"
        Me.Size = New System.Drawing.Size(600, 500)
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbSeleccionar.ResumeLayout(False)
        Me.cmbSeleccionar.PerformLayout()
        CType(Me.cmbOpcionesSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents gestorErrores As Recompila.Controles.rGestorErrores
    Friend WithEvents txtRutaProyecto As Recompila.Controles.rTextOpenFile
    Friend WithEvents cmbSeleccionar As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblRutaProyecto As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblEnsamblado As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtNombreEnsamblado As Recompila.Controles.rTextBox
    Friend WithEvents txtVersion As Recompila.Controles.rTextBox
    Friend WithEvents lblVersion As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chklObjetos As ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox
    Friend WithEvents cmbOpcionesSeleccion As Recompila.Controles.rComboBox
    Friend WithEvents lblSeleccionar As ComponentFactory.Krypton.Toolkit.KryptonLabel

End Class
