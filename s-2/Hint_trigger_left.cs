using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_trigger_left : MonoBehaviour
{

    public AudioSource Hintsound_left;
  

    

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball!(Clone)")
        {
            Hintsound_left.Play();




        }




    }
}
