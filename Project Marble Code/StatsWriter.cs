using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsWriter : MonoBehaviour {

    GlobalVariables GV;
    ScoreCounter score;

    Text TotalTiksCount;
    Text TotalPlaytimeCount;
    Text TiksPerSecondCount;
    Text GoldCubesTotalCount;
    Text CubesClearedCount;
    Text TotalAscendsCount;
    Text AscendRewardCount;

	void Start () {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        score = GV.GetComponent<ScoreCounter>();
        TotalTiksCount = GameObject.Find("TotalTiksCount").GetComponent<Text>();
        TotalPlaytimeCount = GameObject.Find("TotalPlaytimeCount").GetComponent<Text>();
        TiksPerSecondCount = GameObject.Find("TiksPerSecondCount").GetComponent<Text>();
        GoldCubesTotalCount = GameObject.Find("GoldCubesTotalCount").GetComponent<Text>();
        CubesClearedCount = GameObject.Find("CubesClearedCount").GetComponent<Text>();
        TotalAscendsCount = GameObject.Find("TotalAscendsCount").GetComponent<Text>();
        AscendRewardCount = GameObject.Find("AscendRewardCount").GetComponent<Text>();
    }
	
	void Update () {
        TotalTiksCount.text = score.ConvertToDisplayable(Convert.ToDouble(GV.allscore));
        TotalPlaytimeCount.text = FormatTime(GV.Playtime);
        TiksPerSecondCount.text = score.ConvertToDisplayable(GV.tiksPerSecond);
        GoldCubesTotalCount.text = score.ConvertToDisplayable(GV.GoldCubes);
        CubesClearedCount.text = score.ConvertToDisplayable(GV.LayersCleared);
        TotalAscendsCount.text = score.ConvertToDisplayable(GV.Ascends);
        AscendRewardCount.text = score.ConvertToDisplayable(GV.AscendReward);
    }

    string FormatTime(float Seconds)
    {
        int hours;
        int displayminutes;
        int minutes;

        string hourText;
        string minuteText;

        minutes = Convert.ToInt32(Seconds / 60);
        hours = minutes / 60;
        displayminutes = minutes - (hours * 60);
        
        if (hours < 10)
        {
            hourText = "0" + hours;
        }
        else
        {
            hourText = hours.ToString();
        }
        if (minutes < 10)
        {
            minuteText = "0" + minutes;
        }
        else
        {
            minuteText = displayminutes.ToString();
        }

        string output = hourText + ":" + minuteText;
        return output;
    }
}
