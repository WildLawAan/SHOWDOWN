using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorSet : MonoBehaviour
{
    public Transform tr;
    // Start is called before the first frame update

    // Update is called once per frame
    

    void OnCollisionEnter(Collision collision)
    {
        // 입사벡터를 알아본다. (충돌할때 충돌한 물체의 입사 벡터 노말값)
        //Vector3 incomingVector = Collider.contacts[0].normal;
        //incomingVector = incomingVector.normalized;
        // 충돌한 면의 법선 벡터를 구해낸다.
        //Vector3 normalVector = collision.contacts[0].normal;
        // 법선 벡터와 입사벡터을 이용하여 반사벡터를 알아낸다.
        //Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector); //반사각
        //reflectVector = reflectVector.normalized;

        Vector3 reflect = collision.transform.position - tr.position;

        float result = 0.0f;

        if(reflect.x > 0)
        {
            result = reflect.x;
        }
        else if(reflect.x < 0)
        {
            result = reflect.x;
        }

        collision.rigidbody.AddForce(new Vector3(100.0f * result, 0.0f, 20.0f));

        print("sdsdsd");
    }
}
