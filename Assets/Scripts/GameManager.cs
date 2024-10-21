using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject spawner;
    [SerializeField] bool isActive;

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        spawner.SetActive(false);
        isActive = false;
        score = 0;
    }

    private void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void AddScore(int addScore)
    {
        score += addScore;
    }

    public void OnClickSpawnButton()
    {
        if (isActive == false)
        {
            spawner.SetActive(true);
            isActive = true;
        }
        else
        {
            spawner.SetActive(false);
            isActive = false;
        }
    }
}
