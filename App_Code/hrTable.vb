Imports Microsoft.VisualBasic

Public Class hrTable
    Private _footer As String = ""
    Private _width As Integer = 664
    Private _headers As Generic.List(Of String)
    Private _rows As Generic.List(Of Generic.List(Of String))
    Private _colorMode As ColorModes
    Public Sub New()
        _headers = New Generic.List(Of String)
        _rows = New Generic.List(Of Generic.List(Of String))()
        _colorMode = ColorModes.Line
    End Sub
    Public Property Headers() As Generic.List(Of String)
        Get
            Return _headers
        End Get
        Set(ByVal value As Generic.List(Of String))
            _headers = value
        End Set
    End Property
    Public Property Rows() As Generic.List(Of Generic.List(Of String))
        Get
            Return _rows
        End Get
        Set(ByVal value As Generic.List(Of Generic.List(Of String)))
            _rows = value
        End Set
    End Property
    Public Property Footer() As String
        Get
            Return _footer
        End Get
        Set(ByVal value As String)
            _footer = value
        End Set
    End Property
    Public Property Width() As Integer
        Get
            Return _width
        End Get
        Set(ByVal value As Integer)
            _width = value
        End Set
    End Property
    Public Property ColorMode() As ColorModes
        Get
            Return _colorMode
        End Get
        Set(ByVal value As ColorModes)
            _colorMode = value
        End Set
    End Property

    Enum ColorModes As Integer
        Line = 2
        Column = 4
    End Enum

    Public Sub AddRow(ByVal vals() As String)
        Dim tr As New Generic.List(Of String)
        Dim i As Integer
        For i = 0 To vals.Length - 1
            tr.Add(vals(i))
        Next
        Me._rows.Add(tr)
    End Sub

    Public Function GetHTML() As String
        '<table width="400" border="0" cellspacing="0" cellpadding="2" style="border: 2px solid gray;">
        '  <tr bgcolor="#ECEADF">
        '    <td style="border-right: 1px solid #DDDDDD; border-bottom: 1px solid gray; ">Site Name </td>
        '    <td width="100" style="border-right: 1px solid #DDDDDD; border-bottom: 1px solid gray;">Hits</td>
        '    <td width="100" style="border-bottom: 1px solid gray;">Hits Today </td>
        '  </tr>
        '  <tr>
        '    <td bgcolor="#FFFFFF" style="border-right: 1px solid #DDDDDD; border-bottom: 1px solid #DDDDDD;">&nbsp;</td>
        '    <td width="100" bgcolor="#FFFFE8" style="border-right: 1px solid #DDDDDD; border-bottom: 1px solid #DDDDDD;">&nbsp;</td>
        '    <td width="100" bgcolor="#FFFFFF" style=" border-bottom: 1px solid #DDDDDD;">&nbsp;</td>
        '  </tr>
        '  <tr bgcolor="#ECEADF">
        '    <td colspan="3"><a href="add_site.aspx">Add a Site</a></td>
        '  </tr>
        '</table>
        Dim sb As New System.Text.StringBuilder
        Dim i, j, tCols As Integer
        With sb
            .Append("<table width=""")
            .Append(Width.ToString)
            .Append(""" border=""0"" cellspacing=""0"" cellpadding=""2"" style=""border: 2px solid gray;"">")
            .Append("<tr bgcolor=""#ECEADF"">")
            .Append(Environment.NewLine)
            For i = 0 To Headers.Count - 1
                .Append("   <td style="" border-bottom: 1px solid gray; ")
                If i < Headers.Count - 1 Then
                    .Append("border-right: 1px solid #DDDDDD;")
                End If
                .Append("""")
                If i > 0 Then
                    .Append(" width=""100""")
                End If
                .Append(">")
                .Append(Headers(i))
                .Append("</td>")
                .Append(Environment.NewLine)
            Next
            tCols = Headers.Count
            .Append("</tr>")
            For i = 0 To _rows.Count - 1
                .Append(Environment.NewLine)
                Dim cRow As Generic.List(Of String) = _rows(i)
                .Append("<tr>")
                .Append(Environment.NewLine)
                For j = 0 To cRow.Count - 1
                    .Append("   <td bgcolor=""")
                    If ((Me._colorMode = ColorModes.Column) AndAlso (j / 2 = j \ 2)) OrElse ((Me._colorMode = ColorModes.Line) AndAlso (i / 2 = i \ 2)) Then
                        .Append("#FFFFFF")
                    Else
                        .Append("#FFFFE8")
                    End If
                    .Append(""" style=""")
                    .Append("border-bottom: 1px solid #DDDDDD;")
                    If j < cRow.Count - 1 Then
                        .Append("border-right: 1px solid #DDDDDD;")
                    End If
                    .Append(""">")
                    Dim val As String = cRow(j)
                    If val.Length = 0 Then
                        .Append("&nbsp;")
                    Else
                        .Append(cRow(j))
                    End If
                    .Append("</td>")
                    .Append(Environment.NewLine)
                Next
                If cRow.Count > tCols Then tCols = cRow.Count
            Next
            If Me._footer.Length > 0 Then
                .Append("<tr bgcolor=""#ECEADF""><td colspan=""")
                .Append(tCols.ToString)
                .Append(""">")
                .Append(Me._footer)
                .Append("</td></tr>")
            End If
            .Append(Environment.NewLine)
            .Append("</table>")
            Return .ToString
        End With
    End Function
End Class
