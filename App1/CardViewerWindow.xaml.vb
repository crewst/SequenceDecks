' The Blank Page item template Is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' The normally fullscreen viewer window for main content.
''' </summary>
''' 
''' <remarks>
''' Created by Tommy Crews on Sunday, December 23, 2018.
''' </remarks>

Public NotInheritable Class CardViewerWindow
    Inherits Page

    ' CONSTANTS
    Const CARD_SCALE = 0.4  ' Used to set CardGrid's size relative to the display bounds.
    Private BG_ARRAY() As String = {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10"}
    Private InstanceDeck As Deck

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        Dim parameters = CType(e.Parameter, Deck)
        InstanceDeck = parameters
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        ' EVENT:Loaded -- Initial page setup upon load completion.

        ' Gather display information.
        Dim display_scale = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel
        Dim display_width = DisplayInformation.GetForCurrentView().ScreenWidthInRawPixels / display_scale
        Dim display_height = DisplayInformation.GetForCurrentView().ScreenHeightInRawPixels / display_scale
        Debug.WriteLine("INFO: Display resolution is " & display_width & "x" & display_height & " @" & display_scale & "x.")

        Dim random_selector = New Random()

        ' Randomly selects an index from BG_ARRAY.
        Dim background_wildcard = random_selector.Next(BG_ARRAY.Length)

        Me.InitializeComponent()
        ApplicationView.GetForCurrentView().TryEnterFullScreenMode()


        ' Adjusts ViewGrid's size dimensions to equal page bounds and aligns it.
        With ViewGrid
            .Width = display_width
            .Height = display_height
            .HorizontalAlignment = AlignmentX.Left
            .VerticalAlignment = AlignmentY.Top
        End With

        ' Adjust CardGrid's size to proportionally fit the display.
        With CardGrid
            .Width = display_width * CARD_SCALE
            .Height = display_height * CARD_SCALE
        End With

        ' Set ViewGrid background image based on selected index from background_wildcard.
        ViewGrid.Background = New ImageBrush With {
        .ImageSource = New BitmapImage(New Uri(Me.BaseUri, "Assets/CardViewer_BG/grad" & BG_ARRAY(background_wildcard) & ".jpg")),
        .Stretch = Stretch.Fill}

        CardTextBlock.Text = InstanceDeck.GetFirstCard()

    End Sub

    Private Sub ExitViewButton_Clicked(sender As Object, e As RoutedEventArgs) Handles ExitViewButton.Click
        ApplicationView.GetForCurrentView.ExitFullScreenMode()
        Frame.Navigate(GetType(MainPage))
    End Sub

    Private Sub NavigationLeftButton_Clicked(sender As Object, e As RoutedEventArgs) Handles NavigationPreviousButton.Click
        CardTextBlock.Text = InstanceDeck.GetPreviousCard()
    End Sub

    Private Sub NavigationRightButton_Clicked(sender As Object, e As RoutedEventArgs) Handles NavigationNextButton.Click
        CardTextBlock.Text = InstanceDeck.GetNextCard()
    End Sub
End Class

' S. D. G.
