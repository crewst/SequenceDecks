' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' This class acts as the actual deck of cards. As such, it should be instanced.
''' </summary>
''' 
''' <remarks>
''' Created by Tommy Crews on Monday, December 24, 2018.
''' </remarks>

Public Class Deck

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

        ElseIf DeckType = "Letters" Then

            ' Code for Letters will be inserted here.

        End If

        Debug.WriteLine("INFO: Raw assembled deck array: " & String.Join(" | ", DeckStringArray))

        ' Time to insert the blanks.
        For DeckArrayIndex = 0 To DeckStringArray.Length - 1
            Dim CenterFillToggle As Boolean = True
            Dim CenterFillAdder As Integer = 0
            Dim BlankInsertionArray As String() = DeckStringArray(DeckArrayIndex).Split(", ")
            For BlankInsertionIndex = 0 To DeckBlankCount - 1
                If DeckBlankPos = "Left" Then
                    BlankInsertionArray(BlankInsertionIndex) = "_"
                ElseIf DeckBlankPos = "Middle" Then
                    Dim CenterPoint = Math.Floor((BlankInsertionArray.Length) / 2)
                    If CenterFillToggle Then
                        BlankInsertionArray(CenterPoint + CenterFillAdder) = "_"
                        CenterFillAdder += 1
                    Else
                        BlankInsertionArray(CenterPoint - CenterFillAdder) = "_"
                    End If
                    CenterFillToggle = Not CenterFillToggle
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

        ' Shuffle the deck, if necessary.
        If DeckShuffle Then
            Dim original_value, swapped_value As String

            For randomizationIndex As Integer = 0 To DeckStringArray.GetUpperBound(0)
                original_value = random_selector.Next(0, randomizationIndex)
                swapped_value = DeckStringArray(original_value)
                DeckStringArray(original_value) = DeckStringArray(randomizationIndex)
                DeckStringArray(randomizationIndex) = swapped_value
            Next randomizationIndex

            Debug.WriteLine("INFO: Shuffled Deck Order is " & String.Join(", ", DeckStringArray))
        End If

    End Sub

    Public Function GetFirstCard()
        Try
            Return DeckStringArray(0)
        Catch ex As NullReferenceException
            Debug.WriteLine("WARNING: " & ex.ToString)
        End Try
    End Function

    Public Function GetNextCard()
        If CurrentDeckStringArrayIndex = DeckStringArray.GetUpperBound(0) Then
            CurrentDeckStringArrayIndex = 0
        Else
            CurrentDeckStringArrayIndex += 1
        End If
        Return DeckStringArray(CurrentDeckStringArrayIndex)
    End Function

    Public Function GetPreviousCard()
        If CurrentDeckStringArrayIndex = 0 Then
            CurrentDeckStringArrayIndex = DeckStringArray.GetUpperBound(0)
        Else
            CurrentDeckStringArrayIndex -= 1
        End If
        Return DeckStringArray(CurrentDeckStringArrayIndex)
    End Function

End Class

' S. D. G.