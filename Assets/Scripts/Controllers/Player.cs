using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject missile;

    public float accelerationTime = 1f;
    public float decelerationTime = 1f;
    public float maxSpeed = 7.5f;
    public float turnSpeed = 180f;
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
        playerRotation = 0;
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            homingMissile();
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.up;
        }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection -= transform.up;
            }

            if (Input.GetKey(KeyCode.D))
            {
           
                playerRotation -= turnSpeed  * Time.deltaTime;
            
        }

            if (Input.GetKey(KeyCode.A))
            {
            
                playerRotation = turnSpeed * Time.deltaTime;
            
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
            transform.Rotate(0, 0, playerRotation);
        }

   public void homingMissile()
    {
      Instantiate(missile, transform.position, transform.rotation);
    }
    }

