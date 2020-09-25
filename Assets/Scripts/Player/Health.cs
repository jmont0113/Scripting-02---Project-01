using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int _currentHealth;

    [SerializeField] public int _maxHealth = 100;

    [SerializeField] HealthBar healthBar;

    [SerializeField] public AudioSource _healthDamage;

    [SerializeField] ThirdPersonMovement thirdPersonMovement;

    [SerializeField] ScreenFlashImage screenFlash;

    [SerializeField] FlashImage _flashImage = null;

    [SerializeField] Color _newColor = Color.red;

    private float dyingTime = 2.0f;

    [SerializeField] public AudioSource _Dead;

    void Start()
    {
        _currentHealth = _maxHealth;

        healthBar.SetMaxHealth(_maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        _healthDamage.Play();

        _currentHealth -= damage;

        thirdPersonMovement.GetComponent<Animator>().Play("TookDamage");

        _flashImage.StartFlash(.25f, .5f, _newColor);

        healthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        StartCoroutine(KillPlayer());
    }

    IEnumerator KillPlayer()
    {
        thirdPersonMovement.GetComponent<Animator>().Play("Dead");
        _Dead.Play();
        yield return new WaitForSeconds(dyingTime);
        gameObject.SetActive(false);
    }
}