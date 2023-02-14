using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Threading.Tasks;

public class MovementControl : MonoBehaviour
{
	public float playerSpeed = 2.0f;
	private float baseSpeed = 2.0f;
	private float speedIncrease = 0.1f;
	private bool canMove = false;
	public TMP_Text speedText;
	private Vector2 movementInput;
	
	public CharacterController controller;
	
	private WaitForSeconds speedUpTime = new WaitForSeconds(0.1f);

    public bool useCorotuine = false;
    public bool useAsync = false;
	
	public void OnMove(InputAction.CallbackContext context)
	{
		if(context.started)
		{
			Debug.Log("action started");
			canMove = true;
			movementInput = context.ReadValue<Vector2>();
            if (useAsync)
                StartSpeedIncrease();
            else if (useCorotuine)
                StartCoroutine(IncreaseSpeed());
		}
		if(context.canceled)
		{
			Debug.Log("action canceled");
			canMove = false;
			movementInput = Vector2.zero;
		}
		
		//StartCoroutine(IncreaseSpeed());
		
		//if(movementInput == Vector2.zero)
		//	Debug.Log("completed");
	}

    // Update is called once per frame
    void Update()
    {
        
		Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
		controller.Move(move * Time.deltaTime * playerSpeed);
		speedText.text = "Speed: " + playerSpeed.ToString();
    }
	
	IEnumerator IncreaseSpeed()
	{
		Debug.Log("Coroutine started");
        while (canMove)
        {
			playerSpeed += 0.1f;
            yield return speedUpTime;
        }

		playerSpeed = baseSpeed;
        Debug.Log("Coroutine ended");
	}

	public async Task AsyncSpeedIncrease()
    {
		Debug.Log("Async started");
		while (canMove)
		{
			if (playerSpeed >= 1000 || playerSpeed <= 0)
				speedIncrease *= -1;
			playerSpeed += speedIncrease;
			await Task.Yield();
		}

		playerSpeed = baseSpeed;
		Debug.Log("Async ended");
	}

	public async void StartSpeedIncrease()
    {
		await AsyncSpeedIncrease();
	}

    public void ActivateCoroutineUse()
    {
        Debug.Log("Switching to coroutine");
        useCorotuine = true;
        useAsync = false;
        playerSpeed = baseSpeed;
    }

    public void ActivateAsyncUse()
    {
        Debug.Log("Switching to async");
        useCorotuine = false;
        useAsync = true;
        playerSpeed = baseSpeed;
    }
}
