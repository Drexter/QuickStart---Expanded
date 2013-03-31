using System.Collections;

namespace QuickStart.Models
{
    public class Blog
    {
        private long _id;
        private string _name;
        private IList _items;

        public virtual long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual IList Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}