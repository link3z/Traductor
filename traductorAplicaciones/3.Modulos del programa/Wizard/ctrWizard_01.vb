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
        ' Se limpia la configuración de la operacióin a realizar
        txtOperacionRuta.Text = ""

        ' Se limpia la configuración del proyecto
        txtTraduccionNombre.Text = ""
        txtTraduccionDescripcion.Text = ""

        ' Se recargan los datos predeterminados de conexión FTP
        cargarConexionPredeterminada()

        gestorErrores.Clear()
    End Sub

    Public Function PrepararCierre() As Boolean Implements ICBase.PrepararCierre

        Return True
    End Function

    Public Function Cargar(eObjeto As Object) As Boolean Implements IControlWizard.Cargar
        ' Se selecciona la operación seleccionada por el usuario previamente
        If Sistema.Traduccion._OPERACION = Operacion.AbrirProyecto Then
            radOperacionAbrir.Checked = True
        Else
            radOperacionNuevo.Checked = True
        End If
        radOperacionAbrir_CheckedChanged(Nothing, Nothing)

        ' Si ya existía un proyecto previamente cargado se cargan sus datos
        If Sistema.Traduccion._CONFIGURACION_TRADUCTOR IsNot Nothing Then
            With Sistema.Traduccion._CONFIGURACION_TRADUCTOR
                txtTraduccionNombre.Text = .Nombre
                txtTraduccionDescripcion.Text = .Descripcion
            End With
        End If

        Return True
    End Function

    Public Sub CargarDatosMaestros() Implements IControlWizard.CargarDatosMaestros
        ' De entrada se marca la opción de cargar un proyecto existente
        radOperacionAbrir.Checked = True        

        ' Se carga la configuración de acceso FTP/HTTP predeterminada
        cargarConexionPredeterminada()
    End Sub

    Public Sub DarFoco() Implements IControlWizard.DarFoco
        If Sistema.Traduccion._OPERACION = Operacion.NuevoProyecto Then
            txtTraduccionNombre.Focus()
        Else
            txtOperacionRuta.Focus()
        End If
    End Sub

    Public Function ExistenErrores() As Boolean Implements IControlWizard.ExistenErrores
        ' Se verifica que si se escogió abrir un proyecto, este exista
        gestorErrores.SetError(txtOperacionRuta, "")
        If radOperacionAbrir.Checked Then
            If Not IO.File.Exists(txtOperacionRuta.Text) Then
                gestorErrores.SetError(txtOperacionRuta, "Es necesario que seleccione el proyecto de traducción antes de continuar.")
                Return True
            End If
        End If

        ' Se realizan las verificaciones normales 
        Me.ValidateChildren()
        Return (gestorErrores.HasErrors)
    End Function

    Public Function Guardar(ByRef eObjeto As Object) As Object Implements IControlWizard.Guardar
        ' Lo primero es guardar la configuración de acceo al FTP para poder utilizar 
        ' la siguiente vez que se inice el proyecto
        With Sistema.Traduccion._CONFIGURACION_CONEXION
            .Servidor = txtConexionFTPServidor.Text
            .Puerto = txtConexionFTPPuerto.Text
            .Usuario = txtConexionFTPUsuario.Text
            .Clave = txtConexionFTPClave.Text
            .Ruta = txtConexionFTPRuta.Text
            .URLBase = txtConexionHTTP.Text
        End With
        Sistema.Traduccion._CONFIGURACION_CONEXION.guardar(Sistema.Configuracion._DEFAULT_NETEWORK_CONFIG)

        ' Una vez guardado, si se trata de un nuevo proyecto este se crea, en caso contario
        ' se actualizan los datos del que se cargo al seleccionar desde disco
        If radOperacionNuevo.Checked Then
            Sistema.Traduccion._OPERACION = Operacion.NuevoProyecto
            Sistema.Traduccion._RUTA_RTRAD = String.Empty
            Sistema.Traduccion._CONFIGURACION_TRADUCTOR = New Recompila.Traductor.cProyectoTraductor
        Else
            Sistema.Traduccion._OPERACION = Operacion.AbrirProyecto
            Sistema.Traduccion._RUTA_RTRAD = txtOperacionRuta.Text
        End If

        With Sistema.Traduccion._CONFIGURACION_TRADUCTOR
            .Nombre = txtTraduccionNombre.Text
            .Descripcion = txtTraduccionDescripcion.Text
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

    Private Sub radOperacionAbrir_CheckedChanged(sender As Object, e As EventArgs) Handles radOperacionAbrir.CheckedChanged
        If Cargando Then Exit Sub
        tblControles.SuspendLayout()

        ' La apertura solamente estará disponible si se selecciona la opción de abrir
        ' una traducción existente
        txtOperacionRuta.Enabled = radOperacionAbrir.Checked

        ' De entrada se van a poder modificar los datos del proyecto de traducción, a no
        ' ser que se seleccionara un proyecto y este no fuese válido, en ese caso se
        ' bloquea el header y se marca el error
        hdrTraduccion.Enabled = True
        If radOperacionAbrir.Checked Then
            Sistema.Traduccion._OPERACION = Operacion.AbrirProyecto
            LimpiarCampos()

            ' Si ya estába configurada una ruta se carga, en caso contrario
            ' se bloquen los campos de los datos del proyecto hasta que se
            ' abra un proyecto de traducción
            If Not String.IsNullOrEmpty(Sistema.Traduccion._RUTA_RTRAD) AndAlso IO.File.Exists(Sistema.Traduccion._RUTA_RTRAD) Then
                Sistema.Traduccion._CONFIGURACION_TRADUCTOR = New Recompila.Traductor.cProyectoTraductor
                Sistema.Traduccion._CONFIGURACION_TRADUCTOR.cargar(Sistema.Traduccion._RUTA_RTRAD)
                txtTraduccionNombre.Focus()
            Else
                Sistema.Traduccion._CONFIGURACION_TRADUCTOR = Nothing
                hdrTraduccion.Enabled = False
                txtOperacionRuta.Focus()
            End If
        Else
            Sistema.Traduccion._OPERACION = Operacion.NuevoProyecto
        End If

        tblControles.ResumeLayout()
    End Sub
