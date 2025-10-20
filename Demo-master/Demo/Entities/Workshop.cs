// Класс производственного цеха
class Workshop : BaseEntity
{
    public Workshop(string name, WorkshopTypeEnum type, int peopleCount)
    {
        Name = name;
        Type = type;
        PeopleCount = peopleCount;
    }

    public string Name { get; set; }               // Название цеха
    public WorkshopTypeEnum Type { get; set; }     // Тип цеха
    public int PeopleCount { get; set; }           // Количество работников
}

// Типы цехов производственного процесса
enum WorkshopTypeEnum
{
    Проектирование, // Проектирование
    Обработка,      // Обработка материалов
    Сушка,          // Сушка
    Сборка          // Сборка продукции
}
