using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int pointsPerHit = 100;      
    void Start()
    {
        UpdateScoreUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Points"))
        {
            score += pointsPerHit;

            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
