using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerRespawnScript : MonoBehaviour
{
    public float hp = 100f;
    public AudioSource respawner;
    public AudioClip deathSound, respawnSound;

    PickupCoin pickupCoin;

    public GameObject sword;
    [SerializeField] Animator anim;

    private void Update()
    {

        if (hp == 0f)
        {
            pickupCoin = GameObject.FindGameObjectWithTag("Player1").GetComponent<PickupCoin>();
            pickupCoin.wallet = 0f;
            hp = 100f;
            StartCoroutine(RespawnPlayer());
        }
    }

    IEnumerator RespawnPlayer()
    {
        RespawnSounds();

        // Find the player object with the tag "Player1"
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");

        // Check if player1 is not null before performing operations
        if (player1 != null)
        {
            
            player1.SetActive(false);

            yield return new WaitForSeconds(5);
            player1.SetActive(true);

            anim.ResetTrigger("Attack");
            player1.transform.position = new Vector3(-7f, 3.394993f, -1);
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

