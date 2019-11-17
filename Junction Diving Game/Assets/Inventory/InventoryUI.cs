using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class ItemUIEvent : UnityEvent<ItemUI> { }

public class InventoryUI : MonoBehaviour
{

    [SerializeField] Transform content;

    [SerializeField] Inventory inventory;

    [SerializeField] bool IsPlayerInventory = true;

    [SerializeField] private ItemUI itemUIPrefab;



    private void OnEnable ()
    {
        if (IsPlayerInventory)
        {
            inventory = Inventory.playerInventory;
        }
        inventory.onChanged.AddListener (Refresh);
        Debug.Log ("addedrefresg to invent" + inventory);
        Refresh ();
    }

    private void OnDisable ()
    {
        inventory.onChanged.RemoveListener (Refresh);
    }

    public void Refresh ()
    {
        Debug.Log ("Refreshing");

        foreach(Transform t in content)
        {
            Destroy (t.gameObject);
        }

        Item[] items = inventory.GetItems ();

        for(int i = 0; i < items.Length; i++)
        {
            ItemUI instance = Instantiate (itemUIPrefab, content);
            instance.Display (this, items[i]);
        }
    }


    public void UIClicked (ItemUI iui)
    {
        onClicked.Invoke (iui);

    }


    public ItemUIEvent onClicked = new ItemUIEvent();


    public void UseItem(ItemUI iui)
    {
        iui.item.Use ();
    }

    [SerializeField] GroundItem droppedItemPrefab;

    public void DropItem (ItemUI iui)
    {

        GroundItem dropped = Instantiate (droppedItemPrefab, GameObject.FindGameObjectWithTag ("Player").transform.position, Quaternion.identity);
        dropped.Display (iui.item);
        inventory.RemoveItem (iui.item);
    }


}
