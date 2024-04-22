using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank3 : MonoBehaviour
{
    public TMP_Text bank3;
    public TMP_Text wallet3;

    PickupCoin3 pickupCoin3;

    void Start()
    {

    }

    void Update()
    {
        pickupCoin3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<PickupCoin3>();

        int bankInt3 = Mathf.FloorToInt(pickupCoin3.bank);
        int walletInt3 = Mathf.FloorToInt(pickupCoin3.wallet);

        bank3.SetText($"{bankInt3}");
        wallet3.SetText($"{walletInt3}");
    }
}
