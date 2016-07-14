using UnityEngine;
using System.Collections;

namespace ToyBox.MatchMe
{
    public class GameStateController : StateController
    {
        public CardController cardController;

        public override void On()
        {
            base.On();
            cardController.startSpawning();
        }

        public override void Off()
        {
            base.Off();
            cardController.stopSpawning();            
        }
    }
}