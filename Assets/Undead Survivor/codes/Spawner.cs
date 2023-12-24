using Goldmetal.UndeadSurvivor;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    public BossData[] bossData;
    public float levelTime;

    int level;
    float timer;
    private bool BossSpawned = false;

    private HUD hud;
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        levelTime = GameManager.instance.maxGameTime / spawnData.Length;

    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length -1);

        if(timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }

        if (!BossSpawned && GameManager.instance.gameTime >= 10f)
        {
            Boss();
            BossSpawned = true;
        }

    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }

    void Boss()
    {
        // 랜덤한 보스 데이터를 가져옴
        BossData boss = bossData[Random.Range(0, bossData.Length)];

        // 보스 몬스터를 풀에서 가져와서 소환
        GameObject enemy = GameManager.instance.pool.Get(3);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(boss);

        GameManager.instance.bossSpawn = true;
        GameManager.instance.SetBossHealth(boss.health);
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
    public int exp;
}
[System.Serializable]
public class BossData
{
    public int spriteType;
    public int health;
    public float speed;
    public int exp;
}