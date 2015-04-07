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
    Image Nurmikkokuva = LoadImage("Nurmikko");
    Image Tiekuva = LoadImage ("Tie");
    Image Vesikuva = LoadImage ("Vesi");
    Image jalkakaytavakuva = LoadImage("jalkakaytava");
    Image Junaratakuva = LoadImage("jalkakaytava");
    Image Valo1kuva = LoadImage("Valo1");
    Image Valo2kuva = LoadImage("Valo2");
    Image Pelaajakuva = LoadImage("Pelaaja");

    public override void Begin()
    {
        LuoPistelaskuri();
        LuoKentta();

        Camera.ZoomToLevel();

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    
    }
    void LuoKentta()
    {
    ColorTileMap ruudut = ColorTileMap.FromLevelAsset("CrossyRoad2D");
    ruudut.SetTileMethod(Color.FromHexCode("167C00"),  LuoNurmikko);
    ruudut.SetTileMethod(Color.Black,  LuoJunarata);
    ruudut.SetTileMethod(Color.FromHexCode("4CFFED"), LuoPelaaja);
    ruudut.SetTileMethod(Color.FromHexCode("FF6A00"), LuoValo2);
    ruudut.SetTileMethod(Color.FromHexCode("4CFF00"),LuoValo1);
    ruudut.SetTileMethod(Color.FromHexCode("FF001D"), LuoJalkakaytava);
    ruudut.SetTileMethod(Color.FromHexCode("0026FF"), LuoVesi);
    ruudut.SetTileMethod(Color.FromHexCode("808080"), LuoTie);
 
    ruudut.Execute(10, 8); 
    }
    void LuoTie(Vector paikka, double leveys, double korkeus)
    {

        PhysicsObject Tie = PhysicsObject.CreateStaticObject(leveys, korkeus);
        Tie.Position = paikka;
        Tie.Image = Tiekuva;
        Tie.CollisionIgnoreGroup = 1;
        Add(Tie);
    }
    void LuoNurmikko(Vector paikka, double leveys, double korkeus)
    {
    
        PhysicsObject Nurmikko = PhysicsObject.CreateStaticObject(leveys, korkeus);
        Nurmikko.Position = paikka;
        Nurmikko.Image = Nurmikkokuva;
        Nurmikko.CollisionIgnoreGroup = 1;
        Add(Nurmikko);
    }
     void LuoJunarata(Vector paikka, double leveys, double korkeus)
    {    
    
    PhysicsObject Junarata = PhysicsObject.CreateStaticObject(leveys, korkeus);
    Junarata.Position = paikka;
    Junarata.Image = Junaratakuva;
    Junarata.CollisionIgnoreGroup = 1;
    Add(Junarata);
    }
    void LuoJalkakaytava (Vector paikka, double leveys, double korkeus)
    {

        PhysicsObject Jalkakaytava = PhysicsObject.CreateStaticObject(leveys, korkeus);
         Jalkakaytava.Position = paikka;
         Jalkakaytava.Image = jalkakaytavakuva;
         Jalkakaytava.CollisionIgnoreGroup = 1;
         Add(Jalkakaytava);
    } 
    void LuoVesi(Vector paikka, double leveys, double korkeus)
    {

         PhysicsObject Vesi = PhysicsObject.CreateStaticObject(leveys, korkeus);
         Vesi.Position = paikka;
         Vesi.Image = Vesikuva;
         Vesi.CollisionIgnoreGroup = 1;
         Add(Vesi);
    }
     void LuoValo1(Vector paikka, double leveys, double korkeus)
    {

         PhysicsObject Valo1 = PhysicsObject.CreateStaticObject(leveys, korkeus);
         Valo1.Position = paikka;
         Valo1.Image = Valo1kuva;
         Valo1.CollisionIgnoreGroup = 1;
         Add(Valo1);
     }
    void LuoPelaaja(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject Pelaaja = PhysicsObject.CreateStaticObject(leveys, korkeus);
        Pelaaja.Position = paikka;
        Pelaaja.Image = Pelaajakuva;
        Pelaaja.CollisionIgnoreGroup = 1;
        Add(Pelaaja);
    
    }
    void LuoValo2(Vector paikka, double leveys, double korkeus)
    {

        PhysicsObject Valo2 = PhysicsObject.CreateStaticObject(leveys, korkeus);
        Valo2.Position = paikka;
        Valo2.Image = Valo2kuva;
        Valo2.CollisionIgnoreGroup = 1;
        Add(Valo2);
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

