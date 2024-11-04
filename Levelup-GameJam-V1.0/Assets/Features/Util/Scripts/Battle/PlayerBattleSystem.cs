using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBattleSystem : MonoBehaviour
{
    int _healthPoints = 100;
    AudioSource _audioSource;

    //Selecionar ação
    int _selected = 0;
    public TextMeshProUGUI[] options = new TextMeshProUGUI[4];

    Color _defaultColor = Color.black;
    Color _selectedColor = Color.yellow;

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
        UpdateSelected();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.UpArrow)){
            _selected -= 2;
            if(_selected == -1) _selected = options.Length -1;
            if(_selected <  -1) _selected = options.Length -2;
            UpdateSelected();
        }
        if(Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.LeftArrow)){
            _selected--;
            if(_selected == -1) _selected = options.Length -1;
            UpdateSelected();
        }
        if(Input.GetKeyDown(KeyCode.D) ||Input.GetKeyDown(KeyCode.RightArrow)){
            _selected++;
            if(_selected == options.Length) _selected = 0;
            UpdateSelected();
        }
        if(Input.GetKeyDown(KeyCode.S) ||Input.GetKeyDown(KeyCode.DownArrow)){
            _selected += 2;
            if(_selected == options.Length) _selected = 0;
            if(_selected >  options.Length) _selected = 1;
            UpdateSelected();
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter)){
            ExecuteSelected();
        }
    }


    void UpdateSelected(){
        for(int i = 0; i < options.Length; i++){
            if(i == _selected) options[i].color = _selectedColor;
            else options[i].color = _defaultColor;
        }
    }
    private void ExecuteSelected(){
        switch (_selected)
        {
            case 0:
                Attack();
                break;
            case 1:
                Defend();
                break;
            case 2:
                Item();
                break;
            case 3:
                Run();
                break;
            default:
                Attack();
                break;
        }
    }
    private void Attack(){
        Debug.Log("Attack");
    }

    private void Defend(){
        Debug.Log("Defend");
    }

    private void Item(){
        Debug.Log("Item");
    }

    private void Run(){
        Debug.Log("Run");
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
