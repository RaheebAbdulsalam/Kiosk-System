Public Class Prices
    'Sandwiches'
    Public chickenFillet As Double
    Public chickenTikka As Double
    Public steak As Double
    Public vegie As Double
    Public tuna As Double
    'Drinks'
    Public pepsi As Double
    Public diet As Double
    Public sevenUp As Double
    Public water As Double

    'Prices'
    Public chickenFilletPrice As Double = 3.75
    Public chickenTikkaPrice As Double = 3.0
    Public steakPrice As Double = 2.5
    Public vegiePrice As Double = 2.0
    Public tunaPrice As Double = 1.5
    Public pepsiPrice As Double = 0.7
    Public dietPrice As Double = 0.75
    Public sevenUpPrice As Double = 0.75
    Public waterPrice As Double = 1.0

    'Tax and subtotal variables'
    Private taxRate = 0.1
    Private subtotal As Double

    'A Function to get the subtotal amount'
    Public Function GetAmount()
        subtotal = chickenFillet + chickenTikka + steak + vegie + tuna + pepsi + diet + sevenUp + water
        Return subtotal
    End Function

    'A Function to calculate the Tax'
    Public Function FindTax(ByVal cAmount As Double) As Double
        FindTax = (cAmount * taxRate)
        Return FindTax
    End Function



End Class

