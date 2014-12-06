Imports Recompila.Traductor
Imports Recompila.Helper

Public Class ctrWizard_05
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
        epErrores.Clear()
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

    End Sub

    Public Function ExistenErrores() As Boolean Implements IControlWizard.ExistenErrores
        Me.ValidateChildren()
        Return (epErrores.HasErrors)
    End Function

    Public Function Guardar(ByRef eObjeto As Object) As Object Implements IControlWizard.Guardar

        Return True
    End Function
#End Region

#Region " FORMULARIO "
    Private Sub ctrWizard_1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        ' Lo primero que se hace es guardar una copia del proyecto de traducción
        ' si se activó la opción de guardado automático
        If Sistema.Traduccion._GUARDAR_AL_FINALIZAR Then
            Dim laRuta As String = Sistema.Traduccion._PROYECTO_VB.carpetaProyecto & "\" & Sistema.Traduccion._PROYECTO_VB.Ensamblado & Sistema.Configuracion._EXTENSION_TRADUCTOR
            Sistema.Traduccion._CONFIGURACION_TRADUCTOR.guardar(laRuta)
        End If

        iCargando = False
        frmWizard.btnSiguiente.Enabled = True
    End Sub

    Private Sub lnkInformacionUso_LinkClicked(sender As Object, e As EventArgs) Handles lnkInformacionUso.LinkClicked
        ' ToDo: Meter la página real
        Try
            Shell("explorer ""http://recompila.com/""", AppWinStyle.NormalFocus)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lnkAbrirCarpetaPO_LinkClicked(sender As Object, e As EventArgs) Handles lnkAbrirCarpetaPO.LinkClicked
        Try
            Shell("explorer """ & Sistema.Traduccion._PROYECTO_VB.carpetaTraducciones & "", AppWinStyle.NormalFocus)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lnkDescargarPoedit_LinkClicked(sender As Object, e As EventArgs) Handles lnkDescargarPoedit.LinkClicked
        Try
            Shell("explorer ""http://poedit.net/""", AppWinStyle.NormalFocus)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lnkGuardarProyecto_LinkClicked(sender As Object, e As EventArgs) Handles lnkGuardarProyecto.LinkClicked        
        Dim laRuta As String = Ficheros.Buscar.BuscarArchivoGuardar("Guardar proyecto " & Sistema.Configuracion._NOMBRE_APLICACION, _
                                                                     Sistema.Traduccion._PROYECTO_VB.carpetaProyecto, _
                                                                     Sistema.Configuracion._EXTENSION_TRADUCTOR, _
                                                                     Sistema.Traduccion._PROYECTO_VB.Ensamblado & Sistema.Configuracion._EXTENSION_TRADUCTOR)

        If Not String.IsNullOrEmpty(laRuta) Then

        End If
    End Sub

    Private Sub lnkReiniciarAsistente_LinkClicked(sender As Object, e As EventArgs) Handles lnkReiniciarAsistente.LinkClicked
        If Sistema.Traduccion._GUARDAR_AL_FINALIZAR Then
            Sistema.Traduccion._RUTA_RTRAD = Sistema.Traduccion._PROYECTO_VB.carpetaProyecto & "\" & Sistema.Traduccion._PROYECTO_VB.Ensamblado & Sistema.Configuracion._EXTENSION_TRADUCTOR
        Else
            Sistema.Traduccion._RUTA_RTRAD = ""
        End If
        Sistema.Traduccion._CONFIGURACION_TRADUCTOR = Nothing
        Sistema.Traduccion._GUARDAR_AL_FINALIZAR = True
        Sistema.Traduccion._OPERACION = Operacion.AbrirProyecto
        Sistema.Traduccion._PROYECTO_VB = Nothing

        ' Se vuelve al paso inicial del Wizard
        frmWizard.cargarPaso(1)
    End Sub

#End Region


End Class
