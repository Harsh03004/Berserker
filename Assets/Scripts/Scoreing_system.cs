using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scoreing_system : MonoBehaviour
{
    public Text Score;
    public int score = 0;
    public int highscore = 0;
    private bool countScore = true;

    // Update is called once per frame
    void Update()
    {
        countscore();
    }

    public void countscore()
    {
        if (countScore)
        {
            ObstacleMovement obs = GetComponent<ObstacleMovement>();
            if (obs != null)
            {
                score = Mathf.RoundToInt(obs.distance);
                Score.text = "Score:"+ score.ToString();
            }
        }
    }
    public void stopcount()
    {
        countScore = false;
        ObstacleMovement obstacle = GetComponent<ObstacleMovement>();
        obstacle.StopMovement();
        if (score > highscore)
        {
            highscore = score;
            Score.text = "High Score:" + highscore.ToString();
        }

        // Stop counting the score

    }
}