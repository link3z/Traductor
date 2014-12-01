Imports Recompila.Traductor

Public Class frmConfigurarFTP

    Private iConfiguracionFTP As cConfiguracionFTP

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub Mostrar(ByRef eConfiguracionFTP As cConfiguracionFTP)
        iConfiguracionFTP = eConfiguracionFTP
        Me.ShowDialog()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        iConfiguracionFTP.Servidor = txtFTPServidor.Text
        iConfiguracionFTP.Usuario = txtFTPUsuario.Text
        iConfiguracionFTP.Clave = txtFTPContrasenha.Text
        iConfiguracionFTP.Ruta = txtFTPRuta.Text
        iConfiguracionFTP.URLBase = txtURI.Text

        Me.Close()
    End Sub

    Private Sub frmConfigurarFTP_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFTPServidor.Text = iConfiguracionFTP.Servidor
        txtFTPUsuario.Text = iConfiguracionFTP.Usuario
        txtFTPContrasenha.Text = iConfiguracionFTP.Clave
        txtFTPRuta.Text = iConfiguracionFTP.Ruta
        txtURI.Text = iConfiguracionFTP.URLBase
    End Sub

End Class
