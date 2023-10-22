using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class Gun : MonoBehaviour
{
    public InputActionProperty shootingProperty;

    public float damage = 10f;
    public float range = 100f;
    public Transform shootingDirection;             //for raycasting purposes
    public ParticleSystem muzzleFlash;

    [Header("Scripts")]
    public PlayerMovement playerMovement;
    public EnemyMovement enemyMovement;

    private void Awake()
    {
        shootingProperty.action.Enable();
    }

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
        if (Physics.Raycast(shootingDirection.position, shootingDirection.forward, out hit, range))
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
