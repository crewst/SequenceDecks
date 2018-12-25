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

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        ' EVENT:Loaded -- Initial page setup upon load completion.

        Dim display_scale = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel
        Dim display_width = DisplayInformation.GetForCurrentView().ScreenWidthInRawPixels / display_scale
        Dim display_height = DisplayInformation.GetForCurrentView().ScreenHeightInRawPixels / display_scale

        Me.InitializeComponent()
        ApplicationView.GetForCurrentView().TryEnterFullScreenMode()

        With ViewGrid
            ' Adjusts ViewGrid's size dimensions to equal page bounds and aligns it.
            .Width = display_width
            .Height = display_height
            .HorizontalAlignment = AlignmentX.Left
            .VerticalAlignment = AlignmentY.Top
        End With

        With CardGrid
            ' Adjusts CardGrid's size to proportionally fit the display.
            .Width = display_width * CARD_SCALE
            .Height = display_height * CARD_SCALE
        End With

    End Sub
End Class

' S. D. G.
