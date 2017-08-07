using System;

namespace AI
{
    public static class AI
    {
        static int Duration = 0;
        static int SuperDuration = 0;
        static bool bGameEnd = false;
        static int CurAction = -1;
        static int CurGame = 0;
        static int SuperObj_Num = 0;
        static int SuperObj_X = 0;
        static int SuperObj_Y = 0;
        static int Teleport = 0;
        static int LoadedObjects = 0;
        static int azul = 0;
        static int FirstTime = 0;
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
             return "Int egrado;";
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
            else if(CSLeft_R>=130 && CSLeft_R<=150 && CSLeft_G>=94 && CSLeft_G<=114 && CSLeft_B>=41 && CSLeft_B<=61 && CSRight_R>=130 && CSRight_R<=150 && CSRight_G>=94 && CSRight_G<=114 && CSRight_B>=41 && CSRight_B<=61&&(LoadedObjects>0))
            {
                Duration = 59;
                CurAction =1;
            }
            else if(CSRight_R>=130 && CSRight_R<=150 && CSRight_G>=94 && CSRight_G<=114 && CSRight_B>=41 && CSRight_B<=61&&(LoadedObjects>0))
            {
                Duration = 2;
                CurAction =2;
            }
            else if(CSLeft_R>=130 && CSLeft_R<=150 && CSLeft_G>=94 && CSLeft_G<=114 && CSLeft_B>=41 && CSLeft_B<=61&&(LoadedObjects>0))
            {
                Duration = 2;
                CurAction =3;
            }
            else if(Time>=180 && Time<=200)
            {
                Duration = 0;
                CurAction =4;
            }
            else if(CSLeft_R>=130 && CSLeft_R<=150 && CSLeft_G>=147 && CSLeft_G<=167 && CSLeft_B>=41 && CSLeft_B<=61 && CSRight_R>=130 && CSRight_R<=150 && CSRight_G>=147 && CSRight_G<=167 && CSRight_B>=41 && CSRight_B<=61&&(LoadedObjects>0))
            {
                Duration = 2;
                CurAction =5;
            }
            else if(CSRight_R>=130 && CSRight_R<=150 && CSRight_G>=147 && CSRight_G<=167 && CSRight_B>=41 && CSRight_B<=61&&(LoadedObjects>0))
            {
                Duration = 2;
                CurAction =6;
            }
            else if(CSLeft_R>=130 && CSLeft_R<=150 && CSLeft_G>=147 && CSLeft_G<=167 && CSLeft_B>=41 && CSLeft_B<=61&&(LoadedObjects>0))
            {
                Duration = 2;
                CurAction =7;
            }
            else if(CSRight_R>=0 && CSRight_R<=40 && CSRight_G>=0 && CSRight_G<=40 && CSRight_B>=0 && CSRight_B<=40&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =8;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=40 && CSLeft_G>=0 && CSLeft_G<=40 && CSLeft_B>=0 && CSLeft_B<=40&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =9;
            }
            else if(CSRight_R>=0 && CSRight_R<=60 && CSRight_G>=80 && CSRight_G<=180 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =10;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=60 && CSLeft_G>=80 && CSLeft_G<=180 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =11;
            }
            else if(CSRight_R>=80 && CSRight_R<=180 && CSRight_G>=0 && CSRight_G<=60 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6
))
            {
                Duration = 49;
                CurAction =12;
            }
            else if(CSLeft_R>=80 && CSLeft_R<=180 && CSLeft_G>=0 && CSLeft_G<=60 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =13;
            }
            else if(US_Front>=0 && US_Front<=7)
            {
                Duration = 0;
                CurAction =14;
            }
            else if(US_Right>=0 && US_Right<=4)
            {
                Duration = 0;
                CurAction =15;
            }
            else if(US_Left>=0 && US_Left<=8)
            {
                Duration = 0;
                CurAction =16;
            }
            else if(true)
            {
                Duration = 0;
                CurAction =17;
            }
            switch(CurAction)
            {
                case 1:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=2;
                    MyState=0;
                    if(Duration == 1) {  LoadedObjects = 0;}
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
                    LED_1=0;
                    MyState=0;
                    LoadedObjects=0;
                    
                     Teleport = 1;  
                    break;
                case 5:
                    Wheel_Left=-3;
                    Wheel_Right=-1;
                    LED_1=0;
                    MyState=0;
                    break;
                case 6:
                    Wheel_Left=-4;
                    Wheel_Right=0;
                    LED_1=0;
                    MyState=0;
                    break;
                case 7:
                    Wheel_Left=0;
                    Wheel_Right=-4;
                    LED_1=0;
                    MyState=0;
                    break;
                case 8:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
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
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
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
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
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
                    if(Duration < 7)
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
                    if(Duration < 7)
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
                    if(Duration < 7)
                    {
                        Wheel_Left = 2;
                        Wheel_Right = 2;
                    }
                    break;
                case 14:
                    Wheel_Left=-1;
                    Wheel_Right=1;
                    LED_1=0;
                    MyState=0;
                    break;
                case 15:
                    Wheel_Left=-2;
                    Wheel_Right=0;
                    LED_1=0;
                    MyState=0;
                    break;
                case 16:
                    Wheel_Left=0;
                    Wheel_Right=-4;
                    LED_1=0;
                    MyState=0;
                    break;
                case 17:
                    Wheel_Left=4;
                    Wheel_Right=4;
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
            else if(CSLeft_R>=130 && CSLeft_R<=150 && CSLeft_G>=94 && CSLeft_G<=114 && CSLeft_B>=41 && CSLeft_B<=61 && CSRight_R>=130 && CSRight_R<=150 && CSRight_G>=94 && CSRight_G<=114 && CSRight_B>=41 && CSRight_B<=61&&(LoadedObjects>0))
            {
                Duration = 59;
                CurAction =1;
            }
            else if(CSRight_R>=130 && CSRight_R<=150 && CSRight_G>=94 && CSRight_G<=114 && CSRight_B>=41 && CSRight_B<=61&&(LoadedObjects>0))
            {
                Duration = 2;
                CurAction =2;
            }
            else if(CSLeft_R>=130 && CSLeft_R<=150 && CSLeft_G>=94 && CSLeft_G<=114 && CSLeft_B>=41 && CSLeft_B<=61&&(LoadedObjects>0))
            {
                Duration = 2;
                CurAction =3;
            }
            else if(CSRight_R>=130 && CSRight_R<=150 && CSRight_G>=147 && CSRight_G<=167 && CSRight_B>=41 && CSRight_B<=61&&(LoadedObjects>0))
            {
                Duration = 9;
                CurAction =4;
            }
            else if(CSLeft_R>=130 && CSLeft_R<=150 && CSLeft_G>=147 && CSLeft_G<=167 && CSLeft_B>=41 && CSLeft_B<=61&&(LoadedObjects>0
))
            {
                Duration = 9;
                CurAction =5;
            }
            else if(CSRight_R>=79 && CSRight_R<=99 && CSRight_G>=0 && CSRight_G<=10 && CSRight_B>=91 && CSRight_B<=211&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =6;
            }
            else if(CSLeft_R>=79 && CSLeft_R<=99 && CSLeft_G>=0 && CSLeft_G<=10 && CSLeft_B>=91 && CSLeft_B<=211&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =7;
            }
            else if(CSRight_R>=0 && CSRight_R<=40 && CSRight_G>=0 && CSRight_G<=40 && CSRight_B>=0 && CSRight_B<=40&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =8;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=40 && CSLeft_G>=0 && CSLeft_G<=40 && CSLeft_B>=0 && CSLeft_B<=40&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =9;
            }
            else if(CSRight_R>=0 && CSRight_R<=60 && CSRight_G>=80 && CSRight_G<=180 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =10;
            }
            else if(CSLeft_R>=0 && CSLeft_R<=60 && CSLeft_G>=80 && CSLeft_G<=180 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =11;
            }
            else if(CSRight_R>=80 && CSRight_R<=180 && CSRight_G>=0 && CSRight_G<=60 && CSRight_B>=0 && CSRight_B<=60&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =12;
            }
            else if(CSLeft_R>=80 && CSLeft_R<=180 && CSLeft_G>=0 && CSLeft_G<=60 && CSLeft_B>=0 && CSLeft_B<=60&&(LoadedObjects<6))
            {
                Duration = 49;
                CurAction =13;
            }
            else if(US_Front>=0 && US_Front<=15)
            {
                Duration = 0;
                CurAction =14;
            }
            else if(US_Left>=0 && US_Left<=10)
            {
                Duration = 0;
                CurAction =15;
            }
            else if(US_Right>=0 && US_Right<=10)
            {
                Duration = 0;
                CurAction =16;
            }
            else if(true)
            {
                Duration = 0;
                CurAction =17;
            }
            switch(CurAction)
            {
                case 1:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=2;
                    MyState=0;
                    if(Duration == 1) {  LoadedObjects = 0;}
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
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
                    {
                        Wheel_Left = 2;
                        Wheel_Right = 2;
                    }
                    break;
                case 7:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=1;
                    MyState=0;
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
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
                    FirstTime=1;
                    
                    if(Duration == 1) LoadedObjects++;
                    if(Duration < 7)
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
                    if(Duration < 7)
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
                    if(Duration < 7)
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
                    if(Duration < 7)
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
                    if(Duration < 7)
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
                    if(Duration < 7)
                    {
                        Wheel_Left = 2;
                        Wheel_Right = 2;
                    }
                    break;
                case 14:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=0;
                    MyState=0;
                    if(LoadedObjects>2){
Wheel_Left= 0;
                    
Wheel_Right=-2;
                    
}
else{
Wheel_Left= -3;
                    
Wheel_Right=0;
                    
}
                    break;
                case 15:
                    Wheel_Left=0;
                    Wheel_Right=-4;
                    LED_1=0;
                    MyState=0;
                    break;
                case 16:
                    Wheel_Left=-4;
                    Wheel_Right=0;
                    LED_1=0;
                    MyState=0;
                    break;
                case 17:
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
                    break;
                default:
                    break;
            }

        }


    }
}
