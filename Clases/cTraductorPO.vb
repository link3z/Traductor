' ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
''' <summary>
''' Clase para trabajo con ficheros PO de traducciones
''' </summary>
Public Class cTraductorPO
#Region " CLASES INTERNAS "
    ''' <summary>
    ''' Utilizado para la traducción intermedia. 
    ''' Se encarga de guardar una relación entre un índice utilizado para la generación
    ''' del HTML en Web, el nombre del control, el texto original y la traducción obtenida
    ''' </summary>
    Private Class cTraduccion
        Public Property Indice As Long
        Public Property NombreControl As String
        Public Property Original As String
        Public Property Traduccion As String
    End Class
#End Region

#Region " DECLARACIONES "
    ''' <summary>
    ''' Idiomas con los que va a atrabajar la aplicación
    ''' </summary>
    Private iIdiomas As New List(Of cIdioma)

    ''' <summary>
    ''' Motor de traducción que se va a utilizar
    ''' </summary>
    Private iMotor As cMotorTraduccion = Nothing

    ''' <summary>
    ''' Datos de acceso al servidor FTP intermedio para las traducciones
    ''' </summary>            
    Public ConfiguracionFTP As New cConfiguracionFTP

    ''' <summary>
    ''' Finalidad que se le va a dar al objeto
    ''' </summary>
    Private iFinalidad As enmFinalidadTraductor

    ''' <summary>
    ''' Carga en memoria de todas las posibles traducciones a partir de un idioma
    ''' </summary>
    Private iContenidoFichero As String

    ''' <summary>
    ''' Idioma al que se va a traducir el formualario (cargado en memoria)
    ''' </summary>
    Private iIdiomaUso As cIdioma = Nothing

    ''' <summary>
    ''' Tiempo de espera entre traducciones para evitar sobrecarga
    ''' </summary>
    Private iSleepTime As Long = 0
#End Region

#Region " ENUMERADOS "
    ''' <summary>
    ''' Funcionalidad para la que se va utilizar el objeto
    ''' </summary>
    Public Enum enmFinalidadTraductor
        CrearTraducciones = 1                       ' Se va a utilizar para traducir otros proyectos
        UsarTraducciones = 2                        ' Se va a utilizar para traducir el propio proyecto a partir de traducciones
    End Enum
#End Region

#Region " PROPIEDADES "
    ''' <summary>
    ''' Idiomas cargados en el objeto
    ''' </summary>
    Public ReadOnly Property Idiomas As List(Of cIdioma)
        Get
            cargarTodos()
            Return iIdiomas
        End Get
    End Property

    Public Property Motor As cMotorTraduccion
        Get
            Return iMotor
        End Get
        Set(value As cMotorTraduccion)
            If iMotor Is Nothing OrElse (iMotor IsNot Nothing AndAlso iMotor.Motor <> value.Motor) Then
                iMotor = value
                cargarTodos()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Idioma con el que se está trabajando
    ''' </summary>
    Public Property IdiomaUso As cIdioma
        Get
            Return iIdiomaUso
        End Get
        Set(value As cIdioma)
            Dim SeCarga As Boolean = False
            If value IsNot Nothing Then
                If iIdiomaUso IsNot Nothing Then
                    If value.Id <> iIdiomaUso.Id Then
                        SeCarga = True
                    End If
                Else
                    SeCarga = True
                End If

                If SeCarga Then
                    Dim RutaFichero As String = Application.StartupPath & "\Languages\" & Criptografia.EncriptarEnMD5(My.Application.Info.AssemblyName) & "\" & value.Codigo & ".po"
                    If IO.File.Exists(RutaFichero) Then
                        Dim Lector As New StreamReader(RutaFichero, System.Text.Encoding.UTF8)
                        iContenidoFichero = Lector.ReadToEnd
                        Lector.Close()
                        iIdiomaUso = value
                    End If
                End If
            End If
        End Set
    End Property
#End Region

