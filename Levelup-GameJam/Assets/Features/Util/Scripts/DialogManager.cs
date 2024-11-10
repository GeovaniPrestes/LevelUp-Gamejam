using Assets.Features.Util.Scripts.Models;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Features.Util.Scripts
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] private GameObject _dialogBox;
        [SerializeField] private GameObject _portraitGameObject;
        [SerializeField] private Image _portraitImage;
        [SerializeField] private Text _dialogText;
        [SerializeField] private Text _nameText;
        [SerializeField] private int _lettersPerSecond;
        private DialogModel _actualDialog;
        private int _actualDialogLine = 0;

        private Coroutine _typingCoroutine;

        public static DialogManager Instance { get; private set; }

        void Awake() => Instance = this;

        public void ShowDialog(DialogModel dialog)
        {
            if (dialog.Lines[_actualDialogLine].Equals(_dialogText.text)) ShowNextLine();

            
            FindObjectOfType<GameController>()?.SetGameState(GameState.Dialog);

            _dialogBox.SetActive(true);

            _actualDialog = dialog;

            if (dialog.hasPortrait)
                SetPortraitImage();

            _portraitGameObject.SetActive(dialog.hasPortrait);

            if (_typingCoroutine != null)
                StopCoroutine(_typingCoroutine);

            _typingCoroutine = StartCoroutine(TypeDialog(dialog.Lines[_actualDialogLine]));
        }

        private void SetPortraitImage()
        {
            _nameText.text = _actualDialog.NpcName;
            _portraitImage.sprite = _actualDialog.PortraitImage[_actualDialog.PortraitIndex[_actualDialogLine]];
        }

        public bool IsActive() => _dialogBox.activeSelf;

        public void CloseDialog()
        {
            _dialogBox.SetActive(false);
            _actualDialogLine = 0;
            FindObjectOfType<GameController>()?.SetGameState(GameState.FreeRoam);
        }

        public void ShowNextLine()
        {
            if (_typingCoroutine is not null) return;

            _actualDialogLine++;

            if (_actualDialogLine == _actualDialog.Lines.Count) CloseDialog();
            else ShowDialog(_actualDialog);
        }

        public IEnumerator TypeDialog(string line)
        {
            _dialogText.text = "";

            foreach (var letter in line.ToCharArray())
            {
                _dialogText.text += letter;
                yield return new WaitForSeconds(1f / _lettersPerSecond);
            }

            _typingCoroutine = null;
        }
    }
}
