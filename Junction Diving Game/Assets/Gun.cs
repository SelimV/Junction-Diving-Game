using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Projectile projectilePrefab;


    public Transform firePoint;


    public PlayerController playerController;


    public float interval = 2f;

    float nextShootTime = 0;


    private void Start ()
    {
        mainCam = Camera.main;
        playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
    }


    public bool UseCoolDown = true;
    public int cooldownAmmo = 0;
    public int freshCooldownAmmo = 20;
    public int weaponCooldown = 20;

    public void Shoot () {

        if (UseCoolDown && playerController.nextSpeicalWeaponUse < Time.time)
        {
            if (cooldownAmmo <= 0)
            {
                cooldownAmmo = freshCooldownAmmo;
                playerController.nextSpeicalWeaponUse = (int)(Time.time + weaponCooldown);
                playerController.lastAbilityUseTime = Time.time;
            }
        }

        if (nextShootTime < Time.time && (!UseCoolDown || cooldownAmmo > 0))
        {
            cooldownAmmo--;
            StartCoroutine (HideAmmo ());
            nextShootTime = Time.time + interval;
            Projectile instance = Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
            instance.Launch (playerController.transform.localScale.x * firePoint.right);
        }
    }

    public GameObject ammovisual;

    IEnumerator HideAmmo ()
    {
        if (ammovisual)
        {
            ammovisual.SetActive (false);

            yield return new WaitForSeconds (interval);

            ammovisual.SetActive (true);

            yield break;
        }
    }

    Camera mainCam;

    private void Update ()
    {
        Vector2 pointDir =  (Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position).normalized;

        Vector2 limitUp = -playerController.transform.right;

      
        pointDir = (new Vector2 (pointDir.x * playerController.transform.localScale.x, pointDir.y* playerController.transform.localScale.x)).normalized;

        if (Vector2.Angle(limitUp, pointDir) > 90)
        {
            transform.right = pointDir;
        } else
        {
            //transform.right = playerController.transform.right;
        }
  
      
       




        if (Input.GetMouseButton (0))
        {
            Shoot ();
        }

    }

}
