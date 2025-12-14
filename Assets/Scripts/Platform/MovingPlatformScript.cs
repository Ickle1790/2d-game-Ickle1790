using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public int locationIndex = 0;
    public Transform[] locations; // 2

    // Update is called once per frame
    void Update()
    {
       if (transform.position != locations[locationIndex].position)
       {
        transform.position = Vector3.MoveTowards(transform.position, locations[locationIndex].position, 2 * Time.deltaTime);
       }

       else
       {
        if(locationIndex + 1 == locations.Length)
        {
            locationIndex = 0;
        }
        else
        {
            locationIndex++;
        }
       }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = null;
        }
    }
}
