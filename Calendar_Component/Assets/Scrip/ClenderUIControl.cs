using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/// <summary>
/// 日逻辑  管理按键的父类脚本
/// </summary>
public class ClenderUIControl : MonoBehaviour {


    #region  内部

 
    /// <summary>
    /// 顶部界面时分秒
    /// </summary>
    public GameObject TargetDataTime;

    /// <summary>
    ///顶部界面年月日
    /// </summary>
    public GameObject YearMonth;

    /// <summary>
    /// 中部界面的年
    /// </summary>
    public GameObject Middel_Year;

    /// <summary>
    ///  中部界面的月
    /// </summary>
    public GameObject Middle_Month;

    /// <summary>
    /// 下一个月按钮
    /// </summary>
    public GameObject DownButton;

    /// <summary>
    /// 上一个按钮
    /// </summary>
    public GameObject UpButton;

    /// <summary>
    /// 日期内容框
    /// </summary>
    public GameObject DayContent;
    
    /// <summary>
    /// 克隆的预制件
    /// </summary>
    public GameObject ClongPerfab;

    /// <summary>
    /// 当前的月份天数
    /// </summary>
    int Curr_DayNum = 0;
    /// <summary>
    /// 当前的年
    /// </summary>
    public  int Curr_Year;

    /// <summary>
    /// 当前的月
    /// </summary>
    public   int Curr_Month;
    
    /// <summary>
    /// 当前的日
    /// </summary>
    int Curr_Day;

    /// <summary>
    /// 当前日是周几的标记
    /// </summary>
    int Curr_day_Lybe;

	/// <summary>
	/// 点击的时间日期
	/// </summary>
	/// <param name="daytime">Daytime.</param>
	public GameObject ClickGameDay;


    /// <summary>
    /// 选中的年
    /// </summary>
    public string Out_year;

    /// <summary>
    ///选中的月
    /// </summary>
    public string Out_month;

    /// <summary>
    ///  选中的日期
    /// </summary>
    public string Out_Day;

    /// <summary>
    /// 选中的时间点
    /// </summary>
    public string Out_Time;

    /// <summary>
    /// 选中具体的时间
    /// </summary>
    public Dropdown ChoseTime;

    /// <summary>
    /// 确定按键
    /// </summary>
    public Button EnterButton;

    /// <summary>
    ///  退出日历按键
    /// </summary>
    public Button ExitButton;
    /// <summary>
    ///改变目标日期
    /// </summary>
    public virtual void ChildChangeDayData(string  daytime)
    {
        ///
        YearMonth.GetComponent<Text>().text = daytime;

    }

    public static ClenderUIControl ins;
  // Use this for initialization
    void Start () {
        ins = this;

        //初始化年  月 日
        Curr_Year = System.DateTime.Now.Year;
        Curr_Month = System.DateTime.Now.Month;
        Curr_Day = System.DateTime.Now.Day;

       Out_year =  System.DateTime.Now.Year.ToString();
        Out_month =  System.DateTime.Now.Month.ToString();
        Out_Day =  System.DateTime.Now.Day.ToString();
       
  
        //初始化整个界面
        UpdateDays(Curr_Year, Curr_Month, ClongPerfab);

        //初始化  年月日
       Middle_Month.GetComponent<Text>().text = System.DateTime.Now.Month.ToString(); //
        DownButton.GetComponent<Button>().onClick.AddListener(MothDown);
        UpButton.GetComponent<Button>().onClick.AddListener(MothUP);
        ExitButton.GetComponent<Button>().onClick.AddListener( ExitClender);
        EnterButton.GetComponent<Button>().onClick.AddListener(EnterClender);
        YearMonth.GetComponent<Text>().text = System.DateTime.Now.ToLongDateString().ToString();  // 00年 00月  00日
        //得到  当前 的 年月日
        Curr_DayNum = ClenderControl.ins.BackDayNum(DateTime.Now.Year, DateTime.Now.Month);
       // Debug.Log("当月的天数"+Curr_DayNum);
        //根据 当月第一天  返回的  第一天 是星期几 来决定   当月第一天   在  什么位置上
        Curr_day_Lybe = ClenderControl.ins.ZellerWeek(Curr_Year, Curr_Month, Curr_Day);   


    } 

    void Update ()
    {
        //改变  时分秒 时间 显示
        TargetDataTime.GetComponent<Text>().text = System.DateTime.Now.ToLongTimeString().ToString(); 
	}

 

