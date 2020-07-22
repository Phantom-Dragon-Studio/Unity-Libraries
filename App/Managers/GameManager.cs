namespace App.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager _instance;

        public static GameManager Instance { get { if (_instance == null) _instance = FindObjectOfType<GameManager>(); return _instance; } }

        [SerializeField] private GameSettings settings = default;

        public GameSettings Settings { get => settings; }
    }
}
