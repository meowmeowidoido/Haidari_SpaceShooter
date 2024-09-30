using Codice.CM.WorkspaceServer.DataStore.Configuration;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    /* public bool moveLeft=false;
     public bool moveUp = false;
     public bool moveRight = false;
     public bool moveDown = false;*/
    public float acceleration = 2f;
    public bool keyLetGo = false;
    public bool keyUp1 = false;
    public bool keyDown2 = false;
    public bool keyLeft3 = false;
    public bool keyRight4 = false;
    public float radius = 3;
    public int currentIndex = 0;
    public GameObject powerUp;
    void Start()
    {



    }

    void Update()
    {
        EnemyRadar(radius, 0);
        Vector3 offset = Vector3.zero;
        if (keyLetGo == false && acceleration < 10)
        {
            keyDown2 = false;
            keyRight4 = false;
            keyUp1 = false;
            keyLeft3 = false;
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

            offset += Vector3.up * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            keyLetGo = false;
            offset += Vector3.down * acceleration * Time.deltaTime;


        }


        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            keyLetGo = true;
            keyLeft3 = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            keyLetGo = true;

            keyRight4 = true;

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            keyLetGo = true;
            keyUp1 = true;

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            keyLetGo = true;
            keyDown2 = true;
        }

        if (keyRight4 == true)
        {
            if (acceleration > 2)
            {
                acceleration -= acceleration * Time.deltaTime;
                transform.position += Vector3.right * acceleration * Time.deltaTime;
            }
        }
        if (keyLeft3 == true)
        {
            if (acceleration > 2)
            {
                acceleration -= acceleration * Time.deltaTime;
                transform.position += Vector3.left * acceleration * Time.deltaTime;
            }
        }
        if (keyDown2 == true)
        {
            if (acceleration > 2)
            {
                acceleration -= acceleration * Time.deltaTime;
                transform.position += Vector3.down * acceleration * Time.deltaTime;
            }
        }
        if (keyUp1 == true)
        {
            if (acceleration > 2)
            {
                acceleration -= acceleration * Time.deltaTime;
                transform.position += Vector3.up * acceleration * Time.deltaTime;
            }

        }

        PlayerMovement1(offset);
        EnemyMovement();

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPowerUps(4, 6);
        }
    }

    public void PlayerMovement1(Vector3 offset)
    {
        transform.position += offset;


    }

    public void EnemyMovement()
    {
        float playerEnemyDist = Vector3.Distance(enemyTransform.position, transform.position);
        float enemySpeed = 2f;
      //  print(playerEnemyDist);

        if (playerEnemyDist < 8f)
        {
            enemyTransform.position += (transform.position - enemyTransform.position) * enemySpeed * Time.deltaTime;
        }
        if (playerEnemyDist < 1)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        radius = 3;
        circlePoints = 6;
        float incrementAngle = 360f / circlePoints;
        float enemyDist = Vector3.Distance(enemyTransform.position, transform.position);

        Vector3 firstPoint = transform.position + new Vector3(Mathf.Cos(0) * radius, Mathf.Sin(0) * radius);

        Color detectorColor = Color.green;

        if(enemyDist <radius)
        {
            detectorColor = Color.red;
        }
        for (int i = 0; i < circlePoints + 1; i++)
        {
            float radian = incrementAngle * i * Mathf.Deg2Rad;
            Vector3 currentPoint = transform.position + new Vector3(Mathf.Cos(radian) * radius, Mathf.Sin(radian) * radius);
            Debug.DrawLine(firstPoint, currentPoint, detectorColor);
            firstPoint = currentPoint;

        }

    
    }

    public void SpawnPowerUps(float radius, int numberOfPowerUps)
    {
        float incrementAngle = 360f / numberOfPowerUps;



       
        
            print(currentIndex);
            currentIndex= Random.Range(0, numberOfPowerUps);
            float radian = incrementAngle * currentIndex * Mathf.Deg2Rad;
            float positionX = Mathf.Cos(radian);
            float positionY = Mathf.Sin(radian);
        Vector3 spawnPoint = transform.position + new Vector3(positionX * radius, positionY * radius);
            Instantiate(powerUp,spawnPoint,Quaternion.identity);
        



    }
}