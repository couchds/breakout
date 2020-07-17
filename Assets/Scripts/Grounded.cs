using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grounded : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When a collision happens, the function OnCollisionEnter2D is called.
    private void OnCollisionEnter2D(Collision2D collision) {
        // Check what the tag of the incoming collider is.
        if (collision.collider.tag == "Ground") {
            Debug.Log("here!!!");
            Player.GetComponent<Move2D>().isGrounded = true;
            Debug.Log(Player.GetComponent<Move2D>().animator);
            Player.GetComponent<Move2D>().animator.SetBool("IsJumping", false);
            
        }
    }
    // When the collision ends, the function OnCollisionExit2D is called.
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            Player.GetComponent<Move2D>().isGrounded = false;
        }
    }
}
