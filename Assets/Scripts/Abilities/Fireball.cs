using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    [SerializeField] GameObject _projectileSpawned = null;

    int _rank = 1;

    public override void Use(Transform origin, Transform target)
    {
        // spawn projectile using origin's forward direction by default
        GameObject projectile = Instantiate (_projectileSpawned, origin.position, origin.rotation);

        // if we have a target, rotate projectile towards it on spawn
        if (target == null)
        {
            projectile.transform.LookAt(target);
        }
        // make sure fireball can't travel infinitely
        Destroy(projectile, 3.5f);
    }
}