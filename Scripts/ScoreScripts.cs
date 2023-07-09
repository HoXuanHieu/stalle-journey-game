using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScripts : MonoBehaviour
{
    public int playScore = 0;
    public Text scoreText; 

    public void addScore(int score){
        playScore = playScore + score;
        scoreText.text = playScore.ToString();
    }
}
