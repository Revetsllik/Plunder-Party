using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignStats : MonoBehaviour
{
    PickupCoin pickupCoin;
    public TMP_Text p1bank;
    public TMP_Text p1wallet;

    void Start()
    {
        pickupCoin = GameObject.FindGameObjectWithTag("SignTyper").GetComponent<PickupCoin>();
    }

    void Update()
    {
        int bankInt = Mathf.FloorToInt(pickupCoin.bank);
        int walletInt = Mathf.FloorToInt(pickupCoin.wallet);

        p1bank.SetText($"{bankInt}");
        p1wallet.SetText($"{walletInt}");
    }
}
