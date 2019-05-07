using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_trigger_right : MonoBehaviour
{

    
    public AudioSource Hintsound_right;

    

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball!(Clone)")
        {
            Hintsound_right.Play();




        }




    }
}
