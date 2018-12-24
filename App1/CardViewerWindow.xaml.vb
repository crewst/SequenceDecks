' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class CardViewerWindow
    Inherits Page


    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        Me.InitializeComponent()
        ApplicationView.GetForCurrentView().TryEnterFullScreenMode()
        With ViewGrid
            .Width = Me.Width
            .Height = Me.Height
        End With

    End Sub
End Class
