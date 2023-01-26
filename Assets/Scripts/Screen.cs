using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    public TMP_Text lvl;
    public Button RestartButton;
    public Button NextlvlButton;
    void Start()
    {
        lvl.text = $"Your level is {SceneManager.GetActiveScene().buildIndex + 1}";
        RestartButton.onClick.AddListener(ReloadLevel);
        NextlvlButton.onClick.AddListener(LoadLevel);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void LoadLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
