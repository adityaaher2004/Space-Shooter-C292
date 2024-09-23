using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseLaser()
    {
        player.increaseLaserLevel();
    }

    public void decreaseLaser()
    {
        player.decreaseLaserLevel();
    }

    public void increaseSpeed()
    {
        player.increaseSpeedLevel();
    }

    public void decreaseSpeed()
    {
        Debug.Log("Reached");
        player.decreaseSpeedLevel();
    }

    public void increaseMaxHealth()
    {
        player.increaseMaxHealthLevel();
    }

    public void decreaseMaxHealth()
    {
        player.decreaseMaxHealthLevel();
    }
}
