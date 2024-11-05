using Assets.Features.Util.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Features.Player.Scripts
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private Vector2 _input;
        [SerializeField] private LayerMask _interactableLayer;

        void Awake() => _animator = GetComponent<Animator>();

        public void HandleUpdate()
        {
            _input.x = Input.GetAxisRaw("Horizontal");
            _input.y = Input.GetAxisRaw("Vertical");

            _animator.SetBool("isWalking", _input != Vector2.zero);

            if (_input == Vector2.zero) return;

            _animator.SetFloat("moveX", _input.x);
            _animator.SetFloat("moveY", _input.y);
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Z))
                Interact();
        }

        private void Interact()
        {
            var facingDir = new Vector3(_animator.GetFloat("moveX"), _animator.GetFloat("moveY"));
            var interactPos = transform.position + facingDir * 0.2f;
            var overlapCircle = Physics2D.OverlapCircle(interactPos, 0.2f, _interactableLayer);

            if (overlapCircle != null)
                overlapCircle.GetComponent<IInteractableController>()?.Interact();
        }
    }
}
