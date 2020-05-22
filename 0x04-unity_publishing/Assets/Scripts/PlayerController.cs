using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Image winLoseBG;
    public Text winLoseText;
    public Text scoreText;
    public Text healthText;
    public int health = 5;
    private int score = 0;
    [SerializeField]
    public float speed;
    public Rigidbody rb;
    void Update()
    {
        if (joystick.Horizontal >= .2f)
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        if (joystick.Horizontal <= -.2f)
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        if (joystick.Vertical >= .2f)
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (joystick.Vertical <= -.2f)
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        else
            rb.AddForce(0, 0, 0);

        if (health == 0)
        {
            DisplayLose();
            StartCoroutine(LoadScene(3));
        }
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("s"))
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        if (Input.GetKey("a"))
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("d"))
            rb.AddForce(speed * Time.deltaTime, 0, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            Destroy(other.gameObject);
            score += 1;
            SetScoreText();
        }
        if (other.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
        }
        if (other.tag == "Goal")
        {
            DisplayWin();
            StartCoroutine(LoadScene(3));
        }
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("maze");
    }
    void DisplayLose()
    {
        winLoseBG.color = new Color(1, 0, 0, 1);
        winLoseText.color = new Color(1, 1, 1, 1);
        winLoseText.text = "Game Over!";
        winLoseText.fontStyle = FontStyle.Bold;
        winLoseBG.gameObject.SetActive(true);
    }
    void DisplayWin()
    {
        winLoseBG.color = new Color(0, 1, 0, 1);
        winLoseText.color = new Color(0, 0, 0, 1);
        winLoseText.text = "You Win!";
        winLoseText.fontStyle = FontStyle.Bold;
        winLoseBG.gameObject.SetActive(true);
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
