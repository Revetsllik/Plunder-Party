using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage3 : MonoBehaviour
{
    PlayerRespawnScript3 playerRespawnScript3;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has the player tag
        if (other.CompareTag("Weapon1"))
        {
            print("Player 3 died!");
            KillPlayer3();
        }
        if (other.CompareTag("Weapon2"))
        {
            print("Player 3 died!");
            KillPlayer3();
        }
        if (other.CompareTag("Weapon4"))
        {
            print("Player 3 died!");
            KillPlayer3();
        }
        if (other.CompareTag("Bullet1"))
        {
            print("Player 2 died!");
            KillPlayer3();
        }
        if (other.CompareTag("Bullet2"))
        {
            print("Player 2 died!");
            KillPlayer3();
        }
        if (other.CompareTag("Bullet4"))
        {
            print("Player 2 died!");
            KillPlayer3();
        }
    }
    void KillPlayer3()
    {
        playerRespawnScript3 = GameObject.FindGameObjectWithTag("Respawn3").GetComponent<PlayerRespawnScript3>();
        playerRespawnScript3.hp = 0;
    }
}
