using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private int totalScore = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        UpdateUI(0);
    }

    public void AddScore(int points)
    {
        totalScore += points;
        UpdateUI(points);
    }

    private void UpdateUI(int lastPoints)
    {
        if (scoreText != null)
        {
            if (lastPoints > 0)
                scoreText.text = $"Scor: {totalScore}\n(+{lastPoints} pct)";
            else
                scoreText.text = $"Scor: {totalScore}";
        }
    }
}