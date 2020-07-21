using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 12;

    // When the UIInventory is instantiated, we instantiate
    // the slot prefabs 
    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    public void UpdateSlot(int slot, Item item)
    {
        uiItems[slot].UpdateItem(item);
    }

    // when this function is called, a new item is added to the inventory.
    public void AddNewItem(Item item)
    {
        int indexFound = uiItems.FindIndex(i => i.item == null);
        if (indexFound == -1) {
            indexFound = 0;
        }
        UpdateSlot(indexFound, item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
    }

}
