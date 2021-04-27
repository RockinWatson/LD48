using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldGameEventTrigger : MonoBehaviour
{
    public enum GameEvent
    {
        END_GAME = 666,
    }
    [SerializeField] private GameEvent _gameEvent;

    private bool _hasGameEnded = false;

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
        if (_hasGameEnded) return;

        Debug.Log("GAME OVER MAN... You Win...");

        _hasGameEnded = true;

        var health = Player.Get().GetHealthPercent();
        var depth = Player.Get().GetDepth();
        var heat = Player.Get().GetTemperature();
        GlobalManager.Get().SetGameWinStats(health, depth, heat);
        StartCoroutine(LoadGameOverScene());

    }

    IEnumerator LoadGameOverScene()
    {
        GameplayAudioInit.levelMusic.mute = true;
        GameplayAudioInit.pizzasHere.Play();
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("GameWIN");
    }

}
