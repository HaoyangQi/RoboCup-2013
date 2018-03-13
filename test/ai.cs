using System;

namespace AI
{
    public static class AI
    {
        static int Duration = 0;
        static int SuperDuration = 0;
        static bool bGameEnd = false;
        static int CurAction = 0;
        static int CurGame = 0;
        static int SuperObj_Num = 0;
        static int SuperObj_X = 0;
        static int SuperObj_Y = 0;
        static int Teleport = 0;
        static int LoadedObjects = 0;
        static int RedObject = 0;
        static int GreenObject = 0;
        static int BlackObject = 0;
        static int IfFreeObject = 0;
        static int Object = 0;
        static int FindObjStep = 0;
        static int SuperObj_TempX = 0;
        static int SuperObj_TempY = 0;
        static int US_Front = 0;
        static int US_Back = 0;
        static int US_Left = 0;
        static int US_Right = 0;
        static int CSLeft_R = 0;
        static int CSLeft_G = 0;
        static int CSLeft_B = 0;
        static int CSRight_R = 0;
        static int CSRight_G = 0;
        static int CSRight_B = 0;
        static int PositionX = 0;
        static int PositionY = 0;
        static int TM_State = 0;
        static int Compass = 0;
        static int Time = 0;
        static int Wheel_Left = 0;
        static int Wheel_Right = 0;
        static int LED_1 = 0;
        static int MyState = 0;
 
        public static int GetCurAction()
        {
            return CurAction;
        }

 
        public static string GetTeamName()
        {
             return "";
        }

 
        public static string GetGameName(int GameID)
        {
            if (GameID < 0 || GameID > 8) return string.Empty;
            if (GameID == 0) return  "Game0";
            else if (GameID == 1) return "Game1";
            else if (GameID == 2) return "Game2";
            else if (GameID == 3) return "Game3";
            else if (GameID == 4) return "Game4";
            else if (GameID == 5) return "Game5";
            else if (GameID == 6) return "Game6";
            else if (GameID == 7) return "Game7";
            else if (GameID == 8) return "Game8";
            else if (GameID == 9) return "Wait";
            else if (GameID == 10) return "Stop";
            return string.Empty;
        }
 
 
        public static void SetGameID(int GameID)
        {
            CurGame = GameID;
            bGameEnd = false;
        }

 
        public static int GetGameID()
        {
            return CurGame;
        }

 
        public static int GetTeleport()
        {
            return Teleport;
        }

 
        public static void GetSuperObj(ref int x, ref int y, ref int num)
        {
            x = SuperObj_X;
            y = SuperObj_Y;
            num = SuperObj_Num;
        }
 
        public static void SetSuperObj(int X, int Y, int num)
        {
            SuperObj_X = X;
            SuperObj_Y = Y;
            SuperObj_Num = num;
        }
 
        public static bool IsGameEnd()
        {
            return bGameEnd;
        }

