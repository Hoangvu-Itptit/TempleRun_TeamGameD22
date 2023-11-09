using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtl : MonoBehaviour
{
    private Vector3 _distance;
    private PlayerCtl _player;

    private void Start()
    {
        _player = GameCtl.Instance.player;
        _distance = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _player.transform.position + _distance;
    }
}