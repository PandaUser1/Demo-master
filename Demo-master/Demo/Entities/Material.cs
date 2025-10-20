// Класс материала/сырья с информацией о запасах и качестве
class Material : BaseEntity
{
    public string Type { get; set; }
    public string Name { get; set; }
    public Guid SupplierId { get; set; }           // Ссылка на поставщика
    public int PackageCount { get; set; }          // Количество упаковок
    public string CountEntity { get; set; }        // Единица измерения
    public string Description { get; set; }
    public string Image { get; set; }
    public double Price { get; set; }
    public int StorageCount { get; set; }          // Текущий запас на складе
    public int MinCount { get; set; }              // Минимальный запас
    public int ReservedCount { get; set; }         // Зарезервированное количество
    public QualityEnum Quality { get; set; }       // Качество материала
}

// Шкала качества материалов
enum QualityEnum
{
    VeryBad,    // Очень плохое
    Bad,        // Плохое
    Normal,     // Нормальное
    Good,       // Хорошее
    VeryGood    // Очень хорошее
}
