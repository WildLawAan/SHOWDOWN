using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_trigger_mid : MonoBehaviour
{


    public AudioSource Hintsound_mid;
  

    

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball!(Clone)")
        {
            Hintsound_mid.Play();




        }




    }
}
