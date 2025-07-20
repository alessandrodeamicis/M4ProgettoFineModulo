using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int _coinsGoal = 3;
    [SerializeField] private UnityEvent _onCoinsGoalReached;
    private Text _coinsText;
    private int _currentCoins = 0;

    private void Start()
    {
        GameObject coinsTextGameObject = GameObject.FindGameObjectWithTag("CoinsText");
        if (coinsTextGameObject != null)
        {
            _coinsText = coinsTextGameObject.GetComponent<Text>();
            UpdateText();
        }
    }

    public void AddCoin()
    {
        _currentCoins += 1;

        UpdateText();

        if (_currentCoins == _coinsGoal)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void UpdateText()
    {
        _coinsText.text = $"Monete: {_currentCoins.ToString()}/{_coinsGoal.ToString()}";
    }

}

