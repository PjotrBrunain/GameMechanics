using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BasicCharacter
{
    const string MOVEMENT_HORIZONTAL = "MovementHorizontal";
    const string MOVEMENT_VERTICAL = "MovementVertical";
    const string GROUND_LAYER = "Ground";
    const string PRIMARY_FIRE = "PrimaryFire";
    const string SECONDARY_FIRE = "SecondaryFire";
    const string RELOAD = "Reload";

    private Plane _cursorMovementPlane;

    protected override void Awake()
    {
        base.Awake();
        _cursorMovementPlane = new Plane(Vector3.up, transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        HandleMovementInput();
        HandleFireInput();
    }

    void HandleMovementInput()
    {
        if (_movementBehavior == null)
            return;

        //movement
        float horizontalMovement = Input.GetAxis(MOVEMENT_HORIZONTAL);
        float verticalMovement = Input.GetAxis(MOVEMENT_VERTICAL);

        Vector3 movement = horizontalMovement * Vector3.right + verticalMovement * Vector3.forward;

        _movementBehavior.DesiredMovementDirection = movement;

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 positionOfMouseInWorld = transform.position;

        RaycastHit hitInfo;
        if (Physics.Raycast(mouseRay, out hitInfo, 100000.0f, LayerMask.GetMask(GROUND_LAYER)))
        {
            positionOfMouseInWorld = hitInfo.point;
        }    
        else
        {
            _cursorMovementPlane.Raycast(mouseRay, out float distance);
            positionOfMouseInWorld = mouseRay.GetPoint(distance);
        }

        _movementBehavior.DesiredLookatPoint = positionOfMouseInWorld;
    }

    void HandleFireInput()
    {
        if (_shootingBehavior == null) return;

        //Fire
        if (Input.GetAxis(PRIMARY_FIRE) > 0.0f)
            _shootingBehavior.PrimaryFire();
        if (Input.GetAxis(SECONDARY_FIRE) > 0.0f)
            _shootingBehavior.SecondaryFire();

        if (Input.GetAxis(RELOAD) > 0.0f)
            _shootingBehavior.Reload();
    }
}
