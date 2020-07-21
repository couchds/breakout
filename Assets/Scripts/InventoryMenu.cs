using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool inventoryOpen = false;
    public GameObject inventoryMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i")) {
            Debug.Log("Inventory!!!!!!");
            if (inventoryOpen) {
                CloseInventory();
            } else {
                OpenInventory();
            }
        }
    }

    void CloseInventory()
    {
        inventoryMenuUI.SetActive(false);
        inventoryOpen = false;
    }

    void OpenInventory () {
        inventoryMenuUI.SetActive(true);
        inventoryOpen = true;
    } 

}