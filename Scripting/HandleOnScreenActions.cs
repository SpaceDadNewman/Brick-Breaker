using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;

namespace cse210_batter_csharp
{
    public class HandleOnScreenAction : Action
    {
        private List<Actor> _bricks;
        private Actor _ball;
        private List<Actor> _paddle;
        private PhysicsService _physicsService;
        AudioService audioService = new AudioService();
        public HandleOnScreenAction(PhysicsService _PhysicsService)
        {
            _physicsService = _PhysicsService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            _bricks = cast["bricks"];
            _ball = cast["balls"][0];
            _paddle = cast["paddle"];
            List<Actor> BrokenBricks = new List<Actor>();

            //brick collisions
            foreach (Actor Brick in _bricks)
            {
                if (_physicsService.IsCollision(_ball, Brick))
                {
                    BounceActorsY(_ball);
                    BrokenBricks.Add(Brick);
                    audioService.PlaySound(Constants.SOUND_BOUNCE);
                }
            }
            foreach (Actor Brick in BrokenBricks)
            {
                cast["bricks"].Remove(Brick);
            }
            //paddle collisions
            foreach (Actor Paddle in _paddle)
            {
                if (_physicsService.IsCollision(_ball, Paddle))
                {
                    BounceActorsY(_ball);
                    audioService.PlaySound(Constants.SOUND_BOUNCE);
                    int x = _ball.GetVelocity().GetX();
                    int y = _ball.GetVelocity().GetY();
                    if (x > 0)
                    {
                        x += 1;
                    }
                    else
                    {
                        x -= 1;
                    }
                    if (y > 0)
                    {
                        y += 1;
                    }
                    else
                    {
                        y -= 1;
                    }
                    _ball.SetVelocity(new Point(x, y));
                }
            }
        }

        private void BounceActorsX(Actor actor)
        {
            int x = actor.GetVelocity().GetX();
            int y = actor.GetVelocity().GetY();
            x *= -1;
            actor.SetVelocity(new Point(x,y));
        }
        private void BounceActorsY(Actor actor)
        {
            int x = actor.GetVelocity().GetX();
            int y = actor.GetVelocity().GetY();
            y *= -1;
            actor.SetVelocity(new Point(x,y));
        }
        
    }
}