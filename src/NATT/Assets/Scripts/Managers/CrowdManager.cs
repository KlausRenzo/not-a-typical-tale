using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Serialization;

public class CrowdManager : MonoBehaviour
{
	private GameManager _gameManager;
	[SerializeField] private List<NpcBehaviour> _npcs;
	private NpcBehaviour _activeNpc;

	[FormerlySerializedAs("cameraFront")] [SerializeField]
	private Transform position1;

	[FormerlySerializedAs("cameraFront")] [SerializeField]
	private Transform position2;

	[FormerlySerializedAs("cameraFront")] [SerializeField]
	private Transform position3;

	public void Initialize(GameManager gameManager)
	{
		_gameManager = gameManager;
	}

	public Sequence SendNewNpc()
	{
		var npc = _gameManager.activePhase.npc;
		_activeNpc = _npcs.First(x => x.npc == npc);

		var position = _gameManager.activePhase.distance switch
		{
			1 => position1.position,
			2 => position2.position,
			3 => position3.position,
			_ => Vector3.zero
		};


		var sequence = DOTween.Sequence();
		if (_activeNpc != null)
		{
			sequence.Append(_activeNpc.transform.DOMove(_activeNpc.originalPosition, 0.5f).SetEase(Ease.OutQuint));
			sequence.AppendInterval(0.5f);
		}

		sequence.Append(_activeNpc.transform.DOMove(position, 0.5f).SetEase(Ease.OutQuint));
		return sequence.Play();
	}
}