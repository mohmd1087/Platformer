
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


public class hit : MonoBehaviour
{
    public TextMeshProUGUI Coins;
    public TextMeshProUGUI Score;
    
    private static int _coinCount = 0;
    private static int _score = 0;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.name == "brickbox(Clone)")
                {
                    // BrickDestroyed();
                    Destroy(hit.collider.gameObject);
                    _score += 100;
                    Score.text = $"Score\n{_score}";
                    Coins.text = $"Coins\n{_coinCount}";
                    // coins.text = $"SCORE\n{_score}";
                }
                else if (hit.transform.name == "questionmark(Clone)")
                {
                    _coinCount++;
                    _score += 100;
                    Coins.text = $"Coins\n{_coinCount}";
                    Score.text = $"Score\n{_score}";
                }
            }
        }
    }

    // public static void BrickDestroyed()
    // {
    //     _score += 100;
    // }

    // void coinCollected()
    // {
    //     _coinCount++;
    //     //_score += 100;
    //     Coins.text = $"SCORE\n{_coinCount}";
    // }
}
