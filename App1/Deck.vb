' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' This class acts as the actual deck of cards. As such, it should be instanced.
''' </summary>
''' 
''' <remarks>
''' Created by Tommy Crews on Monday, December 24, 2018.
''' </remarks>

Public Class Deck

    Private DeckStringArray As String()  ' An array representing the deck itself.
    Private CurrentDeckStringArrayIndex As Integer = 0  ' A pointer used for navigating through a deck.
    Private random_selector = New Random()  ' An engine for selecting random indices in arrays.
    Public DecodingLetterMap As New Specialized.OrderedDictionary  ' A dictionary used internally for decoding letters.
    Public EncodingLetterMap As New Specialized.OrderedDictionary  ' A dictionary used externally for encoding letters.

    ' Auto properties set externally for deck construction.
    Public Property DeckType As String
    Public Property DeckRange As Integer()
    Public Property DeckCardSize As Integer
    Public Property DeckBlankCount As Integer
    Public Property DeckBlankPos As String
    Public Property DeckShuffle As Boolean

    Public Sub New()
        ' Primary class constructor.

        ' Fill DecodingLetterMap dictionary.
        DecodingLetterMap.Add(0, "A")
        DecodingLetterMap.Add(1, "B")
        DecodingLetterMap.Add(2, "C")
        DecodingLetterMap.Add(3, "D")
        DecodingLetterMap.Add(4, "E")
        DecodingLetterMap.Add(5, "F")
        DecodingLetterMap.Add(6, "G")
        DecodingLetterMap.Add(7, "H")
        DecodingLetterMap.Add(8, "I")
        DecodingLetterMap.Add(9, "J")
        DecodingLetterMap.Add(10, "K")
        DecodingLetterMap.Add(11, "L")
        DecodingLetterMap.Add(12, "M")
        DecodingLetterMap.Add(13, "N")
        DecodingLetterMap.Add(14, "O")
        DecodingLetterMap.Add(15, "P")
        DecodingLetterMap.Add(16, "Q")
        DecodingLetterMap.Add(17, "R")
        DecodingLetterMap.Add(18, "S")
        DecodingLetterMap.Add(19, "T")
        DecodingLetterMap.Add(20, "U")
        DecodingLetterMap.Add(21, "V")
        DecodingLetterMap.Add(22, "W")
        DecodingLetterMap.Add(23, "X")
        DecodingLetterMap.Add(24, "Y")
        DecodingLetterMap.Add(25, "Z")

        ' Fill EncodingLetterMap dictionary.
        EncodingLetterMap.Add("A", 0)
        EncodingLetterMap.Add("B", 1)
        EncodingLetterMap.Add("C", 2)
        EncodingLetterMap.Add("D", 3)
        EncodingLetterMap.Add("E", 4)
        EncodingLetterMap.Add("F", 5)
        EncodingLetterMap.Add("G", 6)
        EncodingLetterMap.Add("H", 7)
        EncodingLetterMap.Add("I", 8)
        EncodingLetterMap.Add("J", 9)
        EncodingLetterMap.Add("K", 10)
        EncodingLetterMap.Add("L", 11)
        EncodingLetterMap.Add("M", 12)
        EncodingLetterMap.Add("N", 13)
        EncodingLetterMap.Add("O", 14)
        EncodingLetterMap.Add("P", 15)
        EncodingLetterMap.Add("Q", 16)
        EncodingLetterMap.Add("R", 17)
        EncodingLetterMap.Add("S", 18)
        EncodingLetterMap.Add("T", 19)
        EncodingLetterMap.Add("U", 20)
        EncodingLetterMap.Add("V", 21)
        EncodingLetterMap.Add("W", 22)
        EncodingLetterMap.Add("X", 23)
        EncodingLetterMap.Add("Y", 24)
        EncodingLetterMap.Add("Z", 25)
    End Sub

    Public Sub BuildDeck()
        ' Called externally to assemble DeckStringArray.

        Debug.WriteLine("INFO: Deck construction initialized.")
        Debug.WriteLine("INFO: Deck type is " & DeckType & ".")
        Debug.WriteLine("INFO: Deck range is " & DeckRange(0).ToString() & " to " & DeckRange(1))

        ' Define an array whose length is equal to the requested range by subtracting lower bounds from upper bounds.
        Dim numberRangeArray(DeckRange(1) - DeckRange(0))

        ' Set a custom array index to be used in the following For loop, since the loop's iterative index must carry the requested range.
        Dim currentNumberRangeArrayIndex As Integer = 0

        ' Fill numberRangeArray with string versions of numbers from the requested range.
        For currentNumber As Integer = DeckRange(0) To DeckRange(1)
            numberRangeArray(currentNumberRangeArrayIndex) = currentNumber.ToString()
            ' Iterate the custom array index.
            currentNumberRangeArrayIndex += 1
        Next

        Debug.WriteLine("INFO: Deck range: " & String.Join(", ", numberRangeArray))

        ' Since the deck is an array of strings, where each string represents one card in the deck, the deck's length is equal to
        ' the requested range's array length, minus the length of one card.
        Dim DeckStringArrayLength = numberRangeArray.Length - DeckCardSize

        ' Set the dimensions of the array that will hold the final deck.
        ReDim DeckStringArray(DeckStringArrayLength)

        ' Time to begin construction of the deck.

        ' A For loop to populate the deck.
        For assemblyRangeArrayIndex As Integer = 0 To DeckStringArrayLength
            ' Define yet another array that will hold each character in a card.
            Dim assemblyStringArray(DeckCardSize - 1)
            ' Create a Numbers-type card.
            If DeckType = "Numbers" Then
                ' Internal For loop to build the current card.
                For innerAssimblyStringArrayIndex As Integer = 0 To DeckCardSize - 1
                    ' Fill the current index of a card with the necessary character. The first character in the card is equal to
                    ' assemblyRangeArrayIndex. Adding innerAssemblyStringArrayIndex will iterate to the next characters in the card.
                    assemblyStringArray(innerAssimblyStringArrayIndex) =
                        numberRangeArray(assemblyRangeArrayIndex + innerAssimblyStringArrayIndex)
                Next
                ' Create a Letters-type card.
            ElseIf DeckType = "Letters" Then
                ' Internal For loop to build the current card.
                For innerAssimblyStringArrayIndex As Integer = 0 To DeckCardSize - 1
                    ' Fill the current index of a card with the necessary character. The first character in the card is equal to
                    ' assemblyRangeArrayIndex. Adding innerAssemblyStringArrayIndex will iterate to the next characters in the card.
                    ' In a Letters-type card, this character (a number) must be converted to its corresponding letter using DecodingLetterMap.
                    assemblyStringArray(innerAssimblyStringArrayIndex) =
                        DecodingLetterMap(Convert.ToInt32(numberRangeArray(assemblyRangeArrayIndex + innerAssimblyStringArrayIndex)))
                Next
            End If
            ' Finally, fill an index of the deck with the generated card. Repeat this process until DeckStringArrayLength
            ' has been reached.
            DeckStringArray(assemblyRangeArrayIndex) = String.Join(", ", assemblyStringArray)
        Next

        Debug.WriteLine("INFO: Raw assembled deck array: " & String.Join(" | ", DeckStringArray))

        ' Time to insert the blanks.

        ' This For loop disassembles each card in the deck to insert blanks.
        For DeckArrayIndex = 0 To DeckStringArray.GetUpperBound(0)
            ' This variable will be used to switch from left to right when filling blanks outward from the center of a card.
            Dim CenterFillToggle As Boolean = True
            ' This variable will be incremented to move the pointer further outward when filling blanks from the center of a card.
            Dim CenterFillAdder As Integer = 0
            ' This array will be used to store and modify a disassembled card string.
            Dim BlankInsertionArray As String() = DeckStringArray(DeckArrayIndex).Split(", ")
            ' This For loop will replace characters in the disassembled card with blanks until
            ' the requested number of blanks Is reached.
            For BlankInsertionIndex = 0 To DeckBlankCount - 1
                ' Fill blanks from the left. This method is the simplest, because the pointer can just use the For loop's index.
                If DeckBlankPos = "Left" Then
                    BlankInsertionArray(BlankInsertionIndex) = "_"
                    ' Fill blanks from the middle. This method is the most tedious, as the pointer must begin in the center, then move
                    ' outward in the opposite direction on each iteration of the For loop.
                ElseIf DeckBlankPos = "Middle" Then
                    ' Find the center point of the card by halving its length. If the length is odd and a decimal is produced, round
                    ' downward, which will make the center point the number just left of center. This is done because the next blank
                    ' will always be filled to the right of the first.
                    Dim CenterPoint = Math.Floor((BlankInsertionArray.Length) / 2)
                    ' If CenterFillToggle is True (which it is initially), move to the right and insert a blank. If it is false,
                    ' move to the left and insert a blank.
                    If CenterFillToggle Then
                        BlankInsertionArray(CenterPoint + CenterFillAdder) = "_"
                        ' Increment CenterFillAdder when we need to move outward from center. This is done on the initial blank
                        ' insertion so that we don't fill the center point twice. It is omitted every other insertion because
                        ' the pointer would skip positions.
                        CenterFillAdder += 1
                    Else
                        BlankInsertionArray(CenterPoint - CenterFillAdder) = "_"
                    End If
                    ' Once a blank has been inserted, switch to fill the other side of the center point on the next iteration.
                    CenterFillToggle = Not CenterFillToggle
                    ' Fill blanks from the right. This is done simply by finding the difference of the card's length and the pointer's
                    ' current position.
                ElseIf DeckBlankPos = "Right" Then
                    BlankInsertionArray(BlankInsertionArray.Length - (BlankInsertionIndex + 1)) = "_"
                    ' Fill blanks randomly. This uses the global instance of the Random class called random_selector. Word on the street
                    ' is that the Random class isn't truly random, and shouldn't be trusted for security. I think it'll be good enough
                    ' for a first grade class, though.
                ElseIf DeckBlankPos = "Random" Then
                    Dim selected_index = random_selector.Next(BlankInsertionArray.Length)
                    ' We need to make sure the randomly selected index isn't already a blank.
                    If BlankInsertionArray(selected_index) <> "_" Then
                        ' If it's not a blank, make it a blank.
                        BlankInsertionArray(selected_index) = "_"
                    Else
                        ' If it is a blank, reset the For loop's current iteration and try again. There is a possibility (though
                        ' extremely statistically improbable) that the random selection engine will continuously choose the same
                        ' index, causing the program to hang for x iterations as x approaches infinity. You'd have a better chance
                        ' of winning the lottery, then getting struck by lightning, surviving, then getting eaten by a shark, all
                        ' in the same day.
                        BlankInsertionIndex -= 1
                    End If
                End If
            Next
            ' Finally, reassemble the disassembled card back into a string, and replace the old, blankless card in the deck.
            DeckStringArray(DeckArrayIndex) = String.Join("  ", BlankInsertionArray)
        Next

        Debug.WriteLine("INFO: Compiled Deck array is " & String.Join(", ", DeckStringArray))

        ' Shuffle the deck, if necessary.
        If DeckShuffle Then
            ' Create two variables to swap cards.
            Dim original_value, swapped_value As String
            ' Iterate through each card, moving it around.
            For randomizationIndex As Integer = 0 To DeckStringArray.GetUpperBound(0)
                ' Pick a random place in the deck. The selected index can't be the same as the For loop's index.
                ' This prevents any card from remaining in its original position.
                original_value = random_selector.Next(0, randomizationIndex)
                ' "Take out" the randomly selected card form the deck and "hold" it.
                swapped_value = DeckStringArray(original_value)
                ' Take the card from the current For loop index and put it in the randomly selected card's place.
                DeckStringArray(original_value) = DeckStringArray(randomizationIndex)
                ' Put the randomly selected card into the current For loop index.
                DeckStringArray(randomizationIndex) = swapped_value
            Next randomizationIndex

            Debug.WriteLine("INFO: Shuffled Deck Order is " & String.Join(", ", DeckStringArray))
        End If

    End Sub

    Public Function GetFirstCard()
        ' Returns a string of the first card in the deck.

        Try
            Return DeckStringArray(0)
        Catch ex As NullReferenceException
            Debug.WriteLine("WARNING: " & ex.ToString)
            Return "Unavailable"
        End Try
    End Function

    Public Function GetNextCard()
        ' Returns a string of the next card in the deck reative to CurrentDeckStringArrayIndex, and advances the index by 1.

        If CurrentDeckStringArrayIndex = DeckStringArray.GetUpperBound(0) Then
            ' If we're at the end of the deck, we can't get the next card, so we'll move back to the beginning of the deck
            ' and get the first card instead.
            CurrentDeckStringArrayIndex = 0
        Else
            ' We want to move the pointer forward so that we don't keep pulling the same card with this function.
            CurrentDeckStringArrayIndex += 1
        End If
        Return DeckStringArray(CurrentDeckStringArrayIndex)
    End Function

    Public Function GetPreviousCard()
        If CurrentDeckStringArrayIndex = 0 Then
            CurrentDeckStringArrayIndex = DeckStringArray.GetUpperBound(0)
            ' If we're at the beginning of the deck, we can't get the previous card, so we'll move forward to the end of the deck
            ' and get the last card instead.

            ' We want to move the pointer backward so that we don't keep pulling the same card with this function.
            CurrentDeckStringArrayIndex -= 1
        End If
        Return DeckStringArray(CurrentDeckStringArrayIndex)
    End Function

End Class

' S. D. G.