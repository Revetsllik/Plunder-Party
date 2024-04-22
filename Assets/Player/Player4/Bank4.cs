using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank4 : MonoBehaviour
{
    public TMP_Text bank4;
    public TMP_Text wallet4;

    PickupCoin4 pickupCoin4;

    void Start()
    {

    }

    void Update()
    {
        pickupCoin4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<PickupCoin4>();

        int bankInt4 = Mathf.FloorToInt(pickupCoin4.bank);
        int walletInt4 = Mathf.FloorToInt(pickupCoin4.wallet);

        bank4.SetText($"{bankInt4}");
        wallet4.SetText($"{walletInt4}");
    }
}
