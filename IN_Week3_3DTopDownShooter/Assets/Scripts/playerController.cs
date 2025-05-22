using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerController : MonoBehaviour
{
    #region player speed, inputs, contraints and lives
    private float speed = 10.0f;
    private float rotationSpeed = 450.0f;
   
    private float horizontalInput;
    private float forwardInput;
    
    private float xRange = 21;
    private float zRange = 13;

    public int lives = 3;
    public int maxLives;
    public TMP_Text livesText;
    #endregion player speed, inputs, contraints and lives

    public GameObject projectilePrefab;
    public Vector3 spawnOffset;

   
    public int score;
    public TMP_Text scoreText;

    void Start()
    {
        maxLives = lives;
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score: " + score;

        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            Debug.Log("GameOver");
            Destroy(gameObject);
        }

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

        //pause

       /* if (Input.GetKeyDown(KeyCode.P))
        {
            // pause menu scene 0
            SceneManager.LoadScene(0);
        }*/

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