using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Features.Util.Scripts.Models
{
    [Serializable]
    public class DialogModel
    {
        [SerializeField] private string _npcName;
        [SerializeField] private List<string> _lines;
        [SerializeField] private Sprite _portraitImage;
        [SerializeField] public bool hasPortrait;

        public List<string> Lines => _lines;
        public Sprite PortraitImage => _portraitImage;
    }
}
