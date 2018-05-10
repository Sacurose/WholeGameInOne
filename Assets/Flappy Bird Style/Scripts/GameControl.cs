using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is dedicated to be a game controller.
/// </summary>
public class GameControl : MonoBehaviour 
{

    #region Properties

    /// <summary>
    /// A reference to our game control script so we can access it statically.
    /// </summary>
    public static GameControl Instance { get; set; }

    /// <summary>
    /// Boolean that indicates if the game is over.
    /// </summary>
    public bool GameOver { get; set; }

    /// <summary>
    /// Instance of the parameter class.
    /// </summary>
    public Parameters Parameters { get; set; }

    #endregion

    #region Variables

    /// <summary>
    /// A reference to the UI text component that displays the player's score.
    /// </summary>
    private Text scoreText;

    /// <summary>
    /// The player's score.
    /// </summary>
    private int score = 0;

    #endregion

    #region Public Methods

    /// <summary>
    /// This method is called only once at start.
    /// </summary>
    public void Awake()
	{

        // Innitial value.
        GameOver = false;

        if (Parameters == null)
        {
            Parameters = new Parameters();
        }

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    
        
    } 

    /// <summary>
    /// Method that keeps track of the score while the game is not over.
    /// </summary>
	public void BirdScored()
	{
		//The bird can't score if the game is over.
		if (GameOver)	
			return;

		//If the game is not over, increase the score...
		score++;

        //...and adjust the score text.
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " +  score.ToString();
	}

    /// <summary>
    /// Method that innitiates GameOver + brings us back to the setting menu.
    /// </summary>
	public void BirdDied()
    {      
        SceneManager.LoadScene("SettingsMenu");
    }   

    /// <summary>
    /// Method that innitiate a scene, after the start button is clicked.
    /// </summary>
    public void OnStartClick()
    {       
        SceneManager.LoadScene("Main");

    }

    /// <summary>
    /// Method, that's used by the slider to change the value of the scroll speed, between -1.5f and -3f;
    /// </summary>
    /// <param name="speed"></param>
    public void SetSpeed(float speed)
    {      
        Debug.Log(speed);       
    }

    public void QuitGame()
    {

    }

    #endregion

}