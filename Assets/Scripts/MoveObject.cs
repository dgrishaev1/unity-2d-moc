using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 1f;
    [SerializeField] private Transform moveTo;

    bool isMoving = false;

    private void Update()
    {
        var positionFrom = transform.position;
        var positionTo = moveTo.position;

        if (positionTo == null) return;

        bool isInX = positionFrom.x == positionTo.x;
        bool isInY = positionFrom.y == positionTo.y;

        if (!isInX || !isInY)
        {
            float step = movementSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(
                positionFrom,
                new Vector2(
                    (isInX || !isInY) ? positionFrom.x : positionTo.x,
                    isInY ? positionFrom.y : positionTo.y
                ),
                step
                );

            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }

}
