using Assets.Features.Util.Scripts;
using Assets.Features.Util.Scripts.Interfaces;
using Assets.Features.Util.Scripts.Models;
using UnityEngine;

namespace Assets.Features.Npcs.Morgana.Scripts
{
    public class MorganaController : MonoBehaviour, IInteractableController
    {
        [SerializeField] private DialogModel _dialog;

        public void Interact() => DialogManager.Instance.ShowDialog(_dialog);
    }
}
