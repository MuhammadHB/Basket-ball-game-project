using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public int Score;
    public int winScore = 5;  // النقاط المطلوبة للفوز
    public Text ScoreText;
    public Text WinText;
    public Text TimerText;
    public Text GameOverText;
    public float gameTime = 60f; // الوقت بالثواني

    private bool gameEnded = false;
    private Rigidbody2D[] allRigidbodies;

    private void Start()
    {
        WinText.text = "";  // تفريغ النص في البداية
        GameOverText.text = "";  // تفريغ النص في البداية
        allRigidbodies = FindObjectsOfType<Rigidbody2D>(); // العثور على جميع الأجسام المتحركة
        StartCoroutine(GameTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameEnded)
        {
            AddScore();
        }
    }

    void AddScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (Score >= winScore)
        {
            WinText.text = "You Win!";
            gameEnded = true;
            StopAllCoroutines();  // إيقاف المؤقت عند الفوز
            StopAllMovements();   // إيقاف جميع الأجسام المتحركة
        }
    }

    IEnumerator GameTimer()
    {
        float remainingTime = gameTime;
        while (remainingTime > 0 && !gameEnded)
        {
            TimerText.text = "Time: " + remainingTime.ToString("F2"); // عرض الوقت المتبقي بواقع منزلتين عشريتين
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }

        if (!gameEnded)
        {
            TimerText.text = "Time: 0.00";
            GameOver();
        }
    }

    void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameEnded = true;
        StopAllMovements();  // إيقاف جميع الأجسام المتحركة
    }

    void StopAllMovements()
    {
        foreach (var rb in allRigidbodies)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true; // جعلها جسم ثابت
        }
    }
}
