using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Ability
{
    [SerializeField] GameObject _laserSpawned = null;

    public override void Use(Transform origin, Transform target)
    {
        // spawn projectile using origin's forward direction by default
        GameObject laserProjectile = Instantiate (_laserSpawned, origin.position, origin.rotation);

        if (target == null)
        {
            laserProjectile.transform.LookAt(target);
        }
        // make sure fireball can't travel infinitely
        Destroy(laserProjectile, 2.0f);
    }
}

