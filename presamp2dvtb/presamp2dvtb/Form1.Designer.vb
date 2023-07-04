<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmmain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btninput = New System.Windows.Forms.Button()
        Me.OpenFileDialoginput = New System.Windows.Forms.OpenFileDialog()
        Me.btnOutput = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.lstInputView = New System.Windows.Forms.ListBox()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'btninput
        '
        Me.btninput.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btninput.Location = New System.Drawing.Point(12, 12)
        Me.btninput.Name = "btninput"
        Me.btninput.Size = New System.Drawing.Size(91, 23)
        Me.btninput.TabIndex = 4
        Me.btninput.Text = "input file"
        Me.btninput.UseVisualStyleBackColor = True
        '
        'OpenFileDialoginput
        '
        Me.OpenFileDialoginput.FileName = "presamp.ini"
        Me.OpenFileDialoginput.Filter = """ini files (*.ini)|*.ini|All files (*.*)|*.*"""
        Me.OpenFileDialoginput.InitialDirectory = """c:/"""
        Me.OpenFileDialoginput.RestoreDirectory = True
        '
        'btnOutput
        '
        Me.btnOutput.Location = New System.Drawing.Point(206, 12)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New System.Drawing.Size(91, 23)
        Me.btnOutput.TabIndex = 7
        Me.btnOutput.Text = "Output"
        Me.btnOutput.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(109, 12)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(91, 23)
        Me.btnChange.TabIndex = 6
        Me.btnChange.Text = "Change"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'lstInputView
        '
        Me.lstInputView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstInputView.HorizontalExtent = 500
        Me.lstInputView.HorizontalScrollbar = True
        Me.lstInputView.ItemHeight = 15
        Me.lstInputView.Location = New System.Drawing.Point(12, 50)
        Me.lstInputView.Name = "lstInputView"
        Me.lstInputView.ScrollAlwaysVisible = True
        Me.lstInputView.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstInputView.Size = New System.Drawing.Size(360, 199)
        Me.lstInputView.TabIndex = 5
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.DefaultExt = "txt"
        Me.SaveFileDialog.FileName = "Resultdvtb.txt"
        Me.SaveFileDialog.Filter = """txt Files (*.txt*)|*.txt"""
        '
        'frmmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoScrollMinSize = New System.Drawing.Size(330, 220)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(384, 261)
        Me.Controls.Add(Me.btninput)
        Me.Controls.Add(Me.btnOutput)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.lstInputView)
        Me.MaximumSize = New System.Drawing.Size(1000, 750)
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "frmmain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "presamp2dvtb_aphla_0.0.1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btninput As Button
    Friend WithEvents OpenFileDialoginput As OpenFileDialog
    Friend WithEvents btnOutput As Button
    Friend WithEvents btnChange As Button
    Friend WithEvents lstInputView As ListBox
    Friend WithEvents SaveFileDialog As SaveFileDialog
End Class
