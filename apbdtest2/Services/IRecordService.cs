using apbdtest2.DTOs;

public interface IRecordService
{
    Task<IEnumerable<ViewRecordDTO>> GetRecords(DateTime? fromDate, int? languageId, int? taskId);
    Task<bool> CreateRecord(CreateRecordDTO dto);
}