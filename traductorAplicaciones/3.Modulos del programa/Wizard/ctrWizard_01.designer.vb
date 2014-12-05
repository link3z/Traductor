<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrWizard_01
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
        Me.radNuevoProyecto = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.radAbrirProyectoExistente = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.hdrProyecto = New ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup()
        Me.tblProyecto = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDescripcion = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblNombre = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtNombre = New Recompila.Controles.rTextBox()
        Me.txtDescripcion = New Recompila.Controles.rTextBox()
        Me.hdrConexion = New ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup()
        Me.tblConexion = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFTPServidor = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblFTPUsuario = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblFTPClave = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblFTPRuta = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblFTPURL = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtFTPServidor = New Recompila.Controles.rTextBox()
        Me.txtFTPUsuario = New Recompila.Controles.rTextBox()
        Me.txtFTPContrasenha = New Recompila.Controles.rTextBox()
        Me.txtFTPRuta = New Recompila.Controles.rTextBox()
        Me.txtURI = New Recompila.Controles.rTextBox()
        Me.lblFTPPuerto = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtFTPPuerto = New Recompila.Controles.rTextBox()
        Me.tblConfiguracion = New System.Windows.Forms.TableLayoutPanel()
        Me.txtRutaProyecto = New Recompila.Controles.rTextOpenFile()
        Me.gestorErrores = New Recompila.Controles.rGestorErrores()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.hdrProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hdrProyecto.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hdrProyecto.Panel.SuspendLayout()
        Me.hdrProyecto.SuspendLayout()
        Me.tblProyecto.SuspendLayout()
        CType(Me.hdrConexion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hdrConexion.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hdrConexion.Panel.SuspendLayout()
        Me.hdrConexion.SuspendLayout()
        Me.tblConexion.SuspendLayout()
        Me.tblConfiguracion.SuspendLayout()
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(3, 3)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(410, 32)
        Me.lblTitulo.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Values.Text = "Seleccione la operación a realizar"
        '
        'radNuevoProyecto
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.radNuevoProyecto, 2)
        Me.radNuevoProyecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radNuevoProyecto.Location = New System.Drawing.Point(1, 62)
        Me.radNuevoProyecto.Margin = New System.Windows.Forms.Padding(1)
        Me.radNuevoProyecto.Name = "radNuevoProyecto"
        Me.radNuevoProyecto.Size = New System.Drawing.Size(544, 33)
        Me.radNuevoProyecto.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.radNuevoProyecto.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.radNuevoProyecto.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radNuevoProyecto.TabIndex = 5
        Me.radNuevoProyecto.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.add_32_gris_66
        Me.radNuevoProyecto.Values.Text = "Iniciar una nueva traducción"
        '
        'radAbrirProyectoExistente
        '
        Me.radAbrirProyectoExistente.Checked = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.radAbrirProyectoExistente, 2)
        Me.radAbrirProyectoExistente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radAbrirProyectoExistente.Location = New System.Drawing.Point(1, 1)
        Me.radAbrirProyectoExistente.Margin = New System.Windows.Forms.Padding(1)
        Me.radAbrirProyectoExistente.Name = "radAbrirProyectoExistente"
        Me.radAbrirProyectoExistente.Size = New System.Drawing.Size(544, 33)
        Me.radAbrirProyectoExistente.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.radAbrirProyectoExistente.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.radAbrirProyectoExistente.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAbrirProyectoExistente.TabIndex = 6
        Me.radAbrirProyectoExistente.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.folder_open_32_gris_66
        Me.radAbrirProyectoExistente.Values.Text = "Abrir una traducción existente"
        '
        'hdrProyecto
        '
        Me.hdrProyecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hdrProyecto.HeaderVisibleSecondary = False
        Me.hdrProyecto.Location = New System.Drawing.Point(3, 3)
        Me.hdrProyecto.Name = "hdrProyecto"
        '
        'hdrProyecto.Panel
        '
        Me.hdrProyecto.Panel.Controls.Add(Me.tblProyecto)
        Me.hdrProyecto.Panel.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.hdrProyecto.Size = New System.Drawing.Size(292, 349)
        Me.hdrProyecto.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.hdrProyecto.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.hdrProyecto.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrProyecto.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrProyecto.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.hdrProyecto.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.hdrProyecto.StateCommon.HeaderPrimary.Back.Color1 = System.Drawing.Color.Transparent
        Me.hdrProyecto.StateCommon.HeaderPrimary.Back.Color2 = System.Drawing.Color.Transparent
        Me.hdrProyecto.StateCommon.HeaderPrimary.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom
        Me.hdrProyecto.StateCommon.HeaderPrimary.Content.LongText.Color1 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.hdrProyecto.StateCommon.HeaderPrimary.Content.LongText.Color2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.hdrProyecto.StateCommon.HeaderPrimary.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrProyecto.StateCommon.HeaderPrimary.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrProyecto.StateCommon.HeaderPrimary.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hdrProyecto.TabIndex = 42
        Me.hdrProyecto.ValuesPrimary.Heading = "Datos de la traducción"
        Me.hdrProyecto.ValuesPrimary.Image = Global.traductorAplicaciones.My.Resources.Resources.page_bold_16_gris_66
        '
        'tblProyecto
        '
        Me.tblProyecto.BackColor = System.Drawing.Color.Transparent
        Me.tblProyecto.ColumnCount = 3
        Me.tblProyecto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblProyecto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblProyecto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblProyecto.Controls.Add(Me.lblDescripcion, 0, 1)
        Me.tblProyecto.Controls.Add(Me.lblNombre, 0, 0)
        Me.tblProyecto.Controls.Add(Me.txtNombre, 2, 0)
        Me.tblProyecto.Controls.Add(Me.txtDescripcion, 0, 2)
        Me.tblProyecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblProyecto.Location = New System.Drawing.Point(0, 10)
        Me.tblProyecto.Name = "tblProyecto"
        Me.tblProyecto.RowCount = 3
        Me.tblProyecto.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblProyecto.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblProyecto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblProyecto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblProyecto.Size = New System.Drawing.Size(290, 316)
        Me.tblProyecto.TabIndex = 0
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescripcion.Location = New System.Drawing.Point(1, 23)
        Me.lblDescripcion.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(72, 16)
        Me.lblDescripcion.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.TabIndex = 0
        Me.lblDescripcion.Values.Text = "Descripción"
        '
        'lblNombre
        '
        Me.lblNombre.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblNombre.Location = New System.Drawing.Point(21, 1)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(52, 20)
        Me.lblNombre.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.TabIndex = 18
        Me.lblNombre.Values.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.controlarBotonBorrar = True
        Me.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNombre.limpiarAlPulsarBoton = True
        Me.txtNombre.Location = New System.Drawing.Point(95, 1)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNombre.mostrarSiempreBotonBorrar = False
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.seleccionarTodo = True
        Me.txtNombre.Size = New System.Drawing.Size(194, 20)
        Me.txtNombre.TabIndex = 21
        '
        'txtDescripcion
        '
        Me.tblProyecto.SetColumnSpan(Me.txtDescripcion, 3)
        Me.txtDescripcion.controlarBotonBorrar = False
        Me.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescripcion.limpiarAlPulsarBoton = True
        Me.txtDescripcion.Location = New System.Drawing.Point(1, 41)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDescripcion.mostrarSiempreBotonBorrar = False
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.seleccionarTodo = True
        Me.txtDescripcion.Size = New System.Drawing.Size(288, 274)
        Me.txtDescripcion.TabIndex = 21
        '
        'hdrConexion
        '
        Me.hdrConexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hdrConexion.HeaderVisibleSecondary = False
        Me.hdrConexion.Location = New System.Drawing.Point(301, 3)
        Me.hdrConexion.Name = "hdrConexion"
        '
        'hdrConexion.Panel
        '
        Me.hdrConexion.Panel.Controls.Add(Me.tblConexion)
        Me.hdrConexion.Panel.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.hdrConexion.Size = New System.Drawing.Size(293, 349)
        Me.hdrConexion.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.hdrConexion.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.hdrConexion.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrConexion.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrConexion.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.hdrConexion.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.hdrConexion.StateCommon.HeaderPrimary.Back.Color1 = System.Drawing.Color.Transparent
        Me.hdrConexion.StateCommon.HeaderPrimary.Back.Color2 = System.Drawing.Color.Transparent
        Me.hdrConexion.StateCommon.HeaderPrimary.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom
        Me.hdrConexion.StateCommon.HeaderPrimary.Content.LongText.Color1 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.hdrConexion.StateCommon.HeaderPrimary.Content.LongText.Color2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.hdrConexion.StateCommon.HeaderPrimary.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrConexion.StateCommon.HeaderPrimary.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrConexion.StateCommon.HeaderPrimary.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hdrConexion.TabIndex = 43
        Me.hdrConexion.ValuesPrimary.Heading = "Configuración FTP/HTTP"
        Me.hdrConexion.ValuesPrimary.Image = Global.traductorAplicaciones.My.Resources.Resources.page_bold_16_gris_66
        '
        'tblConexion
        '
        Me.tblConexion.BackColor = System.Drawing.Color.Transparent
        Me.tblConexion.ColumnCount = 3
        Me.tblConexion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblConexion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblConexion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblConexion.Controls.Add(Me.lblFTPServidor, 0, 0)
        Me.tblConexion.Controls.Add(Me.lblFTPUsuario, 0, 2)
        Me.tblConexion.Controls.Add(Me.lblFTPClave, 0, 3)
        Me.tblConexion.Controls.Add(Me.lblFTPRuta, 0, 4)
        Me.tblConexion.Controls.Add(Me.lblFTPURL, 0, 5)
        Me.tblConexion.Controls.Add(Me.txtFTPServidor, 2, 0)
        Me.tblConexion.Controls.Add(Me.txtFTPUsuario, 2, 2)
        Me.tblConexion.Controls.Add(Me.txtFTPContrasenha, 2, 3)
        Me.tblConexion.Controls.Add(Me.txtFTPRuta, 2, 4)
        Me.tblConexion.Controls.Add(Me.txtURI, 2, 5)
        Me.tblConexion.Controls.Add(Me.lblFTPPuerto, 0, 1)
        Me.tblConexion.Controls.Add(Me.txtFTPPuerto, 2, 1)
        Me.tblConexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblConexion.Location = New System.Drawing.Point(0, 10)
        Me.tblConexion.Name = "tblConexion"
        Me.tblConexion.RowCount = 7
        Me.tblConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConexion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblConexion.Size = New System.Drawing.Size(291, 316)
        Me.tblConexion.TabIndex = 3
        '
        'lblFTPServidor
        '
        Me.lblFTPServidor.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPServidor.Location = New System.Drawing.Point(1, 1)
        Me.lblFTPServidor.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFTPServidor.Name = "lblFTPServidor"
        Me.lblFTPServidor.Size = New System.Drawing.Size(79, 20)
        Me.lblFTPServidor.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPServidor.TabIndex = 4
        Me.lblFTPServidor.Values.Text = "Servidor FTP"
        '
        'lblFTPUsuario
        '
        Me.lblFTPUsuario.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPUsuario.Location = New System.Drawing.Point(4, 45)
        Me.lblFTPUsuario.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFTPUsuario.Name = "lblFTPUsuario"
        Me.lblFTPUsuario.Size = New System.Drawing.Size(76, 20)
        Me.lblFTPUsuario.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPUsuario.TabIndex = 4
        Me.lblFTPUsuario.Values.Text = "Usuario FTP"
        '
        'lblFTPClave
        '
        Me.lblFTPClave.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPClave.Location = New System.Drawing.Point(14, 67)
        Me.lblFTPClave.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFTPClave.Name = "lblFTPClave"
        Me.lblFTPClave.Size = New System.Drawing.Size(66, 20)
        Me.lblFTPClave.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPClave.TabIndex = 4
        Me.lblFTPClave.Values.Text = "Clave FTP"
        '
        'lblFTPRuta
        '
        Me.lblFTPRuta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPRuta.Location = New System.Drawing.Point(20, 89)
        Me.lblFTPRuta.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFTPRuta.Name = "lblFTPRuta"
        Me.lblFTPRuta.Size = New System.Drawing.Size(60, 20)
        Me.lblFTPRuta.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPRuta.TabIndex = 4
        Me.lblFTPRuta.Values.Text = "Ruta FTP"
        '
        'lblFTPURL
        '
        Me.lblFTPURL.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPURL.Location = New System.Drawing.Point(6, 111)
        Me.lblFTPURL.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFTPURL.Name = "lblFTPURL"
        Me.lblFTPURL.Size = New System.Drawing.Size(74, 20)
        Me.lblFTPURL.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPURL.TabIndex = 4
        Me.lblFTPURL.Values.Text = "URL acceso"
        '
        'txtFTPServidor
        '
        Me.txtFTPServidor.controlarBotonBorrar = True
        Me.txtFTPServidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPServidor.limpiarAlPulsarBoton = True
        Me.txtFTPServidor.Location = New System.Drawing.Point(102, 1)
        Me.txtFTPServidor.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFTPServidor.mostrarSiempreBotonBorrar = False
        Me.txtFTPServidor.Name = "txtFTPServidor"
        Me.txtFTPServidor.seleccionarTodo = True
        Me.txtFTPServidor.Size = New System.Drawing.Size(188, 20)
        Me.txtFTPServidor.TabIndex = 0
        '
        'txtFTPUsuario
        '
        Me.txtFTPUsuario.controlarBotonBorrar = True
        Me.txtFTPUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPUsuario.limpiarAlPulsarBoton = True
        Me.txtFTPUsuario.Location = New System.Drawing.Point(102, 45)
        Me.txtFTPUsuario.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFTPUsuario.mostrarSiempreBotonBorrar = False
        Me.txtFTPUsuario.Name = "txtFTPUsuario"
        Me.txtFTPUsuario.seleccionarTodo = True
        Me.txtFTPUsuario.Size = New System.Drawing.Size(188, 20)
        Me.txtFTPUsuario.TabIndex = 2
        '
        'txtFTPContrasenha
        '
        Me.txtFTPContrasenha.controlarBotonBorrar = True
        Me.txtFTPContrasenha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPContrasenha.limpiarAlPulsarBoton = True
        Me.txtFTPContrasenha.Location = New System.Drawing.Point(102, 67)
        Me.txtFTPContrasenha.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFTPContrasenha.mostrarSiempreBotonBorrar = False
        Me.txtFTPContrasenha.Name = "txtFTPContrasenha"
        Me.txtFTPContrasenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtFTPContrasenha.seleccionarTodo = True
        Me.txtFTPContrasenha.Size = New System.Drawing.Size(188, 20)
        Me.txtFTPContrasenha.TabIndex = 3
        Me.txtFTPContrasenha.UseSystemPasswordChar = True
        '
        'txtFTPRuta
        '
        Me.txtFTPRuta.controlarBotonBorrar = True
        Me.txtFTPRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPRuta.limpiarAlPulsarBoton = True
        Me.txtFTPRuta.Location = New System.Drawing.Point(102, 89)
        Me.txtFTPRuta.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFTPRuta.mostrarSiempreBotonBorrar = False
        Me.txtFTPRuta.Name = "txtFTPRuta"
        Me.txtFTPRuta.seleccionarTodo = True
        Me.txtFTPRuta.Size = New System.Drawing.Size(188, 20)
        Me.txtFTPRuta.TabIndex = 4
        Me.txtFTPRuta.Text = "/"
        '
        'txtURI
        '
        Me.txtURI.controlarBotonBorrar = True
        Me.txtURI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtURI.limpiarAlPulsarBoton = True
        Me.txtURI.Location = New System.Drawing.Point(102, 111)
        Me.txtURI.Margin = New System.Windows.Forms.Padding(1)
        Me.txtURI.mostrarSiempreBotonBorrar = False
        Me.txtURI.Name = "txtURI"
        Me.txtURI.seleccionarTodo = True
        Me.txtURI.Size = New System.Drawing.Size(188, 20)
        Me.txtURI.TabIndex = 5
        '
        'lblFTPPuerto
        '
        Me.lblFTPPuerto.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPPuerto.Location = New System.Drawing.Point(10, 23)
        Me.lblFTPPuerto.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFTPPuerto.Name = "lblFTPPuerto"
        Me.lblFTPPuerto.Size = New System.Drawing.Size(70, 20)
        Me.lblFTPPuerto.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPPuerto.TabIndex = 4
        Me.lblFTPPuerto.Values.Text = "Puerto FTP"
        '
        'txtFTPPuerto
        '
        Me.txtFTPPuerto.controlarBotonBorrar = True
        Me.txtFTPPuerto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPPuerto.limpiarAlPulsarBoton = True
        Me.txtFTPPuerto.Location = New System.Drawing.Point(102, 23)
        Me.txtFTPPuerto.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFTPPuerto.mostrarSiempreBotonBorrar = False
        Me.txtFTPPuerto.Name = "txtFTPPuerto"
        Me.txtFTPPuerto.seleccionarTodo = True
        Me.txtFTPPuerto.Size = New System.Drawing.Size(188, 20)
        Me.txtFTPPuerto.TabIndex = 1
        Me.txtFTPPuerto.Text = "21"
        '
        'tblConfiguracion
        '
        Me.tblConfiguracion.ColumnCount = 2
        Me.tblConfiguracion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblConfiguracion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblConfiguracion.Controls.Add(Me.hdrProyecto, 0, 0)
        Me.tblConfiguracion.Controls.Add(Me.hdrConexion, 1, 0)
        Me.tblConfiguracion.Location = New System.Drawing.Point(1, 143)
        Me.tblConfiguracion.Name = "tblConfiguracion"
        Me.tblConfiguracion.RowCount = 1
        Me.tblConfiguracion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblConfiguracion.Size = New System.Drawing.Size(597, 355)
        Me.tblConfiguracion.TabIndex = 44
        Me.tblConfiguracion.Visible = False
        '
        'txtRutaProyecto
        '
        Me.txtRutaProyecto.Apertura = Recompila.Controles.rTextOpenFile.AperturaTipo.OpenFile
        Me.txtRutaProyecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRutaProyecto.ExtensionesArchivo = "*.rtrad|*.rtrad"
        Me.txtRutaProyecto.IconoApertura = Global.traductorAplicaciones.My.Resources.Resources.folder_open_16_gris_66
        Me.txtRutaProyecto.Location = New System.Drawing.Point(27, 36)
        Me.txtRutaProyecto.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRutaProyecto.Name = "txtRutaProyecto"
        Me.txtRutaProyecto.NombreArchivo = ""
        Me.txtRutaProyecto.RutaInicial = "C:\Users\link3z\Documents"
        Me.txtRutaProyecto.Size = New System.Drawing.Size(518, 24)
        Me.txtRutaProyecto.TabIndex = 7
        '
        'gestorErrores
        '
        Me.gestorErrores.Alineacion = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
        Me.gestorErrores.ContainerControl = Me
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.868914!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.13109!))
        Me.TableLayoutPanel1.Controls.Add(Me.radAbrirProyectoExistente, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRutaProyecto, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.radNuevoProyecto, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(52, 38)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(546, 99)
        Me.TableLayoutPanel1.TabIndex = 45
        '
        'ctrWizard_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.tblConfiguracion)
        Me.Controls.Add(Me.lblTitulo)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrWizard_01"
        Me.Size = New System.Drawing.Size(600, 500)
        CType(Me.hdrProyecto.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrProyecto.Panel.ResumeLayout(False)
        CType(Me.hdrProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrProyecto.ResumeLayout(False)
        Me.tblProyecto.ResumeLayout(False)
        Me.tblProyecto.PerformLayout()
        CType(Me.hdrConexion.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrConexion.Panel.ResumeLayout(False)
        CType(Me.hdrConexion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrConexion.ResumeLayout(False)
        Me.tblConexion.ResumeLayout(False)
        Me.tblConexion.PerformLayout()
        Me.tblConfiguracion.ResumeLayout(False)
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents gestorErrores As Recompila.Controles.rGestorErrores
    Friend WithEvents radNuevoProyecto As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents radAbrirProyectoExistente As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents txtRutaProyecto As Recompila.Controles.rTextOpenFile
    Friend WithEvents hdrProyecto As ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup
    Friend WithEvents tblProyecto As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDescripcion As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblNombre As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents hdrConexion As ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup
    Friend WithEvents tblConexion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFTPServidor As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblFTPUsuario As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblFTPClave As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblFTPRuta As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblFTPURL As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtFTPServidor As Recompila.Controles.rTextBox
    Friend WithEvents txtFTPUsuario As Recompila.Controles.rTextBox
    Friend WithEvents txtFTPContrasenha As Recompila.Controles.rTextBox
    Friend WithEvents txtFTPRuta As Recompila.Controles.rTextBox
    Friend WithEvents txtURI As Recompila.Controles.rTextBox
    Friend WithEvents lblFTPPuerto As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtFTPPuerto As Recompila.Controles.rTextBox
    Friend WithEvents txtNombre As Recompila.Controles.rTextBox
    Friend WithEvents txtDescripcion As Recompila.Controles.rTextBox
    Friend WithEvents tblConfiguracion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
