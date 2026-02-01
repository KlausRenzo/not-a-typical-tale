using UnityEngine;

public class NextBlockState : StateMachineBehaviour
{
	private GameManager _gameManager;
	[SerializeField] private AudioClip[] clips;
	private int index;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		_gameManager = ServiceManager.GetService<GameManager>();

		_gameManager.PlayMusic(clips[index++]);
		if (_gameManager.activeBlock == null || _gameManager.bonusScore >= _gameManager.activeBlock.minimumScore)
		{
			_gameManager.GoToNextBlock();
			animator.SetTrigger("NextSection");
		}
		else
		{
			_gameManager.RestartBlock();
			animator.SetTrigger("NextSection");
		}
	}
}