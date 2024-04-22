using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class P1Bank : MonoBehaviour
{
    public TMP_Text bank;
    public TMP_Text wallet;
    PickupCoin pickupCoin;

    void Start()
    {
        
    }

    void Update()
    {
        pickupCoin = GameObject.FindGameObjectWithTag("Player1").GetComponent<PickupCoin>();

        int bankInt = Mathf.FloorToInt(pickupCoin.bank);
        int walletInt = Mathf.FloorToInt(pickupCoin.wallet);

        bank.SetText($"{bankInt}");
        wallet.SetText($"{walletInt}");
    }
}
