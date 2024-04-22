using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage4 : MonoBehaviour
{
    PlayerRespawnScript4 playerRespawnScript4;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has the player tag
        if (other.CompareTag("Weapon1"))
        {
            print("Player 4 died!");
            KillPlayer4();
        }
        if (other.CompareTag("Weapon2"))
        {
            print("Player 4 died!");
            KillPlayer4();
        }
        if (other.CompareTag("Weapon3"))
        {
            print("Player 4 died!");
            KillPlayer4();
        }
        if (other.CompareTag("Bullet1"))
        {
            print("Player 2 died!");
            KillPlayer4();
        }
        if (other.CompareTag("Bullet2"))
        {
            print("Player 2 died!");
            KillPlayer4();
        }
        if (other.CompareTag("Bullet3"))
        {
            print("Player 2 died!");
            KillPlayer4();
        }
    }
    void KillPlayer4()
    {
        playerRespawnScript4 = GameObject.FindGameObjectWithTag("Respawn4").GetComponent<PlayerRespawnScript4>();
        playerRespawnScript4.hp = 0;
    }
}
