using System;
using UnityEngine;
using System.Collections.Generic;

public class GravityB : MonoBehaviour
{

    
    
    Rigidbody rb;
     private  float G = 0.006674f;
     
     public static List<GravityB> planetLists;
     [SerializeField] private bool planet = false;
     [SerializeField] private int oebitSpeed = 1000;
     
     

     private void FixedUpdate()
     {
         foreach (var planet in planetLists)
         {
             if(planet!= this)
             Attract(planet);
         }
     }


     private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (planetLists == null)
        {
            planetLists = new List<GravityB>();
        }   
          planetLists.Add(this);
          if (!planet)
          {
              rb.AddForce(Vector3.left * oebitSpeed);
          }
            
            
    }


    void Attract(GravityB other)
    {

      Rigidbody otherRb = other.rb;

      Vector3 direction = rb.position - otherRb.position;

      float distance = direction.magnitude;

      float forceMagnnitude = G * ((rb.mass * otherRb.mass) / MathF.Pow(distance, 2));
      Vector3 finalFoce = forceMagnnitude * direction.normalized;

      otherRb.AddForce(finalFoce);



    }





}
