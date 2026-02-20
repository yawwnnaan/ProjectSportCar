using ProjectSportCar.Entities;

namespace ProjectSportCar.Drawnings;

/// <summary>
/// Класс, отвечающий за прорисовку и перемещение объекта-сущности
/// </summary>
public class DrawningSportCar : DrawningCar
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес</param>
    /// <param name="bodyColor">Основной цвет</param>
    /// <param name="additionalColor">Дополнительный цвет</param>
    /// <param name="craneBoom">Признак наличия крана</param>
    /// <param name="counterweight">Признак наличия противовеса</param>
    public DrawningSportCar(int speed, double weight, Color bodyColor, Color additionalColor, bool craneBoom, bool counterweight) 
		: base(170, 130)
	{
		_entityCar = new EntitySportCar(speed, weight, bodyColor, additionalColor, craneBoom, counterweight);
	}

	public override void DrawTransport(Graphics g)
	{
        if (_entityCar is not EntitySportCar crane || !_startPosX.HasValue || !_startPosY.HasValue) return;

        _startPosX += 20;
        _startPosY += 40;

        // база
        base.DrawTransport(g);

        _startPosX -= 20;
        _startPosY -= 40;

        int x = _startPosX.Value;
        int y = _startPosY.Value;

        Brush addBrush = new SolidBrush(crane.AdditionalColor);
        Pen pen = new Pen(Color.Black);

        // противовес
        if (crane.Counterweight)
        {
            g.FillRectangle(addBrush, x + 15, y + 75, 15, 25);
            g.DrawRectangle(pen, x + 15, y + 75, 15, 25);
        }

        // трос и крюк
        if (crane.CraneBoom)
        {
            Pen thinBoomPen = new Pen(crane.AdditionalColor, 4);

            g.DrawLine(thinBoomPen, x + 85, y + 40, x + 145, y + 10);

            g.DrawLine(pen, x + 145, y + 10, x + 145, y + 50);
            g.DrawArc(pen, x + 140, y + 50, 10, 10, 0, 180);

            thinBoomPen.Dispose();
        }

        addBrush.Dispose();
        pen.Dispose();
    }
}