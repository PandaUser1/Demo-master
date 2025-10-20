// История реализаций (продаж) для партнеров
class RealizationHistory : BaseHistoryEntity
{
    public Guid PartnerId { get; set; } // ID партнера
    public double Sum { get; set; }     // Сумма реализации
}
