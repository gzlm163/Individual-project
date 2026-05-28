public class YooMoneyPayment : IPaymentStrategy {
  private readonly string _walletNumber;

  public YooMoneyPayment(string walletNumber) {
    _walletNumber = walletNumber;
  }

  public string Pay(double amount) {
    if (string.IsNullOrEmpty(_walletNumber) || _walletNumber.Length < 10) {
      return "Ошибка: неверный номер кошелька";
    }

    return $"Оплата {amount} руб. с кошелька {_walletNumber} прошла успешно";
  }
}