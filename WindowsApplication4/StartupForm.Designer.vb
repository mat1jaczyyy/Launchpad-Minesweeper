<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartupForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblInputDevice = New System.Windows.Forms.Label()
        Me.cboxInputDevice = New System.Windows.Forms.ComboBox()
        Me.cboxOutputDevice = New System.Windows.Forms.ComboBox()
        Me.lblOutputDevice = New System.Windows.Forms.Label()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.lblCredit = New System.Windows.Forms.Label()
        Me.nBombs = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nRows = New System.Windows.Forms.NumericUpDown()
        Me.nColumns = New System.Windows.Forms.NumericUpDown()
        CType(Me.nBombs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nRows, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInputDevice
        '
        Me.lblInputDevice.AutoSize = True
        Me.lblInputDevice.Location = New System.Drawing.Point(12, 13)
        Me.lblInputDevice.Name = "lblInputDevice"
        Me.lblInputDevice.Size = New System.Drawing.Size(94, 13)
        Me.lblInputDevice.TabIndex = 0
        Me.lblInputDevice.Text = "MIDI Input Device"
        '
        'cboxInputDevice
        '
        Me.cboxInputDevice.FormattingEnabled = True
        Me.cboxInputDevice.Location = New System.Drawing.Point(12, 29)
        Me.cboxInputDevice.Name = "cboxInputDevice"
        Me.cboxInputDevice.Size = New System.Drawing.Size(121, 21)
        Me.cboxInputDevice.TabIndex = 1
        '
        'cboxOutputDevice
        '
        Me.cboxOutputDevice.FormattingEnabled = True
        Me.cboxOutputDevice.Location = New System.Drawing.Point(12, 79)
        Me.cboxOutputDevice.Name = "cboxOutputDevice"
        Me.cboxOutputDevice.Size = New System.Drawing.Size(121, 21)
        Me.cboxOutputDevice.TabIndex = 3
        '
        'lblOutputDevice
        '
        Me.lblOutputDevice.AutoSize = True
        Me.lblOutputDevice.Location = New System.Drawing.Point(12, 63)
        Me.lblOutputDevice.Name = "lblOutputDevice"
        Me.lblOutputDevice.Size = New System.Drawing.Size(102, 13)
        Me.lblOutputDevice.TabIndex = 2
        Me.lblOutputDevice.Text = "MIDI Output Device"
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(166, 58)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(75, 23)
        Me.btnRun.TabIndex = 4
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'lblCredit
        '
        Me.lblCredit.AutoSize = True
        Me.lblCredit.Location = New System.Drawing.Point(141, 13)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(108, 13)
        Me.lblCredit.TabIndex = 5
        Me.lblCredit.Text = "Made by mat1jaczyyy"
        '
        'nBombs
        '
        Me.nBombs.Location = New System.Drawing.Point(93, 170)
        Me.nBombs.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nBombs.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nBombs.Name = "nBombs"
        Me.nBombs.Size = New System.Drawing.Size(120, 20)
        Me.nBombs.TabIndex = 6
        Me.nBombs.Value = New Decimal(New Integer() {99, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Bomb"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Rows"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(121, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Columns"
        '
        'nRows
        '
        Me.nRows.Location = New System.Drawing.Point(69, 121)
        Me.nRows.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nRows.Name = "nRows"
        Me.nRows.Size = New System.Drawing.Size(39, 20)
        Me.nRows.TabIndex = 6
        Me.nRows.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'nColumns
        '
        Me.nColumns.Location = New System.Drawing.Point(174, 121)
        Me.nColumns.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nColumns.Name = "nColumns"
        Me.nColumns.Size = New System.Drawing.Size(39, 20)
        Me.nColumns.TabIndex = 6
        Me.nColumns.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'StartupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 205)
        Me.Controls.Add(Me.nColumns)
        Me.Controls.Add(Me.nRows)
        Me.Controls.Add(Me.nBombs)
        Me.Controls.Add(Me.lblCredit)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboxOutputDevice)
        Me.Controls.Add(Me.lblOutputDevice)
        Me.Controls.Add(Me.cboxInputDevice)
        Me.Controls.Add(Me.lblInputDevice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StartupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MineLaunchpad"
        CType(Me.nBombs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nRows, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nColumns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblInputDevice As System.Windows.Forms.Label
    Friend WithEvents cboxInputDevice As System.Windows.Forms.ComboBox
    Friend WithEvents cboxOutputDevice As System.Windows.Forms.ComboBox
    Friend WithEvents lblOutputDevice As System.Windows.Forms.Label
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents nBombs As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents nRows As NumericUpDown
    Friend WithEvents nColumns As NumericUpDown
End Class
