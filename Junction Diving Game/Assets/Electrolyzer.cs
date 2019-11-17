using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Electrolyzer : MonoBehaviour
{

    public PlayerController playerController;

    private void Start ()
    {
        playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
    }

    public UnityEvent onUsed;

    public int coolDown = 32;

    private void Update ()
    {
        
        if (Input.GetMouseButton (0))
        {
            Use ();
        }

    }

    public void Use ()
    {

        if (playerController.nextSpeicalWeaponUse < Time.time)
        {

            playerController.lastAbilityUseTime = Time.time;
            playerController.nextSpeicalWeaponUse = (int)(Time.time + coolDown);
            onUsed.Invoke ();
            playerController.oxygen = Mathf.Min (playerController.maxOxygen, playerController.oxygen + 20f);
        }

    }

    public void BubbleUp ()
    {
        StartCoroutine (Bubbles (5, 35));
    }

    IEnumerator Bubbles (float time, int bubbles)
    {

        float timeElapsed = 0;
        while (timeElapsed < time)
        {

            if (Random.Range(0f, 1f) < bubbles/10*time)
            {
                ps.Emit (1);
            }


            timeElapsed += 0.1f;
            yield return new WaitForSeconds (0.1f);
        }


    }

    public ParticleSystem ps;

}
