// Класс партнера/контрагента с информацией о компании и условиях сотрудничества
class Partner(PartnerType type, string name, string orgAddress, string directorFullName, string phone, string email, int rate) : BaseEntity
{
    // Конструктор для создания из DTO
    public Partner(PartnerDTO dto) :
        this(dto.Type,
            dto.Name,
            dto.OrgAddress,
            dto.DirectorFullName,
            dto.Phone,
            dto.Email,
            dto.Rate)
    { }

    public PartnerType Type { get; set; } = type;              // Тип партнера
    public string Name { get; set; } = name;                   // Название организации
    public string OrgAddress { get; set; } = orgAddress;       // Юридический адрес
    public string DirectorFullName { get; set; } = directorFullName; // ФИО директора
    public string Phone { get; set; } = phone;                 // Телефон
    public string Email { get; set; } = email;                 // Email
    public int Rate { get; set; } = rate;                      // Рейтинг партнера

    // Преобразование в DTO для передачи данных
    public PartnerDTO ToDTO()
    {
        return new PartnerDTO(Type, Name, OrgAddress, DirectorFullName, Phone, Email, Rate, Id);
    }
}

// DTO для передачи данных партнера (record для иммутабельности)
record PartnerDTO(
    PartnerType Type,
    string Name,
    string OrgAddress,
    string DirectorFullName,
    string Phone,
    string Email,
    int Rate,
    Guid? Id = null);  // Id опциональный для создания новых записей

// Типы партнеров (уровни сотрудничества)
enum PartnerType
{
    First,   // Первый тип
    Second,  // Второй тип
    Third    // Третий тип
}
