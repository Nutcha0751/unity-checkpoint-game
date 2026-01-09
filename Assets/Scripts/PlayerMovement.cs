using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    // เก็บตำแหน่ง checkpoint ล่าสุด
    private Vector3 lastCheckpoint;

    public GameManager gameManager;

    void Start()
    {
        // ตั้งค่าเริ่มต้น: จุดเริ่มเกมคือ checkpoint แรก
        lastCheckpoint = transform.position;
    }

    void Update()
    {

        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {  
            x = 1f;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            y = 1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            y = -1f;
        }

        Vector3 move = new Vector3(x, y, 0f).normalized;
        transform.position += move * speed * Time.deltaTime;
    }

    // ฟังก์ชันเรียกเมื่อชน Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ถ้าชน Checkpoint
        if (other.CompareTag("Checkpoint"))
        {
            lastCheckpoint = other.transform.position;
            Debug.Log("Checkpoint updated!");
        }

        // ถ้าชน DeadZone (ขอบ map)
        if (other.CompareTag("DeadZone"))
        {
            transform.position = lastCheckpoint;
            Debug.Log("Back to checkpoint");
        }

        // Finish
        if (other.CompareTag("Finish"))
        {
            gameManager.WinGame();
        }
    }
}
