// Базовый класс для всех исторических сущностей с временной меткой
public class BaseHistoryEntity : BaseEntity
{
    public DateTime Date { get; set; } = DateTime.Now; // Дата события
}
