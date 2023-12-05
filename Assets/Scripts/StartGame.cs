using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    public InputField inputField;
    public Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        // Set a listener for the button click event
        myButton.onClick.AddListener(SavePlayerName);
    }

    void SavePlayerName()
    {
        if (inputField != null && !string.IsNullOrEmpty(inputField.text))
        {
            PlayerPrefs.SetString("PlayerName", inputField.text);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField != null && !string.IsNullOrEmpty(inputField.text))
        {
            myButton.interactable = true;
        }
        else
            myButton.interactable = false;
    }

    public void StarttheGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
