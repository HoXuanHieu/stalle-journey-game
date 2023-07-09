using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
     public float moveSpeed = 5;
     public float deadZone = 25;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,0,90));

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.up * moveSpeed) * Time.deltaTime;
       
       if(transform.position.y > deadZone){
            Destroy(gameObject);
       }
    }
}
