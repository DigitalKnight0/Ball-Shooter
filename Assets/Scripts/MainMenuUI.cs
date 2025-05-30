using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    public Text errorText;
    public InputField nameInput;
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadData();
        string highScoreName = GameManager.Instance.highScoreName;
        int highScore = GameManager.Instance.highScore;
        bestScoreText.text = "Best Score: " + highScoreName + ", " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        string name = nameInput.text;
        if (string.IsNullOrEmpty(name))
        {
            errorText.gameObject.SetActive(true);
            return;
        }
        GameManager.Instance.playerName = name;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
