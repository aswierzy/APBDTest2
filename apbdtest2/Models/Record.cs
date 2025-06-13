using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Record
{
    public int Id { get; set; }

    [Required]
    public int LanguageId { get; set; }

    [Required]
    public int TaskId { get; set; }

    [Required]
    public int StudentId { get; set; }

    [Required]
    public long ExecutionTime { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public Language Language { get; set; } = null!;
    public Task Task { get; set; } = null!;
    public Student Student { get; set; } = null!;
}