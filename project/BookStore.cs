using System;
using System.Collections.Generic;

public class BookStore {
  private List<Book> _books;
  private Cart _cart;
  private ConsoleView _view;

  public BookStore(ConsoleView view) {
    _view = view;
    _books = new List<Book>
    {
            new Book(1, "Война и мир", "Толстой Л.Н.", 500),
            new Book(2, "Преступление и наказание", "Достоевский Ф.М.", 450),
            new Book(3, "Мастер и Маргарита", "Булгаков М.А.", 550),
            new Book(4, "Евгений Онегин", "Пушкин А.С.", 350),
            new Book(5, "Анна Каренина", "Толстой Л.Н.", 480),
            new Book(6, "Идиот", "Достоевский Ф.М.", 420),
            new Book(7, "Мертвые души", "Гоголь Н.В.", 400),
            new Book(8, "Ревизор", "Гоголь Н.В.", 300),
            new Book(9, "Отцы и дети", "Тургенев И.С.", 380),
            new Book(10, "Обломов", "Гончаров И.А.", 360),
            new Book(11, "Тихий Дон", "Шолохов М.А.", 600),
    };
    _cart = new Cart();
  }

  public void ShowBooks() {
    _view.ShowBookList(_books);
    _view.Pause();
  }

  public void AddToCart() {
    _view.ShowBookList(_books);

    string input = _view.GetUserInput("\nВведите номер книги для добавления: ");

    if (!int.TryParse(input, out int bookId)) {
      _view.ShowMessage("Неверный ввод");
      _view.Pause();
      return;
    }

    Console.WriteLine();

    Book foundBook = null;
    foreach (Book currentBook in _books) {
      if (currentBook.Id == bookId) {
        foundBook = currentBook;
        break;
      }
    }

    if (foundBook != null) {
      _cart.Add(foundBook);
      _view.ShowMessage($"Книга \"{foundBook.Name}\" добавлена в корзину");
    } else {
      _view.ShowMessage("Книга не найдена");
    }
    _view.Pause();
  }

  public void RemoveFromCart() {
    _view.ShowCart(_cart);

    if (_cart.GetTotal() > 0) {
      string input = _view.GetUserInput("\nВведите номер книги для удаления: ");

      if (!int.TryParse(input, out int index) || index <= 0 || index > _cart.GetItemCount()) {
        _view.ShowMessage("Неверный номер");
        _view.Pause();
        return;
      }

      _cart.RemoveAt(index - 1);
      _view.ShowMessage("Книга удалена из корзины\n");
      _view.ShowMessage("Обновленная корзина:");
      _view.ShowCart(_cart);
    }
    _view.Pause();
  }

  public void ShowCart() {
    _view.ShowCart(_cart);
    _view.Pause();
  }

  public void Checkout() {
    if (_cart.GetTotal() == 0) {
      _view.ShowMessage("Корзина пуста. Добавьте книги перед оформлением заказа");
      _view.Pause();
      return;
    }

    _view.ShowCart(_cart);

    string paymentChoice = _view.GetUserInput(
        "Выберите способ оплаты:\n" +
        "1. Кредитная карта\n" +
        "2. ЮMoney\n" +
        "Ваш выбор: ");

    if (paymentChoice == "1") {
      string cardNumber = _view.GetUserInput("Введите номер карты: ");
      string expiry = _view.GetUserInput("Введите срок действия (ММ/ГГ): ");
      string cvv = _view.GetUserInput("Введите CVV: ");

      IPaymentStrategy strategy = new CreditCardPayment(cardNumber, expiry, cvv);
      string result = strategy.Pay(_cart.GetTotal());
      _view.ShowMessage(result);

      if (result.Contains("Ошибка")) {
        _view.Pause();
        return;
      }
    } else if (paymentChoice == "2") {
      string wallet = _view.GetUserInput("Введите номер кошелька: ");

      IPaymentStrategy strategy = new YooMoneyPayment(wallet);
      string result = strategy.Pay(_cart.GetTotal());
      _view.ShowMessage(result);

      if (result.Contains("Ошибка")) {
        _view.Pause();
        return;
      }
    } else {
      _view.ShowMessage("Неверный выбор");
      _view.Pause();
      return;
    }

    _cart.Clear();
    _view.ShowMessage("Заказ оформлен!");
    _view.Pause();
  }

  public void Run() {
    while (true) {
      _view.ShowMenu();

      string choice = Console.ReadLine();

      switch (choice) {
        case "1": ShowBooks(); break;
        case "2": AddToCart(); break;
        case "3": RemoveFromCart(); break;
        case "4": ShowCart(); break;
        case "5": Checkout(); break;
        case "6": return;
        default:
          _view.ShowMessage("Неверный выбор");
          _view.Pause();
          break;
      }
    }
  }
}