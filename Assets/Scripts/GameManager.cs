using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject winPanel;
    public PlayerMovement player;
    public GameObject howToPlayPanel;
    public GameObject quitConfirmPanel;

    void Start()
    {
        // ตอนเริ่มเกมหยุดการเล่นก่อน
        Time.timeScale = 0f;

        startPanel.SetActive(true);
        winPanel.SetActive(false);

        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }

        if (quitConfirmPanel != null)
        {
            quitConfirmPanel.SetActive(false);
        }
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
        Time.timeScale = 0f;
    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // เรียกตอนกดปุ่ม Quit
    public void ShowQuitConfirm()
    {
        Debug.Log("Quit button clicked");

        if (quitConfirmPanel != null)
        {
            quitConfirmPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // ปุ่ม NO
    public void CancelQuit()
    {
        if (quitConfirmPanel != null)
        {
            quitConfirmPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    // ปุ่ม YES
    public void ConfirmQuit()
    {
        Debug.Log("Quit Game");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // กลับไปหน้า Start Menu ระหว่างเล่น
    public void BackToStartMenu()
    {
        // หยุดเกม
        Time.timeScale = 0f;

        // ปิด panel อื่นทั้งหมด
        winPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        quitConfirmPanel.SetActive(false);

        // เปิดหน้า Start
        startPanel.SetActive(true);

        // รีเซ็ตตำแหน่ง Player
        if (player != null)
        {
            player.ResetToStart();
        }
    }

}