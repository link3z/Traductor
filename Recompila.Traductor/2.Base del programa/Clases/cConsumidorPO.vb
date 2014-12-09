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

    ''' <summary>
    ''' Contiene una relación de todas las traducciones clasificadas por el nombre del formulario
    ''' en el que se tiene que utilizar.
    ''' </summary>
    Private iTraducciones As New Dictionary(Of String, List(Of cTraduccionIntermedia))
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

            ' Se reinicializan las variables
            iContenidoPO = ""
            iTraducciones = New Dictionary(Of String, List(Of cTraduccionIntermedia))

            ' Se carga todo el contenido del fichero PO en memoria
            Dim rutaPO As String = iRutaTraducciones
            If Not rutaPO.EndsWith("\") Then rutaPO &= "\"
            rutaPO &= iIdioma.ToString.Replace("_", "-") & ".po"
            If IO.File.Exists(rutaPO) Then iContenidoPO = My.Computer.FileSystem.ReadAllText(rutaPO)

            ' Se cargan las traducciones
            If Not String.IsNullOrEmpty(iContenidoPO) Then
                Dim lasLineas() As String = iContenidoPO.Split(vbCrLf)

                ' Se van verificando todas las lineas del formulario y se van identificando
                ' los textos originales y los textos traducidos, para ello, la linea debe
                ' empezar por #: y las dos lineas siguientes por msgid y msgstr respectivamente

                For i As Integer = 18 To lasLineas.Count - 1
                    Try
                        Dim lineaA As String = lasLineas(i).Trim
                        Dim lineaB As String = lasLineas(i + 1).Trim
                        Dim lineaC As String = lasLineas(i + 2).Trim

                        If lineaA.StartsWith("#: ") AndAlso lineaB.Trim.StartsWith("msgid") AndAlso lineaC.Trim.StartsWith("msgstr") Then


                            ' Se obtiene el nombre del formulario
                            Dim nombreFormulario As String = lineaA.Substring(2).Split(".")(0).Trim
                            Dim nombreControl As String = lineaA.Substring(2).Split(".")(1).Trim
                            Dim mensajeOriginal As String = lineaB.Trim.Substring(7, lineaB.Length - 8).Trim
                            Dim mensajeTraducido As String = lineaC.Trim.Substring(8, lineaC.Length - 9).Trim

                            If Not iTraducciones.Keys.Contains(nombreFormulario) Then
                                iTraducciones.Add(nombreFormulario, New List(Of Recompila.Traductor.cTraduccionIntermedia))
                            End If

                            Dim unaTraduccion As Recompila.Traductor.cTraduccionIntermedia = New cTraduccionIntermedia
                            With unaTraduccion
                                .Indice = i
                                .NombreControl = nombreControl
                                .Original = mensajeOriginal
                                .Traduccion = mensajeTraducido
                            End With

                            If Not iTraducciones(nombreFormulario).Contains(unaTraduccion) Then iTraducciones(nombreFormulario).Add(unaTraduccion)

                            i += 3
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
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

#Region " METODOS "
    Public Function traducir(ByRef eObjeto As Object) As Boolean
        Dim paraDevolver As Boolean = True

        ' Controla si se debe realizar la traducción del formulario
        Dim SeTraduce As Boolean = True
        If TypeOf (eObjeto) Is Form Or TypeOf (eObjeto) Is ComponentFactory.Krypton.Toolkit.KryptonForm Then
            If Objetos.tienePropiedad(eObjeto, "translateThis") Then
                SeTraduce = Objetos.obtenerValorPropiedad(eObjeto, "translateThis")
            End If
        End If
        If Not SeTraduce Then Return True









        Return paraDevolver
    End Function
#End Region



End Class
