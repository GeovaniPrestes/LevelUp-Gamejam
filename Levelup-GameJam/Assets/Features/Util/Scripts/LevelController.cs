using UnityEngine;

namespace Assets.Features.Util.Scripts
{
    public class LevelController : MonoBehaviour
    {
        private readonly int[] _levelsAmount = new int[]{
            0,1050,2450,4550,7700,12425,19513,30145,46094,
            70018,105904,159732,240474,361587,543257,
            815762,1224520,1837656,2757360,4136916
        };

        public int ReturnLevel(int xpAmmount)
        {
            var level = 1;
            for (var i = 0; i < _levelsAmount.Length; i++)
            {
                if (xpAmmount < _levelsAmount[i]) break;
                level = i;
            }

            return level;
        }

        public int ReturnXpAmmountForTheNextLevel(int level) =>
            level + 1 < _levelsAmount.Length ? _levelsAmount[level + 1] : 0;
    }
}
