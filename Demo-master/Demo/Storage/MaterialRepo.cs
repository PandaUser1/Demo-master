// Репозиторий для управления материалами и их движением
class MaterialRepo
{
    public List<Material> _materials = [];                              // Хранилище материалов
    public List<RealizeMaterialCountHistory> _materialsHistory = [];    // История изменений количества
    public List<MaterialShipmentHistory> _materialsShipmentHistory = []; // История поставок

    // Массовое создание/обновление материалов
    public void CreateMany(List<Material> materials)
    {
        foreach (var material in materials)
        {
            var thisMaterial = _materials
                .FirstOrDefault(x => x.Name == material.Name
                && x.SupplierId == material.SupplierId);
            if (thisMaterial == null)
            {
                _materials.Add(material);
                AddToHistory(material);
            }
            else
            {
                // Обновление существующего материала
                thisMaterial.StorageCount += material.StorageCount;
                AddToHistory(thisMaterial);
            }
            // Запись в историю поставок
            _materialsShipmentHistory.Add(new MaterialShipmentHistory()
            {
                Count = material.StorageCount,
                SupplierId = material.SupplierId,
                MaterialId = material.Id
            });
        }
    }

    // Добавление записи в историю изменений
    private void AddToHistory(Material material)
    {
        _materialsHistory.Add(new RealizeMaterialCountHistory
        {
            MaterialId = material.Id,
            Name = material.Name,
            SupplierId = material.SupplierId,
            Count = material.StorageCount
        });
    }

    // Резервирование материала для производства
    public void Reserv(Guid id, int count)
    {
        var thisMaterial = _materials
               .FirstOrDefault(x => x.Id == id)
               ?? throw new Exception("Материал не найден по id");
        if (thisMaterial.StorageCount < count)
            throw new Exception("Недостаточно материала на складе");
        thisMaterial.StorageCount -= count;
        thisMaterial.ReservedCount += count;

        AddToHistory(thisMaterial);
    }

    // Отгрузка зарезервированного материала в производство
    public void DeliveryToProd(Guid id, int count)
    {
        var thisMaterial = _materials
             .FirstOrDefault(x => x.Id == id)
             ?? throw new Exception("Материал не найден по id");

        if (thisMaterial.ReservedCount < count)
            throw new Exception("Недостаточно зарезервированного " +
                "материала на складе");
        thisMaterial.ReservedCount -= count; // Списание резерва
    }

    // Получение информации о материалах
    public List<Material> GetMaterialInfos()
    {
        return _materials;
    }

    // Получение истории изменений материалов
    public List<RealizeMaterialCountHistory> GetMaterialHistoryInfos()
    {
        return _materialsHistory;
    }

    // Получение истории поставок
    public List<MaterialShipmentHistory> GetMaterialShipmentHistoryInfos()
    {
        return _materialsShipmentHistory;
    }
}
