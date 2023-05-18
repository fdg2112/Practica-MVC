using Data;

namespace Logic
{
    public class BaseLogic
    {
        protected NorthwindContext _context;

        public BaseLogic()
        {
            _context = new NorthwindContext();
        }
    }
}
