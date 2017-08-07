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
int CurAction = -1;
int CurGame = 0;
int SuperObj_Num = 0;
int SuperObj_X = 0;
int SuperObj_Y = 0;
int Teleport = 0;
int LoadedObjects = 0;
int azul = 0;
int FirstTime = 0;
int FrontTolerance = 15;
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
    Time = Play_Time_MS/1000;
    packet[14] = sum;

}
void GetCommand(int *Motor, int *LegoMotor, int *LED , int *Info)
{
    Motor[0] = Wheel_Left;
    Motor[2] = Wheel_Right;
    LED[0] = LED_1;
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
    else if(Time>=180 && Time<=200)
    {
        Duration = 0;
        CurAction =1;
    }
    else if(CSRight_R>=240 && CSRight_R<=255 && CSRight_G>=155 && CSRight_G<=183 && CSRight_B>=40 && CSRight_B<=60&&(LoadedObjects>0))
    {
        Duration = 2;
        CurAction =2;
    }
    else if(CSLeft_R>=240 && CSLeft_R<=255 && CSLeft_G>=155 && CSLeft_G<=183 && CSLeft_B>=40 && CSLeft_B<=60&&(LoadedObjects>0))
    {
        Duration = 2;
        CurAction =3;
    }
    else if(CSLeft_R>=240 && CSLeft_R<=255 && CSLeft_G>=155 && CSLeft_G<=183 && CSLeft_B>=40 && CSLeft_B<=60 && CSRight_R>=240 && CSRight_R<=255 && CSRight_G>=155 && CSRight_G<=183 && CSRight_B>=40 && CSRight_B<=60&&(LoadedObjects>0))
    {
        Duration = 59;
        CurAction =4;
    }
    else if(CSRight_R>=235 && CSRight_R<=255 && CSRight_G>=235 && CSRight_G<=255 && CSRight_B>=40 && CSRight_B<=60&&(LoadedObjects>0))
    {
        Duration = 2;
        CurAction =5;
    }
    else if(CSLeft_R>=235 && CSLeft_R<=255 && CSLeft_G>=235 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60&&(LoadedObjects>0))
    {
        Duration = 2;
        CurAction =6;
    }
    else if(CSRight_R>=31 && CSRight_R<=71 && CSRight_G>=31 && CSRight_G<=71 && CSRight_B>=235 && CSRight_B<=255 ||((CSLeft_G>=31&&CSLeft_G<=71)&&(CSLeft_R>=31&&CSLeft_R<=71)&&(CSLeft_B>=230&&CSLeft_B<=255)))
    {
        Duration = 9;
        CurAction =7;
    }
    else if(CSRight_R>=180 && CSRight_R<=229 && CSRight_G>=0 && CSRight_G<=50 && CSRight_B>=230 && CSRight_B<=255&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =8;
    }
    else if(CSLeft_R>=180 && CSLeft_R<=229 && CSLeft_G>=0 && CSLeft_G<=50 && CSLeft_B>=230 && CSLeft_B<=255&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =9;
    }
    else if(CSRight_R>=0 && CSRight_R<=60 && CSRight_G>=0 && CSRight_G<=60 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =10;
    }
    else if(CSLeft_R>=0 && CSLeft_R<=60 && CSLeft_G>=0 && CSLeft_G<=60 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =11;
    }
    else if(CSRight_R>=0 && CSRight_R<=60 && CSRight_G>=61 && CSRight_G<=180 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =12;
    }
    else if(CSLeft_R>=0 && CSLeft_R<=60 && CSLeft_G>=61 && CSLeft_G<=180 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =13;
    }
    else if(CSRight_R>=61 && CSRight_R<=180 && CSRight_G>=0 && CSRight_G<=60 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6
))
    {
        Duration = 49;
        CurAction =14;
    }
    else if(CSLeft_R>=61 && CSLeft_R<=180 && CSLeft_G>=0 && CSLeft_G<=60 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =15;
    }
    else if(US_Front<=FrontTolerance)
    {
        Duration = 7;
        CurAction =16;
    }
    else if(US_Left>=0 && US_Left<=8)
    {
        Duration = 1;
        CurAction =17;
    }
    else if(CSRight_R>=153 && CSRight_R<=173 && CSRight_G>=161 && CSRight_G<=181 && CSRight_B>=209 && CSRight_B<=229&&(azul==1))
    {
        Duration = 1;
        CurAction =18;
    }
    else if(CSLeft_R>=153 && CSLeft_R<=173 && CSLeft_G>=161 && CSLeft_G<=181 && CSLeft_B>=209 && CSLeft_B<=229&&(azul==1))
    {
        Duration = 1;
        CurAction =19;
    }
    else if(CSLeft_R>=100 && CSLeft_R<=121 && CSLeft_G>=170 && CSLeft_G<=190 && CSLeft_B>=209 && CSLeft_B<=255 && CSRight_R>=100 && CSRight_R<=121 && CSRight_G>=170 && CSRight_G<=190 && CSRight_B>=209 && CSRight_B<=255)
    {
        Duration = 1;
        CurAction =20;
    }
    else if(true)
    {
        Duration = 0;
        CurAction =21;
    }
    switch(CurAction)
    {
        case 1:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            LoadedObjects=0;
                    
             Teleport = 1;  
            break;
        case 2:
            Wheel_Left=4;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            break;
        case 3:
            Wheel_Left=0;
            Wheel_Right=4;
            LED_1=0;
            MyState=0;
            break;
        case 4:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=2;
            MyState=0;
            if(Duration == 1) {LoadedObjects = 0; } 
            break;
        case 5:
            Wheel_Left=-4;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            break;
        case 6:
            Wheel_Left=0;
            Wheel_Right=-4;
            LED_1=0;
            MyState=0;
            break;
        case 7:
            Wheel_Left=4;
            Wheel_Right=4;
            LED_1=0;
            MyState=0;
            LoadedObjects=0;
                    
            break;
        case 8:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            break;
        case 9:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            break;
        case 10:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 11:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 12:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 13:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 14:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 15:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 16:
            Wheel_Left=-2;
            Wheel_Right=1;
            LED_1=0;
            MyState=0;
            break;
        case 17:
            Wheel_Left=0;
            Wheel_Right=-4;
            LED_1=0;
            MyState=0;
            break;
        case 18:
            Wheel_Left=-4;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            break;
        case 19:
            Wheel_Left=0;
            Wheel_Right=-4;
            LED_1=0;
            MyState=0;
            break;
        case 20:
            Wheel_Left=4;
            Wheel_Right=4;
            LED_1=0;
            MyState=0;
            if(LoadedObjects < 2){
    azul = 1;
                    
}
else{
    azul = 0;
                    
}
            break;
        case 21:
            Wheel_Left=4;
            Wheel_Right=4;
            LED_1=0;
            MyState=0;
            if(LoadedObjects>2&&Compass>=85&&Compass<=95){
 FrontTolerance = 7;
                    
}else{
 FrontTolerance = 15;
                    
}
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
    else if(CSRight_R>=240 && CSRight_R<=255 && CSRight_G>=155 && CSRight_G<=183 && CSRight_B>=40 && CSRight_B<=60&&(LoadedObjects>0))
    {
        Duration = 2;
        CurAction =1;
    }
    else if(CSLeft_R>=240 && CSLeft_R<=255 && CSLeft_G>=155 && CSLeft_G<=183 && CSLeft_B>=40 && CSLeft_B<=60&&(LoadedObjects>0))
    {
        Duration = 2;
        CurAction =2;
    }
    else if(CSLeft_R>=240 && CSLeft_R<=255 && CSLeft_G>=155 && CSLeft_G<=183 && CSLeft_B>=40 && CSLeft_B<=60 && CSRight_R>=240 && CSRight_R<=255 && CSRight_G>=155 && CSRight_G<=183 && CSRight_B>=40 && CSRight_B<=60&&(LoadedObjects>0))
    {
        Duration = 59;
        CurAction =3;
    }
    else if(CSRight_R>=235 && CSRight_R<=255 && CSRight_G>=235 && CSRight_G<=255 && CSRight_B>=40 && CSRight_B<=60&&(LoadedObjects>0))
    {
        Duration = 9;
        CurAction =4;
    }
    else if(CSLeft_R>=235 && CSLeft_R<=255 && CSLeft_G>=235 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60&&(LoadedObjects>0
))
    {
        Duration = 9;
        CurAction =5;
    }
    else if(CSRight_R>=31 && CSRight_R<=71 && CSRight_G>=31 && CSRight_G<=71 && CSRight_B>=235 && CSRight_B<=255&&((CSLeft_G>=31&&CSLeft_G<=71)&&(CSLeft_R>=31&&CSLeft_R<=71)&&(CSLeft_B>=230&&CSLeft_B<=255)))
    {
        Duration = 0;
        CurAction =6;
    }
    else if(CSRight_R>=180 && CSRight_R<=229 && CSRight_G>=0 && CSRight_G<=50 && CSRight_B>=230 && CSRight_B<=255&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =7;
    }
    else if(CSLeft_R>=180 && CSLeft_R<=229 && CSLeft_G>=0 && CSLeft_G<=50 && CSLeft_B>=230 && CSLeft_B<=255&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =8;
    }
    else if(CSRight_R>=0 && CSRight_R<=60 && CSRight_G>=0 && CSRight_G<=60 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =9;
    }
    else if(CSLeft_R>=0 && CSLeft_R<=60 && CSLeft_G>=0 && CSLeft_G<=60 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =10;
    }
    else if(CSRight_R>=0 && CSRight_R<=60 && CSRight_G>=61 && CSRight_G<=180 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =11;
    }
    else if(CSLeft_R>=0 && CSLeft_R<=60 && CSLeft_G>=61 && CSLeft_G<=180 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =12;
    }
    else if(CSRight_R>=61 && CSRight_R<=180 && CSRight_G>=0 && CSRight_G<=60 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =13;
    }
    else if(CSLeft_R>=61 && CSLeft_R<=180 && CSLeft_G>=0 && CSLeft_G<=60 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
    {
        Duration = 49;
        CurAction =14;
    }
    else if(US_Front<=FrontTolerance)
    {
        Duration = 1;
        CurAction =15;
    }
    else if(US_Left>=0 && US_Left<=10)
    {
        Duration = 1;
        CurAction =16;
    }
    else if(US_Right>=0 && US_Right<=10)
    {
        Duration = 1;
        CurAction =17;
    }
    else if(CSLeft_R>=153 && CSLeft_R<=173 && CSLeft_G>=161 && CSLeft_G<=181 && CSLeft_B>=209 && CSLeft_B<=229 && Time>=180 && Time<=240&&(azul==1))
    {
        Duration = 1;
        CurAction =18;
    }
    else if(CSRight_R>=153 && CSRight_R<=173 && CSRight_G>=161 && CSRight_G<=181 && CSRight_B>=209 && CSRight_B<=229 && Time>=180 && Time<=240&&(azul==1))
    {
        Duration = 1;
        CurAction =19;
    }
    else if(CSLeft_R>=100 && CSLeft_R<=121 && CSLeft_G>=170 && CSLeft_G<=190 && CSLeft_B>=209 && CSLeft_B<=255 && CSRight_R>=100 && CSRight_R<=121 && CSRight_G>=170 && CSRight_G<=190 && CSRight_B>=209 && CSRight_B<=255 && Time>=180 && Time<=240)
    {
        Duration = 0;
        CurAction =20;
    }
    else if(true)
    {
        Duration = 0;
        CurAction =21;
    }
    switch(CurAction)
    {
        case 1:
            Wheel_Left=4;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            break;
        case 2:
            Wheel_Left=0;
            Wheel_Right=4;
            LED_1=0;
            MyState=0;
            break;
        case 3:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=2;
            MyState=0;
            if(Duration == 1) {LoadedObjects = 0; } 
            break;
        case 4:
            Wheel_Left=-4;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            break;
        case 5:
            Wheel_Left=0;
            Wheel_Right=-4;
            LED_1=0;
            MyState=0;
            break;
        case 6:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            LoadedObjects=0;
                    
            break;
        case 7:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 8:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 9:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            FirstTime=1;
                    
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 10:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            FirstTime=1;
                    
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 11:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            FirstTime=1;
                    
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 12:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            FirstTime=1;
                    
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 13:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            FirstTime=1;
                    
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 14:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=1;
            MyState=0;
            FirstTime=1;
                    
            if(Duration == 1) LoadedObjects++;
            if(Duration < 6)
            {
                Wheel_Left = 2;
                Wheel_Right = 2;
            }
            break;
        case 15:
            Wheel_Left=0;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            if(LoadedObjects>2){
Wheel_Left= 1;
                    
Wheel_Right=-2;
                    
}
else{
Wheel_Left= -3;
                    
Wheel_Right=0;
                    
}
            break;
        case 16:
            Wheel_Left=0;
            Wheel_Right=-4;
            LED_1=0;
            MyState=0;
            break;
        case 17:
            Wheel_Left=-4;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            break;
        case 18:
            Wheel_Left=0;
            Wheel_Right=-4;
            LED_1=0;
            MyState=0;
            break;
        case 19:
            Wheel_Left=-4;
            Wheel_Right=0;
            LED_1=0;
            MyState=0;
            break;
        case 20:
            Wheel_Left=4;
            Wheel_Right=4;
            LED_1=0;
            MyState=0;
            if(LoadedObjects < 5){
    azul = 1;
                    
}
else{
    azul = 0;
                    
}
            break;
        case 21:
            Wheel_Left=5;
            Wheel_Right=5;
            LED_1=0;
            MyState=0;
            if(LoadedObjects > 0)
{
Wheel_Left =4;
                    
Wheel_Right =4;
                    
}

else if (FirstTime==0)
{
Wheel_Left =4;
                    
Wheel_Right =4;
                    
}
else
{
Wheel_Left =5;
                    
Wheel_Right =5;
                    
}

if(LoadedObjects>2&&((Compass>=85&&Compass<=95)||(Compass >=265 && Compass <=275))){
 FrontTolerance = 7;
                    
}else{
 FrontTolerance = 15;
                    
}
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
