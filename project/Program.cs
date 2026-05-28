using System;
using System.Collections.Generic;

internal class Program {
  private static void Main(string[] args) {
    List<Book> books = new List<Book>
    {
            new Book(1, "Война и мир", "Толстой Л.Н.", 500),
            new Book(2, "Преступление и наказание", "Достоевский Ф.М.", 400),
            new Book(3, "Мастер и Маргарита", "Булгаков М.А.", 300),
            new Book(4, "Евгений Онегин", "Пушкин А.С.", 100),
    };

    Cart cart = new Cart();

    while (true) {
      Console.Clear();
      Console.Write(
          "===== КНИЖНЫЙ ИНТЕРНЕТ-МАГАЗИН =====\n" +
          "1. Посмотреть список книг\n" +
          "2. Добавить книгу в корзину\n" +
          "3. Удалить книгу из корзины\n" +
          "4. Посмотреть корзину\n" +
          "5. Оформить заказ\n" +
          "6. Выйти\n" +
          "Выберите действие: ");

      switch (Console.ReadLine()) {
        case "1":
          Console.Clear();
          PrintBookList(books);
          Pause();
          break;

        case "2":
          Console.Clear();
          PrintBookList(books);
          Console.Write("\nВведите номер книги для добавления: ");

          if (int.TryParse(Console.ReadLine(), out int bookId)) {
            Console.WriteLine();
            Book foundBook = null;
            foreach (Book currentBook in books) {
              if (currentBook.Id == bookId) {
                foundBook = currentBook;
                break;
              }
            }

            if (foundBook != null) {
              cart.Add(foundBook);

              Console.WriteLine($"Книга \"{foundBook.Name}\" добавлена в корзину");
            } else {
              Console.WriteLine("Книга не найдена");
            }
          } else {
            Console.WriteLine("Неверный ввод");
          }

          Pause();
          break;

        case "3":
          Console.Clear();
          Console.WriteLine(cart.Display());
          if (cart.GetTotal() > 0) {
            Console.Write("\nВведите номер книги для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0) {
              if (index <= cart.GetItemCount()) {
                cart.RemoveAt(index - 1);
                Console.WriteLine("Книга удалена из корзины\n");
                Console.WriteLine("Обновленная корзина:");
                Console.WriteLine(cart.Display());
              } else {
                Console.WriteLine("Введенный номер превышает количество книг в корзине");
              }
            } else {
              Console.WriteLine("Неверный номер");
            }
          }

          Pause();
          break;

        case "4":
          Console.Clear();
          Console.WriteLine(cart.Display());
          Pause();
          break;

        case "5":
          Console.Clear();
          if (cart.GetTotal() == 0) {
            Console.WriteLine("Корзина пуста. Добавьте книги перед оформлением заказа");
            Pause();
            break;
          }

          Console.WriteLine(cart.Display());
          Console.WriteLine(
              "Выберите способ оплаты:\n" +
              "1. Кредитная карта\n" +
              "2. ЮMoney\n" +
              "Ваш выбор: ");

          string paymentChoice = Console.ReadLine();

          if (paymentChoice == "1") {
            Console.Write("Введите номер карты: ");
            string cardNumber = Console.ReadLine();
            Console.Write("Введите срок действия (ММ/ГГ): ");
            string expiry = Console.ReadLine();
            Console.Write("Введите CVV: ");
            string cvv = Console.ReadLine();

            IPaymentStrategy strategy = new CreditCardPayment(cardNumber, expiry, cvv);
            Console.WriteLine(strategy.Pay(cart.GetTotal()));
          } else if (paymentChoice == "2") {
            Console.Write("Введите номер кошелька: ");
            string wallet = Console.ReadLine();

            IPaymentStrategy strategy = new YooMoneyPayment(wallet);
            Console.WriteLine(strategy.Pay(cart.GetTotal()));
          } else {
            Console.WriteLine("Неверный выбор");
            Pause();
            break;
          }

          cart.Clear();
          Console.WriteLine("Заказ оформлен!");
          Pause();
          break;

        case "6":
          return;

        default:
          Console.WriteLine("Неверный выбор");
          Pause();
          break;
      }
    }
  }

  private static void PrintBookList(List<Book> books) {
    Console.WriteLine("===== СПИСОК КНИГ =====");
    foreach (Book book in books) {
      Console.WriteLine($"{book.Id}. {book.Name} - {book.Author} - {book.Price} руб.");
    }
  }

  private static void Pause() {
    Console.WriteLine("\nНажмите любую клавишу для возврата в меню");
    Console.ReadKey();
  }
}