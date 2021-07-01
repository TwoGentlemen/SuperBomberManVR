using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTest { 
    public class MoveObjectToGrid : MonoBehaviour
    {
        private Vector2Int currentIndexCell;

        private void Start()
        {
            currentIndexCell = GridManager.instance.GetIndexCell(transform.position);
            GridManager.instance.SetObjectInCell(gameObject);
        }

        private void FixedUpdate()
        {
            var index = GridManager.instance.GetIndexCell(transform.position);

            if(index != currentIndexCell)
            {
                GridManager.instance.SetObjectInCell(gameObject);
                GridManager.instance.SetObjectInCell(null,currentIndexCell);
                currentIndexCell = index;
            }
           
        }
    }
}