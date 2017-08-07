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
------------------------------------------------ CALIB -----------------------------------------
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

public static bool BlackL() {
    if(CSLeft_B<=80 && CSLeft_G<=80 && CSLeft_R<=80)
        return true;
    return false;
                
}

public static bool BlackR() {
    if(CSRight_B <=80 && CSRight_G<=80 && CSRight_R<=80)
        return true;
    return false;
                
}
public static bool GreenL() {
    if(CSLeft_B<=60 && CSLeft_G<=180 && CSLeft_G>=80 && CSLeft_R<=60)
        return true;
    return false;
                
}

public static bool GreenR() {
    if(CSRight_B<=60 && CSRight_G<=100 && CSRight_G>=80 && CSRight_R<=60)
        return true;
    return false;
                
}

public static bool RedL() {
    if(CSLeft_B<=60 && CSLeft_R<=180 && CSLeft_R>=80 && CSLeft_G<=60)
        return true;
    return false;
                
}

public static bool RedR() {
    if(CSRight_B<=60 && CSRight_R<=180 && CSRight_R>=80 && CSRight_G<=60)
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

















/*
-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
------------------------------------------------ CORES ------------------------------------------
-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
*/


public static bool FoundSpecial()   {
    if(BlueL() || BlueR() )
        return true;
    return false;
}

public static bool foundObj()   {
    if( GreenR() || GreenL() ||
        RedR() || RedL() ||
        BlackR() || BlackL() ||
        PinkR() || PinkL())
            return true;
    return false;
}
public static bool foundWarn()   {
	return (YellowR() || YellowL());
}
public static bool foundBase()   {
    return (OrangeR() && OrangeL());
}

public static bool SoftTeleport(){
    if(Time>=180 && Time<=260 && LoadedObjects==0)
        return true;
    return false;
}




public static int[,] regioes= new int[,]    {
    {60,60},{40,120},{50,140},{30,210},
    {120,60},{120,85},{60,180},{100,200},
    {165,15},{150,100},{150,160},{160,210}
};
public static int[,] mapa1 = new int[400,400];

public static int reg = 0;
public static int lastCall = 0;


public static void reg_um() {
    gotoreg(5,Teleport+1);
}

public static void reg_dois()   {
    gotoreg(1,Teleport+1);
}

public static void reg_tres() {
    gotoreg(2,Teleport+1);
}

public static void reg_quatro() {
    gotoreg(3,Teleport+1);
}

public static void reg_cinco() {
    gotoreg(9,Teleport+1);
}

public static void reg_seis() {
    gotoreg(5,Teleport+1);
}

public static void reg_sete()  {
    gotoreg(3,Teleport+1);
}

public static void reg_oito() {
    gotoreg(12,Teleport+1);
}

public static void reg_nove() {
    gotoreg(9,Teleport+1);
}

public static void reg_dez() {
    gotoreg(9,Teleport+1);
}

public static void reg_onze() {
    gotoreg(10,Teleport+1);
}
public static void reg_doze() {
    gotoreg(11,Teleport+1);
}

public static void gotoreg(int region, int map)   {
    double angle = Math.Atan(Math.Abs(regioes[region,1]-pY)/Math.Abs(regioes[region, 0] - pX));
    virar((int) Math.Abs(angle));
}














public static void deposit()    {
    Wheel_Right = Wheel_Left = 0;
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\hang.txt", true))  {
        file.Write(depositing + " " + collecting + " " + Duration + "\n");
    }
    if(!depositing)  {
        Duration = 38;
        depositing = true;
        LED_1 = 2;
        MyState = 0;
    }else{
        if(Duration == 1)   {
            LoadedObjects = 0;
            LED_1 = 0;
            Duration = 0;
            depositing = false;
            indoBase = false;
        }
    }
}
public static void collect()    {
    Wheel_Right = Wheel_Left = 0;
    if(!collecting)  {
        collecting = true;
        Duration = 40;
        LED_1 = 1;
        MyState = 0;
    }else{
        if(Duration < 7)
            Wheel_Left = Wheel_Right = 2;
        if(Duration == 1)   {
            LoadedObjects++;
            collecting = false;
            LED_1 = 0;
        }
    }
}

