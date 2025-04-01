using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFB_ATM
{
    /// <summary>
    /// Provides high-precision timing measurement for performance testing
    /// </summary>
    public class Timing
    {
        private Stopwatch _stopwatch;
        private TimeSpan _elapsedTime;
        private bool _isRunning;

        public Timing()
        {
            _stopwatch = new Stopwatch();
            _elapsedTime = TimeSpan.Zero;
            _isRunning = false;
        }

        /// <summary>
        /// Starts or resumes the timer
        /// </summary>
        public void StartTime()
        {
            if (!_isRunning)
            {
                _stopwatch.Start();
                _isRunning = true;
            }
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void StopTime()
        {
            if (_isRunning)
            {
                _stopwatch.Stop();
                _elapsedTime = _stopwatch.Elapsed;
                _isRunning = false;
            }
        }

        /// <summary>
        /// Resets the timer to zero
        /// </summary>
        public void Reset()
        {
            _stopwatch.Reset();
            _elapsedTime = TimeSpan.Zero;
            _isRunning = false;
        }

        /// <summary>
        /// Gets the elapsed time
        /// </summary>
        /// <returns>TimeSpan representing elapsed time</returns>
        public TimeSpan Result()
        {
            return _isRunning ? _stopwatch.Elapsed : _elapsedTime;
        }

        /// <summary>
        /// Gets the elapsed time in milliseconds
        /// </summary>
        /// <returns>Elapsed milliseconds</returns>
        public double ElapsedMilliseconds()
        {
            return Result().TotalMilliseconds;
        }

        /// <summary>
        /// Gets the elapsed time in seconds
        /// </summary>
        /// <returns>Elapsed seconds</returns>
        public double ElapsedSeconds()
        {
            return Result().TotalSeconds;
        }

        /// <summary>
        /// Gets a formatted string of the elapsed time
        /// </summary>
        /// <returns>Formatted time string</returns>
        public string GetFormattedTime()
        {
            TimeSpan elapsed = Result();
            return $"{elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds:000}";
        }
    }
}