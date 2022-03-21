using UnityEngine;

[System.Serializable]
public class EnemySpawnSequence {

	[SerializeField]
	EnemyFactory factory = default;

	[SerializeField]
	EnemyType type = EnemyType.Medium;

	[SerializeField, Range(1, 100)]
	int amount = 1;

	[SerializeField, Range(0.1f, 10f)]
	float cooldown = 1f;
}