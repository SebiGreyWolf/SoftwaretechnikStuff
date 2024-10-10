using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] Transform startPos;
    
    int score = 0;
    private int highscore = 0;

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();

        if (highscore < score)
        {
            highscore = score;
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = startPos.position;
            RestetScores();
            other.gameObject.SetActive(true);
        }
    }
    private void RestetScores()
    {
        highscoreText.text = "Highscore: " + highscore.ToString();
        scoreText.text = "Score: 0";
        score = 0;
    }
}
