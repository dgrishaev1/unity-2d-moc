using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 1f;
    [SerializeField] private Vector2 moveTo;

    bool isMoving = false;

    private void Update()
    {
        var positionFrom = transform.position;

        bool isInX = positionFrom.x == moveTo.x;
        bool isInY = positionFrom.y == moveTo.y;

        if (!isInX || !isInY)
        {
            float step = movementSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(
                positionFrom,
                new Vector2(
                    (isInX || !isInY) ? positionFrom.x : moveTo.x,
                    isInY ? positionFrom.y : moveTo.y
                ),
                step
                );

            isMoving = true;
        }

    }

}
