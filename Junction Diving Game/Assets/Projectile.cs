using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float velocity = 3f;

    Rigidbody2D rb;

    public float destroyTime = 15;

    public bool aerodynamic;

    private void Start ()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Update ()
    {      
        if (aerodynamic && rb.velocity.magnitude > 1)
        {
            transform.right = rb.velocity;
        }   
    }

    public void Launch ( Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.velocity = direction * velocity  * Random.Range(0.95f, 1.05f);

        Destroy (gameObject, destroyTime);

    }

    public int damage = 1;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        //transform.SetParent( collision.gameObject.transform, true );
        rb.velocity = Vector2.zero;
        //rb.gravityScale = 0;
        rb.angularVelocity = 0;
        //rb.bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<Collider2D> ().enabled = false;


        Enemy enemy = collision.gameObject.GetComponent<Enemy> ();

        if (enemy)
        {
            enemy.TakeDamage (damage);
        }

        onCollision.Invoke ();
    }


    public UnityEngine.Events.UnityEvent onCollision;



}
