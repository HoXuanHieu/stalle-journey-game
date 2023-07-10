using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn_enemy : MonoBehaviour
{
    public GameObject enemy_ship_1;
    public GameObject enemy_ship_2;
    public GameObject bonus_item;
    public GameObject boss;
    public int numberOfEnemy_state_1 = 7;
    public int numberOfEnemy_state_2 = 10;
    public float elapseTime = 0;
    public float spawnTime = 2;
    public bool state_1 = true;
    public bool state_2 = false;
    public bool state_3 = false;
    GameOverText gameOverText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GameObject.FindGameObjectWithTag("gameOver").GetComponent<GameOverText>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(state_1){
            if(numberOfEnemy_state_1 > 0 ) {
                if(elapseTime < spawnTime) {
                    elapseTime += Time.deltaTime;
                }
                else{
                    spawnEnemy_state1();
                    numberOfEnemy_state_1--;
                    elapseTime = 0;
                }
            } else {
                if(GameObject.Find("ship7(Clone)") == null) {
                    state_1 = false;
                    state_2 = true;
                    Instantiate(bonus_item, new Vector3(Random.Range(-7,7), Random.Range(0.5f,4), 0),transform.rotation);
                }             
            }
        } if(state_2){
             if(numberOfEnemy_state_2 > 0 ) {
                if(elapseTime < spawnTime) {
                    elapseTime += Time.deltaTime;
                }
                else{
                    spawnEnemy_state2();
                    numberOfEnemy_state_2--;
                    elapseTime = 0;
                }
            } else {
                if(GameObject.Find("enemy_ship_2(Clone)") == null) {
                    state_2 = false;
                    state_3 = true;
                    //nextstate here
                    Instantiate(bonus_item, new Vector3(Random.Range(-7,7), Random.Range(0.5f,4), 0),transform.rotation);
                }             
            }
        } if(state_3){
            Instantiate(boss, new Vector3(0, 8, 0),transform.rotation);
            state_3 = false;
        }  
        if(GameObject.Find("fighter(Clone)") == null){
            gameOverText.GameOver();
        }
    }
    void spawnEnemy_state1(){
        Instantiate(enemy_ship_1, new Vector3(Random.Range(-7,7), 6, 0),transform.rotation);
    }
    void spawnEnemy_state2(){
        Instantiate(enemy_ship_2, new Vector3(Random.Range(-7,7), 6, 0),transform.rotation);
    }
}
