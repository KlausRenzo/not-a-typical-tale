using UnityEngine;
using Random = UnityEngine.Random;

namespace Bluender.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private int range = 2;

		public void OnMouseEnter()
		{
			var randomVector = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));

			this.transform.position = randomVector;
		}
	}
}