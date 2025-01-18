using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject goalItem;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoalReached()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        endText.SetActive(true);
        goalItem.SetActive(false);

    }

  
}
