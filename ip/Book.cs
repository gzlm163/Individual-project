using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Book
    {
    public string Name;
    public int Id;
    public string Author;
    public double Price;

    public Book(int id, string name, string author, double price)
    {
        Id = id;
        Name = name;
        Author = author;
        Price = price;
    }
}

