using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class YooMoneyPayment : IPaymentStrategy {
  private string _walletNumber;

  public YooMoneyPayment(string walletNumber) {
    _walletNumber = walletNumber;
  }

  public string Pay(double amount) {
    return $"Оплата {amount} руб. с кошелька {_walletNumber} прошла успешно";
  }
}