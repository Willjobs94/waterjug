using System;
using System.Collections.Generic;
using System.Linq;

namespace WaterJugChallange
{
    public class WaterJugChallange
    {

        private int _xJugSize;
        private int _yJugSize;
        private int _targetAmount;


        public WaterJugChallange(int xJugSize, int yJugSize, int targetAmount)
        {
            _xJugSize = xJugSize;
            _yJugSize = yJugSize;
            _targetAmount = targetAmount;
        }

        private List<string> Pour(int JugX, int JugY, int targetAmount)
        {
            var stepList = new List<string>();

            var fromJugX = JugX;
            var to = 0;


            stepList.Add($"Fill Jug X              | (X Jug: {fromJugX}, Y Jug: {to})");

            while (fromJugX != targetAmount && to != targetAmount)
            {
                var minPouredAmount = Math.Min(fromJugX, JugY - to);

                to += minPouredAmount;
                fromJugX -= minPouredAmount;

                stepList.Add($"Transfer Jug X to Jug Y | (X Jug: {fromJugX}, Y Jug: {to})");


                if (fromJugX == targetAmount || to == targetAmount)
                    break;

                if (fromJugX == 0)
                {
                    stepList.Add($"Fill Jug X              | (X Jug: {JugX}, Y Jug: {to})");
                    fromJugX = JugX;
                }

                if (to == JugY)
                {
                    stepList.Add($"Empty Jug Y             | (X Jug: {fromJugX}, Y Jug: {0})");
                    to = 0;
                }
            }

            var lastStep = stepList.Last();
            if (string.IsNullOrEmpty(lastStep))
            {

                lastStep += " Solved";
                stepList[stepList.Count - 1] = lastStep;
            }

            return stepList;
        }

        
        private List<string> Flush(int JugX, int JugY, int targetAmount)
        {
            var stepList = new List<string>();

            var fromJugY = JugY;
            var to = 0;


            stepList.Add($"Fill Jug Y              | (X Jug: {to}, Y Jug: {fromJugY})");

            while (fromJugY != targetAmount && to != targetAmount)
            {
                var minPouredAmount = Math.Min(fromJugY, JugX - to);

                to += minPouredAmount;
                fromJugY -= minPouredAmount;

                stepList.Add($"Transfer Jug Y to Jug X | (X Jug: {to}, Y Jug: {fromJugY})");


                if (fromJugY == targetAmount || to == targetAmount)
                    break;

                if (fromJugY == 0)
                {
                    stepList.Add($"Fill Jug X              | (X Jug: {JugX}, Y Jug: {to})");
                    fromJugY = JugX;
                }

                if (to == JugX)
                {
                    stepList.Add($"Empty Jug X             | (X Jug: {0}, Y Jug: {fromJugY})");
                    to = 0;
                }
            }

            var lastStep = stepList.Last();
            if (string.IsNullOrEmpty(lastStep))
            {

                lastStep += " Solved";
                stepList[stepList.Count - 1] = lastStep;
            }

            return stepList;
        }

        private int GreatestCommonDivisor(int a, int b)
        {
            if (b == 0)
                return a;

            return GreatestCommonDivisor(b, a % b);
        }


        private bool IsPosible()
        {
            var maxJug = Math.Max(_xJugSize, _yJugSize);
            if (_targetAmount > maxJug) return false;

            var gcd = GreatestCommonDivisor(_xJugSize, _yJugSize);

            if (_targetAmount % gcd != 0) return false;

            return true;
        }

        public void DisplaySolution()
        {
            if (!IsPosible())
            {
                Console.WriteLine("No Solution");
                return;
            }


            if (_xJugSize > _yJugSize)
            {
                (_xJugSize, _yJugSize) = (_yJugSize, _xJugSize);
            }

            var stepsPour = Pour(_xJugSize, _yJugSize, _targetAmount);

            List<string> steps;

            var gcd = GreatestCommonDivisor(_xJugSize, _yJugSize);

            if (gcd == _xJugSize)
            { 
                var stepsFlush = Flush(_xJugSize, _yJugSize, _targetAmount);
                steps = stepsFlush.Count > stepsPour.Count ? stepsPour : stepsFlush;
            }
            else
            {
                steps = stepsPour;
            }

            Console.WriteLine($"\nJugs sizes X: {_xJugSize}, Y: {_yJugSize}");
            Console.WriteLine("\n=============== STEPS ==============");
            foreach (var step in steps)
            {
                Console.WriteLine(step);
            }
        }
    }
}










