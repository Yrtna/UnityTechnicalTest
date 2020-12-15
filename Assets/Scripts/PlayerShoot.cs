using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private ShootController shootController;
    private bool isShooting;

    void Start()
    {
        isShooting = false;
        shootController = GetComponentInChildren<ShootController>();
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
            shootController.Shoot();
        }
        // Release
        if (Input.GetButtonUp("Fire1"))
        {
            shootController.StopShooting();
            isShooting = false;
        }
    }
}