        public static void OnTimer()
        {
            switch (CurGame)
            {
                case 9:
                    break;
                case 10:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=0;
                    MyState=0;
                    break;
                case 0:
                    Game0();
                    break;
                case 1:
                    Game1();
                    break;
                default:
                    break;
            }
        }
        public static void SetData(int Sensor0 , int Sensor1 , int Sensor2 , int Sensor3 , int Sensor4 , int Sensor5 , int Sensor6 , int Sensor7 , int Sensor8 , int Sensor9 , int Sensor10 , int Sensor11 , int Sensor12 , int Sensor13 , int Sensor14)
        {
            US_Front = Sensor0;
            US_Back = Sensor1;
            US_Left = Sensor2;
            US_Right = Sensor3;
            CSLeft_R = Sensor4;
            CSLeft_G = Sensor5;
            CSLeft_B = Sensor6;
            CSRight_R = Sensor7;
            CSRight_G = Sensor8;
            CSRight_B = Sensor9;
            PositionX = Sensor10;
            PositionY = Sensor11;
            TM_State = Sensor12;
            Compass = Sensor13;
            Time = Sensor14;
        }
        public static void GetCommand(ref int Actuator0 , ref int Actuator1 , ref int Actuator2 , ref int Actuator3)
        {
            Actuator0 = Wheel_Left;
            Actuator1 = Wheel_Right;
            Actuator2 = LED_1;
            Actuator3 = MyState;
        }
        private static void Game0()
        {

            if(SuperDuration>0)
            {
                SuperDuration--;
            }
            else if(Duration>0)
            {
                Duration--;
            }
            else if(Time>=60 && Time<=1000&&(IfFreeObject==1))
            {
                Duration = 0;
                CurAction =1;
            }
            else if(RedObject>0&&GreenObject>0&&BlackObject>0)
            {
                Duration = 0;
                CurAction =2;
                if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=140 && CSLeft_G<=190 && CSLeft_B>=40 && CSLeft_B<=60 && CSRight_R>=250 && CSRight_R<=255 && CSRight_G>=140 && CSRight_G<=190 && CSRight_B>=40 && CSRight_B<=60&&(RedObject==1&&GreenObject==1&&BlackObject==1))
                {
                    Duration = 49;
                    CurAction =3;
                }
                else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=140 && CSLeft_G<=190 && CSLeft_B>=40 && CSLeft_B<=60 ||(CSRight_R>250&&(CSRight_G>140&&CSRight_G<190)&&
(CSRight_B>40&&CSRight_B<60)))
                {
                    Duration = 0;
                    CurAction =4;
                }
                else if(US_Left>=0 && US_Left<=15 ||(US_Right<15))
                {
                    Duration = 0;
                    CurAction =5;
                }
                else if(US_Front>=0 && US_Front<=15)
                {
                    Duration = 0;
                    CurAction =6;
                }
                else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=250 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60 && CSRight_R>=250 && CSRight_R<=255 && CSRight_G>=250 && CSRight_G<=255 && CSRight_B>=40 && CSRight_B<=60)
                {
                    Duration = 0;
                    CurAction =7;
                }
                else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=250 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60 ||(CSRight_R>250&&CSRight_G>250&&(CSRight_B>40&&CSRight_B<60)))
                {
                    Duration = 0;
                    CurAction =8;
                }
                else if(true)
                {
                    Duration = 0;
                    CurAction =9;
                }
            }
            else if(CSRight_R>=0 && CSRight_R<=7 && CSRight_G>=0 && CSRight_G<=7 && CSRight_B>=0 && CSRight_B<=7&&(BlackObject<1))
            {
                Duration = 49;
                CurAction =10;
            }
            else if(CSRight_R>=0 && CSRight_R<=7 && CSRight_G>=120 && CSRight_G<=140 && CSRight_B>=0 && CSRight_B<=7&&(GreenObject<1))
            {
                Duration = 49;
                CurAction =11;
            }
            else if(CSRight_R>=140 && CSRight_R<=170 && CSRight_G>=0 && CSRight_G<=10 && CSRight_B>=0 && CSRight_B<=10&&(RedObject<1))
            {
                Duration = 49;
                CurAction =12;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=7 && CSLeft_G>=0 && CSLeft_G<=7 && CSLeft_B>=0 && CSLeft_B<=7&&(BlackObject<1))
            {
                Duration = 49;
                CurAction =13;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=7 && CSLeft_G>=120 && CSLeft_G<=140 && CSLeft_B>=0 && CSLeft_B<=7&&(GreenObject<1))
            {
                Duration = 49;
                CurAction =14;
            }
            else if(CSLeft_R>=140 && CSLeft_R<=170 && CSLeft_G>=0 && CSLeft_G<=10 && CSLeft_B>=0 && CSLeft_B<=10&&(RedObject<1))
            {
                Duration = 49;
                CurAction =15;
            }
            else if(US_Left>=0 && US_Left<=15 ||(US_Right<15))
            {
                Duration = 0;
                CurAction =16;
            }
            else if(US_Front>=0 && US_Front<=15)
            {
                Duration = 0;
                CurAction =17;
            }
            else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=250 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60 ||(CSRight_R>250&&CSRight_G>250&&(CSRight_B>40&&CSRight_B<60)))
            {
                Duration = 0;
                CurAction =18;
            }
            else if(true)
            {
                Duration = 0;
                CurAction =19;
            }
            switch(CurAction)
            {
                case 1:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=0;
                    MyState=0;
                     Teleport = 1;  
                    break;
                case 2:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    break;
                case 3:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=2;
                    MyState=0;
                    if(Duration==0)
{
RedObject=0;
                    
GreenObject=0;
                    
BlackObject=0;
                    
IfFreeObject=1;
                    
}
                    break;
                case 4:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(CSRight_R>250&&(CSRight_G>140&&CSRight_G<190)&&
(CSRight_B>40&&CSRight_B<60)&&RedObject==1&&GreenObject==1&&BlackObject==1)
{
Wheel_Left=1;
                    
Wheel_Right=0;
                    
}
else
{
Wheel_Left=0;
                    
Wheel_Right=1;
                    
}
                    break;
                case 5:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(US_Left<15)
{
Wheel_Left=2;
                    
Wheel_Right=-2;
                    
}
else
{
Wheel_Left=-2;
                    
Wheel_Right=2;
                    
}
                    break;
                case 6:
                    Wheel_Left=-2;
                    Wheel_Right=2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 7:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    Wheel_Left=-3;
                    
Wheel_Right=-3;
                    
Wheel_Left=3;
                    
Wheel_Right=-4;
                    
                    break;
                case 8:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(CSLeft_R>250&&CSLeft_G>250&&(CSLeft_B>40&&CSLeft_B<60))
{
Wheel_Left=3;
                    
Wheel_Right=2;
                    
}
else
{
Wheel_Left=2;
                    
Wheel_Right=3;
                    
}
                    break;
                case 9:
                    Wheel_Left=2;
                    Wheel_Right=3;
                    LED_1=0;
                    MyState=0;
                    break;
                case 10:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
BlackObject=BlackObject+1;
                    
}
                    break;
                case 11:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
