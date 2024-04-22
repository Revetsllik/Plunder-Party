using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage2 : MonoBehaviour
{
    PlayerRespawnScript2 playerRespawnScript2;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has the player tag
        if (other.CompareTag("Weapon1"))
        {
            print("Player 2 died!");
            KillPlayer2();
        }
        if (other.CompareTag("Weapon3"))
        {
            print("Player 2 died!");
            KillPlayer2();
        }
        if (other.CompareTag("Weapon4"))
        {
            print("Player 2 died!");
            KillPlayer2();
        }

        if (other.CompareTag("Bullet1"))
        {
            print("Player 2 died!");
            KillPlayer2();
        }
        if (other.CompareTag("Bullet3"))
        {
            print("Player 2 died!");
            KillPlayer2();
        }
        if (other.CompareTag("Bullet4"))
        {
            print("Player 2 died!");
            KillPlayer2();
        }
    }
    void KillPlayer2()
    {
        playerRespawnScript2 = GameObject.FindGameObjectWithTag("Respawn2").GetComponent<PlayerRespawnScript2>();
        playerRespawnScript2.hp = 0;
    }
}