#Region " CONSTRUCTORES "
    ''' <summary>
    ''' Constructor limpio que instancia la clase y la configura para su
    ''' utilización
    ''' </summary>
    Public Sub New(ByVal eFinalidad As enmFinalidadTraductor)
        iFinalidad = eFinalidad
    End Sub

    ''' <summary>
    ''' Crea un objeto de la clase cargando todos los lenguajes disponibles
    ''' </summary>
    Public Sub New(ByVal eFinalidad As enmFinalidadTraductor, _
                   ByVal eCargarTodos As Boolean)
        iFinalidad = eFinalidad
        If eCargarTodos Then cargarTodos()
    End Sub
#End Region

#Region " METODOS IDIOMAS "
    ''' <summary>
    ''' Añade un nuevo lenguaje al objeto
    ''' </summary>
    Public Sub anhadirIdioma(ByVal eIdioma As cIdioma)
        If Not iIdiomas.Contains(eIdioma) Then iIdiomas.Add(eIdioma)
    End Sub

    ''' <summary>
    ''' Añade un nuevo lenguaje al objeto
    ''' </summary>
    Public Sub anhadirIdioma(ByVal eLenguaje As enmLenguajesNombres)
        Dim nuevoIdioma As cIdioma = cIdioma.ObtenerObjetoIdioma(eLenguaje)
        anhadirIdioma(nuevoIdioma)
    End Sub

    ''' <summary>
    ''' Elimina un idioma del objeto
    ''' </summary>
    Public Sub quitarIdioma(ByVal eIdioma As cIdioma)
        If iIdiomas.Contains(eIdioma) Then iIdiomas.Remove(eIdioma)
    End Sub

    ''' <summary>
    ''' Elimina un idioma del objeto
    ''' </summary>
    Public Sub quitarIdioma(ByVal eIdioma As enmLenguajesNombres)
        Dim nuevoIdioma As cIdioma = cIdioma.ObtenerObjetoIdioma(eIdioma)
        quitarIdioma(nuevoIdioma)
    End Sub
#End Region

#Region " CARGA DE IDIOMAS "
    ''' <summary>
    ''' Carga en la lista de lenguajes todos los lenguajes disponibles en la implementación
    ''' de la clase
    ''' </summary>            
    Public Sub cargarTodos()
        iIdiomas.Clear()

        ' Dependiendo de la finalidad del traductor, los idiomas se cargarán
        ' utilizando los internos (programados), o los disponibles en la carpeta de traducciones
        If iFinalidad = enmFinalidadTraductor.CrearTraducciones Then
            If iMotor IsNot Nothing Then
                For Each unIdioma As cIdioma In iMotor.idiomasDisponibles
                    anhadirIdioma(unIdioma)
                Next
            End If
        ElseIf iFinalidad = enmFinalidadTraductor.UsarTraducciones Then
            Dim rutaLenguajes As String = Application.StartupPath & "\Languages\" & Criptografia.EncriptarEnMD5(My.Application.Info.AssemblyName)
            If IO.Directory.Exists(rutaLenguajes) Then
                For Each unLenguaje As String In My.Computer.FileSystem.GetFiles(rutaLenguajes)
                    If IO.File.Exists(unLenguaje) AndAlso unLenguaje.ToLower.EndsWith(".po") Then
                        Dim NombreIdioma As String = Ficheros.extraerNombreFichero(unLenguaje).Replace(".po", "")
                        Dim elIdioma As Traductor.cIdioma = cIdioma.ObtenerObjetoIdioma(cIdioma.iso2enum(NombreIdioma))
                        If elIdioma IsNot Nothing Then anhadirIdioma(elIdioma)
                    End If
                Next
            End If

        End If
    End Sub
#End Region

#Region " MENSAJES DE ESTADO "
    ''' <summary>
    ''' Utilizado par amostrar mensajes e información del estado
    ''' </summary>
    ''' <param name="eTextBox">TextBox donde se concatenará el mensaje</param>
    ''' <param name="eMensaje">Mensaje a concatenar</param>
    Private Sub escribirMensaje(ByRef eTextBox As TextBox, _
                                ByVal eMensaje As String)
        Try
            eTextBox.AppendText(" " & Format(Now, "HH:mm:ss") & " > " & eMensaje.Trim & vbCrLf)
            eTextBox.Refresh()
            Application.DoEvents()
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region " TRADUCTOR "
    ''' <summary>
    ''' Escribe la cabecera del fichero PO y lo configura para la utilización con el sistema
    ''' de traducciones automáticas
    ''' </summary>
    ''' <param name="eEscritor">StreamWriter donde se tiene que escribir la cabecera</param>
    ''' <param name="eNombreEnsamblado">Nombre del ensamblado/programa que se está traduciendo</param>
    ''' <param name="eIdioma"></param>
    ''' <remarks></remarks>
    Public Shared Sub EscribirCabeceraPO(ByVal eEscritor As StreamWriter, _
                                         ByVal eNombreEnsamblado As String, _
                                         ByVal eIdioma As String, _
                                         Optional ByVal eCorreoBugs As String = "info@recompila.com", _
                                         Optional ByVal eNombreTraductor As String = "Javier Rodríguez Blanco <info@recompila.com>", _
                                         Optional ByVal eEquipoTraduccion As String = "Recompila <info@recompila.com>")

        With eEscritor
            .WriteLine("msgid " & """" & """")
            .WriteLine("msgstr " & """" & """")
            .WriteLine("""" & "Project-Id-Version: " & eNombreEnsamblado & "\n" & """")
            .WriteLine("""" & "Report-Msgid-Bugs-To: " & eCorreoBugs & "\n" & """")
            .WriteLine("""" & "POT-Creation-Date: " & Now & "\n" & """")
            .WriteLine("""" & "PO-Revision-Date: " & Now & "\n" & """")
            .WriteLine("""" & "Last-Translator: " & eNombreTraductor & "\n" & """")
            .WriteLine("""" & "Language-Team: " & eEquipoTraduccion & "\n" & """")
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
    End Sub

    ''' <summary>
    ''' Se encarga de añadir un control/componente/texto a la lista de controles 
    ''' </summary>
    Private Function AnhadirControl(ByVal elFicheroDesignerCompleto As String, _
                                    ByVal S As KeyValuePair(Of String, String), _
                                    ByVal ePatronBusqueda As String, _
                                    ByVal ePostNombre As String, _
                                    ByVal eLenguajesSalida As List(Of cIdioma), _
                                    ByVal elEscritor As StreamWriter, _
                                    ByVal eIgnorarHTMLSubida As Boolean, _
                                    ByVal eMensajes As TextBox, _
                                    ByRef elIndice As Long, _
                                    ByVal NombreFormulario As String, _
                                    ByRef DiccionarioTraducciones As Dictionary(Of enmLenguajesCodigos, List(Of cTraduccion)), _
                                    ByVal eContenidoAntiguo As Dictionary(Of String, String), _
                                    Optional ByVal eNombreControl As String = "",
                                    Optional ByRef eBarraProgreso As ProgressBar = Nothing) As Boolean
        Dim posInicio As Integer = -1
        Dim posFin As Integer = -1
        Dim elTextoTraducir As String = ""
        Dim PostNombre As String = ""

        posInicio = elFicheroDesignerCompleto.IndexOf(S.Key & ePatronBusqueda)
        If posInicio > 0 Then PostNombre = ePostNombre

        If posInicio >= 0 Then
            Dim arrayIdiomas(eLenguajesSalida.Count) As String
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

                If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)
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

                escribirMensaje(eMensajes, "[" & nombreControl & " : " & S.Value & "] <" & elTextoTraducir & ">")

                ' Se añadio el row a la tabla, por lo que se añade a la lista de controles coincidiendo con el índice
                For Each unIdioma As cIdioma In eLenguajesSalida
                    Dim LaTraduccion As New cTraduccion With {
                        .Indice = elIndice,
                        .NombreControl = NombreFormulario & "." & nombreControl & PostNombre,
                        .Original = elTextoTraducir,
                .Traduccion = ""
                }
                    DiccionarioTraducciones(unIdioma.Id).Add(LaTraduccion)
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
    ''' Genera el fichero PO a pardir de un fichero VB
    ''' </summary>
    Public Function generarFicheroOP_VB(ByVal eRutaProyecto As String, _
                                        ByVal eRutaTraducciones As String, _
                                        ByVal eRutaFicheroEntrada As String, _
                                        ByVal eLenguajesSalida As List(Of cIdioma), _
                                        ByVal eMotorTraduccion As cMotorTraduccion, _
                                        ByVal eIgnorarHTMLSubida As Boolean, _
                                        ByVal eIgnorarHTMLBajada As Boolean, _
                                        ByVal eMensajes As TextBox, _
                                        ByVal eVersion As String, _
                                        Optional ByRef eBarraProgreso As ProgressBar = Nothing) As Boolean
        Dim momentoInicio As DateTime = Now
        Dim eLenguajeEntrada As cIdioma = cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Español)

        ' Se lee el contenido de fichero con la versión antigua de la traducción, para utilizarla como
        ' base de traducción y evitar volver a traducir el texto ya traducido
        escribirMensaje(eMensajes, "Realizando operaciones previas...")
        Dim traduccionesAntiguas As New Dictionary(Of String, String)
        Dim ContenidoVersionAntigua As String = ""
        For Each unIdioma As cIdioma In eLenguajesSalida
            Dim rutaVersionAntigua As String = eRutaTraducciones & "\" & unIdioma.Codigo & "_" & eVersion & ".po"
            escribirMensaje(eMensajes, "Obteniendo traducciones de la versión " & eVersion & "...")

            If File.Exists(rutaVersionAntigua) Then
                Dim lectorAnterior As New StreamReader(rutaVersionAntigua, System.Text.Encoding.UTF8)
                ContenidoVersionAntigua = lectorAnterior.ReadToEnd
                lectorAnterior.Close()
            End If

            Try
                traduccionesAntiguas.Add(unIdioma.Codigo, ContenidoVersionAntigua)
            Catch ex As Exception
            End Try
        Next


        ' Se convierte todo el proyecto a UTF8 para evitar problemas de traduccion, para ello, se van
        ' leyendo todos los componentes del proyecto, se escriben en UTF8 en un fichero temporal, y se vuelven
        ' a copiar en el proyecto            

        escribirMensaje(eMensajes, "Creando copia del archivo en UTF-8...")
        Dim archivoTemporal As String = Ficheros.obtenerFicheroTemporal
        If IO.File.Exists(archivoTemporal) Then IO.File.Delete(archivoTemporal)
        Dim recodificar As String = File.ReadAllText(eRutaFicheroEntrada, System.Text.Encoding.Default)

        ' Se realizan ajustes sobre el objeto Comonents para poder acceder a estos
        If recodificar.Contains("Private components As System.ComponentModel.IContainer") Then
            If Not recodificar.Contains("Public ReadOnly Property losComponentes As System.ComponentModel.ComponentCollection") Then
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

                recodificar = recodificar.Replace("End Class", losComponentes)
            End If
        End If

        File.WriteAllText(archivoTemporal, recodificar, System.Text.Encoding.UTF8)

        ' Antes de realizar la traducción se hace una copia de seguridad del fichero original
        ' para utilizar siempre en la traducción el fichero UTF-8
        Dim rutaBackup As String = ""
        rutaBackup = eRutaProyecto & "\_BACKUP\"
        If Not IO.Directory.Exists(rutaBackup) Then IO.Directory.CreateDirectory(rutaBackup)

        If eRutaFicheroEntrada.Contains("\..\") Then
            rutaBackup = eRutaFicheroEntrada & ".bak"
        Else
            rutaBackup &= eRutaFicheroEntrada.Substring(eRutaProyecto.Length + 1) & ".bak"
        End If

        Ficheros.Copiar.copiarArchivo(eRutaFicheroEntrada, rutaBackup, True, True)

        ' Se copia el fichero en UTF sobreescribiendo el fichero origienal            
        IO.File.Copy(archivoTemporal, eRutaFicheroEntrada, True)

        escribirMensaje(eMensajes, "Procesando el formulario/control " & eRutaFicheroEntrada & "...")

        ' Se cuentan cuantos elementos se van a procesar
        escribirMensaje(eMensajes, vbTab & "Obteniendo elementos a traducir...")

        ' CONTAR CONTROLES!!!!!
        Dim losControles As Dictionary(Of String, String) = obtenerControles(eRutaFicheroEntrada)
        Dim totalControles As Integer = losControles.Count
        escribirMensaje(eMensajes, vbTab & "Total Controles: " & totalControles)
        ' !!!!!!!!!!!!!!!!!!!!!

        ' CONTAR MENSAJES!!!!!!
        Dim losMSGBOX As Dictionary(Of String, String) = obtenerMensajes(eRutaFicheroEntrada)
        Dim totalMensajes As Integer = losMSGBOX.Count
        escribirMensaje(eMensajes, vbTab & "Total Mensajes: " & totalMensajes)
        ' !!!!!!!!!!!!!!!!!!!!!

        ' CONTAR IDIOMAS!!!!!!!
        Dim totalIdiomas As Integer = eLenguajesSalida.Count
        escribirMensaje(eMensajes, vbTab & "Total Idiomas: " & totalIdiomas)
        ' !!!!!!!!!!!!!!!!!!!!!


        Dim NombreFormulario As String = Ficheros.extraerNombreFichero(eRutaFicheroEntrada)
        If NombreFormulario.Contains(".designer.vb") Then NombreFormulario = NombreFormulario.Replace(".designer.vb", "")
        If NombreFormulario.Contains(".Designer.vb") Then NombreFormulario = NombreFormulario.Replace(".Designer.vb", "")
        If NombreFormulario.Contains(".vb") Then NombreFormulario = NombreFormulario.Replace(".vb", "")

        If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.fijarMaximoBarra(eBarraProgreso, ((totalControles + totalMensajes) * (totalIdiomas) * 6) + 1)

        ' Solamente se realiza la traducción si hay algo que traducir
        If losControles.Count > 0 Then
            ' Se lee el contenido del formulario
            Dim elLector As StreamReader
            elLector = New System.IO.StreamReader(eRutaFicheroEntrada, System.Text.Encoding.UTF8)
            Dim elFicheroDesignerCompleto As String = elLector.ReadToEnd
            elLector.Close()

            ' Se crean los ficheros HTML para la traducción de los distintos idiomas
            Dim RutaBase As String = eRutaTraducciones
            Dim NombreFicheroIdiomaEntrada As String = RutaBase & cIdioma.ObtenerCodigo(eLenguajeEntrada.Codigo) & ".html"
            If IO.File.Exists(NombreFicheroIdiomaEntrada) Then IO.File.Delete(NombreFicheroIdiomaEntrada)
            Dim elEscritor As New StreamWriter(NombreFicheroIdiomaEntrada, False, System.Text.Encoding.UTF8)
            elEscritor.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=utf-8"">")
            elEscritor.WriteLine("<table border=1>")

            ' A medida que se detectan controles se van añadiendo a la lista de los nombres de los controles
            ' y el texto original, siempre y cuando este no se encuentre ya en la versión antigua de la
            ' traducción con el mismo texto
            Dim DiccionarioTraducciones As New Dictionary(Of enmLenguajesCodigos, List(Of cTraduccion))
            For Each UnIdioma As cIdioma In eLenguajesSalida
                Try
                    DiccionarioTraducciones.Add(UnIdioma.Id, New List(Of cTraduccion))
                    If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)
                Catch ex As Exception
                End Try
            Next

            ' Controla el numero de elementos que se están traduciendo y si se
            ' encontró el propio formulario
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
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_l1", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".TextLine2 = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_l2", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".Text = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".Values.Text = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".ExtraText = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_extraText", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".ToolTipBody = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_toolTipBody", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".ToolTipTitle = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_toolTipTitle", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".ToolTipText = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_tooltiptext", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Abort = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Abort", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Cancel = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Cancel", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Close = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Close", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Ignore = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Ignore", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.No = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_No", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.OK = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_OK", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Retry = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Retry", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Today = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Today", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
                If seAnhadio Then yaAnhadido = True

                PatronBusqueda = ".GlobalStrings.Yes = "
                seAnhadio = AnhadirControl(elFicheroDesignerCompleto, S, PatronBusqueda, "_GlobalStrings_Yes", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, uniqueName, eBarraProgreso)
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
                AnhadirControl(elFicheroDesignerCompleto, elPar, ".Text = ", "_Form_Text", eLenguajesSalida, elEscritor, eIgnorarHTMLSubida, eMensajes, elIndice, NombreFormulario, DiccionarioTraducciones, traduccionesAntiguas, "", eBarraProgreso)
            End If

            For Each S As KeyValuePair(Of String, String) In losMSGBOX
                If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)
                elEscritor.Write("<tr>")
                elEscritor.Write("<td>" & elIndice & "</td>")
                If eIgnorarHTMLSubida Then
                    elEscritor.Write("<td>" & S.Value & "</td>")
                Else
                    elEscritor.Write("<td>" & Web.HTML.UTF2HTML(S.Value) & "</td>")
                End If
                elEscritor.WriteLine("</tr>")

                escribirMensaje(eMensajes, "[" & S.Key & "] <" & S.Value & ">")

                ' Se añadio el row a la tabla, por lo que se añade a la lista de controles coincidiendo con el índice
                For Each unIdioma As cIdioma In eLenguajesSalida
                    Dim LaTraduccion As New cTraduccion With {
                        .Indice = elIndice,
                        .NombreControl = NombreFormulario & "." & S.Key,
                        .Original = S.Value,
                        .Traduccion = ""
                }
                    DiccionarioTraducciones(unIdioma.Id).Add(LaTraduccion)
                    If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)
                Next
                elIndice += 1
            Next

            elEscritor.WriteLine("</table>")
            elEscritor.Close()

            escribirMensaje(eMensajes, "Subiendo fichero al FTP...")
            Dim NombreFicheroServidor As String = Aleatorios.CadenaAleatoria(8, True) & ".html"
            Dim ErrorSubida As Boolean = False
            Dim ContadorIntentos As Integer = 0
            Do
                escribirMensaje(eMensajes, "Preparando archivo HTML para subir al servidor FTP (" & ContadorIntentos & "/10)...")
                System.Threading.Thread.Sleep(500)
                Try
                    My.Computer.Network.UploadFile(NombreFicheroIdiomaEntrada, ConfiguracionFTP.Servidor & ConfiguracionFTP.Ruta & NombreFicheroServidor, ConfiguracionFTP.Usuario, ConfiguracionFTP.Clave, True, 2500)
                    ErrorSubida = False
                Catch ex As Exception
                    ErrorSubida = True
                End Try
                ContadorIntentos += 1
            Loop While (ContadorIntentos < 10) And ErrorSubida

            ' Una vez que se ha subido el fichero al servidor, se recorre cada uno de los lenguaje sde salida
            ' pora completar los diccionarios con las traducciones que realiza el parseador
            Dim ww As Web.Parser.HTMLPage = Nothing
            For Each UnIdioma As cIdioma In eLenguajesSalida
                Dim URI As String = ""
                escribirMensaje(eMensajes, "Realizando las traducciones del formulario/control " & NombreFormulario & " de " & cIdioma.ObtenerCodigoCorto(eLenguajeEntrada.Id) & " a " & cIdioma.ObtenerCodigoCorto(UnIdioma.Id) & "...")
                Dim url_Original As String = ConfiguracionFTP.URLBase & NombreFicheroServidor

                URI = eMotorTraduccion.obtenerURL(UnIdioma, url_Original)
                iSleepTime = eMotorTraduccion.SleepTime

                ww = New Web.Parser.HTMLPage()
                ww.LoadSource(URI)

                Dim Limpio As String = ""
                If ww.Body.Length > 0 Then
                    Dim Lineas() As String = ww.Body.Split(Chr(10))

                    For Each UnaLinea As String In Lineas
                        If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)
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

                                DiccionarioTraducciones(UnIdioma.Id)(IndiceDiccionario).Traduccion = Traduccion
                            Catch ex As Exception

                            End Try
                        End If
                    Next
                End If

                ' Entre traducción y traducción se espera un tiempo prudencial
                ' para evitar bloqueos por abuso en el uso del sistema
                escribirMensaje(eMensajes, "Esperando " & iSleepTime & " milisegundos para evitar bloqueo por abuso del servicio...")
                System.Threading.Thread.Sleep(iSleepTime)
            Next

            Dim ElUltimo As Traductor.enmLenguajesCodigos = eLenguajeEntrada.Id
            For Each UnIdioma As cIdioma In eLenguajesSalida
                If UnIdioma.Codigo <> eLenguajeEntrada.Codigo Then
                    RutaBase = eRutaTraducciones
                    Dim NombreFicheroSalida As String = RutaBase & UnIdioma.Codigo & ".po"
                    Dim elEscritorPO As New StreamWriter(NombreFicheroSalida, True, System.Text.Encoding.UTF8)

                    For Each UnaEntrada As cTraduccion In DiccionarioTraducciones(UnIdioma.Id)
                        If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)


                        ' Se comprueba si la traducción ya existía en la versión antigua y esta sigue siendo la misma, de
                        ' ser así, esta se ignora
                        Dim IndiceCabecera As Integer = traduccionesAntiguas(UnIdioma.Codigo).IndexOf("#: " & UnaEntrada.NombreControl)
                        If IndiceCabecera > 0 Then
                            Dim IndiceCuerpo As Integer = traduccionesAntiguas(UnIdioma.Codigo).IndexOf("msgid """ & UnaEntrada.Original & """", IndiceCabecera)
                            If IndiceCuerpo > 0 Then
                                Dim inicioMensajeAntiguo As Integer = traduccionesAntiguas(UnIdioma.Codigo).IndexOf("msgstr ", IndiceCuerpo) + 8
                                Dim finalMensajeAntiguo As Integer = traduccionesAntiguas(UnIdioma.Codigo).IndexOf(Chr(10), inicioMensajeAntiguo) - 1
                                UnaEntrada.Traduccion = traduccionesAntiguas(UnIdioma.Codigo).Substring(inicioMensajeAntiguo, finalMensajeAntiguo - (inicioMensajeAntiguo + 1)).Trim
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
                    ElUltimo = UnIdioma.Id
                End If
            Next

            ' Finalmente se añade el archivo del idioma original con las traducciones con los mismos textos
            RutaBase = eRutaTraducciones
            Dim NombreFicheroSalidaOriginal As String = RutaBase & eLenguajeEntrada.Codigo & ".po"
            Dim elEscritorPOOriginal As New StreamWriter(NombreFicheroSalidaOriginal, True, System.Text.Encoding.UTF8)

            For Each UnaEntrada As cTraduccion In DiccionarioTraducciones(ElUltimo)
                If eBarraProgreso IsNot Nothing Then WinForms.ProgressBar.AumentarBarra(eBarraProgreso)

                elEscritorPOOriginal.WriteLine("#: " & UnaEntrada.NombreControl)
                elEscritorPOOriginal.WriteLine("msgid """ & Web.HTML.ANSI2UTF8(UnaEntrada.Original) & """")
                elEscritorPOOriginal.WriteLine("msgstr """ & Web.HTML.ANSI2UTF8(UnaEntrada.Original) & """")
                elEscritorPOOriginal.WriteLine()
            Next

            elEscritorPOOriginal.Close()
        End If

        Return True
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
#End Region

#Region " TRADUCCION OBJETOS "
    Public Function obtenerMensaje(ByVal eVentana As Object, _
                                   ByVal eIdioma As cIdioma, _
                                   ByVal eIndice As Long) As String
        Dim ParaDevolver As String = ""

        ' Primero se va a obtener el mensaje en el idioma original, para que en el caso
        ' de no poder localizar la traducción, utilizar el original
        If Objetos.tienePropiedad(eVentana, "theMessages") Then
            Try
                ParaDevolver = eVentana.theMessages(eIndice)
            Catch ex As Exception
            End Try
        End If

        ' Se configura el idioma
        Me.IdiomaUso = eIdioma

        Dim NombreContenedor As String = "#: "
        NombreContenedor &= CType(eVentana, Form).Name & "._" & eIndice
        Dim ParaDevolverTraduciro As String = ObtenerTraduccion(NombreContenedor)
        If ParaDevolverTraduciro <> "" Then
            Return ParaDevolverTraduciro
        Else
            Return ParaDevolver
        End If
    End Function


    Private Function ObtenerTraduccion(ByVal eBusqueda As String) As String
        Dim ParaDevolver As String = ""

        ' Se obliga a buscar la cadena completa añadiendo un final de linea a la búsqueda
        If Not eBusqueda.EndsWith(Chr(13)) Then eBusqueda &= Chr(13)

        Try
            If iContenidoFichero <> "" Then
                Dim PosIni As Integer = iContenidoFichero.IndexOf(eBusqueda)
                ' Se busca el nombre del bloque, si este se encuentra, la siguiente aparición a partir de
                ' este msgstr será la traducción, por lo que se obitne el texto entre las comillas como la traducción
                If PosIni > 0 Then
                    Dim PosTrad As Integer = iContenidoFichero.IndexOf("msgstr", PosIni)
                    If PosTrad > 0 Then
                        Dim PosFin As Long = iContenidoFichero.IndexOf(vbLf, PosTrad)
                        Dim lineaTraduccion As String = iContenidoFichero.Substring(PosTrad, PosFin - PosTrad)
                        Dim lasPartes() As String = lineaTraduccion.Split(""""c)
                        If lasPartes.Length = 3 Then
                            ParaDevolver = Web.HTML.ANSI2UTF8(lasPartes(1)).Trim
                        Else
                            ParaDevolver = ""
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

        Return ParaDevolver.Trim
    End Function

    ''' <summary>
    ''' Realiza la traducción del objeto que se le pasa como parámetro al idioma
    ''' que se le pasa como parámetro
    ''' </summary>
    Public Sub traducirObjetos(ByVal eObjetos As Object, _
                               ByVal eIdioma As cIdioma, _
                               ByVal eFormularioPadre As String)

        ' Controla si se debe realizar la traducción del formulario
        Dim SeTraduce As Boolean = True
        If TypeOf (eObjetos) Is Form Or TypeOf (eObjetos) Is ComponentFactory.Krypton.Toolkit.KryptonForm Then
            If Objetos.tienePropiedad(eObjetos, "translateThis") Then
                SeTraduce = Objetos.ObtenerValorPropiedad(eObjetos, "translateThis")
            End If
        End If
        If Not SeTraduce Then Exit Sub

        Me.IdiomaUso = eIdioma
        ' Si no se pudiera obtener la traducción, se deja el texto original
        Dim laTraduccion As String = ""
        Dim elTooltip As String = ""

        Dim NombreContenedor As String = "#: "

        If TypeOf (eObjetos) Is ComponentFactory.Krypton.Toolkit.KryptonForm Then
            Try
                NombreContenedor &= CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Name & "." & CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Name & "_Form_Text"
                laTraduccion = ObtenerTraduccion(NombreContenedor)
                If Not String.IsNullOrEmpty(laTraduccion) Then CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Text = laTraduccion
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
            End Try

            Try
                traducirObjetos(CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Controls, eIdioma, CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Name)
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
            End Try

            Try
                If Objetos.tienePropiedad(eObjetos, "losComponentes") Then traducirObjetos(CType(eObjetos, Object).losComponentes, eIdioma, CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Name)
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
            End Try

        ElseIf TypeOf (eObjetos) Is Form Then
            Try
                NombreContenedor &= CType(eObjetos, Form).Name & "." & CType(eObjetos, Form).Name & "_Form_Text"
                laTraduccion = ObtenerTraduccion(NombreContenedor)
                If Not String.IsNullOrEmpty(laTraduccion) Then CType(eObjetos, Form).Text = laTraduccion
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
            End Try

            Try
                traducirObjetos(CType(eObjetos, Form).Controls, eIdioma, CType(eObjetos, Form).Name)
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
            End Try

            Try
                If Objetos.tienePropiedad(eObjetos, "losComponentes") Then traducirObjetos(CType(eObjetos, Object).losComponentes, eIdioma, CType(eObjetos, Form).Name)
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
            End Try
        ElseIf TypeOf (eObjetos) Is UserControl Then
            Try
                NombreContenedor &= CType(eObjetos, UserControl).Name & "." & CType(eObjetos, UserControl).Name & "_Form_Text"
                laTraduccion = ObtenerTraduccion(NombreContenedor)
                If Not String.IsNullOrEmpty(laTraduccion) Then CType(eObjetos, UserControl).Text = laTraduccion
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
            End Try

            Try
                traducirObjetos(CType(eObjetos, UserControl).Controls, eIdioma, CType(eObjetos, UserControl).Name)
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
            End Try

            Try
                If Objetos.tienePropiedad(eObjetos, "losComponentes") Then traducirObjetos(CType(eObjetos, Object).losComponentes, eIdioma, CType(eObjetos, UserControl).Name)
            Catch ex As Exception
                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
            End Try
        Else
            If eObjetos IsNot Nothing Then
                Try
                    For Each UnControl As Object In eObjetos
                        Try
                            ' Se descartan las traducciones de los objetos que no se traducen
                            If TypeOf (UnControl) Is PictureBox OrElse TypeOf (UnControl) Is ImageList Then
                                Continue For
                            End If


                            If TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbon Then
                                NombreContenedor = "#: frmPrincipal"

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbon).RibbonTabs, eIdioma, "frmPrincipal")
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonManager Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Abort"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Abort = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Cancel"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Cancel = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Close"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Close = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Ignore"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Ignore = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_No"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.No = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_OK"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.OK = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Retry"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Retry = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Today"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Today = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Yes"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Yes = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbonTab Then
                                Try
                                    NombreContenedor = "#: frmPrincipal"
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonTab).Tag
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonTab).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonTab).Groups, eIdioma, "frmPrincipal")
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup Then
                                Try
                                    NombreContenedor = "#: frmPrincipal"
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).Tag & "_l1"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine1 = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: frmPrincipal"
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).Tag & "_l2"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine2 = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).Items, eIdioma, "frmPrincipal")
                                Catch ex As Exception
                                End Try

                                Try
                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine1 = "Group" Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine1 = " "
                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine2 = "Group" Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine2 = " "
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple Then
                                Try
                                    NombreContenedor = "#: frmPrincipal"
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple).Items, eIdioma, "frmPrincipal")
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton Then
                                Try
                                    NombreContenedor = "#: frmPrincipal"
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).Tag & "_l1"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine1 = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: frmPrincipal"
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).Tag & "_l2"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine2 = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                                Try
                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine1 = "Button" Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine1 = " "
                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine2 = "Button" Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine2 = " "
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).ContextMenuStrip IsNot Nothing Then
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).ContextMenuStrip.Items, eIdioma, "frmPrincipal")
                                    End If
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonWrapLabel Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonWrapLabel).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonWrapLabel).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonLabel Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonLabel).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonLabel).Values.Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonTextBox Then
                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonTextBox).ButtonSpecs, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonComboBox Then
                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonComboBox).ButtonSpecs, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker Then
                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker).ButtonSpecs, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonButton Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonButton).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonButton).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonCheckBox Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonCheckBox).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonCheckBox).Values.Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonRadioButton Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonRadioButton).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonRadioButton).Values.Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonGroupBox Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroupBox).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroupBox).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroupBox).Panel.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroupBox).Panel.Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonGroup Then
                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroup).Panel.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroup).Panel.Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try


                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonPanel Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonPanel).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonPanel).Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try


                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup).Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try




                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonSplitContainer Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Name
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Panel1.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Panel1.Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Panel2.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Panel2.Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try


                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Docking.KryptonDockableNavigator Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Docking.KryptonDockableNavigator).Pages, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Docking.KryptonDockableNavigator).Pages, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Navigator.KryptonNavigator Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonNavigator).Pages, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonNavigator).Pages, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try


                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Navigator.KryptonPage Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonPage).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonPage).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonPage).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonPage).Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try

                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.ButtonSpecAny Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).UniqueName
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).UniqueName & "_extraText"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).ExtraText = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).UniqueName & "_toolTipBody"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).ToolTipBody = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre & "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).UniqueName & "_toolTipTitle"
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).ToolTipTitle = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.TabPage Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.TabPage).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.TabPage).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.TabPage).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.TabPage).Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try

                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.TabControl Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.TabControl).TabPages, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.TabControl).TabPages, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try



                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.Label Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.Label).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.Label).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.LinkLabel Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.LinkLabel).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.LinkLabel).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.Button Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.Button).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.Button).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.CheckBox Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.CheckBox).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.CheckBox).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.RadioButton Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.RadioButton).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.RadioButton).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.GroupBox Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.GroupBox).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.GroupBox).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.GroupBox).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.GroupBox).Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try



                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.CheckedListBox Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, CheckedListBox).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.CheckedListBox).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.CheckedListBox).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.CheckedListBox).Items, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.CheckedListBox).Items, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try



                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.Panel Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.Panel).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.Panel).Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.SplitContainer Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.SplitContainer).Panel1.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.SplitContainer).Panel1.Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.SplitContainer).Panel2.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.SplitContainer).Panel2.Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.FlowLayoutPanel Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.FlowLayoutPanel).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.FlowLayoutPanel).Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try



                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripMenuItem Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripMenuItem).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripMenuItem).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripMenuItem).Name & "_tooltiptext"
                                    elTooltip = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripMenuItem).ToolTipText = elTooltip
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStripMenuItem).DropDownItems, eIdioma, eFormularioPadre)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripButton Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripButton).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripButton).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripButton).Name & "_tooltiptext"
                                    elTooltip = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripButton).ToolTipText = elTooltip
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripTextBox Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripTextBox).Name & "_tooltiptext"
                                    elTooltip = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripTextBox).ToolTipText = elTooltip
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripSplitButton Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripSplitButton).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripSplitButton).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripSplitButton).Name & "_tooltiptext"
                                    elTooltip = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripSplitButton).ToolTipText = elTooltip
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStripSplitButton).DropDownItems, eIdioma, eFormularioPadre)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripDropDownButton Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).Name & "_tooltiptext"
                                    elTooltip = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).ToolTipText = elTooltip
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).DropDownItems, eIdioma, eFormularioPadre)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripDropDownItem Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripDropDownItem).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripDropDownItem).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripStatusLabel Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripStatusLabel).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripStatusLabel).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripLabel Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripLabel).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripLabel).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripLabel).Name & "_tooltiptext"
                                    elTooltip = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripLabel).ToolTipText = elTooltip
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try




                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripComboBox Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripComboBox).Name & "_tooltiptext"
                                    elTooltip = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripComboBox).ToolTipText = elTooltip
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try


                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ContextMenuStrip Then
                                Try
                                    NombreContenedor = "#: " & eFormularioPadre
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ContextMenuStrip).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ContextMenuStrip).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ContextMenuStrip).Items, eIdioma, eFormularioPadre)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.ContextMenuStrip).Items, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try



                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.MenuStrip Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.MenuStrip).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.MenuStrip).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.MenuStrip).Items, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.MenuStrip).Items, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try



                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStrip Then
                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStrip).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStrip).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStrip).Items, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStrip).Items, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try



                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.StatusStrip Then

                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.StatusStrip).Name
                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.StatusStrip).Text = laTraduccion
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.StatusStrip).Items, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.StatusStrip).Items, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
                                    End Try
                                End Try



                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.TableLayoutPanel Then

                                Try
                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                End Try

                                Try
                                    traducirObjetos(CType(UnControl, System.Windows.Forms.TableLayoutPanel).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
                                Catch ex As Exception
                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
                                    Try
                                        traducirObjetos(CType(UnControl, System.Windows.Forms.TableLayoutPanel).Controls, eIdioma, eFormularioPadre)
                                    Catch ex2 As Exception
                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))

                                    End Try
                                End Try

                            End If
                        Catch ex As Exception
                            If Log._LOG_ACTIVO Then Log.escribirLog("Error sin capturar Traductor - Nivel 2 -", ex, New StackTrace(0, True))
                        End Try
                    Next
                Catch ex As Exception
                    If Log._LOG_ACTIVO Then Log.escribirLog("Error sin capturar Traductor - Nivel 1 -", ex, New StackTrace(0, True))
                End Try
            End If
        End If
    End Sub
#End Region

#Region " DESARROLLO "
    ''' <summary>
    ''' Se encarga de localizar todas las versiones que ya hay del traductor para configurar de forma automática
    ''' la siguiente versión. En el momento de realizar la traducción, los archivos originales se copiarán
    ''' con el nombre de esta versión y se crearán unos nuevos utilizando la última como base de traducción
    ''' </summary>
    Public Shared Sub cargarVersionTraduccion(ByVal eRutaProyecto As String, _
                                              ByRef eVersionSiguiente As Object)

        Dim RutaProyecto As String = Ficheros.extraerRutaFichero(eRutaProyecto)
        Dim RutaTraducciones As String = RutaProyecto & "\Languages\" & Criptografia.EncriptarEnMD5(obtenerNombreEnsamblado(eRutaProyecto))

        eVersionSiguiente.Text = "1"

        If IO.Directory.Exists(RutaTraducciones) Then
            Dim listaVersiones As New List(Of Long)
            Dim versionMaxima As Long = 0

            For Each unFichero As String In My.Computer.FileSystem.GetFiles(RutaTraducciones)
                Dim nombreFichero As String = Ficheros.extraerNombreFicheroSinExtension(unFichero)
                If nombreFichero.Trim <> "" AndAlso nombreFichero.Contains("_") Then
                    Dim laVersion As Long = nombreFichero.Split(".")(0).Split("_")(1)
                    If versionMaxima < laVersion Then versionMaxima = laVersion
                    If Not listaVersiones.Contains(laVersion) Then listaVersiones.Add(laVersion)
                End If
            Next

            eVersionSiguiente.Text = (versionMaxima + 1)
        Else
            System.IO.Directory.CreateDirectory(RutaTraducciones)
        End If
    End Sub

    Public Shared Function obtenerRutaTraducciones(ByVal eRutaProyecto As String) As String
        Dim RutaProyecto As String = Ficheros.extraerRutaFichero(eRutaProyecto)
        Dim RutaTraducciones As String = RutaProyecto & "\Languages\" & Criptografia.EncriptarEnMD5(obtenerNombreEnsamblado(eRutaProyecto))

        Return RutaTraducciones
    End Function

    ''' <summary>
    ''' Obtiene el nombre del ensamblado a traducir
    ''' </summary>
    Public Shared Function obtenerNombreEnsamblado(ByVal eRutaProyecto As String) As String
        Dim RutaProyecto As String = Ficheros.extraerRutaFichero(eRutaProyecto)

        If System.IO.File.Exists(eRutaProyecto) Then
            Dim dsSupport As New DataSet
            dsSupport.ReadXml(eRutaProyecto)

            For Each T As DataTable In dsSupport.Tables
                If T.TableName = "PropertyGroup" Then
                    If T.TableName.Trim <> "" Then System.Diagnostics.Debug.WriteLine(T.TableName)
                    For Each D As DataColumn In T.Columns
                        If D.ColumnName.Trim = "AssemblyName" Then
                            If D.ColumnName.Trim <> "" Then System.Diagnostics.Debug.WriteLine(vbTab & D.ColumnName)
                            For Each R As DataRow In T.Rows
                                If R.Item(D).ToString.Trim <> "" Then System.Diagnostics.Debug.WriteLine(vbTab & vbTab & R.Item(D).ToString)
                                Dim elValor As String = R.Item(D).ToString
                                Return elValor
                            Next
                        End If
                    Next
                End If
            Next
        End If

        Return ""
    End Function


    ''' <summary>
    ''' Obtiene un listado con todos los Formularios que componen el proyecto seleccionado
    ''' </summary>
    ''' <returns>Listado de formularios</returns>
    ''' <remarks></remarks>
    Public Shared Function obtenerFormulariosProyecto(ByVal eRutaProyecto As String, _
                                                      Optional ByVal eObjetoCarga As Object = Nothing) As List(Of String)
        ' Se trata de ir localizando todos los elementos de la Tabla que contengan el '.Desgner.vb', ya que
        ' estos serán los Formularios, descartando el Application, el Ressources y Settings.
        ' Además, tambien hay que analizar todos los módulos y Clases para realizar los cambios en las constantes
        ' de texto que pudieran existir

        Dim arrayFormularios As New List(Of String)
        If eObjetoCarga IsNot Nothing Then eObjetoCarga.Items.Clear()

        Dim RutaProyecto As String = Ficheros.extraerRutaFichero(eRutaProyecto)

        If System.IO.File.Exists(eRutaProyecto) Then
            Dim dsSupport As New DataSet
            dsSupport.ReadXml(eRutaProyecto)

            For Each T As DataTable In dsSupport.Tables
                If T.TableName.Trim = "Compile" Then
                    If T.TableName.Trim <> "" Then System.Diagnostics.Debug.WriteLine(T.TableName)
                    For Each D As DataColumn In T.Columns
                        If D.ColumnName.Trim = "Include" Then
                            If D.ColumnName.Trim <> "" Then System.Diagnostics.Debug.WriteLine(vbTab & D.ColumnName)
                            For Each R As DataRow In T.Rows
                                If R.Item(D).ToString.Trim <> "" Then System.Diagnostics.Debug.WriteLine(vbTab & vbTab & R.Item(D).ToString)
                                Dim elValor As String = R.Item(D).ToString.ToUpper
                                If elValor.IndexOf(".DESIGNER.VB") > 0 Then
                                    If elValor.Contains("APPLICATION.DESIGNER.VB") = False And _
                                       elValor.Contains("RESOURCES.DESIGNER.VB") = False And _
                                       elValor.Contains("SETTINGS.DESIGNER.VB") = False And _
                                       elValor.Contains("MODELOEF.DESIGNER.VB") = False Then
                                        Dim elFormulario As String = (R.Item(D)).ToString.Trim

                                        ' Dependiendo de la ruta del fichero hay que modificarla para obtener
                                        ' la ruta absoluta
                                        If elFormulario.StartsWith("\\") Or elFormulario.Substring(1, 1) = ":" Then
                                            elFormulario = elFormulario
                                        Else
                                            elFormulario = RutaProyecto & "\" & elFormulario
                                        End If

                                        arrayFormularios.Add(elFormulario)
                                        If eObjetoCarga IsNot Nothing Then eObjetoCarga.Items.Add(elFormulario)
                                    End If
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If

        Return arrayFormularios
    End Function
#End Region
End Class
