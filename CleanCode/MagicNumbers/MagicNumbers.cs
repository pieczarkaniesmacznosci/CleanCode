
namespace CleanCode.MagicNumbers
{
    // use const or enums insted of magic numbers
    public enum DocumentStatus
    {
        Draft = 1,
        Lodged = 2
    }
    // magin number - reader of the code does't know what the number represents
    public class MagicNumbers
    {

        public void ApproveDocument(int status)
        {
            if (status.Equals(DocumentStatus.Draft))
            {
                // ...
            }
            else if (status.Equals(DocumentStatus.Lodged))
            {
                // ...
            }
        }

        public void RejectDoument(DocumentStatus status)
        {
            switch (status)
            {
                case DocumentStatus.Draft:
                    // ...
                    break;
                case DocumentStatus.Lodged:
                    // ...
                    break;
            }
        }
    }
}
