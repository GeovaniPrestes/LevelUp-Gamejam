using Assets.Features.Player.Scripts;
using UnityEngine;

namespace Assets.Features.Util.Scripts
{
    public enum GameState
    {
        FreeRoam,
        Dialog,
        Pause
    }

    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationController _playerController;
        private GameState _state;

        void Update()
        {
            if (_state == GameState.FreeRoam)
            {
                _playerController.HandleUpdate();
            }
            else if (_state == GameState.Pause)
            {

            }
            else if (_state == GameState.Dialog)
            {
                if (Input.GetKey(KeyCode.Escape))
                    DialogManager.Instance.CloseDialog();
            }
        }

    }
}
