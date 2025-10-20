using Microsoft.EntityFrameworkCore;

// Репозиторий для работы с партнерами
class PartnerRepo(ProjectDbContext context)
{
    public DbSet<Partner> _partners = context.partners;

    RealizationRepo RealizationRepo = new(context); // Зависимость для работы с реализациями

    // Создание нового партнера
    public Guid Create(PartnerDTO dto)
    {
        var result = new Partner(dto);
        _partners.Add(result);
        context.SaveChanges(); // Сохранение в БД
        return result.Id; // Возврат ID созданного партнера
    }

    // Обновление данных партнера
    public void Update(Guid id, PartnerDTO dto)
    {
        var partner = _partners.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Партнер не найден по id");
        // Обновление только измененных полей
        if (dto.Type != partner.Type)
            partner.Type = dto.Type;
        if(dto.Name != partner.Name)
            partner.Name = dto.Name;
        if (dto.OrgAddress != partner.OrgAddress)
            partner.OrgAddress = dto.OrgAddress;
        if (dto.DirectorFullName != partner.DirectorFullName)
            partner.DirectorFullName = dto.DirectorFullName;
        if (dto.Phone != partner.Phone)
            partner.Phone = dto.Phone;
        if (dto.Email != partner.Email)
            partner.Email = dto.Email;
        if (dto.Rate != partner.Rate)
            partner.Rate = dto.Rate;
        context.SaveChanges();
    }

    // Получение всех партнеров в формате DTO
    public List<PartnerDTO> ReadAll()
    {
        return _partners.Select(x => x.ToDTO()).ToList();
    }

    // Расчет скидки для партнера на основе суммы реализаций
    public double GetDiscount(Guid id)
    {
        var sum = RealizationRepo.GetSum(id);
        return sum switch
        {
            < 10000 => 0,      // Менее 10к - без скидки
            < 50000 => 0.05,   // 10к-50к - 5% скидка
            < 300000 => 0.1,   // 50к-300к - 10% скидка
            >= 300000 => 0.15, // Более 300к - 15% скидка
            _ => 0,
        };
    }

    // Получение истории реализаций партнера
    public List<RealizationHistory> GetHistory(Guid id)
    {
        return RealizationRepo.Read(id);
    }

    // Создание записи о реализации для партнера
    public void CreateRealization(Guid id, RealizationHistory realization)
    {
        RealizationRepo.Add(id, realization);
    }
}
