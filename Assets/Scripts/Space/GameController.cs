using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;

    public Text healthText;

    public string scorePrefix = string.Empty;
    public string healthPrefix = string.Empty;

    public static int score;
    public static float health = 100f;

    public static GameController instance;
    
    private void Awake() {
        instance = this;
    }

    private void Update() {
        if (scoreText != null){
            scoreText.text = scorePrefix + score.ToString();
        }
        if (healthText != null){
            healthText.text = healthPrefix + health.ToString();
        }
    }

    public static void GameOver() {
        if (instance.gameOverText != null){
            instance.gameOverText.gameObject.SetActive(true);
        }
    }

    public static void Play(){
        instance.GetComponent<AudioSource>().Play();
    }
}
