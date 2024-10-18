﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 0.5f;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(0.1f, 2.0f);
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        StartCoroutine(Baller());
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {


        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);
    }

    IEnumerator Baller()
    {
        while (true)
        {
            spawnInterval = Random.Range(0.1f, 2.0f);
            yield return new WaitForSeconds(spawnInterval);
            SpawnRandomBall();
        }

    }

}