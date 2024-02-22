using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Coins;
    public TextMeshProUGUI Score;
    
    private static int _coinCount = 0;
    private static int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void hitQuestion()
    {
        _coinCount++;
        _score += 100;
        Coins.text = $"Coins\n{_coinCount}";
        Score.text = $"Score\n{_score}";
    }
}
