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

#Region " EVENTOS "
    ''' <summary>
    ''' Evento que se lanza cada vez que se producen cambios para informar al usuario de estos
    ''' El manejador que está comprobando este evento se encargará de mostrar estos mensajes
    ''' mediante un cuadro de texto, un log, etc.
    ''' </summary>
    ''' <param name="eMensaje">Mensaje que se envía desde el traductor</param>
    Event notificarMensaje(ByVal eMensaje As String)
#End Region

#Region " METODOS "
    ''' <summary>
    ''' Obtiene el body de la página que se le pasa como parámetro traducido al idioma solicitdo
    ''' </summary>
    ''' <param name="eDatosConexion">Datos de conexión al servidor FTP y HTTP</param>
    ''' <param name="eIdiomaEntrada">Idioma de entrada para la traducción</param>
    ''' <param name="eIdiomaSalida">Idioma de salida para la traducción</param>
    ''' <param name="eURL">URL donde se tiene que realizar la traducción</param>
    ''' <param name="eEOF">Tag que indica que se terminael fichero a traducir</param>
    ''' <returns>URL formateada para poder realizar la traducción</returns>
    Function obtenerTraducciones(ByVal eDatosConexion As cConfiguracionNetwork, _
                                 ByVal eIdiomaEntrada As cIdioma, _
                                 ByVal eIdiomaSalida As cIdioma, _
                                 ByVal eURL As String, _
                                 ByVal eEOF As String) As Dictionary(Of Long, String)
#End Region

End Interface
