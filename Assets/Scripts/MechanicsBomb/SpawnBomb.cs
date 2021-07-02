using UnityEngine;

namespace GameTest
{
    public class SpawnBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bomb;

        public float coolDownTime = 5;
        public float coolDownTimer = 0f;



        private void Update()
        {

            if (coolDownTimer > 0)
            {
                coolDownTimer -= Time.deltaTime;
            }

            if (coolDownTimer < 0)
            {
                coolDownTimer = 0;
            }
        }


        public void PlantBomb()
        {
            if (coolDownTimer > 0) return;


            Vector3 bombPosition = transform.position + transform.forward * 2; //������� ����� � ������ ����, ���� ������� �����

            var indexCelllBomb = GridManager.instance.GetIndexCell(bombPosition); //���������� ������ ������ � ������� ����� ��������� �����
            var indexCellPlayer = GridManager.instance.GetIndexCell(transform.position); //���������� ������ ������ � ������� ��������� �����

            if (!GridManager.instance.isEmptyCell(indexCelllBomb))
            { Debug.Log("������ ������!"); return; }

            var sum = indexCelllBomb + indexCellPlayer;

            if (sum.x == 2 * indexCellPlayer.x || sum.y == 2 * indexCellPlayer.y)
            {
                var bom = Instantiate(bomb, GridManager.instance.GetPosCell(indexCelllBomb), Quaternion.identity);
                GridManager.instance.SetObjectInCell(bom);
                coolDownTimer = coolDownTime;
            }
            else
            {
                Debug.Log("������ ������� �� ���������!");
            }
        }


    }
}