using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameDeathTracker : MonoBehaviour
{
	public GameObject DeathImage;
	public GeneralState State;

	// Update is called once per frame
	void Update()
	{
		if(!State.Alive)
			SceneManager.LoadScene("EndScene");
	}
}
