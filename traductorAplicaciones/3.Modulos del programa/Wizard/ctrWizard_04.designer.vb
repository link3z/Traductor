<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrWizard_04
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
        Me.tblOrganizadorControles = New System.Windows.Forms.TableLayoutPanel()
        Me.lblIdiomaOriginal = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cmbIdiomaOriginal = New Recompila.Controles.rComboIcon()
        Me.lblMotorTraduccion = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cmbMotorTraduccion = New Recompila.Controles.rComboBox()
        Me.lblTraductorNombre = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblTraductorEquipo = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblTraductorEmail = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtTraduccionEquipo = New Recompila.Controles.rTextBox()
        Me.txtTraduccionTraductor = New Recompila.Controles.rTextBox()
        Me.txtTraduccionEmail = New Recompila.Controles.rTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.chklIdiomasDestino = New ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox()
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblOrganizadorControles.SuspendLayout()
        CType(Me.cmbIdiomaOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMotorTraduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(3, 3)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(457, 32)
        Me.lblTitulo.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Values.Text = "Configure las opciones de traducción"
        '
        'gestorErrores
        '
        Me.gestorErrores.Alineacion = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
        Me.gestorErrores.ContainerControl = Me
        '
        'tblOrganizadorControles
        '
        Me.tblOrganizadorControles.ColumnCount = 3
        Me.tblOrganizadorControles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblOrganizadorControles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblOrganizadorControles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblOrganizadorControles.Controls.Add(Me.lblIdiomaOriginal, 0, 0)
        Me.tblOrganizadorControles.Controls.Add(Me.cmbIdiomaOriginal, 2, 0)
        Me.tblOrganizadorControles.Controls.Add(Me.lblMotorTraduccion, 0, 1)
        Me.tblOrganizadorControles.Controls.Add(Me.cmbMotorTraduccion, 2, 1)
        Me.tblOrganizadorControles.Controls.Add(Me.lblTraductorNombre, 0, 3)
        Me.tblOrganizadorControles.Controls.Add(Me.lblTraductorEquipo, 0, 2)
        Me.tblOrganizadorControles.Controls.Add(Me.lblTraductorEmail, 0, 4)
        Me.tblOrganizadorControles.Controls.Add(Me.txtTraduccionEquipo, 2, 2)
        Me.tblOrganizadorControles.Controls.Add(Me.txtTraduccionTraductor, 2, 3)
        Me.tblOrganizadorControles.Controls.Add(Me.txtTraduccionEmail, 2, 4)
        Me.tblOrganizadorControles.Controls.Add(Me.KryptonLabel1, 0, 5)
        Me.tblOrganizadorControles.Controls.Add(Me.chklIdiomasDestino, 2, 5)
        Me.tblOrganizadorControles.Location = New System.Drawing.Point(3, 41)
        Me.tblOrganizadorControles.Name = "tblOrganizadorControles"
        Me.tblOrganizadorControles.RowCount = 7
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblOrganizadorControles.Size = New System.Drawing.Size(594, 456)
        Me.tblOrganizadorControles.TabIndex = 5
        '
        'lblIdiomaOriginal
        '
        Me.lblIdiomaOriginal.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblIdiomaOriginal.Location = New System.Drawing.Point(43, 3)
        Me.lblIdiomaOriginal.Name = "lblIdiomaOriginal"
        Me.lblIdiomaOriginal.Size = New System.Drawing.Size(87, 21)
        Me.lblIdiomaOriginal.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdiomaOriginal.TabIndex = 0
        Me.lblIdiomaOriginal.Values.Text = "Idioma original"
        '
        'cmbIdiomaOriginal
        '
        Me.cmbIdiomaOriginal.conBorde = True
        Me.cmbIdiomaOriginal.controlarBotonBorrar = False
        Me.cmbIdiomaOriginal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbIdiomaOriginal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdiomaOriginal.DropDownWidth = 435
        Me.cmbIdiomaOriginal.limpiarAlPulsarBoton = True
        Me.cmbIdiomaOriginal.Location = New System.Drawing.Point(156, 3)
        Me.cmbIdiomaOriginal.mostrarSiempreBotonBorrar = False
        Me.cmbIdiomaOriginal.Name = "cmbIdiomaOriginal"
        Me.cmbIdiomaOriginal.Size = New System.Drawing.Size(435, 21)
        Me.cmbIdiomaOriginal.StateCommon.ComboBox.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[True]
        Me.cmbIdiomaOriginal.StateCommon.ComboBox.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.cmbIdiomaOriginal.TabIndex = 0
        '
        'lblMotorTraduccion
        '
        Me.lblMotorTraduccion.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblMotorTraduccion.Location = New System.Drawing.Point(16, 30)
        Me.lblMotorTraduccion.Name = "lblMotorTraduccion"
        Me.lblMotorTraduccion.Size = New System.Drawing.Size(114, 21)
        Me.lblMotorTraduccion.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotorTraduccion.TabIndex = 2
        Me.lblMotorTraduccion.Values.Text = "Motor de traducción"
        '
        'cmbMotorTraduccion
        '
        Me.cmbMotorTraduccion.controlarBotonBorrar = False
        Me.cmbMotorTraduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbMotorTraduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotorTraduccion.DropDownWidth = 435
        Me.cmbMotorTraduccion.limpiarAlPulsarBoton = True
        Me.cmbMotorTraduccion.Location = New System.Drawing.Point(156, 30)
        Me.cmbMotorTraduccion.mostrarSiempreBotonBorrar = False
        Me.cmbMotorTraduccion.Name = "cmbMotorTraduccion"
        Me.cmbMotorTraduccion.Size = New System.Drawing.Size(435, 21)
        Me.cmbMotorTraduccion.TabIndex = 1
        '
        'lblTraductorNombre
        '
        Me.lblTraductorNombre.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTraductorNombre.Location = New System.Drawing.Point(67, 83)
        Me.lblTraductorNombre.Name = "lblTraductorNombre"
        Me.lblTraductorNombre.Size = New System.Drawing.Size(63, 20)
        Me.lblTraductorNombre.TabIndex = 2
        Me.lblTraductorNombre.Values.Text = "Traductor"
        '
        'lblTraductorEquipo
        '
        Me.lblTraductorEquipo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTraductorEquipo.Location = New System.Drawing.Point(3, 57)
        Me.lblTraductorEquipo.Name = "lblTraductorEquipo"
        Me.lblTraductorEquipo.Size = New System.Drawing.Size(127, 20)
        Me.lblTraductorEquipo.TabIndex = 2
        Me.lblTraductorEquipo.Values.Text = "Equipo de traducción"
        '
        'lblTraductorEmail
        '
        Me.lblTraductorEmail.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTraductorEmail.Location = New System.Drawing.Point(36, 109)
        Me.lblTraductorEmail.Name = "lblTraductorEmail"
        Me.lblTraductorEmail.Size = New System.Drawing.Size(94, 20)
        Me.lblTraductorEmail.TabIndex = 2
        Me.lblTraductorEmail.Values.Text = "Email traductor"
        '
        'txtTraduccionEquipo
        '
        Me.txtTraduccionEquipo.controlarBotonBorrar = True
        Me.txtTraduccionEquipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTraduccionEquipo.limpiarAlPulsarBoton = True
        Me.txtTraduccionEquipo.Location = New System.Drawing.Point(156, 57)
        Me.txtTraduccionEquipo.mostrarSiempreBotonBorrar = False
        Me.txtTraduccionEquipo.Name = "txtTraduccionEquipo"
        Me.txtTraduccionEquipo.seleccionarTodo = True
        Me.txtTraduccionEquipo.Size = New System.Drawing.Size(435, 20)
        Me.txtTraduccionEquipo.TabIndex = 2
        '
        'txtTraduccionTraductor
        '
        Me.txtTraduccionTraductor.controlarBotonBorrar = True
        Me.txtTraduccionTraductor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTraduccionTraductor.limpiarAlPulsarBoton = True
        Me.txtTraduccionTraductor.Location = New System.Drawing.Point(156, 83)
        Me.txtTraduccionTraductor.mostrarSiempreBotonBorrar = False
        Me.txtTraduccionTraductor.Name = "txtTraduccionTraductor"
        Me.txtTraduccionTraductor.seleccionarTodo = True
        Me.txtTraduccionTraductor.Size = New System.Drawing.Size(435, 20)
        Me.txtTraduccionTraductor.TabIndex = 3
        '
        'txtTraduccionEmail
        '
        Me.txtTraduccionEmail.controlarBotonBorrar = True
        Me.txtTraduccionEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTraduccionEmail.limpiarAlPulsarBoton = True
        Me.txtTraduccionEmail.Location = New System.Drawing.Point(156, 109)
        Me.txtTraduccionEmail.mostrarSiempreBotonBorrar = False
        Me.txtTraduccionEmail.Name = "txtTraduccionEmail"
        Me.txtTraduccionEmail.seleccionarTodo = True
        Me.txtTraduccionEmail.Size = New System.Drawing.Size(435, 20)
        Me.txtTraduccionEmail.TabIndex = 4
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel1.Location = New System.Drawing.Point(37, 135)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(93, 16)
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.TabIndex = 2
        Me.KryptonLabel1.Values.Text = "Idiomas destino"
        '
        'chklIdiomasDestino
        '
        Me.chklIdiomasDestino.CheckOnClick = True
        Me.chklIdiomasDestino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chklIdiomasDestino.Location = New System.Drawing.Point(156, 135)
        Me.chklIdiomasDestino.Name = "chklIdiomasDestino"
        Me.tblOrganizadorControles.SetRowSpan(Me.chklIdiomasDestino, 2)
        Me.chklIdiomasDestino.Size = New System.Drawing.Size(435, 318)
        Me.chklIdiomasDestino.TabIndex = 5
        '
        'ctrWizard_04
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.tblOrganizadorControles)
        Me.Controls.Add(Me.lblTitulo)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrWizard_04"
        Me.Size = New System.Drawing.Size(600, 500)
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblOrganizadorControles.ResumeLayout(False)
        Me.tblOrganizadorControles.PerformLayout()
        CType(Me.cmbIdiomaOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMotorTraduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents gestorErrores As Recompila.Controles.rGestorErrores
    Friend WithEvents tblOrganizadorControles As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblIdiomaOriginal As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cmbIdiomaOriginal As Recompila.Controles.rComboIcon
    Friend WithEvents lblMotorTraduccion As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cmbMotorTraduccion As Recompila.Controles.rComboBox
    Friend WithEvents lblTraductorNombre As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblTraductorEquipo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblTraductorEmail As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtTraduccionEquipo As Recompila.Controles.rTextBox
    Friend WithEvents txtTraduccionTraductor As Recompila.Controles.rTextBox
    Friend WithEvents txtTraduccionEmail As Recompila.Controles.rTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chklIdiomasDestino As ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox

End Class
