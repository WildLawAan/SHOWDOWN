using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayer : MonoBehaviour
{
    public Transform ball;
    public GameObject other_player;
    public GameObject stcks;
    float a;
    float b;
    float c;
    
    

    

    Transform tr;
    public AudioSource tick;
    

    private void Start()
    {
        tr = GetComponent<Transform>();
        

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball!(Clone)")
        {
            tick.Play();




        }

        


    }

    private void FixedUpdate()
    {
        
        ball = Ball.Instance().ball_transform;
        
        
        a = ball.position.x;
        b = ball.position.y;
        c = ball.position.z;

        //other_player.transform.position = new Vector3(Mathf.Clamp(a * 1.2f, -2f,0f), Mathf.Clamp((b), 0.5f, 0.8f), Mathf.Clamp(c, 5.5f, 6f));
        //Vector3..0Lerp(other_player.transform.position, new Vector3(a, b, 29.77f), Time.deltaTime);

       // other_player.transform.position = new Vector3(a, b, 29.77f);
        if (Ball.Instance().outs < 3) {
            other_player.transform.position = new Vector3(a, b, 29.77f);
        }
        else if(Ball.Instance().outs  > Manager.Instance().level)
        {
            other_player.transform.position = other_player.transform.position;
            Ball.Instance().outs = 0;

        }
        else
        {
            other_player.transform.position = other_player.transform.position;
        }

        stcks.transform.position = other_player.transform.position;
        




    }

    
}
