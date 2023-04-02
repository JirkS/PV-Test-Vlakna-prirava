namespace VlaknaNaTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random gnr = new Random();
            Hrac hrac = new Hrac("IronMan", 100);

            Thread t1 = new Thread(() => Damage(hrac, gnr));
            Thread t2 = new Thread(() => Heal(hrac, gnr));

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(hrac.ToString());

        }
        public static void Heal(Hrac h, Random gnr)
        {

            for (int i = 0; i < 10; i++)
            {
                h.Heal(gnr.Next(10) + 1);
            }
        }

        public static void Damage(Hrac h, Random gnr)
        {

            for(int i = 0; i < 10; i++)
            {
                h.Damage(gnr.Next(10)+1);
            }
        }

    }
}