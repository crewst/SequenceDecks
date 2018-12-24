' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Public mainTitleBar = Core.CoreApplication.GetCurrentView().TitleBar
    Public mainTitleBarProperties = ApplicationView.GetForCurrentView().TitleBar

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        Me.InitializeComponent()
        ApplicationView.PreferredLaunchViewSize = New Size(400, 800)
        ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize
        mainTitleBar.ExtendViewIntoTitleBar = True
        mainTitleBarProperties.ButtonBackgroundColor = Windows.UI.Colors.Transparent
    End Sub

    Private Sub PivotItems_Handler(sender As Object, args As RoutedEventArgs)
        If sender Is numbersButton Then
            Debug.WriteLine("Numbers Button Clicked")
            numbersButton.IsChecked = True
            lettersButton.IsChecked = False
            builderPivot.SelectedIndex = 0
        ElseIf sender Is lettersButton Then
            Debug.WriteLine("Letters Button Clicked")
            lettersButton.IsChecked = True
            numbersButton.IsChecked = False
            builderPivot.SelectedIndex = 1
        End If
    End Sub

    Private Sub NumbersQuantitySlider_Changed(sender As Object, e As RangeBaseValueChangedEventArgs)
        Dim numbersQuantitySliderSender As Slider = TryCast(sender, Slider)
        If numbersQuantitySliderSender IsNot Nothing Then
            Try
                numbersQuantitySliderLabel.Text = numbersQuantitySliderSender.Value.ToString()
            Catch exception As Exception
                Debug.WriteLine("ERROR: " & exception.ToString())
            End Try
        End If
    End Sub

    Private Sub LaunchButtonClicked(sender As Object, e As RoutedEventArgs) Handles LaunchButton.Click
        Me.Frame.Navigate(GetType(CardViewerWindow))
    End Sub
End Class
