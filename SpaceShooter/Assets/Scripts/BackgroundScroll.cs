using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public SpriteRenderer BG;
    public SpriteRenderer BGMirror;
    private float _BGSpeed = .5f;
    private Vector3 _BGPosition;
    

    private void Awake()
    {
        _BGPosition = new Vector3(22.81f, -3.7594f, 1);
    }

    private void Update()
    {
        BG.transform.position = new  Vector3(BG.transform.position.x - (Time.deltaTime * _BGSpeed), BG.transform.position.y);
        BGMirror.transform.position = new Vector3(BGMirror.transform.position.x - (Time.deltaTime *_BGSpeed), BGMirror.transform.position.y);
        if (BGMirror.transform.position.x <= -23.7366)
        {
            BGMirror.transform.position = _BGPosition;
        }

        if (BG.transform.position.x <= -23.7366)
        {
            BG.transform.position = _BGPosition;
        }
    }
}
