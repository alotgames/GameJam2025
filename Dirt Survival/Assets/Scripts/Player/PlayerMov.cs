using UnityEngine;
using System; 

public class PlayerMov : MonoBehaviour
{
    float horzIn;
    float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    bool facingRight = false;
    float jumpPower = 4f;
    bool isJumping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initializes 2D body
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the left or right arrow key is held it allows th eplayer to move
        horzIn = 0f;
        // moves right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horzIn = 1f;
            animator.SetBool("isMoving", true);
        }
        // moves left
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horzIn = -1f;
            animator.SetBool("isMoving", true);
        }
        else
        {
            //stops walking animation if no input from arrow keys is detected
            animator.SetBool("isMoving", false);
        }
        // Keeps it consistent across all devices
        transform.position += new Vector3(horzIn, 0f, 0f) * moveSpeed * Time.deltaTime;
        flipSprite();

        // Checks if jump is detected
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            Debug.Log("Jumping is set to true");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    // Makes sprite face the direction its moving
    void flipSprite()
    {
        // flips the sprite
        if(facingRight && horzIn < 0f || !facingRight && horzIn > 0f)
        {
            // flips it depending on whatever it isn't currently
            facingRight = !facingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    // Makes it so jumping is only available when on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player Collides With floor");
        // Fixes bug where player could jump off of enemies
        if (collision.gameObject.CompareTag("Enemy") == false)
        {
            Debug.Log("Jumping is set to false");
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }
}
