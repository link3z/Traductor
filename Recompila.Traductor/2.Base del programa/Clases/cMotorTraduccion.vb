' ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
''' <summary>
''' Distintos objetos que se encargarán de realizar las traducciones mediante
''' parseo de resultados 
''' </summary>
Public Class cMotorTraduccion
#Region " CONSTANTES "
    ''' <summary>
    ''' URI para traducción utilizando OpenTrad
    ''' </summary>            
    Const URI_OPEN_TRAD As String = "http://opentrad.com/webservices/urlTranslate.php?marcar=&direccion=@entrada@-@salida@&inurl=http%3A%2F%2F@URI@"

    ''' <summary>
    ''' URI para traducción utilizando GoogleTranslator
    ''' </summary>            
    Const URI_GOOGLE As String = "http://translate.google.com/translate?hl=@entrada@&tl=@salida@&u=http%3A%2F%2F@URI@"

    ''' <summary>
    ''' URI para traducción utilizando online-translator
    ''' </summary>
    Const URI_ONLINE_TRANSLATOR As String = "http://www.online-translator.com/url/translation/?autolink=yes&direction=@entrada@@salida@&template=General&sourceURL=http%3a%2f%2f@URI@"

    ''' <summary>
    ''' URI para traducción utilizando InterTran
    ''' </summary>
    ''' <remarks></remarks>
    Const URI_INTERTRAN As String = "http://intertran.tranexp.com/Translate/index.shtml?from=@entrada@&to=@salida@&type=url&url=http%3A%2F%2F@URI@"


    ' ToDo: Implementar Bing Translator ver API en 
    ' http://code.msdn.microsoft.com/windowsazure/Walkthrough-Translator-in-7e0be0f7
    ' http://msdn.microsoft.com/en-us/library/hh456380.aspx
    ' http://msdn.microsoft.com/en-us/library/gg312162.aspx
    ' http://msdn.microsoft.com/es-es/library/hh454949.aspx
    ' http://blogs.msdn.com/b/translation/p/gettingstarted1.aspx
#End Region

#Region " DECLARACIONES "
    ''' <summary>
    ''' Distintos motores de traducción utilizados para las traducciones automáticas
    ''' </summary>
    Public Enum enmMotorTraducciones
        OpenTrad = 0
        Google = 1
        Bing = 2
        Online_Translator_com = 3
        InterTran = 4
    End Enum
#End Region

#Region " DECLARACIONES "
    ''' <summary>
    ''' Id del motor que se está utilizando
    ''' </summary>
    Private iMotor As enmMotorTraducciones

    ''' <summary>
    ''' URL que se utiliza para la traducción
    ''' </summary>
    Private iURL As String = ""

    ''' <summary>
    ''' Tiempo de espera entre traducciones para evitar bloqueos
    ''' </summary>
    Private iSleepTime As Long = 0
#End Region

#Region " PROPIEDADES "
    ''' <summary>
    ''' Id del motro que se está utilizando
    ''' </summary>
    Public Property Motor As enmMotorTraducciones
        Get
            Return iMotor
        End Get
        Set(value As enmMotorTraducciones)
            If value <> iMotor Then
                iMotor = value
            End If
        End Set
    End Property

    Public ReadOnly Property SleepTime As Long
        Get
            Return iSleepTime
        End Get
    End Property
#End Region

#Region " CONSTRUCTORES"
    Public Sub New(ByVal eMotor As enmMotorTraducciones)
        iMotor = eMotor
    End Sub
#End Region

