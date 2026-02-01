using UnityEngine;

public class AnswerState : StateMachineBehaviour
{
	private GameManager _gameManager;
	private float startTime;
	private BlockPhaseDefinition _phase;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		_gameManager = ServiceManager.GetService<GameManager>();
		startTime = Time.time;
		_phase = _gameManager.activePhase;
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate(animator, stateInfo, layerIndex);

		if (Time.time - startTime > _phase.time)
		{
			_gameManager.score -= _phase.malus;
			animator.SetTrigger("BadAnswer");
		}

		var answer = _gameManager.player.AnsweringUpdate();
		if (answer == null)
			return;
		
		Debug.Log(">" + answer.state + "<");
		if (answer.state == _phase.requiredState)
		{
			_gameManager.score += _phase.bonus;
			animator.SetTrigger("GoodAnswer");
		}
		else
		{
			_gameManager.score -= _phase.malus;
			animator.SetTrigger("BadAnswer");
		}
	}
}