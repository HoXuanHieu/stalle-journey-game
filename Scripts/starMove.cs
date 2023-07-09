using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starMove : MonoBehaviour
{
    
    public float moveSpeed = 0.01f;
    public float deadZone = -35;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.down * moveSpeed) * Time.deltaTime;
       
       if(transform.position.y < deadZone){
            Destroy(gameObject);
       }
    }
}
