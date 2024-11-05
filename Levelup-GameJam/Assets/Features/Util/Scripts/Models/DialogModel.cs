using System.Collections.Generic;
using UnityEngine;

namespace Assets.Features.Util.Scripts.Models
{
    [System.Serializable]
    public class DialogModel
    {
        [SerializeField] private string _npcName;
        [SerializeField] private List<string> _lines;

        public List<string> Lines
        {
            get { return _lines; }
        }
    }
}
