// Репозиторий для управления заказами
class OrderRepo
{
    private List<Order> _orders = [];

    // Создание нового заказа
    public void Create(Order order)
    {
        _orders.Add(order);
    }

    // Обновление статуса заказа
    public void Update(Guid id, bool isApproved, OrderStatusEnum status)
    {
        var order = _orders.FirstOrDefault(x => x.Id == id)
             ?? throw new Exception("Заявка не найдена по id");
        if(order.Status != status)
            order.Status = status;
        if (order.IsApproved != isApproved)
            order.IsApproved = isApproved;
    }

    // Получение всех заказов
    public List<Order> ReadAll()
    {
        return _orders;
    }

    // Удаление заказа по ID
    public void Delete(Guid id)
    {
        var order = _orders.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Заявка не найдена по id");
        _orders.Remove(order);
    }

    // Удаление старых заказов (старше 3 дней)
    public void DeleteOldOrders()
    {
        var oldOrders = _orders
            .Where(x => (DateTime.Now - x.Date).Days > 3)
            .ToList();
        oldOrders.ForEach(x => _orders.Remove(x));
    }
}
