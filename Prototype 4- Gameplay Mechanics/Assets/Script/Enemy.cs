using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;//Speed of the enemy
    private Rigidbody enemyRb;//Rigidbody of the enemy
    private GameObject player;//Access the player
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();//To access the component rigid body from the player
        player = GameObject.Find("Player");//To access the player from the hierarchy
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the direction to go to the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);//Adding force according to the direction that we get and apply speed

        //If the enemy exits the boundary it will destroy
        if (transform.position.y < -10) 
        {
            Destroy(gameObject);
        }
    }
}
