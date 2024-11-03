using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleSystem : MonoBehaviour
{
    int _healthPoints = 100;
    AudioSource _audioSource;

    // Atributos da JAM
    int _strength = 1;
    int _speed = 1;
    int _agility = 1;
    int _defense = 1;
    int _attack = 1;
    int _morale = 0;
    int _discipline = 0;

    void Start(){
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

#region Damage
    public void TakeDamage(int damageAmount){
        int finalDamage = Mathf.Max(damageAmount - _defense, 0);
        _healthPoints -= finalDamage;

        if (_healthPoints <= 0){
            // Implementar lógica de Game Over
        }
    }

#endregion

    public void DisplayStats(){
        Debug.Log($"Health: {_healthPoints}, Strength: {_strength}, Speed: {_speed}, Agility: {_agility}, " +
                  $"Defense: {_defense}, Attack: {_attack}, Morale: {_morale}, Discipline: {_discipline}");
    }
}
