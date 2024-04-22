using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class cashInUi : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float fadeSpeed = 1f;
    public GameObject cashInPic;
    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    public AudioSource respawner;
    public AudioClip cashInSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CashFunction()
    {
        StartCoroutine(MoveAndFadeOut());
    }

    IEnumerator MoveAndFadeOut()
    {
        respawner.clip = cashInSound;
        respawner.Play();

        GameObject.FindGameObjectWithTag("CashIn1").transform.localScale = new Vector3(1, 1, 1);
        cashInPic.transform.position = new Vector3(-6.57f, 3.91f, 1);
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        Color startColor = spriteRenderer.color;
        float alpha = startColor.a;
        alpha = 1;
        while (alpha > 0f)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }



}
