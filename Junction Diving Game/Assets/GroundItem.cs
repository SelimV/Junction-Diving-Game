using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{

    SpriteRenderer sr;

    [SerializeField] Item item;

    void Awake()
    {
       StartCoroutine( Unpickable (3) );

        sr = gameObject.GetComponent<SpriteRenderer> ();
        if (item != null)
        {
            Display (item);
        }

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<PlayerController> ())
        {

            Inventory.playerInventory.AddItem (item);
            Destroy (gameObject);
        }

    }

    [SerializeField] GameObject pickup;

    IEnumerator Unpickable(float time)
    {
        pickup.SetActive(false);

        yield return new WaitForSeconds (time);

        pickup.SetActive (true);

        yield break;
    }


    public void Display (Item item)
    {
        Debug.Log (item + " " + sr);
        Debug.Log (item.sprite);

        this.item = item;
        sr.sprite = item.sprite;

    }


}
