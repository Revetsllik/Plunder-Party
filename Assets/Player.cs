using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lookSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] public GameObject currentBulletPrefab;
    [SerializeField] public GameObject[] bulletPrefab;
    Vector2 moveValue;
    Vector2 lookValue;

    public Transform spawnPos;

    public int maxHealth;
    public int currentHealth;

    
    [SerializeField] string player1Name;
    [SerializeField] string player2Name;
    [SerializeField] string player3Name;
    [SerializeField] string player4Name;

    [SerializeField] Animator anim;
    [SerializeField] float damage;

    public string playerTag1 = "Player1";
    public string playerTag2 = "Player2";
    public string playerTag3 = "Player3";
    public string playerTag4 = "Player4";

    public bool canShootBullet = false;
    public Rigidbody2D rb;

    public void Start()
    {
        currentHealth = maxHealth;
        currentBulletPrefab = bulletPrefab[0];
    }
    public void Move(Vector2 value)
    {
       moveValue = value;
    }



    void Update()
    {
        if(isDashing == true)
        {
            canDash = false;
        }
        // Calculate movement direction
        Vector3 moveDirection = new Vector3(moveValue.x, moveValue.y, 0).normalized;

        // If there's movement input, rotate the character to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            // Calculate the angle between the movement direction and the right vector (1,0)
            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

            // Smoothly rotate towards the target angle
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Move the character
        transform.position += moveDirection * speed * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        transform.Rotate(lookValue * lookSpeed * Time.deltaTime);
    }
    public void ShootBullet()
    {
        print("Bang!");
        if(canShootBullet == true)
        {
            print("Bullet Fired!");
            GameObject.Instantiate(currentBulletPrefab, spawnPos.transform.position, transform.rotation);
            canShootBullet = false;
        }
    }

    public void MeleeAttack()
    {
        print("Hussah!");
        anim.SetTrigger("Attack");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PPP")
        {
            print("Touched Bullet");
            canShootBullet = true;
            Destroy(other.gameObject);
        }
    }
    public void GoDash()
    {
        print(gameObject.name + " is Trying to dash");
        StartCoroutine(Dash());
    }

    bool canDash = true;
    bool isDashing;

    public float dashSpeed = 6.5f;
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.AddForce(transform.forward * dashSpeed);
        yield return new WaitForSeconds(0.13f);
        isDashing = false;
        yield return new WaitForSeconds(6);
        canDash = true;
    }
}
