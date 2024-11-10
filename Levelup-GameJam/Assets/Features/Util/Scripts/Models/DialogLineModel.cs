using UnityEngine;

namespace Assets.Features.Util.Scripts.Models
{
    public class DialogLineModel
    {
        [SerializeField] private string _line;
        [SerializeField] private int _imageIndex;

        public string Line { get; set; }
        public int ImageIndex { get; set; }

    }
}
