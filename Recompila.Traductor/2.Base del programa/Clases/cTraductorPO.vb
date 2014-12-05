'Imports Recompila.Helper
'Imports System.IO
'Imports System.Windows.Forms

'' ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
' ''' <summary>
' ''' Clase para trabajo con ficheros PO de traducciones
' ''' </summary>
'Public Class cTraductorPO
'#Region " CLASES INTERNAS "

'#End Region

'#Region " DECLARACIONES "
'    ''' <summary>
'    ''' Idiomas con los que va a atrabajar la aplicación
'    ''' </summary>
'    Private iIdiomas As New List(Of cIdioma)

'    ''' <summary>
'    ''' Carga en memoria de todas las posibles traducciones a partir de un idioma
'    ''' </summary>
'    Private iContenidoFichero As String

'    ''' <summary>
'    ''' Idioma al que se va a traducir el formualario (cargado en memoria)
'    ''' </summary>
'    Private iIdiomaUso As cIdioma = Nothing

'    ''' <summary>
'    ''' Tiempo de espera entre traducciones para evitar sobrecarga
'    ''' </summary>
'    Private iSleepTime As Long = 0
'#End Region

'#Region " PROPIEDADES "
'    ''' <summary>
'    ''' Idiomas cargados en el objeto
'    ''' </summary>
'    Public ReadOnly Property Idiomas As List(Of cIdioma)
'        Get
'            cargarTodos()
'            Return iIdiomas
'        End Get
'    End Property

'    Public Property Motor As cMotorTraduccion
'        Get
'            Return iMotor
'        End Get
'        Set(value As cMotorTraduccion)
'            If iMotor Is Nothing OrElse (iMotor IsNot Nothing AndAlso iMotor.Motor <> value.Motor) Then
'                iMotor = value
'                cargarTodos()
'            End If
'        End Set
'    End Property

'    ''' <summary>
'    ''' Idioma con el que se está trabajando
'    ''' </summary>
'    Public Property IdiomaUso As cIdioma
'        Get
'            Return iIdiomaUso
'        End Get
'        Set(value As cIdioma)
'            Dim SeCarga As Boolean = False
'            If value IsNot Nothing Then
'                If iIdiomaUso IsNot Nothing Then
'                    If value.codigoLocalizacion <> iIdiomaUso.codigoLocalizacion Then
'                        SeCarga = True
'                    End If
'                Else
'                    SeCarga = True
'                End If

'                If SeCarga Then
'                    Dim RutaFichero As String = Application.StartupPath & "\Languages\" & Criptografia.encriptarEnMD5(My.Application.Info.AssemblyName) & "\" & value.Codigo & ".po"
'                    If IO.File.Exists(RutaFichero) Then
'                        Dim Lector As New StreamReader(RutaFichero, System.Text.Encoding.UTF8)
'                        iContenidoFichero = Lector.ReadToEnd
'                        Lector.Close()
'                        iIdiomaUso = value
'                    End If
'                End If
'            End If
'        End Set
'    End Property
'#End Region

'#Region " METODOS IDIOMAS "
'    ''' <summary>
'    ''' Añade un nuevo lenguaje al objeto
'    ''' </summary>
'    Public Sub anhadirIdioma(ByVal eIdioma As cIdioma)
'        If Not iIdiomas.Contains(eIdioma) Then iIdiomas.Add(eIdioma)
'    End Sub

'    ''' <summary>
'    ''' Añade un nuevo lenguaje al objeto
'    ''' </summary>
'    Public Sub anhadirIdioma(ByVal eLenguaje As idiomaNombre)
'        Dim nuevoIdioma As cIdioma = cIdioma.ObtenerObjetoIdioma(eLenguaje)
'        anhadirIdioma(nuevoIdioma)
'    End Sub

'    ''' <summary>
'    ''' Elimina un idioma del objeto
'    ''' </summary>
'    Public Sub quitarIdioma(ByVal eIdioma As cIdioma)
'        If iIdiomas.Contains(eIdioma) Then iIdiomas.Remove(eIdioma)
'    End Sub

'    ''' <summary>
'    ''' Elimina un idioma del objeto
'    ''' </summary>
'    Public Sub quitarIdioma(ByVal eIdioma As idiomaNombre)
'        Dim nuevoIdioma As cIdioma = cIdioma.ObtenerObjetoIdioma(eIdioma)
'        quitarIdioma(nuevoIdioma)
'    End Sub
'#End Region

