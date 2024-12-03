using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISelectLevel : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject levelMenu;
    [SerializeField] private Transform buttonContent;
    [SerializeField] private int maxLevels = 110;

    private void Start()
    {
        GenerateButtons();
    }

    private void GenerateButtons()
    {
        for (int i = 1; i <= maxLevels; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonContent);
            Text buttonText = newButton.GetComponentInChildren<Text>();
            buttonText.text = i.ToString();

            int levelIndex = i;
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("level", levelIndex - 1);
                LoadLelev();
            });
        }
    }

    private void LoadLelev()
    {
        SceneManager.LoadScene(1);
    }

    public void ActiveMenuButton()
    {
        levelMenu.SetActive(true);
    }

    public void NotActiveMenuButton()
    {
        levelMenu.SetActive(false);
    }
}
