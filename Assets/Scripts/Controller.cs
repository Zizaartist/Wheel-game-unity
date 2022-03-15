using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    public enum GameState
    {
        start,
        play,
        end
    }

    public TMP_Text ScoreLabel;
    public TMP_Text FinalScoreLabel;
    public Score score;

    public UnityEvent Started;
    public UnityEvent Ended;

    public GameState state = GameState.start;

    private void Update() {
        if(state == GameState.play)
        {
            ScoreLabel.text = $"Score: {(int) score.TimePlayed}";
            score.TimePlayed += Time.deltaTime;
        }
        else if(state == GameState.end)
            FinalScoreLabel.text = $"Your score: {(int) score.TimePlayed}";
    }

    public void Play()
    {
        if(state != GameState.play)
        {
            score.TimePlayed = 0;
            state = GameState.play;
            Started.Invoke();
        }
    }

    public void End()
    {
        if(state == GameState.play)
        {
            state = GameState.end;
            Ended.Invoke();
        }
    }
}
