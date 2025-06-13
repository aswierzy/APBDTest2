namespace apbdtest2.DTOs;

public class ViewRecordDTO
{
    public string StudentFullName { get; set; } = null!;
    public string LanguageName { get; set; } = null!;
    public string TaskName { get; set; } = null!;
    public long ExecutionTime { get; set; }
    public DateTime CreatedAt { get; set; }
}