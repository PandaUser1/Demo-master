using Microsoft.EntityFrameworkCore;

// Репозиторий для работы с историей реализаций
class RealizationRepo(ProjectDbContext context)
{
    private DbSet<RealizationHistory> _realization = context.histories;

    // Добавление записи о реализации
    public void Add(Guid partnerId, RealizationHistory realization)
    {
        realization.PartnerId = partnerId;
        _realization.Add(realization);
        context.SaveChanges(); // Сохранение изменений в БД
    }

    // Получение общей суммы реализаций для партнера
    public double GetSum(Guid partnerId)
    {
        return _realization
            .Where(x => x.PartnerId == partnerId)
            .Sum(x => x.Sum);
    }

    // Получение истории реализаций для партнера
    public List<RealizationHistory> Read(Guid partnerId)
    {
        return _realization
            .Where(x => x.PartnerId == partnerId)
            .ToList();
    }
}
