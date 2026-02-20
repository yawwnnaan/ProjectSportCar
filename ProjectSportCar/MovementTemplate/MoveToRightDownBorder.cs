namespace ProjectSportCar.MovementTemplate;

/// <summary>
/// Стратегия перемещения объекта к парвой нижней границе экрана
/// </summary>
public class MoveToRightDownBorder : BaseTemplateMovement
{
    // Проверка: достигли ли мы правого нижнего угла?
    protected override bool IsTargetDestinaion()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj == null) return false;

        // Считаем, что дошли, если расстояние до края меньше шага
        return (FieldWidth - obj.RightBorder <= GetStep()) &&
               (FieldHeight - obj.DownBorder <= GetStep());
    }

    // Логика движения к углу
    protected override void MoveToTarget()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj == null) return;

        if (obj.RightBorder < FieldWidth) MoveRight();
        if (obj.DownBorder < FieldHeight) MoveDown();
    }
}