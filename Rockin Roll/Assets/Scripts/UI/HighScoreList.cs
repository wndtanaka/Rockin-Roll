using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreList : MonoBehaviour
{
    const string privateCode = "tlTR0xWBqU6dMeX8wr_sTA7C4PP9IcKEKLKIXcdggGTw";
    const string publicCode = "5b1294f0191a8a0bcc3a3167";
    const string webURL = "http://dreamlo.com/lb/";

    public HighScore[] highScores;
    static HighScoreList instance;
    HallOfFame hallOfFame;

    private void Awake()
    {
        instance = this;
        hallOfFame = GetComponent<HallOfFame>();
    }

    public static void AddNewHighScore(string username, float score)
    {
        instance.StartCoroutine(instance.UploadNewHighScore(username, score));
    }

    IEnumerator UploadNewHighScore(string username, float score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            DownloadHighScores();
        }
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighScores()
    {
        StartCoroutine(DownloadHighScoreFromDatabase());
    }

    IEnumerator DownloadHighScoreFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScore(www.text);
            hallOfFame.OnHighScoresDownloaded(highScores);
        }
        else
        {
            print("Error downloading: " + www.error);
        }
    }

    void FormatHighScore(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highScores = new HighScore[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            float score =float.Parse(entryInfo[1]);
            highScores[i] = new HighScore(username, score);
            print(highScores[i].username + ": " + highScores[i].score);
        }
    }

    public struct HighScore
    {
        public string username;
        public float score;

        public HighScore(string _username, float _score)
        {
            username = _username;
            score = _score;
        }
    }
}
