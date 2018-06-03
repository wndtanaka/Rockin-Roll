using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTester : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int score = Random.Range(0, 1000);
            string username = "";
            string alphabet = "abcdefghijlkmnopqrstuvwxyz";

            for (int i = 0; i < Random.Range(5,10); i++)
            {
                username += alphabet[Random.Range(0, alphabet.Length)];
            }
            HighScoreList.AddNewHighScore(username, score);
        }
    }
}
