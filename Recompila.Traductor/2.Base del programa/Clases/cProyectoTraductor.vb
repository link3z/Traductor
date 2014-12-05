<Serializable>
Public Class cProyectoTraductor
#Region " PROPIEDADES "
    Public Property Nombre As String = "Nuevo proyecto"
    Public Property Descripcion As String = "Descripción del nuevo proyecto de traducción"

    Public Property TraductorNombre As String = "recompila.com"
    Public Property TraductorEquipo As String = "recompila.com"
    Public Property TraductorEmail As String = "traductor@recompila.com"

    Public Property IdiomaOrigen As idiomaLocalizacion = idiomaLocalizacion.es_ES
    Public Property Motor As motorTraduccion = MotorTraduccion.GoogleTranslate
    Public Property IdiomasDestino As New List(Of idiomaLocalizacion)
#End Region
End Class
