using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;


namespace Lab2
{
    public class Student : IDisposable
    {
        private bool _Disposed = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DynamicArray<int> Scores { get; set; }
        public Student(string lastName, string firstName, int numScores)
        {
            LastName = lastName;
            FirstName = firstName;
            Scores = new DynamicArray<int>(numScores);

        }
        public override string ToString()
        {

            return string.Format("{0,-15} {1,-15} {2,5} {3,5}", LastName, FirstName, Scores.Count(), Scores.Average().ToString("#.000"));
        }

        public void Dispose()
        {
            Console.WriteLine($"Disposing Student from thread {Thread.CurrentThread.ManagedThreadId}");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed == true)
            {
                return;
            }
            if (disposing == true)
            {
                Scores?.Dispose();
                Scores = null;
                

                _Disposed = true;
                return;
            }
        }
        ~Student()
        {
            Console.WriteLine($"Finalizing Student from thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
