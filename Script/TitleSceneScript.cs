using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneScript : MonoBehaviour
{
    public TextMesh highscoreText;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "High score: "+highscore;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
        }
    }
}
