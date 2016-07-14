using UnityEngine;
using System.Collections;

namespace ToyBox.TuneTime
{
    public class GameStateController : StateController
    {
        public SpawnFromPool spawner;

        public override void On()
        {
            base.On();
            spawner.StartSpawning();
        }

        public override void Off()
        {
            base.Off();
            spawner.stopSpawning();            
        }
    }
}