Public Class cMotorGoogle
    Inherits cMotorBase
    Implements IMotorTraduccion

#Region " PROPIEDADES "
    ''' <summary>
    ''' Tipo del motor de traducción
    ''' </summary>
    Public Overrides ReadOnly Property Tipo As motorTraduccion
        Get
            Return motorTraduccion.GoogleTranslate
        End Get
    End Property

    ''' <summary>
    ''' Nombre del motor de traducción
    ''' </summary>
    Public ReadOnly Property Nombre As String Implements IMotorTraduccion.Nombre
        Get
            Return "Google Translator"
        End Get
    End Property

    ''' <summary>
    ''' URI utilizada para la traducción de la página HTML
    ''' </summary>
    Public ReadOnly Property URI As String Implements IMotorTraduccion.URI
        Get
            Return iURI
        End Get
    End Property
    Private iURI As String = "http://translate.google.com/translate?hl=@entrada@&tl=@salida@&u=http%3A%2F%2F@URI@"

    ''' <summary>
    ''' Distintas combinaciones que puede realizar el traductor con un idioma de entrada
    ''' </summary>
    Public ReadOnly Property TiposTraduccion As Dictionary(Of idiomaLocalizacion, List(Of idiomaLocalizacion)) Implements IMotorTraduccion.TiposTraduccion
        Get
            If iTiposTraduccion Is Nothing Then
                iTiposTraduccion = New Dictionary(Of idiomaLocalizacion, List(Of idiomaLocalizacion))
                With iTiposTraduccion
                    .Add(idiomaLocalizacion.es_ES, New List(Of idiomaLocalizacion) From {idiomaLocalizacion.en_US, idiomaLocalizacion.gl_GL, idiomaLocalizacion.de_DE, idiomaLocalizacion.pt_PT, idiomaLocalizacion.it_IT, idiomaLocalizacion.fr_FR, idiomaLocalizacion.ca_CA, idiomaLocalizacion.eu_EU, idiomaLocalizacion.el_EL, idiomaLocalizacion.ja_JA, idiomaLocalizacion.ru_RU, idiomaLocalizacion.ro_RO, idiomaLocalizacion.cz_CZ, idiomaLocalizacion.bg_BG, idiomaLocalizacion.hr_HR, idiomaLocalizacion.da_DA, idiomaLocalizacion.nl_NL, idiomaLocalizacion.fi_FI, idiomaLocalizacion.hu_HU, idiomaLocalizacion.sv_SV, idiomaLocalizacion.tr_TR})
                End With
            End If
            Return iTiposTraduccion
        End Get
    End Property
    Private iTiposTraduccion As Dictionary(Of idiomaLocalizacion, List(Of idiomaLocalizacion)) = Nothing
#End Region

#Region " CONSTRUCTORES "
    Public Sub New()
        MyBase.SleepTime = 5000
    End Sub
#End Region

#Region " METODOS "
    ''' <summary>
    ''' Obtiene la URL que se tiene que invocar para realizar la traducción de la página
    ''' que se le pasa por parámetro de un idioma dado a otro
    ''' </summary>
    ''' <param name="eIdiomaEntrada">Idioma de entrada para la traducción</param>
    ''' <param name="eIdiomaSalida">Idioma de salida para la traducción</param>
    ''' <param name="eURL">URL donde se tiene que realizar la traducción</param>
    ''' <returns>URL formateada para poder realizar la traducción</returns>
    Public Function obtenerURL(eIdiomaEntrada As cIdioma, _
                               eIdiomaSalida As cIdioma, _
                               eURL As String) As String Implements IMotorTraduccion.obtenerURL
        Dim paraDevolver As String = Me.URI

        paraDevolver = paraDevolver.Replace("@entrada@", eIdiomaEntrada.strCodigoLocalizacion)
        paraDevolver = paraDevolver.Replace("@salida@", eIdiomaSalida.strCodigoLocalizacion)
        paraDevolver = paraDevolver.Replace("@URI@", eURL.Replace("http://", ""))

        Return paraDevolver
    End Function
#End Region


#Region " SOBRECARGAS "
    ''' <summary>
    ''' Sobrecarga del método toString para mostrar el nombre del traductor
    ''' </summary>
    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function
#End Region
End Class
