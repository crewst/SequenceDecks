' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' Classes for framework objects shared among all modules.
''' </summary>
''' 
''' <remarks>
''' Created by Tommy Crews on Wednesday, December 26, 2018.
''' </remarks>

Public Class SequenceDecksFramework
    Public Shared LetterMap As New List(Of Letter) From
        {
            New Letter With {.Index = 0, .Character = "A"},
            New Letter With {.Index = 1, .Character = "B"},
            New Letter With {.Index = 2, .Character = "C"},
            New Letter With {.Index = 3, .Character = "D"},
            New Letter With {.Index = 4, .Character = "E"},
            New Letter With {.Index = 5, .Character = "F"},
            New Letter With {.Index = 6, .Character = "G"},
            New Letter With {.Index = 7, .Character = "H"},
            New Letter With {.Index = 8, .Character = "I"},
            New Letter With {.Index = 9, .Character = "J"},
            New Letter With {.Index = 10, .Character = "K"},
            New Letter With {.Index = 11, .Character = "L"},
            New Letter With {.Index = 12, .Character = "M"},
            New Letter With {.Index = 13, .Character = "N"},
            New Letter With {.Index = 14, .Character = "O"},
            New Letter With {.Index = 15, .Character = "P"},
            New Letter With {.Index = 16, .Character = "Q"},
            New Letter With {.Index = 17, .Character = "R"},
            New Letter With {.Index = 18, .Character = "S"},
            New Letter With {.Index = 19, .Character = "T"},
            New Letter With {.Index = 20, .Character = "U"},
            New Letter With {.Index = 21, .Character = "V"},
            New Letter With {.Index = 22, .Character = "W"},
            New Letter With {.Index = 23, .Character = "X"},
            New Letter With {.Index = 24, .Character = "Y"},
            New Letter With {.Index = 25, .Character = "Z"}
    }
End Class

Public Class Letter
    Public Property Index As Integer
    Public Property Character As String
End Class

' S. D. G.