using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // How fast the Player is moving
    public float speed;
    
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;


    // Start is called before the first frame update
    void Start()
    {
        // Getting the Rigidbody component associated with the Player object.
        rb = GetComponent<Rigidbody2D>();
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // GetAxis horizontal: checks to see if user is moving left or right, and is equal to -1 or 1
        // GetAxis vertical: check to see if user is moving down or up, and is equal to -1 or 1
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // For instance, user pushing right arrow key and the up arrow key,
        // Then moveInput = <1, 1>
        // If they were pushing left arrow key and up arrow key,
        // Then moveInput = <-1, 1>
        // If they were pushing right arrow key and the down arrow key,
        // Then moveInput = <1, -1>
        // If they were pushing left arrow key and the down arrow key,
        // Then moveInput = <-1, -1>
        // If they're not moving
        // Then moveInput = <0, 0>

        // moveVelocity represe
        moveVelocity = moveInput.normalized * speed;
        animator.SetFloat("Speed", moveVelocity.magnitude);
    }

    // Code related to physics
    //void FixedUpdate() {
    //    rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    //}
}
