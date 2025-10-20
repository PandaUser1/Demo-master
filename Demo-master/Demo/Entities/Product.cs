// Класс продукта с детальной информацией о характеристиках
class Product : BaseEntity
{
    public Product(ProductTypeEnum type, string name, long article, double minPrice, string primaryMaterial)
    {
        Type = type;
        Name = name;
        Article = article;
        MinPrice = minPrice;
        PrimaryMaterial = primaryMaterial;
    }

    public ProductTypeEnum Type { get; set; }      // Тип продукта
    public string Name { get; set; }               // Название
    public long Article { get; set; }              // Артикул
    public double MinPrice { get; set; }           // Минимальная цена
    public string PrimaryMaterial { get; set; }    // Основной материал

    // Физические характеристики
    public Size PackageSize { get; set; }          // Размер упаковки
    public double Brutto { get; set; }             // Вес брутто
    public double Netto { get; set; }              // Вес нетто
    public double BasePrice { get; set; }          // Базовая цена

    public Guid WorkshopId { get; set; }           // Цех производства
    public int ProductPeopleCount { get; set; }    // Количество работников для производства
    public double ProductionDelayTime { get; set; }// Время производства
    public string QualityCertificate { get; set; } // Сертификат качества
    public string StandartNumber { get; set; }     // Номер стандарта

    public string Description { get; set; }
    public string Image { get; set; }
    public double Price { get; set; }              // Текущая цена

    public DateTime ProductionDate { get; set; } = DateTime.Now; // Дата производства
    public int Count { get; set; }                 // Количество
    public double Sum => Price * Count;            // Общая стоимость
}

// Типы продукции (мебельное производство)
enum ProductTypeEnum
{
    Столы,          // Столы
    Стулья,         // Стулья
    Комоды,         // Комоды
    Диваны,         // Диваны
    Кровати,        // Кровати
    Шкафы,          // Шкафы
}

// Класс для хранения размеров
class Size
{
    public double Height { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
}

// Репозиторий для работы с продуктами (имитация базы данных)
class ProductRepo
{
    // Временное хранилище продуктов
    private List<Product> _products = [ ... ]; // Инициализация тестовыми данными

    private List<MinPriceHistory> _minPriceHistories = []; // История изменения цен

    // CRUD операции
    public void Create(Product product) { ... }
    public List<Product> ReadAll() { ... }
    public void Update(Guid id, double price) { ... }
    public void Delete(Guid id) { ... }
}
