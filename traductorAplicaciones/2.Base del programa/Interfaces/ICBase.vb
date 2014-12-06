Public Interface ICBase
#Region " PROPIEDADES "
    ''' <summary>
    ''' Controla si el control todavía se está cargando en su control contenedor
    ''' para evitar que se realicen operaciones innecesarias durante la carga
    ''' </summary>
    Property Cargando As Boolean
#End Region

#Region " METODOS "
    ''' <summary>
    ''' Realiza la limpieza de los controles que se van a utilizar en el propio control,
    ''' seleccionando los valores predeterminados en el caso de selecciones o limpiando
    ''' los controles o fijando en el valor predeterminado en el caso de campos de texto
    ''' </summary>    
    Sub LimpiarCampos()

    ''' <summary>
    ''' Activa todos los campos que se van a utilizar durante el uso del control
    ''' </summary>
    ''' <param name="eEstado">Estado de activación en el que se deben poner los controles</param>    
    Sub ActivarCampos(ByVal eEstado As Boolean)

    ''' <summary>
    ''' Prepara el control para su cierre, deteniendo hilos y timers que pudieran estar ejecutándose
    ''' para evitar que estos siguan funcionando y lanzando eventos mientras se está produciendo
    ''' el cierre y evitar llamadas desde objetos destruidos
    ''' </summary>    
    Function PrepararCierre() As Boolean
#End Region
End Interface
