using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScriptA : MonoBehaviour
{
    public GameObject DoorA;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Debug.Log("key picked up");

            DoorA.GetComponent<BoxCollider2D>().enabled = false;

            this.gameObject.SetActive(false);
            DoorA.SetActive(false);
        }
    }
}