'#Region " CARGA DE IDIOMAS "
'    ''' <summary>
'    ''' Carga en la lista de lenguajes todos los lenguajes disponibles en la implementación
'    ''' de la clase
'    ''' </summary>            
'    Public Sub cargarTodos()
'        iIdiomas.Clear()

'        ' Dependiendo de la finalidad del traductor, los idiomas se cargarán
'        ' utilizando los internos (programados), o los disponibles en la carpeta de traducciones
'        If iFinalidad = enmFinalidadTraductor.CrearTraducciones Then
'            If iMotor IsNot Nothing Then
'                For Each unIdioma As cIdioma In iMotor.idiomasDisponibles
'                    anhadirIdioma(unIdioma)
'                Next
'            End If
'        ElseIf iFinalidad = enmFinalidadTraductor.UsarTraducciones Then
'            Dim rutaLenguajes As String = Application.StartupPath & "\Languages\" & Criptografia.encriptarEnMD5(My.Application.Info.AssemblyName)
'            If IO.Directory.Exists(rutaLenguajes) Then
'                For Each unLenguaje As String In My.Computer.FileSystem.GetFiles(rutaLenguajes)
'                    If IO.File.Exists(unLenguaje) AndAlso unLenguaje.ToLower.EndsWith(".po") Then
'                        Dim NombreIdioma As String = Ficheros.extraerNombreFichero(unLenguaje).Replace(".po", "")
'                        Dim elIdioma As Traductor.cIdioma = cIdioma.ObtenerObjetoIdioma(cIdioma.iso2enum(NombreIdioma))
'                        If elIdioma IsNot Nothing Then anhadirIdioma(elIdioma)
'                    End If
'                Next
'            End If

'        End If
'    End Sub
'#End Region

'#Region " MENSAJES DE ESTADO "
'    ''' <summary>
'    ''' Utilizado par amostrar mensajes e información del estado
'    ''' </summary>
'    ''' <param name="eTextBox">TextBox donde se concatenará el mensaje</param>
'    ''' <param name="eMensaje">Mensaje a concatenar</param>
'    Private Sub escribirMensaje(ByRef eTextBox As TextBox, _
'                                ByVal eMensaje As String)
'        Try
'            eTextBox.AppendText(" " & Format(Now, "HH:mm:ss") & " > " & eMensaje.Trim & vbCrLf)
'            eTextBox.Refresh()
'            Application.DoEvents()
'        Catch ex As Exception
'        End Try
'    End Sub
'#End Region

'#Region " TRADUCTOR "



'#End Region

'#Region " TRADUCCION OBJETOS "
'    Public Function obtenerMensaje(ByVal eVentana As Object, _
'                                   ByVal eIdioma As cIdioma, _
'                                   ByVal eIndice As Long) As String
'        Dim ParaDevolver As String = ""

'        ' Primero se va a obtener el mensaje en el idioma original, para que en el caso
'        ' de no poder localizar la traducción, utilizar el original
'        If Objetos.tienePropiedad(eVentana, "theMessages") Then
'            Try
'                ParaDevolver = eVentana.theMessages(eIndice)
'            Catch ex As Exception
'            End Try
'        End If

'        ' Se configura el idioma
'        Me.IdiomaUso = eIdioma

'        Dim NombreContenedor As String = "#: "
'        NombreContenedor &= CType(eVentana, Form).Name & "._" & eIndice
'        Dim ParaDevolverTraduciro As String = ObtenerTraduccion(NombreContenedor)
'        If ParaDevolverTraduciro <> "" Then
'            Return ParaDevolverTraduciro
'        Else
'            Return ParaDevolver
'        End If
'    End Function


'    Private Function ObtenerTraduccion(ByVal eBusqueda As String) As String
'        Dim ParaDevolver As String = ""

'        ' Se obliga a buscar la cadena completa añadiendo un final de linea a la búsqueda
'        If Not eBusqueda.EndsWith(Chr(13)) Then eBusqueda &= Chr(13)

