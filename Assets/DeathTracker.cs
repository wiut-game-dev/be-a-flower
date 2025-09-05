using UnityEngine;

public class DeathTracker : MonoBehaviour
{
	public GameObject DeathImage;
	public GeneralState State;

	// Update is called once per frame
	void Update()
	{
		if(!State.Alive && !DeathImage.activeSelf)
			DeathImage.SetActive(true);
	}
}
