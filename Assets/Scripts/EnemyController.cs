using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.5f; 
    public GameObject ExplosionPrefab;

    void Update()
    {
        // Move the enemy downward
        Vector3 position = transform.position;
        position.y -= speed * Time.deltaTime;
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player"))
                {
                   collision.gameObject.SetActive(false); 
                    GameObject expo = Instantiate(ExplosionPrefab, transform.position + Vector3.down , Quaternion.identity, transform.parent);
                    expo.transform.localScale = new Vector3(0.8f,0.8f,1); 
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Destroy(expo, 2f); 
                }
    }


    
}

