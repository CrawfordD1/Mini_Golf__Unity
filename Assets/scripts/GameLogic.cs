using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour{

	public Text strokeText;
	public GameObject player;
	public PlayerController playerScript;
	public GameObject scoreTracker;
	public ScoreTracker trackerScript;
	public int currentHole;

		// called zero
		void Awake()
		{
			currentHole = 0;
			DontDestroyOnLoad (gameObject);
		}

		// called first
		void OnEnable()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		// called second
		void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			scoreTracker = GameObject.Find("ScoreTracker");
			strokeText = GameObject.Find("StrokeText").GetComponent<Text>();
			trackerScript = (ScoreTracker)FindObjectOfType(typeof(ScoreTracker));
			trackerScript.resetStrokes ();
			playerScript = player.GetComponent<PlayerController>();
		}

		// called third
		void Start()
		{
		
		scoreTracker.SetActive (false);
		}

		// called when the game is terminated
		void OnDisable()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}



	// Update is called once per frame
	public void Update () {

		if(Input.GetKeyDown(KeyCode.Tab)){
			scoreTracker.SetActive(true);
		}

		if(Input.GetKeyUp(KeyCode.Tab)){
			scoreTracker.SetActive(false);
		}

		if (Input.GetMouseButtonUp (0)) {
			trackerScript.addStroketoCurrent ();
			strokeText.text = (trackerScript.getStrokes ()).ToString();
		}

	}

	public void loadNextLevel(){
		trackerScript.updateScore (currentHole);
		scoreTracker.SetActive(true);
		int newScene = SceneManager.GetActiveScene ().buildIndex + 1;
		SceneManager.LoadScene (newScene);
		currentHole += 1; 
	}
}

