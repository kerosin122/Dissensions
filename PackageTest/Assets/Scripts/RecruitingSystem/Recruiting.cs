using System.Collections;
using System.Collections.Generic;
using CharacterStats;
using UnityEngine;


public class Recruiting : MonoBehaviour
{ 
    private GoldManager goldManager;
private CharacterStater CharacterStater;
    [SerializeField] private GameObject recruitmentMenu;
    [SerializeField] private GameObject player;
    [SerializeField] private TeamFolder teamFolder;
    [SerializeField] private GameObject[] characterPrefabs;
    private bool isMenuActive;
  private void Start()
 {
    isMenuActive = false;
    goldManager = goldManager.GetComponent<GoldManager>();
    recruitmentMenu = GameObject.Find("RecruitmentMenu");
    teamFolder = GameObject.Find("TeamFolder").GetComponent<TeamFolder>();
 }

 private void Update()
 {
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (isMenuActive)
        {
            recruitmentMenu.SetActive(false);
            isMenuActive = false;
        }
        else
        {
            recruitmentMenu.SetActive(true);
            isMenuActive = true;
        }
    }
 }
 public void RecruitCharacter(int index)
 {
    if (goldManager.GetCurrentGold() >= characterPrefabs[index].GetComponent<CharacterStater>().cost)
    {
        goldManager.SpendGold(characterPrefabs[index].GetComponent<CharacterStater>().cost);
        GameObject newCharacter = Instantiate(characterPrefabs[index]);
        teamFolder.AddCharacter(newCharacter);
        recruitmentMenu.SetActive(false);
    }
    else
    {
        Debug.Log("Not enough gold to recruit a character!");
    }
 }
 private void OnTriggerEnter2D(Collider2D collision)
 {
    if (collision.gameObject == player)
    {
        isMenuActive = true;
        recruitmentMenu.SetActive(true);
    }
 }
 private void OnTriggerExit2D(Collider2D collision)
 {
    if (collision.gameObject == player)
    {
        isMenuActive = false;
        recruitmentMenu.SetActive(false);
    }
 }
 public void RecruitCharacters(int index)
 {
    RecruitCharacter(index);
 }

}
