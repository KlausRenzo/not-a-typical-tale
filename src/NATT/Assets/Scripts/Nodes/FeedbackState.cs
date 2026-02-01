using DG.Tweening;
using UnityEngine;

public class FeedbackState : StateMachineBehaviour
{
	private GameManager _gameManager;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		_gameManager = ServiceManager.GetService<GameManager>();

		_gameManager.maskManager.Disable()
					.OnComplete(()=> animator.SetTrigger("Next"));
	}
}