#End Region

#Region " METODOS AUXILIARES "
    ''' <summary>
    ''' Se carga la configuración de conexión al FTP y acceso HTML predeterminadas
    ''' y se asignan a los controles del formulario. En caso de no existir el archivo
    ''' de configuración, se muestran los datos predeterminados
    ''' </summary>
    Private Sub cargarConexionPredeterminada()
        If IO.File.Exists(Sistema.Configuracion._DEFAULT_NETEWORK_CONFIG) Then
            Sistema.Traduccion._CONFIGURACION_CONEXION.cargar(Sistema.Configuracion._DEFAULT_NETEWORK_CONFIG)
            With Sistema.Traduccion._CONFIGURACION_CONEXION
                txtConexionFTPServidor.Text = .Servidor
                txtConexionFTPPuerto.Text = .Puerto
                txtConexionFTPUsuario.Text = .Usuario
                txtConexionFTPClave.Text = .Clave
                txtConexionFTPRuta.Text = .Ruta
                txtConexionHTTP.Text = .URLBase
            End With
        Else
            txtConexionFTPServidor.Text = "ftp://"
            txtConexionFTPPuerto.Text = "21"
            txtConexionFTPUsuario.Text = "anonymous"
            txtConexionFTPClave.Text = "anonymous"
            txtConexionFTPRuta.Text = "/"
            txtConexionHTTP.Text = "http://"
        End If
    End Sub
#End Region

#Region " VALIDADORES "
    Private Sub validarTextoObligatorio(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtConexionFTPServidor.Validating, txtConexionFTPUsuario.Validating, txtConexionFTPClave.Validating, txtConexionHTTP.Validating, txtConexionFTPPuerto.Validating, txtConexionFTPRuta.Validating, txtTraduccionNombre.Validating
        If String.IsNullOrEmpty(CType(sender, KryptonTextBox).Text) Then
            gestorErrores.SetError(sender, "Este campo es obligatorio y no puede quedar en blanco.")
        Else
            gestorErrores.SetError(sender, "")
        End If
    End Sub
    Private Sub validarSoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtConexionFTPPuerto.KeyPress
        Recompila.Helper.Validadores.SoloNumeros_KeyPress(sender, e, False)
    End Sub
#End Region

End Class
