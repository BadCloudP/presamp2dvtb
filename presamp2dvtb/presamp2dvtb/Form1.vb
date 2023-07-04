Imports System.IO
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
'by_邪云
Public Class frmmain
    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninput.Click
        Dim inputdata As String
        lstInputView.Items.Clear()
        '开启档案
        If OpenFileDialoginput.ShowDialog() = DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(OpenFileDialoginput.FileName)
            inputdata = sr.ReadToEnd
            sr.Close()
            Dim lstInput() = Split(inputdata, vbLf)
            '导出list
            For lstInput_i = 0 To lstInput.Count - 1
                lstInputView.Items.Add(lstInput(lstInput_i))
            Next
        End If
    End Sub

    Private Sub frmmain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstInputView.Items.Clear()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click

        Dim lstInput(lstInputView.Items.Count - 1) As String
        '导入序列
        For lstInput_i = 0 To lstInput.Count - 1
            lstInput(lstInput_i) = lstInputView.Items(lstInput_i)
        Next
        Dim CheckVowel As Boolean
        Dim CheckCnsonant As Boolean
        Dim inputVersion As Double
        Dim InVowel As Boolean
        Dim InCnsonant As Boolean
        Dim VowelCount(2) As Integer
        Dim CnsonantCount(2) As Integer
        Dim HavePriority As Boolean '暂时没用，用于未来的缺失检查。
        Dim VowelReday As Boolean
        Dim CnsonantReday As Boolean
        For lst_i = 0 To lstInput.Count - 1
            '计算行数
            If InVowel = True Then
                VowelCount(2) += 1
                VowelReday = True
            ElseIf InCnsonant = True Then
                CnsonantCount(2) += 1
                CnsonantReday = True
            End If
            '寻找各个key的起点
            If lstInput(lst_i).IndexOf("[VERSION]") <> -1 Then
                inputVersion = lstInput(lst_i + 1)
            ElseIf lstInput(lst_i).IndexOf("[VOWEL]") <> -1 Then
                InVowel = True
                VowelCount(1) = CInt(lst_i + 1)
                CheckVowel = True
            ElseIf lstInput(lst_i).IndexOf("[CONSONANT]") <> -1 Then
                InVowel = False
                InCnsonant = True
                CnsonantCount(1) = CInt(lst_i + 1)
                CheckCnsonant = True
            ElseIf lstInput(lst_i).IndexOf("[APPEND]") <> -1 Then
                InCnsonant = False
            ElseIf lstInput(lst_i).IndexOf("[PRIORITY]") <> -1 Then
                InCnsonant = False
                HavePriority = True
                Dim inputPriority As String '暂时没用，用于未来的缺失检查。
                inputPriority = lstInput(lst_i + 1)
                Dim Priority() = Split(inputPriority, ",")
            ElseIf lstInput(lst_i).IndexOf("[REPLACE]") <> -1 Then
                InCnsonant = False
            End If
        Next
        If VowelReday And CnsonantReday Then
            '处理部分
            Dim ResultAll As String = "[SymbolList]" & vbLf
            Dim inputVowelarray(VowelCount(2) - 2) As String
            Dim inputCnsonantarray(CnsonantCount(2) - 2) As String
            Dim CorV_i As Integer = 0
            '分开VC序列
            For inputVowelarray_i = VowelCount(1) To VowelCount(1) + inputVowelarray.Count - 1
                inputVowelarray(CorV_i) = lstInput(inputVowelarray_i)
                CorV_i += 1
            Next
            CorV_i = 0
            For inputCnsonantarray_i = CnsonantCount(1) To CnsonantCount(1) + inputCnsonantarray.Count - 1
                inputCnsonantarray(CorV_i) = lstInput(inputCnsonantarray_i)
                CorV_i += 1
            Next
            '分开每一列
            Dim TempArray(3) As String
            Dim Vowelarray0(inputVowelarray.Count - 1) As String
            Dim Vowelarray1(inputVowelarray.Count - 1) As String
            Dim Vowelarray2(inputVowelarray.Count - 1) As String
            Dim Vowelarray3(inputVowelarray.Count - 1) As Integer
            Dim Cnsonantarray0(inputCnsonantarray.Count - 1) As String
            Dim Cnsonantarray1(inputCnsonantarray.Count - 1) As String
            Dim Cnsonantarray2(inputCnsonantarray.Count - 1) As Integer
            For Vowelarray_i = 0 To inputVowelarray.Count - 1
                TempArray = Split(inputVowelarray(Vowelarray_i), "=")
                Vowelarray0(Vowelarray_i) = TempArray(0)
                Vowelarray1(Vowelarray_i) = TempArray(1)
                Vowelarray2(Vowelarray_i) = TempArray(2)
                Vowelarray3(Vowelarray_i) = TempArray(3)
            Next
            For Cnsonant_i = 0 To inputCnsonantarray.Count - 1
                TempArray = Split(inputCnsonantarray(Cnsonant_i), "=")
                Cnsonantarray0(Cnsonant_i) = TempArray(0)
                Cnsonantarray1(Cnsonant_i) = TempArray(1)
                Cnsonantarray2(Cnsonant_i) = TempArray(2)
            Next
            '组合起来
            For Cnsonant_1_i = 0 To inputCnsonantarray.Count - 1
                Dim Cnsonant_1_Input() = Split(CStr(Cnsonantarray1(Cnsonant_1_i)), ",")
                For Cnsonant_1_Input_i = 0 To Cnsonant_1_Input.Count - 1
                    For Vowel_2_i = 0 To inputVowelarray.Count - 1
                        Dim Vowel_2_Input() = Split(CStr(Vowelarray2(Vowel_2_i)), ",")
                        For Vowel_2_Input_i = 0 To Vowel_2_Input.Count - 1
                            If Cnsonant_1_Input(Cnsonant_1_Input_i) = Vowel_2_Input(Vowel_2_Input_i) Then
                                ResultAll += Cnsonant_1_Input(Cnsonant_1_Input_i) & "," & Cnsonantarray0(Cnsonant_1_i) & "," & Vowelarray0(Vowel_2_i) & vbLf
                            End If
                        Next


                    Next

                Next
            Next
            lstInputView.Items.Clear()
            '输出
            ResultAll += "[VowelList]" & vbLf
            For Vowel_list_i = 0 To inputVowelarray.Count - 1
                Dim TempVowellist() = Split(Vowelarray2(Vowel_list_i), ",")
                ResultAll += Vowelarray0(Vowel_list_i) & "," & TempVowellist(0) & vbLf
            Next
            ResultAll += "[Cnsonant = 1]" & vbLf
            For Cnsonant_list1_i = 0 To inputCnsonantarray.Count - 1
                If Cnsonantarray2(Cnsonant_list1_i) = 1 Then
                    ResultAll += Cnsonantarray0(Cnsonant_list1_i) & vbLf
                End If
            Next
            ResultAll += "[Cnsonant = 0]" & vbLf
            Dim IsinVowel As Boolean = False
            For Cnsonant_list0_i = 0 To inputCnsonantarray.Count - 1
                If Cnsonantarray2(Cnsonant_list0_i) = 0 Then
                    For vowelarray_i = 0 To inputVowelarray.Count - 1
                        '防止V部分重复
                        If Cnsonantarray1(Cnsonant_list0_i).IndexOf(Vowelarray0(vowelarray_i)) = 0 Then
                            IsinVowel = True
                        End If
                    Next
                    If IsinVowel = True Then
                        IsinVowel = False
                    Else
                        ResultAll += Cnsonantarray0(Cnsonant_list0_i) & vbLf
                    End If
                End If
            Next
            Dim lstoutput() = Split(ResultAll, vbLf)
            'refill the list
            For lstoutput_i = 0 To lstoutput.Count - 1
                lstInputView.Items.Add(lstoutput(lstoutput_i))
            Next
        End If
    End Sub

    Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click
        Dim IsChanged As Boolean = False
        If lstInputView.Items(0).IndexOf("[SymbolList]") <> -1 Then
            IsChanged = True
        End If
        '导出文件
        If IsChanged = True Then
            Dim ResultAll As String = ""
            For lstInput_i = 0 To lstInputView.Items.Count - 1
                ResultAll += lstInputView.Items(lstInput_i) & vbLf
            Next
            If SaveFileDialog.ShowDialog = DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog.FileName, ResultAll, True)
            End If
        End If
    End Sub

End Class
