using DG.Tweening;
using UnityEngine;

public class CallNpcState : StateMachineBehaviour
{
	private GameManager _gameManager;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		_gameManager = ServiceManager.GetService<GameManager>();

		_gameManager.crowdManager.SendNewNpc()
					.OnComplete(() => animator.SetTrigger("AskQuestion"));
	}
}