using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollor : MonoBehaviour
{
    [SerializeField] float lightDir = 1;


    GameObject playerLight;

    Vector2 lightLerpPos;

    Camera mainCam;

    private void Start ()
    {
        playerLight = GameObject.FindGameObjectWithTag ("FlashLightNode");
        mainCam = Camera.main;
    }

    [SerializeField] [Range (0, 0.05f)] float lerpSpeed;
    [SerializeField] [Range (0, 0.05f)] float mouseLerpSpeed;

    Vector2 targetPosition;

    void Update()
    {

        float mouseDistance = Mathf.Sqrt( Mathf.Pow( (Input.mousePosition.x / Screen.width)*2 - 1 , 2) + Mathf.Pow ( (Input.mousePosition.y / Screen.height) * 2 - 1, 2));

        targetPosition = targetPosition * (1- mouseLerpSpeed) + (Vector2)(mouseLerpSpeed * ( playerLight.transform.position + playerLight.transform.up * lightDir * mouseDistance));


        transform.position = transform.position * lerpSpeed + (1 - lerpSpeed) * (Vector3)targetPosition + Vector3.back*10;

    }
}
