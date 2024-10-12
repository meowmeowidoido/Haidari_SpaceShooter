using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    public float speed = 1.5f;
    Vector3 enemyPosition;

    // Update is called once per frame
    Enemy enemy;
    

    void Start()
    {
       enemy = FindObjectOfType<Enemy>();
    }
    void FixedUpdate()
    {
        

        transform.position += transform.up * speed * Time.deltaTime;

        if (enemy != null)
        {
            enemyPosition = enemy.gameObject.transform.position;
            followEnemy();
        }
        
    }

   void followEnemy()
    {
      float distBetween=  Vector3.Distance(enemyPosition, transform.position);   

       if(distBetween < 5)
        {
            transform.position += (enemyPosition- transform.position) * speed * Time.deltaTime;
        }
       if(distBetween < 1)
        {
           Destroy(gameObject);
           Destroy(enemy.gameObject);
        }
        print(distBetween);
    
    }
   
}
