using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
   [SerializeField] private float healthValue;

   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
    {
        // Gives health and then deletes the heart asset
        collision.GetComponent<Health>().AddHealth(healthValue);
        gameObject.SetActive(false);
    }
   }
}
