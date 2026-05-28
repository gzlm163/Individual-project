using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreditCardPayment : IPaymentStrategy {
  private string _cardNumber;

  public CreditCardPayment(string cardNumber, string expiry, string cvv) {
    _cardNumber = cardNumber;
  }

  public string Pay(double amount) {
    return $"Оплата {amount} руб. картой {_cardNumber} прошла успешно";
  }
}