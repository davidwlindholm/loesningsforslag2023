using System;

public class Book {
    static void Main(string[] args) { }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int NumberOfPages { get; private set; }
    public string Genre { get; private set; }
    public bool IsBorrowed { get; private set; }
    public double Rating { get; private set; }
    private int NumberOfRatings { get; set; }
    private double TotalRating { get; set; }

    public Book(string title, string author, int numberOfPages, string genre) {
        Title = title;
        Author = author;
        NumberOfPages = numberOfPages;
        Genre = genre;
        IsBorrowed = false;
        Rating = 0;
        NumberOfRatings = 0;
        TotalRating = 0;
    }

    public int CalculateReadingTimeInMinutes() {
        return NumberOfPages;
    }

    public void BorrowBook() {
        if (!IsBorrowed) {
            IsBorrowed = true;
        }
    }

    public void ReturnBook() {
        if (IsBorrowed) {
            IsBorrowed = false;
        }
    }

    public bool RateBook(double rating) {
        if (rating < 0 || rating > 5) {
            return false;  // Indicates rating was not successful
        }

        TotalRating += rating;
        NumberOfRatings++;
        Rating = TotalRating / NumberOfRatings;
        return true;  // Indicates rating was successful
    }
}