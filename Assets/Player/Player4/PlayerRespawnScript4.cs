using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnScript4 : MonoBehaviour
{
    public float hp = 100f;
    public AudioSource respawner;
    public AudioClip deathSound, respawnSound;

    PickupCoin4 pickupCoin;

    public GameObject sword;
    [SerializeField] Animator anim;

    private void Update()
    {
        if (hp == 0f)
        {
            pickupCoin = GameObject.FindGameObjectWithTag("Player4").GetComponent<PickupCoin4>();
            pickupCoin.wallet = 0f;
            hp = 100f;
            StartCoroutine(RespawnPlayer());
        }
    }

    IEnumerator RespawnPlayer()
    {
        RespawnSounds();

        // Find the player object with the tag "Player1"
        GameObject player4 = GameObject.FindGameObjectWithTag("Player4");

        // Check if player1 is not null before performing operations
        if (player4 != null)
        {
            player4.SetActive(false);
            
            yield return new WaitForSeconds(5);
            player4.SetActive(true);
            sword.SetActive(false);
            anim.ResetTrigger("Attack");
            player4.transform.position = new Vector3(6.678076f, -2.535007f, -1);
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

