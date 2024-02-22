//
// using TMPro;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.Serialization;
//
//
// public class hit : MonoBehaviour
// {
//     public TextMeshProUGUI Coins;
//     public TextMeshProUGUI Score;
//     
//     private static int _coinCount = 0;
//     private static int _score = 0;
//     // Start is called before the first frame update
//    
//
//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             Debug.Log("Mouse clicked");
//             RaycastHit hit;
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             if (Physics.Raycast(ray, out hit, 50.0f))
//             {
//                 if (hit.transform.CompareTag("brick"))
//                 {
//                     // BrickDestroyed();
//                     _score += 100;
//                     // Score.text = $"Score\n{_score}";
//                     // Coins.text = $"Coins\n{_coinCount}";
//                     Destroy(hit.collider.gameObject);
//                     
//                     // coins.text = $"SCORE\n{_score}";
//                 }
//                 else if (hit.transform.CompareTag("Question"))
//                 {
//                     // hitQuestion();
//                     _coinCount++;
//                     _score += 100;
//                     // Coins.text = $"Coins\n{_coinCount}";
//                     // Score.text = $"Score\n{_score}";
//                 }
//                 
//             }
//         }
//         Score.text = $"Score\n{_score}";
//         Coins.text = $"Coins\n{_coinCount}";
//     }
//     // public void hitQuestion()
//     // {
//     //     _coinCount++;
//     //     _score += 100;
//     //     Coins.text = $"Coins\n{_coinCount}";
//     //     Score.text = $"Score\n{_score}";
//     // }
//
//     // public static void BrickDestroyed()
//     // {
//     //     _score += 100;
//     // }
//
//     // void coinCollected()
//     // {
//     //     _coinCount++;
//     //     //_score += 100;
//     //     Coins.text = $"SCORE\n{_coinCount}";
//     // }
// }
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hit : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI scoreText;

    private static int _coinCount = 0;
    private static int _score = 0;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            Debug.Log("Mouse clicked");
          
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

             if (Physics.Raycast(ray, out hit, 50.0f))
            {
                HandleHitObject(hit.transform.gameObject);
            }
           
        }

        UpdateUI();
    }

    private void HandleHitObject(GameObject hitObject)
    {
        if (hitObject.CompareTag("brick"))
        {
            _score += 100;
            Destroy(hitObject);
            Debug.Log("Brick");
        }
        else if (hitObject.CompareTag("Question"))
        {
            _coinCount++;
            _score += 100;
            Debug.Log("Question");
        }
    }

    private void UpdateUI()
    {
        coinsText.text = $"Coins\n{_coinCount/32}";
        scoreText.text = $"Score\n{_score/320}";
    }
}

