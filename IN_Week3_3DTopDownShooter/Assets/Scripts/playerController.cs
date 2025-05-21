using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float forwardInput;
    public float rotationSpeed = 450.0f;

    public float xRange = 21;
    public float zRange = 13;

    public GameObject projectilePrefab;
    public Vector3 spawnOffset;
    

    // Update is called once per frame
    void Update()
    {

        #region Player Movement

        //input for lateral and vertical movement control is 'WASD''(only one player profile)
        horizontalInput = Input.GetAxisRaw("Horizontal");  
        forwardInput = Input.GetAxisRaw("Vertical");

        //move along x and z axis at the same speed
        Vector3 moveDirection = new Vector3(horizontalInput, 0, forwardInput).normalized;

        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero)
        {

            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        #endregion Player Movement

        //shooting mechanic

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from where player is facing
            Destroy(Instantiate(projectilePrefab, transform.position + spawnOffset, Quaternion.LookRotation(transform.forward)), 5);
        }


        #region Boundary contraints 

        //Keep player in bounds(-xRange => Player <= xRange) exceeding boundaries will transform position to new
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Keep player in bounds(-zRange => Player <= zRange) exceeding boundaries will transform position to new

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        #endregion Boundary contraints 


    }

}