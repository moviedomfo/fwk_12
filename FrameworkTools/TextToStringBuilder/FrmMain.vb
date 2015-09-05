Imports System.Text
Imports Fwk.Controls.Win32.TextCodeEditor

Public Class FrmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents cbPreserveCRLF As System.Windows.Forms.CheckBox
    Friend WithEvents rbVB As System.Windows.Forms.RadioButton
    Friend WithEvents rbCSharp As System.Windows.Forms.RadioButton

    Friend WithEvents tbSource As System.Windows.Forms.TextBox
    Friend WithEvents tbResult As TextCodeEditor
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.pnlButtons = New System.Windows.Forms.Panel
        Me.rbCSharp = New System.Windows.Forms.RadioButton
        Me.rbVB = New System.Windows.Forms.RadioButton
        Me.cbPreserveCRLF = New System.Windows.Forms.CheckBox
        Me.btnCopy = New System.Windows.Forms.Button
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.tbSource = New System.Windows.Forms.TextBox
        Me.tbResult = New TextCodeEditor
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.White
        Me.pnlButtons.Controls.Add(Me.rbCSharp)
        Me.pnlButtons.Controls.Add(Me.rbVB)
        Me.pnlButtons.Controls.Add(Me.cbPreserveCRLF)
        Me.pnlButtons.Controls.Add(Me.btnCopy)
        Me.pnlButtons.Controls.Add(Me.btnGenerate)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 561)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(783, 56)
        Me.pnlButtons.TabIndex = 0
        '
        'rbCSharp
        '
        Me.rbCSharp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbCSharp.Location = New System.Drawing.Point(575, 27)
        Me.rbCSharp.Name = "rbCSharp"
        Me.rbCSharp.Size = New System.Drawing.Size(40, 24)
        Me.rbCSharp.TabIndex = 4
        Me.rbCSharp.Text = "C#"
        '
        'rbVB
        '
        Me.rbVB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbVB.Checked = True
        Me.rbVB.Location = New System.Drawing.Point(575, 3)
        Me.rbVB.Name = "rbVB"
        Me.rbVB.Size = New System.Drawing.Size(40, 24)
        Me.rbVB.TabIndex = 3
        Me.rbVB.TabStop = True
        Me.rbVB.Text = "VB"
        '
        'cbPreserveCRLF
        '
        Me.cbPreserveCRLF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbPreserveCRLF.Location = New System.Drawing.Point(184, 16)
        Me.cbPreserveCRLF.Name = "cbPreserveCRLF"
        Me.cbPreserveCRLF.Size = New System.Drawing.Size(128, 24)
        Me.cbPreserveCRLF.TabIndex = 2
        Me.cbPreserveCRLF.Text = "Preserve New Lines"
        '
        'btnCopy
        '
        Me.btnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopy.BackColor = System.Drawing.Color.SlateGray
        Me.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopy.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCopy.Location = New System.Drawing.Point(16, 11)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(112, 32)
        Me.btnCopy.TabIndex = 1
        Me.btnCopy.Text = "Copy To Clipboard"
        Me.btnCopy.UseVisualStyleBackColor = False
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.BackColor = System.Drawing.Color.SlateGray
        Me.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerate.Location = New System.Drawing.Point(655, 11)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(112, 32)
        Me.btnGenerate.TabIndex = 0
        Me.btnGenerate.Text = "Generate Code"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 558)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(783, 3)
        Me.Splitter1.TabIndex = 4
        Me.Splitter1.TabStop = False
        '
        'tbSource
        '
        Me.tbSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSource.Location = New System.Drawing.Point(0, 2)
        Me.tbSource.Multiline = True
        Me.tbSource.Name = "tbSource"
        Me.tbSource.Size = New System.Drawing.Size(781, 199)
        Me.tbSource.TabIndex = 6
        '
        'tbResult
        '
        Me.tbResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbResult.Location = New System.Drawing.Point(3, 204)
        Me.tbResult.Name = "tbResult"
        Me.tbResult.Size = New System.Drawing.Size(780, 351)
        Me.tbResult.TabIndex = 7
        Me.tbResult.TitleText = ""
        Me.tbResult.TitleVisible = True
        '
        'FrmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(783, 617)
        Me.Controls.Add(Me.tbResult)
        Me.Controls.Add(Me.tbSource)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.pnlButtons)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(552, 416)
        Me.Name = "FrmMain"
        Me.Text = "Text to String Builder"
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Function GenerateVBStringBuilderCode() As String
        Dim s As String
        Dim sb As New StringBuilder(5000)
        'Append StringBuilder declaration
        sb.Append("Dim sb As New System.Text.StringBuilder(5000)")
        sb.Append(vbCrLf)
        For Each s In Me.tbSource.Lines
            'Append each line
            sb.Append("sb.Append(""")
            sb.Append(EscapeString(s))
            sb.Append(""")")
            sb.Append(vbCrLf)
            If Me.cbPreserveCRLF.Checked Then
                'Append a vbCrLf if new lines are to be preserved
                sb.Append("sb.Append(vbCrLf)")
                sb.Append(vbCrLf)
            End If
        Next
        Return sb.ToString
    End Function

    Private Function GenerateCSharpStringBuilderCode() As String
        Dim s As String
        Dim sb As New StringBuilder(5000)
        'Append StringBuilder declaration
        sb.Append("System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);")
        sb.Append(vbCrLf)
        For Each s In Me.tbSource.Lines
            'Append each line
            sb.Append("sb.Append(@""")
            sb.Append(EscapeString(s))
            sb.Append(""");")
            sb.Append(vbCrLf)
            If Me.cbPreserveCRLF.Checked Then
                'Append a vbCrLf if new lines are to be preserved
                sb.Append("sb.Append(Environment.NewLine);")
                sb.Append(vbCrLf)
            End If
        Next
        Return sb.ToString
    End Function

    Private Sub CopyToClipboard()
        'Put the generated code on the clipboard
        Try
            Clipboard.SetDataObject(Me.tbResult.Text)
        Catch
            MessageBox.Show("The code could not be copied to the clipboard.", "Error Copying to Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Function EscapeString(ByVal source As String) As String
        'Escape(double) any quotes that appear in the text
        If Not source Is Nothing Then
            Return source.Replace("""", """""")
        Else
            Return String.Empty
        End If
    End Function

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If Me.rbVB.Checked Then
            Me.tbResult.Text = Me.GenerateVBStringBuilderCode
        Else
            Me.tbResult.Text = Me.GenerateCSharpStringBuilderCode
        End If
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Me.CopyToClipboard()
    End Sub

    Private Sub pnlButtons_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlButtons.Paint

    End Sub
End Class
