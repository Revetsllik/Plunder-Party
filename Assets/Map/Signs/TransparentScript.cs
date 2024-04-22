using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentSign : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public string playerTag1 = "Player1";
    public string playerTag2 = "Player2";
    public string playerTag3 = "Player3";
    public string playerTag4 = "Player4";

    public float targetTransparency = 0.5f;
    public float fadeDuration = 1.0f;
    private bool isTransparent = false;

    void Start()
    {
        // Get the SpriteRenderer component of the object
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag1))
        {
            StartCoroutine(FadeToTransparency(targetTransparency, fadeDuration));
        }
        if (other.CompareTag(playerTag2))
        {
            StartCoroutine(FadeToTransparency(targetTransparency, fadeDuration));
        }
        if (other.CompareTag(playerTag3))
        {
            StartCoroutine(FadeToTransparency(targetTransparency, fadeDuration));
        }
        if (other.CompareTag(playerTag4))
        {
            StartCoroutine(FadeToTransparency(targetTransparency, fadeDuration));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag1))
        {
            StartCoroutine(FadeToTransparency(1f, fadeDuration));
        }
        if (other.CompareTag(playerTag2))
        {
            StartCoroutine(FadeToTransparency(1f, fadeDuration));
        }
        if (other.CompareTag(playerTag3))
        {
            StartCoroutine(FadeToTransparency(1f, fadeDuration));
        }
        if (other.CompareTag(playerTag4))
        {
            StartCoroutine(FadeToTransparency(1f, fadeDuration));
        }
    }

    IEnumerator FadeToTransparency(float targetAlpha, float duration)
    {
        //Original alpha value
        float startAlpha = spriteRenderer.color.a;

        //Calculate the alpha change per second
        float alphaChangePerSecond = (targetAlpha - startAlpha) / duration;

        //Fade to the target alpha over time
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            //Calculate the new alpha value for this frame
            float newAlpha = startAlpha + (alphaChangePerSecond * elapsedTime);

            //Update the sprite renderers color
            Color newColor = spriteRenderer.color;
            newColor.a = newAlpha;
            spriteRenderer.color = newColor;

            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the target alpha is reached exactly
        Color finalColor = spriteRenderer.color;
        finalColor.a = targetAlpha;
        spriteRenderer.color = finalColor;
        isTransparent = targetAlpha < 1f;
    }
}
