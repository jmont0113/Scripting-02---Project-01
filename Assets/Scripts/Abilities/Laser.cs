using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Ability
{
    [SerializeField] GameObject _laserSpawned = null;

    private int _damage = 1;

    public override void Use(Transform origin, Transform target)
    {
        // spawn projectile using origin's forward direction by default
        GameObject projectile = Instantiate (_laserSpawned, origin.position, origin.rotation);

        if (target == null)
        {
            projectile.transform.LookAt(target);
        }
        // make sure fireball can't travel infinitely
        Destroy(projectile, 2.0f);
    }
}

