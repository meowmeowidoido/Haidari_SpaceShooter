using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float angularSpeed;
    public float targetAngle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angularSpeed = 45f;
        targetAngle =135f;
        // Debug.DrawLine(transform.position, transform.position + transform.up, Color.green);
        Debug.DrawLine(transform.position,transform.up, Color.green);
        float currentRotation = transform.rotation.eulerAngles.z + 90;
      
        if(targetAngle - currentRotation < 0) {
            if (currentRotation > targetAngle)
            {
                transform.Rotate(0, 0, -angularSpeed * Time.deltaTime);
            }

        }

         else
                {
            if (currentRotation  < targetAngle)
            {
                transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
            }
        }
      
        
        Debug.Log(currentRotation);
        

    }
    public float StandardizeAngle(float inAngle)
    {
        inAngle %= 360;
      // inAngle = (inAngle + 360) % 360;

        if (inAngle > 180)
        {
            inAngle -= 360;
        }
        return inAngle;
    }
}
