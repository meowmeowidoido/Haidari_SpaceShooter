using Codice.CM.WorkspaceServer.DataStore.Configuration;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public bool moveLeft=false;
    public bool moveUp = false;
    public bool moveRight = false;
    public bool moveDown = false;
    public float acceleration = 0f;
    public bool keyLetGo = false;

   
    void Update()
    {
        print(acceleration);
        Vector3 offset = Vector3.zero;
        if (keyLetGo == false && acceleration<10)
        {
            acceleration += acceleration * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            keyLetGo = false;

            
            offset += Vector3.left * acceleration * Time.deltaTime;

            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            keyLetGo = false;

            
            offset += Vector3.right * acceleration * Time.deltaTime; ;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            keyLetGo = false;

          
            offset += Vector3.up *acceleration * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow)) 
        {
            keyLetGo = false;
            
            offset += Vector3.down * acceleration * Time.deltaTime;
            

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {

            keyLetGo = true;
        }

        if (keyLetGo == true && acceleration>3)
        {
            if (acceleration > 0)
            {
               
                acceleration-= acceleration * Time.deltaTime;
               // offset += Vector3.zero * acceleration * Time.deltaTime;
               // transform.position += transform.position * acceleration * Time.deltaTime;
            }

        }
        PlayerMovement1(offset);

        //Own Solution
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft =true;
            PlayerMovement();
            
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveUp = true;
            PlayerMovement();

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDown = true;
            PlayerMovement();

        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            moveRight = true;
            PlayerMovement();

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveLeft = false;
            moveUp = false;
            moveDown = false;
            moveRight = false;
        }*/
        /* public void PlayerMovement()
   {
       if (moveLeft == true)
       {
           transform.position = new Vector3(transform.position.x - velocity, transform.position.y);
       }
       if (moveUp == true)
       {

           transform.position = new Vector3(transform.position.x, transform.position.y + velocity);
       }
       if(moveDown == true)
       {
           transform.position = new Vector3(transform.position.x, transform.position.y - velocity);

       }
       if (moveRight==true)
       {
           transform.position = new Vector3(transform.position.x + velocity, transform.position.y);

       }
   }
   */
    }

    public void PlayerMovement1(Vector3 offset)
    {
        transform.position += offset;


    }
}
