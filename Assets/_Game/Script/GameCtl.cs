using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameCtl : MonoBehaviour
{
    public static GameCtl Instance;
    public PlayerCtl player;
    public GameObject roadPrefabs;
    public float distanceRoad;
    private float _posRoadX = 0f;
    private float _backSizeRoadX = 20f;
    public List<GameObject> poolRoad;
    public List<GameObject> listBarrier;
    public ParticleSystem flameParticle;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (var i = 0; i < 3; i++)
        {
            InstanceNewRoad();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            flameParticle.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            flameParticle.Stop();
        }
    }

    public void InstanceNewRoad()
    {
        var size = Random.Range(15, 25);
        var newPos = _posRoadX + _backSizeRoadX / 2f + size / 2f + distanceRoad;
        GameObject road;
        if (Vector3.Distance(player.transform.position, poolRoad[0].transform.position) > 30f)
        {
            road = poolRoad[0];
            poolRoad.RemoveAt(0);
            poolRoad.Add(road);
        }
        else
        {
            road = Instantiate(roadPrefabs);
            poolRoad.Add(road);
        }

        road.transform.localScale = new Vector3(size, 8, 5);
        road.transform.position = new Vector3(newPos, -4, 0);
        _posRoadX = newPos;
        _backSizeRoadX = size;
    }
}