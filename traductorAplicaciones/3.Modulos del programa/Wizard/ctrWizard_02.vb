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
        txtRutaProyecto.Text = ""
        txtNombreEnsamblado.Text = ""
        txtVersion.Text = ""
        chklObjetos.Items.Clear()
        gestorErrores.Clear()
    End Sub

    Public Function PrepararCierre() As Boolean Implements ICBase.PrepararCierre

        Return True
    End Function

    Public Function Cargar(eObjeto As Object) As Boolean Implements IControlWizard.Cargar
        ' Si ya estaba establecido un proyecto o se cargó, se cargan los datos
        If Sistema.Traduccion._PROYECTO_VB IsNot Nothing Then
            txtRutaProyecto.Text = Sistema.Traduccion._PROYECTO_VB.rutaProyecto
            txtRutaProyecto_CambioRuta(Sistema.Traduccion._PROYECTO_VB.rutaProyecto)

            If Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ArchivosVB IsNot Nothing AndAlso Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ArchivosVB.Count > 0 Then
                For i As Integer = 0 To chklObjetos.Items.Count - 1
                    Dim estabaMarcado As Boolean = False
                    Dim laRutaCompleta As String = CType(chklObjetos.Items(i), cArchivoVB).RutaCompleta
                    estabaMarcado = ((From it As cArchivoVB In Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ArchivosVB _
                                      Where it.RutaCompleta = laRutaCompleta _
                                      Select it).Count > 0)
                    chklObjetos.SetItemChecked(i, estabaMarcado)
                Next
            End If
        End If

        ' Se cargan el resto de parámetros
        chkGuardar.Checked = Sistema.Traduccion._GUARDAR_AL_FINALIZAR

        Return True
    End Function

    Public Sub CargarDatosMaestros() Implements IControlWizard.CargarDatosMaestros
        ' Carga las opciones de selección de formularios
        WinForms.Selecciones.anhadirOpcionesSeleccion(cmbOpcionesSeleccion)

    End Sub

    Public Sub DarFoco() Implements IControlWizard.DarFoco
        txtRutaProyecto.Focus()
    End Sub

    Public Function ExistenErrores() As Boolean Implements IControlWizard.ExistenErrores
        ' Se verifica que el proyecto cargado sea válido, en caso contrario no se puede
        ' continuar
        If Sistema.Traduccion._PROYECTO_VB Is Nothing Then
            gestorErrores.SetError(txtRutaProyecto, "El proyecto seleccionado no parece ser válido.")
            Return True
        End If

        Me.ValidateChildren()
        Return (gestorErrores.HasErrors)
    End Function

    Public Function Guardar(ByRef eObjeto As Object) As Object Implements IControlWizard.Guardar
        ' Se guardan todos los objetos que se van a traducir
        Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ArchivosVB = New List(Of cArchivoVB)

        For Each unObjeto As cArchivoVB In chklObjetos.CheckedItems
            If Not Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ArchivosVB.Contains(unObjeto) Then
                Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ArchivosVB.Add(unObjeto)
            End If
        Next

        ' Se guarda el resto de parámetros
        Sistema.Traduccion._GUARDAR_AL_FINALIZAR = chkGuardar.Checked

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
            Sistema.Traduccion._PROYECTO_VB = New cProyectoVB(txtRutaProyecto.Text)

            ' Se obtienen todos los formularios disponibles en el proyecto
            If Log._LOG_ACTIVO Then Log.escribirLog("Obteniendo los objetos NET a traducir...", , New StackTrace(0, True))
            Dim losObjetosNet As List(Of cArchivoVB) = Sistema.Traduccion._PROYECTO_VB.Formularios
            If losObjetosNet IsNot Nothing AndAlso losObjetosNet.Count > 0 Then
                chklObjetos.Items.AddRange(losObjetosNet.ToArray)
            Else
                If Log._LOG_ACTIVO Then Log.escribirLog("WARNING no se encontrarion objetos NET a traducir...", , New StackTrace(0, True))
            End If

            ' Se obtiene el nombre del ensamblado
            If Log._LOG_ACTIVO Then Log.escribirLog("Obteniendo el nombre del ensamblado a traducir...", , New StackTrace(0, True))
            txtNombreEnsamblado.Text = Sistema.Traduccion._PROYECTO_VB.Ensamblado

            ' Se obtiene la siguiente versión de traducción
            If Log._LOG_ACTIVO Then Log.escribirLog("Oteniendo la versión de traducción disponible del proyecto...", , New StackTrace(0, True))
            txtVersion.Text = Sistema.Traduccion._PROYECTO_VB.versionTraduccion

            ' Se seleccionan todos los formuarios
            cmbOpcionesSeleccion.SelectedIndex = 0
            cmbOpcionesSeleccion_SelectedIndexChanged(Nothing, Nothing)
        Else
            Sistema.Traduccion._PROYECTO_VB = Nothing
            If Log._LOG_ACTIVO Then Log.escribirLog("No se puede cagar el proyecto '" & eRuta & "' ya que no existe la ruta...", , New StackTrace(0, True))
        End If
    End Sub

    Private Sub cmbOpcionesSeleccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOpcionesSeleccion.SelectedIndexChanged
        WinForms.Selecciones.marcarSeleccionados(chklObjetos, cmbOpcionesSeleccion.SelectedIndex)
    End Sub
#End Region

#Region " VALIDADORES "
    Private Sub txtRutaProyecto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRutaProyecto.Validating
        If Not IO.File.Exists(txtRutaProyecto.Text) Then
            gestorErrores.SetError(txtRutaProyecto, "Es necesario que se seleccione el proyecto a traducir.")
        Else
            gestorErrores.SetError(txtRutaProyecto, "")
        End If
    End Sub

    Private Sub chklObjetos_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles chklObjetos.Validating
        If chklObjetos.CheckedItems.Count <= 0 Then
            gestorErrores.SetError(cmbOpcionesSeleccion, "Es necesario que se seleccione algún formulario para traducir.")
        Else
            gestorErrores.SetError(cmbOpcionesSeleccion, "")
        End If
    End Sub
#End Region
End Class
