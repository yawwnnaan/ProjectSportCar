namespace ProjectSportCar.MovementTemplate;

/// <summary>
/// Класс-шаблон стратегии перемещения объекта
/// </summary>
public abstract class BaseTemplateMovement
{
	/// <summary>
	/// Перемещаемый объект
	/// </summary>
	private IMoveableObject? _moveableObject;

	/// <summary>
	/// Статус перемещения
	/// </summary>
	private TemplateMovementStatus _state = TemplateMovementStatus.NotInit;

	/// <summary>
	/// Ширина поля
	/// </summary>
	protected int FieldWidth { get; private set; }

	/// <summary>
	/// Высота поля
	/// </summary>
	protected int FieldHeight { get; private set; }

	/// <summary>
	/// Если финиш достигнут
	/// </summary>
	public bool IsFinishReached => _state == TemplateMovementStatus.Finish;

	/// <summary>
	/// Установка данных
	/// </summary>
	/// <param name="moveableObject">Перемещаемый объект</param>
	/// <param name="width">Ширина поля</param>
	/// <param name="height">Высота поля</param>
	public void SetData(IMoveableObject moveableObject, int width, int height)
	{
		if (moveableObject is null)
		{
			_state = TemplateMovementStatus.NotInit;
			return;
		}

		_state = TemplateMovementStatus.InProgress;
		_moveableObject = moveableObject;
		FieldWidth = width;
		FieldHeight = height;
	}

	/// <summary>
	/// Шаг перемещения
	/// </summary>
	public void MakeStep()
	{
		if (_state != TemplateMovementStatus.InProgress)
		{
			return;
		}

		if (IsTargetDestinaion())
		{
			_state = TemplateMovementStatus.Finish;
			return;
		}

		MoveToTarget();
	}

	/// <summary>
	/// Перемещение влево
	/// </summary>
	protected void MoveLeft() => MoveTo(MovementDirection.Left);

	/// <summary>
	/// Перемещение вправо
	/// </summary>
	protected void MoveRight() => MoveTo(MovementDirection.Right);

	/// <summary>
	/// Перемещение вверх
	/// </summary>
	protected void MoveUp() => MoveTo(MovementDirection.Up);

	/// <summary>
	/// Перемещение вниз
	/// </summary>
	protected void MoveDown() => MoveTo(MovementDirection.Down);

	/// <summary>
	/// Параметры объекта
	/// </summary>
	protected ObjectCoordinates? GetObjectCoordinates() => _moveableObject?.ObjectCoordinates;

	/// <summary>
	/// Шаг объекта
	/// </summary>
	/// <returns></returns>
	protected int? GetStep() => _moveableObject?.ObjectStep;

	/// <summary>
	/// Перемещение к цели
	/// </summary>
	protected abstract void MoveToTarget();

	/// <summary>
	/// Достигнута ли цель
	/// </summary>
	/// <returns></returns>
	protected abstract bool IsTargetDestinaion();

	/// <summary>
	/// Попытка перемещения в требуемом направлении
	/// </summary>
	/// <param name="movementDirection">Направление</param>
	private void MoveTo(MovementDirection movementDirection)
	{
		if (_state != TemplateMovementStatus.InProgress || _moveableObject is null)
		{
			return;
		}

		_moveableObject.MoveObject(movementDirection);
	}
}