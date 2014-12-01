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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancelar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnAceptar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.krgConfiguracionFTP = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.tblDatosFTP = New System.Windows.Forms.TableLayoutPanel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtFTPServidor = New Recompila.Controles.rTextBox()
        Me.txtFTPUsuario = New Recompila.Controles.rTextBox()
        Me.txtFTPContrasenha = New Recompila.Controles.rTextBox()
        Me.txtFTPRuta = New Recompila.Controles.rTextBox()
        Me.txtURI = New Recompila.Controles.rTextBox()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.krgConfiguracionFTP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.krgConfiguracionFTP.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.krgConfiguracionFTP.Panel.SuspendLayout()
        Me.krgConfiguracionFTP.SuspendLayout()
        Me.tblDatosFTP.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnCancelar)
        Me.KryptonPanel.Controls.Add(Me.btnAceptar)
        Me.KryptonPanel.Controls.Add(Me.krgConfiguracionFTP)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(447, 217)
        Me.KryptonPanel.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(249, 180)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 25)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Values.Text = "&Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(345, 180)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 25)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Values.Text = "&Aceptar"
        '
        'krgConfiguracionFTP
        '
        Me.krgConfiguracionFTP.Location = New System.Drawing.Point(12, 12)
        Me.krgConfiguracionFTP.Name = "krgConfiguracionFTP"
        '
        'krgConfiguracionFTP.Panel
        '
        Me.krgConfiguracionFTP.Panel.Controls.Add(Me.tblDatosFTP)
        Me.krgConfiguracionFTP.Size = New System.Drawing.Size(423, 165)
        Me.krgConfiguracionFTP.StateCommon.Back.Color1 = System.Drawing.Color.Transparent
        Me.krgConfiguracionFTP.TabIndex = 2
        Me.krgConfiguracionFTP.Text = "Configuración FTP y URI"
        Me.krgConfiguracionFTP.Values.Heading = "Configuración FTP y URI"
        '
        'tblDatosFTP
        '
        Me.tblDatosFTP.BackColor = System.Drawing.Color.Transparent
        Me.tblDatosFTP.ColumnCount = 3
        Me.tblDatosFTP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblDatosFTP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblDatosFTP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDatosFTP.Controls.Add(Me.KryptonLabel5, 0, 0)
        Me.tblDatosFTP.Controls.Add(Me.KryptonLabel7, 0, 1)
        Me.tblDatosFTP.Controls.Add(Me.KryptonLabel8, 0, 2)
        Me.tblDatosFTP.Controls.Add(Me.KryptonLabel9, 0, 3)
        Me.tblDatosFTP.Controls.Add(Me.KryptonLabel12, 0, 4)
        Me.tblDatosFTP.Controls.Add(Me.txtFTPServidor, 2, 0)
        Me.tblDatosFTP.Controls.Add(Me.txtFTPUsuario, 2, 1)
        Me.tblDatosFTP.Controls.Add(Me.txtFTPContrasenha, 2, 2)
        Me.tblDatosFTP.Controls.Add(Me.txtFTPRuta, 2, 3)
        Me.tblDatosFTP.Controls.Add(Me.txtURI, 2, 4)
        Me.tblDatosFTP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDatosFTP.Location = New System.Drawing.Point(0, 0)
        Me.tblDatosFTP.Name = "tblDatosFTP"
        Me.tblDatosFTP.RowCount = 5
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblDatosFTP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblDatosFTP.Size = New System.Drawing.Size(419, 141)
        Me.tblDatosFTP.TabIndex = 2
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel5.Location = New System.Drawing.Point(20, 3)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(54, 20)
        Me.KryptonLabel5.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel5.TabIndex = 4
        Me.KryptonLabel5.Values.Text = "Servidor"
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel7.Location = New System.Drawing.Point(23, 29)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(51, 20)
        Me.KryptonLabel7.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel7.TabIndex = 4
        Me.KryptonLabel7.Values.Text = "Usuario"
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel8.Location = New System.Drawing.Point(3, 55)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(71, 20)
        Me.KryptonLabel8.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel8.TabIndex = 4
        Me.KryptonLabel8.Values.Text = "Contraseña"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel9.Location = New System.Drawing.Point(39, 81)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(35, 20)
        Me.KryptonLabel9.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel9.TabIndex = 4
        Me.KryptonLabel9.Values.Text = "Ruta"
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel12.Location = New System.Drawing.Point(41, 107)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(33, 31)
        Me.KryptonLabel12.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel12.TabIndex = 4
        Me.KryptonLabel12.Values.Text = "URL"
        '
        'txtFTPServidor
        '
        Me.txtFTPServidor.controlarBotonBorrar = True
        Me.txtFTPServidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPServidor.Location = New System.Drawing.Point(100, 3)
        Me.txtFTPServidor.mostrarSiempreBotonBorrar = False
        Me.txtFTPServidor.Name = "txtFTPServidor"
        Me.txtFTPServidor.seleccionarTodo = True
        Me.txtFTPServidor.Size = New System.Drawing.Size(316, 20)
        Me.txtFTPServidor.TabIndex = 5
        '
        'txtFTPUsuario
        '
        Me.txtFTPUsuario.controlarBotonBorrar = True
        Me.txtFTPUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPUsuario.Location = New System.Drawing.Point(100, 29)
        Me.txtFTPUsuario.mostrarSiempreBotonBorrar = False
        Me.txtFTPUsuario.Name = "txtFTPUsuario"
        Me.txtFTPUsuario.seleccionarTodo = True
        Me.txtFTPUsuario.Size = New System.Drawing.Size(316, 20)
        Me.txtFTPUsuario.TabIndex = 6
        '
        'txtFTPContrasenha
        '
        Me.txtFTPContrasenha.controlarBotonBorrar = True
        Me.txtFTPContrasenha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPContrasenha.Location = New System.Drawing.Point(100, 55)
        Me.txtFTPContrasenha.mostrarSiempreBotonBorrar = False
        Me.txtFTPContrasenha.Name = "txtFTPContrasenha"
        Me.txtFTPContrasenha.seleccionarTodo = True
        Me.txtFTPContrasenha.Size = New System.Drawing.Size(316, 20)
        Me.txtFTPContrasenha.TabIndex = 7
        '
        'txtFTPRuta
        '
        Me.txtFTPRuta.controlarBotonBorrar = True
        Me.txtFTPRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFTPRuta.Location = New System.Drawing.Point(100, 81)
        Me.txtFTPRuta.mostrarSiempreBotonBorrar = False
        Me.txtFTPRuta.Name = "txtFTPRuta"
        Me.txtFTPRuta.seleccionarTodo = True
        Me.txtFTPRuta.Size = New System.Drawing.Size(316, 20)
        Me.txtFTPRuta.TabIndex = 8
        '
        'txtURI
        '
        Me.txtURI.controlarBotonBorrar = True
        Me.txtURI.Dock = System.Windows.Forms.DockStyle.Fill        
        Me.txtURI.Location = New System.Drawing.Point(100, 107)
        Me.txtURI.mostrarSiempreBotonBorrar = False
        Me.txtURI.Name = "txtURI"
        Me.txtURI.seleccionarTodo = True
        Me.txtURI.Size = New System.Drawing.Size(316, 20)
        Me.txtURI.TabIndex = 9
        '
        'frmConfigurarFTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 217)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConfigurarFTP"
        Me.Text = "Configuración FTP para traducción"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.krgConfiguracionFTP.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.krgConfiguracionFTP.Panel.ResumeLayout(False)
        CType(Me.krgConfiguracionFTP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.krgConfiguracionFTP.ResumeLayout(False)
        Me.tblDatosFTP.ResumeLayout(False)
        Me.tblDatosFTP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents krgConfiguracionFTP As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents tblDatosFTP As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtFTPServidor As Recompila.Controles.rTextBox
    Friend WithEvents txtFTPUsuario As Recompila.Controles.rTextBox
    Friend WithEvents txtFTPContrasenha As Recompila.Controles.rTextBox
    Friend WithEvents txtFTPRuta As Recompila.Controles.rTextBox
    Friend WithEvents txtURI As Recompila.Controles.rTextBox
    Friend WithEvents btnCancelar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnAceptar As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
