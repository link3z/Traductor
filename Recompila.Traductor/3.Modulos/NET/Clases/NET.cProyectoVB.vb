Imports Recompila.Helper

Namespace NET
    Public Class cProyectoVB
        Inherits cProyectoNET

#Region " PROPIEDADES "
        ''' <summary>
        ''' Obtiene un listado con todos los Formularios que componen el proyecto seleccionado
        ''' </summary>
        Public Overrides ReadOnly Property Formularios As List(Of NET.cFormulario)
            Get
                ' Se trata de ir localizando todos los elementos de la Tabla que finalicen el '.Desgner.vb', ya que
                ' estos serán los Formularios, descartando el Application, el Ressources y Settings.

                ' Además, tambien hay que analizar todos los módulos y Clases para realizar los cambios en las constantes
                ' de texto que pudieran existir

                ' Si no existe el archivo del proyecto no se puede procesar
                If Not IO.File.Exists(iRutaProyecto) Then Return Nothing

                Dim paraDevolver As New List(Of NET.cFormulario)

                Try
                    Dim elDataSet As New DataSet
                    elDataSet.ReadXml(iRutaProyecto)

                    Dim laTabla As DataTable = (From it As DataTable In elDataSet.Tables _
                                                Where it.TableName.Trim.ToUpper = "Compile".ToUpper _
                                                Select it).FirstOrDefault
                    If laTabla IsNot Nothing Then
                        Dim laColumna As DataColumn = (From it As DataColumn In laTabla.Columns _
                                                       Where it.ColumnName.Trim.ToUpper = "Include".ToUpper _
                                                       Select it).FirstOrDefault
                        If laColumna IsNot Nothing Then
                            For Each unRow As DataRow In laTabla.Rows
                                Dim elValor As String = unRow.Item(laColumna).ToString.ToUpper.Trim

                                If elValor.Contains(".DESIGNER.VB") AndAlso _
                                   Not elValor.Contains("APPLICATION.DESIGNER.VB") AndAlso _
                                   Not elValor.Contains("RESOURCES.DESIGNER.VB") AndAlso _
                                   Not elValor.Contains("SETTINGS.DESIGNER.VB") AndAlso _
                                   Not elValor.Contains("MODELOEF.DESIGNER.VB") Then

                                    ' Localizado un formulario para traducir
                                    Dim elFormulario As String = (unRow.Item(laColumna)).ToString.Trim
                                    If Log._LOG_ACTIVO Then Log.escribirLog(" > " & elFormulario, , New StackTrace(0, True))

                                    ' Dependiendo de la ruta del fichero hay que modificarla para obtener la ruta absoluta
                                    Dim rutaObjeto As String = ""
                                    If elFormulario.StartsWith("\\") Or elFormulario.Substring(1, 1) = ":" Then
                                        rutaObjeto = elFormulario
                                    Else
                                        rutaObjeto = carpetaProyecto & "\" & elFormulario
                                    End If

                                    ' Se crea el nuevo objeto y se añade a la lista de objetos a devolver
                                    Dim nuevoObjeto As NET.cFormulario = New NET.cFormulario(iRutaProyecto, rutaObjeto)
                                    paraDevolver.Add(nuevoObjeto)
                                End If
                            Next
                        End If
                    End If
                Catch ex As Exception
                    If Log._LOG_ACTIVO Then Log.escribirLog("ERROR al obtener los objetos del proyecto...", ex, New StackTrace(0, True))
                    paraDevolver = Nothing
                End Try

                Return paraDevolver
            End Get
        End Property
#End Region


#Region " CONSTRUCTORES "
        Public Sub New(ByVal eRutaProyecto As String)
            iRutaProyecto = eRutaProyecto
        End Sub
#End Region

    End Class
End Namespace
