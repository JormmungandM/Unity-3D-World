using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    private GameObject menuContent;
    // Start is called before the first frame update
    void Start()
    {
        GameSettings.LoadSettigns();
        ShowSettings();
        menuContent = GameObject.Find("MenuContent");

        Time.timeScale = 0.0f;
        menuContent.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (menuContent.activeInHierarchy)
            {
                menuContent.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                menuContent.SetActive(true);
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void ShowSettings()
    {
        GameObject.Find("InvZoomToggle").GetComponent<Toggle>().isOn = GameSettings.InverseWheelZoom;
        GameObject.Find("InvVerticalToggle").GetComponent<Toggle>().isOn = GameSettings.VerticalInverted;
        GameObject.Find("SensitivitySlider").GetComponent<Slider>().value = GameSettings.Sensitivity;
        GameObject.Find("DifficultyValue").GetComponent<TMPro.TextMeshProUGUI>().text = GameSettings.Difficulty.ToString();
        GameObject.Find("CoinPriceValue").GetComponent<TMPro.TextMeshProUGUI>().text = GameSettings.CoinValue.ToString();

        GameObject.Find("GameTimerToggle").GetComponent<Toggle>().isOn = GameSettings.GameTimerEnabled;
        GameObject.Find("CoinDistanceToggle").GetComponent<Toggle>().isOn = GameSettings.CoinDistanceEnabled;
        GameObject.Find("DirectionHintToggle").GetComponent<Toggle>().isOn = GameSettings.DirectionHintsEnabled;
        GameObject.Find("DisapearTimerToggle").GetComponent<Toggle>().isOn = GameSettings.CoinTimeoutEnabled;
        GameObject.Find("StaminaToggle").GetComponent<Toggle>().isOn = GameSettings.StaminaEnabled;

        GameObject.Find("SoundsSlider").GetComponent<Slider>().value = GameSettings.EffectsVolume;
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = GameSettings.MusicVolume;
        GameObject.Find("MuteAllToggle").GetComponent<Toggle>().isOn = GameSettings.AllSoundsDisabled;
    }
    public void CloseButtonClick()
    {
        menuContent.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void ExitButtonClick()
    {
        if (EditorUtility.DisplayDialog("Really?", "Exit the game", "Yes", "No"))
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    public void InverseWheelChanged(bool value)
    {
        //Debug.Log(value);
        GameSettings.InverseWheelZoom = value;
    }
    public void InverseVerticalChanged(bool value)
    {
        //Debug.Log(value);
        GameSettings.VerticalInverted = value;
    }
    public void SensitivityChanged(float value)
    {
        GameSettings.Sensitivity = value;
    }
    public void SoundEffectsChanged(float value)
    {
        GameSettings.EffectsVolume = value;
    }
    public void MusicChanged(float value)
    {
        GameSettings.MusicVolume = value;
    }
    public void MuteChanged(bool value)
    {
        GameSettings.AllSoundsDisabled = value;
    }
    public void DisplayGameTimerChanged(bool value)
    {
        GameSettings.GameTimerEnabled = value;
        ShowSettings();
    }
    public void DisplayCoinDistanceChanged(bool value)
    {
        GameSettings.CoinDistanceEnabled = value;
        ShowSettings();
    }
    public void DisplayDirectionHintChanged(bool value)
    {
        GameSettings.DirectionHintsEnabled = value;
        ShowSettings();
    }
    public void DisplayDisapearTimerChanged(bool value)
    {
        GameSettings.CoinTimeoutEnabled = value;
        ShowSettings();
    }
    public void DisplayStaminaChanged(bool value)
    {
        GameSettings.StaminaEnabled = value;
        ShowSettings();
    }

}
