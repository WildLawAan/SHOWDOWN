using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRightSound : MonoBehaviour
{
    public AudioSource tick;

    // Start is called before the first frame update

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball!(Clone)")
        {
            float a = collision.gameObject.transform.position.z;
            a = a / 30;
            //print(a);
            tick.panStereo = 0.8f;
            tick.volume =1 - a;
            tick.Play();


            

        }


    }
}
