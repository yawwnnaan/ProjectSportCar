using ProjectSportCar.Drawnings;

namespace ProjectSportCar.MovementTemplate;

/// <summary>
/// Реализация интерфейса IMoveableObject с адаптацией под DrawningCar
/// </summary>
public class MoveableAdapterCar : IMoveableObject
{
	/// <summary>
	/// Поле-объект класса DrawningCar или его наследника
	/// </summary>
	private readonly DrawningCar _car;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="car">Объект класса DrawningCar</param>
	public MoveableAdapterCar(DrawningCar car)
	{
		_car = car;
	}

	public ObjectCoordinates? ObjectCoordinates
	{
		get
		{
			if (_car is null || !_car.PosX.HasValue || !_car.PosY.HasValue)
			{
				return null;
			}

			return new ObjectCoordinates(_car.PosX.Value, _car.PosY.Value, _car.DrawningCarWidth, _car.DrawningCarHeight);
		}
	}

	public int ObjectStep => (int)(_car?.CarStep ?? 0);

	public void MoveObject(MovementDirection direction)
	{
		switch (direction)
		{
			case MovementDirection.Left:
				_car?.MoveLeft();
				break;
			case MovementDirection.Up:
				_car?.MoveUp();
				break;
			case MovementDirection.Right:
				_car?.MoveRight();
				break;
			case MovementDirection.Down:
				_car?.MoveDown();
				break;
		}
	}

	public void SetObjectPosition(int x, int y) => _car?.SetPosition(x, y);

	public void DrawObject(Graphics graphics) => _car?.DrawTransport(graphics);
}