using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutQuest : MonoBehaviour
{
    [SerializeField] Text discr;
    [SerializeField] GameObject previousBtn;
    [SerializeField] GameObject filter;

    private int index = 0;
    private List<string> phrases = new List<string>
    {
        "Вы пилот самолета, у вашего корабля обнаружились поломки, генеральный штаб вам выслал подробности об ошибке, но они затерялись в гиперпространстве, если вы не почините корабль, вы навсегда останетесь в нем.",
        "Ваша цель - найти поломку корабля и устранить неисправность. Для этого вам надо будет выполнить несколько заданий",
        "Итак, давай начнем. Начни двигать телефон. Это надо чтобы распознать плоскость в дополненной реальности"
    };
    public void onNextClick()
    {
        index += 1;
        if (index >= 3)
        {
            discr.transform.parent.gameObject.SetActive(false);
            filter.SetActive(false);
            return;
        }
        if (index == 1)
        {
            previousBtn.SetActive(true);
        }
        discr.text = phrases[index];


    }
    public void onPreviosClick()
    {
        index -= 1;
        if(index < 0)
        {
            index = 0;
        }
        if (index == 0)
        {
            previousBtn.SetActive(false);
        }

        discr.text = phrases[index];
    }
    // Start is called before the first frame update
    void Start()
    {
        discr.text = phrases[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
