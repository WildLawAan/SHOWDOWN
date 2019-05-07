using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public Transform righthand;
    public GameObject realstick;
    public GameObject stick;
    public AudioSource p_tick;
    float a;
    float b;
    float c;
    float d;

    Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();

    }

    private void FixedUpdate()
    {
        a = righthand.position.x;
        b = righthand.position.z;
        c = righthand.position.y;
        d = realstick.transform.rotation.y;
        stick.transform.position = new Vector3(Mathf.Clamp((a), -4.2f, 6.4f), Mathf.Clamp((c), 3.36f, 3.5f), Mathf.Clamp((0.1f + b), 3.0f,8f) );
        //stick.transform.rotation = Quaternion.Euler(new Vector3(0, -180+d , 0));


    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball!(Clone)")
        {
            p_tick.Play();




        }




    }





}
