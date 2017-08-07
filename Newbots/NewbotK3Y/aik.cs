using System;
using System.Collections.Generic;

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
        static int angulo = 0;
        static int anguloInicial = 0;
 
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


/*
-------------------------------------------------------------------------------------------------
------------------------------------------------ INPUTS -----------------------------------------
-------------------------------------------------------------------------------------------------
*/

public static bool Full()  {
    return LoadedObjects==6;
}

public static bool Empty()  {
    return LoadedObjects==0;
}

public static bool OrangeL()  {
    if(CSLeft_R>=230 && CSLeft_R<=255 && CSLeft_G>=141 && CSLeft_G<=181 && CSLeft_B>=31 && CSLeft_B<=71)
        return true;
    return false;
}
public static bool OrangeR()  {
    if(CSRight_R>=230 && CSRight_R<=255 && CSRight_G>=141 && CSRight_G<=181 && CSRight_B>=31 && CSRight_B<=71)
        return true;
    return false;
}

public static bool Deposit()   {
    if(OrangeR() && OrangeL() && !Empty() )
        return true;
    return false;
}

public static bool FindOrange()   {
    if(OrangeR() && OrangeL() && Empty() )
        return true;
    return false;
}

public static bool PinkL() {
    if(CSLeft_R>=200 && CSLeft_G>=97 && CSLeft_G<=137 && CSLeft_B>=200 && Teleport==1)
        return true;
    return false;
                
}

public static bool PinkR() {
    if(CSRight_R>=200 && CSRight_G>=97 && CSRight_G<=137 && CSRight_B>=200  && Teleport==1)
        return true;
    return false;
                
}

public static bool ColPink() {
    if( ( PinkL() || PinkR() ) && !Full() && Teleport==1)
        return true;
    return false;
                
}

public static bool BlackL() {
    if(CSLeft_B<=40 && CSLeft_G<=40 && CSLeft_R<=40)
        return true;
    return false;
                
}

public static bool BlackR() {
    if(CSRight_B <=40 && CSRight_G<=40 && CSRight_R<=40)
        return true;
    return false;
                
}

public static bool ColBlack() {
    if( ( BlackL() || BlackR() ) && !Full() )
        return true;
    return false;
                
}

public static bool GreenL() {
    if(CSLeft_B<=60 && CSLeft_G<=100 && CSLeft_G>=54 && CSLeft_R<=60)
        return true;
    return false;
                
}

public static bool GreenR() {
    if(CSRight_B<=60 && CSRight_G<=100 && CSRight_G>=54 && CSRight_R<=60)
        return true;
    return false;
                
}

public static bool ColGreen() {
    if( ( GreenL() || GreenR() ) && !Full() )
        return true;
    return false;
                
}

public static bool RedL() {
    if(CSLeft_B<=60 && CSLeft_R<=100 && CSLeft_R>=54 && CSLeft_G<=60)
        return true;
    return false;
                
}

public static bool RedR() {
    if(CSRight_B<=60 && CSRight_R<=100 && CSRight_R>=54 && CSRight_G<=60)
        return true;
    return false;
                
}

public static bool ColRed() {
    if( ( RedL() || RedR() ) && !Full() )
        return true;
    return false;
                
}

public static bool YellowL() {
    if(CSLeft_R>=235 && CSLeft_R<=255 && CSLeft_G>=235 && CSLeft_G<=255 && CSLeft_B>=40 && CSLeft_B<=60)
        return true;
    return false;

}

public static bool YellowR() {
    if(CSRight_R>=235 && CSRight_R<=255 && CSRight_G>=235 && CSRight_G<=255 && CSRight_B>=40 && CSRight_B<=60)
        return true;
    return false;

}

public static bool DetectYellow() {

    if(YellowL() || YellowR() )
        return true;
    return false;

}


public static bool TrapL() {
    if(CSLeft_R<=71 && CSLeft_R>=31 && CSLeft_G>=31 && CSLeft_G<=71 && CSLeft_B>=235)
        return true;
    return false;

}


