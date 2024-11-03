using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int _healthPoints = 100;
    int _walkingSpeed = 3;
    int _runningSpeed = 6;
    Rigidbody2D _rigidBody;
    AudioSource _audioSource;

    // Atributos da JAM
    int _strength = 1;

    int _speed = 1;
    [SerializeField] float _speedXP = 0;

    int _agility = 1;
    int _defense = 1;
    int _attack = 1;
    int _morale = 0;
    int _discipline = 0;

    void Start(){
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate(){
        if(Input.GetKey(KeyCode.LeftShift)){
            Run();
        }
        else{
            Walk();
        }
    }

#region Movement
    private void Walk(){
        _rigidBody.MovePosition(_rigidBody.position + GetMovementDirection() * _walkingSpeed * Time.deltaTime);
        WalkSound();
    }

    private void Run(){
        _rigidBody.MovePosition(_rigidBody.position + GetMovementDirection() * _runningSpeed * Time.deltaTime);
        WalkSound();

        if(GetMovementDirection() != Vector2.zero){
            _speedXP += 10f * Time.deltaTime;
        }
    }

    void WalkSound(){
        if (GetMovementDirection() != Vector2.zero){
            if (!_audioSource.isPlaying){
                _audioSource.Play();
            }
        }
        else{
            if (_audioSource.isPlaying){
                _audioSource.Stop();
            }
        }
    }

#endregion

#region Damage
    public void TakeDamage(int damageAmount)
    {
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

    public Vector2 GetMovementDirection(){
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
