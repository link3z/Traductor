Imports System.Drawing

Public Class cIdioma
#Region " PROPIEDADES "
    Public Property Id As enmLenguajesCodigos
    Public Property Nombre As String
    Public Property Codigo As String
    Public Property Bandera As Image = Nothing
#End Region

#Region " CONSTRUCTORES "
    ''' <summary>
    ''' Constructor limpio
    ''' </summary>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' Constructor con el propio objeto
    ''' </summary>
    Public Sub New(ByVal eId As enmLenguajesCodigos)
        Dim Temp As cIdioma = ObtenerObjetoIdioma(eId)
        With Temp
            Me.Id = .Id
            Me.Codigo = .Codigo
            Me.Nombre = .Nombre
            Me.Bandera = .Bandera
        End With
    End Sub
#End Region

#Region " METODOS COMPARTIDOS "
    ''' <summary>
    ''' Obitiene un objeto que representa al idioma que se lepasa por parametro
    ''' </summary>
    Public Shared Function ObtenerObjetoIdioma(ByVal eId As enmLenguajesNombres) As cIdioma
        Dim NuevoLenguaje As New cIdioma With {
                .Id = eId,
                .Nombre = ObtenerNombre(eId),
                .Codigo = ObtenerCodigo(eId),
                .Bandera = imagenesBanderas(cIdioma.iso2enum(.Codigo))
            }
        Return NuevoLenguaje
    End Function

    Public Shared Function ObtenerCodigoCorto(ByVal eId As enmLenguajesNombres) As String
        Dim CodigoLargo As String = ObtenerCodigo(eId)
        If CodigoLargo <> "" AndAlso CodigoLargo.Contains("-") Then
            Dim Partes() As String = CodigoLargo.Split("-")
            Return Partes(0)
        Else
            Return "es"
        End If
    End Function

    Public Shared Function ObtenerCodigo(ByVal eId As enmLenguajesNombres) As String
        Select Case eId
            Case enmLenguajesNombres.English
                Return "en-US"

            Case enmLenguajesNombres.Spanish
                Return "es-ES"

            Case enmLenguajesNombres.Galician
                Return "gl-GL"

            Case enmLenguajesNombres.German
                Return "de-DE"

            Case enmLenguajesNombres.Portuguese
                Return "pt-PT"

            Case enmLenguajesNombres.Italian
                Return "it-IT"

            Case enmLenguajesNombres.French
                Return "fr-FR"

            Case enmLenguajesNombres.Catalan
                Return "ca-CA"

                'Case enmLenguajesNombres.العربية
                '    Return "ar-AR"

                'Case enmLenguajesNombres.汉语
                '    Return "zh-ZH"

                'Case enmLenguajesNombres.한국어_조선말
                '    Return "ko-KO"

                'Case enmLenguajesNombres.Euskera
                '    Return "eu-EU"

            Case enmLenguajesNombres.Greek
                Return "el-EL"

            Case enmLenguajesNombres.Japanese
                Return "ja-JA"

            Case enmLenguajesNombres.Russian
                Return "ru-RU"

            Case enmLenguajesNombres.Romanian
                Return "ro-RO"

            Case enmLenguajesNombres.Czech
                Return "cz-CZ"

            Case enmLenguajesNombres.Bulgarian
                Return "bg-BG"

            Case enmLenguajesNombres.Croatian
                Return "hr-HR"

            Case enmLenguajesNombres.Danish
                Return "da-DA"

            Case enmLenguajesNombres.Dutch
                Return "nl-NL"

            Case enmLenguajesNombres.Finnish
                Return "fi-FI"

            Case enmLenguajesNombres.Hungarian
                Return "hu-HU"

            Case enmLenguajesNombres.Swedish
                Return "sv-SV"

            Case enmLenguajesNombres.Turkish
                Return "tr-TR"



            Case Else
                Return "es-ES"
        End Select
    End Function

    Public Shared Function ObtenerCodigo(ByVal eNombre As String) As String
        Return ObtenerCodigo(nombre2enum(eNombre))
    End Function

    Public Shared Function nombre2enum(ByVal eNombre As String) As enmLenguajesNombres
        Select Case eNombre
            Case "English"
                Return enmLenguajesNombres.English

            Case "Español"
                Return enmLenguajesNombres.Spanish

            Case "Galego"
                Return enmLenguajesNombres.Galician

            Case "Deutsch"
                Return enmLenguajesNombres.German

            Case "Português"
                Return enmLenguajesNombres.Portuguese

            Case "Italiano"
                Return enmLenguajesNombres.Italian

            Case "Français"
                Return enmLenguajesNombres.French

            Case "Català"
                Return enmLenguajesNombres.Catalan

                'Case "العربية"
                '    Return enmLenguajesNombres.العربية

                'Case "汉语"
                '    Return enmLenguajesNombres.汉语

                'Case "한국어_조선말"
                '    Return enmLenguajesNombres.한국어_조선말

                'Case "Euskera"
                '    Return enmLenguajesNombres.Euskera

            Case "Ελληνική"
                Return enmLenguajesNombres.Greek

            Case "日本語"
                Return enmLenguajesNombres.Japanese

            Case "русский_язык"
                Return enmLenguajesNombres.Russian

            Case "Romanian"
                Return enmLenguajesNombres.Romanian

            Case "čeština"
                Return enmLenguajesNombres.Czech

            Case "Bulgarian"
                Return enmLenguajesNombres.Bulgarian

            Case "Croatian"
                Return enmLenguajesNombres.Croatian

            Case "Danish"
                Return enmLenguajesNombres.Danish

            Case "Dutch"
                Return enmLenguajesNombres.Dutch

            Case "Suomi"
                Return enmLenguajesNombres.Finnish

            Case "Hungarian"
                Return enmLenguajesNombres.Hungarian

            Case "Swedish"
                Return enmLenguajesNombres.Swedish

            Case "Türkçe"
                Return enmLenguajesNombres.Turkish



            Case Else
                Return enmLenguajesNombres.Spanish
        End Select
    End Function

    Public Shared Function iso2enum(ByVal eNombre As String) As enmLenguajesNombres
        Select Case eNombre
            Case "en-US"
                Return enmLenguajesNombres.English

            Case "es-ES"
                Return enmLenguajesNombres.Spanish

            Case "gl-GL"
                Return enmLenguajesNombres.Galician

            Case "de-DE"
                Return enmLenguajesNombres.German

            Case "pt-PT"
                Return enmLenguajesNombres.Portuguese

            Case "it-IT"
                Return enmLenguajesNombres.Italian

            Case "fr-FR"
                Return enmLenguajesNombres.French

            Case "ca-CA"
                Return enmLenguajesNombres.Catalan

                'Case "ar-AR"
                '    Return enmLenguajesNombres.العربية

                'Case "zh-ZH"
                '    Return enmLenguajesNombres.汉语

                'Case "ko-KO"
                '    Return enmLenguajesNombres.한국어_조선말

                'Case "eu-EU"
                '    Return enmLenguajesNombres.Euskera

            Case "el-EL"
                Return enmLenguajesNombres.Greek

            Case "ja-JA"
                Return enmLenguajesNombres.Japanese

            Case "ru-RU"
                Return enmLenguajesNombres.Russian

            Case "ro-RO"
                Return enmLenguajesNombres.Romanian

            Case "cz-CZ"
                Return enmLenguajesNombres.Czech

            Case "bg-BG"
                Return enmLenguajesNombres.Bulgarian

            Case "hr-HR"
                Return enmLenguajesNombres.Croatian

            Case "da-DA"
                Return enmLenguajesNombres.Danish

            Case "nl-NL"
                Return enmLenguajesNombres.Dutch

            Case "fi-FI"
                Return enmLenguajesNombres.Finnish

            Case "hu-HU"
                Return enmLenguajesNombres.Hungarian

            Case "sv-SV"
                Return enmLenguajesNombres.Swedish

            Case "tr-TR"
                Return enmLenguajesNombres.Turkish



            Case Else
                Return enmLenguajesNombres.Spanish
        End Select
    End Function

    Public Shared Function ObtenerNombre(ByVal eId As enmLenguajesNombres) As String
        Return [Enum].GetName(GetType(enmLenguajesNombres), eId)
    End Function
#End Region

#Region " METODOS SOBREESCRITOS "
    ''' <summary>
    ''' Sobreescritura del ToString para devolver el nombre del idioma
    ''' </summary>
    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function
#End Region
End Class
