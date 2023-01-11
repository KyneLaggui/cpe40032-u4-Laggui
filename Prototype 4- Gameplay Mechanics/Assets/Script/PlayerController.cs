using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;//Rigidbody of the player
    private GameObject focalPoint;//To get the center of the camera to the player
    private float powerUpStrength = 10.0f;//The strength of the ball when it pickups the powerup
    public float speed = 5.0f;//Speed of the player
    public bool hasPowerup = false;//Boolean expression for the powerup
    public GameObject powerupIndicator;//To access the game object to indicate the power up

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();//To access the rigid body
        focalPoint = GameObject.Find("Focal Point");//To find or access the focal point in the hierarchy
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");//Access the Vertical input from the player
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);//To add movement with force
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f , 0);//To follow the player when it picksup the powerup
    }
    private void OnTriggerEnter(Collider other)//OnTriggerEnter is called when the Collider other enters the trigger
    {

        if (other.CompareTag("Powerup"))//If the player touches the tag Powerup, the line of codes below will activate
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }

    }
    IEnumerator PowerupCountdownRoutine()//Built in method that we can add timer 
    {
        yield return new WaitForSeconds(7);//When the player collides with the powerup, it will wait 7 seconds to do the other codes below
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)//OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
    {   //this if statement if the player has power up and collided with the player the line of code below will run
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();//Rigidbody of the enemy
            Vector3 awayfromPlayer = collision.gameObject.transform.position - transform.position;//Get the direction away from the player
            //Force mode Impulse- to instantly apply it
            enemyRigidbody.AddForce(awayfromPlayer * powerUpStrength, ForceMode.Impulse);//Add force to the enemy
            //Message when you collide with the enemy and has a powerup
            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
