using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementControl : MonoBehaviour
{
	public float playerSpeed = 2.0f;
	private Vector2 movementInput;
	
	public CharacterController controller;
	
	private WaitForSeconds speedUpTime = new WaitForSeconds(0.5f);
	
	public void OnMove(InputAction.CallbackContext context)
	{
	movementInput = context.ReadValue<Vector2>();
	StartCoroutine(IncreaseSpeed());
	if(movementInput == Vector2.zero)
		Debug.Log("completed");
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
		Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
		controller.Move(move * Time.deltaTime * playerSpeed);
    }
	
	IEnumerator IncreaseSpeed()
	{
	Debug.Log("Coroutine started");
	yield return speedUpTime;
	Debug.Log("Coroutine ended");
	}
}
