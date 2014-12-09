Imports Recompila.Helper
Imports Recompila.Traductor

Public Class ctrWizard_03
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
        chkTraducirMensajes.Checked = True
        chklObjetos.Items.Clear()
        gestorErrores.Clear()
    End Sub

    Public Function PrepararCierre() As Boolean Implements ICBase.PrepararCierre

        Return True
    End Function

    Public Function Cargar(eObjeto As Object) As Boolean Implements IControlWizard.Cargar
        ' Si ya estaba establecido un proyecto o se cargó, se cargan los datos
        If Sistema.Traduccion._CONFIGURACION_TRADUCTOR IsNot Nothing Then
            chkTraducirMensajes.Checked = Sistema.Traduccion._CONFIGURACION_TRADUCTOR.TraducirMensajes

            If Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ControlesNET IsNot Nothing AndAlso Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ControlesNET.Count > 0 Then
                For i As Integer = 0 To chklObjetos.Items.Count - 1
                    Dim estabaMarcado As Boolean = False
                    Dim elNombre As String = CType(chklObjetos.Items(i), NET.cControl).Tipo
                    estabaMarcado = ((From it As NET.cControl In Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ControlesNET _
                                      Where it.Tipo = elNombre _
                                      Select it).Count > 0)
                    chklObjetos.SetItemChecked(i, estabaMarcado)
                Next
            End If
        End If

        Return True
    End Function

    Public Sub CargarDatosMaestros() Implements IControlWizard.CargarDatosMaestros
        ' Carga las opciones de selección de formularios
        WinForms.Selecciones.anhadirOpcionesSeleccion(cmbOpcionesSeleccion)

        ' Se cargan todos los objetos que se pueden traducir predeterminados del sistema
        If Sistema.Configuracion._DEFAULT_CONTROLS IsNot Nothing AndAlso Sistema.Configuracion._DEFAULT_CONTROLS.Count > 0 Then
            For Each unObjeto As NET.cControl In Sistema.Configuracion._DEFAULT_CONTROLS
                Try
                    If Not chklObjetos.Items.Contains(unObjeto) Then
                        Dim i As Integer = chklObjetos.Items.Add(unObjeto)
                        chklObjetos.SetItemChecked(i, True)
                    End If
                Catch ex As Exception
                End Try
            Next
        End If

        ' Se cargan los objetos que se pueden traducir Añadidos por el usuario
        If Sistema.Configuracion._USER_CONTROLS IsNot Nothing AndAlso Sistema.Configuracion._USER_CONTROLS.Count > 0 Then
            For Each unObjeto As NET.cControl In Sistema.Configuracion._USER_CONTROLS
                Try
                    If Not chklObjetos.Items.Contains(unObjeto) Then
                        Dim i As Integer = chklObjetos.Items.Add(unObjeto)
                        chklObjetos.SetItemChecked(i, True)
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub

    Public Sub DarFoco() Implements IControlWizard.DarFoco
        chkTraducirMensajes.Focus()
    End Sub

    Public Function ExistenErrores() As Boolean Implements IControlWizard.ExistenErrores
        Me.ValidateChildren()
        Return (gestorErrores.HasErrors)
    End Function

    Public Function Guardar(ByRef eObjeto As Object) As Object Implements IControlWizard.Guardar
        ' Se guardan todos los objetos que se van a traducir
        Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ControlesNET = New List(Of NET.cControl)

        For Each unObjeto As NET.cControl In chklObjetos.CheckedItems
            If Not Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ControlesNET.Contains(unObjeto) Then
                Sistema.Traduccion._CONFIGURACION_TRADUCTOR.ControlesNET.Add(unObjeto)
            End If
        Next

        ' Se guarda el resto de parámetros
        Sistema.Traduccion._CONFIGURACION_TRADUCTOR.TraducirMensajes = chkTraducirMensajes.Checked

        Return True
    End Function
#End Region

#Region " FORMULARIO "
    Private Sub ctrWizard_3_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        iCargando = False
        frmWizard.btnSiguiente.Enabled = True
    End Sub
#End Region

#Region " LIMPIAR "

#End Region

#Region " PROYECTO Y FORMULARIO "
    Private Sub cmbOpcionesSeleccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOpcionesSeleccion.SelectedIndexChanged
        WinForms.Selecciones.marcarSeleccionados(chklObjetos, cmbOpcionesSeleccion.SelectedIndex)
    End Sub
#End Region

#Region " VALIDADORES "
    Private Sub chklObjetos_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If chklObjetos.CheckedItems.Count <= 0 Then
            gestorErrores.SetError(cmbOpcionesSeleccion, "Es necesario que se seleccione algún objeto/control para traducir.")
        Else
            gestorErrores.SetError(cmbOpcionesSeleccion, "")
        End If
    End Sub
#End Region
End Class
