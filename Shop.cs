using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject panel;
    public int costSticks;
    public int costBasket;
    public int costSpikeWheels;
    private bool enoughtMoney;

    void Start()
    {
        panel.SetActive(true);
    }

    public void Sticks()
    {
        if (ismoney(costSticks))
        {
            Horse.instance.money -= costSticks;
            Horse.instance.sticks = true;
        }
    }
    
    public void Basket()
    {
        if (ismoney(costBasket))
        {
            Horse.instance.money -= costBasket;
            Horse.instance.basket = true;
        }
    }

    public void SpikeWheels()
    {
        if (ismoney(costSpikeWheels))
        {
            Horse.instance.money -= costSpikeWheels;
            Horse.instance.wheelsSpike = true;

        }
    }

    bool ismoney(int cost)
    {
        return Horse.instance.money >= cost;
    }

    public void Exit()
    {
        panel.SetActive(false);
    }

    void Update()
    {

    }
}
