Imports Recompila.Traductor

Namespace Sistema
    Namespace Configuracion
        Module modSistemaConfiguracion
#Region " DECLARACIONES "
            ''' <summary>
            ''' Nombre de la aplicación 
            ''' </summary>
            Public Const _NOMBRE_APLICACION As String = "Recompila.Traductor"

            ''' <summary>
            ''' Extensión utilizada para guardar las configuraciones realizadas en los proyectos
            ''' de traducción y poder recuperarlas sin tener que volver a configurar todo
            ''' el asistente
            ''' </summary>
            Public Const _EXTENSION_TRADUCTOR As String = ".rtrad"
#End Region

#Region " PROPIEDADES "
            ''' <summary>
            ''' Ruta donde se encuentra el archivo de configuración predeterminado para los a
            ''' accesos al servidor FTP y URI base utilziada para realizar las traducciones de
            ''' forma automática
            ''' </summary>
            Public ReadOnly Property _DEFAULT_NETEWORK_CONFIG As String
                Get
                    Return Application.StartupPath & "\network.config"
                End Get
            End Property
#End Region
        End Module
    End Namespace
End Namespace
