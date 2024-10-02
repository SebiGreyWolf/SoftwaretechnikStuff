using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public Transform startPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = startPos.position;
            highscoreText.text = scoreText.text;
            scoreText.text = "Highscore: 0";
            other.gameObject.SetActive(true);
        }
    }
}
