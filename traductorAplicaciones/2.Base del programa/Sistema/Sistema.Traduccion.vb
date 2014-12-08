Imports Recompila.Traductor

Namespace Sistema
    Namespace Traduccion
        ''' <summary>
        ''' Funciones y propiedades que se utilizarán para almacenar información sobre la traducción
        ''' que se esta realizando, tales como la configuración del proyecto de traducción, proyecto
        ''' VB que se está traducción, información de los idiomas de entrada y salida...
        ''' </summary>
        ''' <remarks></remarks>
        Friend Module modSistemaTraduccion
#Region " PROPIEDADES "
            ''' <summary>
            ''' Configuración de acceso al FTP y HTTP para realizar las traducciones.
            ''' Esta configuración se guarda en el archivo network.config en misma carpeta
            ''' donde está instalada la aplicación
            ''' </summary>
            Public Property _CONFIGURACION_CONEXION As cConfiguracionNetwork
                Get
                    If i_CONFIGURACION_CONEXION Is Nothing Then i_CONFIGURACION_CONEXION = New cConfiguracionNetwork
                    Return i_CONFIGURACION_CONEXION
                End Get
                Set(value As cConfiguracionNetwork)
                    i_CONFIGURACION_CONEXION = value
                End Set
            End Property
            Private i_CONFIGURACION_CONEXION As cConfiguracionNetwork = Nothing

            ''' <summary>
            ''' Proyecto VB con el que se va a trabajar para realizar la traducción.
            ''' Este objeto devuelve toda la información que se necesita obtener del código
            ''' fuente del proyecto para realzar los cambios y operaciones necesarias
            ''' para el correcto funcionamiento del traductor tanto a la hora de
            ''' traducir como a la hora de utilizar los archivos PO generados
            ''' </summary>
            Public Property _PROYECTO_NET As NET.cProyectoNET = Nothing

            ''' <summary>
            ''' Tipo de opración que se está realizando, o ejecutando un proyecto de traducción
            ''' que ya existía o creando uno nuevo
            ''' </summary>
            Public Property _OPERACION As Operacion = Operacion.AbrirProyecto

            ''' <summary>
            ''' Ruta del proyecto de traducción
            ''' </summary>
            Public Property _RUTA_RTRAD As String = String.Empty

            ''' <summary>
            ''' Información relevante de la traducción que se está realizando, al finalizar
            ''' el proceso se se puede guardar para poder utilizar con posterioridad serializando
            ''' esta clase y guardándola con la extensión utilizada por el programa
            ''' </summary>
            Public Property _CONFIGURACION_TRADUCTOR As cProyectoTraductor = Nothing

            ''' <summary>
            ''' Motor que se está utilizando para realizar la traducción
            ''' </summary>
            Public Property _MOTOR As Motor.cMotorBase = Nothing

            ''' <summary>
            ''' Guarda de forma automática la configuración del proyecto de traducción al
            ''' finalizar la traducción del proyecto
            ''' </summary>
            Public Property _GUARDAR_AL_FINALIZAR As Boolean = True
#End Region
        End Module
    End Namespace
End Namespace
