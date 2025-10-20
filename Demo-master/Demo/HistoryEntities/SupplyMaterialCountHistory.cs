// История поставок материалов от поставщиков
class SupplyMaterialCountHistory : BaseHistoryEntity
{
    public Guid MaterialId { get; set; }       // ID материала
    public Guid SuplyerId { get; set; }        // ID поставщика (описка в названии свойства - должно быть SupplierId)
    public int Count { get; set; }             // Количество поставленного материала
}
