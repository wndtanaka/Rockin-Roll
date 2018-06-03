using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitHighScore : MonoBehaviour
{
    const string privateCode = "tlTR0xWBqU6dMeX8wr_sTA7C4PP9IcKEKLKIXcdggGTw";
    const string publicCode = "5b1294f0191a8a0bcc3a3167";
    const string webURL = "http://dreamlo.com/lb/";

    static SubmitHighScore instance;

    private void Awake()
    {
        instance = this;
    }

    public static void AddNewHighScore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighScore(username, score));
    }
    IEnumerator UploadNewHighScore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;
    }
}
