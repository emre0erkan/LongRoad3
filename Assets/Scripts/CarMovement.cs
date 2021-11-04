using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{

    bool alive = true;

    public Rigidbody rb;
    [SerializeField] int speed = 15;
    int maxspeed, minspeed;
    float horizontalInput;

    private void FixedUpdate()
    {
        if (!alive) return;

        maxspeed = 50;
        minspeed = 10;
        if (speed < 20) WheelRotate.RotateAmount = 1;
        if (speed < 35 && speed > 20) WheelRotate.RotateAmount = 4;
        if (speed > 35) WheelRotate.RotateAmount = 15;

        if (Input.GetKey(KeyCode.W))
        {
            if (speed < maxspeed) speed++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (speed > minspeed) speed--;
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * Time.fixedDeltaTime * 13;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -3) Die();
    }

    public void Die()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
