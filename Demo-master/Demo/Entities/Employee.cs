// Базовый класс для сотрудников с общей информацией
class Employee : BaseEntity
{
    public string FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public string PassportData { get; set; }
    public string BankRequisits { get; set; }
    public bool IsFamilyGuy { get; set; }
    public string HealthStatus { get; set; }
    public RoleEnum Role { get; set; }
}

// Роли сотрудников в системе
enum RoleEnum
{
    Analitic,   // Аналитик
    Manager,   // Менеджер
    Master   // Мастер
}