public static bool TrapR() {
    if(CSRight_R<=71 && CSRight_R>=31 && CSRight_G>=31 && CSRight_G<=71 && CSRight_B>=235)
        return true;
    return false;

}

public static bool FallTrap() {

    if(TrapL() || TrapR() )
        return true;
    return false;
}

public static bool BlueL() {
    if(CSLeft_R<=137 && CSLeft_R>=87 && CSLeft_G>=146 && CSLeft_G<=206 && CSLeft_B>=235)
        return true;
    return false;

}


public static bool BlueR() {
    if(CSLeft_R<=137 && CSLeft_R>=87 && CSLeft_G>=146 && CSLeft_G<=206 && CSLeft_B>=235)
        return true;
    return false;

}

public static bool FindSpecial() {

    if(BlueL() || BlueR() )
        return true;
    return false;
}

public static bool SoftTeleport(){

    if(Time>=180 && Time<=260 && LoadedObjects==0)
        return true;
    return false;
}

public static bool ForceTeleport(){

    if(Time>=261 && Time<=1000)
        return true;
    return false;
}


public static bool WallFront(){

    if(US_Front>=10)
        return true;
    return false;
}

public static bool WallLeft(){

    if(US_Left>=15)
        return true;
    return false;
}

public static bool WallRight(){

    if(US_Front>=15)
        return true;
    return false;
}

public static bool WallBack(){

    if(US_Front>=10)
        return true;
    return false;
}

public static bool GetObj(){
    if(ColRed() || ColGreen() || ColBlack() || ColPink())
        return true;
    return false;

}

