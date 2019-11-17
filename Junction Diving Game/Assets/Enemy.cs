using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject player;
    [SerializeField] float range;
    [SerializeField] float hideRange;

    [SerializeField] GameObject[] patrolNodes;

    Rigidbody2D rb;

    private void Start ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        rb = GetComponent<Rigidbody2D> ();
    }

    public int health = 3;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            this.enabled = false;
        }
    }

    bool TrySeePlayer ()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, player.transform.position - transform.position, range, ~(1 << 10));

        if ( !hasSeen && -facing == (int)Mathf.Sign( player.transform.position.x - transform.position.x ))
        {
            return false;
        }

        if (hit && hit.collider.gameObject.layer == 9)
        {
            return true;
        } else
        {

            hit = Physics2D.Raycast (transform.position, player.transform.position - transform.position, hideRange, ~(1 << 10 | 1 << 11));

            if (hit && hit.collider.gameObject.layer == 9)
            {
                return true;
            }
        }

        return false;
    }

    int facing { get { return (int)( -transform.localScale.x); } }

    bool hasSeen = false;

    private void FixedUpdate ()
    {

        rb.AddTorque (-rb.rotation);
        if (Mathf.Abs(rb.velocity.x) > 0.2f)
        transform.localScale = new Vector2 ( -Mathf.Sign( rb.velocity.x ) , 1);

        if (TrySeePlayer())
        {
            Debug.Log ("Sees player");
            Chase ();
        } else
        {
            Patrol ();
        }
    }

    int nextWayPoint = 0;
    bool forwards = true;
    public void Patrol ()
    {
        Vector2 direction = (patrolNodes[nextWayPoint].transform.position - transform.position);

        if (direction.SqrMagnitude () < 1)
        {
            if (forwards)
            {
                nextWayPoint++;
                if (nextWayPoint >= patrolNodes.Length - 1)
                {
                    forwards = false;
                }
            } else
            {
                nextWayPoint--;
                if (nextWayPoint <= 0)
                {
                    forwards = true;
                }
            } 
        }

          
        

        rb.velocity = direction.normalized*3f;

    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
           StartCoroutine(LiterallyDie ());
        }

    }

    IEnumerator LiterallyDie ()
    {
        yield return new WaitForSeconds (3f);

        UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
        yield break;
    }


    public void Chase ()
    {
        Vector2 direction = (player.transform.position - transform.position);

        rb.velocity = direction.normalized  * (5 + (6f/ direction.magnitude));

    }


}