'        Try
'            If iContenidoFichero <> "" Then
'                Dim PosIni As Integer = iContenidoFichero.IndexOf(eBusqueda)
'                ' Se busca el nombre del bloque, si este se encuentra, la siguiente aparición a partir de
'                ' este msgstr será la traducción, por lo que se obitne el texto entre las comillas como la traducción
'                If PosIni > 0 Then
'                    Dim PosTrad As Integer = iContenidoFichero.IndexOf("msgstr", PosIni)
'                    If PosTrad > 0 Then
'                        Dim PosFin As Long = iContenidoFichero.IndexOf(vbLf, PosTrad)
'                        Dim lineaTraduccion As String = iContenidoFichero.Substring(PosTrad, PosFin - PosTrad)
'                        Dim lasPartes() As String = lineaTraduccion.Split(""""c)
'                        If lasPartes.Length = 3 Then
'                            ParaDevolver = Web.HTML.ANSI2UTF8(lasPartes(1)).Trim
'                        Else
'                            ParaDevolver = ""
'                        End If
'                    End If
'                End If
'            End If
'        Catch ex As Exception
'        End Try

'        Return ParaDevolver.Trim
'    End Function

'    ''' <summary>
'    ''' Realiza la traducción del objeto que se le pasa como parámetro al idioma
'    ''' que se le pasa como parámetro
'    ''' </summary>
'    Public Sub traducirObjetos(ByVal eObjetos As Object, _
'                               ByVal eIdioma As cIdioma, _
'                               ByVal eFormularioPadre As String)

'        ' Controla si se debe realizar la traducción del formulario
'        Dim SeTraduce As Boolean = True
'        If TypeOf (eObjetos) Is Form Or TypeOf (eObjetos) Is ComponentFactory.Krypton.Toolkit.KryptonForm Then
'            If Objetos.tienePropiedad(eObjetos, "translateThis") Then
'                SeTraduce = Objetos.obtenerValorPropiedad(eObjetos, "translateThis")
'            End If
'        End If
'        If Not SeTraduce Then Exit Sub

'        Me.IdiomaUso = eIdioma
'        ' Si no se pudiera obtener la traducción, se deja el texto original
'        Dim laTraduccion As String = ""
'        Dim elTooltip As String = ""

'        Dim NombreContenedor As String = "#: "

'        If TypeOf (eObjetos) Is ComponentFactory.Krypton.Toolkit.KryptonForm Then
'            Try
'                NombreContenedor &= CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Name & "." & CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Name & "_Form_Text"
'                laTraduccion = ObtenerTraduccion(NombreContenedor)
'                If Not String.IsNullOrEmpty(laTraduccion) Then CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Text = laTraduccion
'            Catch ex As Exception
'                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'            End Try

'            Try
'                traducirObjetos(CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Controls, eIdioma, CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Name)
'            Catch ex As Exception
'                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'            End Try

'            Try
'                If Objetos.tienePropiedad(eObjetos, "losComponentes") Then traducirObjetos(CType(eObjetos, Object).losComponentes, eIdioma, CType(eObjetos, ComponentFactory.Krypton.Toolkit.KryptonForm).Name)
'            Catch ex As Exception
'                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'            End Try

'        ElseIf TypeOf (eObjetos) Is Form Then
'            Try
'                NombreContenedor &= CType(eObjetos, Form).Name & "." & CType(eObjetos, Form).Name & "_Form_Text"
'                laTraduccion = ObtenerTraduccion(NombreContenedor)
'                If Not String.IsNullOrEmpty(laTraduccion) Then CType(eObjetos, Form).Text = laTraduccion
'            Catch ex As Exception
'                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'            End Try

'            Try
'                traducirObjetos(CType(eObjetos, Form).Controls, eIdioma, CType(eObjetos, Form).Name)
'            Catch ex As Exception
'                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'            End Try

'            Try
'                If Objetos.tienePropiedad(eObjetos, "losComponentes") Then traducirObjetos(CType(eObjetos, Object).losComponentes, eIdioma, CType(eObjetos, Form).Name)
'            Catch ex As Exception
'                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'            End Try
'        ElseIf TypeOf (eObjetos) Is UserControl Then
'            Try
'                NombreContenedor &= CType(eObjetos, UserControl).Name & "." & CType(eObjetos, UserControl).Name & "_Form_Text"
'                laTraduccion = ObtenerTraduccion(NombreContenedor)
'                If Not String.IsNullOrEmpty(laTraduccion) Then CType(eObjetos, UserControl).Text = laTraduccion
'            Catch ex As Exception
'                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'            End Try

'            Try
'                traducirObjetos(CType(eObjetos, UserControl).Controls, eIdioma, CType(eObjetos, UserControl).Name)
'            Catch ex As Exception
'                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'            End Try

