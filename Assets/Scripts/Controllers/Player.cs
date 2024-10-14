using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Prefab and Transform variables
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject missile;

    //variables for the Player, initializing them 
    public float accelerationTime = 1f;
    public float decelerationTime = 1f;
    public float maxSpeed = 7.5f;
    public float turnSpeed = 180f;//Used for rotation speed
    public float playerRotation = 0f;

    private float acceleration;
    private float deceleration;
    private Vector3 currentVelocity;
    private float maxSpeedSqr;


    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
        maxSpeedSqr = maxSpeed * maxSpeed;
    }

    void Update()
    {
        //Player rotation is set to 0 so that they dont keep rotating when they let go of the key
        playerRotation = 0;
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HomingMissile();
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Using transform up to increment the way the ship move so it moves the player in front of them in WORLD space
            moveDirection += transform.up;
        }
            if (Input.GetKey(KeyCode.S))
            {
            //When the player presses S it moves the back but they still face the direction they were facing
            //Stored in player rotation variable
                moveDirection -= transform.up;
            }

            if (Input.GetKey(KeyCode.D))
            {

            //Used to rotate the player counter clockwise
            playerRotation -= turnSpeed;
            
        }

            if (Input.GetKey(KeyCode.A))
            {
            //Used to rotate the player clockwise and is stored in playerRotation variable
            playerRotation = turnSpeed;
            
            }
      
            if (moveDirection.sqrMagnitude > 0)
            {
                currentVelocity += Time.deltaTime * acceleration * moveDirection;
                if (currentVelocity.sqrMagnitude > maxSpeedSqr)
                {
                    currentVelocity = currentVelocity.normalized * maxSpeed;
                }
            }
            else
            {
                Vector3 velocityDelta = Time.deltaTime * deceleration * currentVelocity.normalized;
                if (velocityDelta.sqrMagnitude > currentVelocity.sqrMagnitude)
                {
                    currentVelocity = Vector3.zero;
                }
                else
                {
                    currentVelocity -= velocityDelta;
                }
            }

          transform.position += currentVelocity * Time.deltaTime;
        //when player presses A or D they begin to rotate to the respective direction
        // playerRotation in the Z axis.
          transform.Rotate(0, 0, playerRotation * Time.deltaTime);
      
        
        }

   public void HomingMissile()
    {
      Instantiate(missile, transform.position, transform.rotation);
    }
    }

