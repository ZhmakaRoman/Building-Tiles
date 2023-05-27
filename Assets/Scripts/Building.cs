using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

   
    public Vector2Int _size = Vector2Int.one; //Размер сетки
   // [SerializeField]
    public Renderer[] _MeshRenderer;

   

  //  public void Colir()
  //  {
  //      _MeshRenderer.material.color = Color.green;
  //  }

    // public Renderer _Renderer;
   public void SetTransparent(bool available)
   {
       for (var i = 0; i < _MeshRenderer.Length; i++)
       {
           if (available)
           {
               _MeshRenderer[i].material.color = Color.green;
           }
           else
           {
               _MeshRenderer[i].material.color = Color.red;
           }
       }
   }

   public void SetNormal()
   {
       for (var i = 0; i < _MeshRenderer.Length; i++)
       {
           _MeshRenderer[i].material.color = Color.white;
       }
   }
    private void OnDrawGizmos()
    {
        for (int x = 0; x < _size.x ; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                Gizmos.color = new Color(0.88f, 0.3f, 1, 0.3f);
                Gizmos.DrawCube(transform.position + new Vector3(x,0,y),new Vector3(1,0.1f,1));
            }
        }
    }
}
