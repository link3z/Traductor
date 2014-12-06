Imports Recompila
Imports Recompila.Helper
Imports Recompila.Controles
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
        cmbIdiomaOriginal.Items.Clear()
        cmbMotorTraduccion.Items.Clear()
        txtTraduccionEmail.Text = ""
        txtTraduccionEquipo.Text = ""
        txtTraduccionTraductor.Text = ""
        chklIdiomasDestino.Items.Clear()

        gestorErrores.Clear()
    End Sub

    Public Function PrepararCierre() As Boolean Implements ICBase.PrepararCierre

        Return True
    End Function

    Public Function Cargar(eObjeto As Object) As Boolean Implements IControlWizard.Cargar
        Cargando = True

        If Sistema.Traduccion._CONFIGURACION_TRADUCTOR IsNot Nothing Then
            With Sistema.Traduccion._CONFIGURACION_TRADUCTOR
                ' Carga el motor utilizado para la traducción
                Dim elMotor As cMotorBase = Nothing
                elMotor = (From it As cMotorBase In cmbMotorTraduccion.Items _
                           Where it.Tipo = .Motor _
                           Select it).FirstOrDefault
                If elMotor IsNot Nothing Then cmbMotorTraduccion.SelectedItem = elMotor

                ' Carga del idioma original
                Dim elIdiomaOriginal As rComboBoxIconItem = Nothing
                elIdiomaOriginal = (From it As rComboBoxIconItem In cmbIdiomaOriginal.Items _
                                    Where CType(it.Item, cIdioma).codigoLocalizacion = .IdiomaOrigen _
                                    Select it).FirstOrDefault
                If elIdiomaOriginal IsNot Nothing Then cmbIdiomaOriginal.SelectedItem = elIdiomaOriginal

                ' Se cargan los datos del equipo de traducción
                txtTraduccionEquipo.Text = .TraductorEquipo
                txtTraduccionTraductor.Text = .TraductorNombre
                txtTraduccionEmail.Text = .TraductorEmail

                ' Se carga los idiomas de destino de la traducción
                ' Al cargarse se van a tener en cuenta los idiomas que pudieran estar seleccionados
                cargarIdiomasDestino()
            End With
        End If

        Cargando = False
        Return True
    End Function

    Public Sub CargarDatosMaestros() Implements IControlWizard.CargarDatosMaestros
        cargarIdiomasOrigen()
        cargarMotoresTraduccion()
        cargarIdiomasDestino()
    End Sub

    Public Sub DarFoco() Implements IControlWizard.DarFoco
        cmbIdiomaOriginal.Focus()
    End Sub

    Public Function ExistenErrores() As Boolean Implements IControlWizard.ExistenErrores
        Me.ValidateChildren()
        Return (gestorErrores.HasErrors)
    End Function

    Public Function Guardar(ByRef eObjeto As Object) As Object Implements IControlWizard.Guardar
        Dim elIdiomaOrigen As cIdioma = cmbIdiomaOriginal.SelectedItemReal
        Dim elMotor As cMotorBase = cmbMotorTraduccion.SelectedItem

        With Sistema.Traduccion._CONFIGURACION_TRADUCTOR
            .IdiomaOrigen = elIdiomaOrigen.codigoLocalizacion
            .Motor = elMotor.Tipo

            .TraductorNombre = txtTraduccionTraductor.Text
            .TraductorEquipo = txtTraduccionEquipo.Text
            .TraductorEmail = txtTraduccionEmail.Text

            .IdiomasDestino = New List(Of idiomaLocalizacion)
            For i As Integer = 0 To chklIdiomasDestino.Items.Count - 1
                If chklIdiomasDestino.GetItemChecked(i) Then
                    .IdiomasDestino.Add(CType(chklIdiomasDestino.Items(i), cIdioma).codigoLocalizacion)
                End If
            Next
        End With

        Return True
    End Function
#End Region

