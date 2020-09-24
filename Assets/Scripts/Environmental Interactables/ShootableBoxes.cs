using UnityEngine;
using System.Collections;

public class ShootableBoxes : MonoBehaviour
{
    //The box's current health point total
    [SerializeField] public int _health;
    [SerializeField] public int _maxHealth = 3;

    [SerializeField] AudioSource boxHitSound;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        _health -= damageAmount;

        //Check if health has fallen below zero
        if (_health <= 0)
        {
            //if health has fallen below zero, deactivate it 
           gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LaserShot laserShot = other.gameObject.GetComponent<LaserShot>();

        if (laserShot != null)
        {
            boxHitSound.Play();
            gameObject.SetActive(false);
        }
    }
}