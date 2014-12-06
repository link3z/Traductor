Imports System.IO
Imports Recompila.Traductor
Imports Recompila.Helper
Imports Recompila.Controles

Public Class frmPrincipal

#Region "Mesagges for translate"
    Public Property theMessages As String() = { _
        "Debe escoger por lo menos un formulario para crear el fichero XML.", _
        "Debe escoger el idioma en el cual fue diseñada la aplicacion.", _
        "Debe escoger por lo menos un idioma al que traducir la aplicación.", _
        "Proyectos", _
        "El proceso se ha completado con éxito, se ha creado una carpeta Languages en el directorio de la aplicación con los ficheros XML necesarios para las traducciones." _
    }
#End Region


#Region " MOTORES DE TRADUCCIÓN "
    Private Sub cargarMotoresTraduccion()

        With cmbMotorTraduccion.Items
            .Clear()
            '.Add(New cMotorTraduccion(cMotorTraduccion.enmMotorTraducciones.Bing))
            '.Add(New cMotorTraduccion(cMotorTraduccion.enmMotorTraducciones.Google))
            '.Add(New cMotorTraduccion(cMotorTraduccion.enmMotorTraducciones.Online_Translator_com))
            '.Add(New cMotorTraduccion(cMotorTraduccion.enmMotorTraducciones.OpenTrad))
            '.Add(New cMotorTraduccion(cMotorTraduccion.enmMotorTraducciones.InterTran))
        End With
        cmbMotorTraduccion.SelectedIndex = 3
    End Sub

    Private Sub cmbMotorTraduccion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbMotorTraduccion.SelectedIndexChanged
        ' Se cargan los idiomas disponibles en los distintos componentes.
        ' Además, se marcan los que ya se encuentren en el directorio para continuar las traducciones.
        lstIdiomasExportacion.Items.Clear()
        'iTraductorGenerar.Motor = cmbMotorTraduccion.SelectedItem

        Dim rutaTraducciones As String = Sistema.Traduccion._PROYECTO_VB.carpetaTraducciones

        'For Each unIdioma As cIdioma In iTraductorGenerar.Idiomas
        '    Dim elIndice As Long = lstIdiomasExportacion.Items.Add(unIdioma)
        '    Dim seMarca As Boolean = IO.File.Exists(rutaTraducciones & "\" & unIdioma.Codigo & ".po")
        '    lstIdiomasExportacion.SetItemChecked(elIndice, seMarca)
        'Next
    End Sub
#End Region


#Region " CONSTRUCTORES Y CARGA "
    Private Sub frmPRINCIPAL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Objeto para la traducción de aplicaciones
        'iTraductorGenerar = New cTraductorPO(cTraductorPO.enmFinalidadTraductor.CrearTraducciones, True)

        ' Objeto para la traducción de formularios
        'iTraductorUsar = New cTraductorPO(cTraductorPO.enmFinalidadTraductor.UsarTraducciones, True)

        cmbIdiomaVentana.ImageList.Images.Clear()
        Dim indice As Long = 0
        'For Each unIdioma As cIdioma In iTraductorUsar.Idiomas
        '    cmbIdiomaVentana.ImageList.Images.Add(indice, unIdioma.Bandera)
        '    Dim nuevoItem As rComboBoxIconItem = New rComboBoxIconItem(unIdioma, indice)
        '    cmbIdiomaVentana.Items.Add(nuevoItem)
        '    indice += 1
        '    If unIdioma.codigoLocalizacion = idiomaLocalizacion.es_ES Then cmbIdiomaVentana.SelectedItem = nuevoItem
        'Next

        ' Carga las opciones de selección de formularios
        WinForms.Selecciones.anhadirOpcionesSeleccion(cmbOpcionesSeleccion)

        ' Se cargan los motores de traducción disponibles
        cargarMotoresTraduccion()
    End Sub
#End Region

