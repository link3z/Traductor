Imports Recompila.Traductor
Imports ComponentFactory.Krypton.Toolkit

Public Class frmConfigurarFTP

#Region " PROPIEDADES "
    ''' <summary>
    ''' Objeto con la configuración del FTP
    ''' </summary>
    Public Property ConfiguracionFTP As cConfiguracionFTP
        Get
            If iConfiguracionFTP Is Nothing Then
                iConfiguracionFTP = New cConfiguracionFTP
            End If
            Return iConfiguracionFTP
        End Get
        Set(value As cConfiguracionFTP)
            iConfiguracionFTP = value
        End Set
    End Property
    Private iConfiguracionFTP As cConfiguracionFTP = Nothing
#End Region

#Region " CONSTRUCTORES "
    ''' <summary>
    ''' Muestra la ventana de configuración y permite realizar cambios en esta
    ''' </summary>
    ''' <param name="eConfiguracionFTP">Objeto con la configuración que se va a modificar</param>
    Public Sub Mostrar(ByRef eConfiguracionFTP As cConfiguracionFTP)
        iConfiguracionFTP = eConfiguracionFTP
        Me.ShowDialog()
    End Sub

    Private Sub frmConfigurarFTP_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFTPServidor.Text = iConfiguracionFTP.Servidor
        txtFTPUsuario.Text = iConfiguracionFTP.Usuario
        txtFTPContrasenha.Text = iConfiguracionFTP.Clave
        txtFTPRuta.Text = iConfiguracionFTP.Ruta
        txtURI.Text = iConfiguracionFTP.URLBase
    End Sub
#End Region

#Region " CONTROL DE BOTONES "
    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        ' Se verifica que no existan errores, en caso contrario no se puede continuar
        Me.ValidateChildren()
        If gestorErrores.HasErrors Then Exit Sub

        iConfiguracionFTP.Servidor = txtFTPServidor.Text
        iConfiguracionFTP.Usuario = txtFTPUsuario.Text
        iConfiguracionFTP.Clave = txtFTPContrasenha.Text
        iConfiguracionFTP.Ruta = txtFTPRuta.Text
        iConfiguracionFTP.URLBase = txtURI.Text

        Me.Close()
    End Sub
#End Region

#Region " VALIDADORES "
    Private Sub validarTextoObligatorio(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFTPServidor.Validating, txtFTPUsuario.Validating, txtFTPContrasenha.Validating, txtURI.Validating, txtFTPPuerto.Validating
        If String.IsNullOrEmpty(CType(sender, KryptonTextBox).Text) Then
            gestorErrores.SetError(sender, "Este campo es obligatorio y no puede quedar en blanco.")
        Else
            gestorErrores.SetError(sender, "")
        End If
    End Sub
    Private Sub validarSoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtFTPPuerto.KeyPress
        Recompila.Helper.Validadores.SoloNumeros(sender, e, False)
    End Sub
#End Region
End Class
