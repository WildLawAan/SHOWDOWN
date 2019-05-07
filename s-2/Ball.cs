using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Ball : MonoBehaviour {
    static Ball _instance = null;
    public float ballinitalVelocity = 600f;
    public SteamVR_Action_Vibration hapticAction;
    public Transform ball_transform;
    public int outs;
    public bool go ;
    public float resetgame;
    

    private Rigidbody rb;
    private bool ballInPlay;
    private bool tick;
    float pow;
    

    // Use this for initialization

    public static Ball Instance()
    {
        return _instance;
    }

    // Use this for initialization
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }

        

        DontDestroyOnLoad(this);
    }


    void Start () {
         //붙어있는 rigifbody를 가져온다.
        tick = false;
        rb = GetComponent<Rigidbody>();
        go = false;
        


    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Stick" || collision.gameObject.name == "Sticks")
        {
            
            rb.AddForce(0, 0, 4f, ForceMode.Impulse);
            print("Stick!");
            


        }

        if (collision.gameObject.name == "Other_Player")
        {
            rb.AddForce(0, 0, -3f, ForceMode.Impulse);
            outs += 1;
            go = true;




        }


    }

    //public void oncollisionstay(collision collision)
    //{
    //    if (collision.gameobject.name == "stick")
    //    {
    //        rb.addforce(0, 0, 2f, forcemode.impulse);
    //        print("sdsd");
    //    }


    //    else if (collision.gameobject.name == "other_player")
    //    {
    //        rb.addforce(0, 0, -2f, forcemode.impulse);


    //    }

    //}

    //public void OnCollisonStay(Collision collision)
    //{

    //    //if (collision.gameObject.name == "Stick")
    //    //{
    //    //    //pow = collision.gameObject.transform.position.x;

    //    //    rb.AddForce(0, 0, 4f, ForceMode.Impulse);
    //    //    //오른쪽으로 힘이 많이 나가던 원인
    //    //    Pulse(1, 75, 40, SteamVR_Input_Sources.Any);
    //    //    print("whiwhiw");

    //    //}

    //    else if (collision.gameObject.name == "Other_Player")
    //    {
    //        rb.AddForce(0, 0, -4f, ForceMode.Impulse);


    //    }
    //}









    //public void OnCollisoSExit(Collision collision)
    //{

    //    if (collision.gameObject.name == "Stick")
    //    {
    //        //pow = collision.gameObject.transform.position.x;

    //        rb.AddForce(0, 0, 4f, ForceMode.Impulse);
    //        //오른쪽으로 힘이 많이 나가던 원인
    //        Pulse(1, 75, 40, SteamVR_Input_Sources.Any);
    //        print("whiwhiw");

    //    }









    //}

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        //print("Pulse");
    }

    public void FixedUpdate()
    {
        

        ball_transform = this.transform;
        //print(rb.veloc{ity);
        if(tick == true)
        {
            
            tick = false;
            print("ss");


        }
        //print(rb.velocity +  "velo");
        //if(rb.velocity.x)
        //속도조절
        //굉장히 비효율적인 코드이다.
        if(rb.velocity.x > 11 || rb.velocity.y > 11| rb.velocity.z > 11)
        {
            rb.velocity = (rb.velocity / 100) * Manager.Instance().ballspeed;
            Debug.Log("DOWN!!!");
        }
        
        if(rb.velocity.x <= resetgame && rb.velocity.x >= -resetgame && go == true)
        {
            if (rb.velocity.z <= resetgame && rb.velocity.z >= -resetgame)
            {
                resetgame = Manager.Instance().resetgame;
                if(rb.transform.position.z >=8f  )
                Manager.Instance().Re();
            }
        }


    }



    IEnumerator DoSomething()
    {

        
        yield return new WaitForSeconds(4);
        
    }

}
