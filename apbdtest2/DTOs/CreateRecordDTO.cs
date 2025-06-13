using System.ComponentModel.DataAnnotations;

namespace apbdtest2.DTOs;

public class CreateRecordDTO
{
    [Required]
    public int StudentId { get; set; }

    [Required]
    public int LanguageId { get; set; }

    public int? TaskId { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDescription { get; set; }

    [Required]
    public long ExecutionTime { get; set; }
}