using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{

    public GameObject[] weapons;

    public Transform content;


    public int testIndex = 0;

    [ContextMenu("EQuips")]
    public void EQ ()
    {
        Equip (testIndex);
    }

    public void Equip (int index)
    {

        foreach (Transform t in content)
        {
            Destroy (t.gameObject);
        }

        if (index >= 0 && index < weapons.Length)
        {
            Instantiate (weapons[index], content);
        }
        
    }
}
