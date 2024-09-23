using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float timer;
    public float drawingTime;
    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        int i= 0;
        timer+= Time.deltaTime;
        drawingTime= timer/2;
        Vector3 direction = (starTransforms[i + 1].position - starTransforms[i].position) * Time.deltaTime;
            Vector3 endPoint;
  
                for(i=0; i<starTransforms.Count-1; i++)
            {
             

                endPoint = starTransforms[i+1].position + direction;
            Debug.DrawLine(starTransforms[i].position , Vector3.Lerp(starTransforms[i].position, endPoint, drawingTime) , Color.white);

               
                if(i>=starTransforms.Count-1)
            {
                
            }

            }
     
                
                
                
            }

        }

