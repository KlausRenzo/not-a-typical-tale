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
	}

	public BlockDefinition activeBlock;
	public BlockPhaseDefinition activePhase;
	private int activeBlockIndex = -1;
	private int _activePhaseIndex;

	public void GoToNextBlock()
	{
		activeBlockIndex++;

		activeBlock = blocks[activeBlockIndex];
		_activePhaseIndex = 0;
		activePhase = activeBlock.phases[0];
	}

	public void RestartBlock()
	{
		_activePhaseIndex = 0;
		activePhase = activeBlock.phases[0];
	}

	public bool NextPhase()
	{
		_activePhaseIndex++;
		return _activePhaseIndex == activeBlock.phases.Count;
	}

	public int bonusScore;
	public int isolationScore;
	public int burnout;
}