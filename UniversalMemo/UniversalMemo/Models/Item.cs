using System;
using SQLite;
namespace UniversalMemo.Models
{
    public class Item
    {
        public Guid Key { get; set; }
        public Guid BelongsTo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public Item()
        {

        }
        public Item(Guid NewKey, Guid NewBelongsTo, string NewName, string NewDescription, string NewBody, DateTime NewDate)
        {
            Key = NewKey;
            BelongsTo = NewBelongsTo;
            Name = NewName;
            Description = NewDescription;
            Body = NewBody;
            Date = NewDate;
        }
    }
}