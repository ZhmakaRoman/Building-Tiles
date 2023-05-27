using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask;

    private Building _building;
    

    private void PositionObject()
    {
      
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//
        if (Physics.Raycast(ray, out var hit, 100f,_layerMask))
        {
          
            transform.position = hit.point;
        }
    }
    
    private void Update() 
   {
       PositionObject();
       if (Input.GetMouseButtonDown(0))
       {
           Destroy(gameObject.GetComponent<PlaceObject>());
       }
   }
}
