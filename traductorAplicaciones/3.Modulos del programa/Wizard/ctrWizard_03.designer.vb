<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrWizard_03
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
        Me.tblOrganizadorControles = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTraducirMensajes = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.chkTraducirMensajes = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.chklObjetos = New ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox()
        Me.cmbOpcionesSeleccion = New Recompila.Controles.rComboBox()
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblOrganizadorControles.SuspendLayout()
        CType(Me.cmbOpcionesSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(3, 3)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(527, 32)
        Me.lblTitulo.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblTitulo.StateCommon.ShortText.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Values.Text = "Seleccione los Controles/Objetos a traducir"
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
        Me.tblOrganizadorControles.Controls.Add(Me.lblTraducirMensajes, 0, 0)
        Me.tblOrganizadorControles.Controls.Add(Me.chkTraducirMensajes, 2, 0)
        Me.tblOrganizadorControles.Controls.Add(Me.KryptonLabel1, 0, 1)
        Me.tblOrganizadorControles.Controls.Add(Me.chklObjetos, 0, 2)
        Me.tblOrganizadorControles.Controls.Add(Me.cmbOpcionesSeleccion, 2, 1)
        Me.tblOrganizadorControles.Location = New System.Drawing.Point(3, 41)
        Me.tblOrganizadorControles.Name = "tblOrganizadorControles"
        Me.tblOrganizadorControles.RowCount = 3
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblOrganizadorControles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblOrganizadorControles.Size = New System.Drawing.Size(594, 456)
        Me.tblOrganizadorControles.TabIndex = 5
        '
        'lblTraducirMensajes
        '
        Me.lblTraducirMensajes.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTraducirMensajes.Location = New System.Drawing.Point(3, 3)
        Me.lblTraducirMensajes.Name = "lblTraducirMensajes"
        Me.lblTraducirMensajes.Size = New System.Drawing.Size(107, 20)
        Me.lblTraducirMensajes.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTraducirMensajes.TabIndex = 0
        Me.lblTraducirMensajes.Values.Text = "Traducir mensajes"
        '
        'chkTraducirMensajes
        '
        Me.chkTraducirMensajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkTraducirMensajes.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkTraducirMensajes.Location = New System.Drawing.Point(136, 3)
        Me.chkTraducirMensajes.Name = "chkTraducirMensajes"
        Me.chkTraducirMensajes.Size = New System.Drawing.Size(455, 20)
        Me.chkTraducirMensajes.TabIndex = 1
        Me.chkTraducirMensajes.Text = "Realiza los ajustes necesarios para traducir los mensajes."
        Me.chkTraducirMensajes.Values.Text = "Realiza los ajustes necesarios para traducir los mensajes."
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel1.Location = New System.Drawing.Point(3, 29)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(107, 17)
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Traducir mensajes"
        '
        'chklObjetos
        '
        Me.tblOrganizadorControles.SetColumnSpan(Me.chklObjetos, 3)
        Me.chklObjetos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chklObjetos.Location = New System.Drawing.Point(3, 52)
        Me.chklObjetos.Name = "chklObjetos"
        Me.chklObjetos.Size = New System.Drawing.Size(588, 401)
        Me.chklObjetos.TabIndex = 2
        '
        'cmbOpcionesSeleccion
        '
        Me.cmbOpcionesSeleccion.controlarBotonBorrar = False
        Me.cmbOpcionesSeleccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbOpcionesSeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOpcionesSeleccion.DropDownWidth = 462
        Me.cmbOpcionesSeleccion.limpiarAlPulsarBoton = True
        Me.cmbOpcionesSeleccion.Location = New System.Drawing.Point(134, 27)
        Me.cmbOpcionesSeleccion.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbOpcionesSeleccion.mostrarSiempreBotonBorrar = False
        Me.cmbOpcionesSeleccion.Name = "cmbOpcionesSeleccion"
        Me.cmbOpcionesSeleccion.Size = New System.Drawing.Size(459, 21)
        Me.cmbOpcionesSeleccion.TabIndex = 4
        '
        'ctrWizard_03
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.tblOrganizadorControles)
        Me.Controls.Add(Me.lblTitulo)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrWizard_03"
        Me.Size = New System.Drawing.Size(600, 500)
        CType(Me.gestorErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblOrganizadorControles.ResumeLayout(False)
        Me.tblOrganizadorControles.PerformLayout()
        CType(Me.cmbOpcionesSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents gestorErrores As Recompila.Controles.rGestorErrores
    Friend WithEvents tblOrganizadorControles As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTraducirMensajes As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkTraducirMensajes As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chklObjetos As ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox
    Friend WithEvents cmbOpcionesSeleccion As Recompila.Controles.rComboBox


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
