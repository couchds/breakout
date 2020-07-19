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
            if (Player.GetComponent<Move2D>().isHarmed == false) {
                int initialHealth = Player.GetComponent<Move2D>().health;
                Player.GetComponent<Move2D>().health -= 1;
                Debug.Log("Here!");
                //GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>().transform.Find("Health3").gameObject.GetComponent<Health3Controller>().triggerHealthLoss();
                canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
                string objectName = "Health" + initialHealth.ToString();
                canvas.transform.Find(objectName).GetComponent<Animator>().SetTrigger("LoseHealth");
                Player.GetComponent<Move2D>().isHarmed = true;
                Player.GetComponent<Move2D>().animator.SetBool("IsHarmed", true);
                StartCoroutine(waitThreeSeconds());
            } else {
                Debug.Log("Here!");
            }
        }
    }

    IEnumerator waitThreeSeconds() {
         yield return new WaitForSeconds(1);
         Player.GetComponent<Move2D>().isHarmed = false;
         Player.GetComponent<Move2D>().animator.SetBool("IsHarmed", false);
     }

    // When the collision ends, the function OnCollisionExit2D is called.
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            Debug.Log("out!!!");
        }
    }
}
