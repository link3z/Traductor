Imports Recompila.Helper

Namespace NET
    <Serializable>
    Public Class cFormulario
#Region " PROPIEDADES "
        ''' <summary>
        ''' Ruta completa al proyecto que contiene el formulario
        ''' </summary>
        Public ReadOnly Property RutaProyecto As String
            Get
                Return iRutaProyecto
            End Get
        End Property
        Private iRutaProyecto As String = ""

        ''' <summary>
        ''' Ruta completa al archivo .Designer con el diseño del Rormulario/Control
        ''' </summary>
        Public ReadOnly Property RutaFormulario As String
            Get
                Return iRutaFormulario
            End Get
        End Property
        Private iRutaFormulario As String = ""

        ''' <summary>
        ''' Carpeta donde se encuentra el proyecto
        ''' </summary>
        Public ReadOnly Property CarpetaProyecto As String
            Get
                Return Ficheros.extraerRutaFichero(iRutaProyecto)
            End Get
        End Property

        ''' <summary>
        ''' Carpeta donde se encuentra el formulario
        ''' </summary>
        Public ReadOnly Property CarpetaFormulario As String
            Get
                Return Ficheros.extraerRutaFichero(iRutaFormulario)
            End Get
        End Property

        ''' <summary>
        ''' Nombre del fichero
        ''' </summary>
        Public ReadOnly Property NombreFichero As String
            Get
                Return Ficheros.extraerNombreFichero(iRutaFormulario)
            End Get
        End Property

        ''' <summary>
        ''' Nombre del Formulario/Control
        ''' </summary>
        Public ReadOnly Property NombreFormulario As String
            Get
                Dim paraDevolver As String = Me.NombreFichero

                ' Se eliminan las extensiones de VB
                If paraDevolver.Contains(".designer.vb") Then paraDevolver = paraDevolver.Replace(".designer.vb", "")
                If paraDevolver.Contains(".Designer.vb") Then paraDevolver = paraDevolver.Replace(".Designer.vb", "")
                If paraDevolver.Contains(".vb") Then paraDevolver = paraDevolver.Replace(".vb", "")

                ' Se eliminan las extensiones de C#
                If paraDevolver.Contains(".designer.cs") Then paraDevolver = paraDevolver.Replace(".designer.cs", "")
                If paraDevolver.Contains(".Designer.cs") Then paraDevolver = paraDevolver.Replace(".Designer.cs", "")
                If paraDevolver.Contains(".cs") Then paraDevolver = paraDevolver.Replace(".cs", "")

                Return paraDevolver
            End Get
        End Property
        Private iNombreFormulario As String = ""
#End Region

#Region " CONSTRUCTORES "
        Public Sub New()

        End Sub

        Public Sub New(ByVal eRutaProyecto As String, _
                       ByVal eRutaFormulario As String)
            iRutaProyecto = iRutaProyecto
            iRutaFormulario = eRutaFormulario
        End Sub
#End Region

#Region " SOBRECARGAS "
        Public Overrides Function ToString() As String
            Return Me.NombreFormulario
        End Function
#End Region
    End Class
End Namespace