GreenObject=GreenObject+1;
                    
}
                    break;
                case 12:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
RedObject=RedObject+1;
                    
}
                    break;
                case 13:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
BlackObject=BlackObject+1;
                    
}
                    break;
                case 14:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
GreenObject=GreenObject+1;
                    
}
                    break;
                case 15:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
RedObject=RedObject+1;
                    
}
                    break;
                case 16:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(US_Left<15)
{
Wheel_Left=2;
                    
Wheel_Right=-2;
                    
}
else
{
Wheel_Left=-2;
                    
Wheel_Right=2;
                    
}
                    break;
                case 17:
                    Wheel_Left=-2;
                    Wheel_Right=2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 18:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(CSLeft_R>250&&CSLeft_G>250&&(CSLeft_B>40&&CSLeft_B<60))
{
Wheel_Left=2;
                    
Wheel_Right=-2;
                    
}
else
{
Wheel_Left=-2;
                    
Wheel_Right=2;
                    
}
                    break;
                case 19:
                    Wheel_Left=3;
                    Wheel_Right=3;
                    LED_1=0;
                    MyState=0;
                    break;
                default:
                    break;
            }

        }

        private static void Game1()
        {

            if(SuperDuration>0)
            {
                SuperDuration--;
            }
            else if(Duration>0)
            {
                Duration--;
            }
            else if(SuperObj_Num==1&&Object<4)
            {
                Duration = 0;
                CurAction =1;
                if(PositionX>SuperObj_TempX&&PositionY<SuperObj_TempY)
                {
                    Duration = 0;
                    CurAction =2;
                    if(true)
                    {
                        Duration = 0;
                        CurAction =3;
                    }
                    else if(FindObjStep==1)
                    {
                        Duration = 0;
                        CurAction =4;
                    }
                    else if(FindObjStep==2)
                    {
                        Duration = 0;
                        CurAction =5;
                    }
                    else if(FindObjStep==3)
                    {
                        Duration = 0;
                        CurAction =6;
                    }
                    else if(FindObjStep==4)
                    {
                        Duration = 49;
                        CurAction =7;
                    }
                }
                else if(PositionX<SuperObj_TempX&&PositionY<SuperObj_TempY
)
                {
                    Duration = 0;
                    CurAction =8;
                    if(true)
                    {
                        Duration = 0;
                        CurAction =9;
                    }
                    else if(FindObjStep==1)
                    {
                        Duration = 0;
                        CurAction =10;
                    }
                    else if(FindObjStep==2)
                    {
                        Duration = 0;
                        CurAction =11;
                    }
                    else if(FindObjStep==3)
                    {
                        Duration = 0;
                        CurAction =12;
                    }
                    else if(FindObjStep==4)
                    {
                        Duration = 49;
                        CurAction =13;
                    }
                }
                else if(PositionX<SuperObj_TempX&&PositionY>SuperObj_TempY)
                {
                    Duration = 0;
                    CurAction =14;
                    if(true)
                    {
                        Duration = 0;
                        CurAction =15;
                    }
                    else if(FindObjStep==1)
                    {
                        Duration = 0;
                        CurAction =16;
                    }
                    else if(FindObjStep==2)
                    {
                        Duration = 0;
                        CurAction =17;
                    }
                    else if(FindObjStep==3)
                    {
                        Duration = 0;
                        CurAction =18;
                    }
                    else if(FindObjStep==4)
                    {
                        Duration = 49;
                        CurAction =19;
                    }
                }
                else if(PositionX>SuperObj_TempX&&PositionY>SuperObj_TempY)
                {
                    Duration = 0;
                    CurAction =20;
                    if(true)
                    {
                        Duration = 0;
                        CurAction =21;
                    }
                    else if(FindObjStep==1)
                    {
                        Duration = 0;
                        CurAction =22;
                    }
                    else if(FindObjStep==2)
                    {
                        Duration = 0;
                        CurAction =23;
                    }
                    else if(FindObjStep==3)
                    {
                        Duration = 0;
                        CurAction =24;
                    }
                    else if(FindObjStep==4)
                    {
                        Duration = 49;
                        CurAction =25;
                    }
                }
            }
            else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=140 && CSLeft_G<=190 && CSLeft_B>=40 && CSLeft_B<=60 ||(CSRight_R>250&&(CSRight_G>140&&CSRight_G<190)&&
(CSRight_B>40&&CSRight_B<60)&&Object>0
))
            {
                Duration = 0;
                CurAction =26;
                if(IfFreeObject==1)
                {
                    Duration = 0;
                    CurAction =27;
                }
                else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=140 && CSLeft_G<=190 && CSLeft_B>=40 && CSLeft_B<=60 && CSRight_R>=250 && CSRight_R<=255 && CSRight_G>=140 && CSRight_G<=190 && CSRight_B>=40 && CSRight_B<=60)
                {
                    Duration = 49;
                    CurAction =28;
                }
            }
            else if(Object==6)
            {
                Duration = 0;
                CurAction =29;
                if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=140 && CSLeft_G<=190 && CSLeft_B>=40 && CSLeft_B<=90 && CSRight_R>=250 && CSRight_R<=255 && CSRight_G>=140 && CSRight_G<=190 && CSRight_B>=40 && CSRight_B<=60&&(Object==6))
                {
                    Duration = 49;
                    CurAction =30;
                }
                else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=140 && CSLeft_G<=190 && CSLeft_B>=40 && CSLeft_B<=60 ||(CSRight_R>250&&(CSRight_G>140&&CSRight_G<190)&&
(CSRight_B>40&&CSRight_B<60)))
                {
                    Duration = 0;
                    CurAction =31;
                }
                else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=250 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60 && CSRight_R>=250 && CSRight_R<=255 && CSRight_G>=250 && CSRight_G<=255 && CSRight_B>=40 && CSRight_B<=60)
                {
                    Duration = 0;
                    CurAction =32;
                }
                else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=250 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60 ||(CSRight_R>250&&CSRight_G>250&&CSRight_B>40&&CSRight_B<60))
                {
                    Duration = 0;
                    CurAction =33;
                }
                else if(US_Front>=0 && US_Front<=15)
                {
                    Duration = 0;
                    CurAction =34;
                }
                else if(US_Left>=0 && US_Left<=15 ||(US_Right<15))
                {
                    Duration = 0;
                    CurAction =35;
                }
                else if(US_Front>=35 && US_Front<=255 && US_Left>=35 && US_Left<=255 && US_Right>=35 && US_Right<=255)
                {
                    Duration = 0;
                    CurAction =36;
                }
                else if(true)
                {
                    Duration = 0;
                    CurAction =37;
                }
            }
            else if(CSRight_R>=250 && CSRight_R<=255 && CSRight_G>=50 && CSRight_G<=110 && CSRight_B>=250 && CSRight_B<=255&&(Object<6))
            {
                Duration = 49;
                CurAction =38;
            }
            else if(CSRight_R>=0 && CSRight_R<=7 && CSRight_G>=0 && CSRight_G<=7 && CSRight_B>=0 && CSRight_B<=7&&(Object<6))
            {
                Duration = 49;
                CurAction =39;
            }
            else if(CSRight_R>=0 && CSRight_R<=7 && CSRight_G>=120 && CSRight_G<=140 && CSRight_B>=0 && CSRight_B<=7&&(Object<6))
            {
                Duration = 49;
                CurAction =40;
            }
            else if(CSRight_R>=140 && CSRight_R<=170 && CSRight_G>=0 && CSRight_G<=10 && CSRight_B>=0 && CSRight_B<=10&&(Object<6))
            {
                Duration = 49;
                CurAction =41;
            }
            else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=30 && CSLeft_G<=110 && CSLeft_B>=250 && CSLeft_B<=255&&(Object<6))
            {
                Duration = 49;
                CurAction =42;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=7 && CSLeft_G>=0 && CSLeft_G<=7 && CSLeft_B>=0 && CSLeft_B<=7&&(Object<6))
            {
                Duration = 49;
                CurAction =43;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=7 && CSLeft_G>=120 && CSLeft_G<=140 && CSLeft_B>=0 && CSLeft_B<=7&&(Object<6))
            {
                Duration = 49;
                CurAction =44;
            }
            else if(CSLeft_R>=140 && CSLeft_R<=170 && CSLeft_G>=0 && CSLeft_G<=10 && CSLeft_B>=0 && CSLeft_B<=10&&(Object<6))
            {
                Duration = 49;
                CurAction =45;
            }
            else if(US_Front>=0 && US_Front<=15)
            {
                Duration = 0;
                CurAction =46;
            }
            else if(US_Left>=0 && US_Left<=15 ||(US_Right<15))
            {
                Duration = 0;
                CurAction =47;
            }
            else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=250 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60 ||(CSRight_R>250&&CSRight_G>250&&CSRight_B>40&&CSRight_B<60))
            {
                Duration = 0;
                CurAction =48;
            }
            else if(true)
            {
                Duration = 0;
                CurAction =49;
            }
            switch(CurAction)
            {
                case 1:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=0;
                    MyState=0;
                    SuperObj_TempX=SuperObj_X;
                    
SuperObj_TempY=SuperObj_Y;
                    
                    break;
                case 2:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    break;
                case 3:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(Compass>88&&Compass<92)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=1;
                    
}
else
{
Wheel_Left=1;
                    
Wheel_Right=-1;
                    
}
                    break;
                case 4:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(PositionX==SuperObj_X)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=2;
                    
}
else
{
Wheel_Left=3;
                    
Wheel_Right=3;
                    
}
                    break;
                case 5:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(Compass>358||Compass<2)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=3;
                    
}
else
{
Wheel_Left=1;
                    
Wheel_Right=-1;
                    
}
                    break;
                case 6:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(PositionY==SuperObj_TempY)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=4;
                    
}
else
{
Wheel_Left=3;
                    
Wheel_Right=3;
                    
}
                    break;
                case 7:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
