using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    public float speed =5f; //intializing speed of missile

    // Update is called once per frame
    Enemy enemy; //Calling the enmmy script
    

    void Start()
    {
       //finds all objects with the script type of Enemy when Missile is instantiated
       enemy = FindObjectOfType<Enemy>();
     

        }
        void FixedUpdate()
    {
       
        //Transform.position += transform.up (goes in the direction it was shot in).
        //Using transform.position += transform.position increments it in all axis causing it to go off screen
        transform.position += transform.up * speed * Time.deltaTime;

        if (enemy != null)//Ensures code does not run if enemy does not exist
        {
           
            FollowEnemy();//calls followenemy script
        }
        
    }

    void FollowEnemy()
    {
        //calculates distance between missile and enemy
        float distBetween = Vector3.Distance(enemy.transform.position, transform.position);
        if (distBetween < 5)//if distance less than 5 begin to track enemy
        {
            //direction from player to enemy.
            Vector3 enemyDirection = (enemy.transform.position - transform.position).normalized;
            float angleToEnemy;
            float missileAngle = transform.rotation.eulerAngles.z;
            float angleDifference;

            //added direction to the missile so it follows enemy
            transform.position += enemyDirection * Time.deltaTime;

            //getting angle to enemy by using atan2. converting it to degrees 
            //I wanted to see how atan2 could be used and instead I could just use eulerangles.z for the enemy angle
            angleToEnemy= Mathf.Atan2(enemyDirection.y, enemyDirection.x) * Mathf.Rad2Deg - 90;

            //Standardizing the angle of the missile and angle to the enemy
           angleToEnemy = AngleStandardizing(angleToEnemy);
            missileAngle = AngleStandardizing(missileAngle);

            //subtracting the angle TO The enemy by the missiles current angle
            angleDifference = angleToEnemy - missileAngle;
            //standardizing the angle difference
            angleDifference = AngleStandardizing(angleDifference);


            if (missileAngle > angleToEnemy)//if the missiles angle is greater than the angle to the enemy 
            {
                transform.Rotate(0, 0, -angleDifference * -speed * Time.deltaTime);//rotate counter clockwise
            }


            if (missileAngle < angleToEnemy)//less than angle to enemy then rotate clockwise
            {
                transform.Rotate(0, 0, angleDifference * speed * Time.deltaTime);
            }


        }
        if (distBetween < 1)
        {
            //destroys missile and enemy game object after they come in contact.
            Destroy(gameObject);
            Destroy(enemy.gameObject);
        }
    }
   float AngleStandardizing(float angle)
    {
        //used the same code for standardizing in class
        angle %= 360;
        if (angle > 180)
        {
           angle -= 360;
        }
        return angle;
    }

   
}
