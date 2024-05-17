using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_controller : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    float x;
    float y;

    public int winning_score;
    public int score;
    public int live;
    public GameObject Win_Text;
    public GameObject enemy;
    public Collider bad;
    public GameObject Error_Text;
    public GameObject time_Text; 
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject Try_Text;
    public GameObject yes_btn;
    public GameObject no_btn;
    public GameObject ball; 
    public AudioSource collecting; 
    public AudioClip collecting_sound; 
    public AudioSource Win; 
    public AudioSource roll; 
    public AudioSource fail; 
    public AudioSource failing; 
    public AudioClip win_sound;
    bool die= false;
    bool Win_bool = false;
    private follow classAInstance;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has fallen below the y-coordinate of -10
        if (transform.position.y < -30f)
        {
            live--;
            rb.position = new Vector3(0.5f, 0.2f, 1f);
           

        }
       
        
        if (live == 0)
        {
            ball.SetActive(false);
            time_Text.SetActive(true);
            Try_Text.SetActive(true);
            yes_btn.SetActive(true);
            no_btn.SetActive(true);
            failing.Play();
            fail.Stop();

        }

        switch (live)
        {
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
            case 2:
                heart1.SetActive(false);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
            case 1:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(true);
                break;
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
        }
        if( die==true)
        {
            live--;
            Invoke("loadlive", 2f);
            die = false;

        }

       // OnTriggerEnter(bad);
    }

    private void FixedUpdate()
    {
        // Get the horizontal and vertical input from the player
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    
        // Apply force to the Rigidbody based on the input
        rb.AddForce(x * speed, 0, y * speed);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "Bug"
        if (other.CompareTag("bug_tag") && Win_bool==false)
        {
            // Deactivate the collided bug object
            other.gameObject.SetActive(false);
            // Increment the score
            score++;
            collecting.Play();
            //classAInstance = GetComponent<follow>();
            //classAInstance.speed+=100;

            // Check if the player has reached the winning score
            if (score >= winning_score)
            {
                speed = 0;
                // Activate the win text GameObject
                Win.Play();
                Win_Text.SetActive(true);
                ball.SetActive(false);
                Invoke("LoadNextScene", 4f);
                Win_bool = true;

            }


        }
        
        
        else if (other.CompareTag("bad"))
        {
            die = true;
            // Deactivate the collided bug object
            fail.Play();
            ball.SetActive(false);
            Update();
            //Error_Text.SetActive(true);
            //Try_Text.SetActive(true);
            //yes_btn.SetActive(true);
            //no_btn.SetActive(true);
           

        }
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene("Game 1");
    } void loadlive()
    {
        ball.SetActive(true);
        rb.position = new Vector3(0.5f, 0.2f, 1f);
        enemy.transform.position = new Vector3(-18.5f, -18.5f, -19.9f);


    }
}