    /// <summary>
    ///  确定 日历事件
    /// </summary>
    void  EnterClender()
    {
        Debug.Log("确定选择日期");
    }
    /// <summary>
    ///退出 日历按键
    /// </summary>
   void ExitClender()
    {
        Debug.Log("退出日历事件");
    }

    /// <summary>
    ///  月份相加
    /// </summary>
   void   MothUP()
    {
        //月份 加jjjjkkkk
        Curr_Month--;       
      if(Curr_Month <1)
        {
            Curr_Month = 12;
            Curr_Year--;
        }
        //更新信息
        Middel_Year.GetComponent<Text>().text = Curr_Year.ToString();
        Middle_Month.GetComponent<Text>().text = Curr_Month.ToString();

        //更新内容框的信息
        UpdateDays(Curr_Year, Curr_Month, ClongPerfab);
    }

    /// <summary>
    /// 月份相减
    /// </summary>
     void  MothDown()
    {
        
        Curr_Month++;
        //月份 加1
     
        if (Curr_Month >12)
        {
            Curr_Month = 1;
            Curr_Year++;
        }
        //更新信息
        Middel_Year.GetComponent<Text>().text = Curr_Year.ToString();
        Middle_Month.GetComponent<Text>().text = Curr_Month.ToString();

        //更新 内容框的信息
        UpdateDays(Curr_Year, Curr_Month, ClongPerfab);

    }

    /// <summary>
    ///  显示具体的天数
    /// </summary>
    void  showDays(string  num)
    {
       int daynums   = int.Parse(num);
    }


    /// <summary>
    /// 根据选中的月份，刷新日期内容框
    /// </summary>
    /// <param name="year">传入的年份</param>
    /// <param name="month">传入的月份</param>
    /// <param name="perfab">克隆的预制件</param>
    void UpdateDays(int year,  int month,GameObject perfab)
    {
        
        GameObject[] old = GameObject.FindGameObjectsWithTag("日期");//先销毁旧 的日历克隆体
        for (int i = 0; i  < old.Length; i++)
        {
            Destroy(old[i]);
        }
      
        if (month == 1)  //得到上一个月的天数
            month = 12;
        int dayNum  = ClenderControl.ins.BackDayNum(year,month-1);
        //得到本月的开头的星期开头
        int WeekLybe = ClenderControl.ins.ZellerWeek(year, month, 1);
        //星期几开始，就往前补充几个
        int Differ = 7 - (7-WeekLybe)-1;  // 这里很关键
        int AllDays = dayNum - Differ;

        GameObject []  Supply= new GameObject[Differ];  //内容框中的头部分
        for (int i = 0; i < Supply.Length; i++)
        {
            Supply[i] = Instantiate(ClongPerfab);
            Supply[i].transform.SetParent(DayContent.transform,false);
            Supply[i].tag = "日期";
			Supply[i].name = "上月时间";
			Supply[i].transform.GetChild(2).GetComponent<Text>().text = (AllDays+1).ToString();  //总的天数减去   
            Supply[i].transform.GetChild(2).GetComponent<Text>().color = Color.red;
            AllDays = AllDays+1;

        }

        //得到   本月的  天数
       int ThisMonthDays = ClenderControl.ins.BackDayNum(year,month);
        GameObject[] daynums = new GameObject[ThisMonthDays];
        for (int i = 0; i < ThisMonthDays; i++)
        {
            daynums[i] = Instantiate(ClongPerfab);
            daynums[i]. transform.SetParent(DayContent.transform,false);
            daynums[i].tag = "日期";
			daynums[i].name = "当月时间";
			daynums[i].transform.GetChild(2).GetComponent<Text>().text = (i + 1).ToString();
           
        }
        //下月补充天数
        //下月的补充天数  = 总个数（42） - （上一个月的补充天数 + 该月的总天数 ）
        int NextMonthDays = 42 - (Differ+ ThisMonthDays);
        GameObject[] nextdays = new GameObject[NextMonthDays];
        for (int i = 0; i < nextdays.Length; i++)
        {
            nextdays[i] = Instantiate(ClongPerfab);
            nextdays[i].transform.SetParent(DayContent.transform,false);
            nextdays[i].tag = "日期";
			nextdays[i].name = "下月时间";
            nextdays[i].transform.GetChild(2).GetComponent<Text>().text = (i + 1).ToString();   //对下月的天数进行补充
            nextdays[i].transform.GetChild(2).GetComponent<Text>().color = Color.red;
        }

    }


    #endregion


}
