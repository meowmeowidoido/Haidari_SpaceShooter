using Codice.CM.WorkspaceServer.DataStore.Configuration;
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
    public float velocity = 0.03f;
   
    void Update()
    {
       float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftArrow))
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
        }
    }
    public void PlayerMovement()
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
    
}
