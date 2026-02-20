namespace ProjectSportCar.MovementTemplate;

/// <summary>
/// Цель перемещения объекта в центр экрана
/// </summary>
public class MoveToCenter : BaseTemplateMovement
{
	protected override bool IsTargetDestinaion()
	{
		ObjectCoordinates? objParams = GetObjectCoordinates();
		if (objParams is null)
		{
			return false;
		}

		return Math.Abs(objParams.ObjectMiddleHorizontal - FieldWidth / 2) <= GetStep() && Math.Abs(objParams.ObjectMiddleVertical - FieldHeight / 2) <= GetStep();
	}

	protected override void MoveToTarget()
	{
		ObjectCoordinates? objParams = GetObjectCoordinates();
		if (objParams is null)
		{
			return;
		}

		int diffX = objParams.ObjectMiddleHorizontal - FieldWidth / 2;
		if (Math.Abs(diffX) > GetStep())
		{
			if (diffX > 0)
			{
				MoveLeft();
			}
			else
			{
				MoveRight();
			}
		}

		int diffY = objParams.ObjectMiddleVertical - FieldHeight / 2;
		if (Math.Abs(diffY) > GetStep())
		{
			if (diffY > 0)
			{
				MoveUp();
			}
			else
			{
				MoveDown();
			}
		}
	}
}