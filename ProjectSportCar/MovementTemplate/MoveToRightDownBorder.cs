namespace ProjectSportCar.MovementTemplate;

/// <summary>
/// Стратегия перемещения объекта к парвой нижней границе экрана
/// </summary>
public class MoveToRightDownBorder : BaseTemplateMovement
{
    // достигнут ли мы правый нижний угол
    protected override bool IsTargetDestinaion()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj == null) return false;

        // если расстояние меньше шага
        return (FieldWidth - obj.RightBorder <= GetStep()) &&
               (FieldHeight - obj.DownBorder <= GetStep());
    }

    protected override void MoveToTarget()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj == null) return;

        if (obj.RightBorder < FieldWidth) MoveRight();
        if (obj.DownBorder < FieldHeight) MoveDown();
    }
}