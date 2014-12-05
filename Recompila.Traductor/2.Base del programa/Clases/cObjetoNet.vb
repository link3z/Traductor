Imports Recompila.Helper

Public Class cFicheroVB
#Region " PROPIEDADES "
    Public Property RutaCompleta As String
    Public Property RutaProyecto As String
    Public Property RutaParcial As String
    Public Property NombreFichero As String
#End Region

#Region " CONSTRUCTORES "
    Public Sub New(ByVal eRutaProyecto As String, _
                   ByVal eRutaObjeto As String)
        Me.RutaCompleta = eRutaObjeto
        Me.RutaProyecto = Ficheros.extraerRutaFichero(eRutaProyecto)
        Me.RutaParcial = eRutaObjeto.Remove(0, RutaProyecto.Length)
        Me.NombreFichero = Ficheros.extraerNombreFichero(eRutaObjeto)
    End Sub
#End Region

#Region " SOBRECARGAS "
    Public Overrides Function ToString() As String
        Return Me.RutaParcial
    End Function
#End Region
End Class

