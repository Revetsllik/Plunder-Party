using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnScript3 : MonoBehaviour
{
    public float hp = 100f;
    public AudioSource respawner;
    public AudioClip deathSound, respawnSound;

    PickupCoin3 pickupCoin;

    public GameObject sword;
    [SerializeField] Animator anim;

    private void Update()
    {
        if (hp == 0f)
        {
            pickupCoin = GameObject.FindGameObjectWithTag("Player3").GetComponent<PickupCoin3>();
            pickupCoin.wallet = 0f;
            hp = 100f;
            StartCoroutine(RespawnPlayer());
        }
    }

    IEnumerator RespawnPlayer()
    {
        RespawnSounds();

        // Find the player object with the tag "Player1"
        GameObject player3 = GameObject.FindGameObjectWithTag("Player3");

        // Check if player1 is not null before performing operations
        if (player3 != null)
        {
            player3.SetActive(false);
            
            yield return new WaitForSeconds(5);
            player3.SetActive(true);
            sword.SetActive(false);
            anim.ResetTrigger("Attack");
            player3.transform.position = new Vector3(6.628076f, 3.254993f, -1);
            DeathSounds();
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

