Imports Recompila.Helper
Imports Recompila.Traductor

Public Class ctrWizard_02
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
        ' Carga las opciones de selección de formularios
        WinForms.Selecciones.anhadirOpcionesSeleccion(cmbOpcionesSeleccion)


    End Sub

    Public Sub DarFoco() Implements IControlWizard.DarFoco

    End Sub

    Public Function ExistenErrores() As Boolean Implements IControlWizard.ExistenErrores
        Me.ValidateChildren()
        Return (gestorErrores.HasErrors)
    End Function

    Public Function Guardar(eObjeto As Object) As Object Implements IControlWizard.Guardar

        Return True
    End Function
#End Region

#Region " FORMULARIO "
    Private Sub ctrWizard_1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        iCargando = False
        frmWizard.btnSiguiente.Enabled = True
    End Sub
#End Region

#Region " LIMPIAR "

#End Region

#Region " PROYECTO Y FORMULARIO "
    Private Sub txtRutaProyecto_CambioRuta(eRuta As String) Handles txtRutaProyecto.CambioRuta
        If Log._LOG_ACTIVO Then Log.escribirLog("Cargando proyecto '" & eRuta & "'...", , New StackTrace(0, True))
        txtNombreEnsamblado.Text = ""
        txtVersion.Text = ""
        chklObjetos.Items.Clear()

        If IO.File.Exists(eRuta) Then
            Sistema.Configuracion.proyectoVB = New cProyectoVB(txtRutaProyecto.Text)

            ' Se obtienen todos los formularios disponibles en el proyecto
            If Log._LOG_ACTIVO Then Log.escribirLog("Obteniendo los objetos NET a traducir...", , New StackTrace(0, True))
            Dim losObjetosNet As List(Of cFicheroVB) = cTraductorPO.obtenerFormulariosProyecto(txtRutaProyecto.Text)
            If losObjetosNet IsNot Nothing AndAlso losObjetosNet.Count > 0 Then
                chklObjetos.Items.AddRange(losObjetosNet.ToArray)
            Else
                If Log._LOG_ACTIVO Then Log.escribirLog("WARNING no se encontrarion objetos NET a traducir...", , New StackTrace(0, True))
            End If

            ' Se obtiene el nombre del ensamblado
            If Log._LOG_ACTIVO Then Log.escribirLog("Obteniendo el nombre del ensamblado a traducir...", , New StackTrace(0, True))
            txtNombreEnsamblado.Text = Sistema.Configuracion.proyectoVB.Ensamblado

            ' Se obtiene la siguiente versión de traducción
            If Log._LOG_ACTIVO Then Log.escribirLog("Oteniendo la versión de traducción disponible del proyecto...", , New StackTrace(0, True))
            txtVersion.Text = Sistema.Configuracion.proyectoVB.versionTraduccion

            ' Se seleccionan todos los formuarios
            cmbOpcionesSeleccion.SelectedIndex = 0
            cmbOpcionesSeleccion_SelectedIndexChanged(Nothing, Nothing)
        Else
            Sistema.Configuracion.proyectoVB = Nothing
            If Log._LOG_ACTIVO Then Log.escribirLog("No se puede cagar el proyecto '" & eRuta & "' ya que no existe la ruta...", , New StackTrace(0, True))
        End If
    End Sub

    Private Sub cmbOpcionesSeleccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOpcionesSeleccion.SelectedIndexChanged
        WinForms.Selecciones.marcarSeleccionados(chklObjetos, cmbOpcionesSeleccion.SelectedIndex)
    End Sub
#End Region

End Class
