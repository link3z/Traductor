Imports ComponentFactory.Krypton.Toolkit
Imports System.IO
Imports System.Xml.Serialization

Public Class ctrWizard_01
    Implements IControlWizard

#Region " PROPIEDADES "
    ''' <summary>
    ''' Controla si el componente todavía se está cargando
    ''' </summary>
    Public Property Cargando As Boolean Implements ICBase.Cargando
        Get
            Return iCargando
        End Get
        Set(value As Boolean)
            iCargando = value
        End Set
    End Property
    Private iCargando As Boolean = True
#End Region

#Region " IMPLEMENTACION "
    Public Sub ActivarCampos(eEstado As Boolean) Implements ICBase.ActivarCampos

    End Sub

    Public Sub LimpiarCampos() Implements ICBase.LimpiarCampos
        txtNombre.Text = ""
        txtDescripcion.Text = ""
        txtRutaProyecto.Text = ""
        gestorErrores.Clear()
    End Sub

    Public Sub PrepararCierre() Implements ICBase.PrepararCierre

    End Sub

    Public Function Cargar(eObjeto As Object) As Boolean Implements IControlWizard.Cargar
        ' Si ya existía un proyecto previamente cargado se obtienen los datos y se muestran en el formulario
        If Sistema.Configuracion.proyectoTraductor IsNot Nothing Then
            With Sistema.Configuracion.proyectoTraductor
                txtNombre.Text = .Nombre
                txtDescripcion.Text = .Descripcion
            End With
        End If

        Return True
    End Function

    Public Sub CargarDatosMaestros() Implements IControlWizard.CargarDatosMaestros        
        ' De entrada se marca la opción de cargar un proyecto existente
        radAbrirProyectoExistente.Checked = True
        radAbrirProyectoExistente_CheckedChanged(Nothing, Nothing)

        ' Se carga la configuración de acceso al FTP y HTML y se
        ' asigna a los controles del formulario
        Sistema.Configuracion.configuracionNetwork.cargar(Sistema.Configuracion.rutaConfiguracionNetwork)
        With Sistema.Configuracion.configuracionNetwork
            txtFTPServidor.Text = .Servidor
            txtFTPPuerto.Text = .Puerto
            txtFTPUsuario.Text = .Usuario
            txtFTPContrasenha.Text = .Clave
            txtFTPRuta.Text = .Ruta
            txtURI.Text = .URLBase
        End With
    End Sub

    Public Sub DarFoco() Implements IControlWizard.DarFoco
        radAbrirProyectoExistente.Focus()
    End Sub

    Public Function ExistenErrores() As Boolean Implements IControlWizard.ExistenErrores
        Me.ValidateChildren()
        Return (gestorErrores.HasErrors)
    End Function

    Public Function Guardar(eObjeto As Object) As Object Implements IControlWizard.Guardar
        ' Lo primero es guardar la configuración de acceo al FTP para poder utilizar 
        ' la siguiente vez que se inice el proyecto
        With Sistema.Configuracion.configuracionNetwork
            .Servidor = txtFTPServidor.Text
            .Puerto = txtFTPPuerto.Text
            .Usuario = txtFTPUsuario.Text
            .Clave = txtFTPContrasenha.Text
            .Ruta = txtFTPRuta.Text
            .URLBase = txtURI.Text
        End With
        Sistema.Configuracion.configuracionNetwork.guardar(Sistema.Configuracion.rutaConfiguracionNetwork)

        ' Una vez guardado, si se trata de un nuevo proyecto este se crea, en caso contario
        ' se actualizan los datos del que se cargo al seleccionar desde disco
        If radNuevoProyecto.Checked Then
            Sistema.Configuracion.proyectoTraductor = New Recompila.Traductor.cProyectoTraductor
        End If

        With Sistema.Configuracion.proyectoTraductor
            .Nombre = txtNombre.Text
            .Descripcion = txtDescripcion.Text
        End With

        Return True
    End Function
#End Region

#Region " CONTROL "
    Private Sub ctrWizard_1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        iCargando = False
        frmWizard.btnSiguiente.Enabled = True
    End Sub

    Private Sub radAbrirProyectoExistente_CheckedChanged(sender As Object, e As EventArgs) Handles radAbrirProyectoExistente.CheckedChanged
        Me.SuspendLayout()

        txtRutaProyecto.Visible = radAbrirProyectoExistente.Checked

        If radAbrirProyectoExistente.Checked Then
            LimpiarCampos()
            If Not String.IsNullOrEmpty(txtRutaProyecto.Text) AndAlso IO.File.Exists(txtRutaProyecto.Text) Then

                tblConfiguracion.Visible = True
            Else
                tblConfiguracion.Visible = False
            End If
        Else
            tblConfiguracion.Visible = True
        End If

        Me.ResumeLayout()
    End Sub
#End Region

#Region " VALIDADORES "
    Private Sub validarTextoObligatorio(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFTPServidor.Validating, txtFTPUsuario.Validating, txtFTPContrasenha.Validating, txtURI.Validating, txtFTPPuerto.Validating, txtFTPRuta.Validating, txtNombre.Validating
        If String.IsNullOrEmpty(CType(sender, KryptonTextBox).Text) Then
            gestorErrores.SetError(sender, "Este campo es obligatorio y no puede quedar en blanco.")
        Else
            gestorErrores.SetError(sender, "")
        End If
    End Sub
    Private Sub validarSoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtFTPPuerto.KeyPress
        Recompila.Helper.Validadores.SoloNumeros_KeyPress(sender, e, False)
    End Sub
#End Region
End Class
