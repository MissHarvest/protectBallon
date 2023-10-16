using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GameObject prefab_SquareRain;
    
    public GameObject GameoverPanel;
    public Text timerText;
    public Text thisRecordText;
    public Text bestRecordText;

    float aliveSec;


    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("SpawnSquareRain", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        aliveSec += Time.deltaTime;
        timerText.text = string.Format("{0:#0.00}", aliveSec);
    }

    void SpawnSquareRain()
    {
        Instantiate(prefab_SquareRain);
    }

    public void Gameover()
    {
        Time.timeScale = 0.0f;

        if(PlayerPrefs.HasKey("bestScore"))
        {
            PlayerPrefs.SetFloat("bestScore", PlayerPrefs.GetFloat("bestScore") < aliveSec ? aliveSec : PlayerPrefs.GetFloat("bestScore"));
        }
        else
        {
            PlayerPrefs.SetFloat("bestScore", aliveSec);
        }

        thisRecordText.text = string.Format("{0:#0.00}", aliveSec);
        bestRecordText.text = string.Format("{0:#0.00}", PlayerPrefs.GetFloat("bestScore"));
        GameoverPanel.SetActive(true);
    }

    public void ClickRestart()
    {
        SceneManager.LoadScene("Main");
    }

}
