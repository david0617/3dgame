 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScenes : MonoBehaviour
{
    static public int timeRM, timeRS, pointS;
    public int timerM, timerS, point;
    static public bool gameOver = true;
    public bool gameover;

    void Start()
    {
        gameover = gameOver;
        timerM = timeRM;
        timerS = timeRS;
        point = pointS;
        print("M " + timerM);
        print("S " + timerS);
        print("point " + point);
    }
    void Update()
    {

    }

    public void next()
    {
        Pointdisplay Pointdisplay = GameObject.Find("player").GetComponent<Pointdisplay>();
        Timer timer = GameObject.Find("player").GetComponent<Timer>();
        PlayerHealth PH = GameObject.Find("player").GetComponent<PlayerHealth>();
        if(PH.currenthealth == 0) gameOver = true;
        timeRM = timer.timeM;
        timeRS = timer.timeS;
        pointS = Pointdisplay.point;
    }
}