SuperObj_Num=0;
                    
}
                    break;
                case 8:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    break;
                case 9:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(Compass>268&&Compass<272)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=1;
                    
}
else
{
Wheel_Left=1;
                    
Wheel_Right=-1;
                    
}
                    break;
                case 10:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(PositionX==SuperObj_TempX)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=2;
                    
}
else
{
Wheel_Left=3;
                    
Wheel_Right=3;
                    
}
                    break;
                case 11:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(Compass>358||Compass<2)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=3;
                    
}
else
{
Wheel_Left=-1;
                    
Wheel_Right=1;
                    
}
                    break;
                case 12:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(PositionY==SuperObj_TempY)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=4;
                    
}
else
{
Wheel_Left=3;
                    
Wheel_Right=3;
                    
}
                    break;
                case 13:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
SuperObj_Num=0;
                    
}

                    break;
                case 14:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    break;
                case 15:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(Compass>268&&Compass<272)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=1;
                    
}
else
{
Wheel_Left=1;
                    
Wheel_Right=-1;
                    
}
                    break;
                case 16:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(PositionX==SuperObj_TempX)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=2;
                    
}
else
{
Wheel_Left=3;
                    
Wheel_Right=3;
                    
}

                    break;
                case 17:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(Compass>178&&Compass<182)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=3;
                    
}
else
{
Wheel_Left=1;
                    
Wheel_Right=-1;
                    
}
                    break;
                case 18:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(PositionY==SuperObj_TempY)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=4;
                    
}
else
{
Wheel_Left=3;
                    
Wheel_Right=3;
                    
}
                    break;
                case 19:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
