﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracks : MonoBehaviour
{   /* 
    public GameObject[] obstacles;
    public Vector2 numberOfObstacles;
    public List<GameObject> newObstacles;
    // Use this for initialization
    void Start()
    {
        int newNumberOfObstacles = (int)Random.Range(numberOfObstacles.x, numberOfObstacles.y);
        for (int i = 0; i < newNumberOfObstacles; i++)
        {
            newObstacles.Add(Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform));
            newObstacles[i].SetActive(false);
            PositionateObstacles();
        }
    }

    void PositionateObstacles()
    {
        for (int i = 0; i < newObstacles.Count; i++)
        {
            float posZMin = (95f / newObstacles.Count) + (95f / newObstacles.Count) * i;
            float posZMax = (95f / newObstacles.Count) + (95f / newObstacles.Count) * i + 1;
            newObstacles[i].transform.localPosition = new Vector3(0, 0, Random.Range(posZMin, posZMax));
            newObstacles[i].SetActive(true);
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = new Vector3((transform.position.z + -142 * 2), 0, 0);
            //transform.position = new Vector3(0, 0, (transform.position.z + -31.77878f * 2));
            //PositionateObstacles();
        }
    }
}
