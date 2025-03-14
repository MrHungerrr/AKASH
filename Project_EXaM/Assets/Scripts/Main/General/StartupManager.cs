﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTime;
using GameTime.Action;
using Overwatch;
using MultiTasking;
using PostProcessing;
using Vkimow.Unity.Tools.Single;
using Computers;
using Exam;
using GOAP;
using AI.Scholars;
using System.Threading;
using Levels.Concrete;
using Levels;

public class StartupManager : MonoSingleton<StartupManager>
{

    private bool setuped = false;


    private void Awake()
    {
        Setup();
    }

    private void Start()
    {
        FuckThisShit();
    }

    private void FuckThisShit()
    {
        LevelManager.Instance.SetLevel<Level_1>();
        InputManager.SwitchGameInput(InputManager.GameplayType.FirstPerson);

        //ExamManager.Instance.ResetExam(15, 0, 2);
        //ExamStarter.Instance.Interact();
    }


    private void Setup()
    {
        if (!setuped)
        {
            setuped = true;
            AudioManager.Instance.Setup();
            PostProcessManager.Setup();
            InputManager.Setup();
            OverwatchManager.Setup();
            ThreadTaskQueuer.Setup();
            ComputerManager.Instance.Setup();
            MenuManager.Instance.Setup();
            ScholarManager.Instance.Setup();
        }
    }
}
