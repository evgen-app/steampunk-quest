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
        "�� ����� ��������, � ������ ������� ������������ �������, ����������� ���� ��� ������ ����������� �� ������, �� ��� ���������� � �����������������, ���� �� �� �������� �������, �� �������� ���������� � ���.",
        "���� ���� - ����� ������� ������� � ��������� �������������. ��� ����� ��� ���� ����� ��������� ��������� �������",
        "����, ����� ������. ����� ������� �������. ��� ���� ����� ���������� ��������� � ����������� ����������"
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
