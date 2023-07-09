using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ship_2 : MonoBehaviour
{
    ScoreScripts score;
    public GameObject enemyLaser;
    public GameObject exploding;
    public float spawnRate = 2f;
    private float timer = 0;
    int maxy;
    float firstX;
    bool goRight = true;
    bool goLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreScripts>();
        transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
        transform.localScale += new Vector3(0.5f , 0.5f, 0); 
        maxy = Random.Range(0,4);
        firstX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer = timer + Time.deltaTime*0.4f;
        }else{
            shooter();
            timer = 0;
        }
         if(transform.position.y > maxy){
               transform.position += (Vector3.down * 2) * Time.deltaTime;
        }
        else {
            if(goRight){
                transform.position += (Vector3.right) * Time.deltaTime;
                if(transform.position.x > firstX + 2f){
                    goRight = false;
                    goLeft = true;
                }
            }
            if(goLeft){
                transform.position += (Vector3.left) * Time.deltaTime;
                if(transform.position.x < firstX - 2f){
                    goRight = true;
                    goLeft = false;
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.tag == "Laser_1"){
            score.addScore(1);
            Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0);
            Destroy(gameObject);
            Destroy(coll.gameObject);
            Instantiate(exploding, position, transform.rotation);
        }
        if(coll.gameObject.tag == "fighter"){
            Destroy(coll.gameObject);
            Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0);
            Destroy(gameObject);
            Instantiate(exploding, position, transform.rotation);
        }
    }
    void shooter(){
        Instantiate(enemyLaser, new Vector3(gameObject.transform.position.x ,gameObject.transform.position.y, 0), transform.rotation);
    }
}
