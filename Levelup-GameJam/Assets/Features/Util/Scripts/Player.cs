using UnityEngine;

namespace Assets.Features.Util.Scripts
{
    public class Player : MonoBehaviour
    {
        int _healthPoints = 100;
        float _walkingSpeed = 1.5f;
        float _runningSpeed = 3f;
        Rigidbody2D _rigidBody;
        AudioSource _audioSource;

        // Atributos da JAM
        int _strength = 1;
        int _speed = 1;
        int _agility = 1;
        int _defense = 1;
        int _attack = 1;
        int _morale = 0;
        int _discipline = 0;

        void Awake()
        {
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
            _audioSource = gameObject.GetComponent<AudioSource>();
        }

        void Update()
        {

        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftShift)) Run();
            else Walk();
        }

        #region Movement
        private void Walk()
        {
            _rigidBody.MovePosition(_rigidBody.position + GetMovementDirection() * _walkingSpeed * Time.deltaTime);
            WalkSound();
        }

        private void Run()
        {
            _rigidBody.MovePosition(_rigidBody.position + GetMovementDirection() * _runningSpeed * Time.deltaTime);
            WalkSound();
        }

        void WalkSound()
        {
            if (GetMovementDirection() != Vector2.zero)
            {
                if (!_audioSource.isPlaying)
                    _audioSource.Play();
            }
            else
            {
                if (_audioSource.isPlaying)
                    _audioSource.Stop();
            }
        }

        #endregion

        #region Damage
        public void TakeDamage(int damageAmount)
        {
            int finalDamage = Mathf.Max(damageAmount - _defense, 0);
            _healthPoints -= finalDamage;

            if (_healthPoints <= 0)
            {
                // Implementar lógica de Game Over
            }
        }

        #endregion

        public void DisplayStats()
        {
            Debug.Log($"Health: {_healthPoints}, Strength: {_strength}, Speed: {_speed}, Agility: {_agility}, " +
                      $"Defense: {_defense}, Attack: {_attack}, Morale: {_morale}, Discipline: {_discipline}");
        }

        public Vector2 GetMovementDirection()
        {
            var move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            move.Normalize();
            return move;
        }
    }
}
