public class CreditCardPayment : IPaymentStrategy {
  private readonly string _cardNumber;
  private readonly string _expiry;
  private readonly string _cvv;

  public CreditCardPayment(string cardNumber, string expiry, string cvv) {
    _cardNumber = cardNumber;
    _expiry = expiry;
    _cvv = cvv;
  }

  public string Pay(double amount) {
    if (string.IsNullOrEmpty(_cardNumber) || _cardNumber.Length < 16) {
      return "Ошибка: неверный номер карты";
    }

    if (string.IsNullOrEmpty(_expiry) || _expiry.Length != 5 || _expiry[2] != '/') {
      return "Ошибка: неверный срок действия (формат ММ/ГГ)";
    }

    if (string.IsNullOrEmpty(_cvv) || _cvv.Length != 3) {
      return "Ошибка: неверный CVV";
    }

    return $"Оплата {amount} руб. картой {_cardNumber} прошла успешно";
  }
}