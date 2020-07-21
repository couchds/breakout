using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightInteraction : MonoBehaviour
{
    public bool canInteract = false;
    public int interactingChestItem = -1;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o")) {
            Debug.Log("opening!!!!!!");
            if (canInteract)
            {
                Player.GetComponent<Inventory>().GiveItem(interactingChestItem);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Check what the tag of the incoming collider is.
        if (collision.collider.tag == "Chest") {
            Player.GetComponent<Move2D>().ChangeInstructionText("Press 'O' to open the chest.");
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        // Check what the tag of the incoming collider is.
        if (collision.collider.tag == "Chest") {
            Player.GetComponent<Move2D>().ChangeInstructionText("Press 'O' to open the chest.");
            int itemId = collision.collider.gameObject.GetComponent<BoxController>().itemId;
            //Player.GetComponent<Inventory>().GiveItem(itemId);
            canInteract = true;
            interactingChestItem = itemId;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Player.GetComponent<Move2D>().ChangeInstructionText("");
        canInteract = false;
    }

}
