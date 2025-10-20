// История отгрузки материалов поставщикам
class MaterialShipmentHistory : BaseHistoryEntity
{
    public Guid SupplierId { get; set; }       // ID поставщика
    public Guid MaterialId { get; set; }       // ID материала
    public int Count { get; set; }             // Количество отгруженного материала
}
