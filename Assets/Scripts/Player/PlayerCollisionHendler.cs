using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerCollisionHendler : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone scoreZone))
            _player.IncreaceScore();
        else
            _player.Die();
    }
}
