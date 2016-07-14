using UnityEngine;
using System.Collections;

namespace ToyBox
{
    public class StateController : MonoBehaviour
    {
        public float sceneDuration;
        public GameManager GM;
        public StateType nextState;

        public virtual void On()
        {
            GM = GameManager.Instance;
        }

        public virtual void switchState()
        {
            GM.SetGameState(nextState);
        }

        public virtual void Off()
        {
            this.gameObject.SetActive(false);
        }

    }
}