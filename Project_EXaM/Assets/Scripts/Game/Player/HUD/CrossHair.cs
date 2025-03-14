﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vkimow.Unity.Tools.Single;

public class CrossHair : MonoSingleton<CrossHair>
{
    private bool active;
    private Texture2D crossHair;
    [SerializeField]
    private Texture2D crossSimple;
    [SerializeField]
    private Texture2D crossAction;
    [SerializeField]
    private Texture2D crossSpeak;
    [SerializeField]
    private Texture2D crossCant;
    [SerializeField]
    private Texture2D crossEye;


    private void Awake()
    {
        SwitchHair("Simple");
        InputManager.OnGameTypeChanged += SwitchEnabled;
    }

    public void Enable(bool option)
    {
        active = option;
    }

    private void OnGUI()
    {
        if(active)
            GUI.DrawTexture(new Rect(Screen.width / 2 - 31, Screen.height / 2 - 31, 64, 64), crossHair);
    }

    private void SwitchHair(string cross)
    {
        switch(cross)
        {
            case "Simple":
                {
                    crossHair = crossSimple;
                    break;
                }
            case "Action":
                {
                    crossHair = crossAction;
                    break;
                }
            case "Speak":
                {
                    crossHair = crossSpeak;
                    break;
                }
            case "Cant":
                {
                    crossHair = crossCant;
                    break;
                }
            case "Eye":
                {
                    crossHair = crossEye;
                    break;
                }
        }
    }

    public void SelectHair()
    {
        if (Player.Instance.Select.SelectingIsActive)
        {
            switch (Player.Instance.Select.SelectedObject.tag)
            {
                /* case "Scholar":
                     {
                         SwitchHair("Speak");
                         break;
                     }
                     */
                case "Computer":
                case "Elevator":
                case "Door":
                case "ActionObject":
                    {
                        SwitchHair("Action");
                        break;
                    }
                default:
                    {
                        SwitchHair("Simple");
                        break;
                    }
            }
        }
        else
        {
            SwitchHair("Simple");
        }
    }


    private void SwitchEnabled()
    {
        switch (InputManager.GameType)
        {
            case InputManager.GameplayType.FirstPerson:
                {
                    Enable(true);
                    break;
                }
            default:
                {
                    Enable(false);
                    break;
                }
        }
    }

}
