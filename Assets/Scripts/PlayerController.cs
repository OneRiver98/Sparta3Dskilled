public class PlayerController : Player
{
    private void FixedUpdate()
    {
        ApplyMove(playerDirectMove);
    }
}
