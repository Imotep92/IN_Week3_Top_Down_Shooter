using UnityEngine;

public class projectileMovement : MonoBehaviour
{

    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //only tag.enemy gets destroyed
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject.Find("Hayley_Bales").GetComponent<playerController>().score++;
            Debug.Log(GameObject.Find("Hayley_Bales").GetComponent<playerController>().score);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        //only tag.Chicken gets destroyed
        if (other.gameObject.CompareTag("Chicken"))
        {
            GameObject.Find("Hayley_Bales").GetComponent<playerController>().lives--;
            Debug.Log(GameObject.Find("Hayley_Bales").GetComponent<playerController>().lives);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }

    }
