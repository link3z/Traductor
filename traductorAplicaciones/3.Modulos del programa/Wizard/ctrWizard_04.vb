Imports Recompila
Imports Recompila.Helper
Imports Recompila.Traductor

Public Class ctrWizard_04
    Implements IControlWizard

#Region " PROPIEDADES "
    ''' <summary>
    ''' Controla si el componente todavía se está cargando
    ''' </summary>
    Public Property Cargando As Boolean Implements ICBase.Cargando
        Get
            Return iCargando
        End Get
        Set(value As Boolean)
            iCargando = value
        End Set
    End Property
    Private iCargando As Boolean = True
#End Region

#Region " IMPLEMENTACION "
    Public Sub ActivarCampos(eEstado As Boolean) Implements ICBase.ActivarCampos

    End Sub

    Public Sub LimpiarCampos() Implements ICBase.LimpiarCampos
        gestorErrores.Clear()
    End Sub

    Public Sub PrepararCierre() Implements ICBase.PrepararCierre

    End Sub

    Public Function Cargar(eObjeto As Object) As Boolean Implements IControlWizard.Cargar

        Return True
    End Function

    Public Sub CargarDatosMaestros() Implements IControlWizard.CargarDatosMaestros
        ' Se fijan los valores de la barra de progreso general
        WinForms.ProgressBar.fijarMinimoBarra(pbGeneral, 0)
        WinForms.ProgressBar.fijarMaximoBarra(pbGeneral, Sistema.Configuracion.objetosTraducir.Count + 1)
        WinForms.ProgressBar.FijarBarra(pbGeneral, 0)



    End Sub

    Public Sub DarFoco() Implements IControlWizard.DarFoco
        tInicio.Start()
    End Sub

    Public Function ExistenErrores() As Boolean Implements IControlWizard.ExistenErrores
        Me.ValidateChildren()
        Return (gestorErrores.HasErrors)
    End Function

    Public Function Guardar(eObjeto As Object) As Object Implements IControlWizard.Guardar

        Return True
    End Function
#End Region

#Region " TRADUCCION "
    Private Sub tInicio_Tick(sender As Object, e As EventArgs) Handles tInicio.Tick
        tInicio.Stop()

        ' + Se crean los objetos necesarios para la realización de la traducción
        escribirMensaje("Configurando parámetros para la traducción.")

        ' Se crea el objeto traductor
        Dim elTraductor As cGeneradorPO = New cGeneradorPO(Sistema.Configuracion.proyectoVB, _
                                                           Sistema.Configuracion.proyectoTraductor,
                                                           Sistema.Configuracion.configuracionNetwork)

        ' Se añaden los manejadores para recibir información del estado de la traducción
        AddHandler elTraductor.notificarMensaje, AddressOf manejadorNotificarMensaje
        AddHandler elTraductor.notificarMaximo, AddressOf manejadorNotificarMaximo
        AddHandler elTraductor.notificarProgreso, AddressOf manejadorNotificarProgreso
        AddHandler elTraductor.notificarFinalizacion, AddressOf manejadorNotificarFinalizacion

        ' Una vez que el código llega hasta este punto, se puede realizar la traducción 
        ' recorriendo todos los archivos seleccionados
        ' Se recorren todos los formualarios para realizar las traducciones        
        For Each unArchivo As cArchivoVB In Sistema.Configuracion.proyectoTraductor.ArchivosVB
            elTraductor.VBFile2POFile(unArchivo.RutaCompleta)
        Next


        frmWizard.btnAnterior.Enabled = True
        frmWizard.btnSiguiente.Enabled = True
    End Sub
#End Region

#Region " MANEJADORES "
    Private Sub manejadorNotificarMensaje(eHora As Date, eMensaje As String)
        escribirMensaje(eMensaje)
    End Sub

    Private Sub manejadorNotificarMaximo(eValor As Long)
        WinForms.ProgressBar.fijarMinimoBarra(pbConcreta, 0)
        WinForms.ProgressBar.fijarMaximoBarra(pbConcreta, eValor)
        WinForms.ProgressBar.FijarBarra(pbConcreta, 0)
    End Sub

    Private Sub manejadorNotificarProgreso()
        WinForms.ProgressBar.AumentarBarra(pbConcreta)
    End Sub

    Private Sub manejadorNotificarFinalizacion()
        WinForms.ProgressBar.FijarBarra(pbConcreta, 0)
    End Sub
#End Region

#Region " METODOS AUXILIARES "
    Private Sub escribirMensaje(ByVal eMensaje As String)
        Try
            txtMensajes.AppendText(" " & Format(Now, "HH:mm:ss") & " > " & eMensaje.Trim & vbCrLf)
            txtMensajes.Refresh()
            Application.DoEvents()
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " FORMULARIO "
    Private Sub ctrWizard_1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        iCargando = False
        frmWizard.btnAnterior.Enabled = False
        frmWizard.btnSiguiente.Enabled = False
    End Sub
#End Region

End Class
