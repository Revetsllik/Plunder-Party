using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
public class Timer : MonoBehaviour
{
    public float timeLeft;
    bool timerOff;
    public bool timerOn = false;

    public TMP_Text timerTxt;
    public TMP_Text winnerTxt;

    PickupCoin p1;
    PickupCoin2 p2;
    PickupCoin3 p3;
    PickupCoin4 p4;

    float b1;
    float b2;
    float b3;
    float b4;
 

    void Start()
    {
        timerOn = true;
        timerOff = false;
    }

    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timerOn = false;

                timerOff = true;
                if (timerOff == true)
                {
                    p1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PickupCoin>();
                    b1 = p1.bank;

                    p2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PickupCoin2>();
                    b2 = p2.bank;

                    if (GameObject.FindGameObjectWithTag("Player3") != null)
                    {
                        p3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<PickupCoin3>();
                        b3 = p3.bank;
                    }

                    if (GameObject.FindGameObjectWithTag("Player4") != null)
                    {
                        p4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<PickupCoin4>();
                        b4 = p4.bank;
                    }

                    //DetectRed
                    if(b1 > b2)
                    {
                        if (b1 > b3)
                        {
                            if (b1 > b4)
                            {
                                //Red wins
                                print("Red won");
                                winnerTxt.text = string.Format("Red Wins!");
                            }
                        }

                    }
                    //DetectGreen
                    if (b2 > b1)
                    {
                        if (b2 > b3)
                        {
                            if (b2 > b4)
                            {
                                //Green wins
                                winnerTxt.text = string.Format("Green Wins!");
                            }
                        }

                    }
                    //DetectBlue
                    if (b3 > b1)
                    {
                        if (b3 > b2)
                        {
                            if (b3 > b4)
                            {
                                //Blue wins
                                winnerTxt.text = string.Format("Blue Wins!");
                            }
                        }

                    }
                    //DetectPink
                    if (b4 > b1)
                    {
                        if (b4 > b2)
                        {
                            if (b4 > b3)
                            {
                                //Pink wins
                                winnerTxt.text = string.Format("Pink Wins!");
                            }
                        }

                    }
                }
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
