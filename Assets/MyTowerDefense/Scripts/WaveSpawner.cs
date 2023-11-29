using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Wave[] waves;
    public Transform SpawnPoint;

    public static int EnemiesAlive = 0;

    private int waveIndex = 0;
    public float TimeBetweenWave = 5f;
    public float countdown = 2f;
    public Text wavecountdowntext;

    public GameManager gameManager;

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            this.enabled = false;
            gameManager.WinLevel();
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWave;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        wavecountdowntext.text = string.Format("{0:00.00}", countdown);
    }


    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Debug.Log("Wave Incomming!");

        Wave wave = waves[waveIndex];
        EnemiesAlive = wave.count;

        for(int i=0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1 / wave.rate);
        }
        waveIndex++;

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
    }
}