'            Try
'                If Objetos.tienePropiedad(eObjetos, "losComponentes") Then traducirObjetos(CType(eObjetos, Object).losComponentes, eIdioma, CType(eObjetos, UserControl).Name)
'            Catch ex As Exception
'                If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'            End Try
'        Else
'            If eObjetos IsNot Nothing Then
'                Try
'                    For Each UnControl As Object In eObjetos
'                        Try
'                            ' Se descartan las traducciones de los objetos que no se traducen
'                            If TypeOf (UnControl) Is PictureBox OrElse TypeOf (UnControl) Is ImageList Then
'                                Continue For
'                            End If


'                            If TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbon Then
'                                NombreContenedor = "#: frmPrincipal"

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbon).RibbonTabs, eIdioma, "frmPrincipal")
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonManager Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Abort"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Abort = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Cancel"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Cancel = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Close"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Close = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Ignore"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Ignore = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_No"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.No = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_OK"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.OK = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Retry"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Retry = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Today"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Today = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "._KManager_GlobalStrings_Yes"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonManager).GlobalStrings.Yes = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbonTab Then
'                                Try
'                                    NombreContenedor = "#: frmPrincipal"
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonTab).Tag
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonTab).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonTab).Groups, eIdioma, "frmPrincipal")
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup Then
'                                Try
'                                    NombreContenedor = "#: frmPrincipal"
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).Tag & "_l1"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine1 = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: frmPrincipal"
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).Tag & "_l2"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine2 = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).Items, eIdioma, "frmPrincipal")
'                                Catch ex As Exception
'                                End Try

'                                Try
'                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine1 = "Group" Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine1 = " "
'                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine2 = "Group" Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup).TextLine2 = " "
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple Then
'                                Try
'                                    NombreContenedor = "#: frmPrincipal"
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple).Items, eIdioma, "frmPrincipal")
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton Then
'                                Try
'                                    NombreContenedor = "#: frmPrincipal"
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).Tag & "_l1"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine1 = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: frmPrincipal"
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).Tag & "_l2"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine2 = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                                Try
'                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine1 = "Button" Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine1 = " "
'                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine2 = "Button" Then CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).TextLine2 = " "
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    If CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).ContextMenuStrip IsNot Nothing Then
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton).ContextMenuStrip.Items, eIdioma, "frmPrincipal")
'                                    End If
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonWrapLabel Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonWrapLabel).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonWrapLabel).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonLabel Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonLabel).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonLabel).Values.Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonTextBox Then
'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonTextBox).ButtonSpecs, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonComboBox Then
'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonComboBox).ButtonSpecs, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker Then
'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker).ButtonSpecs, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonButton Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonButton).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonButton).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonCheckBox Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonCheckBox).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonCheckBox).Values.Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonRadioButton Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonRadioButton).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonRadioButton).Values.Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonGroupBox Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroupBox).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroupBox).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroupBox).Panel.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroupBox).Panel.Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonGroup Then
'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroup).Panel.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonGroup).Panel.Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try


'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonPanel Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonPanel).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonPanel).Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try


'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup).Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try




'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.KryptonSplitContainer Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Name
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Panel1.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Panel1.Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Panel2.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Toolkit.KryptonSplitContainer).Panel2.Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try


'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Docking.KryptonDockableNavigator Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Docking.KryptonDockableNavigator).Pages, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Docking.KryptonDockableNavigator).Pages, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Navigator.KryptonNavigator Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonNavigator).Pages, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonNavigator).Pages, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try


'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Navigator.KryptonPage Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonPage).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonPage).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonPage).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, ComponentFactory.Krypton.Navigator.KryptonPage).Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try

'                            ElseIf TypeOf (UnControl) Is ComponentFactory.Krypton.Toolkit.ButtonSpecAny Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).UniqueName
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).UniqueName & "_extraText"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).ExtraText = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).UniqueName & "_toolTipBody"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).ToolTipBody = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre & "." & CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).UniqueName & "_toolTipTitle"
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, ComponentFactory.Krypton.Toolkit.ButtonSpecAny).ToolTipTitle = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.TabPage Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.TabPage).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.TabPage).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.TabPage).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.TabPage).Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try

'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.TabControl Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.TabControl).TabPages, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.TabControl).TabPages, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try



'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.Label Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.Label).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.Label).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.LinkLabel Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.LinkLabel).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.LinkLabel).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.Button Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.Button).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.Button).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.CheckBox Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.CheckBox).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.CheckBox).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.RadioButton Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.RadioButton).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.RadioButton).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.GroupBox Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.GroupBox).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.GroupBox).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.GroupBox).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.GroupBox).Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try



'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.CheckedListBox Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, CheckedListBox).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.CheckedListBox).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.CheckedListBox).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.CheckedListBox).Items, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.CheckedListBox).Items, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try



