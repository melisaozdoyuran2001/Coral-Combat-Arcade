using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class bombController : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public ScoreManager scoreManager; 
    
   
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }



    public void Explode()
    {

        GameObject expo = Instantiate(ExplosionPrefab, transform.position + Vector3.up , Quaternion.identity, transform.parent);
    
        Destroy(gameObject, 0.1f);
        Destroy(expo, 2f); 
        
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (collision.gameObject.CompareTag("enemy"))
                {
                      Destroy(collision.gameObject);
                      Explode();
                      ScoreManager.Instance.IncreaseScore();
                }
              
        }
    }
 }
