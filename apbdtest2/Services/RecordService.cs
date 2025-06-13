using apbdtest2.DTOs;
using Microsoft.EntityFrameworkCore;

public class RecordService : IRecordService
{
    private readonly RMContext _context;

    public RecordService(RMContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ViewRecordDTO>> GetRecords(DateTime? fromDate, int? languageId, int? taskId)
    {
        var query = _context.Records.Include(r => r.Student).Include(r => r.Language)
            .Include(r => r.Task)
            .AsQueryable();

        if (fromDate != null) query = query.Where(r => r.CreatedAt >= fromDate);
        if (languageId != null) query = query.Where(r => r.LanguageId == languageId);
        if (taskId != null) query = query.Where(r => r.TaskId == taskId);

        return await query.OrderByDescending(r => r.CreatedAt).ThenBy(r => r.Student.LastName)
            .Select(r => new ViewRecordDTO
            {
                StudentFullName = r.Student.FirstName + " " + r.Student.LastName,
                LanguageName = r.Language.Name,
                TaskName = r.Task.Name,
                ExecutionTime = r.ExecutionTime,
                CreatedAt = r.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<bool> CreateRecord(CreateRecordDTO dto)
    {
        if (await _context.Students.FindAsync(dto.StudentId) is not Student student || await _context.Languages.FindAsync(dto.LanguageId) is not Language language)
            return false;

        int taskId = 0;

        if (dto.TaskId != null)
        {
            if (!await _context.Tasks.AnyAsync(t => t.Id == dto.TaskId)) return false;
            taskId = dto.TaskId.Value;
        }
        else if (!string.IsNullOrWhiteSpace(dto.TaskName) && !string.IsNullOrWhiteSpace(dto.TaskDescription))
        {
            var newTask = new Task { Name = dto.TaskName!, Description = dto.TaskDescription! };
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
            taskId = newTask.Id;
        }
        else return false;

        _context.Records.Add(new Record
        {
            StudentId = dto.StudentId,
            LanguageId = dto.LanguageId,
            TaskId = taskId,
            ExecutionTime = dto.ExecutionTime,
            CreatedAt = DateTime.UtcNow
        });

        await _context.SaveChangesAsync();
        return true;
    }
}