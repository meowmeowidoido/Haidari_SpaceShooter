using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusCircle : MonoBehaviour
{
    public List<float> angles;
    public int currentIndex = 0;
    public float incrementingIndex;
    public float radius = 3f;
    public Vector3 offset = Vector3.zero;
    public float delayInSeconds = 1f;
    private float elapsedTime = 0f;
    // Start is called before the first frame update
 
    void Start()
    {
        angles = new List<float>();

         for(int i =0;i<10;  i++){
            angles.Add(Random.value * 360);
        }
        transform.position += offset;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > delayInSeconds)
        {
            currentIndex += 1;
            elapsedTime = 0;
        }
     /*   if (Input.GetKeyDown(KeyCode.Space))
        {
            currentIndex += 1 ;
            currentIndex = (currentIndex + 1) % 1;
        }*/

        if (currentIndex == 9)
        {
            currentIndex = 0;

        }
        float radians = Mathf.Deg2Rad * angles[currentIndex];
        float xPosition = Mathf.Cos(radians); 
        float yPosition = Mathf.Sin(radians);

        Vector3 endpoint = transform.position + new Vector3(xPosition, yPosition, 0f) * radius;
        Debug.DrawLine(transform.position, endpoint, Color.magenta);
    }
}
