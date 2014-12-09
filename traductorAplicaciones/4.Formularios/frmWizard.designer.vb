<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWizard
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWizard))
        Me.Estilos = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.Paleta = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.pContenedor = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.krgNavegador = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.webAyuda = New System.Windows.Forms.WebBrowser()
        Me.btnCerrar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnAnterior = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblVersion = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.kpnControles = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnSiguiente = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.paso5 = New Recompila.Controles.rPosicion()
        Me.paso2 = New Recompila.Controles.rPosicion()
        Me.paso3 = New Recompila.Controles.rPosicion()
        Me.paso4 = New Recompila.Controles.rPosicion()
        Me.paso1 = New Recompila.Controles.rPosicion()
        Me.cmbIdioma = New Recompila.Controles.rComboIcon()
        CType(Me.pContenedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pContenedor.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pContenedor.Panel.SuspendLayout()
        Me.pContenedor.SuspendLayout()
        CType(Me.krgNavegador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.krgNavegador.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.krgNavegador.Panel.SuspendLayout()
        Me.krgNavegador.SuspendLayout()
        CType(Me.kpnControles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdioma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Estilos
        '
        Me.Estilos.GlobalStrings.Abort = "Abortar"
        Me.Estilos.GlobalStrings.Cancel = "Cancelar"
        Me.Estilos.GlobalStrings.Close = "Cerrar"
        Me.Estilos.GlobalStrings.Ignore = "Ignorar"
        Me.Estilos.GlobalStrings.OK = "Ok"
        Me.Estilos.GlobalStrings.Retry = "Reintentar"
        Me.Estilos.GlobalStrings.Today = "Hoy"
        Me.Estilos.GlobalStrings.Yes = "Si"
        '
        'Paleta
        '
        Me.Paleta.AllowFormChrome = ComponentFactory.Krypton.Toolkit.InheritBool.[True]
        Me.Paleta.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        Me.Paleta.ButtonStyles.ButtonStandalone.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.Paleta.ButtonStyles.ButtonStandalone.StateCommon.Border.Rounding = 0
        Me.Paleta.ButtonStyles.ButtonStandalone.StateCommon.Border.Width = 1
        Me.Paleta.ButtonStyles.ButtonStandalone.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateDisabled.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateDisabled.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateDisabled.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.Paleta.ButtonStyles.ButtonStandalone.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Paleta.ButtonStyles.ButtonStandalone.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateActive.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateActive.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.Paleta.InputControlStyles.InputControlStandalone.StateActive.Border.Width = 1
        Me.Paleta.InputControlStyles.InputControlStandalone.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.Paleta.InputControlStyles.InputControlStandalone.StateCommon.Border.Rounding = 0
        Me.Paleta.InputControlStyles.InputControlStandalone.StateCommon.Border.Width = 1
        Me.Paleta.InputControlStyles.InputControlStandalone.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateDisabled.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateDisabled.Border.Color2 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateDisabled.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.Paleta.InputControlStyles.InputControlStandalone.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Paleta.InputControlStyles.InputControlStandalone.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Paleta.LabelStyles.LabelCommon.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(120, Byte), Integer))
        '
        'pContenedor
        '
        Me.pContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pContenedor.Name = "pContenedor"
        '
        'pContenedor.Panel
        '
        Me.pContenedor.Panel.Controls.Add(Me.cmbIdioma)
        Me.pContenedor.Panel.Controls.Add(Me.krgNavegador)
        Me.pContenedor.Panel.Controls.Add(Me.btnCerrar)
        Me.pContenedor.Panel.Controls.Add(Me.btnAnterior)
        Me.pContenedor.Panel.Controls.Add(Me.lblVersion)
        Me.pContenedor.Panel.Controls.Add(Me.kpnControles)
        Me.pContenedor.Panel.Controls.Add(Me.btnSiguiente)
        Me.pContenedor.Panel.Controls.Add(Me.paso5)
        Me.pContenedor.Panel.Controls.Add(Me.paso2)
        Me.pContenedor.Panel.Controls.Add(Me.paso3)
        Me.pContenedor.Panel.Controls.Add(Me.paso4)
        Me.pContenedor.Panel.Controls.Add(Me.paso1)
        Me.pContenedor.Size = New System.Drawing.Size(950, 650)
        Me.pContenedor.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.pContenedor.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.pContenedor.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.pContenedor.StateCommon.Border.Width = 2
        Me.pContenedor.TabIndex = 0
        '
        'krgNavegador
        '
        Me.krgNavegador.Location = New System.Drawing.Point(611, 92)
        Me.krgNavegador.Name = "krgNavegador"
        '
        'krgNavegador.Panel
        '
        Me.krgNavegador.Panel.Controls.Add(Me.webAyuda)
        Me.krgNavegador.Size = New System.Drawing.Size(324, 499)
        Me.krgNavegador.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.krgNavegador.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.krgNavegador.TabIndex = 12
        '
        'webAyuda
        '
        Me.webAyuda.AllowWebBrowserDrop = False
        Me.webAyuda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webAyuda.IsWebBrowserContextMenuEnabled = False
        Me.webAyuda.Location = New System.Drawing.Point(0, 0)
        Me.webAyuda.Margin = New System.Windows.Forms.Padding(0)
        Me.webAyuda.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webAyuda.Name = "webAyuda"
        Me.webAyuda.ScriptErrorsSuppressed = True
        Me.webAyuda.Size = New System.Drawing.Size(322, 497)
        Me.webAyuda.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(920, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.OverrideDefault.Back.Color1 = System.Drawing.Color.White
        Me.btnCerrar.OverrideDefault.Back.Color2 = System.Drawing.Color.White
        Me.btnCerrar.OverrideFocus.Back.Color1 = System.Drawing.Color.White
        Me.btnCerrar.OverrideFocus.Back.Color2 = System.Drawing.Color.White
        Me.btnCerrar.Size = New System.Drawing.Size(23, 25)
        Me.btnCerrar.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.btnCerrar.StateCommon.Back.Color2 = System.Drawing.Color.White
        Me.btnCerrar.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.btnCerrar.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCerrar.StateDisabled.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.btnCerrar.StateDisabled.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.btnCerrar.StateDisabled.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCerrar.StateDisabled.Content.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.btnCerrar.StateNormal.Back.Color1 = System.Drawing.Color.White
        Me.btnCerrar.StateNormal.Back.Color2 = System.Drawing.Color.White
        Me.btnCerrar.StatePressed.Back.Color1 = System.Drawing.Color.White
        Me.btnCerrar.StatePressed.Back.Color2 = System.Drawing.Color.White
        Me.btnCerrar.StateTracking.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnCerrar.TabIndex = 11
        Me.btnCerrar.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.close_16_gris_66
        Me.btnCerrar.Values.Text = ""
        Me.btnCerrar.Visible = False
        '
        'btnAnterior
        '
        Me.btnAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnterior.Location = New System.Drawing.Point(690, 606)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Palette = Me.Paleta
        Me.btnAnterior.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnAnterior.Size = New System.Drawing.Size(120, 30)
        Me.btnAnterior.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnAnterior.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnterior.TabIndex = 10
        Me.btnAnterior.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.arrow_left_16_gris_66
        Me.btnAnterior.Values.Text = "Anterior"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Location = New System.Drawing.Point(5, 622)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(41, 14)
        Me.lblVersion.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.TabIndex = 8
        Me.lblVersion.Values.Text = "Versión"
        Me.lblVersion.Visible = False
        '
        'kpnControles
        '
        Me.kpnControles.Location = New System.Drawing.Point(5, 92)
        Me.kpnControles.Name = "kpnControles"
        Me.kpnControles.Size = New System.Drawing.Size(600, 500)
        Me.kpnControles.StateCommon.Color1 = System.Drawing.Color.Transparent
        Me.kpnControles.TabIndex = 7
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSiguiente.Location = New System.Drawing.Point(816, 606)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Palette = Me.Paleta
        Me.btnSiguiente.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnSiguiente.Size = New System.Drawing.Size(120, 30)
        Me.btnSiguiente.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnSiguiente.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.TabIndex = 5
        Me.btnSiguiente.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.arrow_right_16_gris_66
        Me.btnSiguiente.Values.Text = "Siguiente"
        '
        'paso5
        '
        Me.paso5.AlieancionTitulo = System.Drawing.ContentAlignment.BottomCenter
        Me.paso5.BackColor = System.Drawing.Color.Transparent
        Me.paso5.Color = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.paso5.Location = New System.Drawing.Point(732, 13)
        Me.paso5.Margin = New System.Windows.Forms.Padding(1)
        Me.paso5.Name = "paso5"
        Me.paso5.Numero = "5"
        Me.paso5.Size = New System.Drawing.Size(170, 75)
        Me.paso5.TabIndex = 4
        Me.paso5.Titulo = "Traducción finalizada"
        '
        'paso2
        '
        Me.paso2.AlieancionTitulo = System.Drawing.ContentAlignment.BottomCenter
        Me.paso2.BackColor = System.Drawing.Color.Transparent
        Me.paso2.Color = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.paso2.Location = New System.Drawing.Point(204, 13)
        Me.paso2.Margin = New System.Windows.Forms.Padding(1)
        Me.paso2.Name = "paso2"
        Me.paso2.Numero = "2"
        Me.paso2.Size = New System.Drawing.Size(170, 75)
        Me.paso2.TabIndex = 3
        Me.paso2.Titulo = "Seleccionar objetos"
        '
        'paso3
        '
        Me.paso3.AlieancionTitulo = System.Drawing.ContentAlignment.BottomCenter
        Me.paso3.BackColor = System.Drawing.Color.Transparent
        Me.paso3.Color = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.paso3.Location = New System.Drawing.Point(380, 13)
        Me.paso3.Margin = New System.Windows.Forms.Padding(1)
        Me.paso3.Name = "paso3"
        Me.paso3.Numero = "3"
        Me.paso3.Size = New System.Drawing.Size(170, 75)
        Me.paso3.TabIndex = 3
        Me.paso3.Titulo = "Configurar traducción"
        '
        'paso4
        '
        Me.paso4.AlieancionTitulo = System.Drawing.ContentAlignment.BottomCenter
        Me.paso4.BackColor = System.Drawing.Color.Transparent
        Me.paso4.Color = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.paso4.Location = New System.Drawing.Point(556, 13)
        Me.paso4.Margin = New System.Windows.Forms.Padding(1)
        Me.paso4.Name = "paso4"
        Me.paso4.Numero = "4"
        Me.paso4.Size = New System.Drawing.Size(170, 75)
        Me.paso4.TabIndex = 1
        Me.paso4.Titulo = "Realizar traducción"
        '
        'paso1
        '
        Me.paso1.AlieancionTitulo = System.Drawing.ContentAlignment.BottomCenter
        Me.paso1.BackColor = System.Drawing.Color.Transparent
        Me.paso1.Color = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.paso1.Location = New System.Drawing.Point(28, 13)
        Me.paso1.Margin = New System.Windows.Forms.Padding(1)
        Me.paso1.Name = "paso1"
        Me.paso1.Numero = "1"
        Me.paso1.Size = New System.Drawing.Size(170, 75)
        Me.paso1.TabIndex = 0
        Me.paso1.Titulo = "Seleccionar operación"
        '
        'cmbIdioma
        '
        Me.cmbIdioma.conBorde = True
        Me.cmbIdioma.controlarBotonBorrar = True
        Me.cmbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdioma.DropDownWidth = 178
        Me.cmbIdioma.limpiarAlPulsarBoton = True
        Me.cmbIdioma.Location = New System.Drawing.Point(506, 615)
        Me.cmbIdioma.mostrarSiempreBotonBorrar = False
        Me.cmbIdioma.Name = "cmbIdioma"
        Me.cmbIdioma.Size = New System.Drawing.Size(178, 21)
        Me.cmbIdioma.StateCommon.ComboBox.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[True]
        Me.cmbIdioma.StateCommon.ComboBox.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.cmbIdioma.TabIndex = 46
        '
        'frmWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(950, 650)
        Me.ControlBox = False
        Me.Controls.Add(Me.pContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWizard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DF-SERVER EVO"
        CType(Me.pContenedor.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pContenedor.Panel.ResumeLayout(False)
        Me.pContenedor.Panel.PerformLayout()
        CType(Me.pContenedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pContenedor.ResumeLayout(False)
        CType(Me.krgNavegador.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.krgNavegador.Panel.ResumeLayout(False)
        CType(Me.krgNavegador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.krgNavegador.ResumeLayout(False)
        CType(Me.kpnControles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdioma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents pContenedor As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents paso1 As Recompila.Controles.rPosicion
    Friend WithEvents paso5 As Recompila.Controles.rPosicion
    Friend WithEvents paso2 As Recompila.Controles.rPosicion
    Friend WithEvents paso3 As Recompila.Controles.rPosicion
    Friend WithEvents paso4 As Recompila.Controles.rPosicion
    Friend WithEvents btnSiguiente As ComponentFactory.Krypton.Toolkit.KryptonButton
    Private WithEvents Estilos As ComponentFactory.Krypton.Toolkit.KryptonManager
    Private WithEvents Paleta As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents kpnControles As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblVersion As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnAnterior As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCerrar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents krgNavegador As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents webAyuda As System.Windows.Forms.WebBrowser
    Friend WithEvents cmbIdioma As Recompila.Controles.rComboIcon

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
