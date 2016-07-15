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
            if(GM == null)
            {
                GM = GameManager.Instance;
            }            
        }

        public virtual void switchState()
        {
            if (GM == null)
            {
                GM = GameManager.Instance;
            }

            GM.SetGameState(nextState);
        }

        public virtual void Off()
        {
            if (GM == null)
            {
                GM = GameManager.Instance;
            }          

            gameObject.SetActive(false);            
        }

    }
}