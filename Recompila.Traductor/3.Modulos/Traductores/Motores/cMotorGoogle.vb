Imports Recompila.Helper
Imports System.Windows.Forms
Imports System.IO
Imports System.Text.RegularExpressions

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

#Region " EVENTOS "
    Public Event notificarMensaje(eMensaje As String) Implements IMotorTraduccion.notificarMensaje
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
    ''' <param name="eDatosConexion">Datos de acceso al servidor FTP/HTTP</param>
    ''' <param name="eIdiomaEntrada">Idioma de entrada para la traducción</param>
    ''' <param name="eIdiomaSalida">Idioma de salida para la traducción</param>
    ''' <param name="eURL">URL donde se tiene que realizar la traducción</param>
    ''' <returns>URL formateada para poder realizar la traducción</returns>
    Public Function obtenerTraducciones(ByVal eDatosConexion As cConfiguracionNetwork, _
                                        ByVal eIdiomaEntrada As cIdioma, _
                                        ByVal eIdiomaSalida As cIdioma, _
                                        ByVal eURL As String, _
                                        ByVal eTagEOF As String) As Dictionary(Of Long, String) Implements IMotorTraduccion.obtenerTraducciones
        Dim paraDevolver As New Dictionary(Of Long, String)

        ' Se crea la URL para la realización de la traducción
        Dim laUri As String = URI
        laUri = laUri.Replace("@entrada@", eIdiomaEntrada.strCodigoLocalizacion)
        laUri = laUri.Replace("@salida@", eIdiomaSalida.strCodigoLocalizacion)
        laUri = laUri.Replace("@URI@", eURL.Replace("http://", ""))

        ' Se carga la página original
        RaiseEvent notificarMensaje("@ Leyendo '" & laUri & "'...")
        Dim laPagina As New Web.cPaginaHTML(360)
        laPagina.cargarURL(laUri)

        ' Google muestra el resultado de la traducción en un iFrame y para acceder a este
        ' y poder cargarlo sin que vuelva a aparecer la cabecera del traductor de google
        ' hay que capturar el Token que utiliza para la petición
        ' Además, mientras la página no está traducida muestra un mensaje de 
        ' espera mientras se traduce, por lo que hay que esperar a que este proceso
        ' se comlete esperando a que aparezca el <b>__999__</b> en la página
        If laPagina.Body.Length > 0 Then
            Dim elHTML As String = laPagina.Body

            Dim laUriIntermedia As String = ""
            Dim indiceInicioToken As Long = elHTML.LastIndexOf("/translate_")
            If indiceInicioToken > 0 Then
                elHTML = elHTML.Substring(indiceInicioToken)
                Dim indiceFinToken As Long = elHTML.IndexOf("""")
                If indiceFinToken > 0 Then
                    laUriIntermedia = elHTML.Substring(0, indiceFinToken)
                    laUriIntermedia = laUriIntermedia.Replace("""", "").Trim.Replace("&amp;", "&").Replace("http://", "http%3A%2F%2F")

                    ' Se genera la nueva URL con el token generado para la traducción por Google
                    laUri = "http://translate.google.com/" & laUriIntermedia

                    ' No se puede acceder directamente a la página ya que hasta que esta
                    ' no es traducida google muestra un mensaje e realizando traducción, por
                    ' lo que se carga en un navegador y se espera a que el body del navegador
                    ' contenga el tag de fin
                    RaiseEvent notificarMensaje("@ Leyendo '" & laUri & "'...")
                    Dim elNavegador As New System.Windows.Forms.WebBrowser()
                    elNavegador.ScriptErrorsSuppressed = True
                    elNavegador.Navigate(laUri)

                    Dim stampInicio As DateTime = Now
                    Dim Salir As Boolean = False                    
                    Do
                        Application.DoEvents()

                        ' Se verifica si se completó la traducción
                        If (Not String.IsNullOrEmpty(elNavegador.DocumentText) AndAlso elNavegador.DocumentText.ToLower.Contains(eTagEOF)) Then Salir = True

                        ' Se verifica que no se entrara en un bucle infinito, si el proceso
                        ' de traducción tarda más de 10 segundos se sale del bucle
                        If Math.Abs(DateDiff(DateInterval.Second, Now, stampInicio)) > 30 Then Salir = True
                    Loop While Not Salir

                    ' Se copmrueba que el navegador tenga contenido y este sea válido, de ser
                    ' así, se obitnene el body
                    If elNavegador.DocumentText.ToLower.Contains(eTagEOF) Then
                        RaiseEvent notificarMensaje("@ Analizando contenido de '" & laUri & "'...")
                        Dim elBodyOriginal As String = elNavegador.DocumentText.Replace(eTagEOF, eTagEOF.ToLower)

                        ' Se cambian a mayusculas todos los TAGS que van a intervenir en
                        ' el proceso de separación de los resultados obtenidos tras la traducción
                        Dim cambiosAMayusculas As New List(Of String) From {"<span", "</span>", "<body>", "</body>", "<tbody>", "</tbody>", "<table border=", "</table>", "<td>", "</td>", "<tr>", "</tr>"}
                        For Each unCambioMayusculas As String In cambiosAMayusculas
                            elBodyOriginal = elBodyOriginal.Replace(unCambioMayusculas, unCambioMayusculas.ToUpper)
                        Next

                        Dim indiceBody As Long = elBodyOriginal.IndexOf("<BODY>")
                        If indiceBody > 0 Then elBodyOriginal = elBodyOriginal.Substring(indiceBody)
                        indiceBody = elBodyOriginal.LastIndexOf(eTagEOF)
                        If indiceBody > 0 Then elBodyOriginal = elBodyOriginal.Substring(0, indiceBody)

                        ' Google a veces mete el globo de sugerir mejor traducción, de ser así
                        ' es necesario recopmoner todoe el body ya que no se trata del HTML original                        
                        If elBodyOriginal.Contains("</SPAN>") Then
                            Dim elBodyAux As String = elBodyOriginal
                            elBodyAux = Regex.Replace(elBodyAux, "<SPAN.*?>", "")
                            elBodyAux = elBodyAux.Replace("</SPAN> <", "<")
                            elBodyAux = elBodyAux.Replace("</SPAN> ", "[|]")
                            elBodyOriginal = elBodyAux
                        End If

                        elBodyOriginal = elBodyOriginal.Replace(Chr(10), "")
                        elBodyOriginal = elBodyOriginal.Replace(Chr(13), "")
                        elBodyOriginal = elBodyOriginal.Replace(vbCrLf, "")

                        elBodyOriginal = elBodyOriginal.Replace("<TABLE BORDER=1>", vbCrLf & vbCrLf)
                        elBodyOriginal = elBodyOriginal.Replace("<TABLE BORDER=""1"">", vbCrLf & vbCrLf)
                        elBodyOriginal = elBodyOriginal.Replace("<TBODY>", vbCrLf & vbCrLf)
                        elBodyOriginal = elBodyOriginal.Replace("</TD></TR>", vbCrLf)
                        elBodyOriginal = elBodyOriginal.Replace("</TBODY>", vbCrLf & vbCrLf)
                        elBodyOriginal = elBodyOriginal.Replace("</TABLE>", vbCrLf & vbCrLf)

                        Dim lasLineas() As String = elBodyOriginal.Split(vbCrLf)
                        For Each unaLinea As String In lasLineas
                            unaLinea = unaLinea.Trim
                            If Not String.IsNullOrEmpty(unaLinea) AndAlso unaLinea.ToLower.StartsWith("<tr><td>") Then
                                Try
                                    Dim Columnas() As String = unaLinea.Replace("</td><td>", "~").Replace("</TD><TD>", "~").Split("~")
                                    Dim laColumna1 As String = Columnas(0).Trim.Replace("<tr>", "").Replace("</tr>", "").Replace("<td>", "").Replace("</td>", "").Replace("<TR>", "").Replace("</TR>", "").Replace("<TD>", "").Replace("</TD>", "").Replace("_", "").Replace("[|]", "~")
                                    Dim laColumna2 As String = Columnas(1).Trim.Replace("<tr>", "").Replace("</tr>", "").Replace("<td>", "").Replace("</td>", "").Replace("<TR>", "").Replace("</TR>", "").Replace("<TD>", "").Replace("</TD>", "").Replace("�", "").Replace("[|]", "~")

                                    Dim IndiceDiccionario As Long = -1
                                    Dim Traduccion As String = ""

                                    If laColumna1.Contains("~") Then
                                        IndiceDiccionario = Funciones.NZL(laColumna1.Split("~")(0))
                                    Else
                                        IndiceDiccionario = Funciones.NZL(laColumna1)
                                    End If
                                    If laColumna1.Contains("~") Then
                                        Traduccion = Web.HTML.HTML2UTF(laColumna2.Split("~")(1))
                                    Else
                                        Traduccion = Web.HTML.HTML2UTF(laColumna2)
                                    End If

                                    If IndiceDiccionario > 0 AndAlso Not paraDevolver.Keys.Contains(IndiceDiccionario) Then
                                        paraDevolver.Add(IndiceDiccionario, Traduccion)
                                    End If
                                Catch ex As Exception
                                    Debugger.Break()
                                End Try
                            End If
                        Next
                    Else
                        RaiseEvent notificarMensaje("! ERROR en el contenido de '" & laUri & "'...")
                    End If
                Else
                    RaiseEvent notificarMensaje("! ERROR en el contenido de '" & laUri & "'...")
                End If
            Else
                RaiseEvent notificarMensaje("! ERROR en el contenido de '" & laUri & "'...")
            End If
        Else
            RaiseEvent notificarMensaje("! ERROR al leer '" & laUri & "'...")
        End If

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
