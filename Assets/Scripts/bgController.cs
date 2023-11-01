using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController : MonoBehaviour

{
    public GameObject backgroundPrefab;
    private GameObject bubble; 
    public float bubbleAmplitude = 0.3f; 
    public float bubbleFrequency = 1.0f;
    private float initialBackgroundY;
    // Start is called before the first frame update
    void Start()
    {
        bubble = Instantiate(backgroundPrefab, new Vector3(4.5f, 0, 0), Quaternion.identity);
        initialBackgroundY = bubble.transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 backgroundPosition = bubble.transform.position;
        backgroundPosition.y = initialBackgroundY + Mathf.Sin(Time.time * bubbleFrequency) * bubbleAmplitude;
        bubble.transform.position = backgroundPosition;
    }
}
