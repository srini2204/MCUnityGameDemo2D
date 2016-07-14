using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ToyBox
{
    public class EndStateController : StateController
    {

        public Animator endScoreAnimator;
        public Text endScore;
        public ScoreManager scoreManager;

        public override void On()
        {
            base.On();
            endScore.text = scoreManager.getScore().ToString();
            endScoreAnimator.SetTrigger("show");
        }

        public override void Off()
        {
            base.Off();
        }
    }
}