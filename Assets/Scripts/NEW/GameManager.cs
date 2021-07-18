using UnityEngine;

namespace NEW { 
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance; //Singleton

        [SerializeField] private GameObject panelPause;
        [SerializeField] private GameObject panelGameWin;
        [SerializeField] private GameObject panelGameOwer;


        [System.Serializable]
        public class AudioData
        {
            [Header("Player audio")]
            public AudioClip damagePlayer;
            public AudioClip takeBaseBonus;
            public AudioClip takeBonusSpeed;
            public AudioClip timer;
            public AudioClip fonMusic;

            [Space(5)]
            public AudioClip gameOwer;
            public AudioClip gameWin;
            public AudioClip levelTransit;

            [Header("Enemy audio")]
            public AudioClip dudicIdle;
            public AudioClip slizenIdle;

        }

        [SerializeField] public AudioData audioData;

        
        //Events
        public delegate void OnStartOrStopGame();
        public event OnStartOrStopGame onStartGame;
        public event OnStartOrStopGame onStopGame;

        public event OnStartOrStopGame onPauseGame;
        public event OnStartOrStopGame onResumeGame;


        private bool isPause = false;

        private void Awake()
        {
            audioData = new AudioData();
            instance = this;
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