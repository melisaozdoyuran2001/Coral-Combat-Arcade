using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("bomb")) {
       Destroy(other.gameObject); 
    }
}
}
