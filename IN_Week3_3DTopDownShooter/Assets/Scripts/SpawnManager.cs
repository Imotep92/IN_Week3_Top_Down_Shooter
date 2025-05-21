using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;


    // OLD CODE
    /* private float spawnRangeX = 20.0f;
       private float spawnPosZ = 20.0f;
       */

    private float xRange = 25.0f;
    private float zRange = 15.0f;

    public animalInfo[] animalInformation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //OLD CODE
        /* if (Input.GetKeyDown(KeyCode.L))
          {

              //randomly spawn animal index and spawn position
              Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

              int animalIndex = Random.Range(0, animalPrefabs.Length);

              Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
          }*/



        if (Input.GetKeyDown(KeyCode.L))
        {

            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-xRange, xRange), 0, Random.Range(zRange, -zRange));
            Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }

    [System.Serializable]
    public struct animalInfo
    {
        public GameObject animaPrefab;
        public string animalName;
        public bool isHostile;
    }
}
