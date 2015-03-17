using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class CrossyRoad2D : PhysicsGame
{
    IntMeter pisteLaskuri;
    
    public override void Begin()
    {
        LuoPistelaskuri();

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    
    }
    void LuoKentta()
    {
    ColorTileMap ruudut = ColorTileMap.FromLevelAsset("CrossyRoad2D");
    ruudut.SetTileMethod(Color.Green,  LuoNurmikko);
    ruudut.SetTileMethod(Color.Black,  LuoJunarata);
    ruudut.SetTileMethod(Color.White,  LuoPelaaja);
    ruudut.SetTileMethod(Color.OrangeRed, LuoValo);
    ruudut.SetTileMethod(Color.LightGreen, LuoValo);
    ruudut.SetTileMethod(Color.Red, LuoJalkakäytävä);
    ruudut.SetTileMethod(Color.Blue, LuoVesi);
     
    ruudut.Execute(10, 8); 
    }
    void LuoNurmikko(Vector paikka, double leveys, double korkeus)
    {
    
        PhysicsObject Nurmikko = PhysicsObject.CreateStaticObject(leveys, korkeus);
        Nurmikko.Position = paikka;
        Nurmikko.Image = groundImage;
        Nurmikko.CollisionIgnoreGroup = 1;
        Add(Nurmikko);
    }
        void LuoPelaaja(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject Pelaaja = PhysicsObject.CreateStaticObject(leveys, korkeus);
        Pelaaja.Position = paikka;
        Pelaaja.Image = groundImage;
        Pelaaja.CollisionIgnoreGroup = 1;
        Add(Pelaaja);
    
    }   
     void LuoPistelaskuri()
     {   
        pisteLaskuri = new IntMeter(0);

        Label pisteNaytto = new Label();
        pisteNaytto.X = Screen.Left + 100;
        pisteNaytto.Y = Screen.Top - 100;
        pisteNaytto.TextColor = Color.Black;
        pisteNaytto.Color = Color.White;

        pisteNaytto.BindTo(pisteLaskuri);
        Add(pisteNaytto);
        pisteNaytto.Title = "Points";
    }
}

