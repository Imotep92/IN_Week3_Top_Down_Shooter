using UnityEngine;

public class destroyOutOfBounds : MonoBehaviour
{

    private float topBound = 30;
    private float lowerBound = -20;

    public float xRange = 30;
    public float zRange = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Boundary contraints
        if (transform.position.z > topBound)
            Destroy(gameObject);

        if (transform.position.z < lowerBound)
            Destroy(gameObject);

          

        //Keep player in bounds(-xRange => Player <= xRange) exceeding boundaries will transform position to new
        if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > xRange)
        {
            Destroy(gameObject);
        }

        //Keep player in bounds(-zRange => Player <= zRange) exceeding boundaries will transform position to new

        if (transform.position.z < -zRange)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > zRange)
        {
            Destroy(gameObject);
        }
        #endregion Boundary contraints 
    }
}
