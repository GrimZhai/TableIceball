using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    public GameObject ballPrefab;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 scanPos;

    // Use this for initialization
    void Start () {
        scanPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (transform.position.z < 0)
        {
            if (transform.position.z + v*0.1f < 0 && transform.position.z + v * 0.1f > -6)
            {                
                transform.Translate(0, 0, v * 0.1f);
            }

            if (transform.position.x + h*0.1f < 3.5 && transform.position.x + h * 0.1f > -3.5)
            {
                transform.Translate(h * 0.1f, 0, 0);
            }
        }
        else
        {
            
            if (transform.position.z - v * 0.1f > 0 && transform.position.z - v * 0.1f < 6)
            {
                transform.Translate(0, 0, -v * 0.1f);
            }
        
            if (transform.position.x - h * 0.1f < 3.5 && transform.position.x - h * 0.1f > -3.5)
            {
                transform.Translate(-h * 0.1f, 0, 0);
            }
        }

    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
        offset = scanPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (!isLocalPlayer)
            return;
        
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
       
        if (transform.position.z < 0)
        {
            if (curPosition.z < -0.5 && curPosition.z > -6)
            {
                transform.position = new Vector3(curPosition.x, 0, curPosition.z); 
            }
            if (curPosition.x < 3.5 && curPosition.x > -3.5)
            {
                transform.position = new Vector3(curPosition.x, 0, curPosition.z);
            }
        }
        else
        {
            if (curPosition.z > 0.5 && curPosition.z < 6)
            {
                transform.position = new Vector3(curPosition.x, 0, curPosition.z);
            }
            if (curPosition.x < 3.5 && curPosition.x > -3.5)
            {
                transform.position = new Vector3(curPosition.x, 0, curPosition.z);
            }
        }
        
    }

    public override void OnStartLocalPlayer()
    {
        if (GameObject.Find("Ball(Clone)") == null)
            CmdStart();

        if (transform.position.z < 0)
        {
            GameObject.Find("Camera").SetActive(false);
        }

        MeshRenderer[] temp = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer m in temp)
        {
            m.material.color = Color.red;
        }
    }    

    [Command]
    void CmdStart()
    {
        GameObject ball = Instantiate(ballPrefab,new Vector3(0, 0, 0),Quaternion.identity);

        NetworkServer.Spawn(ball);        
    }    
}
