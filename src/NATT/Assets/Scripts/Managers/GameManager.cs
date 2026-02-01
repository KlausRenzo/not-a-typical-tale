using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
	public PlayerController player;
	public MaskManager maskManager;
	public CrowdManager crowdManager;

	public Camera gameCamera;
	public Camera maskCamera;
	[SerializeField] private GameState _state;
	public List<BlockDefinition> blocks;

	public GameState State
	{
		get => _state;
		set => _state = value;
	}

	private void Awake()
	{
		ServiceManager.RegisterService(this);
	}

	private void Start()
	{
		player.Initialize(this);
		maskManager.Initialize(this);
		crowdManager.Initialize(this);

		// yield return new WaitForSeconds(2);
		// GoToNextBlock();
	}

	// private void Update()
	// {
	// 	Debugger();
	// 	StateUpdate();
	// }

	// private void Debugger()
	// {
	// 	if (Input.GetKeyDown(KeyCode.P))
	// 	{
	// 		NextState();
	// 	}
	// }

	// private void StateUpdate()
	// {
	// 	switch (State)
	// 	{
	// 		case GameState.SelectingNpc:
	// 			break;
	//
	// 		case GameState.Answering:
	// 			
	// 			break;
	//
	// 		case GameState.GettingFeedback:
	// 			break;
	//
	// 		case GameState.Idle:
	// 			return;
	// 		default:
	// 			throw new ArgumentOutOfRangeException();
	// 	}
	// }


	private void NextState()
	{
		switch (State)
		{
			case GameState.Answering:
				State = GameState.Idle;
				maskManager.Disable()
							.OnComplete(() => State = GameState.GettingFeedback);
				break;

			case GameState.Idle:
			case GameState.GettingFeedback:
				crowdManager.SendNewNpc();
							// .OnComplete(GoToNextSection);
				break;

			case GameState.SelectingNpc:
				State = GameState.Idle;
				maskManager.Enable()
							.OnComplete(() =>
							{
								player.StartAnswering();
								State = GameState.Answering;
							});
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}


	public BlockDefinition activeBlock;
	public BlockPhaseDefinition activePhase;
	private int activeBlockIndex = -1;
	private int _activePhaseIndex;

	public void GoToNextBlock()
	{
		State = GameState.Idle;

		activeBlockIndex++;

		activeBlock = blocks[activeBlockIndex];
		_activePhaseIndex = 0;
		activePhase = activeBlock.phases[0];
	}

	// public void GoToNextSection()
	// {
	// 	if (NextPhase())
	// 	{
	// 		GoToNextBlock();
	// 	}
	// 	else
	// 	{
	// 		NextState();
	// 	}
	// }

	public bool NextPhase()
	{
		_activePhaseIndex++;
		return _activePhaseIndex == activeBlock.phases.Count;
	}

	public void SetBlock(BlockDefinition activeBlock)
	{
	}

	public int score;

	
}