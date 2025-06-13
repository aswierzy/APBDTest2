using System.ComponentModel.DataAnnotations;

public class Language
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    public ICollection<Record> Records { get; set; } = new List<Record>();
}