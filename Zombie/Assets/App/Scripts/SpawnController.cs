using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;  
    

    private float spawnRate = 5.0f;
    private float waveCount = 0.0f;

    void Start()
     {
        InvokeRepeating("SpawnZombie", 0, spawnRate);
     }

     private void SpawnZombie()
     {
        var zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        waveCount++;

        

        
     }
}