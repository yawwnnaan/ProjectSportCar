namespace ProjectSportCar;

/// <summary>
/// Класс-сущность "Автомобиль"
/// </summary>
public class EntityCar
{
	/// <summary>
	/// Скорость
	/// </summary>
	public int Speed { get; private set; }

	/// <summary>
	/// Вес
	/// </summary>
	public double Weight { get; private set; }

	/// <summary>
	/// Основной цвет
	/// </summary>
	public Color BodyColor { get; private set; }

	/// <summary>
	/// Шаг перемещения автомобиля
	/// </summary>
	public double Step => Speed * 100 / Weight;

	/// <summary>
	/// Инициализация полей объекта-класса автомобиля
	/// </summary>
	/// <param name="speed">Скорость</param>
	/// <param name="weight">Вес автомобиля</param>
	/// <param name="bodyColor">Основной цвет</param>
	public void Init(int speed, double weight, Color bodyColor)
	{
		Speed = speed;
		Weight = weight;
		BodyColor = bodyColor;
	}
}