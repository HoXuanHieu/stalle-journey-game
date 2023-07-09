using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_item : MonoBehaviour
{
    public float dropSpeed = 2;
    LaserShoter laser;
    // Start is called before the first frame update
    void Start()
    {
        laser = GameObject.FindGameObjectWithTag("fighter").GetComponent<LaserShoter>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.down * dropSpeed) * Time.deltaTime;

        if(gameObject.transform.position.y < -35){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "fighter"){
            Destroy(gameObject);
            laser.setlevel(1);
        }
    }
}
