using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    float elapsedTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(5f,20f,planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        elapsedTime += Time.deltaTime;
        float angles = elapsedTime * speed;
        float radian = angles *Mathf.Deg2Rad;
        Vector3 followTarget = new Vector3(Mathf.Cos(radian) * radius, Mathf.Sin(radian) * radius);
        transform.position = target.position + followTarget;
    
     
    }
    }
       
    







