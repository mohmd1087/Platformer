
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
   public TextMeshProUGUI Time;
    
    private const int StartTime = 100;
    
    private int _timerValue;
    private float _timeOfRestart;
    
    public static bool OutOfTime;
    // Start is called before the first frame update
    void Start()
    {
        RestartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (OutOfTime)
            return;
        var timePassed = UnityEngine.Time.realtimeSinceStartup - _timeOfRestart;
        _timerValue = (int)(StartTime - timePassed);
        Time.text = $"TIME\n{_timerValue}";
        if (_timerValue == 0)
        {
            OutOfTime = true;
            Debug.Log("FAIL: Player out of time!");
        }
    }

    private void RestartTimer()
    {
        _timerValue = StartTime;
        _timeOfRestart = UnityEngine.Time.realtimeSinceStartup;
    }
}