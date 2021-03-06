Option Explicit

Public Function return_line(my_range As Range, percentage As Double) As Integer
    
    Dim my_cell     As Range
    Dim my_result   As Double
    
    For Each my_cell In my_range
        my_result = my_result + my_cell.Value
        If my_result >= (Application.WorksheetFunction.Sum(my_range) * percentage) Then
            return_line = my_cell.Row - my_range.Row + 1
            Exit For
        End If
    Next my_cell
    
End Function

Public Function change_commas(ByVal myValue As Variant) As String
    
    Dim str_temp As String
    
    str_temp = CStr(myValue)
    change_commas = Replace(str_temp, ",", ".")
    
End Function


Public Sub FormatAsDate(ByRef cell As Range)

    cell.NumberFormat = "[$-407]mmm/ yy;@"
    
End Sub

Public Sub FormatAsPercent(ByRef my_cell As Range)

    my_cell.Style = "Percent"
    my_cell.NumberFormat = "0.00%"

End Sub

Public Sub FormatAsCurrency(ByRef cell As Range, Optional ByVal b_change_0 = False)


    If IsNumeric(cell.Value) And Not cell.HasFormula Then
        cell.Value = Round(cell.Value, 2)
    End If

    cell.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

    If b_change_0 Then
    
        With cell
            .FormatConditions.Delete
            .FormatConditions.Add Type:=xlCellValue, Operator:=xlEqual, Formula1:="=0"
            .FormatConditions(1).Font.ThemeColor = xlThemeColorDark1
            .FormatConditions(1).Font.TintAndShade = -0.25
        End With
        
    End If
    
End Sub

Public Function millions_eur(ByVal my_value As Long) As Long
    
    millions_eur = my_value / 1000000

End Function

Public Sub WhiteYourself(ByVal lines As Long, ByRef my_sheet As Worksheet)
    
    Dim str_lines As String
    str_lines = lines & ":" & lines
    
    With my_sheet.Rows(str_lines).Font
        .ThemeColor = xlThemeColorDark1
        .TintAndShade = 0
    End With
    
End Sub

Public Sub FormatFontColorToGrey(ByRef cell As Range)

    cell.Font.Color = RGB(128, 128, 128)

End Sub
Public Sub UnprotectAll()

    Dim i As Integer
    For i = ActiveWorkbook.Worksheets.Count To 1 Step -1
        ActiveWorkbook.Worksheets(i).Unprotect Password:=SECRET_PASSWORD
    Next
    
End Sub
Public Sub ProtectAll()

    Dim i As Integer
    For i = ActiveWorkbook.Worksheets.Count To 1 Step -1
        ActiveWorkbook.Worksheets(i).Activate
        ActiveWorkbook.Worksheets(i).Cells(1, 1).Select
        ActiveWorkbook.Worksheets(i).Protect Password:=SECRET_PASSWORD
    Next
    
End Sub

Public Function distribution_term_calculation(total_term) As Long

    If total_term >= 6 Then
        distribution_term_calculation = 6
    ElseIf total_term < 6 And total_term >= 2 Then
        distribution_term_calculation = 2
    Else
        distribution_term_calculation = 1
    End If
    
End Function

Public Function sum_range(my_range As Range) As Double
    
    Dim cell As Range
    
    sum_range = 0
    
    For Each cell In my_range
        sum_range = sum_range + cell.Value
    Next
    
End Function

Public Function make_random(down As Long, up As Long) As Long
    
    make_random = CLng((up - down + 1) * Rnd + down)
    
    If make_random > up Then make_random = up
    If make_random < down Then make_random = down

End Function


Public Function last_row_with_data(ByVal lng_column_number As Long, shCurrent As Variant) As Long
    
    last_row_with_data = shCurrent.Cells(Rows.Count, lng_column_number).End(xlUp).Row
    
End Function
