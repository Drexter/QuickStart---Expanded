using System;

namespace QuickStart.Models
{
    public class BlogItem
    {
        private long _id;
        private DateTime _dateTime;
        private string _text;
        private string _title;
        private Blog _blog;

        public virtual Blog Blog
        {
            get { return _blog; }
            set { _blog = value; }
        }

        public virtual DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public virtual long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public virtual string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}