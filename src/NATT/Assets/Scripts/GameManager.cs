using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public PlayerController player;
	public MaskManager maskManager;
	public Camera gameCamera;
	public Camera maskCamera;
	[SerializeField] private GameState _state;

	public GameState State
	{
		get => _state;
		set => _state = value;
	}

	private void Start()
	{
		player.Initialize(this);
		maskManager.Initialize(this);
	}

	private void Update()
	{
		Debugger();
		Loop();
	}

	private void Debugger()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			NextState();
		}
	}

	private void Loop()
	{
		switch (State)
		{
			case GameState.SelectingNpc:

				break;

			case GameState.Answering:
				player.AnsweringUpdate();
				break;

			case GameState.GettingFeedback:
				break;

			default:
				throw new ArgumentOutOfRangeException();
		}
	}


	private void NextState()
	{
		switch (State)
		{
			case GameState.Answering:
				State = GameState.GettingFeedback;
				break;
			case GameState.GettingFeedback:
				State = GameState.SelectingNpc;
				break;
			case GameState.SelectingNpc:
				State = GameState.Answering;
				player.StartAnswering();
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}

public enum GameState
{
	SelectingNpc,
	Answering,
	GettingFeedback
}