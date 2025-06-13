using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = null!;

    [Required, MaxLength(250), EmailAddress]
    public string Email { get; set; } = null!;

    public ICollection<Record> Records { get; set; } = new List<Record>();
}