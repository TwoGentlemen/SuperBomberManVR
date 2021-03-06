using UnityEngine;


    public class Cell 
    {
        private Vector3 position = Vector3.zero;
        private GameObject objectInCell = null;
        private GameObject marker = null;

        MeshRenderer meshMarker;

        public Cell(Vector3 pos)
        {
            position = pos;
        }
        public Cell(Vector3 pos,GameObject _marker)
        {
            position = pos;
            marker = _marker;

            InicializeMarker();
        }

        public bool isEmptyCell()
        {
            if (objectInCell != null) { return false; }
            return true;
        }

    public bool isEmptyCellNotPlayer()
    {
        if (objectInCell == null) { return true; }
        if (objectInCell.CompareTag("Player")) { return true;}

        return false;
    }

    public Vector3 GetPosition()
        {
            return position;
        }

        public GameObject GetObject()
        {
            return objectInCell;
        }

        public void SetObject(GameObject gameObj)
        {
            if (objectInCell != null)
            if (objectInCell.CompareTag("Portal")) { return;}

            objectInCell = gameObj;
            ChangeMarker();
        }

        private void InicializeMarker()
        {
            if(marker == null) { return; }
            meshMarker = marker.GetComponent<MeshRenderer>();
        }

        private void ChangeMarker()
        {
            if(marker == null || meshMarker == null) { return;}
            if (objectInCell)
            {
                meshMarker.material.color = Color.red;
            }
            else
            {
                meshMarker.material.color = Color.green;
            }
        }
    }