SuperObj_Num=0;
                    
}

                    break;
                case 20:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    break;
                case 21:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(Compass>88&&Compass<92)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=1;
                    
}
else
{
Wheel_Left=1;
                    
Wheel_Right=-1;
                    
}
                    break;
                case 22:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(PositionX==SuperObj_TempX)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=2;
                    
}
else
{
Wheel_Left=3;
                    
Wheel_Right=3;
                    
}
                    break;
                case 23:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(Compass>178&&Compass<182)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=3;
                    
}
else
{
Wheel_Left=-1;
                    
Wheel_Right=1;
                    
}
                    break;
                case 24:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(PositionY==SuperObj_TempY)
{
Wheel_Left=0;
                    
Wheel_Right=0;
                    
FindObjStep=4;
                    
}
else
{
Wheel_Left=3;
                    
Wheel_Right=3;
                    
}

                    break;
                case 25:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
SuperObj_Num=0;
                    
}

                    break;
                case 26:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(CSRight_R>250&&(CSRight_G>140&&CSRight_G<190)&&
(CSRight_B>40&&CSRight_B<60))
{
Wheel_Left=1;
                    
Wheel_Right=0;
                    
}
else
{
Wheel_Left=0;
                    
Wheel_Right=1;
                    
}

                    break;
                case 27:
                    Wheel_Left=3;
                    Wheel_Right=3;
                    LED_1=0;
                    MyState=0;
                    break;
                case 28:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=2;
                    MyState=0;
                    Object=0;
                    
