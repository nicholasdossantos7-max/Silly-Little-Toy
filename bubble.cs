using System;
using System.Collections.Generic;
using System.Text;

//idk if I will have to use this cs
namespace MohawkGame2D
{
    public class Bubble
    {
        float x = 400;
        float y = 400;
        //These 2 floats health indicate where the bubbles with spawn.
        float xspeed;
        float yspeed;
        float radius = 35;
        Color bubblecolor;
        public void setup()
        {
            xspeed = Random.Integer(-5,3);
            yspeed = Random.Integer(-5,3);
            
            radius = Random.Integer(10, 35);
        }

        public void update()
        {
            y += yspeed;
            x += xspeed;

            if (x > 800) xspeed = -xspeed;
            if (x < 0) xspeed = -xspeed;
            if (y > 600) yspeed = -yspeed;
            if (y < 0) yspeed = -yspeed;
            //where bubbles bounce off the boarders on the window

            //bubble design
            Draw.SetFillColor(200, 225, 255);
            Draw.Circle(x, y, radius);
            //bubble lighting (doesn't get used btw)
            Draw.SetFillColor(200, 240, 255);
            Draw.SetLineSize(0); 
            Draw.Circle(x, y, radius); //210, 165

            //Bubble Wand
            Draw.SetFillColor(230, 230, 255); // This doesn't even do anything

        }

        public bool trypop(float xbubblepop, float ybubblepop)
        {
            if ((x + radius >= xbubblepop && x - radius <= xbubblepop) && (y + radius >= ybubblepop && y - radius <= ybubblepop))
                return true;
            return false;
        }
    }
}
