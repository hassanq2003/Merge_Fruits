using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform nextSpawnPoint;
    [SerializeField] private Transform clampPoint1; 
    [SerializeField] private Transform clampPoint2; 

    [SerializeField] private float spawnDelay = .2f; 


    private GameObject currentFruit;
    private GameObject nextFruit;
    private bool isSpawning = false;

    void Start()
    {
        SpawnNextFruit();
        SpawnFruit();
    }

    void Update()
    {
        if(FindObjectOfType<PowerUpScript>().isPowerUpSelected==false)
        {
        if (Input.GetMouseButtonDown(0) && !isSpawning)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0;

            
            
            if(mousePosition.x>=clampPoint1.transform.position.x &&mousePosition.x<=clampPoint2.transform.position.x)
            {
            if (currentFruit != null)
            {
                 
                Vector3 fruitPosition = currentFruit.transform.position;
                currentFruit.transform.position = new Vector3(mousePosition.x, fruitPosition.y, fruitPosition.z);

                Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
            }

            StartCoroutine(SpawnNextFruitAfterDelay(spawnDelay));
            }
        }
        }
    }

    IEnumerator SpawnNextFruitAfterDelay(float delay)
    {
        isSpawning = true;
        yield return new WaitForSeconds(delay);
        SpawnFruit();
        isSpawning = false;
    }

    void SpawnFruit()
    {
        currentFruit = nextFruit;
        currentFruit.transform.position = spawnPoint.position;
        SpawnNextFruit();
        
    }
    void SpawnNextFruit()
    {
        int randomIndex = Random.Range(0, fruitPrefabs.Length);
        nextFruit = Instantiate(fruitPrefabs[randomIndex], nextSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = nextFruit.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    
}
