namespace Bookhome.DataAcces.ViewModels.Books;

public class BookCommentViewModel
{
    public int Id { get; set; }

    public string Comment { get; set; } = String.Empty;

    public DateTime CreatedAt { get; set; }


    public DateTime UpdatedAt { get; set; }

    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;

}
