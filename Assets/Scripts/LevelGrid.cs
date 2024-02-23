using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGrid
{
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    
    private int width;
    private int height;

    private Snake snake;

    public LevelGrid(int w, int h)
    {
        width = w;
        height = h;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            Score.AddScore(Score.POINTS);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpawnFood()
    {
              
        do
        {
            foodGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1);
        
        foodGameObject = new GameObject("Food");
        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        int w = Half(width);
        int h = Half(height);
        //multiplicamos por -1 la direccion y y x cada una en su caso correspondiente por -1 para que no solo se guie por arriba 
        // y abajo del escenario sino tambia la posicion del gameobject.
        if (SceneManager.GetActiveScene().name == "Game4")
        {
            if (gridPosition.x > w)
            {
                gridPosition.x = -w;
                gridPosition.y *= -1;
            }
            if (gridPosition.x < -w)
            {
                gridPosition.x = w;
                gridPosition.y *= -1;
            }
            if (gridPosition.y > h)
            {
                gridPosition.y = -h;
                gridPosition.x *= -1;
            }
            if (gridPosition.y < -h)
            {
                gridPosition.y = h;
                gridPosition.x *= -1;
            }
        }
        else {
            // Me salgo por la derecha
            if (gridPosition.x > w)
            {
                gridPosition.x = -w;
            }
            if (gridPosition.x < -w)
            {
                gridPosition.x = w;
            }
            if (gridPosition.y > h)
            {
                gridPosition.y = -h;
            }
            if (gridPosition.y < -h)
            {
                gridPosition.y = h;
            }
        }

        return gridPosition;
    }

    private int Half(int number)
    {
        return number / 2;
    }
}
