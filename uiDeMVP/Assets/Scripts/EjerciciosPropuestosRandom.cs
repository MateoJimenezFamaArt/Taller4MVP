using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EjerciciosPropuestosRandom : MonoBehaviour
{

    //Cover Up answer
    public GameObject Panel;

    // Array of images to choose from
    public Sprite[] images;

    // Reference to the Image component on the UI
    public Image imageUI;

    // Reference to the Text component for displaying the timer
    public TextMeshProUGUI timerText;

    // Time before the placeholder function is called (in seconds)
    public float MaxTimer;

    [SerializeField] private float timeRuning;

    // Flag to check if timer is running
    private bool isTimerRunning = false;

    //Showing Bool
    public bool Next_Exercise = false;

    //Next Button
    public GameObject ButtonForNext;


    public void NextAnswer()
    {
        Next_Exercise = true;
        Debug.Log("Next Exercise es true");

        if (Next_Exercise == true)
        {
            Debug.Log("Next Exercise es true y ejecutara start timer");
            StartTimer();
        }
    }


    // Placeholder function to be called when time is up
    void OnTimeUp()
    {
        // Implement your action here
        Panel.SetActive(false);
        timerText.text = "Se acabo el tiempo!!!";
        ButtonForNext.GetComponent<Button>().interactable = true;
        Debug.Log("Estamos en timeup");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Start the timer when the script starts
        StartTimer();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if timer is running
        if (isTimerRunning)
        {
            // Update the timer display
            timerText.text = "Tiempo para ejercicio: " + Mathf.RoundToInt(timeRuning) + "s";

            // Decrease the time limit
            timeRuning -= Time.deltaTime;

            // Check if time has run out
            if (timeRuning <= 0f)
            {
                // Stop the timer
                isTimerRunning = false;

                // Call the placeholder function
                OnTimeUp();
            }
        }
    }

    // Function to start the timer and display a random image
    public void StartTimer()
    {
        // Choose a random image from the array
        int randomIndex = Random.Range(0, images.Length);
        imageUI.sprite = images[randomIndex];

        // Reset the timer
        timeRuning = MaxTimer;

        // Start the timer
        isTimerRunning = true;

        // Cover up answer
        Panel.SetActive(true);

        //Button for next
        ButtonForNext.GetComponent<Button>().interactable= false;

        //Reset Value
        Next_Exercise = false;
    }

}
