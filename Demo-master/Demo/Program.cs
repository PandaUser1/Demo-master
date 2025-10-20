// Точка входа ASP.NET Core приложения
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

// Инициализация контекста БД и репозиториев
ProjectDbContext context = new();
PartnerRepo partnerRepo = new (context);

// Настройка маршрутов API
app.MapPost("partners", (PartnerDTO dto) => partnerRepo.Create(dto));        // Создание партнера
app.MapPut("partners/{id}", (Guid id, PartnerDTO dto) => partnerRepo.Update(id, dto)); // Обновление партнера
app.MapGet("partners", () => partnerRepo.ReadAll());                         // Получение всех партнеров

app.MapGet("history/{id}", (Guid id) => partnerRepo.GetHistory(id));         // История реализаций
app.MapGet("discount/{id}", (Guid id) => partnerRepo.GetDiscount(id));       // Расчет скидки

app.Run();

// Закомментированный тестовый код для демонстрации работы с партнерами
/*var p1 = new PartnerDTO(PartnerType.First,
    "Наименование партенра", "123", "Директор", "+7 223 322 22 32",
    "", 10);
var p2 = new PartnerDTO(PartnerType.First,
    "Наименование партенра", "123", "Директор", "+7 223 322 22 32",
    "", 10);
var p3 = new PartnerDTO(PartnerType.First,
    "Наименование партенра", "123", "Директор", "+7 223 322 22 32",
    "", 10);
var id1 = partnerRepo.Create(p1);
var id2 = partnerRepo.Create(p2);
var id3 = partnerRepo.Create(p3);
var realize = new RealizationHistory() { PartnerId = id1, Sum = 50000 };
partnerRepo.CreateRealization(id1, realize);
realize.Id = Guid.NewGuid();
partnerRepo.CreateRealization(id2, realize);
realize.Id = Guid.NewGuid();
partnerRepo.CreateRealization(id3, realize);*/