IfFreeObject=1;
                    
                    break;
                case 29:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    break;
                case 30:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=2;
                    MyState=0;
                    Object=0;
                    
                    break;
                case 31:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(CSRight_R>250&&(CSRight_G>140&&CSRight_G<190)&&
(CSRight_B>40&&CSRight_B<60)&&Object==6)
{
Wheel_Left=1;
                    
Wheel_Right=0;
                    
}
else
{
Wheel_Left=0;
                    
Wheel_Right=1;
                    
}
                    break;
                case 32:
                    Wheel_Left=3;
                    Wheel_Right=-4;
                    LED_1=0;
                    MyState=0;
                    break;
                case 33:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(CSLeft_R>250&&CSLeft_G>250&&(CSLeft_B>40&&CSLeft_B<60))
{
Wheel_Left=3;
                    
Wheel_Right=2;
                    
}
else
{
Wheel_Left=2;
                    
Wheel_Right=3;
                    
}
                    break;
                case 34:
                    Wheel_Left=3;
                    Wheel_Right=-4;
                    LED_1=0;
                    MyState=0;
                    break;
                case 35:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(US_Left<15)
{
Wheel_Left=3;
                    
Wheel_Right=2;
                    
}
else
{
Wheel_Left=2;
                    
Wheel_Right=3;
                    
}
                    break;
                case 36:
                    Wheel_Left=3;
                    Wheel_Right=3;
                    LED_1=0;
                    MyState=0;
                    break;
                case 37:
                    Wheel_Left=2;
                    Wheel_Right=3;
                    LED_1=0;
                    MyState=0;
                    break;
                case 38:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
}
                    break;
                case 39:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
}
                    break;
                case 40:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
}
                    break;
                case 41:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
}
                    break;
                case 42:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
}
                    break;
                case 43:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
}
                    break;
                case 44:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
}
                    break;
                case 45:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration==0)
{
Object=Object+1;
                    
}
                    break;
                case 46:
                    Wheel_Left=-2;
                    Wheel_Right=2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 47:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(US_Left<15)
{
Wheel_Left=2;
                    
Wheel_Right=-2;
                    
}
else
{
Wheel_Left=-2;
                    
Wheel_Right=2;
                    
}
                    break;
                case 48:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    if(CSLeft_R>250&&CSLeft_G>250&&CSLeft_B>40&&CSLeft_B<60)
{
Wheel_Left=2;
                    
Wheel_Right=-2;
                    
}
else
{
Wheel_Left=-2;
                    
Wheel_Right=2;
                    
}
                    break;
                case 49:
                    Wheel_Left=3;
                    Wheel_Right=3;
                    LED_1=0;
                    MyState=0;
                    IfFreeObject=0;
                    
                    break;
                default:
                    break;
            }

        }


    }
}
