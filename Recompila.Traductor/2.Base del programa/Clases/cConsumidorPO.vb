Imports Recompila.Helper
Imports System.Windows.Forms

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

    ''' <summary>
    ''' Listado con todos los idiomas disponibles para utilizar en la aplicación
    ''' </summary>
    Public ReadOnly Property IdiomasDisponibles As List(Of cIdioma)
        Get
            Dim paraDevolver As New List(Of cIdioma)

            If IO.Directory.Exists(iRutaTraducciones) Then
                For Each unArchivo As String In My.Computer.FileSystem.GetFiles(iRutaTraducciones, FileIO.SearchOption.SearchTopLevelOnly, "*.po")
                    Dim nombreArchivo As String = Ficheros.extraerNombreFicheroSinExtension(unArchivo)
                    For Each unCodigo As idiomaLocalizacion In [Enum].GetValues(GetType(idiomaLocalizacion))
                        If unCodigo.ToString.ToLower = nombreArchivo.ToLower.Replace("-", "_") Then
                            Dim elIdioma As New cIdioma(unCodigo)
                            If Not paraDevolver.Contains(elIdioma) Then paraDevolver.Add(elIdioma)
                            Exit For
                        End If
                    Next
                Next
            End If

            Return paraDevolver
        End Get
    End Property
#End Region

#Region " CONSTRUCTORES "
    Public Sub New(ByVal eIdioma As idiomaLocalizacion, _
                   Optional ByVal eRutaTraducciones As String = "")
        ' Si se especifica una ruta para las traduccioens y esta existe se trata de utilizar, en caso
        ' contrario se utiliza la ruta predeterminada
        If Not String.IsNullOrEmpty(eRutaTraducciones) AndAlso IO.Directory.Exists(eRutaTraducciones) Then
            iRutaTraducciones = eRutaTraducciones
            If Not iRutaTraducciones.EndsWith("\") Then iRutaTraducciones &= "\"
        Else
            iRutaTraducciones = Ficheros.StartUpPath & "\Languages\" & Criptografia.encriptarEnMD5(My.Application.Info.AssemblyName) & "\"
        End If

        ' Se fija el idoma de traducciones 
        Me.Idioma = eIdioma
    End Sub
#End Region



End Class
