using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //setting the player moevement speed
    public float speed;

    //setting player lateral movement control
    public float horizontalInput;

    public float xRange = 21;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //input for lateral moevement control is 'A' and 'D'(only one player profile)
        horizontalInput = Input.GetAxis("Horizontal");

        //move along x axis     
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //Keep player in bounds(-xRange => Player <= xRange) exceeding boundaries will transform position to new
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}

   
