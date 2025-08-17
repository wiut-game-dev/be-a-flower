using UnityEngine;

public class events : MonoBehaviour
{
    public float minDelay = 10f;
    public float maxDelay = 50f;
    public float delay;
    public float timer;
    
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
       if (timer >= delay)
       {
           timer = 0;
           Debug.Log("something happened");
           SetDelay();
       }
    }
}