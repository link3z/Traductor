Public Interface IControlWizard
    Inherits ICBase

#Region " METODOS "
    ''' <summary>
    ''' Carga los datos maestros que pudieran existir en el combos, listados, etc
    ''' </summary>
    Sub CargarDatosMaestros()

    ''' <summary>
    ''' Función que carga la configuración en el paso.
    ''' </summary>
    ''' <param name="eObjeto">Datos para la carga de la configuración si fuesen necesarios</param>
    Function Cargar(ByVal eObjeto As Object) As Boolean

    ''' <summary>
    ''' Funcion para guardar la configuración del paso
    ''' </summary>
    ''' <param name="eObjeto">Objeto donde se guardarán los datos si fuese necesario</param>
    Function Guardar(ByRef eObjeto As Object) As Object

    ''' <summary>
    ''' Comprueba si existen errores en los controles que componen el paso.
    ''' </summary>
    Function ExistenErrores() As Boolean

    ''' <summary>
    ''' Da el foco al control que se añade poniendo el cursor en el elemento que se debe rellenar.
    ''' </summary>
    Sub DarFoco()
#End Region
End Interface
