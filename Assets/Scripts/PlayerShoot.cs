using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private float fireRate = 0f;

    private ShootController shootController;
    private bool isShooting;
    private float timeSinceLastShot;

    void Start()
    {
        isShooting = false;
        shootController = GetComponentInChildren<ShootController>();
        timeSinceLastShot = 0f;
    }

    void Update()
    {
        // Press
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isShooting)
            {
                shootController.StartShooting();
            }
        }

        // Hold
        if (Input.GetButton("Fire1"))
        {
            isShooting = true;
            if (timeSinceLastShot >= fireRate)
            {
                shootController.Shoot();
                timeSinceLastShot = 0f;
            }
            else
                timeSinceLastShot += Time.deltaTime;
        }

        // Release
        if (Input.GetButtonUp("Fire1"))
        {
            shootController.StopShooting();
            isShooting = false;
        }
    }
}