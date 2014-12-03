<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.btnCrear = New System.Windows.Forms.Button()
        Me.pbMayor = New System.Windows.Forms.ProgressBar()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.txtMensajes = New System.Windows.Forms.TextBox()
        Me.lstIdiomasExportacion = New System.Windows.Forms.CheckedListBox()
        Me.lstFormulariosExportar = New System.Windows.Forms.CheckedListBox()
        Me.pbMenor = New System.Windows.Forms.ProgressBar()
        Me.cmbOpcionesSeleccion = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.pConfiguracionExportacion = New System.Windows.Forms.Panel()
        Me.tblConfiguracionExportacion = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtRutaProyecto = New Recompila.Controles.rTextOpenFile()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtNombreEnsamblado = New Recompila.Controles.rTextBox()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtVersion = New Recompila.Controles.rTextBox()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cmbMotorTraduccion = New Recompila.Controles.rComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tlsbConfigurarFTP = New System.Windows.Forms.ToolStripButton()
        Me.cmbIdiomaVentana = New Recompila.Controles.rComboIcon()
        Me.pConfiguracionExportacion.SuspendLayout()
        Me.tblConfiguracionExportacion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cmbMotorTraduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cmbIdiomaVentana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCrear
        '
        Me.btnCrear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCrear.Location = New System.Drawing.Point(582, 600)
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.Size = New System.Drawing.Size(117, 23)
        Me.btnCrear.TabIndex = 5
        Me.btnCrear.Text = "&Crear PO"
        Me.btnCrear.UseVisualStyleBackColor = True
        '
        'pbMayor
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.pbMayor, 4)
        Me.pbMayor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbMayor.Location = New System.Drawing.Point(3, 534)
        Me.pbMayor.Name = "pbMayor"
        Me.pbMayor.Size = New System.Drawing.Size(804, 29)
        Me.pbMayor.TabIndex = 6
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Location = New System.Drawing.Point(705, 600)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(117, 23)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.Text = "&Salir"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'txtMensajes
        '
        Me.txtMensajes.BackColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtMensajes, 4)
        Me.txtMensajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMensajes.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensajes.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtMensajes.Location = New System.Drawing.Point(3, 240)
        Me.txtMensajes.MaxLength = 2000000000
        Me.txtMensajes.Multiline = True
        Me.txtMensajes.Name = "txtMensajes"
        Me.txtMensajes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMensajes.Size = New System.Drawing.Size(804, 264)
        Me.txtMensajes.TabIndex = 8
        '
        'lstIdiomasExportacion
        '
        Me.lstIdiomasExportacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstIdiomasExportacion.FormattingEnabled = True
        Me.lstIdiomasExportacion.Location = New System.Drawing.Point(405, 25)
        Me.lstIdiomasExportacion.Name = "lstIdiomasExportacion"
        Me.tblConfiguracionExportacion.SetRowSpan(Me.lstIdiomasExportacion, 3)
        Me.lstIdiomasExportacion.Size = New System.Drawing.Size(396, 146)
        Me.lstIdiomasExportacion.TabIndex = 11
        '
        'lstFormulariosExportar
        '
        Me.lstFormulariosExportar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFormulariosExportar.FormattingEnabled = True
        Me.lstFormulariosExportar.Location = New System.Drawing.Point(3, 25)
        Me.lstFormulariosExportar.Name = "lstFormulariosExportar"
        Me.lstFormulariosExportar.Size = New System.Drawing.Size(396, 112)
        Me.lstFormulariosExportar.TabIndex = 13
        '
        'pbMenor
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.pbMenor, 4)
        Me.pbMenor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbMenor.Location = New System.Drawing.Point(3, 510)
        Me.pbMenor.Name = "pbMenor"
        Me.pbMenor.Size = New System.Drawing.Size(804, 18)
        Me.pbMenor.TabIndex = 14
        '
        'cmbOpcionesSeleccion
        '
        Me.cmbOpcionesSeleccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbOpcionesSeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOpcionesSeleccion.FormattingEnabled = True
        Me.cmbOpcionesSeleccion.Location = New System.Drawing.Point(216, 3)
        Me.cmbOpcionesSeleccion.Name = "cmbOpcionesSeleccion"
        Me.cmbOpcionesSeleccion.Size = New System.Drawing.Size(177, 21)
        Me.cmbOpcionesSeleccion.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 605)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Idioma para esta ventana"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(3, 3)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(207, 20)
        Me.KryptonLabel1.TabIndex = 1042
        Me.KryptonLabel1.Values.Text = "Selecciona los formularios a traducir"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonLabel3.Location = New System.Drawing.Point(3, 3)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(155, 24)
        Me.KryptonLabel3.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel3.TabIndex = 1044
        Me.KryptonLabel3.Values.Text = "Ruta del proyecto a traducir"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(3, 3)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(129, 16)
        Me.KryptonLabel4.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel4.TabIndex = 1045
        Me.KryptonLabel4.Values.Text = "Formularios a exportar"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(405, 3)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(233, 16)
        Me.KryptonLabel5.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel5.TabIndex = 1046
        Me.KryptonLabel5.Values.Text = "Idiomas que se usarán para la exportación"
        '
        'pConfiguracionExportacion
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.pConfiguracionExportacion, 4)
        Me.pConfiguracionExportacion.Controls.Add(Me.tblConfiguracionExportacion)
        Me.pConfiguracionExportacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pConfiguracionExportacion.Location = New System.Drawing.Point(3, 60)
        Me.pConfiguracionExportacion.Name = "pConfiguracionExportacion"
        Me.pConfiguracionExportacion.Size = New System.Drawing.Size(804, 174)
        Me.pConfiguracionExportacion.TabIndex = 1047
        '
        'tblConfiguracionExportacion
        '
        Me.tblConfiguracionExportacion.ColumnCount = 2
        Me.tblConfiguracionExportacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblConfiguracionExportacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblConfiguracionExportacion.Controls.Add(Me.Panel1, 0, 3)
        Me.tblConfiguracionExportacion.Controls.Add(Me.KryptonLabel4, 0, 0)
        Me.tblConfiguracionExportacion.Controls.Add(Me.KryptonLabel5, 1, 0)
        Me.tblConfiguracionExportacion.Controls.Add(Me.lstFormulariosExportar, 0, 1)
        Me.tblConfiguracionExportacion.Controls.Add(Me.lstIdiomasExportacion, 1, 1)
        Me.tblConfiguracionExportacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblConfiguracionExportacion.Location = New System.Drawing.Point(0, 0)
        Me.tblConfiguracionExportacion.Name = "tblConfiguracionExportacion"
        Me.tblConfiguracionExportacion.RowCount = 4
        Me.tblConfiguracionExportacion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConfiguracionExportacion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblConfiguracionExportacion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConfiguracionExportacion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConfiguracionExportacion.Size = New System.Drawing.Size(804, 174)
        Me.tblConfiguracionExportacion.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 143)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(396, 28)
        Me.Panel1.TabIndex = 1049
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.KryptonLabel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbOpcionesSeleccion, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(396, 28)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtRutaProyecto, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pConfiguracionExportacion, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pbMenor, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.pbMayor, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMensajes, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel6, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNombreEnsamblado, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel8, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtVersion, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel7, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbMotorTraduccion, 3, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 28)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(810, 566)
        Me.TableLayoutPanel1.TabIndex = 1048
        '
        'txtRutaProyecto
        '
        Me.txtRutaProyecto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRutaProyecto.Apertura = Recompila.Controles.rTextOpenFile.AperturaTipo.OpenFile
        Me.txtRutaProyecto.BackColor = System.Drawing.Color.Transparent
        Me.txtRutaProyecto.ExtensionesArchivo = "VB (*.vbproj)|*.vbproj"
        Me.txtRutaProyecto.Location = New System.Drawing.Point(164, 3)
        Me.txtRutaProyecto.Name = "txtRutaProyecto"
        Me.txtRutaProyecto.NombreArchivo = ""
        Me.txtRutaProyecto.RutaInicial = "C:\rTrabajo\_PROYECTOS\Traductor\pruebasTraductor"
        Me.txtRutaProyecto.Size = New System.Drawing.Size(321, 24)
        Me.txtRutaProyecto.TabIndex = 1041
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel6.Location = New System.Drawing.Point(514, 3)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(75, 24)
        Me.KryptonLabel6.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel6.TabIndex = 1048
        Me.KryptonLabel6.Values.Text = "Ensamblado"
        '
        'txtNombreEnsamblado
        '
        Me.txtNombreEnsamblado.controlarBotonBorrar = True
        Me.txtNombreEnsamblado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNombreEnsamblado.limpiarAlPulsarBoton = True
        Me.txtNombreEnsamblado.Location = New System.Drawing.Point(595, 3)
        Me.txtNombreEnsamblado.mostrarSiempreBotonBorrar = False
        Me.txtNombreEnsamblado.Name = "txtNombreEnsamblado"
        Me.txtNombreEnsamblado.seleccionarTodo = True
        Me.txtNombreEnsamblado.Size = New System.Drawing.Size(212, 20)
        Me.txtNombreEnsamblado.TabIndex = 1049
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel8.Location = New System.Drawing.Point(21, 33)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(137, 21)
        Me.KryptonLabel8.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel8.TabIndex = 1048
        Me.KryptonLabel8.Values.Text = "Versión de la traducción"
        '
        'txtVersion
        '
        Me.txtVersion.controlarBotonBorrar = True
        Me.txtVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVersion.limpiarAlPulsarBoton = True
        Me.txtVersion.Location = New System.Drawing.Point(164, 33)
        Me.txtVersion.mostrarSiempreBotonBorrar = False
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.seleccionarTodo = True
        Me.txtVersion.Size = New System.Drawing.Size(321, 20)
        Me.txtVersion.TabIndex = 1049
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel7.Location = New System.Drawing.Point(491, 33)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(98, 21)
        Me.KryptonLabel7.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel7.TabIndex = 1048
        Me.KryptonLabel7.Values.Text = "Motor traducción"
        '
        'cmbMotorTraduccion
        '
        Me.cmbMotorTraduccion.controlarBotonBorrar = True
        Me.cmbMotorTraduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbMotorTraduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotorTraduccion.DropDownWidth = 212
        Me.cmbMotorTraduccion.limpiarAlPulsarBoton = True
        Me.cmbMotorTraduccion.Location = New System.Drawing.Point(595, 33)
        Me.cmbMotorTraduccion.mostrarSiempreBotonBorrar = False
        Me.cmbMotorTraduccion.Name = "cmbMotorTraduccion"
        Me.cmbMotorTraduccion.Size = New System.Drawing.Size(212, 21)
        Me.cmbMotorTraduccion.TabIndex = 1050
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlsbConfigurarFTP})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(834, 25)
        Me.ToolStrip1.TabIndex = 1049
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tlsbConfigurarFTP
        '
        Me.tlsbConfigurarFTP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlsbConfigurarFTP.Image = CType(resources.GetObject("tlsbConfigurarFTP.Image"), System.Drawing.Image)
        Me.tlsbConfigurarFTP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlsbConfigurarFTP.Name = "tlsbConfigurarFTP"
        Me.tlsbConfigurarFTP.Size = New System.Drawing.Size(23, 22)
        Me.tlsbConfigurarFTP.Text = "Configuración FTP"
        '
        'cmbIdiomaVentana
        '
        Me.cmbIdiomaVentana.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbIdiomaVentana.conBorde = True
        Me.cmbIdiomaVentana.controlarBotonBorrar = True
        Me.cmbIdiomaVentana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdiomaVentana.DropDownWidth = 197
        Me.cmbIdiomaVentana.limpiarAlPulsarBoton = True
        Me.cmbIdiomaVentana.Location = New System.Drawing.Point(146, 600)
        Me.cmbIdiomaVentana.mostrarSiempreBotonBorrar = False
        Me.cmbIdiomaVentana.Name = "cmbIdiomaVentana"
        Me.cmbIdiomaVentana.Size = New System.Drawing.Size(197, 21)
        Me.cmbIdiomaVentana.StateCommon.ComboBox.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[True]
        Me.cmbIdiomaVentana.StateCommon.ComboBox.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.cmbIdiomaVentana.TabIndex = 1050
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(834, 635)
        Me.Controls.Add(Me.cmbIdiomaVentana)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCrear)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recompila - Traductor aplicaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pConfiguracionExportacion.ResumeLayout(False)
        Me.tblConfiguracionExportacion.ResumeLayout(False)
        Me.tblConfiguracionExportacion.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.cmbMotorTraduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cmbIdiomaVentana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCrear As System.Windows.Forms.Button
    Friend WithEvents pbMayor As System.Windows.Forms.ProgressBar
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents txtMensajes As System.Windows.Forms.TextBox
    Friend WithEvents lstIdiomasExportacion As System.Windows.Forms.CheckedListBox
    Friend WithEvents lstFormulariosExportar As System.Windows.Forms.CheckedListBox
    Friend WithEvents pbMenor As System.Windows.Forms.ProgressBar
    Friend WithEvents cmbOpcionesSeleccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRutaProyecto As Recompila.Controles.rTextOpenFile
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pConfiguracionExportacion As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblConfiguracionExportacion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tlsbConfigurarFTP As System.Windows.Forms.ToolStripButton
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtNombreEnsamblado As Recompila.Controles.rTextBox
    Friend WithEvents txtVersion As Recompila.Controles.rTextBox
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cmbMotorTraduccion As Recompila.Controles.rComboBox
    Friend WithEvents cmbIdiomaVentana As Recompila.Controles.rComboIcon
End Class
