using UnityEngine;
using System.Collections;

public enum StateType 
{
	NullState,
	IdleState,
	GameState,
	EndState,
}

public delegate void OnStateChangeHandler();

public class GameManager 
{
	
	private static GameManager _instance = null;    
	public event OnStateChangeHandler OnStateChange;
	public StateType gameState { get; private set; }

	protected GameManager()
    {
        gameState = StateType.NullState;
    }
	
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static GameManager Instance 
	{ 

		get 
		{

			if (_instance == null) 
			{
				_instance = new GameManager(); 
			}

			return _instance;

		}

	}

	/// <summary>
	/// Sets the state of the game.
	/// </summary>
	/// <param name="gameState">Game state.</param>
	public void SetGameState(StateType gameState) 
	{

		if(gameState == this.gameState)
			return;

		this.gameState = gameState;

		if(OnStateChange != null) 
		{
			OnStateChange();
		}

	}
}
