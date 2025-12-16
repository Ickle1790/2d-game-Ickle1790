using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponToGive;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Giving the player the new weapon upon contact
            other.gameObject.GetComponent<WeaponSwap>().UpdateWeapon(weaponToGive);
            Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        }
    }
}
