Public Class cConsumidorPO

#Region " DECLARACIONES "
    ''' <summary>
    ''' Ruta de la carpeta donde se encuentran las traducciones
    ''' </summary>
    Private iRutaTraducciones As String = ""

    ''' <summary>
    ''' Contenido del fichero PO que se va a utilizar para aplicar las traducciones
    ''' </summary>
    Private iContenidoPO As String = ""
#End Region

#Region " PROPIEDADES "
    ''' <summary>
    ''' Idioma al que se tiene que traducir la aplicación
    ''' </summary>
    Public Property Idioma As idiomaLocalizacion
        Get
            Return iIdioma
        End Get
        Set(value As idiomaLocalizacion)
            iIdioma = value
            iContenidoPO = ""

            ' Se carga todo el contenido del fichero PO en memoria
            Dim rutaPO As String = iRutaTraducciones
            If Not rutaPO.EndsWith("\") Then rutaPO &= "\"
            rutaPO &= iIdioma.ToString.Replace("_", "-") & ".po"
            If IO.File.Exists(rutaPO) Then iContenidoPO = My.Computer.FileSystem.ReadAllText(rutaPO)
        End Set
    End Property
    Private iIdioma As idiomaLocalizacion = idiomaLocalizacion.es_ES
#End Region


#Region " CONSTRUCTORES "
    Public Sub New(ByVal eIdioma As idiomaLocalizacion, _
                   Optional ByVal eRutaTraducciones As String = "")
        If Not String.IsNullOrEmpty(eRutaTraducciones) AndAlso IO.Directory.Exists(eRutaTraducciones) Then
            iRutaTraducciones = eRutaTraducciones
            If Not iRutaTraducciones.EndsWith("\") Then iRutaTraducciones &= "\"
        End If

        Me.Idioma = eIdioma
    End Sub
#End Region

End Class
