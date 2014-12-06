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
        Me.radOperacionNuevo = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.radOperacionAbrir = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.hdrTraduccion = New ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup()
        Me.tblTraduccion = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTraduccionDescripcion = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblTraduccionNombre = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtTraduccionNombre = New Recompila.Controles.rTextBox()
        Me.txtTraduccionDescripcion = New Recompila.Controles.rTextBox()
        Me.hdrConexion = New ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup()
        Me.tblConfiguracionConexion = New System.Windows.Forms.TableLayoutPanel()
        Me.lblConexionFTPServidor = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblConexionFTPUsuario = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblConexionFTPClave = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblConexionFTPRuta = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblConexionHTTP = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtConexionFTPServidor = New Recompila.Controles.rTextBox()
        Me.txtConexionFTPUsuario = New Recompila.Controles.rTextBox()
        Me.txtConexionFTPClave = New Recompila.Controles.rTextBox()
        Me.txtConexionFTPRuta = New Recompila.Controles.rTextBox()
        Me.txtConexionHTTP = New Recompila.Controles.rTextBox()
        Me.lblConexionFTPPuerto = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtConexionFTPPuerto = New Recompila.Controles.rTextBox()
        Me.tblControles = New System.Windows.Forms.TableLayoutPanel()
        Me.hdrOperacion = New ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup()
        Me.tblOperacion = New System.Windows.Forms.TableLayoutPanel()
        Me.gestorErrores = New Recompila.Controles.rGestorErrores()
        Me.txtOperacionRuta = New Recompila.Controles.rTextOpenFile()
        CType(Me.hdrTraduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hdrTraduccion.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hdrTraduccion.Panel.SuspendLayout()
        Me.hdrTraduccion.SuspendLayout()
        Me.tblTraduccion.SuspendLayout()
        CType(Me.hdrConexion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hdrConexion.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hdrConexion.Panel.SuspendLayout()
        Me.hdrConexion.SuspendLayout()
        Me.tblConfiguracionConexion.SuspendLayout()
        Me.tblControles.SuspendLayout()
        CType(Me.hdrOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hdrOperacion.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hdrOperacion.Panel.SuspendLayout()
        Me.hdrOperacion.SuspendLayout()
        Me.tblOperacion.SuspendLayout()
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'radOperacionNuevo
        '
        Me.tblOperacion.SetColumnSpan(Me.radOperacionNuevo, 2)
        Me.radOperacionNuevo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radOperacionNuevo.Location = New System.Drawing.Point(1, 49)
        Me.radOperacionNuevo.Margin = New System.Windows.Forms.Padding(1)
        Me.radOperacionNuevo.Name = "radOperacionNuevo"
        Me.radOperacionNuevo.Size = New System.Drawing.Size(563, 20)
        Me.radOperacionNuevo.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.radOperacionNuevo.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.radOperacionNuevo.TabIndex = 5
        Me.radOperacionNuevo.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.add_16_gris_66
        Me.radOperacionNuevo.Values.Text = "Iniciar una nueva traducción"
        '
        'radOperacionAbrir
        '
        Me.radOperacionAbrir.Checked = True
        Me.tblOperacion.SetColumnSpan(Me.radOperacionAbrir, 2)
        Me.radOperacionAbrir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radOperacionAbrir.Location = New System.Drawing.Point(1, 1)
        Me.radOperacionAbrir.Margin = New System.Windows.Forms.Padding(1)
        Me.radOperacionAbrir.Name = "radOperacionAbrir"
        Me.radOperacionAbrir.Size = New System.Drawing.Size(563, 20)
        Me.radOperacionAbrir.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.radOperacionAbrir.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.radOperacionAbrir.TabIndex = 6
        Me.radOperacionAbrir.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.folder_open_16_gris_66
        Me.radOperacionAbrir.Values.Text = "Abrir una traducción existente"
        '
        'hdrTraduccion
        '
        Me.hdrTraduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hdrTraduccion.Enabled = False
        Me.hdrTraduccion.HeaderVisibleSecondary = False
        Me.hdrTraduccion.Location = New System.Drawing.Point(3, 109)
        Me.hdrTraduccion.Name = "hdrTraduccion"
        '
        'hdrTraduccion.Panel
        '
        Me.hdrTraduccion.Panel.Controls.Add(Me.tblTraduccion)
        Me.hdrTraduccion.Panel.Padding = New System.Windows.Forms.Padding(24, 5, 0, 0)
        Me.hdrTraduccion.Size = New System.Drawing.Size(591, 141)
        Me.hdrTraduccion.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.hdrTraduccion.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.hdrTraduccion.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrTraduccion.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrTraduccion.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.hdrTraduccion.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.hdrTraduccion.StateCommon.HeaderPrimary.Back.Color1 = System.Drawing.Color.Transparent
        Me.hdrTraduccion.StateCommon.HeaderPrimary.Back.Color2 = System.Drawing.Color.Transparent
        Me.hdrTraduccion.StateCommon.HeaderPrimary.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom
        Me.hdrTraduccion.StateCommon.HeaderPrimary.Content.LongText.Color1 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.hdrTraduccion.StateCommon.HeaderPrimary.Content.LongText.Color2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.hdrTraduccion.StateCommon.HeaderPrimary.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrTraduccion.StateCommon.HeaderPrimary.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrTraduccion.StateCommon.HeaderPrimary.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hdrTraduccion.TabIndex = 42
        Me.hdrTraduccion.ValuesPrimary.Heading = "Datos de la traducción"
        Me.hdrTraduccion.ValuesPrimary.Image = Global.traductorAplicaciones.My.Resources.Resources.cog_16_gris_66
        '
        'tblTraduccion
        '
        Me.tblTraduccion.BackColor = System.Drawing.Color.Transparent
        Me.tblTraduccion.ColumnCount = 3
        Me.tblTraduccion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTraduccion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTraduccion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblTraduccion.Controls.Add(Me.lblTraduccionDescripcion, 0, 1)
        Me.tblTraduccion.Controls.Add(Me.lblTraduccionNombre, 0, 0)
        Me.tblTraduccion.Controls.Add(Me.txtTraduccionNombre, 2, 0)
        Me.tblTraduccion.Controls.Add(Me.txtTraduccionDescripcion, 0, 2)
        Me.tblTraduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTraduccion.Location = New System.Drawing.Point(24, 5)
        Me.tblTraduccion.Name = "tblTraduccion"
        Me.tblTraduccion.RowCount = 3
        Me.tblTraduccion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTraduccion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTraduccion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTraduccion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTraduccion.Size = New System.Drawing.Size(565, 113)
        Me.tblTraduccion.TabIndex = 0
        '
        'lblTraduccionDescripcion
        '
        Me.lblTraduccionDescripcion.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTraduccionDescripcion.Location = New System.Drawing.Point(1, 23)
        Me.lblTraduccionDescripcion.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTraduccionDescripcion.Name = "lblTraduccionDescripcion"
        Me.lblTraduccionDescripcion.Size = New System.Drawing.Size(72, 16)
        Me.lblTraduccionDescripcion.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTraduccionDescripcion.TabIndex = 0
        Me.lblTraduccionDescripcion.Values.Text = "Descripción"
        '
        'lblTraduccionNombre
        '
        Me.lblTraduccionNombre.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTraduccionNombre.Location = New System.Drawing.Point(21, 1)
        Me.lblTraduccionNombre.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTraduccionNombre.Name = "lblTraduccionNombre"
        Me.lblTraduccionNombre.Size = New System.Drawing.Size(52, 20)
        Me.lblTraduccionNombre.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTraduccionNombre.TabIndex = 18
        Me.lblTraduccionNombre.Values.Text = "Nombre"
        '
        'txtTraduccionNombre
        '
        Me.txtTraduccionNombre.controlarBotonBorrar = True
        Me.txtTraduccionNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTraduccionNombre.limpiarAlPulsarBoton = True
        Me.txtTraduccionNombre.Location = New System.Drawing.Point(95, 1)
        Me.txtTraduccionNombre.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTraduccionNombre.mostrarSiempreBotonBorrar = False
        Me.txtTraduccionNombre.Name = "txtTraduccionNombre"
        Me.txtTraduccionNombre.seleccionarTodo = True
        Me.txtTraduccionNombre.Size = New System.Drawing.Size(469, 20)
        Me.txtTraduccionNombre.TabIndex = 21
        '
        'txtTraduccionDescripcion
        '
        Me.tblTraduccion.SetColumnSpan(Me.txtTraduccionDescripcion, 3)
        Me.txtTraduccionDescripcion.controlarBotonBorrar = False
        Me.txtTraduccionDescripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTraduccionDescripcion.limpiarAlPulsarBoton = True
        Me.txtTraduccionDescripcion.Location = New System.Drawing.Point(1, 41)
        Me.txtTraduccionDescripcion.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTraduccionDescripcion.mostrarSiempreBotonBorrar = False
        Me.txtTraduccionDescripcion.Multiline = True
        Me.txtTraduccionDescripcion.Name = "txtTraduccionDescripcion"
        Me.txtTraduccionDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTraduccionDescripcion.seleccionarTodo = True
        Me.txtTraduccionDescripcion.Size = New System.Drawing.Size(563, 71)
        Me.txtTraduccionDescripcion.TabIndex = 21
        '
        'hdrConexion
        '
        Me.hdrConexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hdrConexion.HeaderVisibleSecondary = False
        Me.hdrConexion.Location = New System.Drawing.Point(3, 256)
        Me.hdrConexion.Name = "hdrConexion"
        '
        'hdrConexion.Panel
        '
        Me.hdrConexion.Panel.Controls.Add(Me.tblConfiguracionConexion)
        Me.hdrConexion.Panel.Padding = New System.Windows.Forms.Padding(24, 5, 0, 0)
        Me.hdrConexion.Size = New System.Drawing.Size(591, 166)
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
        Me.hdrConexion.ValuesPrimary.Image = Global.traductorAplicaciones.My.Resources.Resources.connect_16_gris_66
        '
        'tblConfiguracionConexion
        '
        Me.tblConfiguracionConexion.BackColor = System.Drawing.Color.Transparent
        Me.tblConfiguracionConexion.ColumnCount = 3
        Me.tblConfiguracionConexion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblConfiguracionConexion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblConfiguracionConexion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblConfiguracionConexion.Controls.Add(Me.lblConexionFTPServidor, 0, 0)
        Me.tblConfiguracionConexion.Controls.Add(Me.lblConexionFTPUsuario, 0, 2)
        Me.tblConfiguracionConexion.Controls.Add(Me.lblConexionFTPClave, 0, 3)
        Me.tblConfiguracionConexion.Controls.Add(Me.lblConexionFTPRuta, 0, 4)
        Me.tblConfiguracionConexion.Controls.Add(Me.lblConexionHTTP, 0, 5)
        Me.tblConfiguracionConexion.Controls.Add(Me.txtConexionFTPServidor, 2, 0)
        Me.tblConfiguracionConexion.Controls.Add(Me.txtConexionFTPUsuario, 2, 2)
        Me.tblConfiguracionConexion.Controls.Add(Me.txtConexionFTPClave, 2, 3)
        Me.tblConfiguracionConexion.Controls.Add(Me.txtConexionFTPRuta, 2, 4)
        Me.tblConfiguracionConexion.Controls.Add(Me.txtConexionHTTP, 2, 5)
        Me.tblConfiguracionConexion.Controls.Add(Me.lblConexionFTPPuerto, 0, 1)
        Me.tblConfiguracionConexion.Controls.Add(Me.txtConexionFTPPuerto, 2, 1)
        Me.tblConfiguracionConexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblConfiguracionConexion.Location = New System.Drawing.Point(24, 5)
        Me.tblConfiguracionConexion.Name = "tblConfiguracionConexion"
        Me.tblConfiguracionConexion.RowCount = 7
        Me.tblConfiguracionConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConfiguracionConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConfiguracionConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConfiguracionConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConfiguracionConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConfiguracionConexion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblConfiguracionConexion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblConfiguracionConexion.Size = New System.Drawing.Size(565, 138)
        Me.tblConfiguracionConexion.TabIndex = 3
        '
        'lblConexionFTPServidor
        '
        Me.lblConexionFTPServidor.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblConexionFTPServidor.Location = New System.Drawing.Point(1, 1)
        Me.lblConexionFTPServidor.Margin = New System.Windows.Forms.Padding(1)
        Me.lblConexionFTPServidor.Name = "lblConexionFTPServidor"
        Me.lblConexionFTPServidor.Size = New System.Drawing.Size(79, 20)
        Me.lblConexionFTPServidor.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConexionFTPServidor.TabIndex = 4
        Me.lblConexionFTPServidor.Values.Text = "Servidor FTP"
        '
        'lblConexionFTPUsuario
        '
        Me.lblConexionFTPUsuario.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblConexionFTPUsuario.Location = New System.Drawing.Point(4, 45)
        Me.lblConexionFTPUsuario.Margin = New System.Windows.Forms.Padding(1)
        Me.lblConexionFTPUsuario.Name = "lblConexionFTPUsuario"
        Me.lblConexionFTPUsuario.Size = New System.Drawing.Size(76, 20)
        Me.lblConexionFTPUsuario.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConexionFTPUsuario.TabIndex = 4
        Me.lblConexionFTPUsuario.Values.Text = "Usuario FTP"
        '
        'lblConexionFTPClave
        '
        Me.lblConexionFTPClave.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblConexionFTPClave.Location = New System.Drawing.Point(14, 67)
        Me.lblConexionFTPClave.Margin = New System.Windows.Forms.Padding(1)
        Me.lblConexionFTPClave.Name = "lblConexionFTPClave"
        Me.lblConexionFTPClave.Size = New System.Drawing.Size(66, 20)
        Me.lblConexionFTPClave.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConexionFTPClave.TabIndex = 4
        Me.lblConexionFTPClave.Values.Text = "Clave FTP"
        '
        'lblConexionFTPRuta
        '
        Me.lblConexionFTPRuta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblConexionFTPRuta.Location = New System.Drawing.Point(20, 89)
        Me.lblConexionFTPRuta.Margin = New System.Windows.Forms.Padding(1)
        Me.lblConexionFTPRuta.Name = "lblConexionFTPRuta"
        Me.lblConexionFTPRuta.Size = New System.Drawing.Size(60, 20)
        Me.lblConexionFTPRuta.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConexionFTPRuta.TabIndex = 4
        Me.lblConexionFTPRuta.Values.Text = "Ruta FTP"
        '
        'lblConexionHTTP
        '
        Me.lblConexionHTTP.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblConexionHTTP.Location = New System.Drawing.Point(6, 111)
        Me.lblConexionHTTP.Margin = New System.Windows.Forms.Padding(1)
        Me.lblConexionHTTP.Name = "lblConexionHTTP"
        Me.lblConexionHTTP.Size = New System.Drawing.Size(74, 20)
        Me.lblConexionHTTP.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConexionHTTP.TabIndex = 4
        Me.lblConexionHTTP.Values.Text = "URL acceso"
        '
        'txtConexionFTPServidor
        '
        Me.txtConexionFTPServidor.controlarBotonBorrar = True
        Me.txtConexionFTPServidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConexionFTPServidor.limpiarAlPulsarBoton = True
        Me.txtConexionFTPServidor.Location = New System.Drawing.Point(102, 1)
        Me.txtConexionFTPServidor.Margin = New System.Windows.Forms.Padding(1)
        Me.txtConexionFTPServidor.mostrarSiempreBotonBorrar = False
        Me.txtConexionFTPServidor.Name = "txtConexionFTPServidor"
        Me.txtConexionFTPServidor.seleccionarTodo = True
        Me.txtConexionFTPServidor.Size = New System.Drawing.Size(462, 20)
        Me.txtConexionFTPServidor.TabIndex = 0
        '
        'txtConexionFTPUsuario
        '
        Me.txtConexionFTPUsuario.controlarBotonBorrar = True
        Me.txtConexionFTPUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConexionFTPUsuario.limpiarAlPulsarBoton = True
        Me.txtConexionFTPUsuario.Location = New System.Drawing.Point(102, 45)
        Me.txtConexionFTPUsuario.Margin = New System.Windows.Forms.Padding(1)
        Me.txtConexionFTPUsuario.mostrarSiempreBotonBorrar = False
        Me.txtConexionFTPUsuario.Name = "txtConexionFTPUsuario"
        Me.txtConexionFTPUsuario.seleccionarTodo = True
        Me.txtConexionFTPUsuario.Size = New System.Drawing.Size(462, 20)
        Me.txtConexionFTPUsuario.TabIndex = 2
        '
        'txtConexionFTPClave
        '
        Me.txtConexionFTPClave.controlarBotonBorrar = True
        Me.txtConexionFTPClave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConexionFTPClave.limpiarAlPulsarBoton = True
        Me.txtConexionFTPClave.Location = New System.Drawing.Point(102, 67)
        Me.txtConexionFTPClave.Margin = New System.Windows.Forms.Padding(1)
        Me.txtConexionFTPClave.mostrarSiempreBotonBorrar = False
        Me.txtConexionFTPClave.Name = "txtConexionFTPClave"
        Me.txtConexionFTPClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtConexionFTPClave.seleccionarTodo = True
        Me.txtConexionFTPClave.Size = New System.Drawing.Size(462, 20)
        Me.txtConexionFTPClave.TabIndex = 3
        Me.txtConexionFTPClave.UseSystemPasswordChar = True
        '
        'txtConexionFTPRuta
        '
        Me.txtConexionFTPRuta.controlarBotonBorrar = True
        Me.txtConexionFTPRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConexionFTPRuta.limpiarAlPulsarBoton = True
        Me.txtConexionFTPRuta.Location = New System.Drawing.Point(102, 89)
        Me.txtConexionFTPRuta.Margin = New System.Windows.Forms.Padding(1)
        Me.txtConexionFTPRuta.mostrarSiempreBotonBorrar = False
        Me.txtConexionFTPRuta.Name = "txtConexionFTPRuta"
        Me.txtConexionFTPRuta.seleccionarTodo = True
        Me.txtConexionFTPRuta.Size = New System.Drawing.Size(462, 20)
        Me.txtConexionFTPRuta.TabIndex = 4
        Me.txtConexionFTPRuta.Text = "/"
        '
        'txtConexionHTTP
        '
        Me.txtConexionHTTP.controlarBotonBorrar = True
        Me.txtConexionHTTP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConexionHTTP.limpiarAlPulsarBoton = True
        Me.txtConexionHTTP.Location = New System.Drawing.Point(102, 111)
        Me.txtConexionHTTP.Margin = New System.Windows.Forms.Padding(1)
        Me.txtConexionHTTP.mostrarSiempreBotonBorrar = False
        Me.txtConexionHTTP.Name = "txtConexionHTTP"
        Me.txtConexionHTTP.seleccionarTodo = True
        Me.txtConexionHTTP.Size = New System.Drawing.Size(462, 20)
        Me.txtConexionHTTP.TabIndex = 5
        '
        'lblConexionFTPPuerto
        '
        Me.lblConexionFTPPuerto.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblConexionFTPPuerto.Location = New System.Drawing.Point(10, 23)
        Me.lblConexionFTPPuerto.Margin = New System.Windows.Forms.Padding(1)
        Me.lblConexionFTPPuerto.Name = "lblConexionFTPPuerto"
        Me.lblConexionFTPPuerto.Size = New System.Drawing.Size(70, 20)
        Me.lblConexionFTPPuerto.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConexionFTPPuerto.TabIndex = 4
        Me.lblConexionFTPPuerto.Values.Text = "Puerto FTP"
        '
        'txtConexionFTPPuerto
        '
        Me.txtConexionFTPPuerto.controlarBotonBorrar = True
        Me.txtConexionFTPPuerto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConexionFTPPuerto.limpiarAlPulsarBoton = True
        Me.txtConexionFTPPuerto.Location = New System.Drawing.Point(102, 23)
        Me.txtConexionFTPPuerto.Margin = New System.Windows.Forms.Padding(1)
        Me.txtConexionFTPPuerto.mostrarSiempreBotonBorrar = False
        Me.txtConexionFTPPuerto.Name = "txtConexionFTPPuerto"
        Me.txtConexionFTPPuerto.seleccionarTodo = True
        Me.txtConexionFTPPuerto.Size = New System.Drawing.Size(462, 20)
        Me.txtConexionFTPPuerto.TabIndex = 1
        Me.txtConexionFTPPuerto.Text = "21"
        '
        'tblControles
        '
        Me.tblControles.ColumnCount = 1
        Me.tblControles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblControles.Controls.Add(Me.hdrOperacion, 0, 0)
        Me.tblControles.Controls.Add(Me.hdrConexion, 0, 2)
        Me.tblControles.Controls.Add(Me.hdrTraduccion, 0, 1)
        Me.tblControles.Location = New System.Drawing.Point(3, 41)
        Me.tblControles.Name = "tblControles"
        Me.tblControles.RowCount = 3
        Me.tblControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblControles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblControles.Size = New System.Drawing.Size(597, 425)
        Me.tblControles.TabIndex = 44
        '
        'hdrOperacion
        '
        Me.hdrOperacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hdrOperacion.HeaderVisibleSecondary = False
        Me.hdrOperacion.Location = New System.Drawing.Point(3, 3)
        Me.hdrOperacion.Name = "hdrOperacion"
        '
        'hdrOperacion.Panel
        '
        Me.hdrOperacion.Panel.Controls.Add(Me.tblOperacion)
        Me.hdrOperacion.Panel.Padding = New System.Windows.Forms.Padding(24, 5, 0, 0)
        Me.hdrOperacion.Size = New System.Drawing.Size(591, 100)
        Me.hdrOperacion.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.hdrOperacion.StateCommon.Back.Color2 = System.Drawing.Color.Transparent
        Me.hdrOperacion.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrOperacion.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrOperacion.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.hdrOperacion.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.hdrOperacion.StateCommon.HeaderPrimary.Back.Color1 = System.Drawing.Color.Transparent
        Me.hdrOperacion.StateCommon.HeaderPrimary.Back.Color2 = System.Drawing.Color.Transparent
        Me.hdrOperacion.StateCommon.HeaderPrimary.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom
        Me.hdrOperacion.StateCommon.HeaderPrimary.Content.LongText.Color1 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.hdrOperacion.StateCommon.HeaderPrimary.Content.LongText.Color2 = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.hdrOperacion.StateCommon.HeaderPrimary.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrOperacion.StateCommon.HeaderPrimary.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.hdrOperacion.StateCommon.HeaderPrimary.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hdrOperacion.TabIndex = 46
        Me.hdrOperacion.ValuesPrimary.Heading = "Abrir/Crear una nueva traducción"
        Me.hdrOperacion.ValuesPrimary.Image = Global.traductorAplicaciones.My.Resources.Resources.page_bold_16_gris_66
        '
        'tblOperacion
        '
        Me.tblOperacion.BackColor = System.Drawing.Color.Transparent
        Me.tblOperacion.ColumnCount = 2
        Me.tblOperacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.868914!))
        Me.tblOperacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.13109!))
        Me.tblOperacion.Controls.Add(Me.radOperacionAbrir, 0, 0)
        Me.tblOperacion.Controls.Add(Me.txtOperacionRuta, 1, 1)
        Me.tblOperacion.Controls.Add(Me.radOperacionNuevo, 0, 2)
        Me.tblOperacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblOperacion.Location = New System.Drawing.Point(24, 5)
        Me.tblOperacion.Name = "tblOperacion"
        Me.tblOperacion.RowCount = 4
        Me.tblOperacion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOperacion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOperacion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOperacion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblOperacion.Size = New System.Drawing.Size(565, 72)
        Me.tblOperacion.TabIndex = 45
        '
        'gestorErrores
        '
        Me.gestorErrores.Alineacion = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
        Me.gestorErrores.ContainerControl = Me
        '
        'txtOperacionRuta
        '
        Me.txtOperacionRuta.Apertura = Recompila.Controles.rTextOpenFile.AperturaTipo.OpenFile
        Me.txtOperacionRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOperacionRuta.ExtensionesArchivo = "*.rtrad|*.rtrad"
        Me.txtOperacionRuta.IconoApertura = Global.traductorAplicaciones.My.Resources.Resources.folder_open_16_gris_66
        Me.txtOperacionRuta.Location = New System.Drawing.Point(28, 23)
        Me.txtOperacionRuta.Margin = New System.Windows.Forms.Padding(1)
        Me.txtOperacionRuta.Name = "txtOperacionRuta"
        Me.txtOperacionRuta.NombreArchivo = ""
        Me.txtOperacionRuta.RutaInicial = "C:\Users\link3z\Documents"
        Me.txtOperacionRuta.Size = New System.Drawing.Size(536, 24)
        Me.txtOperacionRuta.TabIndex = 7
        '
        'ctrWizard_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.tblControles)
        Me.Controls.Add(Me.lblTitulo)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrWizard_01"
        Me.Size = New System.Drawing.Size(600, 500)
        CType(Me.hdrTraduccion.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrTraduccion.Panel.ResumeLayout(False)
        CType(Me.hdrTraduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrTraduccion.ResumeLayout(False)
        Me.tblTraduccion.ResumeLayout(False)
        Me.tblTraduccion.PerformLayout()
        CType(Me.hdrConexion.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrConexion.Panel.ResumeLayout(False)
        CType(Me.hdrConexion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrConexion.ResumeLayout(False)
        Me.tblConfiguracionConexion.ResumeLayout(False)
        Me.tblConfiguracionConexion.PerformLayout()
        Me.tblControles.ResumeLayout(False)
        CType(Me.hdrOperacion.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrOperacion.Panel.ResumeLayout(False)
        CType(Me.hdrOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hdrOperacion.ResumeLayout(False)
        Me.tblOperacion.ResumeLayout(False)
        Me.tblOperacion.PerformLayout()
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents gestorErrores As Recompila.Controles.rGestorErrores
    Friend WithEvents radOperacionNuevo As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents radOperacionAbrir As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents txtOperacionRuta As Recompila.Controles.rTextOpenFile
    Friend WithEvents hdrTraduccion As ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup
    Friend WithEvents tblTraduccion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTraduccionDescripcion As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblTraduccionNombre As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents hdrConexion As ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup
    Friend WithEvents tblConfiguracionConexion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblConexionFTPServidor As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblConexionFTPUsuario As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblConexionFTPClave As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblConexionFTPRuta As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblConexionHTTP As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtConexionFTPServidor As Recompila.Controles.rTextBox
    Friend WithEvents txtConexionFTPUsuario As Recompila.Controles.rTextBox
    Friend WithEvents txtConexionFTPClave As Recompila.Controles.rTextBox
    Friend WithEvents txtConexionFTPRuta As Recompila.Controles.rTextBox
    Friend WithEvents txtConexionHTTP As Recompila.Controles.rTextBox
    Friend WithEvents lblConexionFTPPuerto As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtConexionFTPPuerto As Recompila.Controles.rTextBox
    Friend WithEvents txtTraduccionNombre As Recompila.Controles.rTextBox
    Friend WithEvents txtTraduccionDescripcion As Recompila.Controles.rTextBox
    Friend WithEvents tblControles As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblOperacion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents hdrOperacion As ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup

End Class
