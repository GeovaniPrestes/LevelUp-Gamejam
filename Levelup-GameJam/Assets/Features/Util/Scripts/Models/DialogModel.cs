using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Features.Util.Scripts.Models
{
    [Serializable]
    public class DialogModel
    {
        [SerializeField] private string _npcName;
        [SerializeField] private List<string> _lines;
        [SerializeField] private List<Sprite> _portraitImage;
        [SerializeField] private List<int> _portraitIndex;
        [SerializeField] public bool hasPortrait;

        public List<string> Lines => _lines;
        public List<int> PortraitIndex => _portraitIndex;
        public List<Sprite> PortraitImage => _portraitImage;
        public string NpcName => _npcName;
    }
}
