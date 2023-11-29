using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Transform winText;
    public Transform loseText;
    public TextMesh scoreText;
    public Transform floatingScorePrefab;

    public AudioClip shootClip;
    public AudioClip explodeClip;
    public int currentScore;

    public void YouWin()
    {
        winText.gameObject.SetActive(true);
        Invoke("LoadTitle", 5);
    }

    public void YouLose()
    {
        loseText.gameObject.SetActive(true);
        Invoke("LoadTitle", 5);
    }

    public void PlayShootSound()
    {
        this.GetComponent<AudioSource>().PlayOneShot(shootClip);
    }

    public void PlayExplodeSound()
    {
        this.GetComponent<AudioSource>().PlayOneShot(explodeClip);
    }

    void LoadTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    public void AddScore(int add , Vector3 pos)
    {
        currentScore = currentScore + add;
        scoreText.text = "Score : " + currentScore;

        //สร้างคะแนนเด้งๆ
        Transform clone = Instantiate(floatingScorePrefab);
        pos.z = 4;
        clone.position = pos;

        clone.Find("Text").GetComponent<TextMesh>().text = ""+add;

        //เก็บข้อมูล highscore
        int savedHighscore = PlayerPrefs.GetInt("highscore");
        if(currentScore > savedHighscore)
        {
            PlayerPrefs.SetInt("highscore", currentScore);
        }
    }
}
