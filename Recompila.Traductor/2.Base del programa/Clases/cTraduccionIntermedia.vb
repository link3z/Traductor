''' <summary>
''' Utilizado para la traducción intermedia. 
''' Se encarga de guardar una relación entre un índice utilizado para la generación
''' del HTML en la página Web que se va a atraducir, el nombre del control del formulario,
''' el texto original y la traducción obtenida desde el motor de traducción
''' </summary>
Friend Class cTraduccionIntermedia
    Public Property Indice As Long
    Public Property NombreControl As String
    Public Property Original As String
    Public Property Traduccion As String
End Class