<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigurarFTP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigurarFTP))
        Me.btnCancelar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnAceptar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.tblDatosFTP = New System.Windows.Forms.TableLayoutPanel()
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
        Me.gestorErrores = New Recompila.Controles.rGestorErrores()
        Me.tblDatosFTP.SuspendLayout()
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(189, 169)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 30)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.close_16_gris_66
        Me.btnCancelar.Values.Text = "&Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(315, 169)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 30)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Values.Image = Global.traductorAplicaciones.My.Resources.Resources.check_16_gris_66
        Me.btnAceptar.Values.Text = "&Aceptar"
        '
        'tblDatosFTP
        '
        Me.tblDatosFTP.BackColor = System.Drawing.Color.Transparent
        Me.tblDatosFTP.ColumnCount = 3
        Me.tblDatosFTP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDatosFTP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblDatosFTP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDatosFTP.Controls.Add(Me.lblFTPServidor, 0, 0)
        Me.tblDatosFTP.Controls.Add(Me.lblFTPUsuario, 0, 2)
        Me.tblDatosFTP.Controls.Add(Me.lblFTPClave, 0, 3)
        Me.tblDatosFTP.Controls.Add(Me.lblFTPRuta, 0, 4)
        Me.tblDatosFTP.Controls.Add(Me.lblFTPURL, 0, 5)
        Me.tblDatosFTP.Controls.Add(Me.txtFTPServidor, 2, 0)
        Me.tblDatosFTP.Controls.Add(Me.txtFTPUsuario, 2, 2)
        Me.tblDatosFTP.Controls.Add(Me.txtFTPContrasenha, 2, 3)
        Me.tblDatosFTP.Controls.Add(Me.txtFTPRuta, 2, 4)
        Me.tblDatosFTP.Controls.Add(Me.txtURI, 2, 5)
        Me.tblDatosFTP.Controls.Add(Me.lblFTPPuerto, 0, 1)
        Me.tblDatosFTP.Controls.Add(Me.txtFTPPuerto, 2, 1)
        Me.tblDatosFTP.Location = New System.Drawing.Point(12, 12)
        Me.tblDatosFTP.Name = "tblDatosFTP"
        Me.tblDatosFTP.RowCount = 7
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblDatosFTP.Size = New System.Drawing.Size(423, 151)
        Me.tblDatosFTP.TabIndex = 2
        '
        'lblFTPServidor
        '
        Me.lblFTPServidor.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPServidor.Location = New System.Drawing.Point(19, 2)
        Me.lblFTPServidor.Margin = New System.Windows.Forms.Padding(2)
        Me.lblFTPServidor.Name = "lblFTPServidor"
        Me.lblFTPServidor.Size = New System.Drawing.Size(54, 20)
        Me.lblFTPServidor.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPServidor.TabIndex = 4
        Me.lblFTPServidor.Values.Text = "Servidor"
        '
        'lblFTPUsuario
        '
        Me.lblFTPUsuario.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPUsuario.Location = New System.Drawing.Point(22, 50)
        Me.lblFTPUsuario.Margin = New System.Windows.Forms.Padding(2)
        Me.lblFTPUsuario.Name = "lblFTPUsuario"
        Me.lblFTPUsuario.Size = New System.Drawing.Size(51, 20)
        Me.lblFTPUsuario.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPUsuario.TabIndex = 4
        Me.lblFTPUsuario.Values.Text = "Usuario"
        '
        'lblFTPClave
        '
        Me.lblFTPClave.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPClave.Location = New System.Drawing.Point(2, 74)
        Me.lblFTPClave.Margin = New System.Windows.Forms.Padding(2)
        Me.lblFTPClave.Name = "lblFTPClave"
        Me.lblFTPClave.Size = New System.Drawing.Size(71, 20)
        Me.lblFTPClave.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPClave.TabIndex = 4
        Me.lblFTPClave.Values.Text = "Contraseña"
        '
        'lblFTPRuta
        '
        Me.lblFTPRuta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPRuta.Location = New System.Drawing.Point(38, 98)
        Me.lblFTPRuta.Margin = New System.Windows.Forms.Padding(2)
        Me.lblFTPRuta.Name = "lblFTPRuta"
        Me.lblFTPRuta.Size = New System.Drawing.Size(35, 20)
        Me.lblFTPRuta.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPRuta.TabIndex = 4
        Me.lblFTPRuta.Values.Text = "Ruta"
        '
        'lblFTPURL
        '
        Me.lblFTPURL.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPURL.Location = New System.Drawing.Point(40, 122)
        Me.lblFTPURL.Margin = New System.Windows.Forms.Padding(2)
        Me.lblFTPURL.Name = "lblFTPURL"
        Me.lblFTPURL.Size = New System.Drawing.Size(33, 20)
        Me.lblFTPURL.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPURL.TabIndex = 4
        Me.lblFTPURL.Values.Text = "URL"
        '
        'txtFTPServidor
        '
        Me.txtFTPServidor.controlarBotonBorrar = True
        Me.txtFTPServidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPServidor.limpiarAlPulsarBoton = True
        Me.txtFTPServidor.Location = New System.Drawing.Point(97, 2)
        Me.txtFTPServidor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFTPServidor.mostrarSiempreBotonBorrar = False
        Me.txtFTPServidor.Name = "txtFTPServidor"
        Me.txtFTPServidor.seleccionarTodo = True
        Me.txtFTPServidor.Size = New System.Drawing.Size(324, 20)
        Me.txtFTPServidor.TabIndex = 0
        '
        'txtFTPUsuario
        '
        Me.txtFTPUsuario.controlarBotonBorrar = True
        Me.txtFTPUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPUsuario.limpiarAlPulsarBoton = True
        Me.txtFTPUsuario.Location = New System.Drawing.Point(97, 50)
        Me.txtFTPUsuario.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFTPUsuario.mostrarSiempreBotonBorrar = False
        Me.txtFTPUsuario.Name = "txtFTPUsuario"
        Me.txtFTPUsuario.seleccionarTodo = True
        Me.txtFTPUsuario.Size = New System.Drawing.Size(324, 20)
        Me.txtFTPUsuario.TabIndex = 2
        '
        'txtFTPContrasenha
        '
        Me.txtFTPContrasenha.controlarBotonBorrar = True
        Me.txtFTPContrasenha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPContrasenha.limpiarAlPulsarBoton = True
        Me.txtFTPContrasenha.Location = New System.Drawing.Point(97, 74)
        Me.txtFTPContrasenha.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFTPContrasenha.mostrarSiempreBotonBorrar = False
        Me.txtFTPContrasenha.Name = "txtFTPContrasenha"
        Me.txtFTPContrasenha.seleccionarTodo = True
        Me.txtFTPContrasenha.Size = New System.Drawing.Size(324, 20)
        Me.txtFTPContrasenha.TabIndex = 3
        '
        'txtFTPRuta
        '
        Me.txtFTPRuta.controlarBotonBorrar = True
        Me.txtFTPRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPRuta.limpiarAlPulsarBoton = True
        Me.txtFTPRuta.Location = New System.Drawing.Point(97, 98)
        Me.txtFTPRuta.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFTPRuta.mostrarSiempreBotonBorrar = False
        Me.txtFTPRuta.Name = "txtFTPRuta"
        Me.txtFTPRuta.seleccionarTodo = True
        Me.txtFTPRuta.Size = New System.Drawing.Size(324, 20)
        Me.txtFTPRuta.TabIndex = 4
        Me.txtFTPRuta.Text = "/"
        '
        'txtURI
        '
        Me.txtURI.controlarBotonBorrar = True
        Me.txtURI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtURI.limpiarAlPulsarBoton = True
        Me.txtURI.Location = New System.Drawing.Point(97, 122)
        Me.txtURI.Margin = New System.Windows.Forms.Padding(2)
        Me.txtURI.mostrarSiempreBotonBorrar = False
        Me.txtURI.Name = "txtURI"
        Me.txtURI.seleccionarTodo = True
        Me.txtURI.Size = New System.Drawing.Size(324, 20)
        Me.txtURI.TabIndex = 5
        '
        'lblFTPPuerto
        '
        Me.lblFTPPuerto.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFTPPuerto.Location = New System.Drawing.Point(28, 26)
        Me.lblFTPPuerto.Margin = New System.Windows.Forms.Padding(2)
        Me.lblFTPPuerto.Name = "lblFTPPuerto"
        Me.lblFTPPuerto.Size = New System.Drawing.Size(45, 20)
        Me.lblFTPPuerto.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTPPuerto.TabIndex = 4
        Me.lblFTPPuerto.Values.Text = "Puerto"
        '
        'txtFTPPuerto
        '
        Me.txtFTPPuerto.controlarBotonBorrar = True
        Me.txtFTPPuerto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPPuerto.limpiarAlPulsarBoton = True
        Me.txtFTPPuerto.Location = New System.Drawing.Point(97, 26)
        Me.txtFTPPuerto.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFTPPuerto.mostrarSiempreBotonBorrar = False
        Me.txtFTPPuerto.Name = "txtFTPPuerto"
        Me.txtFTPPuerto.seleccionarTodo = True
        Me.txtFTPPuerto.Size = New System.Drawing.Size(324, 20)
        Me.txtFTPPuerto.TabIndex = 1
        Me.txtFTPPuerto.Text = "21"
        '
        'gestorErrores
        '
        Me.gestorErrores.Alineacion = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
        Me.gestorErrores.ContainerControl = Me
        '
        'frmConfigurarFTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(447, 208)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.tblDatosFTP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfigurarFTP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurar FTP y URL"
        Me.tblDatosFTP.ResumeLayout(False)
        Me.tblDatosFTP.PerformLayout()
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tblDatosFTP As System.Windows.Forms.TableLayoutPanel
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
    Friend WithEvents btnCancelar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnAceptar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents gestorErrores As Recompila.Controles.rGestorErrores
    Friend WithEvents lblFTPPuerto As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtFTPPuerto As Recompila.Controles.rTextBox
End Class
