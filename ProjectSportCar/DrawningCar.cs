namespace ProjectSportCar;

/// <summary>
/// Класс, отвечающий за прорисовку и перемещение объекта-сущности
/// </summary>
public class DrawningCar
{
	/// <summary>
	/// Класс-сущность
	/// </summary>
	private EntityCar? _entityCar;

	/// <summary>
	/// Левая координата прорисовки автомобиля
	/// </summary>
	private int? _startPosX;

	/// <summary>
	/// Верхняя координата прорисовки автомобиля
	/// </summary>
	private int? _startPosY;

	/// <summary>
	/// Ширина прорисовки автомобиля
	/// </summary>
	private readonly int _drawningCarWidth = 90;

	/// <summary>
	/// Высота прорисовки автомобиля
	/// </summary>
	private readonly int _drawningCarHeight = 50;

	/// <summary>
	/// Левая координата прорисовки автомобиля
	/// </summary>
	public int? PosX => _startPosX;

	/// <summary>
	/// Верхняя координата прорисовки автомобиля
	/// </summary>
	public int? PosY => _startPosY;

	/// <summary>
	/// Шаг перемещения
	/// </summary>
	public double? CarStep => _entityCar?.Step;

	/// <summary>
	/// Ширина прорисовки автомобиля
	/// </summary>
	public int DrawningCarWidth => _drawningCarWidth;

	/// <summary>
	/// Высота прорисовки автомобиля
	/// </summary>
	public int DrawningCarHeight => _drawningCarHeight;

	/// <summary>
	/// Инициализация свойств
	/// </summary>
	/// <param name="speed">Скорость</param>
	/// <param name="weight">Вес автомобиля</param>
	/// <param name="bodyColor">Основной цвет</param>
	public void Init(int speed, double weight, Color bodyColor)
	{
		_entityCar = new EntityCar();
		_entityCar.Init(speed, weight, bodyColor);
		_startPosX = null;
		_startPosY = null;
	}

	/// <summary>
	/// Установка позиции
	/// </summary>
	/// <param name="x">Координата X</param>
	/// <param name="y">Координата Y</param>
	public void SetPosition(int x, int y)
	{
		_startPosX = x;
		_startPosY = y;
	}

	/// <summary>
	/// Сдвиг изображения влево
	/// </summary>
	public void MoveLeft()
	{
		if (_entityCar is null || !_startPosX.HasValue)
		{
			return;
		}

		_startPosX -= (int)_entityCar.Step;
	}

	/// <summary>
	/// Сдвиг изображения вправо
	/// </summary>
	public void MoveRight()
	{
		if (_entityCar is null || !_startPosX.HasValue)
		{
			return;
		}

		_startPosX += (int)_entityCar.Step;
	}

	/// <summary>
	/// Сдвиг изображения вверх
	/// </summary>
	public void MoveUp()
	{
		if (_entityCar is null || !_startPosY.HasValue)
		{
			return;
		}

		_startPosY -= (int)_entityCar.Step;
	}

	/// <summary>
	/// Сдвиг изображения вниз
	/// </summary>
	public void MoveDown()
	{
		if (_entityCar is null || !_startPosY.HasValue)
		{
			return;
		}

		_startPosY += (int)_entityCar.Step;
	}

	/// <summary>
	/// Прорисовка объекта
	/// </summary>
	/// <param name="g"></param>
	public void DrawTransport(Graphics g)
	{
		if (_entityCar is null || !_startPosX.HasValue || !_startPosY.HasValue)
		{
			return;
		}

		Pen pen = new(Color.Black);

		//границы автомобиля
		g.DrawEllipse(pen, _startPosX.Value, _startPosY.Value, 20, 20);
		g.DrawEllipse(pen, _startPosX.Value, _startPosY.Value + 30, 20, 20);
		g.DrawEllipse(pen, _startPosX.Value + 70, _startPosY.Value, 20, 20);
		g.DrawEllipse(pen, _startPosX.Value + 70, _startPosY.Value + 30, 20, 20);
		g.DrawRectangle(pen, _startPosX.Value - 1, _startPosY.Value + 10, 10, 30);
		g.DrawRectangle(pen, _startPosX.Value + 80, _startPosY.Value + 10, 10, 30);
		g.DrawRectangle(pen, _startPosX.Value + 10, _startPosY.Value - 1, 70, 52);

		//задние фары
		Brush brRed = new SolidBrush(Color.Red);
		g.FillEllipse(brRed, _startPosX.Value, _startPosY.Value, 20, 20);
		g.FillEllipse(brRed, _startPosX.Value, _startPosY.Value + 30, 20, 20);

		//передние фары
		Brush brYellow = new SolidBrush(Color.Yellow);
		g.FillEllipse(brYellow, _startPosX.Value + 70, _startPosY.Value, 20, 20);
		g.FillEllipse(brYellow, _startPosX.Value + 70, _startPosY.Value + 30, 20, 20);

		//кузов
		Brush br = new SolidBrush(_entityCar.BodyColor);
		g.FillRectangle(br, _startPosX.Value, _startPosY.Value + 10, 10, 30);
		g.FillRectangle(br, _startPosX.Value + 80, _startPosY.Value + 10, 10, 30);
		g.FillRectangle(br, _startPosX.Value + 10, _startPosY.Value, 70, 50);

		//стекла
		Brush brBlue = new SolidBrush(Color.LightBlue);
		g.FillRectangle(brBlue, _startPosX.Value + 60, _startPosY.Value + 5, 5, 40);
		g.FillRectangle(brBlue, _startPosX.Value + 20, _startPosY.Value + 5, 5, 40);
		g.FillRectangle(brBlue, _startPosX.Value + 25, _startPosY.Value + 3, 35, 2);
		g.FillRectangle(brBlue, _startPosX.Value + 25, _startPosY.Value + 46, 35, 2);

		//выделяем рамкой крышу
		g.DrawRectangle(pen, _startPosX.Value + 25, _startPosY.Value + 5, 35, 40);
		g.DrawRectangle(pen, _startPosX.Value + 65, _startPosY.Value + 10, 25, 30);
		g.DrawRectangle(pen, _startPosX.Value, _startPosY.Value + 10, 15, 30);
	}
}