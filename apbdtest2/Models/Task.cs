using System.ComponentModel.DataAnnotations;

public class Task
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    public ICollection<Record> Records { get; set; } = new List<Record>();
}