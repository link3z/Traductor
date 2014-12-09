Imports System.IO
Imports System.Xml.Serialization
Imports Recompila.Helper

<Serializable>
Public Class cProyectoTraductor
#Region " PROPIEDADES "
    Public Property Nombre As String = "Nuevo proyecto"
    Public Property Descripcion As String = "Descripción del nuevo proyecto de traducción"

    Public Property TraductorNombre As String = "recompila.com"
    Public Property TraductorEquipo As String = "recompila.com"
    Public Property TraductorEmail As String = "traductor@recompila.com"

    ''' <summary>
    ''' Idioma en el cual fué programado el proyecto VB
    ''' </summary>
    Public Property IdiomaOrigen As idiomaLocalizacion = idiomaLocalizacion.es_ES

    ''' <summary>
    ''' Motor utilizado para realizar las traducciones automáticas
    ''' </summary>
    Public Property Motor As motorTraduccion = motorTraduccion.GoogleTranslate

    ''' <summary>
    ''' Idiomas a los que se tradujo el proyecto
    ''' </summary>
    Public Property IdiomasDestino As New List(Of idiomaLocalizacion)

    ''' <summary>
    ''' Archivos NET que fueron traducidos en la última traducción
    ''' </summary>
    Public Property ArchivosNET As New List(Of NET.cFormulario)

    ''' <summary>
    ''' Objetos NET que fueron traducidos en la última traducción
    ''' </summary>
    Public Property ControlesNET As New List(Of NET.cControl)

    ''' <summary>
    ''' Determina si se tienen que traducir los mensajes del formulario
    ''' </summary>
    Public Property TraducirMensajes As Boolean = True
#End Region

#Region " METODOS "
    ''' <summary>
    ''' Carga la configuración de un documento XML
    ''' </summary>
    ''' <param name="eRuta">Ruta al archivo XML de configuración</param>
    ''' <returns>True o False dependiendo de si se pudo realizar la carga</returns>
    Public Function cargar(ByVal eRuta As String) As Boolean
        Dim paraDevolver As Boolean = True

        If IO.File.Exists(eRuta) Then
            Try
                Dim elLector As New StreamReader(eRuta)
                Dim elSerializador As New XmlSerializer(Me.GetType)
                Dim laConfiguracion As New cProyectoTraductor
                laConfiguracion = elSerializador.Deserialize(elLector)
                With Me
                    .Nombre = laConfiguracion.Nombre
                    .Descripcion = laConfiguracion.Descripcion

                    .TraductorNombre = laConfiguracion.TraductorNombre
                    .TraductorEquipo = laConfiguracion.TraductorEquipo
                    .TraductorEmail = laConfiguracion.TraductorEmail

                    .IdiomaOrigen = laConfiguracion.IdiomaOrigen
                    .Motor = laConfiguracion.Motor
                    If laConfiguracion.IdiomasDestino.Count > 0 Then
                        .IdiomasDestino.AddRange(laConfiguracion.IdiomasDestino.ToArray)
                    End If
                End With

                elLector.Close()
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al desserializar la configuración XML", ex, New StackTrace(0, True))
                paraDevolver = False
            End Try
        Else
            If Log._LOG_ACTIVO Then Log.escribirLog("ERROR, no existe el archivo de configuración XML en '" & eRuta & "'", , New StackTrace(0, True))
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
            If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al serializar la configuración XML", ex, New StackTrace(0, True))
            paraDevolver = False
        End Try

        Return paraDevolver
    End Function
#End Region
End Class
