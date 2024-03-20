using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NumberBaseBallManager : MonoBehaviour
{
    InfoManager InfoManager;

    public Text Main;

    public InputField FirstInput;
    public InputField SecondInput;
    public InputField LastInput;



    private int[] randomNum = {0,0,0};
    private int[] inputNum = {0,0,0};
    private int count = 1;


    System.Random rand = new System.Random();


    private void Awake()
    {
        InfoManager = new InfoManager();



    }

    private bool isGameRunning = false;

    public void GameStart()
    {
        if(!isGameRunning)
        {
            
            isGameRunning = true;
            Main.text = "";
            int[] pocket = new int[9];
            for (int i = 0; i < 9; i++)
            {
                pocket[i] = i + 1;
            }
            System.Random newRandomNumber = new System.Random();
            int temp = 0;
            for (int i = 0; i < 100; i++)
            {
                int firstPosition = newRandomNumber.Next(0, 9);
                int seconsdPosition = newRandomNumber.Next(0, 9);
                temp = pocket[seconsdPosition];
                pocket[seconsdPosition] = pocket[firstPosition];
                pocket[firstPosition] = temp;
            }
            for(int i = 0;i < 3; i++)
            {
                randomNum[i] = pocket[i];
                Debug.Log(randomNum[i]);
            }

            /*            for (int i = 0; i < randomNum.Length; i++)
                        {
                            randomNum[i] = rand.Next(1, 10);
                            Debug.Log(randomNum[i]);
                        }*/
        }
        else
        {
            Debug.Log("이미 게임중 입니다.");
        }
        

    }

    public void GameReset()
    {
        isGameRunning = false;
        count = 1;
        GameStart();
        //InfoManager.LosePointGold();

    }

    public void Play()
    {
        InputValue();
        int strike = 0;
        int ball = 0;

        strike = CheckStrike(inputNum);
        ball = CheckBall(inputNum);

        Main.text += $"strike: {strike}   ball: {ball}   {count}번째 시도\n";
        for(int i = 0; i<3; i++)
        {
            Debug.Log(inputNum[i]);
        }
        count++;
        if (strike == 3)
        {
            Main.text += "===== Win! =====";
            Main.text += "Point: 500 Gold: 500 획득!";
            count = 1;
            isGameRunning = false;
        }


    }


    private bool isInputRunning;
    public void InputValue()
    {
        isInputRunning = true;

        while (isInputRunning)
        {
            
            inputNum[0] = int.Parse(FirstInput.text);
            inputNum[1] = int.Parse(SecondInput.text);
            inputNum[2] = int.Parse(LastInput.text);
            if (inputNum[0] == 0 || inputNum[1] == 0 || inputNum[2] == 0)
            {

                Debug.Log("모든 값을 입력해 주세요.");
                FirstInput.text = "";
                SecondInput.text = "";
                LastInput.text = "";
            }
            else if (inputNum[0] == inputNum[1] || inputNum[0] == inputNum[2] || inputNum[1] == inputNum[2])
            {
                Debug.Log("중복되지 않은 값을 입력해 주세요.");
                FirstInput.text = "";
                SecondInput.text = "";
                LastInput.text = "";
            }
            else
            {
                isInputRunning = false;
            }
        }

    }



    public int CheckStrike(int[] input)
    {
        int strike = 0;

        for(int i = 0; i < randomNum.Length; i++)
        {
            for (int j = 0; j < input.Length; j++)
            {
                if (randomNum[i] == input[j]&& i == j)
                {
                    strike++;
                }
            }
        }
        return strike;
    }
    public int CheckBall(int[] input)
    {
        int ball = 0;

        for (int i = 0; i < randomNum.Length; i++)
        {
            for (int j = 0; j < input.Length; j++)
            {
                if (randomNum[i] == input[j] && i != j)
                {
                    ball++;
                }
            }
        }
        return ball;
    }



}
