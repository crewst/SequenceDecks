' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' This class acts as the actual deck of cards. As such, it should be instanced.
''' </summary>
''' 
''' <remarks>
''' Created by Tommy Crews on Monday, December 24, 2018.
''' </remarks>

Public Class Deck

    Private LETTERS As String() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}

    Private DeckStringArray As String()
    Private CurrentDeckStringArrayIndex As Integer = 0
    Private random_selector = New Random()

    ' Auto properties for construction.
    Public Property DeckType As String
    Public Property DeckRange As Integer()
    Public Property DeckCardSize As Integer
    Public Property DeckBlankCount As Integer
    Public Property DeckBlankPos As String
    Public Property DeckShuffle As Boolean

    Public Sub New()
        ' Primary class constructor.

    End Sub

    Public Sub BuildDeck()
        ' Called externally to assemble DeckStringArray.

        Debug.WriteLine("INFO: Deck construction initialized.")

        If DeckType = "Numbers" Then
            ' Begin construction of a numbers deck.

            Debug.WriteLine("INFO: Deck type is Numbers.")
            Debug.WriteLine("INFO: Deck range is " & DeckRange(0).ToString() & " to " & DeckRange(1))

            Dim numberRangeArray(DeckRange(1) - DeckRange(0))
            Dim currentNumberRangeArrayIndex As Integer = 0

            For currentNumber As Integer = DeckRange(0) To DeckRange(1)
                numberRangeArray(currentNumberRangeArrayIndex) = currentNumber.ToString()
                currentNumberRangeArrayIndex += 1
            Next

            Debug.WriteLine("INFO: Deck range: " & String.Join(", ", numberRangeArray))

            ReDim DeckStringArray(numberRangeArray.Length - DeckCardSize)

            For assemblyRangeArrayIndex As Integer = 0 To (numberRangeArray.Length - DeckCardSize)
                Dim assemblyStringArray(DeckCardSize - 1)
                Dim innerAssemblyIndexTicker = assemblyRangeArrayIndex
                For innerAssimblyStringArrayIndex As Integer = 0 To DeckCardSize - 1
                    assemblyStringArray(innerAssimblyStringArrayIndex) = numberRangeArray(innerAssemblyIndexTicker)
                    innerAssemblyIndexTicker += 1
                Next
                DeckStringArray(assemblyRangeArrayIndex) = String.Join(", ", assemblyStringArray)
            Next

            Debug.WriteLine("INFO: Raw assembled deck array: " & String.Join(" | ", DeckStringArray))

            ' Time to insert the blanks.
            For DeckArrayIndex = 0 To DeckStringArray.Length - 1
                Dim CenterFillToggle As Boolean = False
                Dim CenterFillAdder As Integer = 0
                Dim BlankInsertionArray As String() = DeckStringArray(DeckArrayIndex).Split(", ")
                For BlankInsertionIndex = 0 To DeckBlankCount - 1
                    If DeckBlankPos = "Left" Then
                        BlankInsertionArray(BlankInsertionIndex) = "_"
                    ElseIf DeckBlankPos = "Middle" Then
                        If CenterFillToggle Then
                            BlankInsertionArray(Math.Ceiling(BlankInsertionArray.Length / 2) + CenterFillAdder) = "_"
                        Else
                            BlankInsertionArray(Math.Floor(BlankInsertionArray.Length / 2) - CenterFillAdder) = "_"
                        End If
                        CenterFillToggle = Not CenterFillToggle
                        CenterFillAdder += 1
                    ElseIf DeckBlankPos = "Right" Then
                        BlankInsertionArray(BlankInsertionArray.Length - (BlankInsertionIndex + 1)) = "_"
                    ElseIf DeckBlankPos = "Random" Then
                        Dim selected_index = random_selector.Next(BlankInsertionArray.Length)
                        If BlankInsertionArray(selected_index) <> "_" Then
                            BlankInsertionArray(selected_index) = "_"
                        Else
                            BlankInsertionIndex -= 1
                        End If
                    End If
                Next
                DeckStringArray(DeckArrayIndex) = String.Join("  ", BlankInsertionArray)
            Next

            Debug.WriteLine("INFO: Compiled Deck array is " & String.Join(", ", DeckStringArray))

        ElseIf DeckType = "Letters" Then

        End If
    End Sub

End Class

' S. D. G.