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

            ''' <summary>
            ''' Ruta con la configuración de los controles/objetos predeterminados que el sistema
            ''' de traducción es capaz de traducir
            ''' </summary>
            Public ReadOnly Property _CONTROLS_DEFAULT_PATH As String
                Get
                    Return Application.StartupPath & "\controls.default.config"
                End Get
            End Property

            Public Property _DEFAULT_CONTROLS As New List(Of NET.cControl)

            Public Property _USER_CONTROLS As New List(Of NET.cControl)

            ''' <summary>
            ''' Ruta con la configuración de los controles/objetos que el usuario añadió o modificó
            ''' al sistema de traducción
            ''' </summary>
            Public ReadOnly Property _CONTROLS_USER_PATH As String
                Get
                    Return Application.StartupPath & "\controls.user.config"
                End Get
            End Property
#End Region
        End Module
    End Namespace
End Namespace
