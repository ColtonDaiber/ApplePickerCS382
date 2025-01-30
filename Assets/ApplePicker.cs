using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public GameObject scoreGO;
    int score = 0;
    List<GameObject> baskets = new List<GameObject>();
    public highscore highscore;
    public AppleTree appleTree;
    int currentRound = 1;
    public TextMeshProUGUI currentRoundText;
    public GameObject resetButton;

    void Start()
    {
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;

            tBasketGO.GetComponent<Basket>().applePicker = this;

            baskets.Add(tBasketGO);
        }
    }

    public void AddScore()
    {
        score++;
        scoreGO.GetComponent<TextMeshProUGUI>().text = "Score:" + score;
        
        if(score > highscore.highScore)
        {
            highscore.SetHighScore(score);
        }

        if( score % 5 == 0 ) IncreaseRound();
    }

    public void MissedApple()
    {
        if(baskets.Count == 0) return;

        Destroy(baskets[baskets.Count-1]);
        baskets.RemoveAt(baskets.Count-1);

        DestroyAllApples();

        if(baskets.Count == 0)
        {
            GameOver();
        }
    }

    void DestroyAllApples()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");

        foreach(GameObject apple in apples)
        {
            Destroy(apple);
        }
    }

    void IncreaseRound()
    {
        // DestroyAllApples();
        currentRound++;
        appleTree.speed *= 1.3f;
        appleTree.secondsBetweenAppleDrops *= 0.75f;

        currentRoundText.text = "Round:"+currentRound;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        DestroyAllApples();

        currentRoundText.text = "Game Over!";
        resetButton.SetActive(true);

        for(int i = baskets.Count-1; i >= 0; i--)
        {
            Destroy(baskets[i]);
            baskets.RemoveAt(i);
        }
    }
}
