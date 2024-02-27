using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamFolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters = new List<GameObject>();
    public const int MAX_CHARACTERS = 10;
    public void AddCharacter(GameObject character)
    {
        if (characters.Count < MAX_CHARACTERS)
        {
            characters.Add(character);
        }
        else
        {
            Debug.Log("Cannot recruit more characters. Team is full!");
        }
    }

    public void RemoveCharacter(GameObject character)
    {
        characters.Remove(character);
    }
    public List<GameObject> GetCharacters()
    {
        return characters;
    }

}
