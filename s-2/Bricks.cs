using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{

    public int score = 10;
    //public AudioSource breaks;

    //접근2public Manager manager;


    //private void Start()
    //{
    //manager = GameObject.Find("GameManager").GetComponent<Manager>();
    //GameManger라는 object를 찾아서 Manager라고 하는 클래스를 찾아서 접근해라
    //}

    public void OnCollisionEnter(Collision collision)
    {
        Block();


    }

    public virtual void Block()
    {
        Manager.Instance().DestroyBricks();//현재 살아남은 singleturn pattern
        //접근2 manager.DestroyBricks();
        Manager.Instance().blockScore += score;
        Manager.Instance().currentScore_text.text = "Current score: " + Manager.Instance().blockScore.ToString();//형변환
        Destroy(gameObject);
        //breaks.Play();
        desty();




    }

    IEnumerator desty()
    {
        
        yield return new WaitForSeconds(1f);
    }
}
