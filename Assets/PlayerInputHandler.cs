using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.LowLevel;

public class PlayerInputHandler : MonoBehaviour
{
    
    //names:
    //Player1
    //Player2
    [SerializeField] string player1Name;
    [SerializeField] string player2Name;
    [SerializeField] string player3Name;
    [SerializeField] string player4Name;

    [SerializeField] Vector3 playerSpawnPos1;
    [SerializeField] Vector3 playerSpawnPos2;
    [SerializeField] Vector3 playerSpawnPos3;
    [SerializeField] Vector3 playerSpawnPos4;



    public float shootCooldownSeconds;
    public float meleeCooldownSeconds;
    public float dashCooldownSeconds;

    Coroutine shootCooldownCorutine;
    bool canShoot = true;
    Player player;
    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    bool canDash = true;
    bool canMelee = true;
    Coroutine meleeCooldownCorutine;

    private void Start()
    {
        if(GameObject.Find(player3Name) && GameObject.Find(player2Name) && GameObject.Find(player1Name))
        {
            player = GameObject.Instantiate(prefabs[3], playerSpawnPos4, transform.rotation).GetComponent<Player>();
            return;

        }
        if (GameObject.Find(player2Name) && GameObject.Find(player1Name))
        {
            player = GameObject.Instantiate(prefabs[2], playerSpawnPos3, transform.rotation).GetComponent<Player>();
            return;
        }
        if (GameObject.Find(player1Name))
        {
            player = GameObject.Instantiate(prefabs[1], playerSpawnPos2, transform.rotation).GetComponent<Player>();
            return;
        }
        else
        {
            player = GameObject.Instantiate(prefabs[0], playerSpawnPos1, transform.rotation).GetComponent<Player>();
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        if(player)
        player.Move(context.ReadValue<Vector2>());
    }
    public void Shoot(InputAction.CallbackContext context)
    {
       if(player && context.started)
        {
           if(canShoot)
            {
                player.ShootBullet();
                shootCooldownCorutine = StartCoroutine(ShootCooldownTimer());
            }
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (player && context.started)
        {
            if (canDash)
            {
                player.GoDash();
                shootCooldownCorutine = StartCoroutine(DashCooldownTimer());
            }
        }
    }

    public void Melee(InputAction.CallbackContext context)
    {
        if (player && context.started)
        {
            if (canMelee == true)
            {
                player.MeleeAttack();
                meleeCooldownCorutine = StartCoroutine(MeleeCooldownTimer());
            }
        }
    }

    //WORKING SPACE

    //WORKING SPACE
    IEnumerator MeleeCooldownTimer()
    {
        canMelee = false;
        yield return new WaitForSeconds(meleeCooldownSeconds);
        canMelee = true;
    }
    IEnumerator ShootCooldownTimer()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldownSeconds);
        canShoot = true;
    }
    IEnumerator DashCooldownTimer()
    {
        canDash = false;
        yield return new WaitForSeconds(dashCooldownSeconds);
        canDash = true;
    }
}
