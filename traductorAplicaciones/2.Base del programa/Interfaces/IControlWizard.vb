Public Interface IControlWizard
    Inherits ICBase

    ''' <summary>
    ''' Carga los datos maestros que pudieran existir en el combos, listados, etc
    ''' </summary>
    Sub CargarDatosMaestros()

    ''' <summary>
    ''' Funcion para la carga del objeto al cargar el paso
    ''' </summary>
    Function Cargar(ByVal eObjeto As Object) As Boolean

    ''' <summary>
    ''' Funcion para guardar la entidad
    ''' </summary>
    Function Guardar(ByVal eObjeto As Object) As Object

    ''' <summary>
    ''' Comprueba si existen errores antes de cambiar de página
    ''' </summary>
    Function ExistenErrores() As Boolean

    ''' <summary>
    ''' Da el foco al control que se añade poniendo el cursor en el elemento que se debe rellenar.
    ''' </summary>
    Sub DarFoco()
End Interface
