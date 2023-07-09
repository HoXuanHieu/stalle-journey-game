using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_laser : MonoBehaviour
{
     public float moveSpeed = 2;
     public float deadZone = -15;
     public GameObject exploding;
     // Start is called before the first frame update
     void Start()
     {
         transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
     }

    // Update is called once per frame
     void Update()
     {
          transform.position += (Vector3.down * moveSpeed) * Time.deltaTime;
          if(transform.position.y < deadZone){
               Destroy(gameObject);
          }
     }
     void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag == "fighter"){
            Vector3 position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y,0);
            Instantiate(exploding, position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
     }
}
