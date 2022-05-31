using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Award
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PathToImage { get; set; }
        public Award(string title) : this(Guid.NewGuid(), title)
        {

        }
        public Award()
        {

        }
        public Award(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
        public void Edit(string title)
        {
            Title = title;
        }
    }
}
