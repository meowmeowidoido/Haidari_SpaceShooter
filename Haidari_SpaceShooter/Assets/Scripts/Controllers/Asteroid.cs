using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float maxFloatDistance = 2;
    public float arrivalDistance;
    public Vector3 randomPoint;
    public float speed = 0.1f;
    private void Start()
    {
        
        randomPoint= new Vector3(Random.Range(-20, 19), Random.Range(-11, 6));
    }
    private void Update()
    {
        
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {

        Vector3 direction = (randomPoint - transform.position) *Time.deltaTime;
        direction.Normalize();
        arrivalDistance = Vector3.Distance(transform.position, randomPoint);
        transform.position += direction* speed * Time.deltaTime;
        if (arrivalDistance < 1)
        {
            randomPoint = new Vector3(Random.Range(-20, 19), Random.Range(-11, 6));
 
        }


    }
}
