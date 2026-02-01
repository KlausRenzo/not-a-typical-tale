using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float dragSpeed;
	private GameManager _gameManager;
	public MaskBehaviour activeMask;
	public PlayerState State { get; private set; }

	public void Initialize(GameManager gameManager)
	{
		_gameManager = gameManager;
	}


	private void ManageIdleInput()
	{
		if (Input.GetMouseButton(0))
		{
			var eventData = new PointerEventData(EventSystem.current);
			eventData.position = Input.mousePosition;
			var results = new List<RaycastResult>();
			EventSystem.current.RaycastAll(eventData, results);

			if (!results.Any())
				return;

			var masks = results.Select(x => x.gameObject.GetComponent<MaskBehaviour>());
			var mask = masks.FirstOrDefault(x => x != null);
			if (!mask == null)
				return;

			State++;
			activeMask = mask;
		}
	}

	private TargetPlaceholder ManageDraggingInput()
	{
		if (Input.GetMouseButtonUp(0))
		{
			var dragResult = _gameManager.maskManager.StopDrag();
			if (dragResult != null)
			{
				State = PlayerState.Idle;
				return dragResult;
			}

			State = PlayerState.Idle;
			return null;
		}

		var delta = Input.mousePositionDelta;
		_gameManager.maskManager.Drag(delta);
		return null;
	}


	public TargetPlaceholder AnsweringUpdate()
	{
		switch (State)
		{
			case PlayerState.Idle:
				ManageIdleInput();
				return null;

			case PlayerState.Dragging:
				return ManageDraggingInput();
				break;
		}

		return null;
	}

	public void StartAnswering()
	{
		Debug.Log("Start answering");
		State = PlayerState.Idle;
	}
}