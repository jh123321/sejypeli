using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Pong : PhysicsGame
{
    Vector nopeusYlos = new Vector(0, -200);
    Vector nopeusAlas = new Vector(0,  200);

    PhysicsObject pallo;
    PhysicsObject maila1;
    PhysicsObject maila2;

    PhysicsObject vasenreuna;
    PhysicsObject oikeareuna;
   
    IntMeter pelaajan1Pisteet;
    IntMeter pelaajan2Pisteet;
    
    public override void Begin()
    { 
        LuoKentta();
        AsetaOhjaimet();
        LisaaLaskurit();
        AloitaPeli();

    }
    const double PALLON_MIN_NOPEUS = 500;

    protected override void Update(Time time)
    {
        if (pallo != null && Math.Abs(pallo.Velocity.X) < PALLON_MIN_NOPEUS)
        {
            pallo.Velocity = new Vector(pallo.Velocity.X * 1.1, pallo.Velocity.Y);
        }
        base.Update(time);
    }
    void AsetaNopeus(PhysicsObject maila, Vector nopeus)
    {
        if ((nopeus.Y < 0) && (maila.Bottom < Level.Bottom))
        {
            maila.Velocity = Vector.Zero;
            return;
        }
        if ((nopeus.Y > 0) && (maila.Top > Level.Top))
        {
            maila.Velocity = Vector.Zero;
            return;
        }
        maila.Velocity = nopeus;

    }
    IntMeter LuoPisteLaskuri(double x, double y)
    {
       IntMeter laskuri = new IntMeter (0);
       laskuri.MaxValue = 10;
       
        Label naytto = new Label();
        naytto.BindTo(laskuri);
        naytto.X = x;
        naytto.Y = y;
        naytto.TextColor = Color.White;
        naytto.BorderColor = Level.Background.Color;
        naytto.Color = Level.Background.Color;
        Add(naytto);

        return laskuri;
    }
    void AsetaOhjaimet()
    {
      Keyboard.Listen (Key.A,     ButtonState.Down,       AsetaNopeus, "Pelaaja1: Liikuta mailaa ylös", maila1, nopeusYlos);
      Keyboard.Listen (Key.A,     ButtonState.Released,   AsetaNopeus, null,                            maila1, Vector.Zero);
      Keyboard.Listen (Key.Z,     ButtonState.Down,       AsetaNopeus, "Pelaaja 1: Liikuta mailaa alas", maila1, nopeusAlas); 
      Keyboard.Listen (Key.Z,     ButtonState.Released,   AsetaNopeus,  null,                           maila1, Vector.Zero);
  
      Keyboard.Listen (Key.Up,    ButtonState.Down,       AsetaNopeus,  "Pelaaja 2: Liikuta mailaa ylös",  maila2, nopeusYlos);
      Keyboard.Listen (Key.Up,    ButtonState.Released,   AsetaNopeus,   null,                             maila2, Vector.Zero);
      Keyboard.Listen (Key.Down,  ButtonState.Down,       AsetaNopeus,   "Pelaaja 2: Liikuta mailaa alas", maila2, nopeusAlas);
      Keyboard.Listen (Key.Down,  ButtonState.Released,   AsetaNopeus,   null,                             maila2, Vector.Zero); 
      
      Keyboard.Listen (Key.F1,    ButtonState.Pressed,    ShowControlHelp,"Näytä ohjeet");
      Keyboard.Listen (Key.Escape,ButtonState.Pressed,    ConfirmExit,    "Lopeta peli");
    }
    void LuoKentta()
    {
        pallo = new PhysicsObject(40.0, 40.0);
        pallo.Shape = Shape.Circle;
        pallo.X = -200.0;
        pallo.Y = 0.0;
        pallo.Restitution = 1.0;
        Add(pallo);
        
        AddCollisionHandler(pallo, KasittelePallonTormays);
        
        maila1 = LuoMaila(Level.Left + 20.0, 0.0); 
        maila2 = LuoMaila(Level.Right - 20.0, 0.0);

        vasenreuna = Level.CreateLeftBorder();
        vasenreuna.Restitution = 1.0;
        vasenreuna.IsVisible = false;
        Level.Background.Color = Color.Black;
        oikeareuna = Level.CreateRightBorder();
        oikeareuna.Restitution = 1.0;
        oikeareuna.IsVisible = false;

        PhysicsObject ylaReuna = Level.CreateTopBorder();
        ylaReuna.Restitution = 1.0;
        ylaReuna.IsVisible = false;

        PhysicsObject alaReuna = Level.CreateBottomBorder();
        alaReuna.Restitution = 1.0;
        alaReuna.IsVisible = false;

        Camera.ZoomToLevel();
    }
    void KasittelePallonTormays(PhysicsObject pallo, PhysicsObject kohde)
    {
        if (kohde == oikeareuna)
        {
            pelaajan1Pisteet.Value += 1;
        }
        else if (kohde == vasenreuna)
        {
            pelaajan2Pisteet.Value += 1;
        }
    }

    void AloitaPeli()
    {
        Vector impulssi = new Vector(500.0, 0.0);
        pallo.Hit(impulssi);
    }
    PhysicsObject LuoMaila(double x, double y)
    {
        PhysicsObject maila = PhysicsObject.CreateStaticObject(20.0, 100.0);
        maila.Shape = Shape.Rectangle;
        maila.X = x;
        maila.Y = y;
        maila.Restitution = 1.0;
        Add(maila);
        return maila;
    }
    void LisaaLaskurit()
    {
    pelaajan1Pisteet = LuoPisteLaskuri(Screen.Left + 100.0, Screen.Top - 100.0);
    pelaajan2Pisteet = LuoPisteLaskuri(Screen.Right - 100.0, Screen.Top - 100.0);
    }

}

