using DG.Tweening;
using UnityEngine;

public class AskQuestionState : StateMachineBehaviour
{
	private GameManager _gameManager;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		_gameManager = ServiceManager.GetService<GameManager>();

		_gameManager.maskManager.Enable()
					.OnComplete(() => animator.SetTrigger("Next"));
	}
}