using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 1f;
    [SerializeField] private Transform moveTo;

    private float movementTicks = 0;
    bool isMoving = false;

    private void Movement()
    {
        movementTicks += (Time.deltaTime * movementSpeed);
        if (movementTicks <= 0.5f) return;
        movementTicks = 0;

        var positionFrom = transform.position;
        var positionTo = moveTo.position;

        bool isInX = positionFrom.x == positionTo.x;
        bool isInY = positionFrom.y == positionTo.y;

        if (isInX && isInY)
        {
            isMoving = false;
            Debug.Log("Finish!");
            return;
        }

        isMoving = true;

        // right | left
        string directionX = (transform.position.x - positionTo.x) <= 0 ? "right" : "left";
        // up | down 
        string directionY = (transform.position.y - positionTo.y) <= 0 ? "up" : "down";

        // Переменная для рандомного движения по осям
        // 0 = x; 1 = y
        float randomDirection = Random.Range(0, 2);
        if (isInX) randomDirection = 1f;
        if (isInY) randomDirection = 0f;

        Debug.Log("Go " + (randomDirection == 1f ? "x" : "y"));

        // 10% шанс отправить не туда
        bool isGoStray = Random.Range(0, 10) == 0;
        if (isGoStray)
        {
            if (randomDirection == 0f)
            {
                directionX = directionX == "right" ? "left" : "right";
            }
            else
            {
                directionY = directionY == "up" ? "down" : "up";
            }

            Debug.Log("Go stray");
        }

        Vector2 addVector = new Vector2(0, 0);

        if (randomDirection == 0f)
        {
            addVector.x = directionX == "right" ? 0.25f : -0.25f;
        }
        else
        {
            addVector.y = directionY == "up" ? 0.25f : -0.25f;
        }

        transform.position = new Vector2(transform.position.x, transform.position.y) + addVector;
    }

    private void FixedUpdate()
    {

        Movement();
    }
}
