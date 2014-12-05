Public Interface IMotorTraduccion
#Region " PROPIEDADES "
    ''' <summary>
    ''' Nombre identificativo del motor
    ''' </summary>
    ReadOnly Property Nombre As String

    ''' <summary>
    ''' URL utilizada para la traducción
    ''' </summary>
    ReadOnly Property URI As String

    ''' <summary>
    ''' Distintas combinaciones de traducción que puede hacer cada motor a partir de un idioma de entrada
    ''' </summary>
    ReadOnly Property TiposTraduccion As Dictionary(Of idiomaLocalizacion, List(Of idiomaLocalizacion))
#End Region

#Region " METODOS "
    ''' <summary>
    ''' Obtiene la URL que se tiene que invocar para realizar la traducción de la página
    ''' que se le pasa por parámetro de un idioma dado a otro
    ''' </summary>
    ''' <param name="eIdiomaEntrada">Idioma de entrada para la traducción</param>
    ''' <param name="eIdiomaSalida">Idioma de salida para la traducción</param>
    ''' <param name="eURL">URL donde se tiene que realizar la traducción</param>
    ''' <returns>URL formateada para poder realizar la traducción</returns>
    Function obtenerURL(ByVal eIdiomaEntrada As cIdioma, _
                        ByVal eIdiomaSalida As cIdioma, _
                        ByVal eURL As String) As String



#End Region

End Interface
