Public Class Form1

    Private orderCost As New Prices

    '==================Form Load====================================================='
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetNumericUpDown()
        resetCheckBox()
    End Sub

    ' All Buttons'
    '=================================The Exit button=============================='
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        [Exit].ExitSystem()
    End Sub

    '=================================The Reset Button============================'
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        resetNumericUpDown()
        resetCheckBox()
        clearListBox()
    End Sub
    '========================The Finish button===================================='
    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        GetTotal()
    End Sub

    '=================================Adding to basket Buttons========================================='
    Private Sub btn_AddFillet_Click(sender As Object, e As EventArgs) Handles btn_AddFillet.Click
        AddChickenFillet()
    End Sub

    Private Sub btn_AddTikka_Click(sender As Object, e As EventArgs) Handles btn_AddTikka.Click
        AddChickenTikka()
    End Sub

    Private Sub btn_AddSteak_Click(sender As Object, e As EventArgs) Handles btn_AddSteak.Click
        AddSteak()
    End Sub

    Private Sub btn_AddVegie_Click(sender As Object, e As EventArgs) Handles btn_AddVegie.Click
        AddVegie()
    End Sub

    Private Sub btnAddTuna_Click(sender As Object, e As EventArgs) Handles btnAddTuna.Click
        AddTuna()
    End Sub
    Private Sub btn_AddPepsi_Click(sender As Object, e As EventArgs) Handles btn_AddPepsi.Click
        AddPepsi()
    End Sub

    Private Sub btn_AddDiet_Click(sender As Object, e As EventArgs) Handles btn_AddDiet.Click
        AddDiet()
    End Sub

    Private Sub btn_Add7UP_Click(sender As Object, e As EventArgs) Handles btn_Add7UP.Click
        AddSevenUp()
    End Sub

    Private Sub btn_AddWater_Click(sender As Object, e As EventArgs) Handles btn_AddWater.Click
        AddWater()
    End Sub

    '==============================The checkout button that transfer to the payment page======================================'
    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        Dim receipt = New payment()
        receipt.Show()
        Me.Hide()
    End Sub
    '=======================Enable NumericUpDown when CheckBoxes are checked============================'
    Private Sub chk_CickenFillet_CheckedChanged(sender As Object, e As EventArgs) Handles chk_CickenFillet.CheckedChanged
        AllowFilletNud()
    End Sub

    Private Sub chk_CickenTikka_CheckedChanged(sender As Object, e As EventArgs) Handles chk_CickenTikka.CheckedChanged
        AllowTikkaNud()
    End Sub

    Private Sub chk_Steak_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Steak.CheckedChanged
        AllowSteakNud()
    End Sub

    Private Sub chk_Vegie_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Vegie.CheckedChanged
        AllowVegieNud()
    End Sub

    Private Sub chk_Tuna_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Tuna.CheckedChanged
        AllowTunaNud()
    End Sub

    Private Sub chk_pepsi_CheckedChanged(sender As Object, e As EventArgs) Handles chk_pepsi.CheckedChanged
        AllowPepsiNud()
    End Sub

    Private Sub chk_diet_CheckedChanged(sender As Object, e As EventArgs) Handles chk_diet.CheckedChanged
        AllowDietNud()
    End Sub

    Private Sub chk_7UP_CheckedChanged(sender As Object, e As EventArgs) Handles chk_7UP.CheckedChanged
        AllowSevenUpNud()
    End Sub

    Private Sub chk_water_CheckedChanged(sender As Object, e As EventArgs) Handles chk_water.CheckedChanged
        AllowWaterNud()
    End Sub


    '===========================Reusable codes======================================='
    'A Function Clearing all the numericUpDown'
    Private Sub resetNumericUpDown()
        For Each nud In {nud_ChickenFillet, nud_ChickenTikka, nud_Steak, nud_Tuna, nud_Vegie, nud_Pepsi, nud_diet, nud_7UP, nud_water}
            nud.Value = "0"
            nud.Enabled = False
        Next
        lblSubtotal.Text = ""
        lblTax.Text = ""
        lblTotal.Text = ""
        lstOrders.Text = ""
    End Sub

    'A Function to clear all the checkBoxes'
    Private Sub resetCheckBox()
        For Each chk In {chk_CickenFillet, chk_CickenTikka, chk_Steak, chk_Tuna, chk_Vegie, chk_pepsi, chk_diet, chk_7UP, chk_water}
            chk.Checked = False
        Next
    End Sub

    'A Function to clear the listBoxe'
    Private Sub clearListBox()
        lstOrders.Items.Clear()
    End Sub

    'A Function to Calculate the Total amount'
    Private Sub GetTotal()
        Dim iTax, total As Double
        orderCost.chickenFillet = orderCost.chickenFilletPrice * Double.Parse(nud_ChickenFillet.Value)
        orderCost.chickenTikka = orderCost.chickenTikkaPrice * Double.Parse(nud_ChickenTikka.Value)
        orderCost.steak = orderCost.steakPrice * Double.Parse(nud_Steak.Value)
        orderCost.vegie = orderCost.vegiePrice * Double.Parse(nud_Vegie.Value)
        orderCost.tuna = orderCost.tunaPrice * Double.Parse(nud_Tuna.Value)
        orderCost.pepsi = orderCost.pepsiPrice * Double.Parse(nud_Pepsi.Value)
        orderCost.diet = orderCost.dietPrice * Double.Parse(nud_diet.Value)
        orderCost.sevenUp = orderCost.sevenUpPrice * Double.Parse(nud_7UP.Value)
        orderCost.water = orderCost.waterPrice * Double.Parse(nud_water.Value)

        'Subtotal'
        Dim subtotal As Double = orderCost.GetAmount
        lblSubtotal.Text = FormatCurrency(subtotal)

        'Tax'
        iTax = orderCost.FindTax(subtotal)
        lblTax.Text = FormatCurrency(iTax)

        'Total'
        total = subtotal + iTax
        lblTotal.Text = FormatCurrency(total)

    End Sub

    'Functions to Add items to the Basket'
    Private Sub AddChickenFillet()
        orderCost.chickenFillet = orderCost.chickenFilletPrice * Double.Parse(nud_ChickenFillet.Value)
        lstOrders.Items.Add("Chicken Fillet" + vbTab + nud_ChickenFillet.Value.ToString + vbTab + FormatCurrency(orderCost.chickenFillet.ToString) + vbCrLf)
    End Sub

    Private Sub AddChickenTikka()
        orderCost.chickenTikka = orderCost.chickenTikkaPrice * Double.Parse(nud_ChickenTikka.Value)
        lstOrders.Items.Add("Chicken Tikka" + vbTab + nud_ChickenTikka.Value.ToString + vbTab + FormatCurrency(orderCost.chickenTikka.ToString) + vbCrLf)
    End Sub

    Private Sub AddSteak()
        orderCost.steak = orderCost.steakPrice * Double.Parse(nud_Steak.Value)
        lstOrders.Items.Add("Steak & Cheese" + vbTab + nud_Steak.Value.ToString + vbTab + FormatCurrency(orderCost.steak.ToString) + vbCrLf)
    End Sub

    Private Sub AddVegie()
        orderCost.vegie = orderCost.vegiePrice * Double.Parse(nud_Vegie.Value)
        lstOrders.Items.Add("Vegie" + vbTab + vbTab + nud_Vegie.Value.ToString + vbTab + FormatCurrency(orderCost.vegie.ToString) + vbCrLf)
    End Sub

    Private Sub AddTuna()
        orderCost.tuna = orderCost.tunaPrice * Double.Parse(nud_Tuna.Value)
        lstOrders.Items.Add("Tuna" + vbTab + vbTab + nud_Tuna.Value.ToString + vbTab + FormatCurrency(orderCost.tuna.ToString) + vbCrLf)
    End Sub

    Private Sub AddPepsi()
        orderCost.tuna = orderCost.pepsiPrice * Double.Parse(nud_Pepsi.Value)
        lstOrders.Items.Add("Pepsi" + vbTab + vbTab + nud_Pepsi.Value.ToString + vbTab + FormatCurrency(orderCost.tuna.ToString) + vbCrLf)
    End Sub

    Private Sub AddDiet()
        orderCost.diet = orderCost.dietPrice * Double.Parse(nud_diet.Value)
        lstOrders.Items.Add("Pepsi Diet" + vbTab + vbTab + nud_diet.Value.ToString + vbTab + FormatCurrency(orderCost.diet.ToString) + vbCrLf)
    End Sub

    Private Sub AddSevenUp()
        orderCost.sevenUp = orderCost.sevenUpPrice * Double.Parse(nud_7UP.Value)
        lstOrders.Items.Add("7UP" + vbTab + vbTab + nud_7UP.Value.ToString + vbTab + FormatCurrency(orderCost.sevenUp.ToString) + vbCrLf)
    End Sub

    Private Sub AddWater()
        orderCost.water = orderCost.waterPrice * Double.Parse(nud_water.Value)
        lstOrders.Items.Add("Water" + vbTab + vbTab + nud_water.Value.ToString + vbTab + FormatCurrency(orderCost.water.ToString) + vbCrLf)
    End Sub

    'Functions to only allow the NumericUpDown when the checkeboxes are checked'
    Private Sub AllowFilletNud()
        If chk_CickenFillet.Checked = True Then
            nud_ChickenFillet.Enabled = True
        Else
            nud_ChickenFillet.Enabled = False
        End If
    End Sub
    Private Sub AllowTikkaNud()
        If chk_CickenTikka.Checked = True Then
            nud_ChickenTikka.Enabled = True
        Else
            nud_ChickenTikka.Enabled = False
        End If
    End Sub
    Private Sub AllowSteakNud()
        If chk_Steak.Checked = True Then
            nud_Steak.Enabled = True
        Else
            nud_Steak.Enabled = False
        End If
    End Sub
    Private Sub AllowVegieNud()
        If chk_Vegie.Checked = True Then
            nud_Vegie.Enabled = True
        Else
            nud_Vegie.Enabled = False
        End If
    End Sub
    Private Sub AllowTunaNud()
        If chk_Tuna.Checked = True Then
            nud_Tuna.Enabled = True
        Else
            nud_Tuna.Enabled = False
        End If
    End Sub
    Private Sub AllowPepsiNud()
        If chk_pepsi.Checked = True Then
            nud_Pepsi.Enabled = True
        Else
            nud_Pepsi.Enabled = False
        End If
    End Sub
    Private Sub AllowDietNud()
        If chk_diet.Checked = True Then
            nud_diet.Enabled = True
        Else
            nud_diet.Enabled = False
        End If
    End Sub
    Private Sub AllowSevenUpNud()
        If chk_7UP.Checked = True Then
            nud_7UP.Enabled = True
        Else
            nud_7UP.Enabled = False
        End If
    End Sub
    Private Sub AllowWaterNud()
        If chk_water.Checked = True Then
            nud_water.Enabled = True
        Else
            nud_water.Enabled = False
        End If
    End Sub
End Class







