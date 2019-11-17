using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item> ();

    public static Inventory playerInventory;

    [SerializeField] bool isPlayerInventory;

    private void Awake ()
    {
   

        if (isPlayerInventory)
        {
            if (playerInventory != null)
            {
                Debug.LogError (" more than one player inventory ");
            }

            playerInventory = this;
        }
    }

    public void AddItem (Item item)
    {
        items.Add (item);
        onChanged.Invoke ();
    }

    public void RemoveItem (Item item)
    {
        if (items.Contains (item))
        {
            items.Remove (item);
        }
        onChanged.Invoke ();
    }

    public Item[] GetItems ()
    {
        return items.ToArray ();
    }


    public Item[] GetEquippableItems ()
    {
        List<Item> equippable = new List<Item> ();

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].equippableItem >= 0)
            {
                equippable.Add (items[i]);
            }
        }
        return equippable.ToArray ();
    }

    public UnityEvent onChanged = new UnityEvent();

    [ContextMenu("test")]
    public void Invokeonch ()
    {
        onChanged.Invoke ();
    }

}
