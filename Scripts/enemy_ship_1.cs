using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_ship_1 : MonoBehaviour
{
    Rigidbody2D rb2D;
    ScoreScripts score;
    public GameObject exploding;
    float amplitude, angle;
    Vector2 force;
    int maxy;
    float firstX;
    bool goRight = true;
    bool goLeft = false;
    // Start is called before the first frame update
    // void Start()
    // {   
    //     score = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreScripts>();
    //     transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
    //     rb2D = gameObject.GetComponent<Rigidbosdy2D>();
    //         amplitude = Random.Range(2.0f, 8.0f);
    //         angle = Random.Range(0, 2 * Mathf.PI);
    //         force.x = amplitude * Mathf.Cos(angle);
    //         force.y = amplitude * Mathf.Sin(angle);
    //         rb2D.AddForce(force, ForceMode2D.Impulse);
    // }
    void Start(){
        score = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreScripts>();
        transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
        maxy = Random.Range(0,4);
        firstX = transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
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
    // private void OnTriggerEnter2D(Collider2D other) {
    //      if(other.gameObject.tag == "Laser_1"){
    //         score.addScore(1);
    //         Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0);
    //         Destroy(gameObject);
    //         Destroy(other.gameObject);
    //         Instantiate(exploding, position, transform.rotation);
    //     }
    //     if(other.gameObject.tag == "fighter"){
    //         Destroy(other.gameObject);
    //     }
    // }
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
}
