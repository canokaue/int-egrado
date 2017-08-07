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
        static int OrangeFound = 0;
        static int camaxinho = 2;
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
            else if(CSLeft_R>=230 && CSLeft_R<=255 && CSLeft_G>=141 && CSLeft_G<=181 && CSLeft_B>=31 && CSLeft_B<=71 && CSRight_R>=230 && CSRight_R<=255 && CSRight_G>=141 && CSRight_G<=181 && CSRight_B>=31 && CSRight_B<=71&&(LoadedObjects>2))
            {
                Duration = 59;
                CurAction =1;
            }
            else if(CSRight_R>=230 && CSRight_R<=255 && CSRight_G>=141 && CSRight_G<=181 && CSRight_B>=31 && CSRight_B<=71&&(LoadedObjects>2))
            {
                Duration = 1;
                CurAction =2;
            }
            else if(CSLeft_R>=230 && CSLeft_R<=255 && CSLeft_G>=141 && CSLeft_G<=181 && CSLeft_B>=31 && CSLeft_B<=71&&(LoadedObjects>2))
            {
                Duration = 1;
                CurAction =3;
            }
            else if((Teleport==1&&LoadedObjects<6&&CSLeft_R>=200&&(CSLeft_G>=97&&CSLeft_G<=137)&&CSLeft_B>=200)
||
(Teleport==1&&LoadedObjects<6&&CSRight_R>=200&&(CSRight_G>=97&&CSRight_G<=137)&&CSRight_B>=200)
)
            {
                Duration = 49;
                CurAction =4;
            }
            else if(((LoadedObjects<6)&&
(CSRight_B<=40&&CSRight_G<=40&&CSRight_R<=40)||
(LoadedObjects<6)&&
(CSLeft_B<=40&&CSLeft_G<=40&&CSLeft_R<=40)))
            {
                Duration = 49;
                CurAction =5;
            }
            else if(((LoadedObjects<6)&&
(CSRight_B<=60&&(CSRight_G<=100&&CSRight_G>=54)&&CSRight_R<=60)
||
(LoadedObjects<6)&&
(CSLeft_B<=60&&(CSLeft_G<=100&&CSLeft_G>=54)&&CSLeft_R<=60)))
            {
                Duration = 49;
                CurAction =6;
            }
            else if(((LoadedObjects<6)&&(CSRight_B<=60&&(CSRight_R<=100&&CSRight_R>=60)&&CSRight_G<=60)||(LoadedObjects<6)&&(CSLeft_B<=60&&(CSLeft_R<=100&&CSLeft_R>=60)&&CSLeft_G<=60)))
            {
                Duration = 49;
                CurAction =7;
            }
            else if(Time>=180 && Time<=260&&(LoadedObjects==0))
            {
                Duration = 0;
                CurAction =8;
            }
            else if(Time>=261 && Time<=1000)
            {
                Duration = 0;
                CurAction =9;
            }
            else if((US_Left<US_Right)&&(CSLeft_R>=235&&CSLeft_R<=255)&&(CSLeft_G>=235&&CSLeft_G<=255)&&(CSLeft_B>=40&&CSLeft_B<=60))
            {
                Duration = 1;
                CurAction =10;
            }
            else if((US_Left>US_Right)&&(CSRight_R>=235&&CSRight_R<=255)&&(CSRight_G>=235&&CSRight_G<=255)&&(CSRight_B>=40&&CSRight_B<=60))
            {
                Duration = 1;
                CurAction =11;
            }
            else if(((CSLeft_R<=71&&CSLeft_R>=31)&&(CSLeft_G>=31&&CSLeft_G<=71)&&CSLeft_B>=235)||((CSRight_R<=71&&CSRight_B>=31)&&(CSRight_G>=31&&CSRight_G<=71)&&CSRight_B>=235))
            {
                Duration = 0;
                CurAction =12;
            }
            else if(US_Front>=0 && US_Front<=15 && US_Right>=0 && US_Right<=25)
            {
                Duration = 3;
                CurAction =13;
            }
            else if(US_Front>=0 && US_Front<=15 && US_Left>=0 && US_Left<=25)
            {
                Duration = 3;
                CurAction =14;
            }
            else if(US_Front>=0 && US_Front<=15 && US_Left>=0 && US_Left<=25 && US_Right>=0 && US_Right<=5)
            {
                Duration = 4;
                CurAction =15;
            }
            else if(US_Left>=0 && US_Left<=10)
            {
                Duration = 2;
                CurAction =16;
            }
            else if(US_Right>=0 && US_Right<=10)
            {
                Duration = 2;
                CurAction =17;
            }
            else if(true)
            {
                Duration = 0;
                CurAction =18;
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
                    Wheel_Right=2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 3:
                    Wheel_Left=2;
                    Wheel_Right=4;
                    LED_1=0;
                    MyState=0;
                    break;
                case 4:
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
                case 5:
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
                    LED_1=0;
                    MyState=0;
                     Teleport = 1;  
                    break;
                case 9:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=0;
                    MyState=0;
                     Teleport = 1;  
                    break;
                case 10:
                    Wheel_Left=-1;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    break;
                case 11:
                    Wheel_Left=-5;
                    Wheel_Right=-1;
                    LED_1=0;
                    MyState=0;
                    break;
                case 12:
                    Wheel_Left=0;
                    Wheel_Right=0;
                    LED_1=0;
                    MyState=0;
                    LoadedObjects=0;
                    
                    break;
                case 13:
                    Wheel_Left=-5;
                    Wheel_Right=-2;
                    LED_1=0;
                    MyState=0;
                    break;
                case 14:
                    Wheel_Left=-2;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    break;
                case 15:
                    Wheel_Left=-5;
                    Wheel_Right=-5;
                    LED_1=0;
                    MyState=0;
                    break;
                case 16:
                    Wheel_Left=-3;
                    Wheel_Right=1;
                    LED_1=0;
                    MyState=0;
                    break;
                case 17:
                    Wheel_Left=1;
                    Wheel_Right=-3;
                    LED_1=0;
                    MyState=0;
                    break;
                case 18:
                    Wheel_Left=4;
                    Wheel_Right=4;
                    LED_1=0;
                    MyState=0;
                    break;
                default:
                    break;
            }

        }


    }
}
