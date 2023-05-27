using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MapBuilder : MonoBehaviour
{
    /// <summary>
    /// Данный метод вызывается автоматически при клике на кнопки с изображениями тайлов.
    /// В качестве параметра передается префаб тайла, изображенный на кнопке.
    /// Вы можете использовать префаб tilePrefab внутри данного метода.
    /// </summary>
   

    public Vector2Int GridSize = new Vector2Int(10,10);
    private Building[,] _grid;
    private Building _tilePrefab;
   
    
    

    public void StartPlacingTile(Building tilePrefab)
    {
    
        if (_tilePrefab != null)
        {
            Destroy(_tilePrefab.gameObject);
        }
        _tilePrefab = Instantiate(tilePrefab);
    }

    private void Awake()
    {
        
        _grid = new Building[GridSize.x, GridSize.y];
    }

    private void Update()
    {
        if (_tilePrefab != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out var hit))
            {
                Vector3 worldPosition = ray.GetPoint(hit);

                var x = Mathf.RoundToInt(worldPosition.x);
                var y = Mathf.RoundToInt(worldPosition.z);
                bool available = true;
                if (x < 0 || x > GridSize.x - _tilePrefab._size.x) available = false;
                if (y < 0 || y > GridSize.y - _tilePrefab._size.y) available = false;

                _tilePrefab.transform.position = new Vector3(x +1, 0, y+1);
                
               _tilePrefab.SetTransparent(available);
                if (available && Input.GetMouseButtonDown(0))
                {
                    _tilePrefab.SetNormal();
                    _tilePrefab = null;
                    
                  

                }
            }
        }
    }
}