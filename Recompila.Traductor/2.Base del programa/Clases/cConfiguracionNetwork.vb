Imports System.IO
Imports System.Xml.Serialization
Imports Recompila.Helper

<Serializable>
Public Class cConfiguracionNetwork
#Region " PROPIEDADES "
    Public Property Servidor As String = ""
    Public Property Puerto As Integer = 21
    Public Property Usuario As String = ""
    Public Property Clave As String = ""
    Public Property Ruta As String = "/"
    Public Property URLBase As String = ""
#End Region

#Region " METODOS "
    Public Function cargar(ByVal eRuta As String) As Boolean
        Dim paraDevolver As Boolean = True

        If IO.File.Exists(eRuta) Then
            Try
                Dim elLector As New StreamReader(eRuta)
                Dim elSerializador As New XmlSerializer(Me.GetType)
                Dim laConfiguracion As New cConfiguracionNetwork
                laConfiguracion = elSerializador.Deserialize(elLector)
                With Me
                    .Servidor = laConfiguracion.Servidor
                    .Puerto = laConfiguracion.Puerto
                    .Usuario = laConfiguracion.Usuario
                    .Clave = laConfiguracion.Clave
                    .Ruta = laConfiguracion.Ruta
                    .URLBase = laConfiguracion.URLBase
                End With

                elLector.Close()
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al desserializar la configuración FTP", ex, New StackTrace(0, True))
                paraDevolver = False
            End Try
        Else
            If Log._LOG_ACTIVO Then Log.escribirLog("ERROR, no existe el archivo de configuración FTP en '" & eRuta & "'", , New StackTrace(0, True))
            paraDevolver = False
        End If

        Return paraDevolver
    End Function

    Public Function guardar(ByVal eRuta As String) As Boolean
        Dim paraDevolver As Boolean = True

        Try
            Dim elEscritor As New StreamWriter(eRuta, False)
            Dim elSerializador As New XmlSerializer(Me.GetType)
            elSerializador.Serialize(elEscritor, Me)
            elEscritor.Close()
        Catch ex As Exception
            If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al serializar la configuración FTP", ex, New StackTrace(0, True))
            paraDevolver = False
        End Try

        Return paraDevolver
    End Function
#End Region
End Class
