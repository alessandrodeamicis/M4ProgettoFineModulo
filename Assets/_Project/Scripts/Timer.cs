using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _duration = 60.0f;
    [SerializeField] private Text _timerText; 

    void Update()
    {
        _duration -= Time.deltaTime;
        _timerText.text = ((int)_duration).ToString() + "s";

        if (_duration <= 0.0f)
        {
            TimerEnded();
        }
    }

    void TimerEnded()
    {
        SceneManager.LoadScene("LoseScene");
    }
}