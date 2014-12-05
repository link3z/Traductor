Imports System.IO
Imports System.Xml.Serialization
Imports Recompila.Helper

''' <summary>
''' Configuración de acceso FTP/HTTP
''' </summary>
<Serializable>
Public Class cConfiguracionNetwork
#Region " PROPIEDADES "
    ''' <summary>
    ''' Servidor FTP al que se van a subir los documentos HTML para realizar la traducción d
    ''' </summary>
    Public Property Servidor As String = ""

    ''' <summary>
    ''' Puerto que se va a utilizar para la subida de los documentos al servidor
    ''' </summary>
    Public Property Puerto As Integer = 21

    ''' <summary>
    ''' Usuario de acceso al FTP
    ''' </summary>
    Public Property Usuario As String = ""

    ''' <summary>
    ''' Clave de acceso al FTP
    ''' </summary>
    Public Property Clave As String = ""

    ''' <summary>
    ''' Ruta en el servidor donde se deben dejar los documentos HTML para la traducción.
    ''' Esta ruta tiene que tener permisos de escritura por el usuario que accede al servidor
    ''' y a la vez tiene que ser accesible mediante HTTP para que el traductor puede realizar
    ''' la traducción OnLine
    ''' </summary>
    Public Property Ruta As String = "/"

    ''' <summary>
    ''' URL base que se utilizará para pasar a los traducotores OnLine para realizar la traducción
    ''' de los documentos HTML. Esta ruta tiene que coincidir con la Ruta FTP a la que se suben
    ''' estos documentos
    ''' </summary>
    Public Property URLBase As String = ""
#End Region

#Region " METODOS "
    ''' <summary>
    ''' Carga la configuración de un documento XML de configuración de acceso
    ''' </summary>
    ''' <param name="eRuta">Ruta al archivo XML de configuración</param>
    ''' <returns>True o False dependiendo de si se pudo realizar la carga</returns>
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

    ''' <summary>
    ''' Guarda la configuración del objeto instanciado en un documento XML de configuración
    ''' en la ruta especificada como parámetro
    ''' </summary>
    ''' <param name="eRuta">Ruta donde se quiere guardar la configuración</param>
    ''' <returns>True o False dependiendo de si se pudo realizar la operación</returns>
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
