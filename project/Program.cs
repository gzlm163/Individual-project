internal class Program {
  private static void Main(string[] args) {
    ConsoleView view = new ConsoleView();
    BookStore store = new BookStore(view);
    store.Run();
  }
}
