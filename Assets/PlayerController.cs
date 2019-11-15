using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed;
    float swimSpeed;

    Camera mainCam;

    Rigidbody2D rb;
    private void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D> ();
        mainCam = Camera.main;
    }


    private void Update  ()
    {


        rb.velocity = new Vector2 ( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );



    }





}
