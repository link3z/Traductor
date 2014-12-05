Imports Recompila.Traductor

Namespace Sistema
    Namespace Configuracion
        Module modSistemaConfiguracion
            ''' <summary>
            ''' Nombre de la aplicación
            ''' </summary>
            Public Const _NOMBRE_APLICACION As String = "Recompila.Traductor"

            ''' <summary>
            ''' Ruta donde se encuentra el archivo de configuración de acceos al FTP y HTTP
            ''' </summary>
            Public ReadOnly Property rutaConfiguracionNetwork As String
                Get
                    Return Application.StartupPath & "\network.config"
                End Get
            End Property

            ''' <summary>
            ''' Configuración de acceso al FTP y HTTP para realizar las traducciones.
            ''' Esta configuración se guarda en el archivo network.config en misma carpeta
            ''' donde está instalada la aplicación
            ''' </summary>
            Public Property configuracionNetwork As cConfiguracionNetwork
                Get
                    If iConfiguracionNetwork Is Nothing Then iConfiguracionNetwork = New cConfiguracionNetwork
                    Return iConfiguracionNetwork
                End Get
                Set(value As cConfiguracionNetwork)
                    iConfiguracionNetwork = value
                End Set
            End Property
            Private iConfiguracionNetwork As cConfiguracionNetwork = Nothing

            ''' <summary>
            ''' Se trata de la información relevante de la traducción que se está realizando, al finalizar
            ''' el proceso se se puede guardar para poder utilizar con posterioridad
            ''' </summary>
            Public Property proyectoTraductor As cProyectoTraductor = Nothing

            ''' <summary>
            ''' Proyecto VB con el que se va a trabajar para realizar la traducción
            ''' </summary>
            Public Property proyectoVB As cProyectoVB = Nothing

            ''' <summary>
            ''' Lista con los archivos del proyecto que se van a traducir
            ''' </summary>
            Public objetosTraducir As New List(Of cArchivoVB)
        End Module
    End Namespace
End Namespace
