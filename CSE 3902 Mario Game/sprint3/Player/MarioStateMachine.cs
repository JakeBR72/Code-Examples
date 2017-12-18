using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Timers;

namespace MarioGame
{
    public class MarioStateMachine
    {
        IMarioSprite MarioSprite;

        public bool ShouldCollide { get; set; } = true;
        public Vector2 Location { get; set; }
        public bool FacingLeft {get; set; }
        public bool IsMovingVertically { get; set; }
        public bool PreviousDirection { get; set; }
        public IPhysics Physics { get; set; }

        public enum MarioSize { Small,Big,Fire };
        private MarioSize size;
        public MarioSize Size {
            get { return size;}
            set {
                if ((value == MarioSize.Small || size == MarioSize.Small) && value != size)
                {
                    needsCorrect = true;
                }
                size = value;
            }
        }
        public MarioSize PreviousSize { get; set; }

        public enum MarioState { Idle, Running, Jumping, Ducking };
        public MarioState State { get; set; }
        public MarioState PreviousState { get; set; }

        public enum MarioHealth {Normal,Dead}
        public MarioHealth Health { get; set; }
        public Rectangle Destination {get; set;}

        Timer TransitionTimer = new Timer();
        Timer InvulnerabilityTimer = new Timer();
        MarioSize OriginalSize = new MarioSize();
        MarioSize DestinationSize = new MarioSize();
        int TransitionCount, InvulnCount;

        public bool isInvincible { get; set; }
        public bool DrawInvisibleSprite { get; set; }

        private bool needsCorrect = false;

        public Color Shade
        {
            get { return MarioSprite.Shade;}
            set {  MarioSprite.Shade = value;}
        }

        public MarioStateMachine()
        {
            Location = new Vector2(400, 300);
            FacingLeft = false;
            PreviousDirection = false;
            IsMovingVertically = false;
            Size = MarioSize.Small;
            PreviousSize = MarioSize.Small;
            State = MarioState.Idle;
            PreviousState = MarioState.Idle;
            Health = MarioHealth.Normal;
            MarioSprite = MarioSpriteFactory.Instance.GetIdleSprite(Size, FacingLeft);

            TransitionTimer.Interval = 125;
            TransitionTimer.Elapsed += new ElapsedEventHandler(TransitionAnim);

            InvulnerabilityTimer.Interval = 50;
            InvulnerabilityTimer.Elapsed += new ElapsedEventHandler(InvulnerabilityFlashAnim);

            isInvincible = false;
            DrawInvisibleSprite = false;
            TransitionCount = 0;
            InvulnCount = 0;
        }

        public void SetSmall()
        {
            MarioSoundBoard.Instance.PlayMarioPowerup();
            OriginalSize = Size;
            DestinationSize = MarioSize.Small;
            TransitionTimer.Start();
        }
        public void SetBig()
        {
            MarioSoundBoard.Instance.PlayMarioPowerup();
            OriginalSize = Size;
            DestinationSize = MarioSize.Big;
            TransitionTimer.Start();          
        }
        public void SetFire()
        {
            MarioSoundBoard.Instance.PlayMarioPowerup();
            OriginalSize = Size;
            DestinationSize = MarioSize.Fire;
            TransitionTimer.Start();     
        }

        public void SetLeft()
        {
            FacingLeft = true;
        }
        public void SetRight()
        {
            FacingLeft = false;
        }

        public void Idle()
        {
            if (State != MarioState.Idle)
            {
                State = MarioState.Idle;
            }
        }
        public void Run()
        {
            if (State != MarioState.Running)
            {
                State = MarioState.Running;
            }
        }
        public void Jump()
        {
            if (State != MarioState.Jumping)
            {
                MarioSoundBoard.Instance.PlayMarioJump();
                State = MarioState.Jumping;
            }
        }
        public void Duck()
        {
            if(State != MarioState.Ducking) {
                State = MarioState.Ducking;             
            }
        }
        public void KillMario()
        {
            Physics.YVelocity = -2;
            ShouldCollide = false;
            if ( Health != MarioHealth.Dead)
            {
                MusicManager.Instance.StopBackgroundMusic();
                MarioSoundBoard.Instance.PlayMarioDie();
                Health = MarioHealth.Dead;
            }
        }

