using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxygenArea : MonoBehaviour
{
    PlayerController plc;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        PlayerController pl = collision.GetComponent<PlayerController> ();
        if (pl)
        {
            plc = pl;
        }

    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        PlayerController pl = collision.GetComponent<PlayerController> ();
        if (pl)
        {
            plc = null;
        }
    }

    private void Update ()
    {
        

        if (plc != null)
        {
            plc.oxygen += Time.deltaTime;
        }

    }
}
