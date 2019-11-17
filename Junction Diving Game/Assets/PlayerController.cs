using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    float speed;
    float swimSpeed;

    float oxygenMultiplier = 1f;

    float oxygenBaseConsumption = 0.1f;

    Camera mainCam;

    [SerializeField] GameObject lightGimbal;

    public ProgressBar ogygenBar;
    public ProgressBar chargeTime;
    public float lastAbilityUseTime = 0;

    public float oxygen = 30f;
    public float maxOxygen = 30f;

    Rigidbody2D rb;
    private void Start ()
    {
        col = gameObject.GetComponent<Collider2D> ();
        rb = gameObject.GetComponent<Rigidbody2D> ();
        mainCam = Camera.main;
    }

    public int equippedWeapon = 0;


    float speedMod = 1;

    public int nextSpeicalWeaponUse = 0;
    
    Collider2D col;

    [SerializeField] Animator anim;

    public Item GetEquippedItem ()
    {
        Item[] items = Inventory.playerInventory.GetEquippableItems ();
        if (items.Length <= equippedWeapon)
        {
            if (items.Length == 0)
            {
                return null;
            }
            return items[0];
        }
        return items[equippedWeapon];
    }

    public EquipWeapon equipWeapon;

    private void Update ()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
           int length = Inventory.playerInventory.GetEquippableItems ().Length;

            if (length > 0)
            {
                equippedWeapon = (equippedWeapon + (int)Mathf.Sign (Input.mouseScrollDelta.y)) % length;
                if (equippedWeapon < 0)
                {
                    equippedWeapon = length;
                }

                equipWeapon.Equip (GetEquippedItem ().equippableItem);
            }
        }

       

        oxygen -= Time.deltaTime* oxygenBaseConsumption * oxygenMultiplier;

        if (oxygen < 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate  ()
    {
        ogygenBar.SetFill (oxygen / maxOxygen);

        float chargeLevel = 1;
        if (nextSpeicalWeaponUse - lastAbilityUseTime != 0)
            chargeLevel = (Time.time - lastAbilityUseTime) / (nextSpeicalWeaponUse - lastAbilityUseTime);

        chargeTime.SetFill (chargeLevel);

        if (Mathf.Abs (rb.velocity.x) > 0.5f)
        transform.localScale = new Vector2 (Mathf.Sign (rb.velocity.x), 1);


        Vector3 lightMouseVector = lightGimbal.transform.position - mainCam.ScreenToWorldPoint (Input.mousePosition);


  
        if (Input.GetKey (KeyCode.LeftShift))
        {
            speedMod = speedMod * 0.98f + (2f - speedMod) * 0.02f;
            oxygenMultiplier = (1f + rb.velocity.magnitude)*1.35f;

        } else
        {
            speedMod = speedMod * 0.98f + (1f - speedMod) * 0.02f;
            oxygenMultiplier = 1f + rb.velocity.magnitude;
        }


        Vector2 zTargetRotation = rb.velocity;

       // float rotation = rb.rotation * 0.95f + zTargetRotation * 0.05f;

        //if (!col.IsTouchingLayers())
        transform.up = (Vector2)transform.up * 0.96f + 0.04f * zTargetRotation + Vector2.up * 0.1f;

        float bodyRotation = Mathf.Abs (transform.rotation.eulerAngles.z);

        if (Mathf.Sign( lightMouseVector.x) == transform.localScale.x == (bodyRotation > 270 || bodyRotation < 90))
        {
            head.transform.localScale = new Vector2 (-1, 1);
        } else
        {
            head.transform.localScale = Vector2.one;
        }

        rb.AddForce( new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")).normalized * speedMod * 30f );

        anim.SetFloat ("Speed", rb.velocity.magnitude);
        anim.SetFloat ("LookDir", lightMouseVector.normalized.y);


        lightGimbal.transform.rotation = Quaternion.LookRotation (lightMouseVector, Vector3.forward);

    }

    [SerializeField] GameObject head;



}
