Public Class payment

    '==============The form Load================='
    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAmountDue.Text = Form1.lblTotal.Text
        ComboBox1.Items.Add("Cash")
        ComboBox1.Items.Add("Card")
    End Sub

    '===============The cancel Button=============='
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim cancel = New Form1()
        cancel.Show()
        Me.Hide()
    End Sub

    '========The complete transictionbutton========='
    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        completeTransaction()

    End Sub
    '===============ComboBox===================='
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        chooseMethod()
    End Sub

    '===========================Actual code======================================='
    'A function to get the change'
    Private Sub completeTransaction()
        Dim change, paid, due As Double
        paid = FormatCurrency(txtAmountPaid.Text)
        due = FormatCurrency(lblAmountDue.Text)
        change = paid - due
        txtChange.Text = FormatCurrency(change)

        'If the change is less than 0 then show an error message'
        If txtChange.Text < 0 Then
            MessageBox.Show("Please pay you balance")

        Else
            'If the change is more than 0 then successful message and receipt'
            Dim result As DialogResult = MessageBox.Show("Thanks for ordering with Mia's Sanwich Shop, Do you want a receipt?",
                                                      "Succeful Payment", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim receipt = New Receipt()
                receipt.Show()
                Me.Hide()

            ElseIf result = DialogResult.No Then
                [Exit].ExitSystem()
            End If

        End If
    End Sub

    'If payment method have been chosen then enable payment inputs'
    Private Sub chooseMethod()
        If ComboBox1.Text = "Cash" Then
            txtFirstName.Enabled = False
            txtSurname.Enabled = False
            txtCardNo.Enabled = False
            txtCVV.Enabled = False
            txtDate1.Enabled = False
            txtDate2.Enabled = False
        End If
    End Sub
End Class