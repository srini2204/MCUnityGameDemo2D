using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public bool showTimer;
    public static int intScore;

    public Text scoreBoardText;
    public Animator animator;

    public void startTimer()
    {
        intScore = 0;
        //tbc.startTimer();

        if (!showTimer)
        {
            //tbc.hideTimer();
        }
        scoreBoardText.text = intScore.ToString();
    }

    public void incrementScore(int val = 1)
    {
        intScore += val;
        //sbc.updateScore(intScore);
        animator.SetTrigger("update");
        scoreBoardText.text = intScore.ToString();
    }

    public void decrementScore()
    {
        intScore = Mathf.Max(0, intScore - 1);
        scoreBoardText.text = intScore.ToString();
    }

    public void resetScore()
    {
        intScore = 0;
        scoreBoardText.text = intScore.ToString();
    }

    public void updateScore(int val)
    {
        intScore = val;
        scoreBoardText.text = intScore.ToString();
    }
}