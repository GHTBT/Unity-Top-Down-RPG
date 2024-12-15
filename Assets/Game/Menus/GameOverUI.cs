using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;
public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreValueText;

    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health.OnPlayerDeath += activateGameObject;
        Health.OnEnemyDeath +=countScore;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnDestroy() 
    {
        Health.OnPlayerDeath -= activateGameObject;
        Health.OnEnemyDeath -=countScore;
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void countScore()
    {
        score++;
    }

    private void activateGameObject()
    {
        this.gameObject.SetActive(true);
        scoreValueText.text = score.ToString();
    }
}
