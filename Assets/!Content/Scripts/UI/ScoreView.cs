using UnityEngine;
using UnityEngine.UI;

namespace FlippyPong.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text _text = default;
        [SerializeField] private string _format = default;

        public void SetScore(int score)
        {
            _text.text = string.Format(_format, score);
        }
    }
}
