Imports Recompila.Helper
Imports Recompila.Controles
Imports ComponentFactory.Krypton.Toolkit

Public Class frmWizard

#Region " DECLARACIONES "
    Private Const _TOTAL_PASOS = 5

    Private pasoActual As Integer = 1

    Private _PASO_ACTUAL As IControlWizard = Nothing

    ''' <summary>
    ''' Desactiva el Intro como Tab en el formulario
    ''' </summary>
    Public Property DesactivarIntroComoTab As Boolean = True
#End Region

#Region " CONTROL PASOS "
    Private Sub marcarPaso(ByVal ePaso As rPosicion)
        For Each unControl As Control In pContenedor.Panel.Controls
            If TypeOf (unControl) Is rPosicion Then
                If unControl Is ePaso Then
                    CType(unControl, rPosicion).Color = Color.FromArgb(66, 66, 66)
                Else
                    CType(unControl, rPosicion).Color = Color.FromArgb(233, 233, 233)
                End If
            End If
        Next
    End Sub

    Private Sub cargarPaso(Optional ePaso As Integer = -1)
        btnSiguiente.Visible = False
        Dim mostrarSiguiente As Boolean = False
        Dim mostrarAnterior As Boolean = False

        If ePaso <> -1 Then pasoActual = ePaso

        ' Antes de nada se guardan los datos del paso actual
        If _PASO_ACTUAL IsNot Nothing Then
            If Log._LOG_ACTIVO Then Log.escribirLog("Guardando datos del paso actual...", , New StackTrace(0, True))
            _PASO_ACTUAL.Guardar(Nothing)
        End If

        ' Ahora se marca el siguiente paso y se crea el control que se debe mostrar        
        btnSiguiente.Text = "Siguiente"

        If Log._LOG_ACTIVO Then Log.escribirLog("Cargando paso " & ePaso & "...", , New StackTrace(0, True))
        If pasoActual = 1 Then
            marcarPaso(paso1)
            mostrarSiguiente = True
            mostrarAnterior = False
            _PASO_ACTUAL = New ctrWizard_01
        ElseIf pasoActual = 2 Then
            marcarPaso(paso2)
            mostrarSiguiente = True
            mostrarAnterior = True
            _PASO_ACTUAL = New ctrWizard_02
        ElseIf pasoActual = 3 Then
            marcarPaso(paso3)
            mostrarSiguiente = True
            mostrarAnterior = True
            _PASO_ACTUAL = New ctrWizard_03
        ElseIf pasoActual = 4 Then
            marcarPaso(paso4)
            mostrarSiguiente = True
            mostrarAnterior = True
            _PASO_ACTUAL = New ctrWizard_04
            btnSiguiente.Values.Image = My.Resources.arrow_right_16_gris_66
        ElseIf pasoActual = 5 Then
            marcarPaso(paso5)
            mostrarSiguiente = True
            mostrarAnterior = False
            _PASO_ACTUAL = New ctrWizard_05
            btnSiguiente.Text = "Salir"
            btnSiguiente.Values.Image = Nothing
        End If

        ' Si el control se creo correctamente, entonces se añade el control al conenedor
        ' y se cargan sus datos
        If _PASO_ACTUAL IsNot Nothing Then
            anhadirManejadoresArrastre(_PASO_ACTUAL)
            CType(_PASO_ACTUAL, UserControl).Dock = DockStyle.Fill
            kpnControles.Controls.Clear()
            kpnControles.Controls.Add(_PASO_ACTUAL)
            If Log._LOG_ACTIVO Then Log.escribirLog("Limpiando campos del paso " & ePaso & "...", , New StackTrace(0, True))
            _PASO_ACTUAL.LimpiarCampos()
            If Log._LOG_ACTIVO Then Log.escribirLog("Cargando datos maestros del paso " & ePaso & "...", , New StackTrace(0, True))
            _PASO_ACTUAL.CargarDatosMaestros()
            If Log._LOG_ACTIVO Then Log.escribirLog("Cargando datos del paso " & ePaso & "...", , New StackTrace(0, True))
            _PASO_ACTUAL.Cargar(Nothing)
            _PASO_ACTUAL.DarFoco()
        End If

        If Log._LOG_ACTIVO Then Log.escribirLog("Carga del paso " & ePaso & " completada...", , New StackTrace(0, True))
        btnSiguiente.Visible = mostrarSiguiente
        btnAnterior.Visible = mostrarAnterior
    End Sub

    Private Sub btnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click
        If _PASO_ACTUAL IsNot Nothing AndAlso Not _PASO_ACTUAL.ExistenErrores Then
            If pasoActual = _TOTAL_PASOS Then
                ' Antes de nada se guardan los datos del paso actual ya que se va a cerrar
                ' el postinstalador, y es posible que el paso de despedida tenga que efectuar
                ' alguna operación
                If _PASO_ACTUAL IsNot Nothing Then
                    If Log._LOG_ACTIVO Then Log.escribirLog("Guardando datos del paso actual...", , New StackTrace(0, True))
                    _PASO_ACTUAL.Guardar(Nothing)
                End If

                If Log._LOG_ACTIVO Then Log.escribirLog("Asistente completado correctamente !!!", , New StackTrace(0, True))
                End
            Else
                If pasoActual + 1 <= _TOTAL_PASOS Then
                    pasoActual += 1
                    cargarPaso()
                End If
            End If
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If pasoActual - 1 >= 1 Then
            pasoActual -= 1
            cargarPaso()
        End If
    End Sub
#End Region

#Region " INTROS COMO TABS "
    ''' <summary>
    ''' Nos desplaza a traves de los controles al pulsar enter
    ''' </summary>
    Private Sub EnterComoTab(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter And Not DesactivarIntroComoTab Then
            If (Me.ActiveControl Is Nothing _
                OrElse Me.ActiveControl.Parent Is Nothing _
                OrElse Not TypeOf (Me.ActiveControl.Parent) Is KryptonTextBox _
                OrElse Not DirectCast(Me.ActiveControl.Parent, KryptonTextBox).Multiline) Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
#End Region

#Region " MOVIMIENTO VENTANAS "
    Friend Sub anhadirManejadoresArrastre(ByRef eControl As Object)
        If TypeOf (eControl) Is Form Then
            AddHandler CType(eControl, Form).MouseDown, AddressOf pulsarRaton
            AddHandler CType(eControl, Form).MouseMove, AddressOf moverRaton
            AddHandler CType(eControl, Form).MouseUp, AddressOf soltarRaton

            For Each unControl As Object In CType(eControl, Form).Controls
                anhadirManejadoresArrastre(unControl)
            Next
        ElseIf TypeOf (eControl) Is KryptonGroup Then
            AddHandler CType(eControl, KryptonGroup).MouseDown, AddressOf pulsarRaton
            AddHandler CType(eControl, KryptonGroup).MouseMove, AddressOf moverRaton
            AddHandler CType(eControl, KryptonGroup).MouseUp, AddressOf soltarRaton

            AddHandler CType(eControl, KryptonGroup).Panel.MouseDown, AddressOf pulsarRaton
            AddHandler CType(eControl, KryptonGroup).Panel.MouseMove, AddressOf moverRaton
            AddHandler CType(eControl, KryptonGroup).Panel.MouseUp, AddressOf soltarRaton


            For Each unControl As Object In CType(eControl, KryptonGroup).Panel.Controls
                anhadirManejadoresArrastre(unControl)
            Next
        ElseIf TypeOf (eControl) Is KryptonGroupBox Then
            AddHandler CType(eControl, KryptonGroupBox).MouseDown, AddressOf pulsarRaton
            AddHandler CType(eControl, KryptonGroupBox).MouseMove, AddressOf moverRaton
            AddHandler CType(eControl, KryptonGroupBox).MouseUp, AddressOf soltarRaton

            AddHandler CType(eControl, KryptonGroupBox).Panel.MouseDown, AddressOf pulsarRaton
            AddHandler CType(eControl, KryptonGroupBox).Panel.MouseMove, AddressOf moverRaton
            AddHandler CType(eControl, KryptonGroupBox).Panel.MouseUp, AddressOf soltarRaton


            For Each unControl As Object In CType(eControl, KryptonGroupBox).Panel.Controls
                anhadirManejadoresArrastre(unControl)
            Next
        ElseIf TypeOf (eControl) Is TableLayoutPanel Then
            AddHandler CType(eControl, TableLayoutPanel).MouseDown, AddressOf pulsarRaton
            AddHandler CType(eControl, TableLayoutPanel).MouseMove, AddressOf moverRaton
            AddHandler CType(eControl, TableLayoutPanel).MouseUp, AddressOf soltarRaton

            For Each unControl As Object In CType(eControl, TableLayoutPanel).Controls
                anhadirManejadoresArrastre(unControl)
            Next
        ElseIf TypeOf (eControl) Is Panel Then
            AddHandler CType(eControl, Panel).MouseDown, AddressOf pulsarRaton
            AddHandler CType(eControl, Panel).MouseMove, AddressOf moverRaton
            AddHandler CType(eControl, Panel).MouseUp, AddressOf soltarRaton

            For Each unControl As Object In CType(eControl, Panel).Controls
                anhadirManejadoresArrastre(unControl)
            Next
        ElseIf TypeOf (eControl) Is UserControl Then
            AddHandler CType(eControl, UserControl).MouseDown, AddressOf pulsarRaton
            AddHandler CType(eControl, UserControl).MouseMove, AddressOf moverRaton
            AddHandler CType(eControl, UserControl).MouseUp, AddressOf soltarRaton

            For Each unControl As Object In CType(eControl, UserControl).Controls
                anhadirManejadoresArrastre(unControl)
            Next
        ElseIf TypeOf (eControl) Is Control AndAlso Not TypeOf (eControl) Is KryptonButton Then
            AddHandler CType(eControl, Control).MouseDown, AddressOf pulsarRaton
            AddHandler CType(eControl, Control).MouseMove, AddressOf moverRaton
            AddHandler CType(eControl, Control).MouseUp, AddressOf soltarRaton
        End If
    End Sub

    Private clicPulsado As Boolean = False
    Private p1, p2 As Point

    Private Sub pulsarRaton(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        clicPulsado = True
        p1 = Me.Location
        p2 = e.Location
    End Sub

    Private Sub moverRaton(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If clicPulsado Then Me.Location += (e.Location - p2)
    End Sub

    Private Sub soltarRaton(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        clicPulsado = False
    End Sub
#End Region

#Region " FORMULARIO "
    Private Sub frmPostInstalador_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        ' Se aplica la versión
        lblVersion.Text = "V. " & My.Application.Info.Version.ToString
        lblVersion.Visible = True

        ' Inicialización del Sistema de DEBUG
        ' Este siempre se activa
        Dim rutaDebug As String = Ficheros.StartUpPath & "\Recompila.Traductor.log"
        Log.iniciarSistemaLog(rutaDebug, True)
        Log._LOG_ACTIVO = True

        ' Se añaden los manejadores de arrastre al formulario
        anhadirManejadoresArrastre(Me)

        pasoActual = 1
        cargarPaso(pasoActual)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmPostInstalador_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim laRespuesta As MsgBoxResult
        laRespuesta = _KryptonForms.MostrarMensaje("¿Está seguro que desa cerrar " & Sistema.Configuracion._NOMBRE_APLICACION & "?",
                                                   "Cerrar " & Sistema.Configuracion._NOMBRE_APLICACION, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If laRespuesta = MsgBoxResult.Yes Then
            End
        Else
            e.Cancel = True
        End If
    End Sub
#End Region
End Class
