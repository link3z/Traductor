Public Interface ICBase
    ''' <summary>
    ''' Controla si el control todavía se está cargando el control
    ''' </summary>
    Property Cargando As Boolean

    ''' <summary>
    ''' Realiza la limpieza de los controles contenidos en el control
    ''' </summary>    
    Sub LimpiarCampos()

    ''' <summary>
    ''' Activa los controles contenidos en el control
    ''' </summary>
    ''' <param name="eEstado">Estado de activación en el que se deben poner los controles</param>    
    Sub ActivarCampos(ByVal eEstado As Boolean)

    ''' <summary>
    ''' Prepara el control para su cierre, deteniendo hilos y timers que pudieran estar ejecutándose
    ''' para evitar que estos siguan funcionando cuando el control ya no exista
    ''' </summary>    
    Sub PrepararCierre()
End Interface
