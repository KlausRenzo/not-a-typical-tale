using UnityEngine;

public class NextBlockState : StateMachineBehaviour
{
	private GameManager _gameManager;
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		_gameManager = ServiceManager.GetService<GameManager>();
		
		_gameManager.GoToNextBlock();
		
		animator.SetTrigger("NextSection");
	}
}