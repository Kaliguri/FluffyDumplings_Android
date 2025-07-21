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

        // Keep space key for interactions
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_taskPoint != null)
            {
                _taskPoint.OrderAction();
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
        else
        {
            CookingPoint cookingPoint;
            if(collision.gameObject.TryGetComponent(out cookingPoint))
            {
                cookingPoint.StartCooking();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out _taskPoint))
        {
            _taskPoint.ExitPointAction();
            _taskPoint = null;
        }
    }
}
