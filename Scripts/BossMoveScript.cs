using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveScript : MonoBehaviour
{
    public float moveSpeed = 1;
    public int maxheal = 100;
    public GameObject exploding;
    public GameObject enemy_laser;
    public GameObject enemy_laser_2;
    public GameObject enemy_laser_3;
    public GameObject enemy_laser_4;

    ScoreScripts score;
    LaserShoter shooter;
    bool goRight = true;
    bool goLeft = false;
    public bool shoot_type_1 = false;
    public bool shoot_type_2 = false;
    public float spawnRate = 1f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreScripts>();
        shooter = GameObject.FindGameObjectWithTag("fighter").GetComponent<LaserShoter>();
        transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 3){
            transform.position += (Vector3.down * moveSpeed) * Time.deltaTime;
            shooter.spawnRate = 10f;
            shoot_type_1 = false;
        }
        else{
            shooter.spawnRate = 0.5f;
            shoot_type_1 = true;
        }
        if(maxheal <  90){
            if(goRight){
                transform.position += (Vector3.right)* moveSpeed * Time.deltaTime;
                if(transform.position.x > 0 + 3.5f){
                    goRight = false;
                    goLeft = true;
                }
            }
            if(goLeft){
                transform.position += (Vector3.left) * moveSpeed * Time.deltaTime;
                if(transform.position.x < 0 - 3.5f){
                    goRight = true;
                    goLeft = false;
                }
            }
        }
        if(maxheal == 75){
            moveSpeed = 2.5f;
            spawnRate = 0.8f;
            shoot_type_2 = true;
        }
        //shoot_type_1
        if(shoot_type_1){
            if(timer < spawnRate){
                timer = timer + Time.deltaTime * 0.4f;
            } else {         
                shoot1();
                timer = 0;
            }
        }
        //shoot_type_2
        if(shoot_type_2){
            if(timer < spawnRate){
                timer = timer + Time.deltaTime * 0.4f;
            } else {         
                shoot2();
                timer = 0;
            }
        }
        //boss dead
        if(maxheal == 0){
            Destroy(gameObject);
        }
        
    }
    void shoot1(){
        //mid
        Instantiate(enemy_laser, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1.5f, 0), transform.rotation);
        //right
        Instantiate(enemy_laser_2, new Vector3(gameObject.transform.position.x +0.5f, gameObject.transform.position.y - 1.5f, 0), transform.rotation);
        //left
        Instantiate(enemy_laser_3, new Vector3(gameObject.transform.position.x -0.5f, gameObject.transform.position.y - 1.5f, 0), transform.rotation);
    }
    void shoot2(){
        Instantiate(enemy_laser_4, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1.5f, 0), transform.rotation);
    }
    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.tag == "Laser_1"){
            score.addScore(2);
            Vector3 position = new Vector3(coll.gameObject.transform.position.x, coll.gameObject.transform.position.y,0);
            Destroy(coll.gameObject);
            Instantiate(exploding, position, transform.rotation);
            maxheal--;
        }
        if(coll.gameObject.tag == "fighter"){
            Destroy(coll.gameObject);
            Vector3 position = new Vector3(transform.position.x, transform.position.y,0);
            Destroy(gameObject);
            Instantiate(exploding, position, transform.rotation);
        }
    }
}
