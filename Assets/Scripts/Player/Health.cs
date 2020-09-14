using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int _currentHealth = 50;
    [SerializeField] GameObject thePlayer;

    public void Heal(int amount)
    {
        _currentHealth += amount;
        Debug.Log(gameObject.name + " has healed " + amount);

        if (_currentHealth <= 0)
        {
            //if health has fallen below zero, deactivate it 
            thePlayer.GetComponent<Animator>().Play("Falling");
        }
    }
}
