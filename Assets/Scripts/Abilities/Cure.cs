using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : Ability
{
    int _healthAmount = 25;

    public override void Use(Transform origin, Transform target)
    {
        // don't allow us to cast this speel withput a target 
        if(target == null) { return; }

        Debug.Log("Cast Cure." + target.gameObject.name);
        // if the target has health, heal it 
       // target.GetComponent<Health>()?.Heal(_healthAmount);
    }
}
