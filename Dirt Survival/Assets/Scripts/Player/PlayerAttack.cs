using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Allows for the time that the HitBox stays active
    public float attkTime = 2f;
    private float timer = 0f;
    private bool attkActive = false;

    // Lets me input the HitBox sprites
    public SpriteRenderer attkUp;
    public SpriteRenderer attkMid;
    public SpriteRenderer attkDown;
    private void Start()
    {
        if(attkUp != null && attkMid != null && attkDown != null)
        {
            attkUp.enabled = false;
            attkMid.enabled = false;
            attkDown.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && attkActive == false)
        {
            attkUp.enabled = true;
            timer = attkTime;
            attkActive = true;
        }
        else if(Input.GetKeyDown(KeyCode.S) && attkActive == false)
        {
            attkMid.enabled = true;
            timer = attkTime;
            attkActive = true;
        }
        else if(Input.GetKeyDown(KeyCode.D) && attkActive == false)
        {
            attkDown.enabled = true;
            timer = attkTime;
            attkActive = true;
        }

        //Countdown on Hitbox
        if (attkActive)
        {
            timer -= Time.deltaTime;
            
            // if the timer reaches 0, resets all hitboxes and attkTime
            if(timer <= 0f)
            {
                attkUp.enabled = false;
                attkMid.enabled = false;
                attkDown.enabled = false;
                attkActive = false;
            }
        }
    }
}
