namespace NumberVerify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SwedishPersonalNumber.VerifyPersonalNumber("19890326-1611");
            ISBN.VerifyIsbnNumber("978-0-306-40615-7");
        }
    }
}