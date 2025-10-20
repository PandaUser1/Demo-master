// Базовый класс для всех сущностей, обеспечивающий уникальный идентификатор
public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
