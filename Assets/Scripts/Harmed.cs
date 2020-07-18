using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Harmed : MonoBehaviour
{
    GameObject Player;
    private Canvas canvas;
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
        if (collision.collider.tag == "Harmful") {
            Debug.Log("harmed!!!");

            Player.GetComponent<Move2D>().health -= 1;
            Debug.Log("Here!");
            //GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>().transform.Find("Health3").gameObject.GetComponent<Health3Controller>().triggerHealthLoss();
            canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
            canvas.transform.Find("Health3").GetComponent<Animator>().SetTrigger("LoseHealth");
            //yield WaitForSeconds(1);
            //canvas.transform.Find("Health3").gameObject.SetActive(false);
            //Health3.triggerHealthLoss();
            //Debug.Log(Health3);

            //Debug.Log(Player.GetComponent<Move2D>().animator);
            //Player.GetComponent<Move2D>().animator.SetBool("IsJumping", false);
            
        }
    }

    // When the collision ends, the function OnCollisionExit2D is called.
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            Debug.Log("out!!!");
        }
    }
}
