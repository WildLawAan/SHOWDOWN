using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 1f;

    private Vector3 playerPos = new Vector3(0 , 0 ,0);

	
	// Update is called once per frame
	void Update () {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);

        playerPos = new Vector3(xPos, 0f, 0);
        //playerPos = new Vector3(Mathf.Clamp(xPos, -10f, 10f), 0f, 0);
        this.transform.position = playerPos;

		
	}


}
