using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupCollector : MonoBehaviour
{
    PowerupPhysical powerupPhysical;
    Player player;
    private void Start()
    {
        powerupPhysical = GameObject.FindGameObjectWithTag("PPP").GetComponent<PowerupPhysical>();
        player = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Player>();
    }
    private void Update()
    {
        if (powerupPhysical.canShoot1 == true)
        {
            player.canShootBullet = true;
        }
    }
}
