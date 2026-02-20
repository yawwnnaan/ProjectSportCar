namespace ProjectSportCar;

/// <summary>
/// Полотно
/// </summary>
public class CanvasForCar
{
	/// <summary>
	/// Поле-объект для прорисовки объекта
	/// </summary>
	private DrawningCar? _drawningCar;

	/// <summary>
	/// Ширина полотна
	/// </summary>
	private int? _canvasWidth;

	/// <summary>
	/// Высота полотна
	/// </summary>
	private int? _canvasHeight;

	/// <summary>
	/// Установка границ поля
	/// </summary>
	/// <param name="width">Ширина поля</param>
	/// <param name="height">Высота поля</param>
	public void SetPictureSize(int width, int height)
	{
		_canvasWidth = width;
		_canvasHeight = height;
	}

	/// <summary>
	/// Вставить объекта "автомобиля"
	/// </summary>
	/// <param name="car">Объект "автомобиля"</param>
	/// <returns>true - объект сохранен, false - объект нельзя поместить в имеющиеся размеры формы</returns>
	public bool InsertCar(DrawningCar car)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
        {
            return false;
        }

        if (car.DrawningCarWidth <= _canvasWidth && car.DrawningCarHeight <= _canvasHeight)
        {
            _drawningCar = car;
            return true;
        }
        return false;
  
		//TODO
		// если размеры форм не заданы, то завершаем работу метода
		// если размеры форм есть, то проверяем, что по размерам объект можно поместить в поле
		// если не удается - завершаем работу метода
		// если можно, то сохраняем ссылку на объект
	}

	/// <summary>
	/// Установка позиции объекта
	/// </summary>
	/// <param name="x">Координата X</param>
	/// <param name="y">Координата Y</param>
	public void SetCarPosition(int x, int y)
	{
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningCar is null)
        {
            return;
        }

        if (x < 0) x = 0;
        if (x + _drawningCar.DrawningCarWidth > _canvasWidth)
            x = _canvasWidth.Value - _drawningCar.DrawningCarWidth;


        if (y < 0) y = 0;
        if (y + _drawningCar.DrawningCarHeight > _canvasHeight)
            y = _canvasHeight.Value - _drawningCar.DrawningCarHeight;

        _drawningCar.SetPosition(x, y);

        // TODO
        // если размеры форм не заданы или не задан объект DrawningCar, то завершаем работу метода
        // если при установке объекта в эти координаты, он будет "выходить" за границы формы
        // то надо изменить координаты, чтобы он оставался в этих границах
    }

	/// <summary>
	/// Изменение направления перемещения
	/// </summary>
	/// <param name="direction">Направление</param>
	/// <returns>true - перемещение выполнено, false - перемещение невозможно</returns>
	public bool MoveTransport(DirectionType direction)
	{
		if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningCar is null || !_drawningCar.PosX.HasValue || !_drawningCar.PosY.HasValue || !_drawningCar.CarStep.HasValue)
		{
			return false;
		}

		switch (direction)
		{
			//влево
			case DirectionType.Left:
				if (_drawningCar.PosX.Value - _drawningCar.CarStep.Value > 0)
				{
					_drawningCar.MoveLeft();
					return true;
				}

				break;
			//вверх
			case DirectionType.Up:
				if (_drawningCar.PosY.Value - _drawningCar.CarStep.Value > 0)
				{
					_drawningCar.MoveUp();
					return true;
				}

				break;
			// вправо
			case DirectionType.Right:
                if (_drawningCar.PosX.Value + _drawningCar.DrawningCarWidth + _drawningCar.CarStep.Value < _canvasWidth.Value)
                {
                    _drawningCar.MoveRight();
                    return true;
                }
                //TODO прописать логику сдвига в право
                break;
			//вниз
			case DirectionType.Down:
                if(_drawningCar.PosY.Value + _drawningCar.DrawningCarHeight + _drawningCar.CarStep.Value < _canvasHeight.Value)
    {
                    _drawningCar.MoveDown();
                    return true;
                }
                //TODO прописать логику сдвига в вниз
                break;
		}

		return false;
	}

	/// <summary>
	/// Прорисовка полотна
	/// </summary>
	/// <returns></returns>
	public Bitmap? DrawCanvas()
	{
		if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
		{
			return null;
		}

		Bitmap bmp = new(_canvasWidth.Value, _canvasHeight.Value);
		Graphics graphics = Graphics.FromImage(bmp);
		_drawningCar?.DrawTransport(graphics);
		return bmp;
	}
}