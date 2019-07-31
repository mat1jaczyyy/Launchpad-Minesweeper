Imports Midi

Public Class StartupForm
    Sub StartupForm_Load() Handles MyBase.Load
        For Each inputDevice As Midi.InputDevice In Midi.InputDevice.InstalledDevices
            cboxInputDevice.Items.Add(inputDevice.Name)
        Next inputDevice

        For Each outputDevice As Midi.OutputDevice In Midi.OutputDevice.InstalledDevices
            cboxOutputDevice.Items.Add(outputDevice.Name)
        Next outputDevice
    End Sub

    Sub btnRun_Click() Handles btnRun.Click
        Dim MainForm As New MainForm
        MainForm.inputDevice = Midi.InputDevice.InstalledDevices.Item(cboxInputDevice.SelectedIndex)
        MainForm.outputDevice = Midi.OutputDevice.InstalledDevices.Item(cboxOutputDevice.SelectedIndex)
        MainForm.nBombs = nBombs.Value
        MainForm.nRows = nRows.Value
        MainForm.nColumns = nColumns.Value
        MainForm.Show()
        Me.Close()
    End Sub

    Private Sub StartupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub nColumns_ValueChanged(sender As Object, e As EventArgs) Handles nColumns.ValueChanged

    End Sub

    Private Sub nRows_ValueChanged(sender As Object, e As EventArgs) Handles nRows.ValueChanged

    End Sub
End Class