using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public Image saladImage;
	public Image pizzaImage;
	public Image burgerImage;
	public Rigidbody playerRigid;
	
 	public CharacterController cc;
	
	private int pizza = 0;
	private int burger = 0;
	private int salad = 0;
	
	string targetTag;
	
	public Text foodPickup;
	public Text gameTimerText;
	public Text gameOver;
	public Text postmateText;
	public Text startText;
	
 	private float speed = 30f;
	private float gameTimer = 20;
	private float playerScore = 0;
	private float startTextTimer = 3;

	void Start()
	{
		saladImage.enabled = false;
		burgerImage.enabled = false;
		pizzaImage.enabled = false;
	
	}
 	void Update ()
	 {
		 startTextTimer -= 1 * Time.deltaTime;
		 if (startTextTimer > 0)
		 {
			 startText.text = "Walk to a restaurant to pick up food!";
		 }
		 else
		 {
			 startText.text = "";
		 }
		 gameTimer -= 1 * Time.deltaTime;
		 gameTimerText.text = gameTimer +"";
		 if (gameTimer > 0)
		 {
			 Vector3 moveDirectionRight = transform.right;
			 Vector3 moveDirectionUp = transform.up;
			 if (Input.GetKey(KeyCode.A))
			 {
				 cc.Move(moveDirectionRight * -speed * Time.deltaTime);
				 //transform.Rotate(0, 0, 180);
			 }

			 if (Input.GetKey(KeyCode.Space))
			 {
					//Test
			 }
			 if (Input.GetKey(KeyCode.D))
			 {
				 cc.Move(moveDirectionRight * speed * Time.deltaTime);
				 //transform.Rotate(0, 0, 0);
			 }

			 Ray playerRay = new Ray(transform.position, transform.up);

			 float playerRayDistance = 5f;

			 Debug.DrawRay(playerRay.origin, playerRay.direction * playerRayDistance, Color.yellow);

			 RaycastHit eyeRayHit = new RaycastHit();

			 if (Physics.Raycast(playerRay, out eyeRayHit, playerRayDistance))
			 {
				 if (eyeRayHit.collider.tag == "Pizza")
				 {
					 foodPickup.text = "Press space to pick up Pizza!";
					 if (Input.GetKey(KeyCode.Space))
					 {
						 pizza = 1;
						 pizzaImage.enabled = true;
						 targetTag = "House" + Random.Range(1,16).ToString();
						 postmateText.text = "Deliver to: " + targetTag;
					 }
				 }
				 else if (eyeRayHit.collider.tag == "Shop")
				 {
					 foodPickup.text = "Welcome to the Shops!";
					 if (Input.GetKey((KeyCode.Space)))
					 {
						 if (gameTimer > 100)
						 {
							 speed = 40f;
						 }

						 if (gameTimer > 300)
						 {
							 postmateText.text = "Bonus! You earned $200 dollars of guaranteed income!";
							 gameTimer = 500;
						 }
					 }
				 }
				 else if (eyeRayHit.collider.tag == "Burger")
				 {
					 foodPickup.text = "Press space to pick up Burger!";
					 if (Input.GetKey(KeyCode.Space))
					 {
						 burger = 1;
						 burgerImage.enabled = true;
						 targetTag = "House" + Random.Range(1,16).ToString();
						 postmateText.text = "Deliver to " + targetTag ;
					 }
				 }
				 else if (eyeRayHit.collider.tag == "Salad")
				 {
					 foodPickup.text = "Press space to pick up Salad!";
					 if (Input.GetKey(KeyCode.Space))
					 {
						 salad = 1;
						 saladImage.enabled = true;
						 targetTag = "House" + Random.Range(1,16).ToString();
						 postmateText.text = "Deliver to " + targetTag ;

					 }
				
				 }
				 else if (eyeRayHit.collider.tag == targetTag.ToString() + "")
				 {
					 postmateText.text = "Press space to deliver!";
					 if (Input.GetKey(KeyCode.Space))
					 {
						 if (salad >= 1)
						 {
							 playerScore = playerScore + 100;
							 postmateText.text = "Delivered Salad! Walk to a restaurant to pick up more food!";
							 saladImage.enabled = false;
							 salad = 0;
							 targetTag = "House17";
							 gameTimer = gameTimer + 5;
						 }
						 else if (salad == 0)
						 {
							 
						 }

						 if (burger >= 1)
						 {
							 playerScore = playerScore + 100;
							 postmateText.text = "Delivered Burger! Walk to a restaurant to pick up more food!";
							 burgerImage.enabled = false;
							 burger = 0;
							 targetTag = "House17";
							 gameTimer = gameTimer + 10;
						 }
						 else if (burger == 0)
						 {
							 
						 }

						 if (pizza >= 1)
						 {
							 playerScore = playerScore + 100;
							 postmateText.text = "Delivered Pizza! Walk to a restaurant to pick up more food!";
							 pizzaImage.enabled = false;
							 pizza = 0;
							 targetTag = "House17";
							 gameTimer = gameTimer + 15;
						 }
						 else if (pizza == 0)
						 {
							 
						 }
						 //salad = 0;
						// pizza = 0;
						 //burger = 0;
						// burgerImage.enabled = false;
						// pizzaImage.enabled = false;
						// saladImage.enabled = false;
						// postmateText.text = "Delivered! Walk to a restaurant to pick up more food!";
						// playerScore = playerScore + 100;
						// targetTag = "House17";
					 }
				 }
				 else if (eyeRayHit.collider.tag == "Enemy")
				 {
					 gameTimer = -1;
				 }
				 else
				 {
					 foodPickup.text = "";
				 }

			 }
		 }
		 else if (gameTimer > 600)
		 {
			 gameOver.text = "You Win  " + "Your Score: " + playerScore;
		 }
		 else if (gameTimer < 0)
		 {
			 gameOver.text = "Game Over   " + "Your Score: " + playerScore;
		 }
	 }
 }
