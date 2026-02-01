using System;
using UnityEngine;

internal class NpcBehaviour : MonoBehaviour
{
	public NpcDefinition npc;
	public Vector3 originalPosition;

	private void Start()
	{
		originalPosition = transform.position;
	}
}