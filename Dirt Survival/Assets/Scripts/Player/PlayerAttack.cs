using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    //Allows for the time that the HitBox stays active
    public float attkTime = 0.3f;
    private float timer = 0f;
    //private bool attkActive = false;
    private bool upAttkActive = false;
    private bool midAttkActive = false;
    private bool downAttkActive = false;

    // Lets me input the HitBox sprites
    public SpriteRenderer attkUp;
    public SpriteRenderer attkMid;
    public SpriteRenderer attkDown;

    public Collider2D attkUpCollider;
    public Collider2D attkMidCollider;
    public Collider2D attkDownCollider;

    //Animation control
    private Animator animator;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();

        if (attkUp != null && attkMid != null && attkDown != null)
        {
            attkUp.enabled = false;
            attkMid.enabled = false;
            attkDown.enabled = false;

            attkUpCollider.enabled = false;
            attkMidCollider.enabled = false;
            attkDownCollider.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && upAttkActive == false)
        {
            Debug.Log("Up Attack is Active");
            animator.SetBool("attkUp", true);
            attkUp.enabled = true;
            attkUpCollider.enabled = true;
            timer = attkTime;
            upAttkActive = true;

        }
        else if (Input.GetKeyDown(KeyCode.S) && midAttkActive == false)
        {
            animator.SetBool("attkMid", true);
            attkMid.enabled = true;
            attkMidCollider.enabled = true;
            timer = attkTime;
            midAttkActive = true;

        }
        else if (Input.GetKeyDown(KeyCode.D) && downAttkActive == false)
        {
            animator.SetBool("attkDown", true);
            attkDown.enabled = true;
            attkDownCollider.enabled = true;
            timer = attkTime;
            downAttkActive = true;

        }

        //Countdown on Hitbox
        if (upAttkActive || midAttkActive || downAttkActive)
        {
            timer -= Time.deltaTime;
            
            // if the timer reaches 0, resets all hitboxes and attkTime
            if(timer <= 0f)
            {
                attkUp.enabled = false;
                attkMid.enabled = false;
                attkDown.enabled = false;
                
                upAttkActive = false;
                midAttkActive = false;
                downAttkActive = false;

                attkUpCollider.enabled = false;
                attkMidCollider.enabled = false;
                attkDownCollider.enabled = false;

                animator.SetBool("attkMid", false);
                animator.SetBool("attkDown", false);
                animator.SetBool("attkUp", false);
            }
        }
    }
    // getter for attkActive
    
    public bool getUpAttkActive()
    {
        return upAttkActive;
    }

    public bool getMidAttkActive()
    {
        return midAttkActive;
    }

    public bool getDownAttkActive()
    {
        return downAttkActive;
    }
    
}
