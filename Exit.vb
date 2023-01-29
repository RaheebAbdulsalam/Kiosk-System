Public Class [Exit]
    Public Shared Function ExitSystem()
        Dim iExit As DialogResult
        iExit = MessageBox.Show("Please confirm that you want to exit", "Kiosk Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If iExit = DialogResult.Yes Then
            Application.Exit()
        End If

    End Function
End Class
