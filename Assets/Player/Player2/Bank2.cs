using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank2 : MonoBehaviour
{
    public TMP_Text bank2;
    public TMP_Text wallet2;

    PickupCoin2 pickupCoin2;

    void Start()
    {

    }

    void Update()
    {
        pickupCoin2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PickupCoin2>();

        int bankInt2 = Mathf.FloorToInt(pickupCoin2.bank);
        int walletInt2 = Mathf.FloorToInt(pickupCoin2.wallet);

        bank2.SetText($"{bankInt2}");
        wallet2.SetText($"{walletInt2}");
    }
}
