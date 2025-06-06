using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float xRange = 22.0f;
    private float zRange = 11.0f;

    public animalInfo[] animalInformation;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

       InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);

    }
    // Update is called once per frame
    void Update()
    {
      
    }

    void SpawnRandomAnimal()
    { 
        int animalIndex = Random.Range(0, animalPrefabs.Length); Vector3 spawnPosition = new Vector3(Random.Range(-xRange, xRange), 0, Random.Range(zRange, -zRange));

        Destroy(Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0)), 10);

    }

    [System.Serializable]
    public struct animalInfo
    {
        public GameObject animaPrefab;
        public string animalName;
        public bool isHostile;
    }
}