#Region " METODOS "
    Public Function obtenerURL(ByVal eIdiomaSalida As cIdioma, _
                               ByVal eURL As String) As String
        If iMotor = enmMotorTraducciones.Bing Then

        ElseIf iMotor = enmMotorTraducciones.Google Then
            iURL = URI_GOOGLE.Replace("@entrada@", cIdioma.ObtenerCodigoCorto(enmLenguajesNombres.Spanish)).Replace("@salida@", cIdioma.ObtenerCodigoCorto(eIdiomaSalida.Id)).Replace("@URI@", eURL.Replace("http://", ""))
            iSleepTime = 5000
        ElseIf iMotor = enmMotorTraducciones.Online_Translator_com Then
            Dim caracterEntrada As String = "s"
            Dim caracterSalida As String = ""
            If eIdiomaSalida.Id = enmLenguajesCodigos.de_DE Then
                caracterSalida = "g"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.fr_FR Then
                caracterSalida = "f"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.en_US Then
                caracterSalida = "e"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.ru_RU Then
                caracterSalida = "r"
            End If

            iURL = URI_ONLINE_TRANSLATOR.Replace("@entrada@", caracterEntrada).Replace("@salida@", caracterSalida).Replace("@URI@", eURL.Replace("http://", ""))
            iSleepTime = 2000
        ElseIf iMotor = enmMotorTraducciones.OpenTrad Then
            iURL = URI_OPEN_TRAD.Replace("@entrada@", cIdioma.ObtenerCodigoCorto(enmLenguajesNombres.Spanish)).Replace("@salida@", cIdioma.ObtenerCodigoCorto(eIdiomaSalida.Id)).Replace("@URI@", eURL.Replace("http://", ""))
            iSleepTime = 0
        ElseIf iMotor = enmMotorTraducciones.InterTran Then
            Dim codigoSalida As String = "spa"

            If eIdiomaSalida.Id = enmLenguajesCodigos.cz_CZ Then
                codigoSalida = "che"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.en_US Then
                codigoSalida = "eng"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.bg_BG Then
                codigoSalida = "bul"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.hr_HR Then
                codigoSalida = "cro"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.da_DA Then
                codigoSalida = "dan"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.nl_NL Then
                codigoSalida = "dut"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.fi_FI Then
                codigoSalida = "fin"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.fr_FR Then
                codigoSalida = "fre"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.de_DE Then
                codigoSalida = "ger"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.es_ES Then
                codigoSalida = "spa"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.el_EL Then
                codigoSalida = "grk"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.hu_HU Then
                codigoSalida = "hun"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.it_IT Then
                codigoSalida = "ita"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.ja_JA Then
                codigoSalida = "jpn"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.pt_PT Then
                codigoSalida = "poe"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.ru_RU Then
                codigoSalida = "rus"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.ro_ro Then
                codigoSalida = "rom"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.sv_SV Then
                codigoSalida = "swe"
            ElseIf eIdiomaSalida.Id = enmLenguajesCodigos.tr_TR Then
                codigoSalida = "tur"
            End If

            iURL = URI_INTERTRAN.Replace("@entrada@", "spa").Replace("@salida@", codigoSalida).Replace("@URI@", eURL.Replace("http://", ""))
            iSleepTime = 2000
        End If

        Return iURL
    End Function

    Public Function idiomasDisponibles() As List(Of cIdioma)
        Dim paradevolver As New List(Of cIdioma)

        If iMotor = enmMotorTraducciones.Bing Then

        ElseIf iMotor = enmMotorTraducciones.Google Then

        ElseIf iMotor = enmMotorTraducciones.Online_Translator_com Then
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.German))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Spanish))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.French))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.English))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Russian))
        ElseIf iMotor = enmMotorTraducciones.OpenTrad Then
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Catalan))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.English))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Spanish))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Italian))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.French))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Galician))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Portuguese))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Romanian))
        ElseIf iMotor = enmMotorTraducciones.InterTran Then
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Czech))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.English))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Bulgarian))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Croatian))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Danish))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Dutch))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Finnish))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Spanish))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.German))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.French))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Greek))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Hungarian))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Italian))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Japanese))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Portuguese))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Russian))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Romanian))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Swedish))
            paradevolver.Add(cIdioma.ObtenerObjetoIdioma(enmLenguajesNombres.Turkish))
        End If

        Return paradevolver
    End Function
#End Region

#Region " METODOS SOBRECARGADOS "
    Public Overrides Function ToString() As String
        Return iMotor.ToString()
    End Function
#End Region
End Class