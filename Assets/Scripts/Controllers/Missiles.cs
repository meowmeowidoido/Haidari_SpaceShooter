using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    public float speed =3f;
    Vector3 enemyPosition;

    // Update is called once per frame
    Enemy enemy;
    public Transform enemyTransform;
    

    void Start()
    {
       enemy = FindObjectOfType<Enemy>();
        if (enemy != null)
        {
            enemyTransform = enemy.transform;
        }

        }
        void FixedUpdate()
    {
        speed = 1.5f;

        transform.position += transform.up * speed * Time.deltaTime;

        if (enemy != null)
        {
            enemyPosition = enemy.gameObject.transform.position;
            enemyTransform.position = enemyPosition;
            FollowEnemy();
        }
        
    }

   void FollowEnemy()
    {
      float distBetween=  Vector3.Distance(enemyPosition, transform.position);   
       if(distBetween < 5)
        {
            Vector3 enemyDirection = (enemyPosition - transform.position).normalized;
            float enemyAngle;
            float missileAngle = transform.rotation.eulerAngles.z;
            float angleDifference;

            transform.position += enemyDirection * Time.deltaTime;
            enemyAngle = Mathf.Atan2(enemyDirection.y, enemyDirection.x) * Mathf.Rad2Deg - 90;

            enemyAngle = AngleStandardizing(enemyAngle);
            missileAngle = AngleStandardizing(missileAngle);

            angleDifference = enemyAngle - missileAngle;
            angleDifference = AngleStandardizing(angleDifference);
                if (missileAngle> enemyAngle)
                { 
                    transform.Rotate(0, 0, -angleDifference* -speed * Time.deltaTime);
                }
             
                
                   if (missileAngle < enemyAngle)
                    {
                        transform.Rotate(0, 0, angleDifference * speed * Time.deltaTime);
                    }
                
                
            }
            if (distBetween < 1)
        {
           Destroy(gameObject);
           Destroy(enemy.gameObject);
        }
    
    }
   float AngleStandardizing(float angle)
    {

        angle %= 360;

        if (angle > 180)
        {
           angle -= 360;
        }

        return angle;
    }

   
}
