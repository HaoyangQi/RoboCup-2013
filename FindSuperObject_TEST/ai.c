//CsBot_AI_H
//Do NOT delete the Above Line
///////////////////////////////

//The robot ID : It must be two char, such as '00','kl' or 'Cr'.
char AI_MyID[2] = {'0','2'};
///////////////////////////////////
int AI_MotorType = 0;
int Duration = 0;
int SuperDuration = 0;
int bGameEnd = false;
int CurAction = 0;
int CurGame = 0;
int SuperObj_Num = 0;
int SuperObj_X = 0;
int SuperObj_Y = 0;
int Teleport = 0;
int LoadedObjects = 0;
int RedObject = 0;
int GreenObject = 0;
int BlackObject = 0;
int IfFreeObject = 0;
int Object = 0;
int FindObjStep = 0;
int SuperObj_TempX = 0;
int SuperObj_TempY = 0;
int US_Front = 0;
int US_Back = 0;
int US_Left = 0;
int US_Right = 0;
int CSLeft_R = 0;
int CSLeft_G = 0;
int CSLeft_B = 0;
int CSRight_R = 0;
int CSRight_G = 0;
int CSRight_B = 0;
int PositionX = 0;
int PositionY = 0;
int TM_State = 0;
int Compass = 0;
int Time = 0;
int Wheel_Left = 0;
int Wheel_Right = 0;
int LED_1 = 0;
int MyState = 0;
int AI_SensorNum = 14;



//CsBot_AI_C
//Do NOT delete the Above Line
///////////////////////////////

 
//Only Used by CsBot Dance Platform
void SetGameID(int GameID)
{
    CurGame = GameID;
    bGameEnd = false;
}

 
//Only Used by CsBot Dance Platform
int GetGameID()
{
    return CurGame;
}

 
//Only Used by CsBot Dance Platform
int IsGameEnd()
{
    return bGameEnd;
}

 
//Only Used by CsBot Rescue Platform
int GetTeleport()
{
    return Teleport;
}

 
//Only Used by CsBot Rescue Platform
void SetSuperObj(int X, int Y, int num)
{
    SuperObj_X = X;
    SuperObj_Y = Y;
    SuperObj_Num = num;
}
void SetDataAI(int *AI_CCP , int *AI_ADC ,int *AI_INFO)
{

    int sum = 0;

    US_Front = AI_ADC[0]; packet[0] = US_Front; sum += US_Front;
    US_Back = AI_ADC[1]; packet[1] = US_Back; sum += US_Back;
    US_Left = AI_ADC[2]; packet[2] = US_Left; sum += US_Left;
    US_Right = AI_ADC[3]; packet[3] = US_Right; sum += US_Right;
    CSLeft_R = AI_CCP[1]; packet[4] = CSLeft_R; sum += CSLeft_R;
    CSLeft_G = AI_CCP[2]; packet[5] = CSLeft_G; sum += CSLeft_G;
    CSLeft_B = AI_CCP[3]; packet[6] = CSLeft_B; sum += CSLeft_B;
    CSRight_R = AI_CCP[4]; packet[7] = CSRight_R; sum += CSRight_R;
    CSRight_G = AI_CCP[5]; packet[8] = CSRight_G; sum += CSRight_G;
    CSRight_B = AI_CCP[6]; packet[9] = CSRight_B; sum += CSRight_B;
    PositionX = AI_INFO[2]; packet[10] = PositionX; sum += PositionX;
    PositionY = AI_INFO[3]; packet[11] = PositionY; sum += PositionY;
    TM_State = AI_INFO[1]; packet[12] = TM_State; sum += TM_State;
    Compass = AI_Compass; packet[13] = Compass; sum += Compass;
    Time = Play_Time_S;
    packet[14] = sum;

}
void GetCommand(int *Motor, int *LegoMotor, int *LED , int *Info)
{
    Motor[0] = Wheel_Left;
    Motor[2] = Wheel_Right;
    LED[0] = LED_1;
    LED[1] = LED_1;
    Info[0] = MyState;
}
void Game0()
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
        else if(US_Front>=35 && US_Front<=255 && US_Left>=35 && US_Left<=255 && US_Right>=35 && US_Right<=255)
        {
            Duration = 0;
            CurAction =9;
        }
        else if(true)
        {
            Duration = 0;
            CurAction =10;
        }
    }
    else if(CSRight_R>=0 && CSRight_R<=7 && CSRight_G>=0 && CSRight_G<=7 && CSRight_B>=0 && CSRight_B<=7&&(BlackObject<1))
    {
        Duration = 49;
        CurAction =11;
    }
    else if(CSRight_R>=0 && CSRight_R<=7 && CSRight_G>=120 && CSRight_G<=140 && CSRight_B>=0 && CSRight_B<=7&&(GreenObject<1))
    {
        Duration = 49;
        CurAction =12;
    }
    else if(CSRight_R>=140 && CSRight_R<=170 && CSRight_G>=0 && CSRight_G<=10 && CSRight_B>=0 && CSRight_B<=10&&(RedObject<1))
    {
        Duration = 49;
        CurAction =13;
    }
    else if(CSLeft_R>=0 && CSLeft_R<=7 && CSLeft_G>=0 && CSLeft_G<=7 && CSLeft_B>=0 && CSLeft_B<=7&&(BlackObject<1))
    {
        Duration = 49;
        CurAction =14;
    }
    else if(CSLeft_R>=0 && CSLeft_R<=7 && CSLeft_G>=120 && CSLeft_G<=140 && CSLeft_B>=0 && CSLeft_B<=7&&(GreenObject<1))
    {
        Duration = 49;
        CurAction =15;
    }
    else if(CSLeft_R>=140 && CSLeft_R<=170 && CSLeft_G>=0 && CSLeft_G<=10 && CSLeft_B>=0 && CSLeft_B<=10&&(RedObject<1))
    {
        Duration = 49;
        CurAction =16;
    }
    else if(US_Left>=0 && US_Left<=15 ||(US_Right<15))
    {
        Duration = 0;
        CurAction =17;
    }
    else if(US_Front>=0 && US_Front<=15)
    {
        Duration = 0;
        CurAction =18;
    }
    else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=250 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60 ||(CSRight_R>250&&CSRight_G>250&&(CSRight_B>40&&CSRight_B<60)))
    {
        Duration = 0;
        CurAction =19;
    }
    else if(true)
    {
        Duration = 0;
        CurAction =20;
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
            Wheel_Left=3;
            Wheel_Right=3;
            LED_1=0;
            MyState=0;
            break;
        case 10:
            Wheel_Left=2;
            Wheel_Right=3;
            LED_1=0;
            MyState=0;
            break;
        case 11:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration==0)
{
BlackObject=BlackObject+1;
                    
}
            break;
        case 12:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration==0)
{
GreenObject=GreenObject+1;
                    
}
            break;
        case 13:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration==0)
{
RedObject=RedObject+1;
                    
}
            break;
        case 14:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration==0)
{
BlackObject=BlackObject+1;
                    
}
            break;
        case 15:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration==0)
{
GreenObject=GreenObject+1;
                    
}
            break;
        case 16:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration==0)
{
RedObject=RedObject+1;
                    
}
            break;
        case 17:
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
        case 18:
            Wheel_Left=-2;
            Wheel_Right=2;
            LED_1=0;
            MyState=0;
            break;
        case 19:
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
        case 20:
            Wheel_Left=3;
            Wheel_Right=3;
            LED_1=0;
            MyState=0;
            break;
        default:
            break;
    }

}

