using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Screen_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject tap_point;
    public GameObject circle;
    public GameObject navigation_Screen;
    public GameObject lost_screen;
    public GameObject win_screen;
    public GameObject start_screen;
    GameObject circle_transform;
    public GameObject play_screen;
    public GameObject play_screen2;
    public Transform charater;
    Vector2 press_point;
    bool instantiated;
    bool won;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        Play();
        StartCoroutine(Start_Screen());
        text.text = gameManager.speed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !gameManager.isPressing)
        {
            press_point = Input.mousePosition;
            gameManager.isPressing = true;
        }
        else if (!Input.GetMouseButton(0))
        {
            gameManager.isPressing = false;
            instantiated = false;
        }

        if (gameManager.isPressing && !instantiated)
        {
            GameObject tap_point1 = Instantiate(tap_point, press_point, Quaternion.identity);
            tap_point1.transform.SetParent(play_screen.transform, true);
            GameObject circle1 = Instantiate(circle, press_point, Quaternion.identity);
            circle1.transform.SetParent(play_screen.transform, true);
            circle_transform = circle1;
            instantiated = true;
        }
        //Debug.Log(gameManager.isPressing);
        //if (circle_transform != null) circle_transform.transform.position = Input.mousePosition;
        //Vector2 direction = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - press_point;
        ////Debug.DrawRay(direction, press_point, Color.blue);
        ////Debug.Log(direction);
        //gameManager.x = direction.x;
        //gameManager.z = direction.y;
        ////// (ty - mpy) * (x - tx) + (mpx - tx) * (y - ty) = 0
        ////// (x - tx) = -[(mp - tx) * (y - ty)]/(ty - mp)
        ////// x = -[(mp - tx) * (y - ty)]/(ty - mp) + tx
        ////// x = 
        //////
        ////// (x - tx)^2 + (y - ty)^2 = R^2
        ////// [-[(mpx - tx) * (y - ty)]/(ty - mp)]^2 + (y - ty)^2 = R^2
        ////// [-[(mpx - tx)*y - mpx*ty + tx*ty]/(ty - mpy)]^2 + (y - ty)^2 = R^2
        ////// [(mpx - tx)^2*y^2 - 2*(mpx - tx)*y * (mpx*ty + tx*ty) + (mpx*ty + tx*ty)^2]/(ty - mpy)]^2 + (ty - mpy)]^2*y^2 - (ty - mpy)]^2*2*y*ty + (ty - mpy)]^2*ty^2 = R^2
        ////// (mpx - tx)^2*y^2 - 2*(mpx - tx)*y * (mpx*ty + tx*ty) + (mpx*ty + tx*ty)^2 + (ty - mpy)]^2*y^2 - (ty - mpy)]^2*2*ty*y + (ty - mpy)]^2*ty^2 = R^2
        ////// [(mpx - tx)^2 + (ty - mpy)^2] * y^2 + [- 2*(mpx - tx) * (mpx*ty + tx*ty) - (ty - mpy)]^2]*2*y*ty + (mpx*ty + tx*ty)^2 + (ty - mpy)]^2*ty^2 - (ty - mpy)]^2*R^2 = 0
        ////float tx = press_point.x;
        ////float ty = press_point.y;
        ////float mpx = Input.mousePosition.x;
        ////float mpy = Input.mousePosition.y;
        ////float a = Mathf.Pow((mpx - tx),2) + Mathf.Pow((ty - mpy),2);
        ////float b = (-2 * (mpx - tx) * Mathf.Pow((mpx * ty + tx * ty) - (ty - mpy), 2)) * 2 * ty;
        ////float c = Mathf.Pow((mpx * ty + tx * ty), 2) + Mathf.Pow((ty - mpy), 2) * ty - Mathf.Pow((ty - mpy), 2) * Mathf.Pow(r, 2);
        ////float delta = Mathf.Pow(b, 2) - 4 * a * c;
        ////float x;
        ////float y;
        ////if (gameManager.isPressing && Input.mousePosition.y - press_point.y > 0)
        ////{
        ////    y = (-b + Mathf.Sqrt(delta))/ 2 * a;
        ////    x = -((mpx - tx) * (y - ty)) / (ty - mpy) + tx;
        ////    circle_transform.transform.position = new Vector2(x, y);
        ////}
        ////else if (gameManager.isPressing && Input.mousePosition.y - press_point.y < 0)
        ////{
        ////    y = (-b + Mathf.Sqrt(delta)) / 2 * a;
        ////    x = -((mpx - tx) * (y - ty)) / (ty - mpy) + tx;
        ////    circle_transform.transform.position = new Vector2(x, y);
        ////}
        StartCoroutine(Win_Screen());
        if (charater.position.z > 360)
        {
            SceneManager.LoadScene(0);
        }
        if (gameManager.lost)
        {
            Lost_Screen();
        }
    }
    void Lost_Screen()
    {
        lost_screen.SetActive(true);
        Time.timeScale = 0;
    }
    public void Upgrade()
    {
        gameManager.speed += 10;
        text.text = gameManager.speed.ToString();
    }
    public void DeUpgrade()
    {
        gameManager.speed -= 10;
        text.text = gameManager.speed.ToString();
    }
    IEnumerator Start_Screen()
    {
        start_screen.SetActive(true);
        yield return new WaitForSeconds(1f);
        start_screen.SetActive(false);

    }
    IEnumerator Win_Screen()
    {
        if (charater.position.z > 240 && !won)
        {
            won = true; 
            win_screen.SetActive(true);
            yield return new WaitForSeconds(1f);
            win_screen.SetActive(false);
        }
    }
    void Play()
    {
        play_screen.SetActive(true);
        play_screen2.SetActive(true);
        lost_screen.SetActive(false);
        win_screen.SetActive(false);
        navigation_Screen.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        play_screen.SetActive(false);
        play_screen2.SetActive(false);
        lost_screen.SetActive(false);
        win_screen.SetActive(false);
        navigation_Screen.SetActive(true);
        Time.timeScale = 0;
    }
    public void Level1()
    {
        gameManager.level = GameManager.Level.one;
        SceneManager.LoadScene("SampleScene");
    }
    public void Level2()
    {
        gameManager.level = GameManager.Level.two;
        SceneManager.LoadScene("SampleScene");
    }
    public void Level3()
    {
        gameManager.level = GameManager.Level.three;
        SceneManager.LoadScene("SampleScene");
    }
    public void Level4()
    {
        gameManager.level = GameManager.Level.four;
        SceneManager.LoadScene("SampleScene");
    }
    public void Level5()
    {
        gameManager.level = GameManager.Level.five;
        SceneManager.LoadScene("SampleScene");
    }
    public void Level6()
    {
        gameManager.level = GameManager.Level.six;
        SceneManager.LoadScene("SampleScene");
    }
    public void Level7()
    {
        gameManager.level = GameManager.Level.seven;
        SceneManager.LoadScene("SampleScene");
    }
    public void Level8()
    {
        gameManager.level = GameManager.Level.eight;
        SceneManager.LoadScene("SampleScene");
    }
    public void Level9()
    {
        gameManager.level = GameManager.Level.nine;
        SceneManager.LoadScene("SampleScene");
    }
    public void Level10()
    {
        gameManager.level = GameManager.Level.ten;
        SceneManager.LoadScene("SampleScene");
    }

}
