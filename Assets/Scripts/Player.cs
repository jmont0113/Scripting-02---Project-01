using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] AbilityLoadout _abilityLoadout;
    [SerializeField] Ability _startingAbility;
    [SerializeField] Ability _newAbilityToTest;
    [SerializeField] Ability _newAbilityLaser;


    [SerializeField] Transform _testTranform = null;

    public Transform CurrentTarget { get; private set; }

    private void Awake()
    {
        if(_startingAbility != null)
        {
            _abilityLoadout?.EquipAbility(_startingAbility);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        CurrentTarget = newTarget;
    }

    void Update()
    {
        //TODO in reality, Inputs would be detected elsewhere,
        // and passed into the Player class. We're doing it here
        // for simplification of example 
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _abilityLoadout.UseEquippedAbility(CurrentTarget);
        }
        //equip new weapon
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            _abilityLoadout.EquipAbility(_newAbilityToTest);
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            _abilityLoadout.EquipAbility(_newAbilityLaser);
            _abilityLoadout.UseEquippedAbility(CurrentTarget);
        }
        // set a target, for testing 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetTarget(_testTranform);
        }
    }
}
