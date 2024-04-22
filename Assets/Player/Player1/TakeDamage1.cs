using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage1 : MonoBehaviour
{
    PlayerRespawnScript playerRespawnScript;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has the player tag
        if (other.CompareTag("Weapon2"))
        {
            print("Player 1 died!");
            KillPlayer1();
        }
        if (other.CompareTag("Weapon3"))
        {
            print("Player 1 died!");
            KillPlayer1();
        }
        if (other.CompareTag("Weapon4"))
        {
            print("Player 1 died!");
            KillPlayer1();
        }
        if (other.CompareTag("Bullet2"))
        {
            print("Player 1 died!");
            KillPlayer1();
        }
        if (other.CompareTag("Bullet3"))
        {
            print("Player 1 died!");
            KillPlayer1();
        }
        if (other.CompareTag("Bullet4"))
        {
            print("Player 1 died!");
            KillPlayer1();
        }
    }

    void KillPlayer1()
    {
        playerRespawnScript = GameObject.FindGameObjectWithTag("Respawn1").GetComponent<PlayerRespawnScript>();
        playerRespawnScript.hp = 0;
    }
}
