using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleSystem : MonoBehaviour
{
    int _healthPoints = 100;
    AudioSource _audioSource;

    // Atributos da JAM
    int _strength = 1;
    int _speed = 1;
    int _defense = 1;
    int _attack = 1;

    void Start(){
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

#region Damage
    public void TakeDamage(int damageAmount)
    {
        int finalDamage = Mathf.Max(damageAmount - _defense, 0);
        _healthPoints -= finalDamage;

        if (_healthPoints <= 0){
            // Implementar lógica de Vitótia
        }
    }

#endregion
}
