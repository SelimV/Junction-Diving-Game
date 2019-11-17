using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollorPlayer : MonoBehaviour
{
    bool active = false;

    public Rigidbody2D rb;

    public GameObject player;

    public Animator anim;



    private void Update ()
    {
        if (active)
        {
            anim.SetBool ("active", true);

            Vector2 dir = (player.transform.position - transform.position);

            if (dir.magnitude > 2)
            {
                rb.velocity = (player.transform.position - transform.position).normalized * 3;
            } else
            {
                rb.velocity = -(player.transform.position - transform.position).normalized * 0.5f;
            }

            rb.AddTorque (rb.rotation);


        }

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            active = true;
        }

    }

}
