namespace OOP_Structures
{
    internal class Program
    {
        abstract class Dog
        {
            protected abstract int SoundStregth { get; set; }
            protected virtual string Sound { get; set; } = "Gav";

            public void MakeNeighborAngry()
            {
                RepeatSound(SoundStregth);
            }

            private void RepeatSound(int count)
            {
                for (var i = 0; i < count; i++)
                    MakeSound();
            }

            private void MakeSound()
            {
                Console.WriteLine(Sound);
            }
        }

        class Pitbull : Dog, IBadDog
        {
            protected override int SoundStregth { get; set; } = 5;
        }

        class AngryPitbull : Pitbull
        {
            public void MakeSound()
            {
                Console.WriteLine("GaVV");
            }
        }


        class Hasky : Dog, IBadDog
        {
            protected override int SoundStregth { get; set; } = 10;
        }

        class AnotherDog: IBadDog
        {

            public void MakeNeighborAngry()
            {
                RepeatSound(10);
            }

            private void RepeatSound(int count)
            {
                for (var i = 0; i < count; i++)
                    MakeSound();
            }

            private void MakeSound()
            {
                Console.WriteLine("Gaav");
            }
        }


        interface IBadDog
        {
            void MakeNeighborAngry();
        }

        static void Main(string[] args)
        {
            var angryPitbull = new AngryPitbull();

            angryPitbull.MakeNeighborAngry();

            Console.ReadKey();
        }        
    }
}