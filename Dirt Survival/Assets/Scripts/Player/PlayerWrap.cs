using UnityEngine;

public class PlayerWrap : MonoBehaviour
{
    public float wrapWidth = 20f;
    public Transform cam;

    private void LateUpdate()
    {
        Vector3 newPos = transform.position;
        Vector3 camPos = cam.position;

        bool wrapped = false;

        if(newPos.x > wrapWidth / 2f)
        {
            newPos.x -= wrapWidth;
            camPos.x -= wrapWidth;
            wrapped = true;
        }
        else if(newPos.x < -wrapWidth / 2f)
        {
            newPos.x += wrapWidth;
            camPos.x += wrapWidth;
            wrapped = true;
        }

        if (wrapped)
        {
            transform.position = newPos;
            cam.position = camPos;
        }
    }
    /*
    private float startPosX;
    public float wrapWidth = 20f;
    public Transform cam;

    private void Start()
    {
        startPosX = Mathf.Floor(transform.position.x / wrapWidth) * wrapWidth;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceFromStart = transform.position.x - startPosX;

        if(distanceFromStart > wrapWidth / 2f)
        {
            transform.position = new Vector3(transform.position.x - wrapWidth, transform.position.y, transform.position.z);
            cam.position = new Vector3(cam.position.x - wrapWidth, cam.position.y, cam.position.z);
            startPosX += wrapWidth;
            
        }
        else if(distanceFromStart < -wrapWidth / 2f)
        {
            transform.position = new Vector3(transform.position.x + wrapWidth, transform.position.y, transform.position.z);
            cam.position = new Vector3(cam.position.x + wrapWidth, cam.position.y, cam.position.z);
            startPosX -= wrapWidth;
        }

    }
    */
}
