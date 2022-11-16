using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{ 
    public void Load_Scene(int number_scene) => SceneManager.LoadScene(number_scene);
}
