using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/// <summary>
///  日历组件的算法层
/// </summary>
public class ClenderControl : MonoBehaviour {

 

    Toggle istoggle;

    public static ClenderControl ins;
    // Use this for initialization
    void Start()
    {
      //  Up_Button.onClick.AddListener(UP_ChangeShow);
     //   Down_Button.onClick.AddListener(Down_ChangeShow);

        ins = this;

    }


    // Update is called once per frame
    void Update() {

    }




    
    #region 外部调用
    /// <summary>
    /// 改变  窗口的状态
    /// </summary>
    public void UP_ChangeShow()
    {
        //将所有的时间按钮上移


    }

    /// <summary>
    /// 向下改变窗口的状态
    /// </summary>
    public void Down_ChangeShow()
    {
        //将所有的时间按钮下移
    }
    #endregion  

    #region    日历核心算法
    /// <summary>
    /// 日历核心算法  在win10 的系统日历中,每一个月的1号  永远都是在  内容框中的第一行。所以只要得出  1号 是星期几，剩下的天数在其后边往下排就可以
    /// 而上一个月的剩余日期则应该 用剩余的天数往回计算，空余几天就  往回算几天。而下一个月的补进来的天数则是同样的道理。根据当前月的最后一天是星期几来计算
    /// 下一个月需要补上来多少天。  内容框的容器内应该使用  自动排列组件，使其可以自动换行。
    /// </summary>
    /// <param name="year"></param>
    /// <param name="moth"></param>
    void PrintMouthCalendar(int year, int month)
    {
        int days = BackDayNum(year, month);
        int firstDayweek = ZellerWeek(year, month, 1);
        
        
    }


    int[] DayNumsArry = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    /// <summary>
    /// 根据 输入的年月  返回当月的天数
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    public  int  BackDayNum(int year,int month)
    {
        //Debug.Log("传入的月份"+month);
        int DayNums = 0;
        month= month - 1 ;
        //闰年
        if (year % 4 == 0 && 
             year%100 != 0 &&
             year %400  == 0)  //年份是4的倍数  且 不是100 的倍数  
        {
       
            if (month == 2)
            {
                DayNums = DayNumsArry[month] + 1; //
            }
            else
                DayNums = DayNumsArry[month];
        }
        else//不是闰年
        {     
            DayNums = DayNumsArry[month];
        }
        return DayNums;
    }
    
    /// <summary>
    ///  蔡乐算法（根据输入的年份、月份、天数返回  星期）
    /// </summary>
    /// <param name="year">年份</param>
    /// <param name="month">月份</param>
    /// <param name="day">该月几号</param>
    /// <returns></returns>
    public  int ZellerWeek(int year ,int  month,int day )
    {
        int m = month;
        int d = day;

        if(month <= 2) //
        {
            year--;
            m = month + 12;
        }

        int y = year % 100;
        int c = year / 100;

        int w = (y+y/4+c/4-2*c+(13*(m+1)/5)+d-1)%7;
      //  Debug.Log("修正前输出"+ w);
        if (w<=0)  //修正计算结果是负数的情况
            w += 7;

        return w;

    }


    string[] MonthArry = { "一月", "二月","三月","四月","五月","六月",
                                        "七月","八月","九月","十月","十一月","十二月"};
    /// <summary>
    ///  打印相应的 月份
    /// </summary>
    /// <param name="monthNum">月份的时间</param>
    /// <param name="showobj">要显示的物体</param>
    void ShowMonthBanner(int monthNum,GameObject  showobj)
    {
        if (showobj.GetComponent<Text>())
        {
            showobj.GetComponent<Text>().text = MonthArry[monthNum];
        }
        else
            Debug.Log("目标物体不包含组件");
    }


    
#endregion
}
