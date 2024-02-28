using UnityEngine;
using CharacterStats;

public class Recruiting : MonoBehaviour
{
    [SerializeField] private GameObject _recruitmentMenu;
    [SerializeField] private GameObject _player;
    [SerializeField] private TeamFolder _teamFolder;
    [SerializeField] private GameObject[] _characterPrefabs;

    private GoldManager _goldManager;
    private CharacterStater _characterStater;
    private bool _isMenuActive;

    private void Start()
    {
        _isMenuActive = false;
        _goldManager = _goldManager.GetComponent<GoldManager>();
        _recruitmentMenu = GameObject.Find("RecruitmentMenu");
        _teamFolder = GameObject.Find("TeamFolder").GetComponent<TeamFolder>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isMenuActive)
            {
                _recruitmentMenu.SetActive(false);
                _isMenuActive = false;
            }

            else
            {
                _recruitmentMenu.SetActive(true);
                _isMenuActive = true;
            }
        }
    }

    public void RecruitCharacter(int index)
    {
        if (_goldManager.GetCurrentGold() >= _characterPrefabs[index].GetComponent<CharacterStater>().cost)
        {
            _goldManager.SpendGold(_characterPrefabs[index].GetComponent<CharacterStater>().cost);
            GameObject newCharacter = Instantiate(_characterPrefabs[index]);
            _teamFolder.AddCharacter(newCharacter);
            _recruitmentMenu.SetActive(false);
        }

        else
            Debug.Log("Not enough gold to recruit a character!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            _isMenuActive = true;
            _recruitmentMenu.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            _isMenuActive = false;
            _recruitmentMenu.SetActive(false);
        }
    }
    public void RecruitCharacters(int index) => RecruitCharacter(index);
}