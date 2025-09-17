using System.Collections.Generic;

using UnityEngine;

public class EventPick : MonoBehaviour
{
	public float minDelay = 10f;
	public float maxDelay = 50f;
	public float delay;
	public float timer;

	public GeneralState GeneralState;

	public List<Event> events;

	private void SetDelay()
	{
		delay = Random.Range(minDelay, maxDelay);
	}

	private void Start()
	{
		SetDelay();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if(timer >= delay)
		{
			timer = 0;
			Event ev = events[Random.Range(0, events.Count)];
			//do sth
		}
	}
}