#Region " METODOS AUXILIARES "

    Private Sub cargarIdiomasOrigen()
        cmbIdiomaOriginal.ImageList.Images.Clear()
        Dim indice As Long = 0


        Dim elIdioma As New cIdioma(idiomaLocalizacion.es_ES)
        cmbIdiomaOriginal.ImageList.Images.Add(indice, Imagenes.imagenAIcono(imagenesBanderas(elIdioma.codigoLocalizacion)))
        Dim nuevoItem As rComboBoxIconItem = New rComboBoxIconItem(elIdioma, indice)
        cmbIdiomaOriginal.Items.Add(nuevoItem)
        cmbIdiomaOriginal.SelectedIndex = 0

        ' ToDo: Terminar de configurar el resto de idiomas

        '' Si no hay seleccionado un motor de traducción se cargan todos los idiomas disponibles,
        '' en caso contrario, se cargan los idiomas de origen a los que puede traducir el motor
        'If cmbMotorTraduccion.SelectedIndex >= 0 Then
        '    Dim elMotorSeleccionado As IMotorTraduccion = cmbMotorTraduccion.SelectedItem

        '    For Each unCodigoIdioma As idiomaLocalizacion In elMotorSeleccionado.TiposTraduccion.Keys
        '        Dim elIdioma As New cIdioma(unCodigoIdioma)
        '        cmbIdiomaOriginal.ImageList.Images.Add(indice, Imagenes.imagenAIcono(imagenesBanderas(elIdioma.codigoLocalizacion)))
        '        Dim nuevoItem As rComboBoxIconItem = New rComboBoxIconItem(elIdioma, indice)
        '        cmbIdiomaOriginal.Items.Add(nuevoItem)
        '        indice += 1
        '    Next
        'Else
        '    For Each unCodigoIdioma As idiomaLocalizacion In System.Enum.GetValues(GetType(idiomaLocalizacion))
        '        Dim elIdioma As New cIdioma(unCodigoIdioma)
        '        cmbIdiomaOriginal.ImageList.Images.Add(indice, Imagenes.imagenAIcono(imagenesBanderas(elIdioma.codigoLocalizacion)))
        '        Dim nuevoItem As rComboBoxIconItem = New rComboBoxIconItem(elIdioma, indice)
        '        cmbIdiomaOriginal.Items.Add(nuevoItem)
        '        indice += 1
        '    Next
        'End If
    End Sub

    Private Sub cargarIdiomasDestino()
        chklIdiomasDestino.Items.Clear()

        ' Se obtienen los valores del motor e idioma de origen seleccionado, si estos parámetros
        ' no están cargados no se pueden cargar los idiomas de destino
        Dim elMotorSeleccionado As IMotorTraduccion = cmbMotorTraduccion.SelectedItem
        Dim elIdiomaSeleccionado As cIdioma = cmbIdiomaOriginal.SelectedItemReal
        If elMotorSeleccionado Is Nothing Or elIdiomaSeleccionado Is Nothing Then Exit Sub

        ' Si el código llega hasta este punto están seleccionados tanto el idioma de origen
        ' como el motor, por lo que se pueden cargar los idiomas de destino, evitando cargar
        ' el idioma de origen
        For Each unCodigoIdima As idiomaLocalizacion In elMotorSeleccionado.TiposTraduccion(elIdiomaSeleccionado.codigoLocalizacion)
            If unCodigoIdima <> elIdiomaSeleccionado.codigoLocalizacion Then
                Dim elIdioma As New cIdioma(unCodigoIdima)
                chklIdiomasDestino.Items.Add(elIdioma)
            End If
        Next

        ' Se seleccionan los idiomas que están configurados en la configuración del proyecto
        If Sistema.Traduccion._CONFIGURACION_TRADUCTOR IsNot Nothing Then
            With Sistema.Traduccion._CONFIGURACION_TRADUCTOR
                If chklIdiomasDestino.Items.Count > 0 Then
                    For i As Integer = 0 To chklIdiomasDestino.Items.Count - 1
                        Dim elIdioma As cIdioma = chklIdiomasDestino.Items(i)
                        chklIdiomasDestino.SetItemChecked(i, (.IdiomasDestino.Contains(elIdioma.codigoLocalizacion)))
                    Next
                End If
            End With
        End If

    End Sub

    Private Sub cargarMotoresTraduccion()
        With cmbMotorTraduccion.Items
            .Clear()
            .Add(New cMotorGoogle)
            .Add(New cMotorOpenTrad)
            .Add(New cMotorIntertran)
            .Add(New cMotorOnlineTranslator)
        End With
        cmbMotorTraduccion.SelectedIndex = 0
    End Sub
#End Region

#Region " FORMULARIO "
    Private Sub ctrWizard_1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        iCargando = False
        frmWizard.btnSiguiente.Enabled = True
    End Sub

    Private Sub cmbIdiomaOriginal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIdiomaOriginal.SelectedIndexChanged
        If Cargando Then Exit Sub
        cargarIdiomasDestino()
    End Sub

    Private Sub cmbMotorTraduccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMotorTraduccion.SelectedIndexChanged
        If Cargando Then Exit Sub
        cargarIdiomasDestino()
    End Sub
#End Region

#Region " VALIDADORES "
    Private Sub chklIdiomasDestino_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles chklIdiomasDestino.Validating
        If chklIdiomasDestino.CheckedItems.Count = 0 Then
            gestorErrores.SetError(chklIdiomasDestino, "Es necesario que seleccione al menos un idioma para realizar la traducción.")
        Else
            gestorErrores.SetError(chklIdiomasDestino, "")
        End If
    End Sub
#End Region
End Class
