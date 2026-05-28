using System.Collections.Generic;

public class Cart {
  private readonly List<Book> _books = new List<Book>();

  public void Add(Book book) {
    _books.Add(book);
  }

  public void RemoveAt(int index) {
    if (index >= 0 && index < _books.Count) {
      _books.RemoveAt(index);
    }
  }

  public string Display() {
    if (_books.Count == 0) {
      return "Корзина пуста";
    }

    string result = string.Empty;
    for (int bookIndex = 0; bookIndex < _books.Count; ++bookIndex) {
      result += $"{bookIndex + 1}. {_books[bookIndex].Name} - {_books[bookIndex].Price} руб.\n";
    }

    result += $"Итого: {GetTotal()} руб.\n";
    return result;
  }

  public double GetTotal() {
    double total = 0;
    foreach (Book book in _books) {
      total += book.Price;
    }

    return total;
  }

  public void Clear() {
    _books.Clear();
  }

  public int GetItemCount() {
    return _books.Count;
  }
}