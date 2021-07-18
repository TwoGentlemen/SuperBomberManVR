using UnityEngine;

namespace NEW { 
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance; //Singleton

        [SerializeField] private GameObject panelPause;
        [SerializeField] private GameObject panelGameWin;
        [SerializeField] private GameObject panelGameOwer;

        [SerializeField] public AudioDataSO audioData;

        
        //Events
        public delegate void OnStartOrStopGame();
        public event OnStartOrStopGame onStartGame;
        public event OnStartOrStopGame onStopGame;

        public event OnStartOrStopGame onPauseGame;
        public event OnStartOrStopGame onResumeGame;


        private bool isPause = false;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            StartGame();
        }

        [ContextMenu("start game")]
        public void StartGame()
        {
            onStartGame?.Invoke();
        }

        public void StopGame()
        {
            onStopGame?.Invoke();
        }

        public void PauseGame()
        {
            if (isPause)
            {
                
                onResumeGame?.Invoke();
            }
            else
            {
                onPauseGame?.Invoke();
            }

            panelPause.SetActive(!isPause);
        }

    }
}