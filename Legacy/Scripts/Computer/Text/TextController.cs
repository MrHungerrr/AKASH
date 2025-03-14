﻿using UnityEngine;
using System.Collections;
using Searching;
using TMPro;

public class TextController : MonoBehaviour
{


    [HideInInspector]
    public InputFieldText input { get; private set; }


    public void Setup()
    {
        Transform text = transform.Find("Text");
        input = text.GetComponentInChildren<InputFieldText>();
        input.SetInputField();
    }

    public void Reset()
    {
        input.Reset();
    }

}
