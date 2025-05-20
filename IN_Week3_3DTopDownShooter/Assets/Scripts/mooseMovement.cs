using UnityEngine;

public class mooseMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float xRange = 23;
    //public float zRange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //move along x and z axis at the same speed

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //Keep Moose in bounds(-xRange => Moose <= xRange) exceeding boundaries will transform position to new
        if (transform.position.x < -xRange)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }   
}
