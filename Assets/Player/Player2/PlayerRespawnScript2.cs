using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnScript2 : MonoBehaviour
{
    public float hp = 100f;
    public AudioSource respawner;
    public AudioClip deathSound, respawnSound;

    PickupCoin2 pickupCoin;

    public GameObject sword;
    [SerializeField] Animator anim;
    private void Update()
    {
        if (hp == 0f)
        {
            pickupCoin = GameObject.FindGameObjectWithTag("Player2").GetComponent<PickupCoin2>();
            pickupCoin.wallet = 0f;
            hp = 100f;
            StartCoroutine(RespawnPlayer());
        }
    }

    IEnumerator RespawnPlayer()
    {
        RespawnSounds();

        // Find the player object with the tag "Player1"
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");

        // Check if player1 is not null before performing operations
        if (player2 != null)
        {
            player2.SetActive(false);
            
            yield return new WaitForSeconds(5);
            player2.SetActive(true);
         
            anim.ResetTrigger("Attack");
            player2.transform.position = new Vector3(-6.9f, -3.4f, -1);
            DeathSounds();

            yield return new WaitForSeconds(0.5f);
            sword.SetActive(false);
        }
    }

    void RespawnSounds()
    {
        respawner.clip = deathSound;
        respawner.Play();
    }

    void DeathSounds()
    {
        respawner.clip = respawnSound;
        respawner.Play();
    }
}

