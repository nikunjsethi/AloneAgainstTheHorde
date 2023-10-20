using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class Gun : MonoBehaviour
{
    public InputActionReference shootingReference;
    public InputActionProperty shootingProperty;

    public float damage = 10f;
    public float range = 100f;
    public GameObject cam;
    public ParticleSystem muzzleFlash;

    [Header("Scripts")]
    public PlayerMovement playerMovement;
    public EnemyMovement enemyMovement;

    private void Awake()
    {
        //shootingReference.action.started += Shoot;
        shootingProperty.action.Enable();
    }

    //private void OnDestroy()
    //{
    //    shootingReference.action.started -= Shoot;
    //}
    // Update is called once per frame
    void Update()
    {
        if (shootingProperty.action.triggered)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        muzzleFlash.Play();
        playerMovement.PlayerShooting(0);       //0 array clip is for gun shooting
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
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
