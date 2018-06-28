using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    GlobalVariables GV;
    public float score;
    public double displayScore;
    Text displayText;

    public void Start()
    {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        displayText = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<Text>();
    }

    private void Update()
    {
        displayScore = Convert.ToDouble(score);
        displayText.text = ConvertToDisplayable(Convert.ToDouble(displayScore));
    }

    public void AddScore(float score)
    {
        this.score += score;
        GV.allscore += score;
    }

    public void BuyObject(float score)
    {
        this.score -= score;
    }

    public void SetScore(float score)
    {
        this.score = score;
    }

    public String ConvertToDisplayable(double number)
    {
        if (number < 1000)
        {
            number = System.Math.Round(number, 2);
            return number.ToString();
        }
        if (number < 1000000)
        {
            number = number / 1000;
            number = System.Math.Round(number, 2);
            return number + "k";
        }
        if (number < 1000000000)
        {
            number = number / 1000000;
            number = System.Math.Round(number, 2);
            return number + "M";
        }
        else
        {
            number = number / 1000000000;
            number = System.Math.Round(number, 2);
            return number + "G";
        }
    }
    public String ConvertToDisplayable(float number)
    {
        return ConvertToDisplayable(Convert.ToDouble(number));
    }
    public String ConvertToDisplayable(int number)
    {
        return ConvertToDisplayable(Convert.ToDouble(number));
    }

}
