using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldGameEventTrigger : MonoBehaviour
{
    public enum GameEvent
    {
        END_GAME = 666,
    }
    [SerializeField] private GameEvent _gameEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch(_gameEvent)
            {
                case GameEvent.END_GAME:
                    EndGame();
                    break;
            }
        }
    }

    private void EndGame()
    {
        Debug.Log("GAME OVER MAN... You Win...");

        var health = Player.Get().GetHealthPercent();
        var depth = Player.Get().GetDepth();
        var heat = Player.Get().GetTemperature();
        GlobalManager.Get().SetGameWinStats(health, depth, heat);

        SceneManager.LoadScene("GameWIN");
    }
}
