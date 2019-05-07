using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{



    private void OnCollisionEnter(Collision collision)
    {




        //Destroy(collision.gameObject);

        if (collision.gameObject.name == "Ball!(Clone)")
        {
            Destroy(collision.gameObject);
            Manager.Instance().Win();
            //desty();
        }





    }
}

