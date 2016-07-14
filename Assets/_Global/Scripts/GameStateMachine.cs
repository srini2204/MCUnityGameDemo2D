using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ToyBox
{
    [System.Serializable]
    public struct GameState
    {
        public StateType state;
        public GameObject stateOject;
    }

    public class GameStateMachine : MonoBehaviour
    {

        public GameState[] scenes;
        private Dictionary<StateType, GameObject> _scenes = new Dictionary<StateType, GameObject>();
        public StateType _currentState = StateType.NullState;
        public StateType _futureState = StateType.NullState;
        private GameManager GM;

        private float startTime;
        public float elapsedTime;
        public float timeToReturn;
        public bool useTimer;
        public bool isGameStateVisible;
        public SceneNavController snc;
        public ScoreManager scoreManager;

        void Awake()
        {

            PopulateScenes();

            GM = GameManager.Instance;
            GM.OnStateChange += HandleOnStateChange;

            _currentState = StateType.NullState;
            _futureState = StateType.IdleState;

            GM.SetGameState(StateType.IdleState);

            startTime = Time.time;

        }

        void PopulateScenes()
        {

            foreach (GameState s in scenes)
            {
                _scenes[s.state] = s.stateOject;
                _scenes[s.state].SetActive(false);
            }

            if (isGameStateVisible)
            {
                _scenes[StateType.GameState].SetActive(true);
            }
        }

        /// <summary>
        /// Handles the on state change.
        /// </summary>
        public void HandleOnStateChange()
        {

            //play off current stateOject
            if (_currentState != StateType.NullState)
            {
                _scenes[_currentState].GetComponent<StateController>().Off();
            }

            //switch to new state and turn on
            _scenes[GM.gameState].SetActive(true);
            _scenes[GM.gameState].GetComponent<StateController>().On();

            switch (GM.gameState)
            {

                case StateType.IdleState:
                    Debug.Log("Changed to Idle State");
                    scoreManager.resetScore();
                    _futureState = StateType.GameState;
                    break;

                case StateType.GameState:
                    Debug.Log("Changed to Game State");
                    //AnalyticsManager.addInteraction("Game Started");
                    _futureState = StateType.EndState;
                    break;

                case StateType.EndState:
                    Debug.Log("Changed to Gameover State");
                    //AnalyticsManager.addInteraction("Game Ended");
                    //Debug.Log(ScoreManager.intScore);
                    _futureState = StateType.IdleState;
                    break;
            }

            resetTimer(_scenes[GM.gameState].GetComponent<StateController>().sceneDuration);

            _currentState = GM.gameState;

            if (isGameStateVisible)
            {
                _scenes[StateType.GameState].SetActive(true);
            }

        }

        public void resetTimer(float t = 10.0f)
        {
            if (useTimer)
            {
                timeToReturn = elapsedTime + t;
            }
        }

        void Update()
        {

            elapsedTime = Time.time - startTime;

            if (useTimer)
            {

                if (elapsedTime > timeToReturn)
                {

                    if (GM.gameState == StateType.EndState && snc.returnToLauncher)
                    {
                        snc.goToScene(GameScene._MainScene);
                    }
                    else
                    {
                        GM.SetGameState(_futureState);
                    }
                }

            }

        }

    }
}