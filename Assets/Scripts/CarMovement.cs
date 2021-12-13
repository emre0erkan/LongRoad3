using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{

    public GameObject failMenuUI;
    public bool alive = true;

    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 15;
    [SerializeField] float maxspeed, minspeed;
    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 9;

    private void FixedUpdate()
    {
        if (!alive) return;

        maxspeed = 50;
        minspeed = 10;
        if (speed < 20) WheelRotate.RotateAmount = 1;
        if (speed < 35 && speed > 20) WheelRotate.RotateAmount = 4;          //wheel rotating according to car's speed
        if (speed > 35) WheelRotate.RotateAmount = 15;

        if (Input.GetKey(KeyCode.W))
        {
            if (speed < maxspeed) speed = speed + 0.2f;           //speed up and down
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (speed > minspeed) speed--;
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;        //moving forward
        Vector3 horizontalMove = transform.right * horizontalInput * Time.fixedDeltaTime * horizontalMultiplier;      //moving to sides
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -3.5f, 3.5f), rb.position.y, rb.position.z);      //setting limits of the road
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");     //horizontal movement with A and D
        if (transform.position.y < -3) Die();              //restarting if we fall from the road
    }

    public void Die()
    {
        failMenuUI.SetActive(true);           //opens menu on crash
        Time.timeScale = 0;                     //time stops when there is menu
        PauseMenu.GameIsPaused = true;
        alive = false;
        // Restart the game
        //Invoke("Restart", 1);
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);       //restarts the game
        Time.timeScale = 1f;        //keeps the time going
    }

}
