
namespace CleanCode.MagicNumbers
{
    // magin number - reader of the code does't know what the number represents
    public class MagicNumbers
    {
        private const int Draft = 1;
        private const int Lodged = 2;

        public void ApproveDocument(int status)
        {
            if (status == Draft)
            {
                // ...
            }
            else if (status == Lodged)
            {
                // ...
            }
        }

        public void RejectDoument(string status)
        {
            switch (status)
            {
                case "1":
                    // ...
                    break;
                case "2":
                    // ...
                    break;
            }
        }
    }
}
