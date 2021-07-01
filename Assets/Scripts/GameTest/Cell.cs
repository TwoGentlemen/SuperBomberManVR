using UnityEngine;

namespace GameTest { 
    public class Cell 
    {
        private Vector3 position = Vector3.zero;
        private GameObject objectInCell = null;

        public Cell(Vector3 pos)
        {
            position = pos;
        }

        public bool GetActive()
        {
            if (objectInCell) { return true; }
            return false;
        }

        public Vector3 GetPosition()
        {
            return position;
        }

        public GameObject GetObject()
        {
            var obj = objectInCell;
            objectInCell = null;
            return obj;
        }

        public void SetObject(GameObject gameObj)
        {
            objectInCell = gameObj;
        }
    }
}
