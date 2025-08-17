//class representing modificator, contains variable to scale, and percentage to scale it by
//duration is given in seconds, after which modificator should disappear
public class Modificator
{
	public ShareVariable Variable;
	public float Value;
	public float? Duration;
	public Modificator(ShareVariable variable, float value, float? duration = null)
	{
		Variable = variable;
		Value = value;
		Duration = duration;
	}
}

