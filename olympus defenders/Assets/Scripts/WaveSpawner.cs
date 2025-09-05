using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab; // enemy prefab to spawn

    public Transform spawnPoint; // where the enemy will spawn

    public float timeBetweenWaves = 5f; // time between waves
    private float countdown = 2f; // countdown timer

    public Text waveCountdownText; // text to display countdown timer

    private int waveIndex = 0; // current wave index

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave()); // start spawning wave
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; // decrease countdown timer

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = "WAVE IN: " + string.Format("{0:00.00}", countdown); // update countdown text
    }

    IEnumerator SpawnWave() // coroutine to spawn wave
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); // wait 0.5 seconds between spawns
        } 

        
    }

    void SpawnEnemy () // function to spawn a single enemy
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}