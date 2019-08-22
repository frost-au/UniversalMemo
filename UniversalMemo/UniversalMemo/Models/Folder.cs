using System;


namespace UniversalMemo.Models
{
    public class Folder
    {
        public Guid BelongsTo { get; set; }
        public string Text { get; set; }
        public DateTime Detail { get; set; }

        //for inital creatation
        public Folder(string newName, DateTime newDateTime)
        {
            this.Text = newName;
            this.Detail = newDateTime;
        }
        //For DB retrival
        public Folder(Guid NewKey, string NewText, DateTime Detail)
        {
            this.BelongsTo = NewKey;
            this.Text = NewText;
            this.Detail = Detail;
        }

        public Folder()
        {

        }

        public String DateToString()
        {
            return Detail.ToString();
        }
    }
}
