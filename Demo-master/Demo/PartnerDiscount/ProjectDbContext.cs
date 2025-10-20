using Microsoft.EntityFrameworkCore;

// Контекст базы данных Entity Framework Core
class ProjectDbContext : DbContext
{
    public DbSet<Partner> partners => Set<Partner>();                      // Таблица партнеров
    public DbSet<RealizationHistory> histories => Set<RealizationHistory>(); // Таблица истории реализаций

    public ProjectDbContext()
    {
        Database.EnsureCreated(); // Создание БД при первом обращении
    }

    // Настройка подключения к SQLite базе данных
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=database.db"); // Исправлено имя файла: database.db
    }
}
