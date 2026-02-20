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
	private readonly int _drawningCarWidth = 110;

	/// <summary>
	/// Высота прорисовки автомобиля
	/// </summary>
	private readonly int _drawningCarHeight = 90;

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

        Pen pen = new Pen(Color.Black);
        Brush bodyBrush = new SolidBrush(_entityCar.BodyColor);
        Brush trackBrush = new SolidBrush(Color.DarkGray);
        Brush windowBrush = new SolidBrush(Color.LightBlue);

        int x = _startPosX.Value;
        int y = _startPosY.Value;

        // 1. Гусеничная платформа (сместили с 60 на 65)
        g.FillEllipse(trackBrush, x, y + 65, 110, 25);
        g.DrawEllipse(pen, x, y + 65, 110, 25);

        // Катки (сместили с 65 на 70)
        for (int i = 0; i < 5; i++)
        {
            g.FillEllipse(Brushes.Black, x + 10 + (i * 20), y + 70, 15, 15);
            g.DrawEllipse(pen, x + 10 + (i * 20), y + 70, 15, 15);
        }

        // 2. Основной корпус (сместили с 30 на 35)
        g.FillRectangle(bodyBrush, x + 10, y + 35, 90, 30);
        g.DrawRectangle(pen, x + 10, y + 35, 90, 30);

        // 3. Кабина (БЫЛО y - 5, СТАЛО ровно y)
        // Теперь это самая верхняя точка объекта
        g.FillRectangle(bodyBrush, x + 60, y, 40, 35);
        g.DrawRectangle(pen, x + 60, y, 40, 35);

        // 5. Выхлопная труба (сместили с 10 на 15)
        g.FillRectangle(trackBrush, x + 25, y + 15, 5, 20);
        g.DrawRectangle(pen, x + 25, y + 15, 5, 20);
    }
}