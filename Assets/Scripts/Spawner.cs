using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] zombieSpawns;
    public GameObject[] chestSpawns;
    public int currentWave;
    public int currentZombiesKilled;
    public int scalingFactor = 3;
    public int zombiesRequiredForNextWave;
    public float spawnInterval = 5f; // Adjust this value to set the time between zombie spawns
    public TextMeshProUGUI zombieKillCount;
    public GameObject[] zombies;
    public GameObject[] chests;

    private Coroutine spawnCoroutine;

    void Start()
    {
        currentWave = 1;
        currentZombiesKilled = 0;
        zombiesRequiredForNextWave = scalingFactor * currentWave;

        // Start the coroutine when the game begins
        spawnCoroutine = StartCoroutine(SpawnZombiesCoroutine());
    }

    void Update()
    {
        zombieKillCount.text = "" + PlayerPrefs.GetInt("ZombiesKilled");
        waveTracker();
        spawnChests(checkChests());
    }

    public void waveTracker()
    {
        currentZombiesKilled = PlayerPrefs.GetInt("ZombiesKilled");
        if (currentZombiesKilled > zombiesRequiredForNextWave)
        {
            currentWave++;
            zombiesRequiredForNextWave = scalingFactor * currentWave;

            // Stop the current coroutine and start a new one for the next wave
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = StartCoroutine(SpawnZombiesCoroutine());
        }
    }

    public IEnumerator SpawnZombiesCoroutine()
    {
        int zombiesSpawned = 0;

        while (zombiesSpawned < zombiesRequiredForNextWave)
        {
            // Spawn a zombie
            int zombieToSpawnIndex = Random.Range(0, zombies.Length);
            int placeToSpawnIndex = Random.Range(0, zombieSpawns.Length);
            Instantiate(zombies[zombieToSpawnIndex], zombieSpawns[placeToSpawnIndex].transform.position, Quaternion.identity);

            // Update counters
            zombiesSpawned++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public bool checkChests()
    {
        if (PlayerPrefs.GetInt("GoldChestOpened") == 1 && PlayerPrefs.GetInt("BlackChestOpened") == 1 && PlayerPrefs.GetInt("GreenChestOpened") == 1 && PlayerPrefs.GetInt("RedChestOpened") == 1)
        {
            PlayerPrefs.SetInt("GoldChestOpened", 0);
            PlayerPrefs.SetInt("BlackChestOpened", 0);
            PlayerPrefs.SetInt("GreenChestOpened", 0);
            PlayerPrefs.SetInt("RedChestOpened", 0);
            return true;
        }

        return false;
    }
    public void spawnChests(bool allChestsFound)
    {
        if (allChestsFound)
        { 
            List<GameObject> usedSpawnPoints = new List<GameObject>();

            foreach (GameObject chestSpawnPoint in chestSpawns)
            {
                if (!usedSpawnPoints.Contains(chestSpawnPoint))
                {
                    int chestToSpawnIndex = Random.Range(0, chests.Length);
                    Instantiate(chests[chestToSpawnIndex], chestSpawnPoint.transform.position, Quaternion.identity);
                    usedSpawnPoints.Add(chestSpawnPoint);
                }
            }

            usedSpawnPoints.Clear();
        }
    }

}
