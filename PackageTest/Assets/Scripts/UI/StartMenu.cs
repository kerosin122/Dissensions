using ScriptsScene;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private Button _loadSceneButton;
        [SerializeField] private SceneLoader _sceneLoader;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _loadGameButton;
        [SerializeField] private Button _extButton;

        [SerializeField] private Button _selectedSwordManButton;
        [SerializeField] private Button _selectedArcherButton;
        [SerializeField] private Button _selectedMagButton;

        private CharacterType _currentCharacterType;

        private void Awake()
        {
            _currentCharacterType = CharacterType.SwordMan;

            _loadSceneButton.onClick.AddListener(LoadScene);

            _extButton.onClick.AddListener(IsExitGame);

            _selectedSwordManButton.onClick.AddListener(SelectSwordMan);
            _selectedArcherButton.onClick.AddListener(SelectArcher);
            _selectedMagButton.onClick.AddListener(SelectMag);
        }

        private void OnDestroy()
        {
            _loadSceneButton.onClick.RemoveListener(LoadScene);

            _extButton.onClick.RemoveListener(IsExitGame);

            _selectedSwordManButton.onClick.RemoveListener(SelectSwordMan);
            _selectedArcherButton.onClick.RemoveListener(SelectArcher);
            _selectedMagButton.onClick.RemoveListener(SelectMag);
        }

        private void SelectSwordMan()
            => SelectTypeCharacter(CharacterType.SwordMan);

        private void SelectArcher()
            => SelectTypeCharacter(CharacterType.Archer);

        private void SelectMag()
            => SelectTypeCharacter(CharacterType.Mag);


        private void SelectTypeCharacter(CharacterType type)
        {
            _currentCharacterType = type;
        }

        private void LoadScene()
        {
            _sceneLoader.LoadingScene(_currentCharacterType);
        }

        public void IsExitGame() => Application.Quit();


        public enum CharacterType
        {
            SwordMan,
            Archer,
            Mag,
        }
    }
}
