using Assets.Features.Util.Scripts.Models;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Features.Util.Scripts
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] private GameObject _dialogBox;
        [SerializeField] private Text _dialogText;
        [SerializeField] private int _lettersPerSecond;

        private Coroutine _typingCoroutine;

        public static DialogManager Instance { get; private set; }

        void Awake() => Instance = this;

        public void ShowDialog(DialogModel dialog)
        {
            _dialogBox.SetActive(true);
            if (_typingCoroutine != null)
                StopCoroutine(_typingCoroutine);

            _typingCoroutine = StartCoroutine(TypeDialog(dialog.Lines[0]));
        }

        public void CloseDialog() => _dialogBox.SetActive(false);

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