/*
-------------------------------------------------------------------------------------------------
------------------------------------------------ NOSSO -----------------------------------------
-------------------------------------------------------------------------------------------------
*/



        // teleport = 1 => firstTime = 1
        static bool firstTime = true;
        static bool nextMap = true;
        static int mapeando = 0;
        const int TMX = 360;
        const int TMY = 270;

        public static int count = 0;

        public static double[] vs = new double[]{180/16, 180/10,180/8,180/7,180/3.6};

        const byte INEX = 0;
        const byte FLOOR = 1;
        const byte WALL = 2;
        const byte YELLOW = 3;
        const byte BLUE = 4;
        const byte SWAMP = 5;
        const byte RED = 6;
        const byte GREEN = 7;
        const byte BLACK = 8;
        const byte SUPER = 9;
        const byte BASE = 10;
        const byte TRAP = 11;

        public static int AnguloDestino = Compass;
        public static double gotoX = 0;
        public static double gotoY = 0;
        private static double pX = 0, pY = 0;
        static byte[,] mapa = new byte[2*TMX,2*TMY];


        public static void virar(int angulo, int R, int L) {
            AnguloDestino = (Compass + angulo)%360;
            Wheel_Left = L;
            Wheel_Right = R;
        }

        public static void andar(int distX, int distY, int spd)    {
            gotoX = distX;
            gotoY = distY;
            Wheel_Right = Wheel_Left = spd;
        }

        public static bool achouObjeto()    {
            return false;
        }
        public static void collect()    {

        }

        public static void mapear() {
            int x, y;
            for(int i=0;i<US_Front;++i) {
                x = TMX + (int) (Math.Round(i*Math.Sin(Compass*Math.PI/180) + pX));
                y = TMY + (int) (Math.Round(i*Math.Cos(Compass*Math.PI/180) + pY));
                mapa[x,y] = FLOOR;
            }
            for(int i=0;i<US_Back;++i) {
                x = TMX + (int) Math.Round(i*Math.Sin((Compass+180)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(i*Math.Cos((Compass+180)*Math.PI/180) + pY);
                mapa[x,y] = FLOOR;
            }
            for(int i=0;i<US_Left;++i) {
                x = TMX + (int) Math.Round(i*Math.Sin((Compass+45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(i*Math.Cos((Compass+45)*Math.PI/180) + pY);
                mapa[x,y] = FLOOR;
            }
            for(int i=0;i<US_Right;++i) {
                x = TMX + (int) Math.Round(i*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(i*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[x,y] = FLOOR;
            }

            if(US_Front < 186)  {
                x = TMX + (int) (Math.Round(US_Front*Math.Sin(Compass*Math.PI/180) + pX));
                y = TMY + (int) (Math.Round(US_Front*Math.Cos(Compass*Math.PI/180) + pY));
                mapa[x,y] = WALL;
            }

            if(US_Back < 186)  {
                x = TMX - (int) Math.Round(US_Back*Math.Sin((Compass+180)*Math.PI/180) + pX);
                y = TMY - (int) Math.Round(US_Back*Math.Cos((Compass+180)*Math.PI/180) + pY);
                mapa[x,y] = WALL;
            }

            if(US_Left < 186)  {
                x = TMX + (int) Math.Round(US_Left*Math.Sin((Compass+45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(US_Left*Math.Cos((Compass+45)*Math.PI/180) + pY);
                mapa[x,y] = WALL;
            }

            if(US_Right < 186)  {
                x = TMX + (int) Math.Round(US_Right*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(US_Right*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[x,y] = WALL;
            }

             if(PinkL || PinkR)  {
                x = TMX + (int) Math.Round(US_Right*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(US_Right*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[x,y] = SUPER;
            }

            if(BlackL || BlackR)  {
                x = TMX + (int) Math.Round(US_Right*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(US_Right*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[x,y] = BLACK;
            }

            if(GreenL || GreenR)  {
                x = TMX + (int) Math.Round(US_Right*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(US_Right*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[x,y] = GREEN;
            }

            if(RedL || RedR)  {
                x = TMX + (int) Math.Round(US_Right*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(US_Right*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[x,y] = RED;
            }

            if(OrangeL || OrangeR)  {
                x = TMX + (int) Math.Round(US_Right*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(US_Right*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[x,y] = BASE;
            }

             if(YellowL || YellowR)  {
                x = TMX + (int) Math.Round(US_Right*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(US_Right*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[x,y] = YELLOW;
            }

             if(TrapR || TrapR)  {
                x = TMX + (int) Math.Round(US_Right*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(US_Right*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[x,y] = TRAP;
            }







            /* if color_direita != chao => mapa[pX+distX,pY+distY] = color;*/
            /* foreach sensor => sensor.read < 186 => mapa[x,y] = PAREDE*/
        }

        public static void desenhar()   {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\mapa.txt", true))
                    {
            for(int i=0;i<2*TMX;++i)    {
                for(int j=0;j<2*TMY;++j)    {
                        file.Write(mapa[i,j]);
                }
                file.Write("\r\n");
            }
        }
        }

        public static void OnTimer()
        {
            Game0();
        }

        private static void Game0()
        {
            mapear();


            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\pos.txt", true))
                    {
                        file.Write(pX + " " + pY + " Tempo: " + Time + " "+ Compass + " " +"\n\r");
                    }

                    count++;

            pX = pX + 0.060*vs[Math.Abs(Wheel_Left)]*Math.Sin(Compass*Math.PI/180);
            pY = pY + 0.060*vs[Math.Abs(Wheel_Left)]*Math.Cos(Compass*Math.PI/180);

            if(count >= 4*(1/0.060))
                desenhar();

            if(Math.Abs(pX - gotoX) > 4 || Math.Abs(pY - gotoY) > 4) {}
            else if((Math.Abs(AnguloDestino - Compass) > 6 && Math.Abs(AnguloDestino - Compass) < 180) || (Math.Abs(AnguloDestino - Compass) >= 180 && Math.Abs(AnguloDestino - Compass) < 354)) {}
            else{

            andar(0,100,3);

            return;

            if(Duration-- > 0)  {}
            else if(Deposit())  {
                Duration = 59;
                LED_1 = 2;
                Wheel_Right = Wheel_Left = 0;
                if(Duration == 1)
                    LoadedObjects = 0;
            }else{
                Wheel_Right = Wheel_Left = 0;
                gotoX = pX;
                gotoY = pY;
            }
        }
        } // game0
    }
}