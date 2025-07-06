using UnityEngine;

public class BackgroundMov : MonoBehaviour
{
    private float length;
    private float initialPosX;
    public GameObject cam;
    public float parallaxEffect; // The speed that the background will move relative to the camera

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calcs the dist background move based on cam movement
        float camX = cam.transform.position.x;
        float distance = camX * parallaxEffect; // 0 = move with cam || 1 = won't move || 0.5 will move at half speed
        
        transform.position = new Vector3(initialPosX + distance, transform.position.y, transform.position.z);

        float relativeCamMovement = camX * (1 - parallaxEffect);
        float temp = relativeCamMovement % length;

        transform.position = new Vector3(initialPosX + distance + temp, transform.position.y, transform.position.z);
        //If background has reached the end of its length adjust its position
           //for infinite scrolling
        /*if(movement > startPos + length)
        {
            startPos += length;
        }
        else if(movement < startPos - length)
        {
            startPos -= length;
        }
        */
    }
    
}