public static int ondeVirar()   {
    contador_onde++;

    if(LoadedObjects >= 7 && !indoBase)  indoBase = true;
    if(indoBase)    {
        if(Teleport == 0)  {
            if(pX <= 60 && pY <= 60 && pX >= 0 && pY >= 0) reg = 1;
            else if(pX <= 120 && pY <= 60 && pX >= 60 && pY >= 0) reg = 2;
            else if(pX <= 180 && pY <= 60 && pX >= 120 && pY >= 0) reg = 3;
            else if(pX <= 240 && pY <= 60 && pX >= 180 && pY >= 0) reg = 4;

            else if(pX <= 60 && pY <= 120 && pX >= 0 && pY >= 60) reg = 5;
            else if(pX <= 120 && pY <= 120 && pX >= 60 && pY >= 60) reg = 6;
            else if(pX <= 180 && pY <= 120 && pX >= 120 && pY >= 60) reg = 7;
            else if(pX <= 240 && pY <= 120 && pX >= 180 && pY >= 60) reg = 8;

            else if(pX <= 60 && pY <= 180 && pX >= 0 && pY >= 120) reg = 9;
            else if(pX <= 120 && pY <= 180 && pX >= 60 && pY >= 120) reg = 10;
            else if(pX <= 180 && pY <= 180 && pX >= 120 && pY >= 120) reg = 11;
            else if(pX <= 240 && pY <= 180 && pX >= 180 && pY >= 120) reg = 12;
        }else{
            if(pX <= 90 && pY <= 90 && pX >= 0 && pY >= 0) reg = 1;
            else if(pX <= 180 && pY <= 90 && pX >= 90 && pY >= 0) reg = 2;
            else if(pX <= 270 && pY <= 90 && pX >= 180 && pY >= 0) reg = 3;
            else if(pX <= 360 && pY <= 90 && pX >= 270 && pY >= 0) reg = 4;

            else if(pX <= 90 && pY <= 180 && pX >= 0 && pY >= 90) reg = 5;
            else if(pX <= 180 && pY <= 180 && pX >= 90 && pY >= 90) reg = 6;
            else if(pX <= 270 && pY <= 180 && pX >= 180 && pY >= 90) reg = 7;
            else if(pX <= 360 && pY <= 180 && pX >= 270 && pY >= 90) reg = 8;

            else if(pX <= 90 && pY <= 270 && pX >= 0 && pY >= 180) reg = 9;
            else if(pX <= 180 && pY <= 270 && pX >= 90 && pY >= 180) reg = 10;
            else if(pX <= 270 && pY <= 270 && pX >= 180 && pY >= 180) reg = 11;
            else if(pX <= 360 && pY <= 270 && pX >= 270 && pY >= 180) reg = 12;
        }
        if(lastCall == 100) {
            switch(reg) {
                case 1: reg_um();break;
                case 2: reg_dois();break;
                case 3: reg_tres();break;
                case 4: reg_quatro();break;
                case 5: reg_cinco();break;
                case 6: reg_seis();break;
                case 7: reg_sete();break;
                case 8: reg_oito();break;
                case 9: reg_nove();break;
                case 10: reg_dez();break;
                case 11: reg_onze();break;
                case 12: reg_doze();break;
            }
            lastCall = 0;
        }
    }

    if(US_Front <= 25)
        return rand.Next(80,90);

    if(YellowR() && YellowL())  {
        return 90; // mudar
    }else{
        if(YellowR())   {
            return 90;
        }
        if(YellowL())
            return -90;
    }
    return 0;
}

public static int virar(int angulo) {
    if(angulo != 0) {
        if(virando) {
            if(Duration == 1) virando = false;
        }

        virando = true;
        if(angulo < 0)  {
            Wheel_Left = 1;
            Wheel_Right = -1;
        }else{
            Wheel_Left = -1;
            Wheel_Right = 1;
        }

        return (int) Math.Floor(((angulo/360.0)*w)/0.060) + 1;
    }
    return 0;
}

public static void avoid()  {
    Wheel_Left = Wheel_Right = 0;
    virando = true;
    Duration = virar(ondeVirar());
}

