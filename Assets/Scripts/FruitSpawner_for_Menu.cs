using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner_for_Menu : MonoBehaviour
{
    public GameObject[] fruitPrefabs; // Array of fruit prefabs
    public float spawnDelay = 1f; // Delay between spawns
    public float minVelocity = 5f; // Minimum velocity
    public float maxVelocity = 10f; // Maximum velocity
    public float minAngle = 30f; // Minimum angle
    public float maxAngle = 60f; // Maximum angle

    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            // Randomly select a fruit prefab
            GameObject fruitPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

            // Instantiate the fruit at the spawner's position
            GameObject fruit = Instantiate(fruitPrefab, transform.position, Quaternion.identity);

            // Set the sorting layer order to 0
            SpriteRenderer spriteRenderer = fruit.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = 0;
            }

            // Randomize the velocity within the specified range
            float randomVelocity = Random.Range(minVelocity, maxVelocity);

            // Randomize the angle within the specified range and calculate the direction vector
            float randomAngle = Random.Range(minAngle, maxAngle);
            Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

            // Apply the calculated velocity and direction to the fruit
            Rigidbody2D rb = fruit.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * randomVelocity;
            }
        }
    }
}
