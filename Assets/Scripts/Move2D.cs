using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    // reference to animator
    public Animator animator;

    // mouse targeting
    private Vector3 target;


    // player attributes
    public int health = 3;

    // movement state bools
    public bool isGrounded = false;
    public bool inFirstJump = false;
    public bool facingRight = true;

    public bool isHarmed = false;

    // movement speeds
    public float moveSpeed = 3f;
    public float jumpSpeed = 30f;

    // power states
    public bool canTeleport = false;
    public bool canGrapple = false;

    // +1 for right, -1 for left, 0 for no direction
    public int direction = 1;

    // canvas-related elements. possibly move these to canvas controller.
    public Text txt;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        handleMouseClick();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        animator.SetFloat("Speed", movement.magnitude);
        // movement = <4, 0>
        // moveSpeed = 4/s
        // deltaTime=2s
        // (4/s)*2s
        // 8
        // <4, 0> * 8 => <32, 0>
        // Move the position of the player a little bit based on the movement speed and the player's movement direction/position
        transform.position += movement * moveSpeed * Time.deltaTime;
        updateDirection(movement);

    }


    /*  updateDirection
     *  Called during the Update loop.
     *  Checks the direction of the Player character and sets the public direction property accordingly.
     *
     * */
    void updateDirection(Vector3 movementVector) {
        if (movementVector.x > 0 && !facingRight) {
            Flip();
        } else if (movementVector.x < 0 && facingRight) {
            Flip();
        }
        /*
        Vector3 playerLocalScale = transform.localScale;
        if (movementVector.x > 0) {
            if (direction != 1) {
                playerLocalScale.x *= -1;
            }
            direction = 1;
        }
        else if (movementVector.x < 0) {
            direction = -1;
            if (direction != -1) {
                playerLocalScale.x *= -1;
            }
        }
        transform.localScale = playerLocalScale;
        //animator.SetInteger("XDirection", direction);
        */
    }

    private void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void handleMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Clicked!!!");
            // user has ability to teleport
            if (canTeleport == true) {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = target;
            }
        }
    }

    void Jump () {
        // if the user is on the ground, they should be able to jump.
        if (Input.GetButtonDown("Jump") && isGrounded == true) {
            animator.SetBool("IsJumping", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 4f), ForceMode2D.Impulse);
            inFirstJump = true;
        }
        // if the user is in the middle of their first jump, they should be able to do a double jump.
        else if (Input.GetButtonDown("Jump") && inFirstJump == true) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 4f), ForceMode2D.Impulse);
            inFirstJump = false;
        }
    }

    public void ChangeInstructionText (string newText) {
        txt = GameObject.Find("Instruction").GetComponent<UnityEngine.UI.Text>();
        txt.text = newText;
    }

    void FireProjectile () {
        if (Input.GetButtonDown("Fire1")) {

        }
    }
}
