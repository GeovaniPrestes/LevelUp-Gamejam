using Assets.Features.Util.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Features.Npcs.Scripts.Controllers
{
    public class GenericNpcController : MonoBehaviour, IInteractableController
    {
        [SerializeField] private string[] _lowMoralLines;
        [SerializeField] private string[] _mediumMoralLines;
        [SerializeField] private string[] _highMoralLines;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Interact()
        {

        }
    }
}
