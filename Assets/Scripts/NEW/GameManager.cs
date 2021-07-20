using System;
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

        public delegate void OnChangeCountEnemy(int value);
        public event OnChangeCountEnemy changeCountEnemyAction;

        private bool isPause = false;
        private int quantityEnemy = 0;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            StartGame();
            CountingEnemy();
        }

        #region Enemys
        private void CountingEnemy()
        {
            var enemys = GameObject.FindGameObjectsWithTag("Enemy");
            quantityEnemy = enemys.Length;
            
            changeCountEnemyAction?.Invoke(quantityEnemy);
        }

        public void DeathEnemy()
        {
            quantityEnemy--;

            if(quantityEnemy <= 0)
                UnlockNextLevel();
        }

        private void UnlockNextLevel()
        {
            
        }

        #endregion

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