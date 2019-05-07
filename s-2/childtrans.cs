using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childtrans : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject play;
    public GameObject sick;
    public Transform meeple;
    public float distance;
    public GameObject table;
    private bool check = true;




    // Update is called once per frame
    void FixedUpdate()
    {
        meeple = play.gameObject.transform.GetChild(1).GetChild(1);


        //sick.transform.position = Vector3.Lerp(sicktransform.position, meeple.position, Time.deltaTime);
        if (check = true )
        {
            sick.transform.position = meeple.transform.position;
        }
        else if(check = false)
        {
            
            sick.transform.position = sick.transform.position;
            check = true;
        }

        sick.transform.position = meeple.transform.position;






        sick.transform.rotation = meeple.rotation;





    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "wall_floor" )
        {

            check = false;


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "wall_floor")
        {

            check = true;


        }
    }

}
