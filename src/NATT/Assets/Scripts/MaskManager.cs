using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class MaskManager : MonoBehaviour
{
	[SerializeField] private float draggingSpeed;
	[FormerlySerializedAs("activeMask")] [SerializeField] private MaskBehaviour selector;
	private GameManager _gameManager;

	[SerializeField] private Transform center;
	[SerializeField] private float returnDuration;
	private List<TargetPlaceholder> targets;

	public void Initialize(GameManager gameManager)
	{
		_gameManager = gameManager;
	}

	private Coroutine returningCoroutine;

	public void Drag(Vector3 delta)
	{
		selector.transform.DOKill();

		selector.transform.position += delta * draggingSpeed;
		var maxDistance = targets.Max(x => (center.position - x.transform.position).magnitude) * 1.2f;


		selector.transform.position = Vector3.ClampMagnitude(selector.transform.position, maxDistance);

	}

	public void StopDrag()
	{
		Debug.Log("DraggingStopped");
		//returningCoroutine = StartCoroutine(ReturnToStart());
		selector.transform.DOMove(center.position, returnDuration);
		selector.transform.DOPlay();
	}

}