using System;
using System.Collections.Generic;

public class ConsoleView {
  public void ShowMenu() {
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
  }

  public void ShowBookList(List<Book> books) {
    Console.Clear();
    Console.WriteLine("===== СПИСОК КНИГ =====");
    foreach (Book book in books) {
      Console.WriteLine($"{book.Id}. {book.Name} - {book.Author} - {book.Price} руб.");
    }
  }

  public void ShowCart(Cart cart) {
    Console.Clear();
    Console.WriteLine(cart.Display());
  }

  public void ShowMessage(string message) {
    Console.WriteLine(message);
  }

  public string GetUserInput(string query) {
    Console.Write(query);
    return Console.ReadLine();
  }

  public void Pause() {
    Console.WriteLine("\nНажмите любую клавишу для возврата в меню");
    Console.ReadKey();
  }
}