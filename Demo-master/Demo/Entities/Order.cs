// Класс заказа с информацией о статусе и товарах
class Order : BaseEntity
{
    public Guid PartnerId { get; set; }            // ID партнера/клиента
    public bool IsApproved { get; set; } = false;  // Флаг подтверждения
    public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Created; // Текущий статус
    public DateTime Date { get; set; } = DateTime.Now; // Дата создания

    public List<Product> Products { get; set; }    // Список товаров в заказе
}

// Статусы жизненного цикла заказа
enum OrderStatusEnum
{
    Created,        // Создан
    WaitPayment,    // Ожидает оплаты
    FullPayment,    // Полностью оплачен
    Completed       // Завершен
}
