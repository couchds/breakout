using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    void BuildDatabase()
    {
        items = new List<Item>{
            new Item(0, "Grappling Hook", "A tool to scale walls.",
            new Dictionary <string, int> 
            {
                {"Special", 1}
            })
        };
        Debug.Log("Start");
        Debug.Log(items);
        Debug.Log(items[0].title);
        Debug.Log("End");
    }

    public Item GetItem(int id)
    {
        Debug.Log(items);
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

}
