Imports PackageIO
Imports System.IO
Public Class Form1
    Private FilePath As String
    Private FilePath2 As String
    Private FilePath3 As String
    Private FilePath4 As String
    Private FilePath5 As String
    Private FilePath6 As String
    Private FilePath7 As String
    Private FilePath8 As String
    Private Log As String
    Public Function SingleToHex(ByVal tmp As Single) As String
        Dim arr = BitConverter.GetBytes(tmp)
        Array.Reverse(arr)
        Return BitConverter.ToString(arr).Replace("-", "")
    End Function
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.ColumnIndex = 0 Then
            Dim Dialog3 As New OpenFileDialog
            Dialog3.Filter = "Wavefront Object Files *.OBJ |*.OBJ"
                Dialog3.FileName = DataGridView1(2, e.RowIndex).Value
                Dialog3.ShowDialog()
                FilePath2 = Dialog3.FileName
                Dim reader As Reader = New Reader(FilePath2, Endian.Big)
                Dim Writer As Writer = New Writer(FilePath, Endian.Big)
                Dim Reader3 As New Reader(FilePath, Endian.Little)
                Dim Reader2 As New Reader(FilePath, Endian.Little)
                Dim x As Integer = 0
                Dim x2 As Integer = DataGridView1(3, e.RowIndex).Value
                Reader3.Position = "&H" + DataGridView1(4, e.RowIndex).Value
                Reader3.Position = Reader3.Position + &H8
                Reader2.Position = Reader3.Position
                Reader3.Position = Reader3.SearchString("FFFFFFFF", StringType.Hexadecimal, Reader2.Position, True, FileLen(FilePath), True)(0)
                Reader3.Position = Reader3.Position + &H10
                Do Until x = x2
                    reader.Position = reader.SearchString("0A76", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    Writer.Position = Reader3.Position
                    reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    reader.Position = reader.Position + 1
                    Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                    reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    reader.Position = reader.Position + 1

                    Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                    reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    reader.Position = reader.Position + 1
                    Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                    x = x + 1
                    Reader2.Position = Reader3.Position
                    If DataGridView1.RowCount < 2 Then
                        Reader3.Position = Reader3.Position + &H24
                    End If
                    If DataGridView1.RowCount > 2 Then
                        Reader3.Position = Reader3.Position + &H44
                    End If
                Loop
                If MsgBox("Would you like to Inject U-V's?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    x = 0
                    x2 = DataGridView1(3, e.RowIndex).Value
                    Reader3.Position = "&H" + DataGridView1(4, e.RowIndex).Value
                    Reader3.Position = Reader3.Position + &H8
                    Reader2.Position = Reader3.Position
                    Reader3.Position = Reader3.SearchString("FFFFFFFF", StringType.Hexadecimal, Reader2.Position, True, FileLen(FilePath), True)(0)
                    Reader3.Position = Reader3.Position - &H8
                    reader.Position = 0
                    reader.Position = reader.SearchString("7674", StringType.Hexadecimal, 0, True,, False)(0)
                    Do Until x = x2
                        Writer.Position = Reader3.Position

                        reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                        reader.Position = reader.Position + 1
                        Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                        reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                        reader.Position = reader.Position + 1
                        Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                        x = x + 1
                        Reader2.Position = Reader3.Position + &HC
                        If DataGridView1.RowCount < 2 Then
                            Reader3.Position = Reader3.Position + &H24
                        ElseIf DataGridView1.RowCount > 2 Then
                            Reader3.Position = Reader3.Position + &H44
                        End If
                    Loop
                Else

                End If
            If MsgBox("Would you like to Inject Normals?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                x = 0
                x2 = DataGridView1(3, e.RowIndex).Value
                reader.Position = 0
                Reader3.Position = "&H" + DataGridView1(4, e.RowIndex).Value
                Reader3.Position = Reader3.Position + &H8
                Reader2.Position = Reader3.Position
                Reader3.Position = Reader3.SearchString("FFFFFFFF", StringType.Hexadecimal, Reader2.Position, True, FileLen(FilePath), True)(0)
                Reader3.Position = Reader3.Position + &H4
                reader.Position = reader.SearchString("766E", StringType.Hexadecimal, 0, True,, False)(0)
                Do Until x = x2
                    Writer.Position = Reader3.Position
                    reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    reader.Position = reader.Position + 1
                    Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                    reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    reader.Position = reader.Position + 1
                    Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                    reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    reader.Position = reader.Position + 1
                    Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                    x = x + 1
                    Reader2.Position = Reader3.Position + &H10
                    Reader3.Position = Reader3.SearchString("FFFFFFFF", StringType.Hexadecimal, Reader2.Position, True, FileLen(FilePath), True)(0)
                    Reader3.Position = Reader3.Position + &H4
                    reader.Position = reader.SearchString("766E", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    Writer.Position = Reader3.Position
                    reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    reader.Position = reader.Position + 1
                    Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                    reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    reader.Position = reader.Position + 1
                    Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                    reader.Position = reader.SearchString("20", StringType.Hexadecimal, reader.LastPosition, True,, False)(0)
                    reader.Position = reader.Position + 1
                    Writer.WriteHex(SingleToHex(CSng(reader.ReadASCII(6))))
                    x = x + 1
                    Reader2.Position = Reader3.Position + &H10
                    If DataGridView1.RowCount < 2 Then
                        Reader3.Position = Reader3.Position + &H24
                    ElseIf DataGridView1.RowCount > 2 Then
                        Reader3.Position = Reader3.Position + &H44
                    End If
                Loop
            Else

            End If
            Writer.Close()
            MsgBox("File Injected Successfully !!")
            Writer.Close()
            reader.Close()
            Reader2.Close()
            Reader3.Close()
            InjectFaces(sender, e)

            End If


    End Sub
    Private Sub DataGridView2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.ColumnIndex = 1 Then
            Dim Dialog3 As New SaveFileDialog

            Dialog3.Filter = "Wavefront Object Files *.OBJ |*.OBJ"
            Dialog3.FileName = DataGridView1(2, e.RowIndex).Value
            Dialog3.ShowDialog()
            FilePath3 = Dialog3.FileName
            File.Create(FilePath3).Dispose()
            Dim Sng As Single
            Dim Reader As New Reader(FilePath, Endian.Little, 0)
            Dim Reader2 As New Reader(FilePath, Endian.Little)
            Dim Writer As New Writer(FilePath3, Endian.Big)
            Dim x As Integer = 0
            Dim x2 As Integer = DataGridView1(3, e.RowIndex).Value
            Writer.WriteHex("0A")
            Writer.WriteHex("76")
            Writer.WriteHex("20")
            Reader.Position = "&H" + DataGridView1(4, e.RowIndex).Value
            Reader.Position = Reader.Position + &H8
            Reader2.Position = Reader.Position
            Reader.Position = Reader.SearchString("FFFFFFFF", StringType.Hexadecimal, Reader2.Position, True, FileLen(FilePath), True)(0)
            Reader.Position = Reader.Position + &H10
            Do Until x = x2
                Sng = Reader.ReadSingle()
                Writer.WriteASCII(Sng.ToString("N6"))
                Writer.WriteHex("20")
                Sng = Reader.ReadSingle()
                Writer.WriteASCII(Sng.ToString("N6"))
                Writer.WriteHex("20")
                Sng = Reader.ReadSingle()
                Writer.WriteASCII(Sng.ToString("N6"))
                Writer.WriteHex("0A")
                Writer.WriteHex("76")
                Writer.WriteHex("20")
                x = x + 1
                Reader2.Position = Reader.Position
                If DataGridView1.RowCount < 2 Then
                    Reader.Position = Reader.Position + &H18
                ElseIf DataGridView1.RowCount > 2 Then
                    Reader.Position = Reader.Position + &H38
                End If
            Loop
            Writer.Position = Writer.Position - 3
            Writer.DeleteBytes(3)

            x = 0
            Writer.WriteHex("0A")
            Writer.WriteHex("76")
            Writer.WriteHex("74")
            Writer.WriteHex("20")
            Reader.Position = "&H" + DataGridView1(4, e.RowIndex).Value
            Reader.Position = Reader.Position + &H8
            Reader2.Position = Reader.Position
            Reader.Position = Reader.SearchString("FFFFFFFF", StringType.Hexadecimal, Reader2.Position, True, FileLen(FilePath), True)(0)
            Reader.Position = Reader.Position - &H8
            Do Until x = x2
                Sng = Reader.ReadSingle()
                Writer.WriteASCII(Sng.ToString("N6"))
                Writer.WriteHex("20")
                Sng = Reader.ReadSingle()
                Writer.WriteASCII(Sng.ToString("N6"))
                Writer.WriteHex("0A")
                Writer.WriteHex("76")
                Writer.WriteHex("74")
                Writer.WriteHex("20")
                x = x + 1
                Reader2.Position = Reader.Position
                If DataGridView1.RowCount < 2 Then
                    Reader.Position = Reader.Position + &H1C
                ElseIf DataGridView1.RowCount > 2 Then
                    Reader.Position = Reader.Position + &H3C
                End If
            Loop
            Writer.Position = Writer.Position - 3
            Writer.DeleteBytes(3)
            x = 0
            Writer.WriteHex("0A")
            Writer.WriteHex("76")
            Writer.WriteHex("6E")
            Writer.WriteHex("20")
            Reader.Position = "&H" + DataGridView1(4, e.RowIndex).Value
            Reader.Position = Reader.Position + &H8
            Reader2.Position = Reader.Position
            Reader.Position = Reader.SearchString("FFFFFFFF", StringType.Hexadecimal, Reader2.Position, True, FileLen(FilePath), True)(0)
            Reader.Position = Reader.Position + &H4
            Do Until x = x2
                Sng = Reader.ReadSingle()
                Writer.WriteASCII(Sng.ToString("N6"))
                Writer.WriteHex("20")
                Sng = Reader.ReadSingle()
                Writer.WriteASCII(Sng.ToString("N6"))
                Writer.WriteHex("20")
                Sng = Reader.ReadSingle()
                Writer.WriteASCII(Sng.ToString("N6"))
                Writer.WriteHex("0A")
                Writer.WriteHex("76")
                Writer.WriteHex("6E")
                Writer.WriteHex("20")
                x = x + 1
                Reader2.Position = Reader.Position
                If DataGridView1.RowCount < 2 Then
                    Reader.Position = Reader.Position + &H18
                ElseIf DataGridView1.RowCount > 2 Then
                    Reader.Position = Reader.Position + &H38
                End If

            Loop
            Writer.Position = Writer.Position - 3
            Writer.DeleteBytes(3)
            Writer.Close()
            Reader.Close()
            Reader2.Close()
            EFaces(sender, e)
            MsgBox("Object Exported Successfully !!")
        End If

    End Sub
    Public Function InjectFaces(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        If e.ColumnIndex = 0 Then
            FilePath6 = FilePath + ".faces"
            File.Create(FilePath6).Dispose()
            Dim reader2 As New Reader(FilePath, Endian.Little, 0L)
            Dim Writer2 As New Writer(FilePath6, Endian.Little, 0L)
            Writer2.WriteHex(reader2.ReadHex(FileLen(FilePath)))
            reader2.Close()
            Writer2.Close()
            Dim files As BinaryReader = New BinaryReader(File.Open(FilePath, FileMode.Open))
            Dim bytes As Byte() = New Byte(FilePath.Length) {}
            Dim numberofblocks As Integer = DataGridView1(6, e.RowIndex).Value
                files.BaseStream.Position = "&H" + DataGridView1(8, e.RowIndex).Value - 4
                Dim blockoffset As Integer = "&H" + DataGridView1(8, e.RowIndex).Value - 4
                Dim numberoflines As Integer = Convert.ToInt32(files.ReadByte())
                files.BaseStream.Position = files.BaseStream.Position + 3
                Dim startblockoffs As Integer = files.ReadInt32()
                files.BaseStream.Position = files.BaseStream.Position + 2
                Dim endblockoffs As Integer = files.ReadInt32()
                Dim vertsperoffset As Integer
                Dim facesperoffset As Integer
                Dim vertstomakeface As Integer
                Dim sum As Integer
                Dim face As Integer
            Dim facesoffset As Integer
            Dim Reader As New Reader(FilePath2, Endian.Little)
                Dim Writer As New Writer(FilePath6, Endian.Big)
            Dim blockscompleted As Integer = 0
            Dim linescompleted As Integer = 0
            Reader.Position = &H100
            While blockscompleted < numberofblocks
                While linescompleted < numberoflines
                    Dim writtenVertices As New List(Of String)()
                    files.BaseStream.Position = startblockoffs + 8
                        vertstomakeface = Convert.ToInt32(files.ReadByte())
                        files.BaseStream.Position = files.BaseStream.Position + 7
                        vertsperoffset = Convert.ToInt32(files.ReadByte())
                        sum = vertsperoffset - vertstomakeface
                        facesperoffset = 1 + sum
                        Debug.WriteLine("VERTS PER OFFSET: " & vertsperoffset)
                        Debug.WriteLine("verts to make face: " & vertstomakeface)
                        files.BaseStream.Position = files.BaseStream.Position + 3
                        facesoffset = files.ReadInt32()
                    files.BaseStream.Position = facesoffset + 8
                    Dim offset As Integer = Convert.ToInt32(files.BaseStream.Position)
                        Dim i As Integer = 0
                        Dim FaceInt As Integer
                    Debug.WriteLine("Stream Pos:" & Hex(files.BaseStream.Position))
                    Writer.Position = offset
                    Dim j As Integer = 0
                    While i < vertsperoffset
                        Reader.Position = Reader.SearchString("66", StringType.Hexadecimal, Reader.Position, True, FileLen(FilePath2), True)(0)
                    While j < vertsperoffset
                            Reader.Position = Reader.SearchString("20", StringType.Hexadecimal, Reader.Position, True, FileLen(FilePath2), True)(0)
                                Reader.Position += 1
                                Debug.WriteLine("Reader Pos: " & Hex(Reader.Position))
                            Dim Read As String = Reader.ReadASCII(2)
                            If Read.Contains("/") Then
                                Dim parts As String() = Read.Split("/")
                                Dim vertexIndex As String = parts(0)
                                FaceInt = CInt(vertexIndex)
                                FaceInt -= 1
                            Else

                                FaceInt = CInt(Read)
                                FaceInt -= 1

                            End If
                                Dim ProperFaceInt As String = If(Hex(FaceInt).Length = 1, "0" & Hex(FaceInt), Hex(FaceInt))
                                Debug.WriteLine("FaceInt: " & Hex(FaceInt))
                            Debug.WriteLine("Writer Pos: " & Hex(Writer.Position))
                            If Not writtenVertices.Conta;ins(Read) Then
                            ' Write the vertex to the file
                            Writer.WriteHex((ProperFaceInt))
                                writtenVertices.Add(Read)
                                Writer.Position += 1
                            Else
                            End If
                            j += 1
                        End While
                    i += 1
                    linescompleted += 1
                    End While
                    If linescompleted = numberoflines Then
                            blockscompleted += 1
                        End If
                End While
                startblockoffs = startblockoffs + 16
                    linescompleted = 0

                    If blockscompleted <> numberofblocks Then
                        blockoffset = blockoffset + 144
                        files.BaseStream.Position = blockoffset
                        numberoflines = Convert.ToInt32(files.ReadByte())
                        files.BaseStream.Position = files.BaseStream.Position + 3
                        startblockoffs = files.ReadInt32()
                        files.BaseStream.Position = files.BaseStream.Position + 2
                        endblockoffs = files.ReadInt32()
                    End If
                End While
                files.Close()
            Writer.Close()
            MsgBox("Faces Injected Successfully !!")
        End If


    End Function
    Public Function EFaces(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        If e.ColumnIndex = 1 Then
            Dim files As BinaryReader = New BinaryReader(File.Open(FilePath, FileMode.Open))
            Dim bytes As Byte() = New Byte(FilePath.Length) {}
                Dim numberofblocks As Integer = DataGridView1(6, e.RowIndex).Value
                files.BaseStream.Position = "&H" + DataGridView1(8, e.RowIndex).Value - 4
                Dim blockoffset As Integer = "&H" + DataGridView1(8, e.RowIndex).Value - 4
                Dim numberoflines As Integer = Convert.ToInt32(files.ReadByte())
                files.BaseStream.Position = files.BaseStream.Position + 3
                Dim startblockoffs As Integer = files.ReadInt32()
                files.BaseStream.Position = files.BaseStream.Position + 2
                Dim endblockoffs As Integer = files.ReadInt32()
            Dim vertsperoffset As Integer
            Dim facesperoffset As Integer
            Dim vertstomakeface As Integer
                Dim sum As Integer
                Dim face As Integer
                Dim facesoffset As Integer
                Dim facesarray As Integer()
                Dim Writer As New Writer(FilePath3, Endian.Big)
                Writer.Position = FileLen(FilePath3)
                Dim blockscompleted As Integer = 0

                While blockscompleted < numberofblocks
                    Dim linescompleted As Integer = 0

                    While linescompleted < numberoflines
                        files.BaseStream.Position = startblockoffs + 8
                    vertstomakeface = Convert.ToInt32(files.ReadByte())
                    files.BaseStream.Position = files.BaseStream.Position + 7
                    vertsperoffset = Convert.ToInt32(files.ReadByte())
                    sum = vertsperoffset - vertstomakeface
                    facesperoffset = 1 + sum
                    Debug.WriteLine("VERTS PER OFFSET: " & vertsperoffset)
                    Debug.WriteLine("verts to make face: " & vertstomakeface)
                    files.BaseStream.Position = files.BaseStream.Position + 3
                        facesoffset = files.ReadInt32()
                        files.BaseStream.Position = facesoffset + 8
                    facesarray = New Integer(facesperoffset) {}
                    Dim offset As Integer = Convert.ToInt32(files.BaseStream.Position)
                        Dim i As Integer = 0

                    While i < facesperoffset
                        Dim j As Integer = 0
                        Writer.WriteHex("0A")
                        Writer.WriteHex("66")
                        Writer.WriteHex("20")
                        While j < vertstomakeface
                            facesarray.SetValue(files.ReadInt16() + 1, i)
                            Writer.WriteASCII(facesarray.GetValue(i).ToString() & "/" & facesarray.GetValue(i).ToString())
                        Writer.WriteHex("20")
                            j += 1
                            offset += 2
                            files.BaseStream.Position = offset
                        End While
                        i += 1
                        offset -= 4
                        files.BaseStream.Position = offset
                        Writer.WriteHex("0A")
                    End While
                    linescompleted += 1

                        If linescompleted = numberoflines Then
                            blockscompleted += 1
                        End If

                        startblockoffs = startblockoffs + 16
                    End While

                    If blockscompleted <> numberofblocks Then
                        blockoffset = blockoffset + 144
                        files.BaseStream.Position = blockoffset
                        numberoflines = Convert.ToInt32(files.ReadByte())
                        files.BaseStream.Position = files.BaseStream.Position + 3
                        startblockoffs = files.ReadInt32()
                        files.BaseStream.Position = files.BaseStream.Position + 2
                        endblockoffs = files.ReadInt32()
                    End If
                End While
                files.Close()
                Writer.Close()
                MsgBox("Faces Exported Successfully !!")
            End If


    End Function
    Public Shared Function StringToByteArray(string_5 As String) As Byte()
        Dim length As Integer = string_5.Length
        Dim array As Byte() = New Byte(length / 2 - 1) {}
        For i As Integer = 0 To length - 1 Step 2
            array(i / 2) = Convert.ToByte(string_5.Substring(i, 2), 16)
        Next
        Return array
    End Function
    Private Sub ReadOffset()
        Dim Reader As Reader = New Reader(FilePath, Endian.Big, 0)
        Try
            Dim x As Integer = DataGridView1.RowCount - 1
            Dim x2 As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim obj(DataGridView1.RowCount - 1) As Object
                For i = 0 To DataGridView1.RowCount - 1
                    obj(i) = DataGridView1.RowCount
                    Reader.Position = &H60
                    DataGridView1.Rows(i).Cells(4).Value = Hex(Reader.ReadInt32(3))
                    x2 = x2 + 1
                    i = i + 1
                    Do Until x2 = x
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(4).Value = Hex(Reader.ReadInt32(3))
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(4).Value = Hex(Reader.ReadInt32(3))
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(4).Value = Hex(Reader.ReadInt32(3))
                        x2 = x2 + 1
                        i = i + 1
                    Loop
                Next

            Next

        Catch Ex As Exception
        End Try
        Try
            If TextBox1.Text = "1" Then
                Reader.Position = &H60
                DataGridView1(4, 0).Value = Hex(Reader.ReadInt32(3))
            End If
        Catch ex As Exception

        End Try
        Reader.Close()
    End Sub

    Private Sub ObjectName()
        Try
            Dim x As Integer = DataGridView1.RowCount - 1
            Dim x2 As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim obj(DataGridView1.RowCount - 1) As Object
                For i = 0 To DataGridView1.RowCount - 1
                    obj(i) = DataGridView1.RowCount

                    Do Until x2 = x
                        DataGridView1.Rows(i).Cells(2).Value = "Object" & x2
                        x2 = x2 + 1
                        i = i + 1
                        DataGridView1.Rows(i).Cells(2).Value = "Object" & x2
                        x2 = x2 + 1
                        i = i + 1
                        DataGridView1.Rows(i).Cells(2).Value = "Object" & x2
                        x2 = x2 + 1
                        i = i + 1
                    Loop
                Next

            Next
            If TextBox1.Text = 1 Then
                DataGridView1(2, 0).Value = "Object0"
            End If
        Catch Ex As Exception
        End Try
    End Sub
    Private Sub ReadTextures()
        Dim reader As Reader = New Reader(FilePath, Endian.Little, 0)
        reader.Position = &H20
        Me.TextBox2.Text = (reader.ReadInt32)
        reader.Close()
    End Sub
    Public Property UseColumnTextForButtonValue As Boolean
    Private Sub ReadObjects()

        Dim reader As Reader = New Reader(FilePath, Endian.Little, 0)
        reader.Position = &H18
        Me.TextBox1.Text = (reader.ReadInt32)
        Try
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.ColumnCount = 0
            Dim inj As New DataGridViewButtonColumn
            inj.DataPropertyName = "PropertyName"
            inj.HeaderText = "Inject Misc."
            inj.Name = "colWhateverName"
            inj.Text = "Inject Misc."
            inj.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Insert(0, inj)
            Dim exp As New DataGridViewButtonColumn
            exp.DataPropertyName = "PropertyName"
            exp.HeaderText = "Export Misc."
            exp.Name = "colWhateverName"
            exp.Text = "Export Misc."
            exp.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Insert(1, exp)
            Dim obj As New DataGridViewTextBoxColumn
            obj.DataPropertyName = "PropertyName"
            obj.HeaderText = "Object"
            obj.Name = "colWhateverName"
            DataGridView1.Columns.Insert(2, obj)
            Dim verts As New DataGridViewTextBoxColumn
            verts.DataPropertyName = "PropertyName"
            verts.HeaderText = "Vertices"
            verts.Name = "colWhateverName"
            DataGridView1.Columns.Insert(3, verts)
            Dim Offs As New DataGridViewTextBoxColumn
            Offs.DataPropertyName = "PropertyName"
            Offs.HeaderText = "Offset"
            Offs.Name = "colWhateverName"
            DataGridView1.Columns.Insert(4, Offs)
            Dim Face As New DataGridViewTextBoxColumn
            Face.DataPropertyName = "PropertyName"
            Face.HeaderText = "Face Offset"
            Face.Name = "colWhateverName"
            DataGridView1.Columns.Insert(5, Face)
            Dim Tex As New DataGridViewTextBoxColumn
            Tex.DataPropertyName = "PropertyName"
            Tex.HeaderText = "BlocksofFacesCount"
            Tex.Name = "colWhateverName"
            DataGridView1.Columns.Insert(6, Tex)
            DataGridView1.AutoResizeRows()
            Dim Face2 As New DataGridViewTextBoxColumn
            Face2.DataPropertyName = "PropertyName"
            Face2.HeaderText = "LinesOfFaceData"
            Face2.Name = "colWhateverName"
            DataGridView1.Columns.Insert(7, Face2)
            DataGridView1.AutoResizeRows()
            Dim Face3 As New DataGridViewTextBoxColumn
            Face3.DataPropertyName = "PropertyName"
            Face3.HeaderText = "Face Info"
            Face3.Name = "colWhateverName"
            DataGridView1.Columns.Insert(8, Face3)
            DataGridView1.AutoResizeRows()
        Catch ex As Exception
        End Try
        Try
            reader.Position = &H18
            DataGridView1.Rows.Add(reader.ReadInt32)
            DataGridView1.Show()
        Catch ex As Exception
        End Try
        Try
            If TextBox1.Text = "1" Then
                reader.Position = &H18
                DataGridView1.Rows.Add(reader.ReadInt32 - 1)
                DataGridView1.Show()
            End If
        Catch ex As Exception
        End Try
        reader.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        DataGridView1.Hide()
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub Textures()
        Dim Reader As Reader = New Reader(FilePath, Endian.Big, 0)
        Try
            Dim x As Integer = DataGridView1.RowCount - 1
            Dim x2 As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim obj(DataGridView1.RowCount - 1) As Object
                For i = 0 To DataGridView1.RowCount - 1
                    obj(i) = DataGridView1.RowCount
                    Reader.Position = &H4C
                    DataGridView1.Rows(i).Cells(6).Value = Reader.ReadInt32(2)
                    x2 = x2 + 1
                    i = i + 1
                    Do Until x2 = x
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(6).Value = Reader.ReadInt32(2)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(6).Value = Reader.ReadInt32(2)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(6).Value = Reader.ReadInt32(2)
                        x2 = x2 + 1
                        i = i + 1
                    Loop
                Next

            Next

        Catch Ex As Exception
        End Try
        Try
            If TextBox1.Text = "1" Then
                Reader.Position = &H4C
                DataGridView1(6, 0).Value = Reader.ReadInt32(3)
            End If
        Catch ex As Exception
        End Try
        Reader.Close()
    End Sub
    Private Sub Vertices()
        Dim Reader As Reader = New Reader(FilePath, Endian.Big, 0)
        Try
            Dim x As Integer = DataGridView1.RowCount - 1
            Dim x2 As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim obj(DataGridView1.RowCount - 1) As Object
                For i = 0 To DataGridView1.RowCount - 1
                    obj(i) = DataGridView1.RowCount
                    Reader.Position = &H70
                    DataGridView1.Rows(i).Cells(3).Value = Reader.ReadInt32(2)
                    x2 = x2 + 1
                    i = i + 1
                    Do Until x2 = x
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(3).Value = Reader.ReadInt32(2)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(3).Value = Reader.ReadInt32(2)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(3).Value = Reader.ReadInt32(2)
                        x2 = x2 + 1
                        i = i + 1
                    Loop
                Next

            Next

        Catch Ex As Exception
        End Try
        Try
            If TextBox1.Text = "1" Then
                Reader.Position = &H70
                DataGridView1(3, 0).Value = Reader.ReadInt32(3)
            End If
        Catch ex As Exception
        End Try
        Reader.Close()
    End Sub
    Private Sub FaceCountOffset()
        Dim Reader As Reader = New Reader(FilePath, Endian.Big, 0)
        Dim Reader2 As Reader = New Reader(FilePath, Endian.Big, 0)
        Try
            Dim x As Integer = DataGridView1.RowCount - 1
            Dim x2 As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim obj(DataGridView1.RowCount - 1) As Object
                For i = 0 To DataGridView1.RowCount - 1
                    obj(i) = DataGridView1.RowCount
                    Reader.Position = &H54
                    Reader2.Position = Reader.Position
                    Reader.Position = Reader.ReadInt32(3)
                    Reader.Position = Reader.Position + &H8C
                    DataGridView1.Rows(i).Cells(7).Value = Reader.ReadInt32(1)
                    x2 = x2 + 1
                    i = i + 1
                    Do Until x2 = x
                        Reader.Position = Reader2.Position + &H40
                        Reader2.Position = Reader.Position
                        Reader.Position = Reader.ReadInt32(3)
                        Reader.Position = Reader.Position + &H8C
                        DataGridView1.Rows(i).Cells(7).Value = Reader.ReadInt32(1)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader2.Position + &H40
                        Reader2.Position = Reader.Position
                        Reader.Position = Reader.ReadInt32(3)
                        Reader.Position = Reader.Position + &H8C
                        DataGridView1.Rows(i).Cells(7).Value = Reader.ReadInt32(1)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader2.Position + &H40
                        Reader2.Position = Reader.Position
                        Reader.Position = Reader.ReadInt32(3)
                        Reader.Position = Reader.Position + &H8C
                        DataGridView1.Rows(i).Cells(7).Value = Reader.ReadInt32(1)
                        x2 = x2 + 1
                        i = i + 1
                    Loop
                Next

            Next

        Catch Ex As Exception
        End Try
        Try
            If TextBox1.Text = "1" Then
                Reader.Position = &H54
                Reader.Position = Reader.ReadInt32(3)
                Reader.Position = Reader.Position + &H8C
                DataGridView1(7, 0).Value = Reader.ReadInt32(1)
            End If
        Catch ex As Exception
        End Try
        Reader2.Close()
        Reader.Close()
    End Sub
    Private Sub FaceOffset()
        Dim Reader As Reader = New Reader(FilePath, Endian.Big, 0)
        Try
            Dim x As Integer = DataGridView1.RowCount - 1
            Dim x2 As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim obj(DataGridView1.RowCount - 1) As Object
                For i = 0 To DataGridView1.RowCount - 1
                    obj(i) = DataGridView1.RowCount
                    Reader.Position = &H54
                    DataGridView1.Rows(i).Cells(5).Value = Hex(Reader.ReadInt32(3) + &H94)
                    x2 = x2 + 1
                    i = i + 1
                    Do Until x2 = x
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(5).Value = Hex(Reader.ReadInt32(3) + &H94)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(5).Value = Hex(Reader.ReadInt32(3) + &H94)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(5).Value = Hex(Reader.ReadInt32(3) + &H94)
                        x2 = x2 + 1
                        i = i + 1
                    Loop
                Next

            Next

        Catch Ex As Exception
        End Try
        Try
            If TextBox1.Text = "1" Then
                Reader.Position = &H54
                DataGridView1(5, 0).Value = Hex(Reader.ReadInt32(3) + &H94)
            End If
        Catch ex As Exception
        End Try
        Reader.Close()
    End Sub
    Private Sub FaceInfo()
        Dim Reader As Reader = New Reader(FilePath, Endian.Big, 0)
        Try
            Dim x As Integer = DataGridView1.RowCount - 1
            Dim x2 As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim obj(DataGridView1.RowCount - 1) As Object
                For i = 0 To DataGridView1.RowCount - 1
                    obj(i) = DataGridView1.RowCount
                    Reader.Position = &H54
                    DataGridView1.Rows(i).Cells(8).Value = Hex(Reader.ReadInt32(3) + &H90)
                    x2 = x2 + 1
                    i = i + 1
                    Do Until x2 = x
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(8).Value = Hex(Reader.ReadInt32(3) + &H90)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(8).Value = Hex(Reader.ReadInt32(3) + &H90)
                        x2 = x2 + 1
                        i = i + 1
                        Reader.Position = Reader.LastPosition + &H40
                        DataGridView1.Rows(i).Cells(8).Value = Hex(Reader.ReadInt32(3) + &H90)
                        x2 = x2 + 1
                        i = i + 1
                    Loop
                Next

            Next

        Catch Ex As Exception
        End Try
        Try
            If TextBox1.Text = "1" Then
                Reader.Position = &H54
                DataGridView1(8, 0).Value = Hex(Reader.ReadInt32(3) + &H90)
            End If
        Catch ex As Exception
        End Try
        Reader.Close()
    End Sub
    Private Sub OpenArenaYOBJToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenArenaYOBJToolStripMenuItem.Click
        Try
            Dim Dialog As New OpenFileDialog
            Dialog.Filter = "YOBJ Files *.YOBJ |*.YOBJ"
            Dialog.ShowDialog()
            FilePath = Dialog.FileName
            FilePath4 = Dialog.FileName + ".bak"
            File.Create(FilePath4).Dispose()
            Dim R As New Reader(FilePath, Endian.Little)
            Dim W As New Writer(FilePath4, Endian.Little)
            W.WriteHex((R.ReadHex(FileLen(FilePath))))
            DataGridView1.Show()
            ReadObjects()
            Vertices()
            ObjectName()
            ReadTextures()
            ReadOffset()
            FaceOffset()
            Textures()
            FaceCountOffset()
            FaceInfo()
            R.Close()
            W.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class

