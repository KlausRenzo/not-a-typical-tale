using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Block_definition", menuName = "NATT/Block Definition", order = 0)]
public class BlockDefinition : ScriptableObject
{
	public int blockNumber;
	public int minimumScore;
	[Range(0, 300)] public float maskRadius;
	public List<BlockPhaseDefinition> phases;
}