using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUi : MonoBehaviour
{
    public Button StartButton, SettingsButton;

    private void Start()
    {
        StartButton.onClick.AddListener(StartButtonPressed);
        SettingsButton.onClick.AddListener(SettingsButtonPressed);
    }

    public void StartButtonPressed()
    {

        SceneManager.LoadScene("Scenes/Hub");

    }

    public void SettingsButtonPressed()
    {
        
    }
}
