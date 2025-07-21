using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : Controller
{
    [SerializeField] private Joystick movementJoystick;
    private TaskPoint _taskPoint;
    private float _speed = 1;

    private void Update()
    {
        // Joystick movement
        if (movementJoystick != null)
        {
            Vector2 moveDirection = new Vector2(movementJoystick.Horizontal, movementJoystick.Vertical);
            transform.Translate(moveDirection * _speed * Time.deltaTime);
        }

        // Handle interactions
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        bool interactionPressed = false;
        Vector3 inputPosition = Vector3.zero;

        // Check for space key (for editor testing) - use TaskPoint if available
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_taskPoint != null)
            {
                _taskPoint.OrderAction();
            }
            return;
        }

        // Check for touch input (Android)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                interactionPressed = true;
                inputPosition = touch.position;
            }
        }

        // Check for mouse click (for editor testing)
        if (Input.GetMouseButtonDown(0))
        {
            interactionPressed = true;
            inputPosition = Input.mousePosition;
        }

        if (interactionPressed)
        {
            // Convert screen position to world position and check for CookingPoint
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputPosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            
            if (hit.collider != null)
            {
                CookingPoint cookingPoint = hit.collider.GetComponent<CookingPoint>();
                if (cookingPoint != null)
                {
                    cookingPoint.StartCooking();
                }
            }
        }
    }

    public override void Activate()
    {
        enabled = true;
        base.Activate();
    }

    public override void Deactivate() 
    { 
        enabled = false;
        base.Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out _taskPoint))
        {
            GetComponent<EmotionalPerson>().ShowEmoje(EmojiTypes.Glad);
            _taskPoint.EnterPointAction();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TaskPoint taskPoint) && taskPoint == _taskPoint)
        {
            _taskPoint.ExitPointAction();
            _taskPoint = null;
        }
    }
}
