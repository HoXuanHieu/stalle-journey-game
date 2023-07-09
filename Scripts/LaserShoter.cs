using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserShoter : MonoBehaviour
{
    
    public GameObject laser;
    public float spawnRate = 0.5f;
    private float timer = 0;
    int level =1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer = timer + Time.deltaTime;
        }else{
            if(level == 1){
                laserShot_1();
            }if(level ==2){
                laserShot_2();
            }if(level ==3){
                LaserShot_3();
            }
            timer = 0;
        }
    }
    void laserShot_1(){
        Instantiate(laser, new Vector3(gameObject.transform.position.x ,gameObject.transform.position.y, 0), transform.rotation);
    }
    void laserShot_2(){
        Instantiate(laser, new Vector3(gameObject.transform.position.x - 0.3f ,gameObject.transform.position.y, 0), transform.rotation);
        Instantiate(laser, new Vector3(gameObject.transform.position.x + 0.3f ,gameObject.transform.position.y, 0), transform.rotation);
    }
    void LaserShot_3(){
        Instantiate(laser, new Vector3(gameObject.transform.position.x - 0.5f ,gameObject.transform.position.y, 0), transform.rotation);
        Instantiate(laser, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, 0), transform.rotation);
        Instantiate(laser, new Vector3(gameObject.transform.position.x + 0.5f ,gameObject.transform.position.y, 0), transform.rotation);
    }
    public void setlevel(int level_input){
        level += level_input;
    }
}
