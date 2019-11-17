using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public Sprite sprite;

    public int equippableItem = -1;

    public void Use ()
    {
        Debug.Log("used " + gameObject.name);
    }


}
