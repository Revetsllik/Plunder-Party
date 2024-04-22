using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPhysical : MonoBehaviour
{
    public bool canShoot1 = false;
    public bool canShoot2 = false;
    public bool canShoot3 = false;
    public bool canShoot4 = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player1")
        {
            canShoot1 = true;
            Destroy(this);
        }
        if (col.gameObject.tag == "Player2")
        {
            canShoot2 = true;
            Destroy(this);
        }
        if (col.gameObject.tag == "Player3")
        {
            canShoot3 = true;
            Destroy(this);
        }
        if (col.gameObject.tag == "Player4")
        {
            canShoot4 = true;
            Destroy(this);
        }
    }
}
