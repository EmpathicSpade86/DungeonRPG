//Partial classes are only for those that are using Godot.
public class GameConstants
{
    //Animations
    public const string ANIM_IDLE = "Idle";
    public const string ANIM_MOVE = "Move";
    public const string ANIM_DASH = "Dash";
    public const string ANIM_ATTACK = "Attack";
    public const string ANIM_DEATH = "Death";
    public const string ANIM_EXPAND = "Expand"; //Should Autoplay on load
    public const string ANIM_EXPLODE = "Explosion";
    public const string ANIM_STUN = "Stun";
    //Input
    public const string INPUT_MOVE_LEFT = "MoveLeft";
    public const string INPUT_MOVE_RIGHT = "MoveRight";
    public const string INPUT_MOVE_FORWARD = "MoveForward";
    public const string INPUT_MOVE_BACKWARD = "MoveBackward";
    public const string INPUT_DASH = "Dash";
    public const string INPUT_ATTACK = "Attack";
    public const string INPUT_PAUSE = "Pause";
    public const string INPUT_INTERACT = "Interact";

    //Notification
    public const int NOTIFCATION_ENTER_STATE = 5001;
    public const int NOTIFCATION_EXIT_STATE = 5002;
}