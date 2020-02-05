using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_Move : MonoBehaviour
{
   private Vector3 _position;
   public float xSpeed, zSpeed, gravity;
   private CharacterController _controller;

   private void Start()
   {
      _controller = GetComponent<CharacterController>();
   }

   private void Update()
   {
      _position.Set(Input.GetAxis("Horizontal") * xSpeed, -gravity * Time.deltaTime, Input.GetAxis("Vertical") * zSpeed);
      
      _position = _controller.transform.TransformDirection(_position);
      _controller.Move(_position * Time.deltaTime);
   }
}
