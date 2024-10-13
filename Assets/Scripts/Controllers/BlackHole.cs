using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 6;
    public float pullSpeed = 0.75f;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        DetectPlayer(radius);
    }


    public void DetectPlayer(float radius)
    {
        float angleIncrement = 360 / 25;
        Vector3 currentPoint;
        Vector3 previousPoint = transform.position + new Vector3(Mathf.Cos(0) * radius, Mathf.Sin(0) * radius);
        for (int i = 0; i < 25+ 2; i++)
        {

            float radian = angleIncrement * i * Mathf.Deg2Rad;
            currentPoint = transform.position + new Vector3(Mathf.Cos(radian) * radius, Mathf.Sin(radian) * radius);
            Debug.DrawLine(previousPoint, currentPoint, Color.red);
            previousPoint = currentPoint;
        }
        if (player != null)
        {
            float playerDist = Vector3.Distance(player.transform.position, transform.position);
            if (playerDist < radius)
            {
                InterruptShip();
            }
            if (playerDist < 0.8f)
            {
                Destroy(player);

            }
        }
    }

    public void InterruptShip()
    {
        if (player != null)
        {
            float playerSpin = 250;
            playerSpin++;
            player.transform.position += (transform.position - player.transform.position) * pullSpeed * Time.deltaTime;
            player.transform.Rotate(0, 0, playerSpin * Time.deltaTime);
       //     Vector3 shrinkPlayer = player.transform.localScale - new Vector3(0.3f, 0.3f, 0.3f);
            //player.transform.localScale -= shrinkPlayer * Time.deltaTime;
        }
    }
}

