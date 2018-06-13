using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 该脚本只是负责UI界面的 界面表现形式
/// </summary>
public class DayControl : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{

    /// <summary>
    /// 当鼠标点击  日期时间  时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        //激活本身的蓝色选种框
        GameObject[] oldday = GameObject.FindGameObjectsWithTag("日期");
        for (int i = 0; i < oldday.Length; i++)
        {
            oldday[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
        }

        this.transform.GetChild(0).GetComponent<Image>().enabled = true;

		switch(this.transform.name )
		{
		case "上月时间":
			{
                    //年份
                    ClenderUIControl.ins.ClickGameDay.transform.GetChild (0).GetComponent<Text> ().text =  (ClenderUIControl.ins.Curr_Year).ToString() ;
                    //月份
                    ClenderUIControl.ins.ClickGameDay.transform.GetChild (1).GetComponent<Text> ().text =  (ClenderUIControl.ins.Curr_Month-1).ToString() ;
                    //日
                    ClenderUIControl.ins.ClickGameDay.transform.GetChild (2).GetComponent<Text> ().text = this.transform.GetChild(2).GetComponent<Text>().text;

                    ClenderUIControl.ins.Out_year = (ClenderUIControl.ins.Curr_Year).ToString();
                    ClenderUIControl.ins.Out_month =    (ClenderUIControl.ins.Curr_Month-1).ToString() ;
                    ClenderUIControl.ins.Out_Day = this.transform.GetChild(2).GetComponent<Text>().text;
                    

			}break;
			case "当月时间":
			{
                    //年份
                    ClenderUIControl.ins.ClickGameDay.transform.GetChild (0).GetComponent<Text> ().text =  (ClenderUIControl.ins.Curr_Year).ToString() ;
                    //月份
                    ClenderUIControl.ins.ClickGameDay.transform.GetChild (1).GetComponent<Text> ().text =  (ClenderUIControl.ins.Curr_Month).ToString() ;
                    //日
                    ClenderUIControl.ins.ClickGameDay.transform.GetChild (2).GetComponent<Text> ().text = this.transform.GetChild(2).GetComponent<Text>().text;

                    ClenderUIControl.ins.Out_year = (ClenderUIControl.ins.Curr_Year).ToString();
                    ClenderUIControl.ins.Out_month =    (ClenderUIControl.ins.Curr_Month).ToString() ;
                    ClenderUIControl.ins.Out_Day = this.transform.GetChild(2).GetComponent<Text>().text;
 
                } break;
			case "下月时间":
			{
                    //年份
                    ClenderUIControl.ins.ClickGameDay.transform.GetChild (0).GetComponent<Text> ().text = (ClenderUIControl.ins.Curr_Year ).ToString() ;
                    //月份
                    ClenderUIControl.ins.ClickGameDay.transform.GetChild (1).GetComponent<Text> ().text = (ClenderUIControl.ins.Curr_Month+1).ToString() ;
                    //日
                    ClenderUIControl.ins.ClickGameDay.transform.GetChild (2).GetComponent<Text> ().text = this.transform.GetChild(2).GetComponent<Text>().text;

                    ClenderUIControl.ins.Out_year = (ClenderUIControl.ins.Curr_Year).ToString();
                    ClenderUIControl.ins.Out_month =    (ClenderUIControl.ins.Curr_Month+1).ToString() ;
                    ClenderUIControl.ins.Out_Day = this.transform.GetChild(2).GetComponent<Text>().text;
 
                } break;

		default:break;
			
		}
	   //	UIControl.ins.ClickGameDay.
    }



    /// <summary>
    /// 当鼠标进入日期时间时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        //激活灰色选中框
        this.transform.GetChild(1).GetComponent<Image>().enabled = true;
    }


    /// <summary>
    /// 当鼠标 退出日期时间时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        //关闭 灰色选中框
        this.transform.GetChild(1).GetComponent<Image>().enabled = false;
    }

    // Use this for initialization
    void Start () {

        //   Debug.Log("数量"+this.transform.GetChildCount);
        //判定  当前的日期 是否与  自身相同即 当前  年份与月份 
        if (System.DateTime.Now.Year == ClenderUIControl.ins.Curr_Year
            && System.DateTime.Now.Month == ClenderUIControl.ins.Curr_Month
            && this.transform.GetChild(2).GetComponent<Text>().text == System.DateTime.Now.Day.ToString()
            && this.transform.name == "当月时间")
        {
            this.GetComponent<Image>().enabled = true;
        }

        ClenderUIControl.ins.ClickGameDay.transform.GetChild(0).GetComponent<Text>().text = System.DateTime.Now.Year.ToString();
        //月份
        ClenderUIControl.ins.ClickGameDay.transform.GetChild(1).GetComponent<Text>().text = System.DateTime.Now.Month.ToString();
        //日
        ClenderUIControl.ins.ClickGameDay.transform.GetChild(2).GetComponent<Text>().text = System.DateTime.Now.Day.ToString();

        ClenderUIControl.ins.Out_year = System.DateTime.Now.Year.ToString();
        ClenderUIControl.ins.Out_month = System.DateTime.Now.Month.ToString();
        ClenderUIControl.ins.Out_Day  = System.DateTime.Now.Day.ToString();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
