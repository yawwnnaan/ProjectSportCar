namespace ProjectSportCar.Entities;

/// <summary>
/// Класс-сущность "Спортивный автомобиль"
/// </summary>
public class EntitySportCar : EntityCar
{
	/// <summary>
	/// Дополнительный цвет (для опциональных элементов)
	/// </summary>
	public Color AdditionalColor { get; init; }

	/// <summary>
	/// Признак (опция) наличия крана
	/// </summary>
	public bool CraneBoom { get; init; }

	/// <summary>
	/// Признак (опция) наличия противовеса
	/// </summary>
	public bool Counterweight { get; init; }

    /// <summary>
    /// Конструктор для инициализации полей объекта-класса спортивного автомобиля
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес автомобиля</param>
    /// <param name="bodyColor">Основной цвет</param>
    /// <param name="additionalColor">Дополнительный цвет</param>
    /// <param name="craneBoom">Признак наличия крана</param>
    /// <param name="counterweight">Признак наличия противовеса</param>
    /// <param name="sportLine">Признак наличия гоночной полосы</param>
    public EntitySportCar(int speed, double weight, Color bodyColor, Color additionalColor, bool craneBoom, bool counterweight)
		: base(speed, weight, bodyColor)
	{
		AdditionalColor = additionalColor;
		CraneBoom = craneBoom;
		Counterweight = counterweight;
	}
}