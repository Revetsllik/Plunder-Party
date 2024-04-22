using System.Collections;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    bool canSpawn = true;
    public GameObject bulletPowerup;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnBullet());
        }
    }

    IEnumerator SpawnBullet()
    {
        canSpawn = false;
        yield return new WaitForSeconds(5);

        // Generate random coordinates within the defined range
        Vector2 spawnPosition = GetValidSpawnPosition();

        // Instantiate bulletPowerup at the random coordinates
        Instantiate(bulletPowerup, spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(5);
        canSpawn = true;
    }

    Vector2 GetValidSpawnPosition()
    {
        bool validPosition = false;
        Vector2 spawnPosition = Vector2.zero;

        while (!validPosition)
        {
            // Generate random coordinates within the defined range
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            spawnPosition = new Vector2(randomX, randomY);

            // Check if the spawn position intersects with any colliders tagged as "walls"
            Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPosition, Vector2.one, 0);
            bool intersectsWall = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Wall"))
                {
                    intersectsWall = true;
                    break;
                }
            }

            // If the spawn position doesn't intersect with any walls, it's valid
            if (!intersectsWall)
            {
                validPosition = true;
            }
        }

        return spawnPosition;
    }
}