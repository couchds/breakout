using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;
    private Image spriteImage;

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        // initial update: no item.
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        Debug.Log("On UIItem");
        Debug.Log(item);
        if (this.item != null)
        {
            spriteImage.color = Color.black;
            spriteImage.sprite = this.item.icon;
            spriteImage.GetComponent<Image>().color = Color.white;
            //spriteImage.sprite.color = Color.white;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

}
