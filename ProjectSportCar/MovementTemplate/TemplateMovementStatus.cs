namespace ProjectSportCar.MovementTemplate;

/// <summary>
/// Статус выполнения операции перемещения
/// </summary>
public enum TemplateMovementStatus
{
	/// <summary>
	/// Все готово к началу
	/// </summary>
	NotInit,

	/// <summary>
	/// Выполняется
	/// </summary>
	InProgress,

	/// <summary>
	/// Завершено
	/// </summary>
	Finish
}