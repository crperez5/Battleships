using Battleships.Application.Common;
using Battleships.Application.Enums;
using Battleships.Application.Events;
using Battleships.Application.Extensions;
using System.Timers;

namespace Battleships.Application.Entities
{
    public class Game
    {
        private int _secondsLeft;
        private readonly Timer _timer;
        private readonly Radar _radar;

        public event TimeElapsedEventHandler TimeElapsed;
        public event TimeOutEventHandler TimeOut;
        public event ShotMissedEventHandler ShootMissed;
        public event TargetHitEventHandler TargetHit;
        public event ShipSunkEventHandler ShipSunk;
        public event UserVictoryEventHandler UserVictory;

        public GameBoard Board { get; }
        public GameStatus Status { get; private set; }

        public Game()
        {
            Status = GameStatus.InProgress;
            Board = new GameBoard();

            _radar = new Radar();

            var battleship = new Battleship();
            battleship.AddCompartiments(Board.GetParkingSpace(battleship.CompartimentsNumber));
            _radar.TrackShip(battleship);

            var destroyer1 = new Destroyer();
            destroyer1.AddCompartiments(Board.GetParkingSpace(destroyer1.CompartimentsNumber));
            _radar.TrackShip(destroyer1);

            var destroyer2 = new Destroyer();
            destroyer2.AddCompartiments(Board.GetParkingSpace(destroyer2.CompartimentsNumber));
            _radar.TrackShip(destroyer2);

            _secondsLeft = Constants.DefaultGameLengthInSeconds;

            _timer = new Timer() { Interval = 1000 };
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        public void AttemptShoot(Coordinates coordinates)
        {
            if (Status != GameStatus.InProgress)
            {
                return;
            }

            Ship ship = _radar.FindShip(coordinates);

            if (ship == null)
            {
                Board.Board[coordinates.Column, coordinates.Row].MarkAsMissed();
                ShotMissedEventHandler shotMissedEventHandler = ShootMissed;
                shotMissedEventHandler?.Invoke(this, new ShotMissedEventArgs());
                return;
            }

            ship.GetShot(coordinates);
            Board.Board[coordinates.Column, coordinates.Row].MarkAsHit();
            TargetHitEventHandler targetHitEventHandler = TargetHit;
            targetHitEventHandler?.Invoke(this, new TargetHitEventArgs());


            if (ship.Status == ShipStatus.Sunk)
            {
                ShipSunkEventHandler shipSunkEventHandler = ShipSunk;
                var shipSunkEventArgs = new ShipSunkEventArgs(ship.GetType().Name);
                shipSunkEventHandler?.Invoke(this, shipSunkEventArgs);
            }

            if (!_radar.AnyShipAlive())
            {
                UserVictoryEventHandler userVictoryEventHandler = UserVictory;
                userVictoryEventHandler?.Invoke(this, new UserVictoryEventArgs());
                Status = GameStatus.Victory;
                _timer.Stop();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _secondsLeft -= 1;

            if (_secondsLeft == 0)
            {
                Status = GameStatus.TimeOut;
                _timer.Stop();
                _timer.Dispose();

                TimeOutEventHandler TimeOutEventHandler = TimeOut;
                TimeOutEventHandler?.Invoke(this, new TimeOutEventArgs());

            }

            var gameTimeElapsedEvent = new TimeElapsedEventArgs
            {
                SecondsLeft = _secondsLeft
            };

            TimeElapsedEventHandler timeElapsedHandler = TimeElapsed;
            timeElapsedHandler?.Invoke(this, gameTimeElapsedEvent);
        }
    }
}
