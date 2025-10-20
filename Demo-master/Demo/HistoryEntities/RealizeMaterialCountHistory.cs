// История реализации (продажи/списания) материалов
class RealizeMaterialCountHistory : BaseHistoryEntity
{
    public Guid MaterialId { get; set; }       // ID материала
    public string Name { get; set; }           // Название материала
    public Guid SupplierId { get; set; }       // ID поставщика материала
    public int Count { get; set; }             // Количество реализованного материала
}
