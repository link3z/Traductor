Public MustInherit Class cMotorBase
#Region " DECLARACIONES "
    ''' <summary>
    ''' Tipo del motor utilizado para identificarlo
    ''' </summary>
    Public MustOverride ReadOnly Property Tipo As motorTraduccion

    ''' <summary>
    ''' Tiempo de espera entre traducciones para evitar sobrecarga de CPU
    ''' y de la propia página de traducción.
    ''' Este tiempo variará dependiendo del motor que se utilice
    ''' </summary>
    Public Property SleepTime As Long
        Get
            Return iSleepTime
        End Get
        Set(value As Long)
            iSleepTime = value
        End Set
    End Property
    Private iSleepTime As Long = 0
#End Region
End Class
