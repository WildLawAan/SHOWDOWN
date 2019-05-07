using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BricksChild : Bricks {

    //public GameObject wow;

    private void OnDisable()
    {
        //wow.gameObject.SetActive(false);
    }

    public override void Block()
    {
        base.Block();
        //Debug.Log("Hello");
        //StartCoroutine(TextEffect());
    }

    //IEnumerator TextEffect()
    //{
        
    //}
}
