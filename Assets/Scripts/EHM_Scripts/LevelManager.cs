using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Space] [Header("Level Prefab")]
    public GameObject levelPrefabForPool;
    private int _levelIndex = 5; //Because of the first level is already spawned
    private GameObject envSpawnPoint;
    [SerializeField] private float levelLength = 90f;
    private Vector3 nextSpawnPosition;
    [Space] [Header("Level Pool")]
    [SerializeField] private int poolSize = 5;
    private Queue<GameObject> levelPool;
    [Space] [Header("Player Settings")]
    private GameObject _player;

    private void Start()
    {
        envSpawnPoint = GameObject.FindWithTag("Env");
        _player = GameObject.FindWithTag("Player");
        InitializePool();
    }

    private void Update()
    {
        if (!GameManager.instance.LoadNextLevel) return;
        UpdateLevels(_player.transform.position);
    }

    private void InitializePool()
    {
        levelPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject level = Instantiate(levelPrefabForPool, envSpawnPoint.transform);
            level.name = "Level-" + i;
            level.transform.position = nextSpawnPosition + new Vector3(0, 0, i * levelLength);
            levelPool.Enqueue(level);
            Debug.LogWarning("level pool" + i + " created");
        }
    }

    public void MoveNextLevel()
    {
        if (_levelIndex >= 0)
        {
            GameObject level = levelPool.Dequeue();
            level.name = "LevelIndex-" + _levelIndex;
            levelPool.Enqueue(level);
            level.transform.position = nextSpawnPosition + new Vector3(0, 0, _levelIndex * levelLength);
            _levelIndex++;
        }
    }

    // Oyuncunun pozisyonuna göre yeni level parçalarını aktifleştirmek için bu metodu kullanın
    public void UpdateLevels(Vector3 playerPosition)
    {
        MoveNextLevel();
        GameManager.instance.LoadNextLevel = false;
    }
}