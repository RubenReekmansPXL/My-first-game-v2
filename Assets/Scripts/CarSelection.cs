using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    private GameObject[] carList;
    private int index;
    public GameObject player;


    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        carList = new GameObject[transform.childCount];
        
        //fill the array with our models
        for(int i = 0; i < transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }

        //we toggle off their renderer
        foreach(GameObject go in carList)
        {
            go.SetActive(false);
        }

        //we toggle on the selected
        if (carList[index]){
            player = carList[index];
            player.SetActive(true);
        }
    }

    private void Update()
    {
        if (carList[index])
        {
            player = carList[index];
            player.SetActive(true);
            PlayerPrefs.SetInt("CharacterSelected", index);

        }
    }

    public void ToggleLeft()
    {
        //toggle off the current model
        carList[index].SetActive(false);

        index--;
        if(index < 0)
        {
            index = carList.Length - 1;
        }

        //toggle on the new model
        carList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        //toggle off the current model
        carList[index].SetActive(false);

        index++;
        if (index == carList.Length)
        {
            index = 0;
        }

        //toggle on the new model
        carList[index].SetActive(true);
    }

    public void SelectButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("EndlessLevel");
        Time.timeScale = 1;

    }

}
