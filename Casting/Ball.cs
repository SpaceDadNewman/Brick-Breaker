using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    class Ball : Actor
    {
        public Ball()
        {
            SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2));
            SetImage(Constants.IMAGE_BALL);
            SetWidth(Constants.BALL_WIDTH);
            SetHeight(Constants.BALL_HEIGHT);
            SetVelocity(new Point(-5,-5));
        }
    }
}