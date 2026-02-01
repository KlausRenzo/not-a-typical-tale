using UnityEngine;

public class AnswerState : StateMachineBehaviour
{
	private GameManager _gameManager;
	private float startTime;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		_gameManager = ServiceManager.GetService<GameManager>();
		startTime = Time.time;
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate(animator, stateInfo, layerIndex);
		var answer = _gameManager.player.AnsweringUpdate();


		if (answer == null)
			return;

		var activePhase = _gameManager.activePhase;

		Debug.Log(">" + answer.state + "<");
		if (answer.state == activePhase.requiredState)
		{
			_gameManager.score += activePhase.bonus;
			animator.SetTrigger("GoodAnswer");
		}
		else
		{
			_gameManager.score -= activePhase.malus;
			animator.SetTrigger("BadAnswer");
		}
	}
}