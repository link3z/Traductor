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
        epErrores.Clear()
    End Sub

    Public Sub PrepararCierre() Implements ICBase.PrepararCierre

    End Sub

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
End Class
