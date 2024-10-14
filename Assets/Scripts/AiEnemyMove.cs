
using UnityEngine;

public class AiEnemyMove : MonoBehaviour
{
    [SerializeField]
    private AiEnemyCombat check;
    [SerializeField]
    private Transform platform1;
    [SerializeField]
    private Transform platform2;
    [SerializeField]

    private float moveSpeed = 2f; // Скорость движения противника
    [SerializeField]
    private float patrolSpeed = 1f; // Скорость патрулирования
    

    private float leftBoundary;
    
    private float rightBoundary;

    private bool movingRight = true; // Начальное направление движения противника

    private void Start()
    {
        check = GetComponent<AiEnemyCombat>();
        CalculateBoundaries();

    }

    private void Update()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, check.player.position);
        if (check.isRangedAttacker == true)
        {
            if (distanceToPlayer > check.attackRadius)
            {
                PatrolBetweenPlatforms();
                Vector2 directionToMove = movingRight ? Vector2.right : Vector2.left;
                FaceDirection(directionToMove);

            }
            else
            {
                Vector2 directionToPlayer = (check.player.position - transform.position).normalized;
                FaceDirection(directionToPlayer);
                PatrolBetweenPlatforms();


            }

        }
        else
        {
            if (distanceToPlayer < check.attackRadius)
            {
                Vector2 directionToPlayer = (check.player.position - transform.position).normalized;
                FaceDirection(directionToPlayer);
                FollowPlayer();




            }
            else
            {
                PatrolBetweenPlatforms();
                Vector2 directionToMove = movingRight ? Vector2.right : Vector2.left;
                FaceDirection(directionToMove);

            }

        }





    }

    private void FaceDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void CalculateBoundaries()
    {
        if (platform1 != null && platform2 != null)
        {
            leftBoundary = Mathf.Min(platform1.position.x, platform2.position.x);
            rightBoundary = Mathf.Max(platform1.position.x, platform2.position.x);
        }
    }

    public void FollowPlayer()
    {
        Vector2 directionToPlayer = (check.player.position - transform.position).normalized;
        MoveEnemy(directionToPlayer, moveSpeed);
    }

    public void PatrolBetweenPlatforms()
    {


        if (movingRight)
        {
            if (transform.position.x >= rightBoundary)
            {
                movingRight = false;
            }
            else
            {
                MoveEnemy(Vector2.right, patrolSpeed);
            }
        }
        else
        {
            if (transform.position.x <= leftBoundary)
            {
                movingRight = true;
            }
            else
            {
                MoveEnemy(Vector2.left, patrolSpeed);
            }
        }
    }

    private void MoveEnemy(Vector2 direction, float speed)
    {
        Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);
        transform.position = newPosition;

    }
}