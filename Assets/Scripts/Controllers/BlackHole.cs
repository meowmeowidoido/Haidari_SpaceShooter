using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    //Variables for the radius and pull speed of the blackhole
    public float radius = 6;
    public float pullSpeed = 0.75f;
    //variable for the player gameobject, it is then assigned in Unity.
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        //Called in update
        DetectPlayer(radius);
    }


    public void DetectPlayer(float radius)
    {
        //used to determine how many points to increment in the Circle around player
        float angleIncrement = 360 / 25;
        Vector3 currentPoint; //Used for the current point of the circle
        Vector3 previousPoint = transform.position + new Vector3(Mathf.Cos(0) * radius, Mathf.Sin(0) * radius);//initialized as the first point
        for (int i = 0; i < 25+ 2; i++)//25 + 2 so the circle is not incomplete
        {
            //incrementing the angle by I  and converting to radians.
            float radian = angleIncrement * i * Mathf.Deg2Rad;
            //adding the transform.position to the newest point made,multiplying the radius by the Cos and Sin of the radian, Cos in the x value and Sin in y.
            currentPoint = transform.position + new Vector3(Mathf.Cos(radian) * radius, Mathf.Sin(radian) * radius);
            //Draws the line from the previous point to the current point each angle increment
            Debug.DrawLine(previousPoint, currentPoint, Color.red);
            //the previous point is set to the current point after drawing the line.
            previousPoint = currentPoint;
        }
        if (player != null)//Ensures that this does not run if the player object is destroyed
        {
            float playerDist = Vector3.Distance(player.transform.position, transform.position);//calculates the distance between player transform and the black hole's transform.
            if (playerDist < radius)//if the playerDistance is less than the radius of the circle, call InterruptShip.
            {
                InterruptShip();
            }
            if (playerDist < 0.8f)//Destroy the player if distance is less than .8f
            {
                Destroy(player);

            }
        }
    }

    public void InterruptShip()
    {
        if (player != null)//Ensures that this does not run if the player object is destroyed
        {
            float playerSpin = 250; //used to spin player when they are in the circle
            playerSpin++; //Increments while player is inside blackhole
            //begins pulling the player by adding the players transform with the direction (black hole centre position subtracted by the players position) multiplied by pullSpeed.
            player.transform.position += (transform.position - player.transform.position) * pullSpeed * Time.deltaTime;
            player.transform.Rotate(0, 0, playerSpin * Time.deltaTime);//player is spun
            Vector3 shrinkPlayer = player.transform.localScale - new Vector3(0.3f, 0.3f, 0.3f);//player scale begins to reduce by 0.3f.
            player.transform.localScale -= shrinkPlayer * Time.deltaTime;
        }
    }
}