'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.Panel Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.Panel).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.Panel).Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.SplitContainer Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.SplitContainer).Panel1.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.SplitContainer).Panel1.Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.SplitContainer).Panel2.Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.SplitContainer).Panel2.Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.FlowLayoutPanel Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.FlowLayoutPanel).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.FlowLayoutPanel).Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try



'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripMenuItem Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripMenuItem).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripMenuItem).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripMenuItem).Name & "_tooltiptext"
'                                    elTooltip = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripMenuItem).ToolTipText = elTooltip
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStripMenuItem).DropDownItems, eIdioma, eFormularioPadre)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripButton Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripButton).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripButton).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripButton).Name & "_tooltiptext"
'                                    elTooltip = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripButton).ToolTipText = elTooltip
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripTextBox Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripTextBox).Name & "_tooltiptext"
'                                    elTooltip = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripTextBox).ToolTipText = elTooltip
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripSplitButton Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripSplitButton).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripSplitButton).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripSplitButton).Name & "_tooltiptext"
'                                    elTooltip = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripSplitButton).ToolTipText = elTooltip
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStripSplitButton).DropDownItems, eIdioma, eFormularioPadre)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripDropDownButton Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).Name & "_tooltiptext"
'                                    elTooltip = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).ToolTipText = elTooltip
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStripDropDownButton).DropDownItems, eIdioma, eFormularioPadre)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripDropDownItem Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripDropDownItem).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripDropDownItem).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripStatusLabel Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripStatusLabel).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripStatusLabel).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripLabel Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripLabel).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStripLabel).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripLabel).Name & "_tooltiptext"
'                                    elTooltip = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripLabel).ToolTipText = elTooltip
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try




'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStripComboBox Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStripComboBox).Name & "_tooltiptext"
'                                    elTooltip = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(elTooltip) Then CType(UnControl, System.Windows.Forms.ToolStripComboBox).ToolTipText = elTooltip
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try


'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ContextMenuStrip Then
'                                Try
'                                    NombreContenedor = "#: " & eFormularioPadre
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ContextMenuStrip).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ContextMenuStrip).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ContextMenuStrip).Items, eIdioma, eFormularioPadre)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.ContextMenuStrip).Items, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try



'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.MenuStrip Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.MenuStrip).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.MenuStrip).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.MenuStrip).Items, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.MenuStrip).Items, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try



'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.ToolStrip Then
'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.ToolStrip).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.ToolStrip).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStrip).Items, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.ToolStrip).Items, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try



'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.StatusStrip Then

'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                    NombreContenedor &= "." & CType(UnControl, System.Windows.Forms.StatusStrip).Name
'                                    laTraduccion = ObtenerTraduccion(NombreContenedor)
'                                    If Not String.IsNullOrEmpty(laTraduccion) Then CType(UnControl, System.Windows.Forms.StatusStrip).Text = laTraduccion
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.StatusStrip).Items, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.StatusStrip).Items, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))
'                                    End Try
'                                End Try



'                            ElseIf TypeOf (UnControl) Is System.Windows.Forms.TableLayoutPanel Then

'                                Try
'                                    NombreContenedor = "#: " & CType(UnControl, Control).FindForm.Name
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                End Try

'                                Try
'                                    traducirObjetos(CType(UnControl, System.Windows.Forms.TableLayoutPanel).Controls, eIdioma, CType(UnControl, Control).FindForm.Name)
'                                Catch ex As Exception
'                                    If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex, New StackTrace(0, True))
'                                    Try
'                                        traducirObjetos(CType(UnControl, System.Windows.Forms.TableLayoutPanel).Controls, eIdioma, eFormularioPadre)
'                                    Catch ex2 As Exception
'                                        If Log._LOG_ACTIVO Then Log.escribirLog("Error traductor!", ex2, New StackTrace(0, True))

'                                    End Try
'                                End Try

'                            End If
'                        Catch ex As Exception
'                            If Log._LOG_ACTIVO Then Log.escribirLog("Error sin capturar Traductor - Nivel 2 -", ex, New StackTrace(0, True))
'                        End Try
'                    Next
'                Catch ex As Exception
'                    If Log._LOG_ACTIVO Then Log.escribirLog("Error sin capturar Traductor - Nivel 1 -", ex, New StackTrace(0, True))
'                End Try
'            End If
'        End If
'    End Sub
'#End Region
'End Class
