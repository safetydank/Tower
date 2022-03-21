using UnityEngine;

[CreateAssetMenu]
public class EnemyWave : ScriptableObject {

	[SerializeField]
	EnemySpawnSequence[] spawnSequences = {
		new EnemySpawnSequence()
	};
}