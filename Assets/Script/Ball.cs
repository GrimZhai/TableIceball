using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	
    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        var speed = GetComponent<Rigidbody>().velocity;
        

        if (!(transform.position.z > -6 && transform.position.z < 6))
        {
            //hit bottom or top:
            speed.z = -speed.z;
            GetComponent<Rigidbody>().velocity = speed;
                             
        }
        
        if (!(transform.position.x > -3.5 && transform.position.x < 3.5))
        {
            speed.x = -speed.x;
            GetComponent<Rigidbody>().velocity = speed;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Debug.Log(hit.name);
        //hit the gate
        if (hit.CompareTag("gate"))
        {
            var score = GetComponent<Score>();
            if (transform.position.z > 0)
            {
                score.HostWin();
                transform.position = new Vector3(0, 0, 3);
            }
            else
            {
                score.ClientWin();
                transform.position = new Vector3(0, 0, -3);

            }

            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        //hit the player
        if (hit.CompareTag("Player")){
            GetComponent<Rigidbody>().AddForce(transform.forward* 1.2f);
    
        }
    }
}
