' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' The initial page and setup view for the application.
''' </summary>
''' 
''' <remarks>
''' Created by Tommy Crews
''' </remarks>

Public NotInheritable Class MainPage
    Inherits Page

    ' GLOBAL VARIABLES
    Public mainTitleBar = Core.CoreApplication.GetCurrentView().TitleBar
    Public mainTitleBarProperties = ApplicationView.GetForCurrentView().TitleBar
    Public realDeck = New Deck

    Private IsLoaded = False

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs) Handles LaunchButton.Loaded
        ' EVENT:Loaded -- Initial page setup upon load completion.

        Me.InitializeComponent()

        ApplicationView.PreferredLaunchViewSize = New Size(400, 800)
        ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize

        ' Setup window for acrylic effects.
        mainTitleBar.ExtendViewIntoTitleBar = True
        mainTitleBarProperties.ButtonBackgroundColor = Windows.UI.Colors.Transparent

        IsLoaded = True

        LoadPreview()
    End Sub

    Private Sub LoadPreview() Handles ShuffleCheckbox.Checked, ShuffleCheckbox.Unchecked
        ' Builds or rebuilds the preview card UI.

        Dim previewDeck = New Deck

        Try
            RebuildDeck(previewDeck)
            PreviewTextBlock.Text = previewDeck.GetFirstCard()
        Catch ex As Exception
            PreviewTextBlock.Text = "Unavailable"
        End Try

    End Sub

    Private Sub PivotItems_Handler(sender As Object, args As RoutedEventArgs)
        ' Enables builderPivot navigation using numbersButton and lettersButton.

        ' Listen for a Click event and call the appropriate builderPivot index.
        If sender Is numbersButton Then
            Debug.WriteLine("INFO: Numbers Button Clicked.")
            numbersButton.IsChecked = True
            lettersButton.IsChecked = False
            builderPivot.SelectedIndex = 0
        ElseIf sender Is lettersButton Then
            Debug.WriteLine("INFO: Letters Button Clicked.")
            lettersButton.IsChecked = True
            numbersButton.IsChecked = False
            builderPivot.SelectedIndex = 1
        End If

        LoadPreview()
    End Sub

#Region "Numbers Handlers"

    Private Sub NumbersQuantitySlider_Changed(sender As Object, e As RangeBaseValueChangedEventArgs)
        ' Handles a change in value of NumbersQuantitySlider.

        ' Since this Sub is called on every .Value change, I think it's called at the initialization as well.
        ' This leads to a null reference. The debug console shows that this seems to only happen once, so it should be safe to ignore it with a Try.

        If IsLoaded Then
            Try
                numbersQuantitySliderLabel.Text = numbersQuantitySlider.Value.ToString()
                numbersBlanksQuantitySlider.Maximum = numbersQuantitySlider.Value - 1
                If numbersQuantitySlider.Value = 1 Then
                    numbersBlanksQuantitySlider.IsEnabled = False
                Else
                    numbersBlanksQuantitySlider.IsEnabled = True
                End If
            Catch ex As NullReferenceException
                Debug.WriteLine("WARNING: " & ex.ToString())
            End Try

            LoadPreview()
        End If


    End Sub

    Private Sub NumbersBlanksQuantitySlider_Changed(sender As Object, e As RangeBaseValueChangedEventArgs)
        ' Handles numbersBlanksQuantitySlider value changes.

        ' Since this Sub is called on every .Value change, I think it's called at the initialization as well.
        ' This leads to a null reference. The debug console shows that this seems to only happen once, so it should be safe to ignore it with a Try.
        If IsLoaded Then
            Try
                numbersBlanksQuantitySliderLabel.Text = numbersBlanksQuantitySlider.Value.ToString()
            Catch ex As NullReferenceException
                Debug.WriteLine("WARNING: " & ex.ToString())
            End Try

            LoadPreview()
        End If

    End Sub

    Private Sub NumbersBlanksPositionButton_Changed(sender As Object, e As RoutedEventArgs)
        ' Handle numbersBlanksPosition[x]Button clicks.

        If sender Is numbersBlanksPositionLeftButton Then
            Debug.WriteLine("INFO: Numbers Left Blanks Position Button Clicked.")
            numbersBlanksPositionLeftButton.IsChecked = True
            numbersBlanksPositionMiddleButton.IsChecked = False
            numbersBlanksPositionRightButton.IsChecked = False
            numbersBlanksPositionRandomButton.IsChecked = False
        ElseIf sender Is numbersBlanksPositionMiddleButton Then
            Debug.WriteLine("INFO: Numbers Middle Blanks Position Button Clicked.")
            numbersBlanksPositionLeftButton.IsChecked = False
            numbersBlanksPositionMiddleButton.IsChecked = True
            numbersBlanksPositionRightButton.IsChecked = False
            numbersBlanksPositionRandomButton.IsChecked = False
        ElseIf sender Is numbersBlanksPositionRightButton Then
            Debug.WriteLine("INFO: Numbers Right Blanks Position Button Clicked.")
            numbersBlanksPositionLeftButton.IsChecked = False
            numbersBlanksPositionMiddleButton.IsChecked = False
            numbersBlanksPositionRightButton.IsChecked = True
            numbersBlanksPositionRandomButton.IsChecked = False
        ElseIf sender Is numbersBlanksPositionRandomButton Then
            Debug.WriteLine("INFO: Numbers Random Blanks Position Button Clicked.")
            numbersBlanksPositionLeftButton.IsChecked = False
            numbersBlanksPositionMiddleButton.IsChecked = False
            numbersBlanksPositionRightButton.IsChecked = False
            numbersBlanksPositionRandomButton.IsChecked = True
        End If

        LoadPreview()
    End Sub

#End Region

#Region "Letters Handlers"

    Private Sub LettersQuantitySlider_Changed(sender As Object, e As RangeBaseValueChangedEventArgs)
        ' Handles a change in value of LettersQuantitySlider.

        ' Since this Sub is called on every .Value change, I think it's called at the initialization as well.
        ' This leads to a null reference. The debug console shows that this seems to only happen once, so it should be safe to ignore it with a Try.
        If IsLoaded Then
            Try
                lettersQuantitySliderLabel.Text = lettersQuantitySlider.Value.ToString()
                lettersBlanksQuantitySlider.Maximum = lettersQuantitySlider.Value - 1
                If lettersQuantitySlider.Value = 1 Then
                    lettersBlanksQuantitySlider.IsEnabled = False
                Else
                    lettersBlanksQuantitySlider.IsEnabled = True
                End If
            Catch ex As NullReferenceException
                Debug.WriteLine("WARNING: " & ex.ToString())
            End Try

            LoadPreview()
        End If

    End Sub

    Private Sub LettersBlanksQuantitySlider_Changed(sender As Object, e As RangeBaseValueChangedEventArgs)
        ' Handles lettersBlanksQuantitySlider value changes.

        ' Since this Sub is called on every .Value change, I think it's called at the initialization as well.
        ' This leads to a null reference. The debug console shows that this seems to only happen once, so it should be safe to ignore it with a Try.
        If IsLoaded Then
            Try
                lettersBlanksQuantitySliderLabel.Text = lettersBlanksQuantitySlider.Value.ToString()
            Catch ex As NullReferenceException
                Debug.WriteLine("WARNING: " & ex.ToString())
            End Try
            LoadPreview()
        End If

    End Sub

    Private Sub LettersBlanksPositionButton_Changed(sender As Object, e As RoutedEventArgs)
        ' Handle lettersBlanksPosition[x]Button clicks.

        If sender Is lettersBlanksPositionLeftButton Then
            Debug.WriteLine("INFO: Letters Left Blanks Position Button Clicked.")
            lettersBlanksPositionLeftButton.IsChecked = True
            lettersBlanksPositionMiddleButton.IsChecked = False
            lettersBlanksPositionRightButton.IsChecked = False
            lettersBlanksPositionRandomButton.IsChecked = False
        ElseIf sender Is lettersBlanksPositionMiddleButton Then
            Debug.WriteLine("INFO: Letters Middle Blanks Position Button Clicked.")
            lettersBlanksPositionLeftButton.IsChecked = False
            lettersBlanksPositionMiddleButton.IsChecked = True
            lettersBlanksPositionRightButton.IsChecked = False
            lettersBlanksPositionRandomButton.IsChecked = False
        ElseIf sender Is lettersBlanksPositionRightButton Then
            Debug.WriteLine("INFO: Letters Right Blanks Position Button Clicked.")
            lettersBlanksPositionLeftButton.IsChecked = False
            lettersBlanksPositionMiddleButton.IsChecked = False
            lettersBlanksPositionRightButton.IsChecked = True
            lettersBlanksPositionRandomButton.IsChecked = False
        ElseIf sender Is lettersBlanksPositionRandomButton Then
            Debug.WriteLine("INFO: Letters Random Blanks Position Button Clicked.")
            lettersBlanksPositionLeftButton.IsChecked = False
            lettersBlanksPositionMiddleButton.IsChecked = False
            lettersBlanksPositionRightButton.IsChecked = False
            lettersBlanksPositionRandomButton.IsChecked = True
        End If
        LoadPreview()
    End Sub

#End Region

    Private Sub LaunchButtonClicked(sender As Object, e As RoutedEventArgs) Handles LaunchButton.Click
        ' Handles LaunchButton click event.

        Try
            RebuildDeck(realDeck)
            Frame.Navigate(GetType(CardViewerWindow), realDeck)
        Catch ex As Exception
            ShowDialog("Unacceptable Input", "There was an error building the deck. Check the Range values and try again." &
                       vbCrLf & vbCrLf & "The error was: " & ex.Message.ToString())
        End Try
    End Sub

    Private Function RebuildDeck(ByRef GivenDeck As Deck)
        ' Consolidation for the procedures used to build a deck. This lets us build both previewDeck and realDeck with the same code.

        ' Make sure range boxes aren't empty.
        Dim RangeMinInt, RangeMaxInt As Integer
        Dim RangeMinChar, RangeMaxChar As String
        With numbersRangeMinTextBox
            If .Text = "" Then
                RangeMinInt = Convert.ToInt32(.PlaceholderText)
            Else
                RangeMinInt = Convert.ToInt32(.Text)
            End If
        End With
        With numbersRangeMaxTextBox
            If .Text = "" Then
                RangeMaxInt = Convert.ToInt32(.PlaceholderText)
            Else
                RangeMaxInt = Convert.ToInt32(.Text)
            End If
        End With
        With lettersRangeMinTextBox
            If .Text = "" Then
                RangeMinChar = .PlaceholderText
            Else
                RangeMinChar = .Text.ToUpper()
            End If
        End With
        With lettersRangeMaxTextBox
            If .Text = "" Then
                RangeMaxChar = .PlaceholderText
            Else
                RangeMaxChar = .Text.ToUpper()
            End If
        End With

        With GivenDeck
            If numbersButton.IsChecked Then
                .DeckType = numbersButton.Content
                ' Next, we must convert the input ranges to integers so that they can be used as indices in the Deck class's For loops.
                .DeckRange = {RangeMinInt, RangeMaxInt}
                .DeckCardSize = numbersQuantitySlider.Value
                .DeckBlankCount = numbersBlanksQuantitySlider.Value
                ' Next up is a messy determination of which toggle button was selected. I'll need to clean this up eventually.
                If numbersBlanksPositionLeftButton.IsChecked Then
                    .DeckBlankPos = numbersBlanksPositionLeftButton.Content
                ElseIf numbersBlanksPositionMiddleButton.IsChecked Then
                    .DeckBlankPos = numbersBlanksPositionMiddleButton.Content
                ElseIf numbersBlanksPositionRightButton.IsChecked Then
                    .DeckBlankPos = numbersBlanksPositionRightButton.Content
                ElseIf numbersBlanksPositionRandomButton.IsChecked Then
                    .DeckBlankPos = numbersBlanksPositionRandomButton.Content
                End If
            ElseIf lettersButton.IsChecked Then
                .DeckType = lettersButton.Content
                .DeckRange = { .ReverseLetterMap(RangeMinChar.ToUpper), .ReverseLetterMap(RangeMaxChar.ToUpper)}
                .DeckCardSize = lettersQuantitySlider.Value
                .DeckBlankCount = lettersBlanksQuantitySlider.Value
                If lettersBlanksPositionLeftButton.IsChecked Then
                    .DeckBlankPos = lettersBlanksPositionLeftButton.Content
                ElseIf lettersBlanksPositionMiddleButton.IsChecked Then
                    .DeckBlankPos = lettersBlanksPositionMiddleButton.Content
                ElseIf lettersBlanksPositionRightButton.IsChecked Then
                    .DeckBlankPos = lettersBlanksPositionRightButton.Content
                ElseIf lettersBlanksPositionRandomButton.IsChecked Then
                    .DeckBlankPos = lettersBlanksPositionRandomButton.Content
                End If
            End If

            If ShuffleCheckbox.IsChecked Then
                .DeckShuffle = True
            Else
                .DeckShuffle = False
            End If

            .BuildDeck()

            .GetFirstCard()
            .GetNextCard()
            .GetPreviousCard()

        End With

        Return GivenDeck
    End Function

    Private Async Sub ShowDialog(Title As String, Content As String)
        ' Handles all simple popup dialogs.

        Dim InstanceDialog As ContentDialog = New ContentDialog With {
        .Title = Title,
        .Content = Content,
        .CloseButtonText = "OK"
        }

        Await InstanceDialog.ShowAsync()

    End Sub
End Class
' S. D. G.