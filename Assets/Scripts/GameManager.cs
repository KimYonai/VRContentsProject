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

    [Header("Value")]
    [SerializeField] int score;
    [SerializeField] int highScore;
    [SerializeField] float remainTime;
    [SerializeField] bool isActive;
    public bool isTimeOver;

    [Header("Reference")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject spawner;
    [SerializeField] AudioSource scoreSound;
    [SerializeField] AudioSource timeoutSound;
    Coroutine timeOut;

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

        spawner.SetActive(false);
        isActive = false;
    }

    private void Start()
    {
        remainTime = 60;
        score = 0;
    }

    private void Update()
    {
        if (isActive == true)
        {
            remainTime -= Time.deltaTime;
        }

        if (remainTime <= 0 && isActive == true)
        {
            remainTime = 0;
            timeoutSound.Play();
            spawner.SetActive(false);
            isActive = false;
        }

        if (score > highScore)
        {
            highScore = score;
        }

        timeText.text = "Remain Time\n" + remainTime.ToString();
        scoreText.text = "Score : " + score.ToString();
        highScoreText.text = "High Score : " + highScore.ToString();
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreSound.Play();
    }

    public void OnClickSpawnButton()
    {
        if (isActive == false)
        {
            remainTime = 60;
            spawner.SetActive(true);
            isActive = true;
        }
        else
        {
            spawner.SetActive(false);
            isActive = false;
        }
    }

    IEnumerator TimeOut()
    {
        timeoutSound.Play();
        yield return null;
    }
}
