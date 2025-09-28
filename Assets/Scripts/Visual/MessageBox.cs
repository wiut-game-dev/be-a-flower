using TMPro;

using UnityEngine;

public class MessageBox : MonoBehaviour
{
	public TMP_Text Title;
	public TMP_Text Content;

	public GeneralState State;

	public void SetText(string title, string content)
	{
		Title.text = title;
		Content.text = content;
	}

	public void KillYourself()
	{
		Destroy(gameObject);
		State.HoldOn = false;
	}
}