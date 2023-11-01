using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject submarinePrefab;
    public float speed = 7.0f; 
    private GameObject submarine; 
    public GameObject bombPerfab; 
    public float bombVelocity = 5.0f;
    private float screenHalfWidth;
    public AudioClip fireSound;
    private AudioSource audioSource;

    

    void Start()
    {
        submarine = Instantiate(submarinePrefab, new Vector3(0, -4.1f, 0), Quaternion.identity);

        float aspectRatio = Camera.main.aspect;
        Camera camera = Camera.main;
        float cameraHeight = camera.orthographicSize * 2;
        screenHalfWidth = cameraHeight * aspectRatio / 2.0f - 0.5f;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 position = submarine.transform.position;
        position.x += horizontalInput * speed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -screenHalfWidth, screenHalfWidth);
        submarine.transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
        Fire();
        }
    }

    private void Fire()
    {
    GameObject bomb = Instantiate(bombPerfab, submarine.transform.position + submarine.transform.up, Quaternion.identity);
    Rigidbody2D bombRB = bomb.GetComponent<Rigidbody2D>();
    bombRB.velocity = bombVelocity * submarine.transform.up;
    audioSource.PlayOneShot(fireSound);
    }
}