        public void TakeDamage()
        {

            if (!isInvincible && Size == MarioSize.Fire)
            {
                OriginalSize = MarioSize.Fire;
                DestinationSize = MarioSize.Big;
                isInvincible = true;
                TransitionTimer.Start();
                InvulnerabilityTimer.Start();
                MarioSoundBoard.Instance.PlayMarioDamage();
            } else if(!isInvincible && Size == MarioSize.Big)
            {
                OriginalSize = MarioSize.Big;
                DestinationSize = MarioSize.Small;
                isInvincible = true;
                TransitionTimer.Start();
                InvulnerabilityTimer.Start();
                MarioSoundBoard.Instance.PlayMarioDamage();
            }
            else if (!isInvincible)
            {
                Physics.YVelocity = -2;
                KillMario();
            }
        }
        
        private void TransitionAnim(object source, ElapsedEventArgs e)
        {
            int iterations = 8;
            if (Size == OriginalSize) {
                Size = DestinationSize;

            } else
            {
                Size = OriginalSize;
            }

            TransitionCount++;

            if (TransitionCount >= iterations)
            { 
                Size = DestinationSize;
                needsCorrect = false;
                TransitionTimer.Stop();
                TransitionCount = 0;
            }
            getMarioSprite(true);
        }

        private void InvulnerabilityFlashAnim(object source, ElapsedEventArgs e)
        {
            int iterations = 25;    //Adjusts how long Mario will be invincible for

            DrawInvisibleSprite = !DrawInvisibleSprite;

            InvulnCount++;

            if (InvulnCount >= iterations)
            {
                InvulnerabilityTimer.Stop();
                needsCorrect = false;
                DrawInvisibleSprite = false;
                isInvincible = false;
                InvulnCount = 0;
            }

            getMarioSprite(true);
        }

        public void SetPosition(Vector2 loc)
        {
            Destination = new Rectangle((int)loc.X, (int)loc.Y, 
                Destination.Width, Destination.Height);
            Location = loc;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (needsCorrect)
            {
                needsCorrect = false;
                if (Size == MarioSize.Small) { 
                    SetPosition(new Vector2(Destination.X, Destination.Y + 16));
                } else
                {
                    SetPosition(new Vector2(Destination.X, Destination.Y - 16));
                }
            }
            Destination = MarioSprite.Draw(spriteBatch, Location);
        }
        public void Update(GameTime gameTime)
        {

            Physics.UpdatePosition();
            bool ForceUpdate = false;
            IsMovingVertically = false;
            if (FacingLeft != PreviousDirection || Size != PreviousSize)
            {
                ForceUpdate = true;
                PreviousDirection = FacingLeft;
                PreviousSize = Size;
            }
            getMarioSprite(ForceUpdate);
            

            MarioSprite.Update(gameTime);           
        }

        private void getMarioSprite(bool ForceUpdate)
        {
            if (Health == MarioHealth.Normal && !DrawInvisibleSprite)
            {
                switch (State)
                {
                    case MarioState.Idle:
                        if (ForceUpdate || !(MarioSprite is MarioIdleSprite))
                            MarioSprite = MarioSpriteFactory.Instance.GetIdleSprite(Size, FacingLeft);
                        break;
                    case MarioState.Running:
                        if (ForceUpdate || !(MarioSprite is MarioRunningSprite))
                            MarioSprite = MarioSpriteFactory.Instance.GetRunningSprite(Size, FacingLeft);
                        break;
                    case MarioState.Jumping:
                        if (ForceUpdate || !(MarioSprite is MarioJumpingSprite))
                            MarioSprite = MarioSpriteFactory.Instance.GetJumpingSprite(Size, FacingLeft);
                        break;
                    case MarioState.Ducking:
                        if (ForceUpdate || !(MarioSprite is MarioDuckingSprite))
                            MarioSprite = MarioSpriteFactory.Instance.GetDuckingSprite(Size, FacingLeft);
                        break;
                }
            }
            else
            {
                if (DrawInvisibleSprite)
                    MarioSprite = MarioSpriteFactory.Instance.GetInvisibleSprite();
                else if (!(MarioSprite is MarioDeadSprite))
                    MarioSprite = MarioSpriteFactory.Instance.GetDeadSprite();
            }

        }
    }
}
