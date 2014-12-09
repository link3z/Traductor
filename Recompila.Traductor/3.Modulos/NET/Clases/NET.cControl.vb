Namespace NET
    ''' <summary>
    ''' Control/Objeto .NET que se puede traducir y su configuración para localizarlo en los archivos de
    ''' código fuente del proyecto
    ''' </summary>
    <Serializable>
    Public Class cControl
#Region " PROPIEDADES "
        ''' <summary>
        ''' Tipo del objeto o control
        ''' </summary>
        Public Property Tipo As String = ""

        ''' <summary>
        ''' Determina si este tipo de control es el propio formulario 
        ''' </summary>
        Public Property esFormulario As Boolean = False

        ''' <summary>
        ''' Determina si el objeto o control no tiene la propiedad Name, por lo que hay que
        ''' buscar otra propiedad (UniqueName) para poder identificarlo de forma única
        ''' </summary>
        Public Property conUniqueName As Boolean = False

        ''' <summary>
        ''' Ruta completa con los espacios de nombres y la propiedad que se utilizará para
        ''' extraer el UniqueName si se trata de un objeto/control sin propiedad .Name
        ''' </summary>
        Public Property rutaUniqueName As String = ""

        ''' <summary>
        ''' Sufijo a añadir al UniqueName una vez extraido
        ''' </summary>
        Public Property sufijoUniqueName As String = ""

        ''' <summary>
        ''' Todas las propiedades que se van a traducir del objeto/control
        ''' </summary>
        Public Property Propiedades As New List(Of NET.cPropiedad)
#End Region

#Region " CONSTRUCTORES "
        Public Sub New()

        End Sub
#End Region

#Region " SOBRECARGAS "
        Public Overrides Function ToString() As String
            Return Me.Tipo
        End Function
#End Region
    End Class
End Namespace
