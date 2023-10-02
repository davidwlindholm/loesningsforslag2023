using Xunit;

public class ProgramTest {
    [Fact]
    public void Bog_Initialiseres_Korrekt() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");
        
        //Act

        //Assert
        Assert.Equal("Lord of the Rings", book.Title);
        Assert.Equal("J.R.R. Tolkien", book.Author);
        Assert.Equal(500, book.NumberOfPages);
        Assert.Equal("Fantasy", book.Genre);
        Assert.False(book.IsBorrowed);
        Assert.Equal(0, book.Rating);
    }

    [Fact]
    public void Bog_kan_laanes_hvis_ikke_udlaant() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");

        //Act
        book.BorrowBook();

        //Assert
        Assert.True(book.IsBorrowed);
    }

    [Fact]
    public void Bog_kan_ikke_laanes_hvis_udlaant() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");
        book.BorrowBook();

        //Act
        bool borrowSuccessful = book.BorrowBook();

        //Assert
        Assert.False(borrowSuccessful);
    }

    [Fact]
    public void Bog_kan_afleveres_hvis_udlaant() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");
        book.BorrowBook();

        //Act
        book.ReturnBook();

        //Assert
        Assert.False(book.IsBorrowed);
    }

    [Fact]
    public void Bog_kan_ikke_afleveres_hvis_ikke_udlaant() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");

        //Act
        bool returnSuccessful = book.ReturnBook();

        //Assert
        Assert.False(returnSuccessful);
    }

    [Fact]
    public void Bog_kan_afleveres_og_laanes_flere_gange() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");

        //Act
        book.BorrowBook();
        book.ReturnBook();
        book.BorrowBook();

        //Assert
        Assert.True(book.IsBorrowed);
    }

    [Fact]
    public void Bog_kan_laanes_og_afleveres_flere_gange() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");

        //Act
        book.BorrowBook();
        book.ReturnBook();
        book.BorrowBook();
        book.ReturnBook();

        //Assert
        Assert.False(book.IsBorrowed);
    }

    [Theory]
    [InlineData(500, 250)]
    [InlineData(250, 500)]
    [InlineData(1000, 125)]
    [InlineData(125000, 1)]
    public void Bog_har_korrekt_laesehastighed(int minutter, int ordPerMinut) {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");

        //Act
        int readingTime = book.CalculateReadingTimeInMinutes(ordPerMinut);

        //Assert
        Assert.Equal(minutter, readingTime);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Bog_returnerer_minus_en_ved_ugyldig_laesehastighed(int ordPerMinut) {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");

        //Act
        int readingTime = book.CalculateReadingTimeInMinutes(ordPerMinut);

        //Assert
        Assert.Equal(-1, readingTime);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(6)]
    public void Bog_kan_ikke_anmeldes_med_ugyldig_rating(int rating) {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");

        //Act
        bool ratingSuccessful = book.RateBook(rating);

        //Assert
        Assert.False(ratingSuccessful);
        Assert.Equal(0, book.Rating);
    }

    [Fact]
    public void Bog_kan_anmeldes_med_gyldig_rating() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");

        //Act
        bool ratingSuccessful = book.RateBook(4);

        //Assert
        Assert.True(ratingSuccessful);
        Assert.Equal(4, book.Rating);
    }

    [Fact]
    public void Gennemsnit_beregnes_korrekt_ved_flere_anmeldelser() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");

        //Act
        book.RateBook(4);
        book.RateBook(5);

        //Assert
        Assert.Equal(4.5, book.Rating);
    }

    [Fact]
    public void Gennemsnit_afrundes_korrekt_ved_flere_anmeldelser() {
        //Arrange
        Book book = new Book("Lord of the Rings", "J.R.R. Tolkien", 500, "Fantasy");
        
        //Act
        book.RateBook(4);
        book.RateBook(4);
        book.RateBook(5);

        //Assert
        Assert.Equal(4.33, book.Rating);
    }


}