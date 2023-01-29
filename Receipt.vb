Public Class Receipt
    Private Sub Receipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayReceipt()
    End Sub

    'Function to display the receipt'
    Private Sub DisplayReceipt()
        lstReceipt.Items.Add("******************************************************")
        lstReceipt.Items.Add(vbTab + "Mia's Sandwich Shop" + vbCrLf)
        lstReceipt.Items.Add("******************************************************")

        'Passing the data from orders listBox to Receipt listBox'
        Dim orders As Integer
        For orders = 0 To Form1.lstOrders.Items.Count - 1 Step 1
            lstReceipt.Items.Add(Form1.lstOrders.Items.Item(orders).ToString)
        Next
        lstReceipt.Items.Add("-----------------------------------------------------------")
        lstReceipt.Items.Add("Subtotal" + vbTab + vbTab + vbTab + Form1.lblSubtotal.Text)
        lstReceipt.Items.Add("Tax" + vbTab + vbTab + vbTab + Form1.lblTax.Text)
        lstReceipt.Items.Add("Total" + vbTab + vbTab + vbTab + Form1.lblTotal.Text)
        lstReceipt.Items.Add("")
        lstReceipt.Items.Add(DateAndTime.Now)
        lstReceipt.Items.Add("")
        lstReceipt.Items.Add("")
        lstReceipt.Items.Add("Thank you for visiting Mia's Sandwich Shop")
        lstReceipt.Items.Add(vbTab + "Enjoy your meal!")
    End Sub
End Class