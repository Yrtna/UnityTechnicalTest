using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ShootController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnPoints;
    [SerializeField]
    private GameObject bullet;
    
    private Animator modelAnimator;
    private static readonly int IsFiring = Animator.StringToHash("is_firing");

    private void Start()
    {
        modelAnimator = GetComponent<Animator>();
    }
    
    public void StartShooting()
    {
        modelAnimator.SetBool(IsFiring, true);
    }

    public void Shoot()
    {
        foreach (var point in spawnPoints)
        {
            Instantiate(bullet, point.position, gameObject.transform.rotation);
        }
    }

    public void StopShooting()
    {
        modelAnimator.SetBool(IsFiring, false);
    }
}
