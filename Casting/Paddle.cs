using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    class Paddle : Actor
    {
        public Paddle()
        {
            SetPosition(new Point(Constants.MAX_X / 2,Constants.MAX_Y - 25));
            SetImage(Constants.IMAGE_PADDLE);
            SetWidth(Constants.PADDLE_WIDTH);
            SetHeight(Constants.PADDLE_HEIGHT);
        }
    }
}