/*
-------------------------------------------------------------------------------------------------
------------------------------------------------ NOSSO -----------------------------------------
-------------------------------------------------------------------------------------------------
*/



        // teleport = 1 => firstTime = 1
        public static bool virando = false;
        public static bool indoBase = false;
        public static bool collecting = false;
        public static bool depositing = false;

        public static int contador_onde = 0;
        public static int t_indo = 0;

        static bool firstTime = true;
        static bool nextMap = true;
        static int mapeando = 0;
        const int TMX = 360;
        const int TMY = 270;

        public static int count = 0;

        const double v = 180.0/7.0;
        const double w = 5.0;

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

        public static Random rand = new Random();

        public static int AnguloDestino = Compass;
        public static double gotoX = 0;
        public static double gotoY = 0;
        private static double pX = 0, pY = 0;
        static byte[,] mapa = new byte[2*TMY,2*TMX];

        public static void mapear() {
            int x, y; 
            /*
            for(int i=0;i<20;++i)
                for(int j=0;j<15;j++)   {
                    x = TMX + (int) Math.Floor(pX + j*Math.Sin(Compass*Math.PI/180) + i*Math.Cos(Compass*Math.PI/180));
                    y = TMY + (int) Math.Floor(pY + j*Math.Cos(Compass*Math.PI/180) + i*Math.Sin(Compass*Math.PI/180));

                    mapa[x,y] = FLOOR;
                }
                */
            /*
            for(int i=0;i<US_Front;++i) {
                x = TMX + (int) (Math.Round(i*Math.Sin(Compass*Math.PI/180) + pX ) );
                y = TMY + (int) (Math.Round(i*Math.Cos(Compass*Math.PI/180) + pY ));
                mapa[y,x] = FLOOR;
            }
            for(int i=0;i<US_Back;++i) {
                x = TMX + (int) Math.Round(i*Math.Sin((Compass+180)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(i*Math.Cos((Compass+180)*Math.PI/180) + pY);
                mapa[y,x] = FLOOR;
            }*/
            for(int i=0;i<US_Left;++i) {
                x = TMX + (int) Math.Round(i*Math.Sin((Compass+45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(i*Math.Cos((Compass+45)*Math.PI/180) + pY);
                mapa[y,x] = FLOOR;
            }
            for(int i=0;i<US_Right;++i) {
                x = TMX + (int) Math.Round(i*Math.Sin((Compass-45)*Math.PI/180) + pX);
                y = TMY + (int) Math.Round(i*Math.Cos((Compass-45)*Math.PI/180) + pY);
                mapa[y,x] = FLOOR;
            }
/*
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
*/
            /* if color_direita != chao => mapa[pX+distX,pY+distY] = color;*/
            /* foreach sensor => sensor.read < 186 => mapa[x,y] = PAREDE*/

            int TX;
            int TY;


            if(Teleport == 0)   {
                TX = 240;
                TY = 180;
            }else{
                TX = 360;
                TY = 270;
            }

            for(int i=0; i<TX;++i)  {
                for(int j=0;j<TY;++j)   {
                    if(mapa1[i,j] != 2) {
                        
                    }
                }
            }
        }

        public static void desenhar()   {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\mapa.txt", true))
                    {
            for(int i=0;i<2*TMY;++i)    {
                for(int j=0;j<2*TMX;++j)    {
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
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\pos.txt", true))
                file.Write(pX + " " + pY + " Tempo: " + Time + " "+ Compass + " " +"\n\r");
            count++;

            Duration = Duration - 1;

            if(Duration <= 0)  {
                virando = depositing = collecting = false;
                Duration = 0;
                if(indoBase) {
                    if(foundObj()&&!Full()){
                        collect();
                    }else if(foundWarn()&&!Empty()){
                        avoid();
                    }else if(foundBase()&&!Empty()){
                        deposit();
                    }
                }else{

                    if(virando) {
                    }else if(foundWarn()&&!Empty()){
                        avoid();
                    }else if(foundBase()&&!Empty()){
                        deposit();
                    }else{
                        if(foundObj()&&!Full())  {
                            collect();
                        }else{
                            int ret = ondeVirar();

                            if(ret == 0)    {
                                Wheel_Right = Wheel_Left = 4;
                                pX = pX + 0.060*v*Math.Sin(Compass*Math.PI/180);
                                pY = pY + 0.060*v*Math.Cos(Compass*Math.PI/180);
                                mapear();
                            }else{
                                Duration = virar(ret);
                            }
                        }
                    }
                }
            }else{
                if(collecting) collect();
                if(depositing) deposit();
                if(virando) virar(0);
            }

            if(count%10 == 0 && count != 0)    {
                desenhar();
            }
        } // game0
    }
}
