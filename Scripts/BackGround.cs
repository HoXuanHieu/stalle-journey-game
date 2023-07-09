using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject back_Ground;
    public GameObject Star;
    public GameObject fighter;
    public float spawnRate = 10;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(back_Ground, new Vector3(transform.position.x, transform.position.y, 1), transform.rotation);     
        Instantiate(Star, new Vector3(0, 5, 0), transform.rotation);  
        Instantiate(fighter, new Vector3(0, -4, 0), transform.rotation);        

    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer = timer + Time.deltaTime;
        }else{
            backgroundMove();
            timer = 0;
        }
    }
    void backgroundMove(){
        Instantiate(Star, new Vector3(transform.position.x, 27, 0), transform.rotation);        
    }
}
