using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

namespace NEW { 
    public class Player : MonoBehaviour
    {
        public static Player instanstance; //Singleton 

        
        [System.Serializable]
        private class PlayerData 
        { 
            [Header("Player parametors")]
            [SerializeField] public float moveSpeed = 1;
            [SerializeField] public float maxMoveSpeed = 10;
            [SerializeField] public int countRoller = 0; //rollers - increase the speed

            [Space(10)]
            [SerializeField] public int heathPoint = 10; // number of lives untile the end of the game
            [SerializeField] public float timeLive = 120; //in seconds 

            [Space(10)]
            [SerializeField] public int radiusExplosion = 1; // by cell in forward, back, right, left
            [SerializeField] public int countBomb = 1;  //number of bombs at a time
            [SerializeField] public TypeBomb typeCurrentBomb = TypeBomb.defaultBomb;

            [Space(10)]
            [SerializeField] public int score = 0;
        }

        [SerializeField] private Transform gameOwerPos;
        [SerializeField] private Transform gameWinPos;

        [SerializeField] private PlayerData playerData;

        [Space(20)]
        [Header("Input Controlls")]
        [SerializeField] private InputActionProperty shootInput;
        
        [Space(20)]
        [Header("Health Point UI")]
        [SerializeField] private GameObject PanelLiveTime;
        [SerializeField] private GameObject heartUI;
        [HideInInspector] private Stack<GameObject> hearts = new Stack<GameObject>();

        //------EVENTS---------
        public delegate void ChangePlayerParametors(int value);
        public event ChangePlayerParametors changeHealthPointAction;
        public event ChangePlayerParametors changeRadiusExplosionAction;
        public event ChangePlayerParametors changeCountBombAction;
        public event ChangePlayerParametors changeCountRollerAction;

        public delegate void ChangePlayerSpeed(float value);
        public event ChangePlayerSpeed changeMoveSpeedAction;

        public delegate void GameOwertDelegate();
        public event GameOwertDelegate gameOwerAction;
        //------End event---------

        private Vector3 startPos;

        private SpawnBomb spawnBomb;
        private bool isStartGame = false;
        private void Awake()
        {
            if(instanstance != null)
            { 
                playerData = instanstance.playerData;
                Debug.Log("Copy PlayerData");
            }
            else
            {
                playerData = new PlayerData();
                Debug.Log("New PlayerData");               
            }
            instanstance = this;

            
            spawnBomb = GetComponent<SpawnBomb>();
            if(spawnBomb == null) { Debug.LogError("Not SpawnBomb");}
        }

        private void OnEnable()
        {
          
        }

        private void StopGame()
        {
            isStartGame = false;
        }

        private void StartGame()
        {
            isStartGame = true;
        }

        private void Start()
        {
            GameManager.instance.onStartGame += StartGame;
            GameManager.instance.onStopGame += StopGame;

            shootInput.action.performed += OnShootAction;

            InitializeHealthPoint_UI();

            changeCountBombAction?.Invoke(playerData.countBomb);
            changeHealthPointAction?.Invoke(playerData.heathPoint);
            changeRadiusExplosionAction?.Invoke(playerData.radiusExplosion);
            changeMoveSpeedAction?.Invoke(playerData.moveSpeed);
            changeCountRollerAction?.Invoke(playerData.countRoller);

            startPos = transform.position;


        }

        private void OnShootAction(InputAction.CallbackContext obj)
        {
            if(!isStartGame)
                return;

            spawnBomb.PlantBomb();

        }

        //Taking damage player 
        public void Damage()
        {
            playerData.heathPoint--; 
            changeHealthPointAction?.Invoke(playerData.heathPoint); // action player damage
            
            hearts.Pop().SetActive(false);

            transform.position = startPos;

            if(playerData.heathPoint <= 0)
            {
                //GAME OWER
                Debug.Log("GameOver");
                GameManager.instance.StopGame();
                GameOwer();
            }
        }

        private void GameOwer()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void InitializeHealthPoint_UI()
        {
            if(PanelLiveTime == null || heartUI == null)
            {
                Debug.Log("Not panel live time!");
                return;
            }

            for (int i = 0; i < playerData.heathPoint; i++)
            {
                var imageHeart = Instantiate(heartUI);
                imageHeart.transform.SetParent(PanelLiveTime.transform);
                imageHeart.transform.localPosition = Vector3.zero;
                imageHeart.transform.localScale = Vector3.one;
                hearts.Push(imageHeart.gameObject);
            }
        }

        #region PowerUp
        public void SetSpeed(TypeSetMode mode, float value = 0.5f)
        {
            switch (mode)
            {
                case TypeSetMode.Add:
                    playerData.moveSpeed = (playerData.moveSpeed+value<=playerData.maxMoveSpeed) ? playerData.moveSpeed + value : playerData.maxMoveSpeed;
                    playerData.countRoller = (playerData.moveSpeed + value <= playerData.maxMoveSpeed) ? playerData.countRoller+1 : playerData.countRoller;
                    break;
                case TypeSetMode.Set:
                    playerData.moveSpeed = value <= playerData.maxMoveSpeed ? value : playerData.maxMoveSpeed;
                    playerData.countRoller = 0;
                    break;
                case TypeSetMode.ResetDefault:
                    playerData.moveSpeed = 1;
                    playerData.countRoller = 0;
                    break;
                default:
                    break;
            }

            changeCountRollerAction?.Invoke(playerData.countRoller);
            changeMoveSpeedAction?.Invoke(playerData.moveSpeed);
        }

        public void SetCountBomb(TypeSetMode mode, int value = 1)
        {
            switch (mode)
            {
                case TypeSetMode.Add:
                    playerData.countBomb+=value;
                    break;
                case TypeSetMode.Set:
                    playerData.countBomb = value;
                    break;
                case TypeSetMode.ResetDefault:
                    playerData.countBomb = 1;
                    break;
                default:
                    break;
            }

            changeCountBombAction?.Invoke(playerData.countBomb);
        }

        public void SetCountRadiusExplosion(TypeSetMode mode, int value = 1)
        {
            switch (mode)
            {
                case TypeSetMode.Add:
                    playerData.radiusExplosion += value;
                    break;
                case TypeSetMode.Set:
                    playerData.radiusExplosion = value;
                    break;
                case TypeSetMode.ResetDefault:
                    playerData.radiusExplosion = 1;
                    break;
                default:
                    break;
            }

            changeRadiusExplosionAction?.Invoke(playerData.radiusExplosion);
        }

        public void SetCurrentTypeBomb(TypeBomb typeBomb)
        {
            playerData.typeCurrentBomb = typeBomb;
        }

        public float GetSpeed() { return playerData.moveSpeed;}
        public int GetRadiusExplosion() { return playerData.radiusExplosion;}
        public int GetHealtPoint() { return playerData.heathPoint;}
        public TypeBomb GetTypeCurrentBomb() { return playerData.typeCurrentBomb;}
        public float GetTimeLive() { return playerData.timeLive;}
        public int GetCountBomb() { return playerData.countBomb;}
        #endregion

    }
}
