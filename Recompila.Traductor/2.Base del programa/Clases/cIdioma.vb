Imports System.Drawing

''' <summary>
''' Objeto que representa un idioma
''' </summary>
''' <remarks></remarks>
Public Class cIdioma

#Region " DECLARACIONES "
    ''' <summary>
    ''' Código interno de la clase que coincide con el enumerado de todos los idomas
    ''' para obtener todas sus propiedades
    ''' </summary>
    Private iCodigoInterno As Integer = 0
#End Region

#Region " PROPIEDADES "
    ''' <summary>
    ''' Código del idioma para identificarlo. 
    ''' Se utiliza la localización del idioma
    ''' </summary>
    Public ReadOnly Property codigoLocalizacion As idiomaLocalizacion
        Get
            Return iCodigoInterno
        End Get
    End Property

    ''' <summary>
    ''' String con el código de localización del idioma
    ''' </summary>
    Public ReadOnly Property strCodigoLocalizacion As String
        Get
            Return Me.codigoLocalizacion.ToString.Replace("_", "-")
        End Get
    End Property

    ''' <summary>
    ''' Nombre del idioma
    ''' </summary>
    Public ReadOnly Property Nombre As idiomaNombre
        Get
            Return iCodigoInterno
        End Get
    End Property

    ''' <summary>
    ''' String con el nombre del idioma
    ''' </summary>
    Public ReadOnly Property strNombre As String
        Get
            Return Me.Nombre.ToString
        End Get
    End Property

    ''' <summary>
    ''' Código del idioma en ISO 639-1
    ''' </summary>
    Public ReadOnly Property ISO639_1 As idiomaISO639_1
        Get
            Return iCodigoInterno
        End Get
    End Property

    ''' <summary>
    ''' String con el código del idioma en formato ISO639-1
    ''' </summary>
    Public ReadOnly Property strISO639_1 As String
        Get
            Return Me.ISO639_1.ToString
        End Get
    End Property

    ''' <summary>
    ''' Código del idioma en ISO 639-3
    ''' </summary>
    Public ReadOnly Property ISO639_3 As idiomaISO639_3
        Get
            Return iCodigoInterno
        End Get
    End Property

    ''' <summary>
    ''' String con el código del idioma en formato ISO639-3
    ''' </summary>
    Public ReadOnly Property strISO639_3 As String
        Get
            Return Me.ISO639_3.ToString
        End Get
    End Property

    ''' <summary>
    ''' Bandera asociada al idioma
    ''' </summary>
    Public Property Bandera As Image = Nothing
#End Region

#Region " CONSTRUCTORES "
    ''' <summary>
    ''' Constructor que genera un objeto idioma a partir del código
    ''' que se le pasa como parámetro
    ''' </summary>
    Public Sub New(ByVal eCodigoInterno As idiomaLocalizacion)
        iCodigoInterno = CInt(eCodigoInterno)
    End Sub
#End Region

#Region " METODOS SOBREESCRITOS "
    ''' <summary>
    ''' Sobreescritura del ToString para devolver el nombre del idioma
    ''' </summary>
    Public Overrides Function ToString() As String
        Return Me.strNombre
    End Function
#End Region
End Class
