using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public Text gameOverText;

    public void GameOver(){
        gameOverText.text = "GAME OVER";
    }
}
