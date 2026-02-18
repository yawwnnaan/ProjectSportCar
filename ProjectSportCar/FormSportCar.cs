namespace ProjectSportCar;

public partial class FormSportCar : Form
{
	/// <summary>
	/// Поле-объект полотно
	/// </summary>
	private readonly CanvasForCar _canvas;

	/// <summary>
	/// Поле для фиксации состояния для следующего шага проверки выхода за границы
	/// </summary>
	private DirectionType _checkBordersState;

	/// <summary>
	/// Инициализация формы
	/// </summary>
	public FormSportCar()
	{
		InitializeComponent();
		_canvas = new CanvasForCar();
		_canvas.SetPictureSize(pictureBoxSportCar.Width, pictureBoxSportCar.Height);
		_checkBordersState = DirectionType.None;
	}

	/// <summary>
	/// Метод прорисовки машины
	/// </summary>
	private void Draw() => pictureBoxSportCar.Image = _canvas.DrawCanvas();

	/// <summary>
	/// Обработка нажатия кнопки "Создать"
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonCreateCar_Click(object sender, EventArgs e)
	{
		Random random = new();
		DrawningCar car = new();
		car.Init(random.Next(100, 300), random.Next(1000, 3000), Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
		if (_canvas.InsertCar(car))
		{
			_canvas.SetCarPosition(random.Next(10, 100), random.Next(10, 100));
			Draw();
		}
	}

	/// <summary>
	/// Перемещение объекта по форме (нажатие кнопок навигации)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonMove_Click(object sender, EventArgs e)
	{
		string name = ((Button)sender)?.Name ?? string.Empty;
		DirectionType direction = DirectionType.None;
		switch (name)
		{
			case "buttonUp":
				direction = DirectionType.Up;
				break;
			case "buttonDown":
				direction = DirectionType.Down;
				break;
			case "buttonLeft":
				direction = DirectionType.Left;
				break;
			case "buttonRight":
				direction = DirectionType.Right;
				break;
		}

		if (_canvas.MoveTransport(direction))
		{
			Draw();
		}
	}

	/// <summary>
	/// Проверка, что объект не выходит за границы при неверно заданных координатах
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonCheckBorders_Click(object sender, EventArgs e)
	{
		Random random = new();
		switch (_checkBordersState)
		{
			case DirectionType.None:
			case DirectionType.Down:
				_canvas.SetCarPosition(random.Next(10, 100) - 1000, random.Next(10, 100));
				_checkBordersState = DirectionType.Left;
				break;
			case DirectionType.Left:
				_canvas.SetCarPosition(random.Next(10, 100), random.Next(10, 100) - 1000);
				_checkBordersState = DirectionType.Up;
				break;
			case DirectionType.Up:
				_canvas.SetCarPosition(random.Next(10, 100) + pictureBoxSportCar.Width, random.Next(10, 100));
				_checkBordersState = DirectionType.Right;
				break;
			case DirectionType.Right:
				_canvas.SetCarPosition(random.Next(10, 100), random.Next(10, 100) + pictureBoxSportCar.Height);
				_checkBordersState = DirectionType.Down;
				break;
		}

		Draw();
	}
}