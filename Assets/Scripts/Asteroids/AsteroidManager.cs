using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameConfigData config;
    public int asteroidIdCounter = 0;
    public Asteroid[] asteroidPrefabs;
    public int asteroidCount = 1;
    public static AsteroidManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameManager.Instance.onGameStarted.AddListener(StartGame);
    }

    private void OnDestroy()
    {
        GameManager.Instance.onGameStarted.RemoveListener(StartGame);
    }

    void StartGame()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            var randomPosition = GenerateRandomPosition();
            var a = CreateAsteroid(asteroidPrefabs.Length-1,randomPosition);
            var dir = SetFirstDirection(randomPosition.ToVector3());
            a.SetDirection(dir);
        }
    }

    Vector3 SetFirstDirection(Vector3 from)
    {
        return Random.insideUnitCircle;
    }
    public Vector2 GenerateRandomPosition()
    {
        Vector2 randomPosition;
        do
        {
            float randomX = Random.Range(-config.gameArea.x, config.gameArea.x);
            float randomY = Random.Range(-config.gameArea.y, config.gameArea.y);
            randomPosition = new Vector2(randomX, randomY);

        } while (IsNearPlayer(randomPosition));

        return randomPosition;
    }
    public Asteroid CreateAsteroid(int index, Vector2 position)
    {
        asteroidIdCounter++;
        var go = Instantiate(asteroidPrefabs[index],position,Quaternion.identity);
        go.name += string.Format("ID {0}", asteroidIdCounter);
        return go;
    }

    bool IsNearPlayer(Vector2 randomPosition)
    {
        return Vector2.Distance(ShipManager.instance.ships[0].rbd.Position, randomPosition) < config.distanceFromPlayer;
    }
    
    
}