#Region " GENERACIÓN DE FICHEROS PO "
    Private Sub btnCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrear.Click
        'Dim laRespuesta As MsgBoxResult
        'laRespuesta = _KryptonForms.MostrarMensaje("¡ Atención !" & vbCrLf & vbCrLf & "Se van modificar todos los archivos .VB del proyecto volviéndolos a codificiar en UTF-8. Antes de continuar, ES MUY IMPORTANTE HACER UNA COPIA DE SEGURIDAD DEL PROYECTO por si durante este proceso se pudiera producir algún tipo de problema." & vbCrLf & vbCrLf & "¿Ya está la copia de seguridad lista?", _
        '                                                    "Codificación UTF8", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        'If laRespuesta = MsgBoxResult.No Then Exit Sub

        'txtMensajes.Clear()

        'If txtNombreEnsamblado.Text = "" Then
        '    MsgBox("Debes seleccionar el nombre del ensamblado.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        '    Exit Sub
        'End If

        'If txtVersion.Text = "" Then
        '    MsgBox("Debes seleccionar la versión del ensamblado para la generación del fichero de salida.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        '    Exit Sub
        'End If

        'If chklFormulariosExportar.CheckedItems.Count = 0 Then
        '    'MSG 1 : "Debe escoger por lo menos un formulario para crear el fichero XML."
        '    MsgBox(theMessages(0), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        '    Exit Sub
        'End If

        'If lstIdiomasExportacion.CheckedItems.Count = 0 Then
        '    'MSG 3 : "Debe escoger por lo menos un idioma al que traducir la aplicación."
        '    MsgBox(theMessages(2), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        '    Exit Sub
        'End If

        'WinForms.ProgressBar.fijarMinimoBarra(pbMayor, 0)
        'WinForms.ProgressBar.fijarMaximoBarra(pbMayor, chklFormulariosExportar.CheckedItems.Count + 1)
        'WinForms.ProgressBar.FijarBarra(pbMayor, 0)

        '' Lista de los lenguajes de los que se van a generar las traducciones
        'Dim ListaLenguajesExportar As New List(Of cIdioma)
        'For Each unIdioma As cIdioma In lstIdiomasExportacion.CheckedItems
        '    If Not ListaLenguajesExportar.Contains(unIdioma) Then ListaLenguajesExportar.Add(unIdioma)
        'Next

        '' Se añade el propio lenguaje como lenguaje a traducir
        'Dim elSpanish As cIdioma = cIdioma.ObtenerObjetoIdioma(idiomaNombre.Spanish)
        'If Not ListaLenguajesExportar.Contains(elSpanish) Then ListaLenguajesExportar.Add(elSpanish)

        '' Se crea la carpeta para los lenguajes si todavía no existe
        'Dim RutaProyecto As String = Ficheros.extraerRutaFichero(txtRutaProyecto.Text)
        'Dim RutaTraducciones As String = RutaProyecto & "\Languages\" & Criptografia.encriptarEnMD5(txtNombreEnsamblado.Text) & "\"
        'If Not IO.Directory.Exists(RutaTraducciones) Then IO.Directory.CreateDirectory(RutaTraducciones)

        '' Se copian los ficheros actuales en la versión de generación, los cuales serán
        '' utilizados para comprobar si el texto ya está traducido o no
        'Dim ExistenIdiomas As Boolean = False
        'Dim RutaIdioma_original As String = ""
        'Dim RutaIdioma_destino As String = ""
        'For Each UnIdioma As cIdioma In ListaLenguajesExportar
        '    RutaIdioma_original = RutaTraducciones & UnIdioma.Codigo & ".po"
        '    RutaIdioma_destino = RutaTraducciones & UnIdioma.Codigo & "_" & txtVersion.Text & ".po"
        '    If IO.File.Exists(RutaIdioma_destino) Then IO.File.Delete(RutaIdioma_destino)
        '    If IO.File.Exists(RutaIdioma_original) Then
        '        IO.File.Move(RutaIdioma_original, RutaIdioma_destino)
        '    End If
        'Next

        '' Se crean todos los ficheros PO de salida con la cabecera de cada fichero
        'Dim RutaIdioma As String = ""
        'For Each UnIdioma As cIdioma In ListaLenguajesExportar
        '    RutaIdioma = RutaTraducciones & UnIdioma.Codigo & ".po"
        '    If IO.File.Exists(RutaIdioma) Then IO.File.Delete(RutaIdioma)
        '    Dim elEscritorPO As New StreamWriter(RutaIdioma, False, System.Text.Encoding.UTF8)
        '    cTraductorPO.EscribirCabeceraPO(elEscritorPO, txtNombreEnsamblado.Text, UnIdioma.Codigo)
        '    elEscritorPO.Close()
        'Next

        '' Se recorren todos los formualarios para realizar las traducciones        
        'For i As Integer = 0 To chklFormulariosExportar.CheckedItems.Count - 1
        '    iTraductorGenerar.generarFicheroOP_VB(RutaProyecto, _
        '                                          RutaTraducciones, _
        '                                          chklFormulariosExportar.CheckedItems(i), _
        '                                          ListaLenguajesExportar, _
        '                                          cmbMotorTraduccion.SelectedItem, _
        '                                          False, _
        '                                          False, _
        '                                          txtMensajes, _
        '                                          txtVersion.Text, _
        '                                          pbMenor)
        '    WinForms.ProgressBar.AumentarBarra(pbMayor)
        'Next

        'WinForms.ProgressBar.FijarBarra(pbMayor, pbMayor.Maximum)
        'WinForms.ProgressBar.FijarBarra(pbMenor, pbMenor.Minimum)


        ''MSG 4 : "El proceso se ha completado con éxito, se ha creado una carpeta Languages en el directorio de la aplicación con los ficheros XML necesarios para las traducciones."
        'MsgBox(theMessages(4), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        'WinForms.ProgressBar.FijarBarra(pbMayor, pbMayor.Minimum)

    End Sub
#End Region

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmbOpcionesSeleccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOpcionesSeleccion.SelectedIndexChanged
        WinForms.Selecciones.marcarSeleccionados(chklFormulariosExportar, cmbOpcionesSeleccion.SelectedIndex)
    End Sub

    Private Sub cmbIdiomaVentana_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdiomaVentana.SelectedIndexChanged
        If cmbIdiomaVentana IsNot Nothing Then
            'iTraductorUsar.traducirObjetos(Me, cmbIdiomaVentana.SelectedItemReal, Me.Name)
        End If
    End Sub

#Region " CARGA DE FORMULARIOS "
    Private Sub txtRutaProyecto_CambioRuta(eRuta As String) Handles txtRutaProyecto.CambioRuta
        'cTraductorPO.obtenerFormulariosProyecto(txtRutaProyecto.text, chklFormulariosExportar)
        'txtNombreEnsamblado.Text = cTraductorPO.obtenerNombreEnsamblado(txtRutaProyecto.text)
        'cTraductorPO.cargarVersionTraduccion(txtRutaProyecto.text, Me.txtVersion)
        cmbMotorTraduccion_SelectedIndexChanged(Nothing, Nothing)
    End Sub
#End Region

End Class