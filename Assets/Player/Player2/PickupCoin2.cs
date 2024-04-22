using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupCoin2 : MonoBehaviour
{
    public float wallet;
    public float bank;
    public float startRamp;
    bool isStandingOnTreasure;

    cashInUi2 cashInScript;

    public Text p1bank;
    public Text p1wallet;

    public GameObject signText;

    //Sounds
    public AudioSource audioPlayer;
    public AudioClip moneyCollect;

    void Start()
    {
        wallet = 0f;
        isStandingOnTreasure = false;

        cashInScript = GameObject.FindGameObjectWithTag("CashIn2").GetComponent<cashInUi2>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            isStandingOnTreasure = true;

            audioPlayer.clip = moneyCollect;
            audioPlayer.Play();
        }
        if (col.gameObject.CompareTag("Base2"))
        {
            if (wallet > 0f)
            {
                bank += wallet;
                wallet = 0f;

                cashInScript.CashFunction();
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            isStandingOnTreasure = false;

            audioPlayer.clip = moneyCollect;
            audioPlayer.Stop();
        }
    }

    void Update()
    {
        if (isStandingOnTreasure == false)
        {
            startRamp = 0f;
        }
        if (isStandingOnTreasure == true)
        {
            wallet += 15 * Time.deltaTime;
            startRamp += Time.deltaTime;
            if (startRamp > 2f)
            {
                wallet += 1.5f * Time.deltaTime;
            }

            if (startRamp > 4f)
            {
                wallet += 2f * Time.deltaTime;
            }

            if (startRamp > 6f)
            {
                wallet += 3f * Time.deltaTime;
            }
        }
    }
}
