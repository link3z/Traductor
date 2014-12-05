Imports System.IO
Imports Recompila.Helper

''' <summary>
''' Clase encargada de la generación de los archivos PO con las traducciones
''' </summary>
Friend Class cGeneradorPO
#Region " DECLARACIONES "
    ''' <summary>
    ''' Proyecto VB.NET que se va a traducir
    ''' </summary>
    Private iProyectoVB As cProyectoVB = Nothing
#End Region


#Region " PROPIEDADES "
    ''' <summary>
    ''' Motor de traducción que se va a utilizar para realizar las traducciones
    ''' </summary>
    Public Motor As IMotorTraduccion = Nothing

    ''' <summary>
    ''' Datos de acceso al servidor FTP/HTTP intermedio para las traducciones
    ''' </summary>            
    Public Property ConfiguracionNetwork As cConfiguracionNetwork = Nothing

    ''' <summary>
    ''' Idioma original del formulario desde el que se van a realizar las traducciones
    ''' </summary>
    Public IdiomaUso As cIdioma = Nothing

    ''' <summary>
    ''' Idiomas con los que va a atrabajar el objeto
    ''' </summary>
    Public ReadOnly Property Idiomas As List(Of cIdioma)
        Get
            Return iIdiomas
        End Get
    End Property
    Private iIdiomas As New List(Of cIdioma)

    ''' <summary>
    ''' Correo electrónico al que se tendrán que remitir las notificaciones de erroes en la traducción
    ''' </summary>
    Public Property correoErrores As String = "correo@errores"

    ''' <summary>
    ''' Nombre del traductor que se guardará en el fichero PO
    ''' </summary>
    Public Property nombreTraductor As String = "Nombre del traductor"

    ''' <summary>
    ''' Equipo encargado de la traducción del proyecto
    ''' </summary>
    Public Property equipoTraduccion As String = "Equipo traduccion"


#End Region

#Region " EVENTOS "
    ''' <summary>
    ''' Evento que se lanza cada vez que se producen cambios para informar al usuario de los cambios
    ''' que se están realizando 
    ''' </summary>
    ''' <param name="eHora">Hora en la que se envía el mensaje</param>
    ''' <param name="eMensaje">Mensaje que se envía</param>
    Public Event notificarMensaje(ByVal eHora As DateTime, _
                                  ByVal eMensaje As String)

#End Region

#Region " CONSTRUCTORES "
    Public Sub New(ByVal eProyectoVB As cProyectoVB)
        iProyectoVB = eProyectoVB
    End Sub
#End Region

#Region " METODOS CARGA/DESCARGA IDIOMAS "
    ''' <summary>
    ''' Añade un nuevo idioma al objeto
    ''' </summary>
    Public Sub anhadirIdioma(ByVal eIdioma As cIdioma)
        Dim yaExiste As Boolean = False
        yaExiste = ((From it As cIdioma In iIdiomas _
                     Where it.codigoLocalizacion = eIdioma.codigoLocalizacion _
                     Select it).Count > 0)
        If Not yaExiste Then iIdiomas.Add(eIdioma)
    End Sub

    ''' <summary>
    ''' Añade un nuevo idioma al objeto
    ''' </summary>
    Public Sub anhadirIdioma(ByVal eIdioma As idiomaLocalizacion)
        Dim nuevoIdioma As cIdioma = New cIdioma(eIdioma)
        anhadirIdioma(nuevoIdioma)
    End Sub

    ''' <summary>
    ''' Elimina un idioma del objeto
    ''' </summary>
    Public Sub quitarIdioma(ByVal eIdioma As cIdioma)
        Dim elIdioma As cIdioma = Nothing
        elIdioma = (From it As cIdioma In iIdiomas _
                    Where it.codigoLocalizacion = eIdioma.codigoLocalizacion _
                    Select it).FirstOrDefault
        If elIdioma IsNot Nothing Then iIdiomas.Remove(elIdioma)
    End Sub

    ''' <summary>
    ''' Elimina un idioma del objeto
    ''' </summary>
    Public Sub quitarIdioma(ByVal eIdioma As idiomaLocalizacion)
        Dim nuevoIdioma As cIdioma = New cIdioma(eIdioma)
        quitarIdioma(nuevoIdioma)
    End Sub

    ''' <summary>
    ''' Se cargan todos los idiomas a los que se puede traducir segun el
    ''' motor que está configurado
    ''' </summary>
    Public Sub cargarTodos()
        iIdiomas.Clear()

        If Motor IsNot Nothing AndAlso IdiomaUso IsNot Nothing Then
            If Motor.TiposTraduccion.Keys.Contains(IdiomaUso.codigoLocalizacion) Then
                For Each unCodigo As idiomaLocalizacion In Motor.TiposTraduccion(IdiomaUso.codigoLocalizacion)
                    Dim nuevoIdioma As New cIdioma(unCodigo)
                    If Not iIdiomas.Contains(nuevoIdioma) Then iIdiomas.Add(nuevoIdioma)
                Next
            End If
        End If
    End Sub
#End Region

#Region " TRADUCTOR "
    ''' <summary>
    ''' Genera los ficheros PO con las traducciones del proyecto utilizando los idiomas
    ''' configurados en el objeto
    ''' </summary>
    Private Function VBFile2POFile(ByVal eRutaFicheroEntrada As String, _
                                   ByVal eIgnorarHTMLSubida As Boolean, _
                                   ByVal eIgnorarHTMLBajada As Boolean, _
                                   ByVal eVersion As String) As Boolean

        ' Se guarda el momento de inicio para realizar cálculos de tiempo de procesado
        RaiseEvent notificarMensaje(Now, "Procesando el formulario/control " & eRutaFicheroEntrada & "...")
        Dim momentoInicio As DateTime = Now

        ' Se lee el contenido de fichero con la versión antigua de la traducción, para utilizarla como
        ' base de traducción y evitar volver a traducir el texto ya traducido o el texto que fué
        ' corregido posteriormente por otra persona
        RaiseEvent notificarMensaje(Now, "Analizando traducciones previas...")

        ' Diccionario donde se va a guardar el idioma y el contenido del fichero PO previo
        Dim traduccionesAntiguas As New Dictionary(Of idiomaLocalizacion, String)

        ' Se recorre cada uno de los idiomas de salida configurados y se carga en el diccionario
        ' de traducciones antiguas
        For Each unIdioma As cIdioma In iIdiomas
            Try
                RaiseEvent notificarMensaje(Now, "Obteniendo traducciones de la versión " & eVersion & " para " & unIdioma.strNombre & "[" & unIdioma.codigoLocalizacion & "]...")

                Dim rutaVersionAntigua As String = iProyectoVB.carpetaTraducciones & unIdioma.strCodigoLocalizacion & "_" & eVersion & ".po"
                If File.Exists(rutaVersionAntigua) Then
                    Dim contenidoVersionAntigua As String = ""

                    Dim lectorVersionAntigua As New StreamReader(rutaVersionAntigua, System.Text.Encoding.UTF8)
                    contenidoVersionAntigua = lectorVersionAntigua.ReadToEnd
                    lectorVersionAntigua.Close()

                    ' Se añade la traduccin al diccionario
                    traduccionesAntiguas.Add(unIdioma.codigoLocalizacion, contenidoVersionAntigua)
                End If
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al obtener las traducciones antiguas para un idioma...", ex, New StackTrace(0, True))
            End Try
        Next


        ' Se convierte todo el proyecto a UTF8 para evitar problemas de traduccion, para ello, se van
        ' leyendo todos los componentes del proyecto, se escriben en UTF8 en un fichero temporal, y se vuelven
        ' a copiar en el proyecto, guardando una copia del documento original en la carpeta _BACKUP en
        ' la misma carpeta donde se encuentra el proyecto.
        RaiseEvent notificarMensaje(Now, "Realizando copia de seguridad de '" & Ficheros.extraerNombreFichero(eRutaFicheroEntrada) & "'...")
        Try
            Dim rutaBackup As String = iProyectoVB.carpetaProyecto & "\_BACKUP\"
            If Not IO.Directory.Exists(rutaBackup) Then IO.Directory.CreateDirectory(rutaBackup)

            If eRutaFicheroEntrada.Contains("\..\") Then
                rutaBackup = eRutaFicheroEntrada & ".bak"
            Else
                rutaBackup &= eRutaFicheroEntrada.Substring(iProyectoVB.carpetaProyecto.Length + 1) & ".bak"
            End If
            Ficheros.Copiar.copiarArchivo(eRutaFicheroEntrada, rutaBackup, True, True)
        Catch ex As Exception
            If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al realizar la copiad e seguridad de un archivo...", ex, New StackTrace(0, True))
        End Try

        ' Cambio del fichero a UTF-8, además, se crea el objeto Components para poder acceder a estos a la hora de traducir los objetos
        ' que no tiene representación sobre el formulario, accediendo a ellos mediante esta nueva propiedad
        RaiseEvent notificarMensaje(Now, "Convirtiendo a UFT-8 el archivo '" & Ficheros.extraerNombreFichero(eRutaFicheroEntrada) & "'...")
        Try
            Dim archivoTemporal As String = Ficheros.obtenerFicheroTemporal
            If IO.File.Exists(archivoTemporal) Then IO.File.Delete(archivoTemporal)
            Dim contenidoOriginal As String = File.ReadAllText(eRutaFicheroEntrada, System.Text.Encoding.Default)

            ' Se realizan ajustes sobre el objeto Comonents para poder acceder a estos,
            ' cambiando la linean "End Class" por la nueva linea de componentes
            If contenidoOriginal.Contains("Private components As System.ComponentModel.IContainer") Then
                If Not contenidoOriginal.Contains("Public ReadOnly Property losComponentes As System.ComponentModel.ComponentCollection") Then
                    Dim losComponentes As String = Environment.NewLine & _
                                                   "Public ReadOnly Property losComponentes As System.ComponentModel.ComponentCollection" & Environment.NewLine & _
                                                   "    Get" & Environment.NewLine & _
                                                   "        If Me.components IsNot Nothing Then" & Environment.NewLine & _
                                                   "            Return Me.components.Components" & Environment.NewLine & _
                                                   "        else" & Environment.NewLine & _
                                                   "            Return Nothing" & Environment.NewLine & _
                                                   "        End If" & Environment.NewLine & _
                                                   "    End Get" & Environment.NewLine & _
                                                   "End Property" & Environment.NewLine & _
                                                   Environment.NewLine & _
                                                   "End Class"

                    contenidoOriginal = contenidoOriginal.Replace("End Class", losComponentes)
                End If
            End If

            ' Se copia el fichero en UTF sobreescribiendo el fichero origienal            
            File.WriteAllText(archivoTemporal, contenidoOriginal, System.Text.Encoding.UTF8)
            IO.File.Copy(archivoTemporal, eRutaFicheroEntrada, True)
        Catch ex As Exception
            If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al convertir el fichero a UTF-8...", ex, New StackTrace(0, True))
        End Try

        ' ---------------------------------------------------------------------------------------------

        ' Se cuentan cuantos elementos se van a procesar
        RaiseEvent notificarMensaje(Now, vbTab & "Obteniendo elementos a traducir...")

        ' + CONTAR CONTROLES
        Dim losControles As Dictionary(Of String, String) = obtenerControles(eRutaFicheroEntrada)
        Dim totalControles As Integer = losControles.Count

        ' + CONTAR MENSAJES
        Dim losMSGBOX As Dictionary(Of String, String) = obtenerMensajes(eRutaFicheroEntrada)
        Dim totalMensajes As Integer = losMSGBOX.Count

        ' CONTAR IDIOMAS
        Dim totalIdiomas As Integer = iIdiomas.Count

        ' Se obtiene el nombre del formulario para la generación de los nombres de los objetos
        ' a insertar el fichero PO. Los nombres de los formularios son únicos por proyecto, por
        ' lo que esta será la base del objeto que se añadirá al fichero PO para identificar 
        ' los controles y mensajes traducidos
        Dim NombreFormulario As String = Ficheros.extraerNombreFichero(eRutaFicheroEntrada)
        If NombreFormulario.Contains(".designer.vb") Then NombreFormulario = NombreFormulario.Replace(".designer.vb", "")
        If NombreFormulario.Contains(".Designer.vb") Then NombreFormulario = NombreFormulario.Replace(".Designer.vb", "")
        If NombreFormulario.Contains(".vb") Then NombreFormulario = NombreFormulario.Replace(".vb", "")

        ' ToDo: Barra progreso
        'If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.fijarMaximoBarra(eBarraProgreso, ((totalControles + totalMensajes) * (totalIdiomas) * 6) + 1)

        ' Solamente se realiza la traducción si hay algo que traducir
        If totalControles > 0 Or totalIdiomas > 0 Then

            ' Se lee el contenido del formulario. Este formulario ya está convertido a UTF-8
            ' por lo que el Encodig se fija a este formato
            Dim elLector As StreamReader = New System.IO.StreamReader(eRutaFicheroEntrada, System.Text.Encoding.UTF8)
            Dim elFicheroDesignerCompleto As String = elLector.ReadToEnd
            elLector.Close()

            ' Se crea el fichero HTML con las cadenas de textos a traducir
            Dim NombreFicheroIdiomaEntrada As String = iProyectoVB.carpetaTraducciones & IdiomaUso.strCodigoLocalizacion & ".html"
            If IO.File.Exists(NombreFicheroIdiomaEntrada) Then IO.File.Delete(NombreFicheroIdiomaEntrada)

            Dim elEscritor As New StreamWriter(NombreFicheroIdiomaEntrada, False, System.Text.Encoding.UTF8)
            elEscritor.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=utf-8"">")
            elEscritor.WriteLine("<table border=1>")

            ' A medida que se detectan controles se van añadiendo a la lista de los nombres de los controles
            ' y el texto original, siempre y cuando este no se encuentre ya en la versión antigua de la
            ' traducción con el mismo texto, lo que significaría que la traducción no cambia y sigue siendo
            ' la misma, en caso contrario, se tiene que volver a traducir.
            Dim DiccionarioTraducciones As New Dictionary(Of idiomaLocalizacion, List(Of cTraduccionIntermedia))
            For Each UnIdioma As cIdioma In iIdiomas
                Try
                    DiccionarioTraducciones.Add(UnIdioma.codigoLocalizacion, New List(Of cTraduccionIntermedia))                    
                Catch ex As Exception
                End Try
            Next

            ' Controla el numero de elementos que se están traduciendo y si se encontró el propio formulario
            Dim elIndice As Long = 0
            Dim encontroFormulario As Boolean = False

            For Each S As KeyValuePair(Of String, String) In losControles
                Dim seAnhadio As Boolean = False
                Dim yaAnhadido As Boolean = False
                Dim PatronBusqueda As String = ""
                Dim uniqueName As String = ""

                If S.Value.EndsWith("System.Windows.Forms.Form") OrElse S.Value.EndsWith("System.Windows.Forms.Form()") Then encontroFormulario = True

                ' Algunos controles no tienen la propiedad nombre (Krypton), por lo que 
                ' hay que utilizar el UniqueName
                If S.Value.Contains("ComponentFactory.Krypton.Toolkit.ButtonSpecAny") Then
                    Try
                        Dim patronUniqueName As String = S.Key & ".UniqueName ="

                        Dim posInicio As Integer = 0
                        Dim posFin As Integer = 0
                        posInicio = elFicheroDesignerCompleto.IndexOf(patronUniqueName)

                        If posInicio > 0 Then
                            posFin = elFicheroDesignerCompleto.IndexOf("""", posInicio + patronUniqueName.Length + 1)

                            uniqueName = elFicheroDesignerCompleto.Substring(posInicio + patronUniqueName.Length + 1, (posFin + 1) - (posInicio - 1))
                            uniqueName = uniqueName.Replace("""", "").Trim
                        End If
                    Catch ex As Exception
                        Debugger.Break()
                        uniqueName = ""
                    End Try
                ElseIf S.Value.Contains("ComponentFactory.Krypton.Toolkit.KryptonManager") Then
                    uniqueName = "_KManager"
                End If

                PatronBusqueda = ".TextLine1 = "                
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_l1", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".TextLine2 = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_l2", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".Text = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".Values.Text = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".ExtraText = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_extraText", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".ToolTipBody = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_toolTipBody", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".ToolTipTitle = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_toolTipTitle", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".ToolTipText = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_tooltiptext", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Abort = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Abort", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Cancel = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Cancel", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Close = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Close", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Ignore = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Ignore", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.No = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_No", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.OK = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_OK", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Retry = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Retry", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Today = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Today", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Yes = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Yes", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName)
                If seAnhadio Then yaAnhadido = True

                ' Si el control no se añadió con ningún padrón, entonces se
                ' añade de todas formas sin traducción
                If Not yaAnhadido Then
                    ' ToDo: Necesario??
                End If
            Next

            ' Si no encontró el formulario se fuerza la búsqueda.
            ' A veces el propio formulario no se crea con New System.Windows.Forms.Form() 
            ' y el Texto aparece directamente bajo el patrón .Text = 
            If Not encontroFormulario Then
                Dim elPar As New KeyValuePair(Of String, String)("Me", "System.Windows.Forms.Form()")
                AnhadirControl(elFicheroDesignerCompleto, elPar, ".Text = ", "_Form_Text", elEscritor, eIgnorarHTMLSubida, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, "")
            End If

            For Each S As KeyValuePair(Of String, String) In losMSGBOX
                'If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)
                elEscritor.Write("<tr>")
                elEscritor.Write("<td>" & elIndice & "</td>")
                If eIgnorarHTMLSubida Then
                    elEscritor.Write("<td>" & S.Value & "</td>")
                Else
                    elEscritor.Write("<td>" & Web.HTML.UTF2HTML(S.Value) & "</td>")
                End If
                elEscritor.WriteLine("</tr>")

                'escribirMensaje(eMensajes, "[" & S.Key & "] <" & S.Value & ">")

                ' Se añadio el row a la tabla, por lo que se añade a la lista de controles coincidiendo con el índice
                For Each unIdioma As cIdioma In iIdiomas
                    Dim LaTraduccion As New cTraduccionIntermedia With {
                        .Indice = elIndice,
                        .NombreControl = NombreFormulario & "." & S.Key,
                        .Original = S.Value,
                        .Traduccion = ""
                }
                    DiccionarioTraducciones(unIdioma.codigoLocalizacion).Add(LaTraduccion)
                    'If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)
                Next
                elIndice += 1
            Next

            elEscritor.WriteLine("</table>")
            elEscritor.Close()

            'escribirMensaje(eMensajes, "Subiendo fichero al FTP...")
            Dim NombreFicheroServidor As String = Aleatorios.cadenaAleatoria(8, True) & ".html"
            Dim ErrorSubida As Boolean = False
            Dim ContadorIntentos As Integer = 0
            Do
                'escribirMensaje(eMensajes, "Preparando archivo HTML para subir al servidor FTP (" & ContadorIntentos & "/10)...")
                System.Threading.Thread.Sleep(500)
                Try
                    My.Computer.Network.UploadFile(NombreFicheroIdiomaEntrada, ConfiguracionNetwork.Servidor & ConfiguracionNetwork.Ruta & NombreFicheroServidor, ConfiguracionNetwork.Usuario, ConfiguracionNetwork.Clave, True, 2500)
                    ErrorSubida = False
                Catch ex As Exception
                    ErrorSubida = True
                End Try
                ContadorIntentos += 1
            Loop While (ContadorIntentos < 10) And ErrorSubida

            ' Una vez que se ha subido el fichero al servidor, se recorre cada uno de los lenguaje sde salida
            ' pora completar los diccionarios con las traducciones que realiza el parseador            
            For Each UnIdioma As cIdioma In iIdiomas
                Dim URI As String = ""
                'escribirMensaje(eMensajes, "Realizando las traducciones del formulario/control " & NombreFormulario & " de " & cIdioma.ObtenerCodigoCorto(eLenguajeEntrada.codigoLocalizacion) & " a " & cIdioma.ObtenerCodigoCorto(UnIdioma.codigoLocalizacion) & "...")
                Dim url_Original As String = ConfiguracionNetwork.URLBase & NombreFicheroServidor

                URI = Motor.obtenerURL(IdiomaUso, UnIdioma, url_Original)

                Dim laPagina As New Web.cPaginaHTML(120)
                laPagina.cargarURL(URI)

                Dim Limpio As String = ""
                If laPagina.Body.Length > 0 Then
                    Dim Lineas() As String = laPagina.Body.Split(Chr(10))

                    For Each UnaLinea As String In Lineas
                        'If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)
                        UnaLinea = UnaLinea.Trim

                        If UnaLinea.StartsWith("<tr><td>") Then
                            Try
                                Dim Columnas() As String = UnaLinea.Replace("</td><td>", "~").Split("~")

                                Dim IndiceDiccionario As Long = Columnas(0).Trim.Replace("<tr>", "").Replace("</tr>", "").Replace("<td>", "").Replace("</td>", "")
                                Dim Traduccion As String = ""
                                If eIgnorarHTMLBajada Then
                                    Traduccion = Columnas(1).Trim.Replace("<tr>", "").Replace("</tr>", "").Replace("<td>", "").Replace("</td>", "").Replace("�", "")
                                Else
                                    Traduccion = Web.HTML.HTML2UTF(Columnas(1).Trim.Replace("<tr>", "").Replace("</tr>", "").Replace("<td>", "").Replace("</td>", "")).Replace("�", "")
                                End If

                                DiccionarioTraducciones(UnIdioma.codigoLocalizacion)(IndiceDiccionario).Traduccion = Traduccion
                            Catch ex As Exception

                            End Try
                        End If
                    Next
                End If

                ' Entre traducción y traducción se espera un tiempo prudencial
                ' para evitar bloqueos por abuso en el uso del sistema
                'escribirMensaje(eMensajes, "Esperando " & iSleepTime & " milisegundos para evitar bloqueo por abuso del servicio...")
                System.Threading.Thread.Sleep(CType(Motor, cMotorBase).SleepTime)
            Next

            Dim ultimoTraducido As idiomaLocalizacion = IdiomaUso.codigoLocalizacion
            For Each UnIdioma As cIdioma In iIdiomas
                If UnIdioma.codigoLocalizacion <> Me.IdiomaUso.codigoLocalizacion Then
                    Dim NombreFicheroSalida As String = iProyectoVB.carpetaTraducciones & UnIdioma.strCodigoLocalizacion & ".po"
                    Dim elEscritorPO As New StreamWriter(NombreFicheroSalida, True, System.Text.Encoding.UTF8)

                    For Each UnaEntrada As cTraduccionIntermedia In DiccionarioTraducciones(UnIdioma.codigoLocalizacion)
                        'If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)


                        ' Se comprueba si la traducción ya existía en la versión antigua y esta sigue siendo la misma, de
                        ' ser así, esta se ignora
                        Dim IndiceCabecera As Integer = traduccionesAntiguas(UnIdioma.codigoLocalizacion).IndexOf("#: " & UnaEntrada.NombreControl)
                        If IndiceCabecera > 0 Then
                            Dim IndiceCuerpo As Integer = traduccionesAntiguas(UnIdioma.codigoLocalizacion).IndexOf("msgid """ & UnaEntrada.Original & """", IndiceCabecera)
                            If IndiceCuerpo > 0 Then
                                Dim inicioMensajeAntiguo As Integer = traduccionesAntiguas(UnIdioma.codigoLocalizacion).IndexOf("msgstr ", IndiceCuerpo) + 8
                                Dim finalMensajeAntiguo As Integer = traduccionesAntiguas(UnIdioma.codigoLocalizacion).IndexOf(Chr(10), inicioMensajeAntiguo) - 1
                                UnaEntrada.Traduccion = traduccionesAntiguas(UnIdioma.codigoLocalizacion).Substring(inicioMensajeAntiguo, finalMensajeAntiguo - (inicioMensajeAntiguo + 1)).Trim
                            End If
                        End If


                        elEscritorPO.WriteLine("#: " & UnaEntrada.NombreControl)
                        elEscritorPO.WriteLine("msgid """ & Web.HTML.ANSI2UTF8(UnaEntrada.Original) & """")
                        elEscritorPO.WriteLine("msgstr """ & Web.HTML.HTML2UTF(Web.HTML.ANSI2UTF8(UnaEntrada.Traduccion)) & """")
                        elEscritorPO.WriteLine()
                    Next

                    ' Se escribe un texto de final de documento para evitar problemas de EOF cuando se trabaja con el fichero
                    elEscritorPO.WriteLine("#: EOF")
                    elEscritorPO.WriteLine("msgid """ & "EOF" & """")
                    elEscritorPO.WriteLine("msgstr """ & "EOF" & """")
                    elEscritorPO.WriteLine()

                    elEscritorPO.Close()
                    ultimoTraducido = UnIdioma.codigoLocalizacion
                End If
            Next

            ' Finalmente se añade el archivo del idioma original con las traducciones con los mismos textos            
            Dim NombreFicheroSalidaOriginal As String = iProyectoVB.carpetaTraducciones & IdiomaUso.strCodigoLocalizacion & ".po"
            Dim elEscritorPOOriginal As New StreamWriter(NombreFicheroSalidaOriginal, True, System.Text.Encoding.UTF8)

            For Each UnaEntrada As cTraduccionIntermedia In DiccionarioTraducciones(ultimoTraducido)
                'If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)

                elEscritorPOOriginal.WriteLine("#: " & UnaEntrada.NombreControl)
                elEscritorPOOriginal.WriteLine("msgid """ & Web.HTML.ANSI2UTF8(UnaEntrada.Original) & """")
                elEscritorPOOriginal.WriteLine("msgstr """ & Web.HTML.ANSI2UTF8(UnaEntrada.Original) & """")
                elEscritorPOOriginal.WriteLine()
            Next

            elEscritorPOOriginal.Close()
        End If

        Return True
    End Function
#End Region

#Region " METODOS AUXILIARES PO "
    ''' <summary>
    ''' Escribe la cabecera del fichero PO y lo configura para la utilización con el sistema
    ''' de traducciones automáticas
    ''' </summary>
    Public Sub EscribirCabeceraPO(ByVal eEscritor As StreamWriter, _
                                  ByVal eIdioma As String)
        Try
            If eEscritor IsNot Nothing AndAlso iProyectoVB IsNot Nothing Then
                With eEscritor
                    .WriteLine("msgid " & """" & """")
                    .WriteLine("msgstr " & """" & """")
                    .WriteLine("""" & "Project-Id-Version: " & iProyectoVB.Ensamblado & "\n" & """")
                    .WriteLine("""" & "Report-Msgid-Bugs-To: " & correoErrores & "\n" & """")
                    .WriteLine("""" & "POT-Creation-Date: " & Now & "\n" & """")
                    .WriteLine("""" & "PO-Revision-Date: " & Now & "\n" & """")
                    .WriteLine("""" & "Last-Translator: " & nombreTraductor & "\n" & """")
                    .WriteLine("""" & "Language-Team: " & equipoTraduccion & "\n" & """")
                    .WriteLine("""" & "MIME-Version: 1.0\n" & """")
                    .WriteLine("""" & "Content-Type: text/plain; charset=UTF-8\n" & """")
                    .WriteLine("""" & "Content-Transfer-Encoding: 8bit\n" & """")
                    .WriteLine("""" & "X-Poedit-SourceCharset: utf-8\n" & """")
                    .WriteLine("""" & "X-Poedit-KeywordsList: esc_html__;esc_html_e;esc_attr__;esc_attr_e;__;_e\n" & """")
                    .WriteLine("""" & "X-Poedit-Basepath: .\n" & """")
                    .WriteLine("""" & "Language: " & eIdioma & "\n" & """")
                    .WriteLine("""" & "X-Generator: Poedit 1.5.5\n" & """")
                    .WriteLine("""" & "X-Poedit-SearchPath-0: .\n" & """")
                    .WriteLine("""" & "X-Poedit-SearchPath-1: ..\n" & """")
                    .WriteLine()
                End With
            Else
                If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al tratar de escribir la cabecera del archivo PO...", , New StackTrace(0, True))
            End If
        Catch ex As Exception
            If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al tratar de escribir la cabecera del archivo PO...", , New StackTrace(0, True))
        End Try
    End Sub
#End Region





    ''' <summary>
    ''' Se encarga de añadir un control/componente/texto a la lista de controles 
    ''' </summary>
    Private Function AnhadirControl(ByVal elFicheroDesignerCompleto As String, _
                                    ByVal S As KeyValuePair(Of String, String), _
                                    ByVal ePatronBusqueda As String, _
                                    ByVal ePostNombre As String, _
                                    ByVal elEscritor As StreamWriter, _
                                    ByVal eIgnorarHTMLSubida As Boolean, _
                                    ByRef elIndice As Long, _
                                    ByVal NombreFormulario As String, _
                                    ByRef DiccionarioTraducciones As Dictionary(Of idiomaLocalizacion, List(Of cTraduccionIntermedia)), _
                                    ByVal eContenidoAntiguo As Dictionary(Of idiomaLocalizacion, String), _
                                    Optional ByVal eNombreControl As String = "") As Boolean
        Dim posInicio As Integer = -1
        Dim posFin As Integer = -1
        Dim elTextoTraducir As String = ""
        Dim PostNombre As String = ""

        posInicio = elFicheroDesignerCompleto.IndexOf(S.Key & ePatronBusqueda)
        If posInicio > 0 Then PostNombre = ePostNombre

        If posInicio >= 0 Then
            Dim arrayIdiomas(Idiomas.Count) As String
            posFin = elFicheroDesignerCompleto.IndexOf(vbCrLf, posInicio + 1)

            Dim laSubCadena As String = elFicheroDesignerCompleto.Substring(posInicio, posFin - posInicio)
            laSubCadena = laSubCadena.Trim

            While laSubCadena.EndsWith(" & _")
                laSubCadena = laSubCadena.Replace(""" & _", "")
                posInicio = posFin + 1
                posFin = elFicheroDesignerCompleto.IndexOf(vbCrLf, posInicio + 1)
                Dim SiguienteTrozo As String = elFicheroDesignerCompleto.Substring(posInicio, posFin - posInicio).Trim
                If SiguienteTrozo.StartsWith("""") Then SiguienteTrozo = SiguienteTrozo.Substring(1, SiguienteTrozo.Length - 1)
                laSubCadena &= SiguienteTrozo
            End While

            Dim posIniComillas As Integer = laSubCadena.IndexOf("""") + 1
            If posIniComillas >= 0 Then
                elTextoTraducir = laSubCadena.Substring(posIniComillas)
                elTextoTraducir = elTextoTraducir.Substring(0, elTextoTraducir.Length - 1).Replace("&", "")

                Dim resultadoTraduccion As String = ""

                elEscritor.Write("<tr>")
                elEscritor.Write("<td>" & elIndice & "</td>")
                If eIgnorarHTMLSubida Then
                    elEscritor.Write("<td>" & elTextoTraducir & "</td>")
                Else
                    elEscritor.Write("<td>" & Web.HTML.UTF2HTML(elTextoTraducir) & "</td>")
                End If
                elEscritor.WriteLine("</tr>")

                Dim nombreControl As String = eNombreControl
                If String.IsNullOrEmpty(nombreControl) Then
                    If S.Key <> "Me" Then
                        nombreControl = S.Key.Substring(3)
                    Else
                        nombreControl = NombreFormulario
                    End If
                End If

                RaiseEvent notificarMensaje(Now, "[" & nombreControl & " : " & S.Value & "] <" & elTextoTraducir & ">")

                ' Se añadio el row a la tabla, por lo que se añade a la lista de controles coincidiendo con el índice
                For Each unIdioma As cIdioma In iIdiomas
                    Dim LaTraduccion As New cTraduccionIntermedia With {
                        .Indice = elIndice,
                        .NombreControl = NombreFormulario & "." & nombreControl & PostNombre,
                        .Original = elTextoTraducir,
                        .Traduccion = ""
                }
                    DiccionarioTraducciones(unIdioma.codigoLocalizacion).Add(LaTraduccion)
                Next

                ' Se pasa al siguiente control y se devuelve un True indicando que 
                ' se encontró el patrón y se añadió al ficheor de traducciones
                elIndice += 1
                Return True
            End If
        End If

        ' Si el código llega hasta aquí es que no se pudo añadir el control ya que 
        ' no se encontró el patrón de búsqueda. Es necesario saber si se añadió
        ' o no ya que aunque un control no tenga traducción puede que si lo tengan
        ' sus hijos, en tal caso, se debe añadir igual sin texto
        Return False
    End Function



    ''' <summary>
    ''' Obitiene los controles que se pueden traducir o el sistema reconoce
    ''' </summary>
    Private Function obtenerControles(ByVal eFicheroEntrada As String) As Dictionary(Of String, String)
        ' ToDo: Cambiar el sistema de traducción del ribbon y utilizar el mismo que se usar par alos bottonspec            

        Dim paraDevolver As New Dictionary(Of String, String)

        Dim elLector As New System.IO.StreamReader(eFicheroEntrada, System.Text.Encoding.UTF8)
        Dim laCadena As String = ""

        ' Se obtienen todos los controles a traducir
        Do
            laCadena = elLector.ReadLine.Trim

            If (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonWrapLabel()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonWrapLabel")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonLabel()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonLabel")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonButton()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonButton")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonCheckBox()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonCheckBox")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonRadioButton()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonRadioButton")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonGroupBox()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonGroupBox")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonPanel()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonPanel")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonForm()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonForm")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonSplitContainer")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonManager")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonManager()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.ButtonSpecAny")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Toolkit.ButtonSpecAny()")) Or _
 _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Docking.KryptonDockableNavigator")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Docking.KryptonDockableNavigator()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Navigator.KryptonNavigator")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Navigator.KryptonNavigator()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Navigator.KryptonPage")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Navigator.KryptonPage()")) Or _
 _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.Label()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.Label")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.LinkLabel()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.LinkLabel")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.Button()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.Button")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.CheckBox()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.CheckBox")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.RadioButton()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.RadioButton")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.GroupBox()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.GroupBox")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.CheckedListBox()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.CheckedListBox")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.TreeNode()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.TreeNode")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.Form()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.Form")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.SplitContainer()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.SplitContainer")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.FlowLayoutPanel()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.FlowLayoutPanel")) Or _
 _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.MenuStrip()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.MenuStrip(Me.components)")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.MenuStrip")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStrip()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStrip")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripDropDownButton()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripDropDownButton")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripSplitButton()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripSplitButton")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripStatusLabel()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripStatusLabel")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripButton()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripButton")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripTextBox()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripTextBox")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.StatusStrip()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.StatusStrip")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ContextMenuStrip()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ContextMenuStrip(Me.components)")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ContextMenuStrip")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripMenuItem()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripMenuItem")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripDropDownItem()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripDropDownItem")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripLabel()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripLabel")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripComboBox()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.ToolStripComboBox")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.TabPage()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("System.Windows.Forms.TabPage")) Or _
 _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Ribbon.KryptonRibbonTab()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Ribbon.KryptonRibbonTab")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()")) Or _
              (laCadena.Contains(" = New ") And laCadena.EndsWith("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton")) Then

                Try
                    Dim nombreControl As String = laCadena.Substring(0, laCadena.IndexOf("=")).Trim
                    Dim tipoComponente As String = laCadena.Substring(laCadena.IndexOf("=") + 5).Trim
                    tipoComponente = tipoComponente.Replace("Me.components", "")

                    paraDevolver.Add(nombreControl, tipoComponente)
                Catch ex As Exception
                End Try
            End If
        Loop Until elLector.EndOfStream
        elLector.Close()

        Return paraDevolver
    End Function



    ''' <summary>
    ''' Obitnene las cadenas de texto que el sistema es capaz de traducir
    ''' </summary>
    Private Function obtenerMensajes(ByVal eFicheroEntrada As String) As Dictionary(Of String, String)
        Dim laRutaCodigoFuente As String = eFicheroEntrada
        Dim paraDevolver As New Dictionary(Of String, String)

        laRutaCodigoFuente = eFicheroEntrada.Substring(0, eFicheroEntrada.Length - 11) & "vb"

        Dim encontroInicio As Boolean = False

        If System.IO.File.Exists(laRutaCodigoFuente) Then
            Dim elReader As New System.IO.StreamReader(laRutaCodigoFuente, System.Text.Encoding.UTF8)
            Dim laCadena As String
            Dim laKey As Integer = 0

            Do
                laCadena = elReader.ReadLine.Trim

                If encontroInicio Then
                    If laCadena = "}" Then
                        Exit Do
                    Else
                        If laCadena <> "" AndAlso laCadena <> """""" Then
                            laCadena = laCadena.Substring(1)

                            Dim elValor As String = laCadena.Split("""")(0)

                            paraDevolver.Add("_" & laKey, elValor)

                            laKey += 1
                        End If
                    End If
                Else
                    If laCadena = "Public Property theMessages As String() = { _" Then
                        encontroInicio = True
                    End If
                End If
            Loop Until elReader.EndOfStream
        End If

        Return paraDevolver
    End Function


End Class
