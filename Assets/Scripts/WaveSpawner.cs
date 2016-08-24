using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public Transform spawnPoint;
	public Text countdownText;
	public float timeBetweenWaves = 5f;
	private float countdown;
	public float timeBetweenEnemies = .2f;
	private float waveIndex;

	void Start(){
		countdown = 2f;
		waveIndex = 1;
	}

	void Update(){
		if (countdown <= 0f) {
			// spawn
			StartCoroutine("SpawnWave");
			countdown = timeBetweenWaves;
		}


		countdown -= Time.deltaTime;
		countdownText.text = Mathf.Round(countdown).ToString ();
	}

	IEnumerator SpawnWave(){

		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (timeBetweenEnemies);
		}

		waveIndex++;
		yield return null;
	}

	void SpawnEnemy(){
		Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
	}

}
