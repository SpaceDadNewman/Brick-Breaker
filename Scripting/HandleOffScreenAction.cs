using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;

namespace cse210_batter_csharp
{
    public class HandleOffScreenAction : Action
    {
        AudioService audioService = new AudioService();
        public List<Actor> BallsRemove = new List<Actor>();
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> group in cast.Values)
            {
                foreach (Actor actor in group)
                {
                    if (actor.GetLeftEdge() <= 15)
                    {
                        BounceActorsX(actor);
                    }
                    
                    if (actor.GetRightEdge() >= Constants.MAX_X - 15)
                    {
                        BounceActorsX(actor);
                    }

                    if (actor.GetTopEdge() <= 0)
                    {
                        BounceActorsY(actor);
                    }

                    if (actor.GetPosition().GetY() >= Constants.MAX_Y - 5)
                    {
                        BallsRemove.Add(actor);
                    }
                }
                foreach (Actor actor in BallsRemove)
                {
                    cast["balls"].Remove(actor);
                    audioService.PlaySound(Constants.SOUND_OVER);
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