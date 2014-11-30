
' ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
''' <summary>
''' Idioma para traducciones
''' Mantiene información sobre el idioma para poder utilizar tanto internamente
''' como externamente
''' </summary>
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

            Case enmLenguajesNombres.Español
                Return "es-ES"

            Case enmLenguajesNombres.Galego
                Return "gl-GL"

            Case enmLenguajesNombres.Deutsch
                Return "de-DE"

            Case enmLenguajesNombres.Português
                Return "pt-PT"

            Case enmLenguajesNombres.Italiano
                Return "it-IT"

            Case enmLenguajesNombres.Français
                Return "fr-FR"

            Case enmLenguajesNombres.Català
                Return "ca-CA"

                'Case enmLenguajesNombres.العربية
                '    Return "ar-AR"

                'Case enmLenguajesNombres.汉语
                '    Return "zh-ZH"

                'Case enmLenguajesNombres.한국어_조선말
                '    Return "ko-KO"

                'Case enmLenguajesNombres.Euskera
                '    Return "eu-EU"

            Case enmLenguajesNombres.Ελληνική
                Return "el-EL"

            Case enmLenguajesNombres.日本語
                Return "ja-JA"

            Case enmLenguajesNombres.русский_язык
                Return "ru-RU"

            Case enmLenguajesNombres.Romanian
                Return "ro-RO"

            Case enmLenguajesNombres.čeština
                Return "cz-CZ"

            Case enmLenguajesNombres.Bulgarian
                Return "bg-BG"

            Case enmLenguajesNombres.Croatian
                Return "hr-HR"

            Case enmLenguajesNombres.Danish
                Return "da-DA"

            Case enmLenguajesNombres.Dutch
                Return "nl-NL"

            Case enmLenguajesNombres.Suomi
                Return "fi-FI"

            Case enmLenguajesNombres.Hungarian
                Return "hu-HU"

            Case enmLenguajesNombres.Swedish
                Return "sv-SV"

            Case enmLenguajesNombres.Türkçe
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
                Return enmLenguajesNombres.Español

            Case "Galego"
                Return enmLenguajesNombres.Galego

            Case "Deutsch"
                Return enmLenguajesNombres.Deutsch

            Case "Português"
                Return enmLenguajesNombres.Português

            Case "Italiano"
                Return enmLenguajesNombres.Italiano

            Case "Français"
                Return enmLenguajesNombres.Français

            Case "Català"
                Return enmLenguajesNombres.Català

                'Case "العربية"
                '    Return enmLenguajesNombres.العربية

                'Case "汉语"
                '    Return enmLenguajesNombres.汉语

                'Case "한국어_조선말"
                '    Return enmLenguajesNombres.한국어_조선말

                'Case "Euskera"
                '    Return enmLenguajesNombres.Euskera

            Case "Ελληνική"
                Return enmLenguajesNombres.Ελληνική

            Case "日本語"
                Return enmLenguajesNombres.日本語

            Case "русский_язык"
                Return enmLenguajesNombres.русский_язык

            Case "Romanian"
                Return enmLenguajesNombres.Romanian

            Case "čeština"
                Return enmLenguajesNombres.čeština

            Case "Bulgarian"
                Return enmLenguajesNombres.Bulgarian

            Case "Croatian"
                Return enmLenguajesNombres.Croatian

            Case "Danish"
                Return enmLenguajesNombres.Danish

            Case "Dutch"
                Return enmLenguajesNombres.Dutch

            Case "Suomi"
                Return enmLenguajesNombres.Suomi

            Case "Hungarian"
                Return enmLenguajesNombres.Hungarian

            Case "Swedish"
                Return enmLenguajesNombres.Swedish

            Case "Türkçe"
                Return enmLenguajesNombres.Türkçe



            Case Else
                Return enmLenguajesNombres.Español
        End Select
    End Function

    Public Shared Function iso2enum(ByVal eNombre As String) As enmLenguajesNombres
        Select Case eNombre
            Case "en-US"
                Return enmLenguajesNombres.English

            Case "es-ES"
                Return enmLenguajesNombres.Español

            Case "gl-GL"
                Return enmLenguajesNombres.Galego

            Case "de-DE"
                Return enmLenguajesNombres.Deutsch

            Case "pt-PT"
                Return enmLenguajesNombres.Português

            Case "it-IT"
                Return enmLenguajesNombres.Italiano

            Case "fr-FR"
                Return enmLenguajesNombres.Français

            Case "ca-CA"
                Return enmLenguajesNombres.Català

                'Case "ar-AR"
                '    Return enmLenguajesNombres.العربية

                'Case "zh-ZH"
                '    Return enmLenguajesNombres.汉语

                'Case "ko-KO"
                '    Return enmLenguajesNombres.한국어_조선말

                'Case "eu-EU"
                '    Return enmLenguajesNombres.Euskera

            Case "el-EL"
                Return enmLenguajesNombres.Ελληνική

            Case "ja-JA"
                Return enmLenguajesNombres.日本語

            Case "ru-RU"
                Return enmLenguajesNombres.русский_язык

            Case "ro-RO"
                Return enmLenguajesNombres.Romanian

            Case "cz-CZ"
                Return enmLenguajesNombres.čeština

            Case "bg-BG"
                Return enmLenguajesNombres.Bulgarian

            Case "hr-HR"
                Return enmLenguajesNombres.Croatian

            Case "da-DA"
                Return enmLenguajesNombres.Danish

            Case "nl-NL"
                Return enmLenguajesNombres.Dutch

            Case "fi-FI"
                Return enmLenguajesNombres.Suomi

            Case "hu-HU"
                Return enmLenguajesNombres.Hungarian

            Case "sv-SV"
                Return enmLenguajesNombres.Swedish

            Case "tr-TR"
                Return enmLenguajesNombres.Türkçe



            Case Else
                Return enmLenguajesNombres.Español
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
