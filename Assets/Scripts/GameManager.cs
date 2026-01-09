using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject winPanel;
    public PlayerMovement player;
    public GameObject howToPlayPanel;

    void Start()
    {
        // ตอนเริ่มเกมหยุดการเล่นก่อน
        Time.timeScale = 0f;

        startPanel.SetActive(true);
        winPanel.SetActive(false);
    }

    // เรียกจากปุ่ม Start
    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // เรียกจากปุ่ม Restart
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // เรียกจาก Player ตอนชนะ
    public void WinGame()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }

    public void OpenHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }

}