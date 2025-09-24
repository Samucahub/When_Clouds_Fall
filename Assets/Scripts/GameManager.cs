using UnityEngine;

namespace WhenCloudsFall
{
    /// <summary>
    /// Main game manager responsible for core game state and flow control.
    /// This is a singleton that persists across scenes.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Game Settings")]
        [SerializeField] private bool isPaused = false;
        
        public bool IsPaused => isPaused;

        private void Awake()
        {
            // Implement singleton pattern
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeGame();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // Game initialization logic
            Debug.Log("When Clouds Fall - Game Manager Initialized");
        }

        private void InitializeGame()
        {
            // Set initial game settings
            Time.timeScale = 1f;
            // Add more initialization logic as needed
        }

        public void PauseGame()
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0f;
                Debug.Log("Game Paused");
            }
        }

        public void ResumeGame()
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1f;
                Debug.Log("Game Resumed");
            }
        }

        public void QuitGame()
        {
            Debug.Log("Quitting Game");
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}