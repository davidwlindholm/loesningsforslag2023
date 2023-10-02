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

    public int CalculateReadingTimeInMinutes(int wordsPerMinute) {
        if (wordsPerMinute <= 0) {
            return -1; // Vi har ikke lært at teste exceptions endnu
        }

        double multiplier = 250.0 / wordsPerMinute;
        return (int) Math.Round(NumberOfPages * multiplier);
    }

    public bool BorrowBook() {
        if (!IsBorrowed) {
            IsBorrowed = true;
            return true;  // Indicates borrowing was successful
        }
        return false;  // Indicates borrowing was not successful
    }

    public bool ReturnBook() {
        if (IsBorrowed) {
            IsBorrowed = false;
            return true;  // Indicates returning was successful
        }
        return false;  // Indicates returning was not successful
    }

    public bool RateBook(double rating) {
        if (rating < 0 || rating > 5) {
            return false;  // Indicates rating was not successful
        }

        TotalRating += rating;
        NumberOfRatings++;
        Rating = TotalRating / NumberOfRatings;
        Rating = Math.Round(Rating, 2);
        return true;  // Indicates rating was successful
    }
}