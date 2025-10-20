// История перемещений сотрудников между цехами
class EmployeeMovedHistory : BaseHistoryEntity
{
    public Guid EmployeeId { get; set; }       // ID сотрудника
    public Guid FromWorkshopId { get; set; }   // ID цеха, откуда перевели
    public Guid ToWorkshopId { get; set; }     // ID цеха, куда перевели
}
