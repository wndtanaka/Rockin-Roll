using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallOfFame : MonoBehaviour
{
    public Text[] highscoresText;
    HighScoreList highscoreManager;

    private void Start()
    {
        for (int i = 0; i < highscoresText.Length; i++)
        {
            highscoresText[i].text = i + 1 + ". Fetching Data...";
        }
        highscoreManager = GetComponent<HighScoreList>();
        StartCoroutine(RefreshHighScores());
    }

    public void OnHighScoresDownloaded(HighScoreList.HighScore[] highScoreLists)
    {
        for (int i = 0; i < highscoresText.Length; i++)
        {
            highscoresText[i].text = i + 1 + ". ";
            if (highScoreLists.Length > i)
            {
                highscoresText[i].text += highScoreLists[i].username + " - " + highScoreLists[i].score;
            }
        }

    }

    IEnumerator RefreshHighScores()
    {
        while (true)
        {
            highscoreManager.DownloadHighScores();
            yield return new WaitForSeconds(30);
        }
    }
}
