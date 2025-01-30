using TMPro;
using UnityEngine;

public class highscore : MonoBehaviour
{
    public int highScore = 0;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        this.GetComponent<TextMeshProUGUI>().text = "High Score:" + highScore;
    }

    public void SetHighScore(int score)
    {
        highScore = score;
        this.GetComponent<TextMeshProUGUI>().text = "High Score:" + highScore;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }
}
