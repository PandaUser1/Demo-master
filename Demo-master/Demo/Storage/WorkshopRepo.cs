// Репозиторий для управления цехами
class WorkshopRepo
{
    // Предзаполненный список цехов производства
    private List<Workshop> _workshopList =
    [
        new ("Проектный",WorkshopTypeEnum.Проектирование,4),
        new ("Расчетный",WorkshopTypeEnum.Проектирование,5),
        new ("Раскроя",WorkshopTypeEnum.Обработка,5),
        new ("Обработки",WorkshopTypeEnum.Обработка,6),
        new ("Сушильный",WorkshopTypeEnum.Сушка,3),
        new ("Покраски",WorkshopTypeEnum.Обработка,6),
        new ("Столярный",WorkshopTypeEnum.Обработка,7),
        new ("Изготовления изделий из искусственного камня и композитных материалов",
            WorkshopTypeEnum.Обработка,3),
        new ("Изготовления мягкой мебели",WorkshopTypeEnum.Обработка,5),
        new ("Монтажа стеклянных, зеркальных вставок и других изделий",
            WorkshopTypeEnum.Сборка,2),
        new ("Сборки",WorkshopTypeEnum.Сборка,6),
        new ("Упаковки",WorkshopTypeEnum.Сборка,4),
    ];

    // Получение всех цехов
    public List<Workshop> ReadAll()
    {
        return _workshopList;
    }

    // Получение цеха по ID
    public Workshop Read(Guid id)
    {
        return _workshopList.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Цех не найден по id");
    }
}
