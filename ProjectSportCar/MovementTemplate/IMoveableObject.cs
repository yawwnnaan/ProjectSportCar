namespace ProjectSportCar.MovementTemplate;

/// <summary>
/// Интерфейс для работы с перемещаемым объектом
/// </summary>
public interface IMoveableObject
{
	/// <summary>
	/// Координаты объекта
	/// </summary>
	ObjectCoordinates? ObjectCoordinates { get; }

	/// <summary>
	/// Шаг объекта
	/// </summary>
	int ObjectStep { get; }

	/// <summary>
	/// Установка позиции объекта
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	void SetObjectPosition(int x, int y);

	/// <summary>
	/// Перемещение объекта в указанном направлении
	/// </summary>
	/// <param name="direction">Направление</param>
	void MoveObject(MovementDirection direction);

	/// <summary>
	/// Прорисовка объекта
	/// </summary>
	/// <param name="graphics"></param>
	void DrawObject(Graphics graphics);
}