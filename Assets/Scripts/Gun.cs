using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public GameObject cam;
    public ParticleSystem muzzleFlash;

    [Header("Scripts")]
    public PlayerMovement playerMovement;
    public EnemyMovement enemyMovement;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        playerMovement.PlayerShooting(0);       //0 array clip is for gun shooting
        muzzleFlash.Play();
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                hit.transform.gameObject.GetComponent<EnemyMovement>().bloodEffect.Play();
                hit.transform.gameObject.GetComponent<EnemyMovement>().hitCount++;
                Debug.Log(hit.transform.gameObject.name);
            }
            else
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }
}
