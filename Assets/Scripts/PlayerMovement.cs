using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
 	public CharacterController cc;
 
 	private float speed = 30f;
 	void Update () {
 		Vector3 moveDirectionForward = transform.forward;
 		if (Input.GetKey(KeyCode.W))
 		{
 		
 			cc.Move(moveDirectionForward*speed*Time.deltaTime);
 		}
 
 		if (Input.GetKey(KeyCode.A))
 		{
 			transform.eulerAngles += new Vector3(0f,-3f,0f);
 		}
 		if (Input.GetKey(KeyCode.D))
 		{
 			transform.eulerAngles += new Vector3(0f,3f,0f);
 		}
 	}
 }
