using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{

    [SerializeField] TMPro.TMP_Text text;
    [SerializeField] UnityEngine.UI.Image image;

    public Item item;

    public void Display (InventoryUI invui, Item i)
    {
        Vector2 dim = new Vector2 (i.sprite.textureRect.width, i.sprite.textureRect.height).normalized;

        image.rectTransform.sizeDelta = dim * 50;

        text.text = i.name;
        image.sprite = i.sprite;
        item = i;
        onClicked.AddListener (invui.UIClicked);
    }

    public void Click ()
    {
        onClicked.Invoke (this);
    }

    public ItemUIEvent onClicked = new ItemUIEvent();

}
