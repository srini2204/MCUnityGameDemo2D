using UnityEngine;
using System.Collections;

namespace ToyBox
{

    public class IdleStateController : StateController
    {
        public Animator idleAnimator;

        public override void On()
        {
            base.On();
            idleAnimator.SetTrigger("show");
        }

        public override void Off()
        {
            base.Off();
        }
    }

}