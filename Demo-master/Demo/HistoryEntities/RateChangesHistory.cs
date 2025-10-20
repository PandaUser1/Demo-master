// История изменения ставок/скидок для партнеров
class RateChangesHistory : BaseHistoryEntity
{
    public Guid PartnerId { get; set; }        // ID партнера
    public double Value { get; set; }          // Новое значение ставки/скидки
}
