using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int _damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();

        if (other.tag == "Player")
        {
            PlayerHealth(health);
        }
    }

    protected virtual void PlayerHealth(Health health)
    {
        health.TakeDamage(_damageAmount);
    }
}
