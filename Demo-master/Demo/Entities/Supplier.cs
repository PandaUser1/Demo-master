// Класс поставщика материалов
class Supplier : BaseEntity
{
    public string Type { get; set; }       // Тип поставщика
    public string Name { get; set; }       // Название
    public string Inn { get; set; }        // ИНН
    public bool IsActive { get; set; } = true; // Активен ли поставщик
}