void Game1()
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
            if(FindObjStep==4)
            {
                Duration = 49;
                CurAction =3;
            }
            else if(FindObjStep==3)
            {
                Duration = 0;
                CurAction =4;
            }
            else if(FindObjStep==2)
            {
                Duration = 0;
                CurAction =5;
            }
            else if(FindObjStep==1)
            {
                Duration = 0;
                CurAction =6;
            }
        }
        else if(PositionX<SuperObj_TempX&&PositionY<SuperObj_TempY
)
        {
            Duration = 0;
            CurAction =7;
            if(FindObjStep==4)
            {
                Duration = 49;
                CurAction =8;
            }
            else if(FindObjStep==3)
            {
                Duration = 0;
                CurAction =9;
            }
            else if(FindObjStep==2)
            {
                Duration = 0;
                CurAction =10;
            }
            else if(FindObjStep==1)
            {
                Duration = 0;
                CurAction =11;
            }
        }
        else if(PositionX<SuperObj_TempX&&PositionY>SuperObj_TempY)
        {
            Duration = 0;
            CurAction =12;
            if(FindObjStep==4)
            {
                Duration = 49;
                CurAction =13;
            }
            else if(FindObjStep==3)
            {
                Duration = 0;
                CurAction =14;
            }
            else if(FindObjStep==2)
            {
                Duration = 0;
                CurAction =15;
            }
            else if(FindObjStep==1)
            {
                Duration = 0;
                CurAction =16;
            }
        }
        else if(PositionX>SuperObj_TempX&&PositionY>SuperObj_TempY)
        {
            Duration = 0;
            CurAction =17;
            if(FindObjStep==4)
            {
                Duration = 49;
                CurAction =18;
            }
            else if(FindObjStep==3)
            {
                Duration = 0;
                CurAction =19;
            }
            else if(FindObjStep==2)
            {
                Duration = 0;
                CurAction =20;
            }
            else if(FindObjStep==1)
            {
                Duration = 0;
                CurAction =21;
            }
        }
    }
    else if(US_Left>=0 && US_Left<=15 ||(US_Right<15))
    {
        Duration = 0;
        CurAction =22;
    }
    else if(CSLeft_R>=250 && CSLeft_R<=255 && CSLeft_G>=250 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60 ||(CSRight_R>250&&CSRight_G>250&&CSRight_B>40&&CSRight_B<60))
    {
        Duration = 0;
        CurAction =23;
    }
    else if(true)
    {
        Duration = 0;
        CurAction =24;
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
        case 3:
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
        case 4:
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
        case 7:
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
        case 8:
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
        case 9:
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
        case 10:
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
        case 11:
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
        case 12:
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
        case 15:
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
        case 18:
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
        case 19:
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
        case 20:
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
        case 21:
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
        case 22:
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
        case 23:
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
        case 24:
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


void OnTimer()
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
