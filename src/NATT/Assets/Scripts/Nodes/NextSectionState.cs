using UnityEngine;

public class NextSectionState : StateMachineBehaviour
{
	private GameManager _gameManager;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		_gameManager = ServiceManager.GetService<GameManager>();

		if (_gameManager.NextPhase())
		{
			animator.SetTrigger("NextBlock");	
		}
		else
		{
			animator.SetTrigger("CallNpc");
		}
	}
}