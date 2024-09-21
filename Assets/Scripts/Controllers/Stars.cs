using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public int p=0;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
       


        foreach (Transform t in starTransforms)
        {

            Vector2 points;


            if (p<starTransforms.Count)
            {
               
               
                 points = starTransforms[p].position;
                
                Debug.DrawLine(transform.position, points, Color.blue);
                p++;
            }
           else {
                p = 0;
            }

        }
    }
}
