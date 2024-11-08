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
                _playerController.HandleUpdate();
            else if (_state == GameState.Pause)
            {

            }
            else if (_state == GameState.Dialog)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                    DialogManager.Instance.CloseDialog();

                if (Input.GetKeyDown(KeyCode.Z) && DialogManager.Instance.IsActive()) 
                    DialogManager.Instance.ShowNextLine();
            }
        }

        public void SetGameState(GameState gameState) => _state = gameState;
    }
}
