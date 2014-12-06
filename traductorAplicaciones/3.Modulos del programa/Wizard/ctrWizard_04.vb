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

    Public Function PrepararCierre() As Boolean Implements ICBase.PrepararCierre

        Return True
    End Function

    Public Function Cargar(eObjeto As Object) As Boolean Implements IControlWizard.Cargar

        Return True
    End Function

    Public Sub CargarDatosMaestros() Implements IControlWizard.CargarDatosMaestros

    End Sub

    Public Sub DarFoco() Implements IControlWizard.DarFoco
        tInicio.Start()
    End Sub

    Public Function ExistenErrores() As Boolean Implements IControlWizard.ExistenErrores
        Me.ValidateChildren()
        Return (gestorErrores.HasErrors)
    End Function

    Public Function Guardar(ByRef eObjeto As Object) As Object Implements IControlWizard.Guardar

        Return True
    End Function
#End Region

#Region " TRADUCCION "
    Private Sub tInicio_Tick(sender As Object, e As EventArgs) Handles tInicio.Tick
        tInicio.Stop()

        ' + Se crean los objetos necesarios para la realización de la traducción
        escribirMensaje("Configurando parámetros para la traducción.")

        ' Se crea el objeto traductor
        Dim elTraductor As cGeneradorPO = New cGeneradorPO(Sistema.Traduccion._PROYECTO_VB, _
                                                           Sistema.Traduccion._CONFIGURACION_TRADUCTOR,
                                                           Sistema.Traduccion._CONFIGURACION_CONEXION)

        ' Se añaden los manejadores para recibir información del estado de la traducción
        AddHandler elTraductor.notificarMensaje, AddressOf manejadorNotificarMensaje
        AddHandler elTraductor.notificarMaximo, AddressOf manejadorNotificarMaximo
        AddHandler elTraductor.notificarProgreso, AddressOf manejadorNotificarProgreso
        AddHandler elTraductor.notificarFinalizacion, AddressOf manejadorNotificarFinalizacion


        ' Una vez que el código llega hasta este punto, se puede realizar la traducción 
        ' recorriendo todos los archivos seleccionados
        elTraductor.Traducir()

        frmWizard.btnAnterior.Enabled = True
        frmWizard.btnSiguiente.Enabled = True
        frmWizard.btnSiguiente.PerformClick()
    End Sub
#End Region

#Region " MANEJADORES "
    Private Sub manejadorNotificarMensaje(ByVal eMensaje As String)
        escribirMensaje(eMensaje)
    End Sub

    Private Sub manejadorNotificarMaximo(ByVal eBarra As cGeneradorPO.TipoBarraProgreso, ByVal eValor As Long)
        If eBarra = cGeneradorPO.TipoBarraProgreso.Primaria Then
            WinForms.ProgressBar.fijarMinimoBarra(pbPrimaria, 0)
            WinForms.ProgressBar.fijarMaximoBarra(pbPrimaria, eValor)
            WinForms.ProgressBar.FijarBarra(pbPrimaria, 0)
        ElseIf eBarra = cGeneradorPO.TipoBarraProgreso.Secundaria Then
            WinForms.ProgressBar.fijarMinimoBarra(pbSecundaria, 0)
            WinForms.ProgressBar.fijarMaximoBarra(pbSecundaria, eValor)
            WinForms.ProgressBar.FijarBarra(pbSecundaria, 0)
        End If
    End Sub

    Private Sub manejadorNotificarProgreso(ByVal eBarra As cGeneradorPO.TipoBarraProgreso, _
                                           ByVal eValor As Integer)
        If eBarra = cGeneradorPO.TipoBarraProgreso.Primaria Then
            If eValor = 0 Then
                WinForms.ProgressBar.AumentarBarra(pbPrimaria)
            Else
                WinForms.ProgressBar.FijarBarra(pbPrimaria, eValor)
            End If
        ElseIf eBarra = cGeneradorPO.TipoBarraProgreso.Secundaria Then
            If eValor = 0 Then
                WinForms.ProgressBar.AumentarBarra(pbSecundaria)
            Else
                WinForms.ProgressBar.FijarBarra(pbSecundaria, eValor)
            End If
        End If
    End Sub

    Private Sub manejadorNotificarFinalizacion(ByVal eBarra As cGeneradorPO.TipoBarraProgreso)
        If eBarra = cGeneradorPO.TipoBarraProgreso.Primaria Then
            WinForms.ProgressBar.FijarBarra(pbPrimaria, 0)
        ElseIf eBarra = cGeneradorPO.TipoBarraProgreso.Secundaria Then
            WinForms.ProgressBar.FijarBarra(pbSecundaria, 0)
        End If
    End Sub
#End Region

#Region " METODOS AUXILIARES "
    Private Sub escribirMensaje(ByVal eMensaje As String)
        Try
            txtMensajes.AppendText(Format(Now, "mm:ss") & " " & eMensaje.Trim & vbCrLf)
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
